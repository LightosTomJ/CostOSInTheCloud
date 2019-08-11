using System;

namespace Desktop.common.nomitech.bcis.dto
{

    [Serializable]
    public class ItemAssignmentDTO : ItemDTO
    {
        private string subItemId;

        private string subItemChildId;

        private decimal subItemQuantity;

        private decimal subItemRate;

        private decimal subItemTotal;

        public virtual string SubItemId
        {
            get
            {
                return this.subItemId;
            }
            set
            {
                this.subItemId = value;
            }
        }


        public virtual string SubItemChildId
        {
            get
            {
                return this.subItemChildId;
            }
            set
            {
                this.subItemChildId = value;
            }
        }


        public virtual decimal SubItemQuantity
        {
            get
            {
                return this.subItemQuantity;
            }
            set
            {
                this.subItemQuantity = value;
            }
        }


        public virtual decimal SubItemRate
        {
            get
            {
                return this.subItemRate;
            }
            set
            {
                this.subItemRate = value;
            }
        }


        public virtual decimal SubItemTotal
        {
            get
            {
                return this.subItemTotal;
            }
            set
            {
                this.subItemTotal = value;
            }
        }

    }

    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\bcis\dto\ItemAssignmentDTO.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}