using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    public class IssueBookController : Controller
    {
        private readonly DbContextApp dbContextApp;
        public IssueBookController(DbContextApp _dbContextApp)
        {
            dbContextApp = _dbContextApp;
        }
        public async Task<IActionResult> IssueBook()
        {
           
            ViewBag.BookId = (from book in dbContextApp.Books
                                where book.IsActive == true && book.Available != 0
                                select new Book()
                                {
                                    BookName = book.BookName,
                                    BookId = book.BookId
                                }).ToList();
          
            ViewBag.StudentId = (from std in dbContextApp.Students
                                where std.IsActive == true
                                select new Student()
                                {
                                    StudentName = std.StudentName,
                                    StudentId = std.StudentId
                                }).ToList();
            return View();
        }
        
        public async Task<IActionResult> IssueBooks(BoookIssue model)
        {
            model.IsActive = true;
            model.IssueDate = DateTime.UtcNow;
            model.PanaltyStatus = "No";
            var views = "";
            int updateRow = 0;
            await dbContextApp.BookIssues.AddAsync(model);
            updateRow = await dbContextApp.SaveChangesAsync();
            if(updateRow > 0)
            {
                Book book = await dbContextApp.Books.FindAsync(model.BookId);
                book.Available = book.Available - 1;
                book.Rent = book.Rent + 1;

                dbContextApp.Books.Update(book);
                var update = await dbContextApp.SaveChangesAsync();
                if (update > 0)
                {
                    views = "IssueBook";
                }
                
            }
            return RedirectToAction(views);
        }
        
        public async Task<IActionResult> IssueBookReport()
        {
            List<BoookIssue> book = new List<BoookIssue>();
            book = (from bk in dbContextApp.BookIssues where bk.IsActive == true select new BoookIssue() { 
                Days=bk.Days,
                IssueId=bk.IssueId,
                BookId=bk.BookId,
                StudentId=bk.StudentId,
                IssueDate=bk.IssueDate,
                ReturnDate=bk.ReturnDate,
                PanaltyStatus=bk.PanaltyStatus
            }).ToList();
            for(int i = 0; i < book.Count; i++)
            {
                book[i].Books = await dbContextApp.Books.FindAsync(book[i].BookId);
               book[i].Students = await dbContextApp.Students.FindAsync(book[i].StudentId);
            }
            return View(book);
        }
        public async Task<IActionResult> ReturnBook(int Id)
        {
            BoookIssue model = await dbContextApp.BookIssues.FindAsync(Id);
            model.IsActive = false;
            model.ReturnDate = DateTime.UtcNow;
            model.PanaltyStatus = "Return";
            var views = "";
            int updateRow = 0;
             dbContextApp.BookIssues.Update(model);
            updateRow = await dbContextApp.SaveChangesAsync();
            if (updateRow > 0)
            {
                Book book = await dbContextApp.Books.FindAsync(model.BookId);
                book.Available = book.Available + 1;
                book.Rent = book.Rent - 1;

                dbContextApp.Books.Update(book);
                var update = await dbContextApp.SaveChangesAsync();
                if (update > 0)
                {
                    views = "IssueBook";
                }
            }
            return RedirectToAction("IssueBookReport");
        }
    }
}
