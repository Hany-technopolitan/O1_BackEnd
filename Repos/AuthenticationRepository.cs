using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techno_Project.Contexts;
using Techno_Project.Models;

namespace Techno_Project.Repos
{
    public class AuthenticationRepository : IAuthentication
    {
        GenericDbContext db;
        public AuthenticationRepository(GenericDbContext _db)
        {
            db = _db;
        }
        public async Task<bool> Login(Authentication AuthData)
        {
            var form =   db.Authentication.FirstOrDefault(e => e.Name == AuthData.Name && e.Password==AuthData.Password);

            if(form!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Register(Authentication AuthData)
        {
           // var found = db.Authentication.FirstOrDefault(e => e.Name == AuthData.Name && e.Password == AuthData.Password);
            var id = await db.Authentication.AddAsync(AuthData);
            //if(found!=null)
            //{

            //}
            await db.SaveChangesAsync();
            if (id == null)
            {
                return false;
            }
            else
            {
                return true;
            }
         
        }
    }
}
