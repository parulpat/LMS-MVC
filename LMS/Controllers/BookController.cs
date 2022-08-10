using LMS.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    public class BookController : Controller
    {
        private readonly DbContextApp dbContextApp;
        private readonly IWebHostEnvironment webHostEnvironment;
        public BookController(DbContextApp _dbContextApp, IWebHostEnvironment hostEnvironment)
        {
            dbContextApp = _dbContextApp;
            webHostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> List()
        {
            List<BookViewModel> model = new List<BookViewModel>();
            model = (from book in dbContextApp.Books
                     where book.IsActive == true
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
                         BookPhotoPath = book.BookPhoto
                     }).ToList();
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.PubId = (from pub in dbContextApp.Publications
                                   where pub.IsActive == true
                                   select new Publication()
                                   {
                                       PublicationName = pub.PublicationName,
                                       PubId = pub.PubId
                                   }).ToList();
            ViewBag.BranchId = (from branch in dbContextApp.Branches
                                   where branch.IsActive == true
                                   select new Branch()
                                   {
                                       BranchName = branch.BranchName,
                                       BranchId = branch.BranchId
                                   }).ToList();
            return View();
        }
         public async Task<IActionResult> save(BookViewModel book)
        {
            var fileName = "";
            int updaterow = 0;
            var view = "";
            if (book.BookPhoto != null)
            {
                fileName = await UploadFile(book.BookPhoto);
            }
            Book books = new Book()
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
                Available = book.Quantity,
                Rent = 0,
                IsActive = true,
                BookPhoto = fileName
            };
            dbContextApp.Books.Add(books);
            updaterow = dbContextApp.SaveChanges();
            if (updaterow > 0)
            {
                view = "List";
            }
            return RedirectToAction(view);
        }
        public async Task<IActionResult> Edit(int Id)
        {
            var model =  (from book in dbContextApp.Books
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
                                     BookPhotoPath = book.BookPhoto
                                 }).FirstOrDefault();
            ViewBag.PubId = (from pub in dbContextApp.Publications
                             where pub.IsActive == true
                             select new Publication()
                             {
                                 PublicationName = pub.PublicationName,
                                 PubId = pub.PubId
                             }).ToList();
            ViewBag.BranchId = (from branch in dbContextApp.Branches
                                where branch.IsActive == true
                                select new Branch()
                                {
                                    BranchName = branch.BranchName,
                                    BranchId = branch.BranchId
                                }).ToList();
            return View(model);
        }
        public async Task<IActionResult> update(BookViewModel book)
        {
            var fileName = "";
            int updaterow = 0;
            var view = "";
            if (book.BookPhoto != null)
            {
                fileName = await UploadFile(book.BookPhoto);
            }
            else
            {
                fileName = book.BookPhotoPath;
            }
            Book books = new Book()
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
                IsActive = true,
                Available = book.Quantity,
                Rent = 0,
                BookPhoto = fileName
            };
            dbContextApp.Books.Update(books);
            updaterow = dbContextApp.SaveChanges();
            if (updaterow > 0)
            {
                view = "List";
            }
            return RedirectToAction(view);
        }
        public async Task<IActionResult> Details(int Id)
        {
            var model = (from book in dbContextApp.Books
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
                             BookPhotoPath = book.BookPhoto
                         }).FirstOrDefault();
           
            return View(model);
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var model = (from book in dbContextApp.Books
                         where book.IsActive == true && book.BookId == Id
                         select new Book()
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
                             IsActive = book.IsActive
                         }).FirstOrDefault();
            model.IsActive = false;
            int upadaterow = 0;
            var view = "List";
            dbContextApp.Books.Update(model);
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

        public async Task<IActionResult> BookReport(int branchId=0,int pubId=0)
        {
            ViewBag.PubId = (from pub in dbContextApp.Publications
                             where pub.IsActive == true
                             select new Publication()
                             {
                                 PublicationName = pub.PublicationName,
                                 PubId = pub.PubId
                             }).ToList();
            ViewBag.BranchId = (from branch in dbContextApp.Branches
                                where branch.IsActive == true
                                select new Branch()
                                {
                                    BranchName = branch.BranchName,
                                    BranchId = branch.BranchId
                                }).ToList();
            List<BookViewModel> bookmodel = new List<BookViewModel>();
            if(branchId != 0)
            {
                bookmodel = (from book in dbContextApp.Books
                             where book.IsActive == true && book.BranchId == branchId
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
                             }).ToList();
            }else if(pubId !=0)
            {
                bookmodel = (from book in dbContextApp.Books
                             where book.IsActive == true && book.PubId == pubId
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
                             }).ToList();
            }
            else
            {
                bookmodel = (from book in dbContextApp.Books
                             where book.IsActive == true
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
                             }).ToList();
            }

            return View(bookmodel);
        }
      
        public async Task<IActionResult> GetBookReportDetail(int Id)
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

        public async Task<IActionResult> Penalty(int bookId = 0,int studentId = 0)
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
            BoookIssue boookIssue = new BoookIssue();
            if(bookId != 0 && studentId != 0)
            {
                boookIssue = (from issuebk in dbContextApp.BookIssues where issuebk.BookId == bookId && issuebk.StudentId == studentId select new BoookIssue() {
                    BookId = issuebk.BookId,
                    StudentId = issuebk.StudentId,
                    Days = issuebk.Days,
                    PanaltyStatus = issuebk.PanaltyStatus,
                    IssueDate = issuebk.IssueDate,
                    ReturnDate = issuebk.ReturnDate
                }
                ).FirstOrDefault(); 
            }
            else
            {
                boookIssue = (from issuebk in dbContextApp.BookIssues
                              where issuebk.BookId == 3 && issuebk.StudentId == 2 
                              select new BoookIssue() { 
                                  BookId=issuebk.BookId,
                                  StudentId = issuebk.StudentId,
                                  Days = issuebk.Days,
                                  PanaltyStatus = issuebk.PanaltyStatus,
                                  IssueDate = issuebk.IssueDate,
                                  ReturnDate = issuebk.ReturnDate
                              }).FirstOrDefault();
            }
            BookViewModel bookmodel = new BookViewModel();
            Student student = new Student();
            
            bookmodel = (from model in dbContextApp.Books
                         where model.BookId == boookIssue.BookId
                         select new BookViewModel() { 
                            Author=model.Author,
                            Branchs=model.Branchs,
                            Publications = model.Publications,
                            Price=model.Price,
                            BookPhotoPath = model.BookPhoto,
                            BookName = model.BookName
                         }).FirstOrDefault();
            student = (from model in dbContextApp.Students
                         where model.StudentId == boookIssue.StudentId
                         select new Student() { StudentName=model.StudentName}).FirstOrDefault();
            Penalty penalty = new Penalty();
            {
                penalty.Author = bookmodel.Author;
                penalty.PublicationName = bookmodel.Publications.PublicationName;
                penalty.BranchName = bookmodel.Branchs.BranchName;
                penalty.Price = bookmodel.Price;
                penalty.StudentName = student.StudentName;
                penalty.Day = boookIssue.Days;
                penalty.IssueDate = boookIssue.IssueDate;
                penalty.Status = boookIssue.PanaltyStatus;
                penalty.PenaltyAmount = penalty.PenaltyAmount;
                penalty.Reason = penalty.Reason;
                penalty.BookName = bookmodel.BookName;
                penalty.BookPhotoPath = bookmodel.BookPhotoPath;
            }
            //var issuedate = penalty.IssueDate;
            //var returndate = issuedate.AddDays(penalty.Day);
            //var currentdate = DateTime.UtcNow;
            //if(currentdate == returndate)
            //{
            //    penalty.Status = "Yes Penalty";
            //    dbContextApp.Penalties.Update(penalty);
            //    dbContextApp.SaveChanges();
            //}
            return View(penalty);
        }
        public async Task<IActionResult> PenaltyList()
        {
            List<Penalty> penalties = new List<Penalty>();
            penalties =  dbContextApp.Penalties.ToList();
            return View(penalties);
        }
        public async Task<IActionResult> savePenalty(Penalty penalty)
        {
           var view = "";
            int updaterow = 0;
            dbContextApp.Penalties.Add(penalty);
            updaterow = dbContextApp.SaveChanges();
            if(updaterow > 0)
            {
                view = "PenaltyList";
            }
            return RedirectToAction(view);
        }

    }
}
