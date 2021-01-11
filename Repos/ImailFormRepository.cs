using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techno_Project.Controllers;
using Techno_Project.Models;

namespace Techno_Project.Repos
{
   public  interface ImailFormRepository 
    {
        Task<List<FormEmail>> Getall();

        Task<ActionResult<FormEmail>> GetbyId(int? postId);

        Task<int> Add(List<FormEmail> post);

        Task<int> Delete(int? postId);

         Task<string>  Update(int?id ,int Action,string Notes);
    }
}
