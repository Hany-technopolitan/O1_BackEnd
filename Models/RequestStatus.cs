using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Techno_Project.Models
{
    public class RequestStatus
    {
            
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { set; get; }
        public int Req_id { set; get; }
        public string Status { set; get; }
        public string username { set; get; }
        public string Notes { set; get; }
        public DateTime ActionDate { set; get; }

    }
}
