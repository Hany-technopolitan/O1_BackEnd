using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techno_Project.Contexts;
using Techno_Project.Models;

namespace Techno_Project.Repos
{
    public class FormRepository : IFormDbRepository
    {
        GenericDbContext db;
        public FormRepository(GenericDbContext _db)
        {
            db = _db;
        }
        public async Task<int> Add(FormData Form)
        
        {
            Random rd = new Random();
            if (db != null)
            {
                int rand_num = rd.Next(1, 1000000);
                Form.serialNumber = rand_num.ToString();
                
                await db.FormData.AddAsync(Form);
                await db.SaveChangesAsync();

                return Form.FormId;
            }

            return 0;
        }
        public FormData GetbyId(int FormId)
        {
            var form = db.FormData.FirstOrDefault(e => e.FormId == FormId);

            return form;
        }

        public Task<int> Delete(int? FormId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FormData>> Getall()
        {
            var form = db.FormData.ToList();
            return form;
        }

        public int Update(FormData Form,int id)
        {
            try
            {
                FormData ee;
                ee = db.FormData.Where(d => d.FormId ==id ).FirstOrDefault();
                ee.Company = Form.Company;
                ee.Email = Form.Email;
                ee.enterOrExitDateTime = Form.enterOrExitDateTime;
                ee.entryOrExit = Form.entryOrExit;
                ee.MobileNo = Form.MobileNo;
                ee.Position = Form.Position;
                ee.RepresentativeName = Form.RepresentativeName;
                ee.RepresntativeMobileNo = Form.RepresntativeMobileNo;
                ee.RequesterName = Form.RequesterName;
                ee.vistorCompany = Form.vistorCompany;          

                db.SaveChanges();
                return 1;
            }
            catch (Exception e)

            {
                return 0;

            }

        }


    }
}