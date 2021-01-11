using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techno_Project.Controllers;
using Techno_Project.Models;

namespace Techno_Project.Repos
{
    public interface IFormDbRepository
    {
        Task<List<FormData>> Getall();

        FormData GetbyId(int postId);

        Task<int> Add(FormData post);

        Task<int> Delete(int? postId);

        int Update(FormData post,int id);
  
    }
}
