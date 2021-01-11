using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Techno_Project.Models
{
    public class Movableitems
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        public string type { set; get; }
        public string Description { set; get; }
        public int Quantity { set; get; }
        public int FormDataid { set; get; }

    }
}
