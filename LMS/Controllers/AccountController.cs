using LMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly DbContextApp dbContextApp;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<AccountController> logger;
        
        public AccountController(DbContextApp _dbContextApp, UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager, SignInManager<ApplicationUser> _signInManager, ILogger<AccountController> _logger)
        {
            dbContextApp = _dbContextApp;
            userManager = _userManager;
            roleManager = _roleManager;
            signInManager = _signInManager;
            logger = _logger;
        }
        public IActionResult Registration()
        
        {
            ViewBag.Role = dbContextApp.Roles.ToList();
            return View();
        }
        public async Task<IActionResult> SaveRegistration(Register register)
        {
            Response response = new Response();
            var userExit = await userManager.FindByNameAsync(register.Email);
            if(userExit != null)
            {
                response.status = false;
                response.message = "User Exit";
            }
            else
            {
                
                ApplicationUser applicationUser = new ApplicationUser()
                {
                    Address = register.Address,
                    FirstName = register.Name,
                     UserName = register.Email,
                    Email = register.Email,
                    PhoneNumber = register.MobileNo
                };
                await userManager.CreateAsync(applicationUser, register.Password);
                var roleType = await dbContextApp.Roles.FindAsync(register.RoleId);
                var roleExit = await roleManager.RoleExistsAsync(roleType.RoleName);
                if(roleExit == false)
                {
                    IdentityRole identityRole = new IdentityRole()
                    {
                        Name = roleType.RoleName
                    };
                    await roleManager.CreateAsync(identityRole);
                }
                await userManager.AddToRoleAsync(applicationUser, roleType.RoleName);
            }
            return RedirectToAction("Login","Account");
        }

        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> LoginUser(Login login)
        {
            var view = "";
            var cont = "";
            if (login.Email != null && login.Password != null)
            {
                var user = await userManager.FindByNameAsync(login.Email);
                var isvalidPassword = await userManager.CheckPasswordAsync(user, login.Password);
                if (user != null && isvalidPassword)
                {
                    var signIn = await signInManager.PasswordSignInAsync(user, login.Password,isPersistent : false, lockoutOnFailure : false);
                    if (signIn.Succeeded)
                    {
                        logger.LogInformation("SUCCESS");
                        var roles = await userManager.GetRolesAsync(user);
                        ViewBag.Role = roles[0];
                        Penalty();
                        view = "Index";
                        cont = "Home";
                    }
                    else
                    {
                        logger.LogInformation("unSUCCESS");
                        view = "Login";
                        cont = "Account";
                    }
                }
                else
                {
                    view = "Login";
                    cont = "Account";
                }
            }

            return RedirectToAction(view, cont);
        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            logger.LogInformation("User Logout");
            return RedirectToAction("Login","Account");
        }
        public async Task<IActionResult> Penalty()
        {
           
            List<BoookIssue> boookIssue = new List<BoookIssue>();
          
                boookIssue = (from issuebk in dbContextApp.BookIssues
                              where  issuebk.IsActive == true
                              select new BoookIssue()
                              {
                                  BookId = issuebk.BookId,
                                  StudentId = issuebk.StudentId,
                                  Days = issuebk.Days,
                                  PanaltyStatus = issuebk.PanaltyStatus,
                                  IssueDate = issuebk.IssueDate,
                                  ReturnDate = issuebk.ReturnDate,
                                  IssueId = issuebk.IssueId,
                                  IsActive = issuebk.IsActive
                              }).ToList();
            for (int i = 0; i < boookIssue.Count; i++)
            {
                BoookIssue boook = new BoookIssue();

                boook = (from issuebk in dbContextApp.BookIssues
                              where issuebk.IsActive == true && issuebk.IssueId == boookIssue[i].IssueId
                              select new BoookIssue()
                              {
                                  BookId = issuebk.BookId,
                                  StudentId = issuebk.StudentId,
                                  Days = issuebk.Days,
                                  PanaltyStatus = issuebk.PanaltyStatus,
                                  IssueDate = issuebk.IssueDate,
                                  ReturnDate = issuebk.ReturnDate,
                                  IssueId = issuebk.IssueId,
                                  IsActive = issuebk.IsActive
                              }).FirstOrDefault();
                var issuedate = boook.IssueDate;
                var Rdate = issuedate.AddDays(boook.Days);
                var returndate = Convert.ToDateTime(Rdate).ToString("dd/MM/yyyy");
                var currentdate = Convert.ToDateTime(DateTime.UtcNow).ToString("dd/MM/yyyy");
                if (currentdate == returndate)
                {
                    boook.PanaltyStatus = "Yes Penalty";
                    dbContextApp.BookIssues.Update(boook);
                    dbContextApp.SaveChanges();
                }
            }
            
            return null;
        }
    }
}
