using System;

using ProjectIdEntity = Desktop.common.nomitech.common.@base.ProjectIdEntity;
using ResourceTable = Desktop.common.nomitech.common.@base.ResourceTable;
using ResourceToAssignmentTable = Desktop.common.nomitech.common.@base.ResourceToAssignmentTable;
using ResourceWithAssignmentsTable = Desktop.common.nomitech.common.@base.ResourceWithAssignmentsTable;
using BigDecimalMath = Desktop.common.nomitech.common.util.BigDecimalMath;
using Desktop.common.nomitech.common.@base;

namespace Model.local
{
    /// <summary>
    /// @author: George Hatzisymeon
    /// 
    /// 
    /// @hibernate.class table="ASSEMBLY_CHILD"
    /// @hibernate.cache usage="nonstrict-read-write"
    /// </summary>
    [Serializable]
    public class AssemblyAssemblyTable : ResourceToAssignmentTable, ProjectIdEntity
    {

        private static readonly decimal ONE = BigDecimalMath.ONE;

        public static readonly string[] FIELDS = new string[] { "factor1", "factor2", "factor3", "quantityPerUnit", "quantityPerUnitFormula", "exchangeRate", "finalRate", "fixedCost", "finalFixedCost", "comment" };

        private long? assemblyChildId = null;
        private DateTime lastUpdate;
        private decimal factor1;
        private decimal factor2;
        private decimal factor3;
        private decimal quantityPerUnit;
        private string quantityPerUnitFormula;
        private sbyte? quantityPerUnitFormulaState;
        private decimal localFactor;
        private string localCountry;
        private string localStateProvince;
        private decimal exchangeRate;
        private long? childTableId = null;
        private AssemblyTable childTable = null;
        private AssemblyTable parentTable;
        private decimal finalRate;
        private decimal fixedCost;
        private decimal finalFixedCost = decimal.Zero;
        private string comment;

        /// <summary>
        /// This String declares which SQL COLUMN contains which PV Variables
        /// 	e.g. <code>CUSRATE1FORM:var1,var2;CUSTXT1FORM:mitsos,george;MARKUPFORM:var2,mitsos</code>
        /// </summary>
        private string pvVars;

