using LMS.Models;
using Microsoft.EntityFrameworkCore;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzSchduling.Models.Schedule
{
    public class Task1 : IJob
    {
        //private readonly DbContextApp dbContextApp;
        //public Task1(DbContextApp _dbContextApp)
        //{
        //    dbContextApp = _dbContextApp;
        //}
        public Task Execute(IJobExecutionContext context)
        {
            var task = Task.Run(() => logfile(DateTime.Now)); 
            return task;
        }
        public void logfile(DateTime time)
        {
            string path = "c:\\log\\sample.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(time);
                writer.Close();
            }
            // this.Penalty();
        }
        //public void Penalty()
        //{

        //    List<BoookIssue> boookIssue = new List<BoookIssue>();

        //    boookIssue = (from issuebk in dbContextApp.BookIssues
        //                  where issuebk.IsActive == true
        //                  select new BoookIssue()
        //                  {
        //                      BookId = issuebk.BookId,
        //                      StudentId = issuebk.StudentId,
        //                      Days = issuebk.Days,
        //                      PanaltyStatus = issuebk.PanaltyStatus,
        //                      IssueDate = issuebk.IssueDate,
        //                      ReturnDate = issuebk.ReturnDate,
        //                      IssueId = issuebk.IssueId,
        //                      IsActive = issuebk.IsActive
        //                  }).ToList();
        //    for (int i = 0; i < boookIssue.Count; i++)
        //    {
        //        BoookIssue boook = new BoookIssue();

        //        boook = (from issuebk in dbContextApp.BookIssues
        //                 where issuebk.IsActive == true && issuebk.IssueId == boookIssue[i].IssueId
        //                 select new BoookIssue()
        //                 {
        //                     BookId = issuebk.BookId,
        //                     StudentId = issuebk.StudentId,
        //                     Days = issuebk.Days,
        //                     PanaltyStatus = issuebk.PanaltyStatus,
        //                     IssueDate = issuebk.IssueDate,
        //                     ReturnDate = issuebk.ReturnDate,
        //                     IssueId = issuebk.IssueId,
        //                     IsActive = issuebk.IsActive
        //                 }).FirstOrDefault();
        //        var issuedate = boook.IssueDate;
        //        var Rdate = issuedate.AddDays(boook.Days);
        //        var returndate = Convert.ToDateTime(Rdate).ToString("dd/MM/yyyy");
        //        var currentdate = Convert.ToDateTime(DateTime.UtcNow).ToString("dd/MM/yyyy");
        //        if (currentdate == returndate)
        //        {
        //            boook.PanaltyStatus = "Yes Penalty";
        //            dbContextApp.BookIssues.Update(boook);
        //            dbContextApp.SaveChanges();
        //        }
        //    }

        //}
    }
}
