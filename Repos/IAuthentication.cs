using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techno_Project.Models;

namespace Techno_Project.Repos
{
   public  interface IAuthentication
    {
       Task<bool> Login(Authentication AuthData);

        Task<bool> Register(Authentication AuthData);

    }
}
