using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techno_Project.Models;

namespace Techno_Project.Repos
{
    public interface IMovableRepository
    {
        Task<List<Movableitems>> Getall();

        List<Movableitems>GetbyId(int? postId);

        Task<int> Add(List<Movableitems> post,int formid);

        Task<int> Delete(int? postId);

         Task Update(List<Movableitems> post,int id);
    }
}
