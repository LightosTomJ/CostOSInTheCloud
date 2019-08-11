using System;
using System.Numerics;

namespace Desktop.common.nomitech.bcis.dto
{
    //using BaseEntity = nomitech.common.@base.BaseEntity;

    [Serializable]
    public class ResourceDTO //: BaseEntity
    {
        private string resId;

        private string resType;

        private string edition;

        private string resCode;

        private string resDesc;

        private string resUnit;

        private decimal resRate;

        private bool resGangBit;

        private decimal resWastePc;

        private decimal resOhpPc;

        private decimal resUnitsInBulk;

        private decimal resBulkCost;

        private decimal resUnitCost;

        private string resourceParentId;

        private string resourceRootId;

        private sbyte? resourceDepth;

        private BigInteger resourceOa;

        private string productionId;

        private bool isPriced;

        private bool isParent;

        private decimal labour;

        private decimal plant;

        private decimal material;

        private decimal specialist;

        public virtual string ResId
        {
            get
            {
                return this.resId;
            }
            set
            {
                this.resId = value;
            }
        }


        public virtual string ResType
        {
            get
            {
                return this.resType;
            }
            set
            {
                this.resType = value;
            }
        }


        public virtual string Edition
        {
            get
            {
                return this.edition;
            }
            set
            {
                this.edition = value;
            }
        }


        public virtual string ResCode
        {
            get
            {
                return this.resCode;
            }
            set
            {
                this.resCode = value;
            }
        }


        public virtual string ResDesc
        {
            get
            {
                return this.resDesc;
            }
            set
            {
                this.resDesc = value;
            }
        }


        public virtual string ResUnit
        {
            get
            {
                return this.resUnit;
            }
            set
            {
                this.resUnit = value;
            }
        }


        public virtual decimal ResRate
        {
            get
            {
                return this.resRate;
            }
            set
            {
                this.resRate = value;
            }
        }


        public virtual bool ResGangBit
        {
            get
            {
                return this.resGangBit;
            }
            set
            {
                this.resGangBit = value;
            }
        }


        public virtual decimal ResWastePc
        {
            get
            {
                return this.resWastePc;
            }
            set
            {
                this.resWastePc = value;
            }
        }


        public virtual decimal ResOhpPc
        {
            get
            {
                return this.resOhpPc;
            }
            set
            {
                this.resOhpPc = value;
            }
        }


        public virtual decimal ResUnitsInBulk
        {
            get
            {
                return this.resUnitsInBulk;
            }
            set
            {
                this.resUnitsInBulk = value;
            }
        }


        public virtual decimal ResBulkCost
        {
            get
            {
                return this.resBulkCost;
            }
            set
            {
                this.resBulkCost = value;
            }
        }


        public virtual decimal ResUnitCost
        {
            get
            {
                return this.resUnitCost;
            }
            set
            {
                this.resUnitCost = value;
            }
        }


        public virtual string ResourceParentId
        {
            get
            {
                return this.resourceParentId;
            }
            set
            {
                this.resourceParentId = value;
            }
        }


        public virtual string ResourceRootId
        {
            get
            {
                return this.resourceRootId;
            }
            set
            {
                this.resourceRootId = value;
            }
        }


        public virtual sbyte? ResourceDepth
        {
            get
            {
                return this.resourceDepth;
            }
            set
            {
                this.resourceDepth = value;
            }
        }


        public virtual BigInteger ResourceOa
        {
            get
            {
                return this.resourceOa;
            }
            set
            {
                this.resourceOa = value;
            }
        }


        public virtual string ProductionId
        {
            get
            {
                return this.productionId;
            }
            set
            {
                this.productionId = value;
            }
        }


        public virtual bool Priced
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


        public virtual bool Parent
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


        public virtual decimal Labour
        {
            get
            {
                return this.labour;
            }
            set
            {
                this.labour = value;
            }
        }


        public virtual decimal Plant
        {
            get
            {
                return this.plant;
            }
            set
            {
                this.plant = value;
            }
        }


        public virtual decimal Material
        {
            get
            {
                return this.material;
            }
            set
            {
                this.material = value;
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


    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\bcis\dto\ResourceDTO.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}