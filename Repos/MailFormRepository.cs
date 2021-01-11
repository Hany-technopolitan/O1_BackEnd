using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techno_Project.Contexts;
using Techno_Project.Controllers;
using Techno_Project.Models;

namespace Techno_Project.Repos
{
    public class MailFormRepository : ImailFormRepository
    {
        GenericDbContext db;
        public MailFormRepository(GenericDbContext _db)
        {
            db = _db;
        }
        public async Task<int> Add(List<FormEmail> EmailList)
        {
            try
            {
                for (int i = 0; i < EmailList.Count; i++)
                {
                   
                    await db.FormEmail.AddAsync(EmailList[i]);
                   
                }
                await db.SaveChangesAsync();

            }
            catch (Exception)
            {
                return 0;
            }
            return 1;

        }

        public async Task<string> Update(int? id, int Action, string Notes)
        {

            try
            {
                FormEmail ee;
                ee = db.FormEmail.Where(d => d.id == id).First();
                ee.Action = Action;
                ee.Notes = Notes;
                db.SaveChanges();
                return "";
            }
            catch (Exception e)

            {
                return "";

            }
      

        }
        public async Task<List<FormEmail>> Getall()
        {
            var form = db.FormEmail.ToList();
            return form;
        }
        public async Task<int> Delete(int? postId)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<FormEmail>> GetbyId(int? postId)
        {
            throw new NotImplementedException();
        }


    }
}
