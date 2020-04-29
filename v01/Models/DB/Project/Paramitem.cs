using System;
using System.Collections.Generic;

namespace Models.DB.Project
{
    public partial class ParamItem
    {
        public ParamItem()
        {
            Boqitem = new HashSet<BoqItem>();
            BoqitemAssembly = new HashSet<BoqItemAssembly>();
            BoqitemCondition = new HashSet<BoqItemCondition>();
            BoqitemConsumable = new HashSet<BoqItemConsumable>();
            BoqitemEquipment = new HashSet<BoqItemEquipment>();
            BoqitemLabor = new HashSet<BoqItemLabor>();
            BoqitemMaterial = new HashSet<BoqItemMaterial>();
            BoqitemSubcontractor = new HashSet<BoqItemSubcontractor>();
            Paramcondition = new HashSet<ParamCondition>();
            Paraminput = new HashSet<ParamInput>();
            Paramoutput = new HashSet<ParamOutput>();
            Paramreturn = new HashSet<Paramreturn>();
        }

        public long Paramitemid { get; set; }
        public decimal? Samplerate { get; set; }
        public bool? Wasexploded { get; set; }
        public string Icon { get; set; }
        public bool? Cmodel { get; set; }
        public string Groupname { get; set; }
        public decimal? Totalcost { get; set; }
        public decimal? Qty { get; set; }
        public bool? Multunitqty { get; set; }
        public string Variable { get; set; }
        public string Description { get; set; }
        public string Accrights { get; set; }
        public string Keyw { get; set; }
        public string Rescode { get; set; }
        public string Titleequ { get; set; }
        public string Groupidentity { get; set; }
        public string Title { get; set; }
        public string Unit { get; set; }
        public string Groupcode { get; set; }
        public string Gekcode { get; set; }
        public string Editorid { get; set; }
        public string Notes { get; set; }
        public DateTime? Lastupdate { get; set; }
        public string Extracode1 { get; set; }
        public string Extracode2 { get; set; }
        public string Extracode3 { get; set; }
        public string Extracode4 { get; set; }
        public string Extracode5 { get; set; }
        public string Extracode6 { get; set; }
        public string Extracode7 { get; set; }
        public string Extracode8 { get; set; }
        public string Extracode9 { get; set; }
        public string Extracode10 { get; set; }
        public string Wbs { get; set; }
        public string Wbs2 { get; set; }
        public string Loc { get; set; }
        public string Pswd { get; set; }
        public string Snum { get; set; }
        public string Prttype { get; set; }
        public string Createuserid { get; set; }
        public DateTime? Createdate { get; set; }
        public long? Boqitemid { get; set; }
        public long? Databaseid { get; set; }
        public long? Databasecreationdate { get; set; }
        public long? Glbid { get; set; }
        public long? Prjid { get; set; }
        public long? RefId { get; set; }

        public virtual BoqItem BoqitemNavigation { get; set; }
        public virtual ICollection<BoqItem> Boqitem { get; set; }
        public virtual ICollection<BoqItemAssembly> BoqitemAssembly { get; set; }
        public virtual ICollection<BoqItemCondition> BoqitemCondition { get; set; }
        public virtual ICollection<BoqItemConsumable> BoqitemConsumable { get; set; }
        public virtual ICollection<BoqItemEquipment> BoqitemEquipment { get; set; }
        public virtual ICollection<BoqItemLabor> BoqitemLabor { get; set; }
        public virtual ICollection<BoqItemMaterial> BoqitemMaterial { get; set; }
        public virtual ICollection<BoqItemSubcontractor> BoqitemSubcontractor { get; set; }
        public virtual ICollection<ParamCondition> Paramcondition { get; set; }
        public virtual ICollection<ParamInput> Paraminput { get; set; }
        public virtual ICollection<ParamOutput> Paramoutput { get; set; }
        public virtual ICollection<Paramreturn> Paramreturn { get; set; }
    }
}
