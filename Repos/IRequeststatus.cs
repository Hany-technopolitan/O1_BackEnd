using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techno_Project.Models;

namespace Techno_Project.Repos
{
    public interface IRequeststatus
    {
    Task< List<RequestStatus>> Getall();

        List<RequestStatus> GetbyId(int? postId);

        Task<bool> Add(RequestStatus RequestStatus);


        Task<int> Update(int Reqid, string userName, string status, string Notes);
    }
}