        public AssemblyAssemblyTable()
        {

        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Transient public Object clone(boolean cloneAssembly, boolean cloneChild)
        public virtual object Clone(bool cloneAssembly, bool cloneChild)
        {
            AssemblyAssemblyTable obj = new AssemblyAssemblyTable();

            obj.AssemblyChildId = AssemblyChildId;
            obj.LastUpdate = LastUpdate;
            //obj.setFinalRate(getFinalRate());
            obj.Factor1 = this.Factor1;
            obj.Factor2 = Factor2;
            obj.Factor3 = Factor3;

            obj.QuantityPerUnit = QuantityPerUnit;
            obj.QuantityPerUnitFormula = QuantityPerUnitFormula;
            obj.QuantityPerUnitFormulaState = QuantityPerUnitFormulaState;

            obj.LocalFactor = LocalFactor;
            obj.LocalCountry = LocalCountry;
            obj.LocalStateProvince = LocalStateProvince;
            obj.ExchangeRate = ExchangeRate;
            obj.FixedCost = FixedCost;
            obj.Comment = Comment;
            obj.PvVars = PvVars;

            obj.ChildTableId = ChildTableId;
            obj.ProjectId = ProjectId;

            try
            {
                obj.FinalRate = calculateFinalRate();
                obj.FinalFixedCost = calculateFinalFixedCost();
            }
            catch (System.NullReferenceException)
            {
                // ignore!
            }

            if (cloneAssembly && ParentTable != null)
            {
                obj.ParentTable = (AssemblyTable)ParentTable.clone();
            }

            if (cloneChild && ChildTable != null)
            {
                obj.ChildTable = (AssemblyTable)ChildTable.clone();
            }

            return obj;
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Transient public Object clone(boolean relations)
        public virtual object Clone(bool relations)
        {
            if (relations)
            {
                return Clone(true, true);
            }
            AssemblyAssemblyTable obj = new AssemblyAssemblyTable();

            obj.AssemblyChildId = AssemblyChildId;
            obj.LastUpdate = LastUpdate;
            //obj.setFinalRate(getFinalRate());
            obj.Factor1 = Factor1;
            obj.Factor2 = Factor2;
            obj.Factor3 = Factor3;

            obj.QuantityPerUnit = QuantityPerUnit;
            obj.QuantityPerUnitFormula = QuantityPerUnitFormula;
            obj.QuantityPerUnitFormulaState = QuantityPerUnitFormulaState;

            obj.LocalFactor = LocalFactor;
            obj.LocalCountry = LocalCountry;
            obj.LocalStateProvince = LocalStateProvince;
            obj.ExchangeRate = ExchangeRate;
            obj.FixedCost = FixedCost;
            obj.Comment = Comment;

            obj.PvVars = PvVars;

            obj.ChildTableId = ChildTableId;
            obj.ProjectId = ProjectId;

            try
            {
                obj.FinalRate = calculateFinalRate();
                obj.FinalFixedCost = calculateFinalFixedCost();
            }
            catch (System.NullReferenceException)
            {
                // ignore!
            }

            return obj;
        }

        /// <summary>
        /// @hibernate.id generator-class="native" 
        ///               unsaved-value="null"
        ///               column="ASSEMBLYCHILDID" </summary>
        /// <returns> Long </returns>
        public virtual long? AssemblyChildId
        {
            get
            {
                return assemblyChildId;
            }
            set
            {
                assemblyChildId = value;
            }
        }


        /// <summary>
        /// Description Here
        /// 
        /// @hibernate.property column="LASTUPDATE" type="timestamp" </summary>
        /// <returns> lastUpdate </returns>
        public virtual DateTime LastUpdate
        {
            get
            {
                return lastUpdate;
            }
            set
            {
                lastUpdate = value;
            }
        }


        public virtual decimal calculateFinalRate()
        {

            if (ParentTable != null && ChildTable != null)
            {
                ChildTable.calculateRate();
                finalRate = ChildTable.Rate * Factor1;
                finalRate = finalRate * Factor2;
                finalRate = finalRate * Factor3;
                finalRate = finalRate * ExchangeRate;
                finalRate = finalRate * LocalFactor;
                finalRate = finalRate * QuantityPerUnit;

                //finalRate = finalRate.setScale(10, decimal.ROUND_HALF_UP);
                finalRate = Math.Round(finalRate, 10, MidpointRounding.AwayFromZero);
            }

            return finalRate;
        }

        public virtual decimal calculateFinalFixedCost()
        {

            if (ParentTable != null && ChildTable != null)
            {
                finalFixedCost = ChildTable.calculateFinalFixedCost();
                finalFixedCost = BigDecimalMath.mult(finalFixedCost, ExchangeRate);
                finalFixedCost = BigDecimalMath.mult(finalFixedCost, Factor1);
                finalFixedCost = BigDecimalMath.mult(finalFixedCost, Factor2);
                finalFixedCost = BigDecimalMath.mult(finalFixedCost, Factor3);
                finalFixedCost = BigDecimalMath.mult(finalFixedCost, LocalFactor);
            }

            //finalFixedCost.setScale(10, decimal.ROUND_HALF_UP);
            finalFixedCost = Math.Round(finalFixedCost, 10, MidpointRounding.AwayFromZero);

            return finalFixedCost;
        }

        /// <summary>
        /// Description Here
        /// 
        /// @hibernate.property column="FRATE" type="big_decimal" precision="30" scale="10" </summary>
        /// <returns> rate </returns>
        public virtual decimal FinalRate
        {
            get
            {
                if (ParentTable != null && ChildTable != null)
                {
                    return calculateFinalRate();
                }
                return finalRate;
            }
            set
            {
                finalRate = value;
            }
        }


        /// <summary>
        /// Description Here
        /// 
        /// @hibernate.property column="FACTOR1" type="big_decimal" precision="30" scale="10" </summary>
        /// <returns> rate </returns>
        public virtual decimal Factor1
        {
            get
            {
                return factor1;
            }
            set
            {
                factor1 = value;
            }
        }


        /// <summary>
        /// Description Here
        /// 
        /// @hibernate.property column="FACTOR2" type="big_decimal" precision="30" scale="10" </summary>
        /// <returns> rate </returns>
        public virtual decimal Factor2
        {
            get
            {
                return factor2;
            }
            set
            {
                factor2 = value;
            }
        }


        /// <summary>
        /// Description Here
        /// 
        /// @hibernate.property column="DIVIDER" type="big_decimal" precision="30" scale="10" </summary>
        /// <returns> rate </returns>
        public virtual decimal Factor3
        {
            get
            {
                return factor3;
            }
            set
            {
                factor3 = value;
            }
        }


        /// <summary>
        /// Description Here
        /// 
        /// @hibernate.property column="QTYPUNIT" type="big_decimal" precision="30" scale="10" </summary>
        /// <returns> quantityPerUnit </returns>
        public virtual decimal QuantityPerUnit
        {
            get
            {
                return quantityPerUnit;
            }
            set
            {
                this.quantityPerUnit = value;
            }
        }


        /// <summary>
        /// @hibernate.property column="QTYPUNITFORM" type="costos_text" </summary>
        /// <returns> quantityPerUnitFormula </returns>
        public virtual string QuantityPerUnitFormula
        {
            get
            {
                return quantityPerUnitFormula;
            }
            set
            {
                this.quantityPerUnitFormula = value;
            }
        }


        /// <summary>
        /// @hibernate.property column="QTYPUFORMSTATE" type="byte" </summary>
        /// <returns> quantityPerUnitFormulaState </returns>
        public virtual sbyte? QuantityPerUnitFormulaState
        {
            get
            {
                return quantityPerUnitFormulaState;
            }
            set
            {
                this.quantityPerUnitFormulaState = value;
            }
        }


        /// <summary>
        /// Description Here
        /// 
        /// @hibernate.property column="LOCALFACTOR" type="big_decimal" precision="30" scale="10" </summary>
        /// <returns> rate </returns>
        public virtual decimal LocalFactor
        {
            get
            {
                return localFactor;
            }
            set
            {
                this.localFactor = value;
            }
        }


        /// <summary>
        /// Description Here
        /// 
        /// @hibernate.property column="LOCALCOUNTRY" type="costos_string" </summary>
        /// <returns> rate </returns>
        public virtual string LocalCountry
        {
            get
            {
                return localCountry;
            }
            set
            {
                this.localCountry = value;
            }
        }


        /// <summary>
        /// Description Here
        /// 
        /// @hibernate.property column="LOCALSTATE"  type="costos_string" </summary>
        /// <returns> rate </returns>
        public virtual string LocalStateProvince
        {
            get
            {
                return localStateProvince;
            }
            set
            {
                this.localStateProvince = value;
            }
        }


        /// <summary>
        /// Description Here
        /// 
        /// @hibernate.property column="EXCHANGERATE" type="big_decimal" precision="30" scale="10" </summary>
        /// <returns> rate </returns>
        public virtual decimal ExchangeRate
        {
            get
            {
                if (exchangeRate == null)
                {
                    exchangeRate = ONE;
                }
                return exchangeRate;
            }
            set
            {
                if (value == null)
                {
                    value = ONE;
                }
                this.exchangeRate = value;
            }
        }


        /// <summary>
        /// @hibernate.property column="FIXEDCOST" type="big_decimal" precision="30" scale="10" </summary>
        /// <returns> fixedCost </returns>
        public virtual decimal FixedCost
        {
            get
            {
                return fixedCost;
            }
            set
            {
                this.fixedCost = value;
            }
        }


        /// <summary>
        /// @hibernate.property column="FINALFIXEDCOST" type="big_decimal" precision="30" scale="10" </summary>
        /// <returns> finalFixedCost </returns>
        public virtual decimal FinalFixedCost
        {
            get
            {
                return calculateFinalFixedCost();
            }
            set
            {
                this.finalFixedCost = value;
            }
        }


        /// <summary>
        /// This String declares which SQL COLUMN contains which PV Variables
        /// e.g. <code>CUSRATE1FORM:var1,var2;CUSTXT1FORM:mitsos,george;MARKUPFORM:var2,mitsos</code>
        /// 
        /// @hibernate.property column="PV_VARS" type="costos_text" </summary>
        /// <returns> pvVars </returns>
        public virtual string PvVars
        {
            get
            {
                return pvVars;
            }
            set
            {
                this.pvVars = value;
            }
        }


        /// <summary>
        /// @hibernate.many-to-one
        ///  column="CHILDID" </summary>
        /// <returns> ChildTable </returns>
        public virtual AssemblyTable ChildTable
        {
            get
            {
                return childTable;
            }
            set
            {
                this.childTable = value;
                if (value != null)
                {
                    ChildTableId = value.AssemblyId;
                }
            }
        }


        public virtual long? ChildTableId
        {
            get
            {
                return childTableId;
            }
            set
            {
                this.childTableId = value;
            }
        }


        /// <summary>
        /// @hibernate.many-to-one
        ///  column="ASSEMBLYID" </summary>
        /// <returns> ChildTable </returns>
        public virtual AssemblyTable ParentTable
        {
            get
            {
                return parentTable;
            }
            set
            {
                parentTable = value;
            }
        }


        /// <summary>
        /// @hibernate.property column="COMMENT" type="costos_text" </summary>
        /// <returns> comment </returns>
        public virtual string Comment
        {
            get
            {
                return comment;
            }
            set
            {
                this.comment = value;
            }
        }


        public virtual AssemblyAssemblyTable Data
        {
            set
            {

                AssemblyChildId = value.AssemblyChildId;
                LastUpdate = value.LastUpdate;
                //obj.setFinalRate(getFinalRate());
                Factor1 = value.Factor1;
                Factor2 = value.Factor2;
                Factor3 = value.Factor3;

                QuantityPerUnit = value.QuantityPerUnit;
                QuantityPerUnitFormula = value.QuantityPerUnitFormula;
                QuantityPerUnitFormulaState = value.QuantityPerUnitFormulaState;

                LocalFactor = value.LocalFactor;
                LocalCountry = value.LocalCountry;
                LocalStateProvince = value.LocalStateProvince;
                ExchangeRate = value.ExchangeRate;
                FixedCost = value.FixedCost;
                Comment = value.Comment;
                PvVars = value.PvVars;

                try
                {
                    FinalRate = value.calculateFinalRate();
                    FinalFixedCost = value.calculateFinalFixedCost();
                }
                catch (System.NullReferenceException)
                {
                    // ignore!
                }
            }
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Transient @Override public System.Nullable<long> getId()
        public override long? Id
        {
            get
            {
                return AssemblyChildId;
            }
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Transient @Override public nomitech.common.base.ResourceWithAssignmentsTable getResourceTable()
        public override ResourceWithAssignmentsTable getResourceTable()
        {
            return ParentTable;
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Transient @Override public nomitech.common.base.ResourceTable getAssignmentResourceTable()
        public override ResourceTable AssignmentResourceTable
        {
            get
            {
                return ChildTable;
            }
            set
            {
                ChildTable = (AssemblyTable)value;
            }
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Transient @Override public void setData(nomitech.common.base.ResourceToAssignmentTable assignmentTable)
        public override ResourceToAssignmentTable Data
        {
            set
            {
                Data = (AssemblyAssemblyTable)value;
            }
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Transient @Override public void setResourceTable(nomitech.common.base.ResourceTable resourceTable)
        public override void setResourceTable(ResourceTable resourceTable)
        {
            ParentTable = (AssemblyTable)resourceTable;
        }


        public virtual decimal calculateFinalLaborManhours()
        {
            //NOT TOTAL YOU NEED TO MULT * QTY
            decimal fRate = BigDecimalMath.ZERO;

            if (ChildTable != null && ParentTable != null)
            {
                if (ChildTable.ActivityBased.Equals(false))
                {
                    //decimal assemblyRate = ChildTable.@Override public long? ProjectId
                    
                }
            }
        
			return fRate;
        }
    }
}