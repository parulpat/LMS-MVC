using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers
{
   
    public class BranchController : Controller
    {
        private readonly DbContextApp dbContextApp;
        public BranchController(DbContextApp _dbContextApp)
        {
            dbContextApp = _dbContextApp;
        }
        public async Task<IActionResult> List()
        {
            List<Branch> model = new List<Branch>();
            model = (from branch in dbContextApp.Branches where branch.IsActive == true select new Branch() {
                BranchName = branch.BranchName,
                BranchId = branch.BranchId,
                IsActive = branch.IsActive
            }).ToList();
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        public async Task<IActionResult> save(Branch model)
        {
            model.IsActive = true;
            int upadaterow = 0;
            var view = "List";
            dbContextApp.Branches.AddAsync(model);
            upadaterow = await dbContextApp.SaveChangesAsync();
            if (upadaterow > 0)
            {
                view = "List";
            }
            return RedirectToAction(view);
        }
        public async Task<IActionResult> Edit(int Id)
        {
            var model = await dbContextApp.Branches.FindAsync(Id);
            return View(model);
        }
        public async Task<IActionResult> update(Branch model)
        {
            model.IsActive = true;
            int upadaterow = 0;
            var view = "List";
            dbContextApp.Branches.Update(model);
            upadaterow = await dbContextApp.SaveChangesAsync();
            if (upadaterow > 0)
            {
                view = "List";
            }
            return RedirectToAction(view);
        }
        public async Task<IActionResult> Delete(int Id)
        {
            Branch model = await dbContextApp.Branches.FindAsync(Id);
            model.IsActive = false;
            int upadaterow = 0;
            var view = "List";
            dbContextApp.Branches.Update(model);
            upadaterow = await dbContextApp.SaveChangesAsync();
            if (upadaterow > 0)
            {
                view = "List";
            }
            return RedirectToAction(view);
        }
    }
}
