using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techno_Project.Contexts;
using Techno_Project.Models;

namespace Techno_Project.Repos
{
    public class MovableRepository : IMovableRepository
    {
        GenericDbContext db;
        public MovableRepository(GenericDbContext _db)
        {
            db = _db;
        }
        public async Task<int> Add(List<Movableitems> MovablesList,int formid)
        {
            for (int i = 0; i < MovablesList.Count; i++)
            {
                MovablesList[i].FormDataid = formid;
                await db.Movableitems.AddAsync(MovablesList[i]);
            }

            await db.SaveChangesAsync();
            return formid;
        }
        public async  Task Update(List<Movableitems> Movableitems, int id)
        {
            try
            {
                db.Movableitems.RemoveRange(db.Movableitems.Where(x => x.FormDataid == id));
                await Add(Movableitems, id);
                db.SaveChanges();
            }
            catch(Exception e)
            {
              
            }

    
        }
        public List<Movableitems> GetbyId(int? formid)
        {
            var form = db.Movableitems.Where(e => e.FormDataid == formid).ToList();
            return form;
        }
        public Task<int> Delete(int? postId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movableitems>> Getall()
        {
            throw new NotImplementedException();
      
        }  

      
    }
}
