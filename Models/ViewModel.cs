using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Techno_Project.Models
{
    public class ViewModel
    {
        public string FormId { get; set; }
        public DateTime RequestDate { get; set; }

        public string Company { set; get; }

        public string RequesterName { set; get; }

        public string Position { set; get; }

        public string Email { set; get; }

        public string MobileNo { set; get; }

        public string UnitNo { set; get; }

        //visitor info 

        public int entryOrExit { set; get; }

        public DateTime enterOrExitDateTime { set; get; }

        public string vistorCompany { set; get; }

        public string RepresentativeName { set; get; }

        public string RepresntativeMobileNo { set; get; }

        public string serialNumber { set; get; }
        public int MovableItemsId { set; get; }

        public List<Movableitems> type { set; get; }
    }
}
