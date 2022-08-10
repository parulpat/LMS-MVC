using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    public class PublicationController : Controller
    {
        private readonly DbContextApp dbContextApp;
        public PublicationController(DbContextApp _dbContextApp)
        {
            dbContextApp = _dbContextApp;
        }
        public async Task<IActionResult> List()
        {
            List<Publication> publications = new List<Publication>();
            publications = (from pub in dbContextApp.Publications where pub.IsActive == true select new Publication() {
                PublicationName = pub.PublicationName,
                IsActive = pub.IsActive,
                PubId = pub.PubId
            }).ToList();
            return View(publications);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        public async Task<IActionResult> save(Publication model)
        {
            model.IsActive = true;
            int upadaterow = 0;
            var view = "List";
             dbContextApp.Publications.AddAsync(model);
            upadaterow = await dbContextApp.SaveChangesAsync();
            if (upadaterow > 0)
            {
                view = "List";
            }
            return RedirectToAction(view);
        }
        public async Task<IActionResult> Edit(int Id)
        {
            var model = await dbContextApp.Publications.FindAsync(Id);
            return View(model);
        }
        public async Task<IActionResult> update(Publication model)
        {
            model.IsActive = true;
            int upadaterow = 0;
            var view = "List";
            dbContextApp.Publications.Update(model);
            upadaterow = await dbContextApp.SaveChangesAsync();
            if (upadaterow > 0)
            {
                view = "List";
            }
            return RedirectToAction(view);
        }
        public async Task<IActionResult> Delete(int Id)
        {
            Publication model = await dbContextApp.Publications.FindAsync(Id);
            model.IsActive = false;
            int upadaterow = 0;
            var view = "List";
            dbContextApp.Publications.Update(model);
            upadaterow = await dbContextApp.SaveChangesAsync();
            if (upadaterow > 0)
            {
                view = "List";
            }
            return RedirectToAction(view);
        }
    }
}
