using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Techno_Project.Models
{
    public class FormEmail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Name { set; get; }
        public string Email { set; get; }
        public int Action { set; get; }  //1-approved  2- Revert 3-Reject
        public string Notes { set; get; }  //1-approved  2- Revert 3-Reject
    }
}
