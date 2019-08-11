using System.Collections.Generic;

namespace Desktop.common.nomitech.bcis.dto
{

    public class Assignments
    {
        private IList<ItemAssignmentDTO> itemList;

        private IList<ResourceAssignmentDTO> resourceList;

        private IList<ItemEditionDTO> trendList;

        public virtual IList<ItemAssignmentDTO> ItemList
        {
            get
            {
                return this.itemList;
            }
            set
            {
                this.itemList = value;
            }
        }


        public virtual IList<ResourceAssignmentDTO> ResourceList
        {
            get
            {
                return this.resourceList;
            }
            set
            {
                this.resourceList = value;
            }
        }


        public virtual IList<ItemEditionDTO> TrendList
        {
            get
            {
                return this.trendList;
            }
            set
            {
                this.trendList = value;
            }
        }

    }

    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\bcis\dto\Assignments.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}