using System;

namespace Desktop.common.nomitech.bcis.dto
{
   // using BaseEntity = Desktop.common.nomitech.common.@base.BaseEntity;

    [Serializable]
    public class ItemDTO //: BaseEntity
    {
        private string itemId;

        private string editionId;

        private string publicationId;

        private string itemParentId;

        private string itemRootId;

        private sbyte itemDepth;

        private string itemCode;

        private string itemDesc;

        private string itemUnit;

        private string itemNote;

        private string itemType;

        private decimal itemUnitPrice;

        private decimal itemQuant;

        private decimal itemTotal;

        private string itemDerivedId;

        private decimal labourHours;

        private decimal labourTotal;

        private decimal plantHours;

        private decimal plantTotal;

        private decimal materialTotal;

        private decimal specialist;

        private decimal itemOhpPc;

        private decimal itemRate;

        private int? isParent;

        private int? isPriced;

        public virtual string ItemDerivedId
        {
            get
            {
                return this.itemDerivedId;
            }
            set
            {
                this.itemDerivedId = value;
            }
        }


        public virtual decimal LabourHours
        {
            get
            {
                return this.labourHours;
            }
            set
            {
                this.labourHours = value;
            }
        }


        public virtual decimal LabourTotal
        {
            get
            {
                return this.labourTotal;
            }
            set
            {
                this.labourTotal = value;
            }
        }


        public virtual decimal PlantHours
        {
            get
            {
                return this.plantHours;
            }
            set
            {
                this.plantHours = value;
            }
        }


        public virtual decimal PlantTotal
        {
            get
            {
                return this.plantTotal;
            }
            set
            {
                this.plantTotal = value;
            }
        }


        public virtual decimal MaterialTotal
        {
            get
            {
                return this.materialTotal;
            }
            set
            {
                this.materialTotal = value;
            }
        }


        public virtual decimal Specialist
        {
            get
            {
                return this.specialist;
            }
            set
            {
                this.specialist = value;
            }
        }


        public virtual decimal ItemOhpPc
        {
            get
            {
                return this.itemOhpPc;
            }
            set
            {
                this.itemOhpPc = value;
            }
        }


        public virtual decimal ItemRate
        {
            get
            {
                return this.itemRate;
            }
            set
            {
                this.itemRate = value;
            }
        }


        public virtual int? IsParent
        {
            get
            {
                return this.isParent;
            }
            set
            {
                this.isParent = value;
            }
        }


        public virtual int? IsPriced
        {
            get
            {
                return this.isPriced;
            }
            set
            {
                this.isPriced = value;
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


        public virtual string EditionId
        {
            get
            {
                return this.editionId;
            }
            set
            {
                this.editionId = value;
            }
        }


        public virtual string PublicationId
        {
            get
            {
                return this.publicationId;
            }
            set
            {
                this.publicationId = value;
            }
        }


        public virtual string ItemParentId
        {
            get
            {
                return this.itemParentId;
            }
            set
            {
                this.itemParentId = value;
            }
        }


        public virtual string ItemRootId
        {
            get
            {
                return this.itemRootId;
            }
            set
            {
                this.itemRootId = value;
            }
        }


        public virtual sbyte ItemDepth
        {
            get
            {
                return this.itemDepth;
            }
            set
            {
                this.itemDepth = value;
            }
        }


        public virtual string ItemCode
        {
            get
            {
                return this.itemCode;
            }
            set
            {
                this.itemCode = value;
            }
        }


        public virtual string ItemDesc
        {
            get
            {
                return this.itemDesc;
            }
            set
            {
                this.itemDesc = value;
            }
        }


        public virtual string ItemUnit
        {
            get
            {
                return this.itemUnit;
            }
            set
            {
                this.itemUnit = value;
            }
        }


        public virtual string ItemNote
        {
            get
            {
                return this.itemNote;
            }
            set
            {
                this.itemNote = value;
            }
        }


        public virtual decimal ItemUnitPrice
        {
            get
            {
                return this.itemUnitPrice;
            }
            set
            {
                this.itemUnitPrice = value;
            }
        }


        public virtual string ItemType
        {
            get
            {
                return this.itemType;
            }
            set
            {
                this.itemType = value;
            }
        }


        public virtual decimal ItemQuant
        {
            get
            {
                return this.itemQuant;
            }
            set
            {
                this.itemQuant = value;
            }
        }


        public virtual decimal ItemTotal
        {
            get
            {
                return this.itemTotal;
            }
            set
            {
                this.itemTotal = value;
            }
        }


        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Transient public System.Nullable<long> getId()
        public virtual long? Id
        {
            get
            {
                return null;
            }
        }
    }


    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\bcis\dto\ItemDTO.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}