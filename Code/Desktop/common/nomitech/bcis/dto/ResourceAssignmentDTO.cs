using System;

namespace Desktop.common.nomitech.bcis.dto
{

    [Serializable]
    public class ResourceAssignmentDTO : ResourceDTO
    {
        private string itemResourceId;

        private string itemId;

        private decimal itemResourceQuant;

        private decimal itemResourceRate;

        private decimal itemResourceTotal;

        public virtual string ItemResourceId
        {
            get
            {
                return this.itemResourceId;
            }
            set
            {
                this.itemResourceId = value;
            }
        }


        public virtual string ItemId
        {
            get
            {
                return this.itemId;
            }
            set
            {
                this.itemId = value;
            }
        }


        public virtual decimal ItemResourceQuant
        {
            get
            {
                return this.itemResourceQuant;
            }
            set
            {
                this.itemResourceQuant = value;
            }
        }


        public virtual decimal ItemResourceRate
        {
            get
            {
                return this.itemResourceRate;
            }
            set
            {
                this.itemResourceRate = value;
            }
        }


        public virtual decimal ItemResourceTotal
        {
            get
            {
                return this.itemResourceTotal;
            }
            set
            {
                this.itemResourceTotal = value;
            }
        }

    }


    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\bcis\dto\ResourceAssignmentDTO.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}