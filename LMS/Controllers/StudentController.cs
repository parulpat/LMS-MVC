using LMS.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    public class StudentController : Controller
    {
        private readonly DbContextApp dbContextApp;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public StudentController(DbContextApp _dbContextApp, IWebHostEnvironment hostEnvironment, UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            dbContextApp = _dbContextApp;
            webHostEnvironment = hostEnvironment;
            userManager = _userManager;
            roleManager = _roleManager;
        }
        public async Task<IActionResult> List()
        {
            List<StudentViewModel> model = new List<StudentViewModel>();
            model = (from std in dbContextApp.Students
                     where std.IsActive == true
                     select new StudentViewModel()
                     {
                         StudentId = std.StudentId,
                         StudentName = std.StudentName,
                         BranchId = std.BranchId,
                         Branchs = std.Branchs,
                         Gender = std.Gender,
                         DateOfBirth = std.DateOfBirth,
                         MobileNo = std.MobileNo,
                         Address = std.Address,
                         City = std.City,
                         Pincode = std.Pincode,
                         IsActive = std.IsActive,
                         PhotoPath = std.Photo,
                         Email = std.Email,
                         Password = std.Password,
                         RoleId = std.RoleId,
                         Roles = std.Roles
                     }).ToList();
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.BranchId = (from branch in dbContextApp.Branches
                                   where branch.IsActive == true
                                   select new Branch()
                                   {
                                       BranchName = branch.BranchName,
                                       BranchId = branch.BranchId
                                   }).ToList();
            return View();
        }
         public async Task<IActionResult> save(StudentViewModel student)
        {
            var fileName = "";
            int updaterow = 0;
            var view = "";
            if (student.Photo != null)
            {
                fileName = await UploadFile(student.Photo);
            }
            Student stds = new Student()
            {
                StudentId = student.StudentId,
                StudentName = student.StudentName,
                BranchId = student.BranchId,
                Branchs = student.Branchs,
                Gender = student.Gender,
                DateOfBirth = student.DateOfBirth,
                MobileNo = student.MobileNo,
                Address = student.Address,
                City = student.City,
                Pincode = student.Pincode,
                IsActive = true,
                Photo = fileName,
                Email = student.Email,
                Password = student.Password,
                RoleId = student.RoleId,
            };
            
                var userExit = await userManager.FindByNameAsync(stds.Email);
                if(userExit == null)
                {
                    ApplicationUser applicationUser = new ApplicationUser()
                    {
                        Address = stds.Address,
                        FirstName = stds.StudentName,
                        UserName = stds.Email,
                        Email = stds.Email,
                        PhoneNumber = stds.MobileNo
                    };
                    await userManager.CreateAsync(applicationUser, stds.Password);
                    var roleType = await dbContextApp.Roles.FindAsync(stds.RoleId);
                    var roleExit = await roleManager.RoleExistsAsync(roleType.RoleName);
                    if (roleExit == false)
                    {
                        IdentityRole identityRole = new IdentityRole()
                        {
                            Name = roleType.RoleName
                        };
                        await roleManager.CreateAsync(identityRole);
                    }
                    await userManager.AddToRoleAsync(applicationUser, roleType.RoleName);
               

                dbContextApp.Students.Add(stds);
                updaterow = dbContextApp.SaveChanges();
                if (updaterow > 0)
                {
                    view = "List";
                }
            }
               
            
            
            return RedirectToAction(view);
        }
        public async Task<IActionResult> Edit(int Id)
        {
            
            var model =  (from std in dbContextApp.Students
                                 where std.IsActive == true && std.StudentId == Id
                                 select new StudentViewModel()
                                 {
                                     StudentId = std.StudentId,
                                     StudentName = std.StudentName,
                                     BranchId = std.BranchId,
                                     Branchs = std.Branchs,
                                     Gender = std.Gender,
                                     DateOfBirth = std.DateOfBirth,
                                     MobileNo = std.MobileNo,
                                     Address = std.Address,
                                     City = std.City,
                                     Pincode = std.Pincode,
                                     IsActive = true,
                                     PhotoPath = std.Photo,
                                     Email = std.Email,
                                     Password = std.Password,
                                     RoleId = std.RoleId,
                                     Roles = std.Roles
                                 }).FirstOrDefault();
            var userDetail = await userManager.FindByNameAsync(model.Email);
            ViewBag.UserDetailId = userDetail.Id;
            ViewBag.BranchId = (from branch in dbContextApp.Branches
                                where branch.IsActive == true
                                select new Branch()
                                {
                                    BranchName = branch.BranchName,
                                    BranchId = branch.BranchId
                                }).ToList();
            return View(model);
        }
        public async Task<IActionResult> update(StudentViewModel student)
        {
            var fileName = "";
            int updaterow = 0;
            var view = "";
            if (student.Photo != null)
            {
                fileName = await UploadFile(student.Photo);
            }
            else
            {
                fileName = student.PhotoPath;
            }
            Student stud = new Student()
            {
                StudentId = student.StudentId,
                StudentName = student.StudentName,
                BranchId = student.BranchId,
                Branchs = student.Branchs,
                Gender = student.Gender,
                DateOfBirth = student.DateOfBirth,
                MobileNo = student.MobileNo,
                Address = student.Address,
                City = student.City,
                Pincode = student.Pincode,
                IsActive = true,
                Photo = fileName,
                Email = student.Email,
                Password = student.Password,
                RoleId = student.RoleId,
            };
            ApplicationUser applicationUser = new ApplicationUser()
            {
                Address = stud.Address,
                FirstName = stud.StudentName,
                UserName = stud.Email,
                Email = stud.Email,
                PhoneNumber = stud.MobileNo
            };
            var user = await userManager.FindByIdAsync(student.UserId);
            user.UserName = applicationUser.Email;
            user.Email = applicationUser.Email;
            user.FirstName = applicationUser.FirstName;
            user.PhoneNumber = applicationUser.PhoneNumber;
            user.Address = applicationUser.Address;
            var result = await userManager.UpdateAsync(user);
            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            var result1 = await userManager.ResetPasswordAsync(user, token, student.Password);
           if(result.Succeeded == true && result1.Succeeded == true)
            {
                dbContextApp.Students.Update(stud);
                updaterow = dbContextApp.SaveChanges();
                if (updaterow > 0)
                {
                    view = "List";
                }
            }
            return RedirectToAction(view);
        }
        public async Task<IActionResult> Details(int Id)
        {
            var model = (from student in dbContextApp.Students
                         where student.IsActive == true && student.StudentId == Id
                         select new StudentViewModel()
                         {
                             StudentId = student.StudentId,
                             StudentName = student.StudentName,
                             BranchId = student.BranchId,
                             Branchs = student.Branchs,
                             Gender = student.Gender,
                             DateOfBirth = student.DateOfBirth,
                             MobileNo = student.MobileNo,
                             Address = student.Address,
                             City = student.City,
                             Pincode = student.Pincode,
                             IsActive = student.IsActive,
                             PhotoPath = student.Photo,
                             Email = student.Email,
                             Password = student.Password,
                             RoleId = student.RoleId,
                             Roles = student.Roles
                         }).FirstOrDefault();
           
            return View(model);
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var model = (from student in dbContextApp.Students
                         where student.IsActive == true && student.StudentId == Id
                         select new Student()
                         {
                             StudentId = student.StudentId,
                             StudentName = student.StudentName,
                             BranchId = student.BranchId,
                             Branchs = student.Branchs,
                             Gender = student.Gender,
                             DateOfBirth = student.DateOfBirth,
                             MobileNo = student.MobileNo,
                             Address = student.Address,
                             City = student.City,
                             Pincode = student.Pincode,
                             IsActive = student.IsActive,
                             Email = student.Email,
                             Password = student.Password,
                         }).FirstOrDefault();
            model.IsActive = false;
            int upadaterow = 0;
            var view = "List";
            dbContextApp.Students.Update(model);
            upadaterow = await dbContextApp.SaveChangesAsync();
            if (upadaterow > 0)
            {
                view = "List";
            }
            return RedirectToAction(view);
        }
        public async Task<string> UploadFile(IFormFile file)
        {
            string filename = "";
            string path = "";
            bool iscopied = false;
            try
            {

                if (file.Length > 0)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    filename = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadsFolder, filename);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                }
                return filename;
            }
            catch (Exception)
            {
                throw;
            }
            return filename;
        }

        public async Task<IActionResult> StudentReport(int branchId=0,string studentName = null)
        {
           
            ViewBag.BranchId = (from branch in dbContextApp.Branches
                                where branch.IsActive == true
                                select new Branch()
                                {
                                    BranchName = branch.BranchName,
                                    BranchId = branch.BranchId
                                }).ToList();
            List<StudentViewModel> stdmodel = new List<StudentViewModel>();
            if (branchId != 0)
            {
                stdmodel = (from std in dbContextApp.Students
                             where std.IsActive == true && std.BranchId == branchId
                             select new StudentViewModel()
                             {
                                 StudentId = std.StudentId,
                                 StudentName = std.StudentName,
                                 BranchId = std.BranchId,
                                 Branchs = std.Branchs,
                                 Gender = std.Gender,
                                 DateOfBirth = std.DateOfBirth,
                                 MobileNo = std.MobileNo,
                                 Address = std.Address,
                                 City = std.City,
                                 Pincode = std.Pincode,
                                 IsActive = std.IsActive,
                                 PhotoPath = std.Photo,
                                 Email = std.Email,
                                 Password = std.Password,
                                 RoleId = std.RoleId,
                                 Roles = std.Roles
                             }).ToList();
            }
            else if (studentName != null)
            {
                stdmodel = (from std in dbContextApp.Students
                             where std.IsActive == true && std.StudentName.Contains(studentName)
                            select new StudentViewModel()
                             {
                                 StudentId = std.StudentId,
                                 StudentName = std.StudentName,
                                 BranchId = std.BranchId,
                                 Branchs = std.Branchs,
                                 Gender = std.Gender,
                                 DateOfBirth = std.DateOfBirth,
                                 MobileNo = std.MobileNo,
                                 Address = std.Address,
                                 City = std.City,
                                 Pincode = std.Pincode,
                                 IsActive = std.IsActive,
                                 PhotoPath = std.Photo,
                                 Email = std.Email,
                                 Password = std.Password,
                                 RoleId = std.RoleId,
                                 Roles = std.Roles
                             }).ToList();
            }
            else
            {
                stdmodel = (from std in dbContextApp.Students
                             where std.IsActive == true
                             select new StudentViewModel()
                             {
                                 StudentId = std.StudentId,
                                 StudentName = std.StudentName,
                                 BranchId = std.BranchId,
                                 Branchs = std.Branchs,
                                 Gender = std.Gender,
                                 DateOfBirth = std.DateOfBirth,
                                 MobileNo = std.MobileNo,
                                 Address = std.Address,
                                 City = std.City,
                                 Pincode = std.Pincode,
                                 IsActive = std.IsActive,
                                 PhotoPath = std.Photo,
                                 Email = std.Email,
                                 Password = std.Password,
                                 RoleId = std.RoleId,
                                 Roles = std.Roles
                             }).ToList();
            }
            return View(stdmodel);
        }

        public async Task<IActionResult> GetStudentReportDetail(int Id)
        {
            BookViewModel bookmodel = new BookViewModel();
            bookmodel = (from book in dbContextApp.Books
                         where book.IsActive == true && book.BookId == Id
                         select new BookViewModel()
                         {
                             BookId = book.BookId,
                             BookName = book.BookName,
                             Detail = book.Detail,
                             Author = book.Author,
                             PubId = book.PubId,
                             Publications = book.Publications,
                             BranchId = book.BranchId,
                             Branchs = book.Branchs,
                             Price = book.Price,
                             Quantity = book.Quantity,
                             IsActive = book.IsActive,
                             BookPhotoPath = book.BookPhoto,
                             Available = book.Available,
                             Rent = book.Rent
                         }).FirstOrDefault();
            return View(bookmodel);
        }
    }
}
