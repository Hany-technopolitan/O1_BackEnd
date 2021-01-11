using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techno_Project.Contexts;
using Techno_Project.Models;

namespace Techno_Project.Repos
{
    public class RequestStatusRepository : IRequeststatus
    {
        GenericDbContext db;
        public RequestStatusRepository(GenericDbContext _db)
        {
            db = _db;
        }
        public async Task<bool> Add(RequestStatus RequestStatus)
        {
          
               
                await db.RequestStatus.AddAsync(RequestStatus);
            

            await db.SaveChangesAsync();
            return true;
   
        }

        public async Task<List<RequestStatus>> Getall()
        {
            var form = db.RequestStatus.ToList();
            return form;
        }

        public List<RequestStatus> GetbyId(int? formid)
        {
           //  var form = db.Movableitems.Where(e => e.FormDataid == formid).ToList();
            var form = db.RequestStatus.Where(e => e.Req_id == formid).ToList();
            return form;
        }
        public async  Task<int> Update(int id, string userName,string status,string Notes)
        {
            RequestStatus ee;
            ee = db.RequestStatus.Where(d => d.Req_id ==id &&d.username==userName).FirstOrDefault();
            ee.Status = status;
            ee.Notes = Notes;
            ee.ActionDate = DateTime.Now;

            await  db.SaveChangesAsync();
            return 1;

        }

 
    }
}
