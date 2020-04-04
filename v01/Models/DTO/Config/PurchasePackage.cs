using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO.Config
{
    public class PurchasePackage
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Max_Projects { get; set; }
        public string Max_Project_Size { get; set; }
        public string Rendering_Resource { get; set; }
        public string Rate_Libraries { get; set; }
        public string Data_Feeds { get; set; }
        public string Escalation { get; set; }
        public string Advanced_WBS { get; set; }

        public PurchasePackage()
        { }
    }
}
