using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Assembly
    {
        public Assembly()
        {
            AssemblyConsumable = new HashSet<AssemblyConsumable>();
            AssemblyEquipment = new HashSet<AssemblyEquipment>();
            AssemblyHhistoryAssembly = new HashSet<AssemblyHhistory>();
            AssemblyHhistoryAssemlby = new HashSet<AssemblyHhistory>();
            AssemblyLabor = new HashSet<AssemblyLabor>();
            AssemblyMaterial = new HashSet<AssemblyMaterial>();
            AssemblySubcontractor = new HashSet<AssemblySubcontractor>();
            BoQitemAssembly = new HashSet<BoQitemAssembly>();
        }

        public long Assemblyid { get; set; }
        public DateTime? Lastupdate { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal? Productivity { get; set; }
        public decimal? Publishedrate { get; set; }
        public string Publishedcode { get; set; }
        public string Groupcode { get; set; }
        public string Gekcode { get; set; }
        public string Project { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public string Editorid { get; set; }
        public string Currency { get; set; }
        public string Stateprovince { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Labrate { get; set; }
        public decimal? Matrate { get; set; }
        public decimal? Subrate { get; set; }
        public decimal? Conrate { get; set; }
        public decimal? Equrate { get; set; }
        public decimal? Qty { get; set; }
        public string Accuracy { get; set; }
        public string Createuser { get; set; }
        public DateTime? Createdate { get; set; }
        public string Bimtype { get; set; }
        public string Bimmaterial { get; set; }
        public string Country { get; set; }
        public long? Databaseid { get; set; }
        public long? Databasecreationdate { get; set; }
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
        public bool? Virtual { get; set; }
        public bool? Virtualequ { get; set; }
        public bool? Virtualsub { get; set; }
        public bool? Virtuallab { get; set; }
        public bool? Virtualmat { get; set; }
        public bool? Virtualcon { get; set; }
        public decimal? Umhours { get; set; }
        public string Accrights { get; set; }
        public string Keyw { get; set; }
        public string Custxt1 { get; set; }
        public string Custxt2 { get; set; }
        public string Custxt3 { get; set; }
        public string Custxt4 { get; set; }
        public string Custxt5 { get; set; }
        public string Custxt6 { get; set; }
        public string Custxt7 { get; set; }
        public string Custxt8 { get; set; }
        public string Custxt9 { get; set; }
        public string Custxt10 { get; set; }
        public string Custxt11 { get; set; }
        public string Custxt12 { get; set; }
        public string Custxt13 { get; set; }
        public string Custxt14 { get; set; }
        public string Custxt15 { get; set; }
        public string Custxt16 { get; set; }
        public string Custxt17 { get; set; }
        public string Custxt18 { get; set; }
        public string Custxt19 { get; set; }
        public string Custxt20 { get; set; }
        public bool? Actbased { get; set; }
        public decimal? Uehours { get; set; }

        public virtual ICollection<AssemblyConsumable> AssemblyConsumable { get; set; }
        public virtual ICollection<AssemblyEquipment> AssemblyEquipment { get; set; }
        public virtual ICollection<AssemblyHhistory> AssemblyHhistoryAssembly { get; set; }
        public virtual ICollection<AssemblyHhistory> AssemblyHhistoryAssemlby { get; set; }
        public virtual ICollection<AssemblyLabor> AssemblyLabor { get; set; }
        public virtual ICollection<AssemblyMaterial> AssemblyMaterial { get; set; }
        public virtual ICollection<AssemblySubcontractor> AssemblySubcontractor { get; set; }
        public virtual ICollection<BoQitemAssembly> BoQitemAssembly { get; set; }
    }
}
