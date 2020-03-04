using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Model.DB.Project
{
    public partial class projectContext : DbContext
    {
        public projectContext()
        {
        }

        public projectContext(DbContextOptions<projectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assembly> Assembly { get; set; }
        public virtual DbSet<AssemblyChild> AssemblyChild { get; set; }
        public virtual DbSet<AssemblyConsumable> AssemblyConsumable { get; set; }
        public virtual DbSet<AssemblyEquipment> AssemblyEquipment { get; set; }
        public virtual DbSet<AssemblyLabor> AssemblyLabor { get; set; }
        public virtual DbSet<AssemblyMaterial> AssemblyMaterial { get; set; }
        public virtual DbSet<AssemblySubcontractor> AssemblySubcontractor { get; set; }
        public virtual DbSet<Asshistory> Asshistory { get; set; }
        public virtual DbSet<Boqitem> Boqitem { get; set; }
        public virtual DbSet<BoqitemAssembly> BoqitemAssembly { get; set; }
        public virtual DbSet<BoqitemCondition> BoqitemCondition { get; set; }
        public virtual DbSet<BoqitemConsumable> BoqitemConsumable { get; set; }
        public virtual DbSet<BoqitemEquipment> BoqitemEquipment { get; set; }
        public virtual DbSet<BoqitemLabor> BoqitemLabor { get; set; }
        public virtual DbSet<BoqitemMaterial> BoqitemMaterial { get; set; }
        public virtual DbSet<BoqitemSubcontractor> BoqitemSubcontractor { get; set; }
        public virtual DbSet<Boqitemmetadata> Boqitemmetadata { get; set; }
        public virtual DbSet<Cndon> Cndon { get; set; }
        public virtual DbSet<Cnmhistory> Cnmhistory { get; set; }
        public virtual DbSet<Conceptuals> Conceptuals { get; set; }
        public virtual DbSet<Consumable> Consumable { get; set; }
        public virtual DbSet<Equhistory> Equhistory { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Extracode1> Extracode1 { get; set; }
        public virtual DbSet<Extracode2> Extracode2 { get; set; }
        public virtual DbSet<Extracode3> Extracode3 { get; set; }
        public virtual DbSet<Extracode4> Extracode4 { get; set; }
        public virtual DbSet<Extracode5> Extracode5 { get; set; }
        public virtual DbSet<Extracode6> Extracode6 { get; set; }
        public virtual DbSet<Extracode7> Extracode7 { get; set; }
        public virtual DbSet<Fncton> Fncton { get; set; }
        public virtual DbSet<FnctonArgument> FnctonArgument { get; set; }
        public virtual DbSet<Gekcode> Gekcode { get; set; }
        public virtual DbSet<Groupcode> Groupcode { get; set; }
        public virtual DbSet<Ifcelement> Ifcelement { get; set; }
        public virtual DbSet<Ifcproperty> Ifcproperty { get; set; }
        public virtual DbSet<Labhistory> Labhistory { get; set; }
        public virtual DbSet<Labor> Labor { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<Mathistory> Mathistory { get; set; }
        public virtual DbSet<Ostdbcon> Ostdbcon { get; set; }
        public virtual DbSet<Paramcondition> Paramcondition { get; set; }
        public virtual DbSet<Paraminput> Paraminput { get; set; }
        public virtual DbSet<Paramitem> Paramitem { get; set; }
        public virtual DbSet<Paramoutput> Paramoutput { get; set; }
        public virtual DbSet<Paramreturn> Paramreturn { get; set; }
        public virtual DbSet<Prjprop> Prjprop { get; set; }
        public virtual DbSet<Prjuserprop> Prjuserprop { get; set; }
        public virtual DbSet<Projectspecvar> Projectspecvar { get; set; }
        public virtual DbSet<Projecttemplate> Projecttemplate { get; set; }
        public virtual DbSet<Projectwbs> Projectwbs { get; set; }
        public virtual DbSet<Projectwbs2> Projectwbs2 { get; set; }
        public virtual DbSet<Queryresource> Queryresource { get; set; }
        public virtual DbSet<Queryrow> Queryrow { get; set; }
        public virtual DbSet<Quote> Quote { get; set; }
        public virtual DbSet<Quoteitem> Quoteitem { get; set; }
        public virtual DbSet<Ratebuildup> Ratebuildup { get; set; }
        public virtual DbSet<Ratebuildupcols> Ratebuildupcols { get; set; }
        public virtual DbSet<Ratedistrib> Ratedistrib { get; set; }
        public virtual DbSet<Rawmaterial> Rawmaterial { get; set; }
        public virtual DbSet<Subcontractor> Subcontractor { get; set; }
        public virtual DbSet<Subhistory> Subhistory { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Wscolident> Wscolident { get; set; }
        public virtual DbSet<Wsdatamapping> Wsdatamapping { get; set; }
        public virtual DbSet<Wsfile> Wsfile { get; set; }
        public virtual DbSet<Wsrevision> Wsrevision { get; set; }
        public virtual DbSet<Xcellfile> Xcellfile { get; set; }
        public virtual DbSet<Xchangerate> Xchangerate { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=project;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Assembly>(entity =>
            {
                entity.ToTable("ASSEMBLY");

                entity.HasIndex(e => e.Databaseid)
                    .HasName("IDX_MDBID");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Assemblyid).HasColumnName("ASSEMBLYID");

                entity.Property(e => e.Accrights)
                    .HasColumnName("ACCRIGHTS")
                    .HasMaxLength(255);

                entity.Property(e => e.Accuracy)
                    .HasColumnName("ACCURACY")
                    .HasMaxLength(255);

                entity.Property(e => e.Actbased).HasColumnName("ACTBASED");

                entity.Property(e => e.Bimmaterial).HasColumnName("BIMMATERIAL");

                entity.Property(e => e.Bimtype)
                    .HasColumnName("BIMTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Conrate)
                    .HasColumnName("CONRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Createdate).HasColumnName("CREATEDATE");

                entity.Property(e => e.Createuser)
                    .HasColumnName("CREATEUSER")
                    .HasMaxLength(255);

                entity.Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasMaxLength(255);

                entity.Property(e => e.Cusrate1)
                    .HasColumnName("CUSRATE1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate10)
                    .HasColumnName("CUSRATE10")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate11)
                    .HasColumnName("CUSRATE11")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate12)
                    .HasColumnName("CUSRATE12")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate13)
                    .HasColumnName("CUSRATE13")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate14)
                    .HasColumnName("CUSRATE14")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate15)
                    .HasColumnName("CUSRATE15")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate16)
                    .HasColumnName("CUSRATE16")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate17)
                    .HasColumnName("CUSRATE17")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate18)
                    .HasColumnName("CUSRATE18")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate19)
                    .HasColumnName("CUSRATE19")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate2)
                    .HasColumnName("CUSRATE2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate20)
                    .HasColumnName("CUSRATE20")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate3)
                    .HasColumnName("CUSRATE3")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate4)
                    .HasColumnName("CUSRATE4")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate5)
                    .HasColumnName("CUSRATE5")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate6)
                    .HasColumnName("CUSRATE6")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate7)
                    .HasColumnName("CUSRATE7")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate8)
                    .HasColumnName("CUSRATE8")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate9)
                    .HasColumnName("CUSRATE9")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Custxt1)
                    .HasColumnName("CUSTXT1")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt10)
                    .HasColumnName("CUSTXT10")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt11)
                    .HasColumnName("CUSTXT11")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt12)
                    .HasColumnName("CUSTXT12")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt13)
                    .HasColumnName("CUSTXT13")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt14)
                    .HasColumnName("CUSTXT14")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt15)
                    .HasColumnName("CUSTXT15")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt16)
                    .HasColumnName("CUSTXT16")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt17)
                    .HasColumnName("CUSTXT17")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt18)
                    .HasColumnName("CUSTXT18")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt19)
                    .HasColumnName("CUSTXT19")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt2)
                    .HasColumnName("CUSTXT2")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt20)
                    .HasColumnName("CUSTXT20")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt21)
                    .HasColumnName("CUSTXT21")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt22)
                    .HasColumnName("CUSTXT22")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt23)
                    .HasColumnName("CUSTXT23")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt24)
                    .HasColumnName("CUSTXT24")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt25)
                    .HasColumnName("CUSTXT25")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt3)
                    .HasColumnName("CUSTXT3")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt4)
                    .HasColumnName("CUSTXT4")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt5)
                    .HasColumnName("CUSTXT5")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt6)
                    .HasColumnName("CUSTXT6")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt7)
                    .HasColumnName("CUSTXT7")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt8)
                    .HasColumnName("CUSTXT8")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt9)
                    .HasColumnName("CUSTXT9")
                    .HasMaxLength(255);

                entity.Property(e => e.Databasecreationdate).HasColumnName("DATABASECREATIONDATE");

                entity.Property(e => e.Databaseid).HasColumnName("DATABASEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Equrate)
                    .HasColumnName("EQURATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Extracode1)
                    .HasColumnName("EXTRACODE1")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode10)
                    .HasColumnName("EXTRACODE10")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode2)
                    .HasColumnName("EXTRACODE2")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode3)
                    .HasColumnName("EXTRACODE3")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode4)
                    .HasColumnName("EXTRACODE4")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode5)
                    .HasColumnName("EXTRACODE5")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode6)
                    .HasColumnName("EXTRACODE6")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode7)
                    .HasColumnName("EXTRACODE7")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode8)
                    .HasColumnName("EXTRACODE8")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode9)
                    .HasColumnName("EXTRACODE9")
                    .HasMaxLength(255);

                entity.Property(e => e.Gekcode)
                    .HasColumnName("GEKCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Keyw).HasColumnName("KEYW");

                entity.Property(e => e.Labrate)
                    .HasColumnName("LABRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Matrate)
                    .HasColumnName("MATRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Notes).HasColumnName("NOTES");

                entity.Property(e => e.Overtype).HasColumnName("OVERTYPE");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Productivity)
                    .HasColumnName("PRODUCTIVITY")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Project)
                    .HasColumnName("PROJECT")
                    .HasMaxLength(255);

                entity.Property(e => e.Publishedcode)
                    .HasColumnName("PUBLISHEDCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Publishedrate)
                    .HasColumnName("PUBLISHEDRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Puex1factor)
                    .HasColumnName("PUEX1FACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Puex2factor)
                    .HasColumnName("PUEX2FACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Puex3factor)
                    .HasColumnName("PUEX3FACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Puex4factor)
                    .HasColumnName("PUEX4FACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Puex5factor)
                    .HasColumnName("PUEX5FACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Puex6factor)
                    .HasColumnName("PUEX6FACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Puex7factor)
                    .HasColumnName("PUEX7FACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Pugekfactor)
                    .HasColumnName("PUGEKFACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Pugrcfactor)
                    .HasColumnName("PUGRCFACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qty)
                    .HasColumnName("QTY")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Rescode)
                    .HasColumnName("RESCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Stateprovince)
                    .HasColumnName("STATEPROVINCE")
                    .HasMaxLength(255);

                entity.Property(e => e.Subrate)
                    .HasColumnName("SUBRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Uehours)
                    .HasColumnName("UEHOURS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Umhours)
                    .HasColumnName("UMHOURS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Vars).HasColumnName("VARS");

                entity.Property(e => e.Virtual).HasColumnName("VIRTUAL");

                entity.Property(e => e.Virtualcon).HasColumnName("VIRTUALCON");

                entity.Property(e => e.Virtualequ).HasColumnName("VIRTUALEQU");

                entity.Property(e => e.Virtuallab).HasColumnName("VIRTUALLAB");

                entity.Property(e => e.Virtualmat).HasColumnName("VIRTUALMAT");

                entity.Property(e => e.Virtualsub).HasColumnName("VIRTUALSUB");
            });

            modelBuilder.Entity<AssemblyChild>(entity =>
            {
                entity.ToTable("ASSEMBLY_CHILD");

                entity.HasIndex(e => e.Assemblyid)
                    .HasName("IDX_ASSEMBLY");

                entity.HasIndex(e => e.Childid)
                    .HasName("IDX_ASSEMBLY_CHILD");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Assemblychildid).HasColumnName("ASSEMBLYCHILDID");

                entity.Property(e => e.Assemblyid).HasColumnName("ASSEMBLYID");

                entity.Property(e => e.Childid).HasColumnName("CHILDID");

                entity.Property(e => e.Divider)
                    .HasColumnName("DIVIDER")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Exchangerate)
                    .HasColumnName("EXCHANGERATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Finalfixedcost)
                    .HasColumnName("FINALFIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fixedcost)
                    .HasColumnName("FIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255);

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.PvVars).HasColumnName("PV_VARS");

                entity.Property(e => e.Qtypuformstate).HasColumnName("QTYPUFORMSTATE");

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qtypunitform).HasColumnName("QTYPUNITFORM");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.HasOne(d => d.Assembly)
                    .WithMany(p => p.AssemblyChildAssembly)
                    .HasForeignKey(d => d.Assemblyid)
                    .HasConstraintName("FKE296096314030E1E");

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.AssemblyChildChild)
                    .HasForeignKey(d => d.Childid)
                    .HasConstraintName("FKE2960963CD57CFD4");
            });

            modelBuilder.Entity<AssemblyConsumable>(entity =>
            {
                entity.ToTable("ASSEMBLY_CONSUMABLE");

                entity.HasIndex(e => e.Assemblyid)
                    .HasName("IDX_ASSEMBLY");

                entity.HasIndex(e => e.Consumableid)
                    .HasName("IDX_CONSUMABLE");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Assemblyconsumableid).HasColumnName("ASSEMBLYCONSUMABLEID");

                entity.Property(e => e.Assemblyid).HasColumnName("ASSEMBLYID");

                entity.Property(e => e.Consumableid).HasColumnName("CONSUMABLEID");

                entity.Property(e => e.Divider)
                    .HasColumnName("DIVIDER")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Exchangerate)
                    .HasColumnName("EXCHANGERATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Finalfixedcost)
                    .HasColumnName("FINALFIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fixedcost)
                    .HasColumnName("FIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255);

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.PvVars).HasColumnName("PV_VARS");

                entity.Property(e => e.Qtypuformstate).HasColumnName("QTYPUFORMSTATE");

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qtypunitform).HasColumnName("QTYPUNITFORM");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.HasOne(d => d.Assembly)
                    .WithMany(p => p.AssemblyConsumable)
                    .HasForeignKey(d => d.Assemblyid)
                    .HasConstraintName("FKF8A5E65C14030E1E");

                entity.HasOne(d => d.Consumable)
                    .WithMany(p => p.AssemblyConsumable)
                    .HasForeignKey(d => d.Consumableid)
                    .HasConstraintName("FKF8A5E65CFFA537BE");
            });

            modelBuilder.Entity<AssemblyEquipment>(entity =>
            {
                entity.ToTable("ASSEMBLY_EQUIPMENT");

                entity.HasIndex(e => e.Assemblyid)
                    .HasName("IDX_ASSEMBLY");

                entity.HasIndex(e => e.Equipmentid)
                    .HasName("IDX_EQUIPMENT");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Assemblyequipmentid).HasColumnName("ASSEMBLYEQUIPMENTID");

                entity.Property(e => e.Assemblyid).HasColumnName("ASSEMBLYID");

                entity.Property(e => e.Energyprice)
                    .HasColumnName("ENERGYPRICE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Equipmentid).HasColumnName("EQUIPMENTID");

                entity.Property(e => e.Exchangerate)
                    .HasColumnName("EXCHANGERATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor3)
                    .HasColumnName("FACTOR3")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fdeprate)
                    .HasColumnName("FDEPRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Finalfixedcost)
                    .HasColumnName("FINALFIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Finalfuelrate)
                    .HasColumnName("FINALFUELRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fixedcost)
                    .HasColumnName("FIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fuelrate)
                    .HasColumnName("FUELRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255);

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.PvVars).HasColumnName("PV_VARS");

                entity.Property(e => e.Qtypuformstate).HasColumnName("QTYPUFORMSTATE");

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qtypunitform).HasColumnName("QTYPUNITFORM");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Unithours)
                    .HasColumnName("UNITHOURS")
                    .HasColumnType("numeric(30, 10)");

                entity.HasOne(d => d.Assembly)
                    .WithMany(p => p.AssemblyEquipment)
                    .HasForeignKey(d => d.Assemblyid)
                    .HasConstraintName("FK71C9765514030E1E");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.AssemblyEquipment)
                    .HasForeignKey(d => d.Equipmentid)
                    .HasConstraintName("FK71C97655B2878194");
            });

            modelBuilder.Entity<AssemblyLabor>(entity =>
            {
                entity.ToTable("ASSEMBLY_LABOR");

                entity.HasIndex(e => e.Assemblyid)
                    .HasName("IDX_ASSEMBLY");

                entity.HasIndex(e => e.Laborid)
                    .HasName("IDX_LABOR");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Assemblylaborid).HasColumnName("ASSEMBLYLABORID");

                entity.Property(e => e.Assemblyid).HasColumnName("ASSEMBLYID");

                entity.Property(e => e.Exchangerate)
                    .HasColumnName("EXCHANGERATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor3)
                    .HasColumnName("FACTOR3")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fikarate)
                    .HasColumnName("FIKARATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Finalfixedcost)
                    .HasColumnName("FINALFIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fixedcost)
                    .HasColumnName("FIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Laborid).HasColumnName("LABORID");

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255);

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.PvVars).HasColumnName("PV_VARS");

                entity.Property(e => e.Qtypuformstate).HasColumnName("QTYPUFORMSTATE");

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qtypunitform).HasColumnName("QTYPUNITFORM");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Unithours)
                    .HasColumnName("UNITHOURS")
                    .HasColumnType("numeric(30, 10)");

                entity.HasOne(d => d.Assembly)
                    .WithMany(p => p.AssemblyLabor)
                    .HasForeignKey(d => d.Assemblyid)
                    .HasConstraintName("FKE311947714030E1E");

                entity.HasOne(d => d.Labor)
                    .WithMany(p => p.AssemblyLabor)
                    .HasForeignKey(d => d.Laborid)
                    .HasConstraintName("FKE31194775C7E33D4");
            });

            modelBuilder.Entity<AssemblyMaterial>(entity =>
            {
                entity.ToTable("ASSEMBLY_MATERIAL");

                entity.HasIndex(e => e.Assemblyid)
                    .HasName("IDX_ASSEMBLY");

                entity.HasIndex(e => e.Materialid)
                    .HasName("IDX_MATERIAL");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Assemblymaterialid).HasColumnName("ASSEMBLYMATERIALID");

                entity.Property(e => e.Assemblyid).HasColumnName("ASSEMBLYID");

                entity.Property(e => e.Divider)
                    .HasColumnName("DIVIDER")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Exchangerate)
                    .HasColumnName("EXCHANGERATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Finalfixedcost)
                    .HasColumnName("FINALFIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fixedcost)
                    .HasColumnName("FIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255);

                entity.Property(e => e.Materialid).HasColumnName("MATERIALID");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.PvVars).HasColumnName("PV_VARS");

                entity.Property(e => e.Qtypuformstate).HasColumnName("QTYPUFORMSTATE");

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qtypunitform).HasColumnName("QTYPUNITFORM");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.HasOne(d => d.Assembly)
                    .WithMany(p => p.AssemblyMaterial)
                    .HasForeignKey(d => d.Assemblyid)
                    .HasConstraintName("FKC0D89B6014030E1E");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.AssemblyMaterial)
                    .HasForeignKey(d => d.Materialid)
                    .HasConstraintName("FKC0D89B602461A27E");
            });

            modelBuilder.Entity<AssemblySubcontractor>(entity =>
            {
                entity.ToTable("ASSEMBLY_SUBCONTRACTOR");

                entity.HasIndex(e => e.Assemblyid)
                    .HasName("IDX_ASSEMBLY");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.HasIndex(e => e.Subcontractorid)
                    .HasName("IDX_SUBCONTRACTOR");

                entity.Property(e => e.Assemblysubcontractorid).HasColumnName("ASSEMBLYSUBCONTRACTORID");

                entity.Property(e => e.Assemblyid).HasColumnName("ASSEMBLYID");

                entity.Property(e => e.Exchangerate)
                    .HasColumnName("EXCHANGERATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor3)
                    .HasColumnName("FACTOR3")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fikarate)
                    .HasColumnName("FIKARATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Finalfixedcost)
                    .HasColumnName("FINALFIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fixedcost)
                    .HasColumnName("FIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255);

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.PvVars).HasColumnName("PV_VARS");

                entity.Property(e => e.Qtypuformstate).HasColumnName("QTYPUFORMSTATE");

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qtypunitform).HasColumnName("QTYPUNITFORM");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Subcontractorid).HasColumnName("SUBCONTRACTORID");

                entity.HasOne(d => d.Assembly)
                    .WithMany(p => p.AssemblySubcontractor)
                    .HasForeignKey(d => d.Assemblyid)
                    .HasConstraintName("FK3F0CDDFC14030E1E");

                entity.HasOne(d => d.Subcontractor)
                    .WithMany(p => p.AssemblySubcontractor)
                    .HasForeignKey(d => d.Subcontractorid)
                    .HasConstraintName("FK3F0CDDFC7C0276B4");
            });

            modelBuilder.Entity<Asshistory>(entity =>
            {
                entity.ToTable("ASSHISTORY");

                entity.HasIndex(e => e.Assemlbyid)
                    .HasName("IDX_ASSEMBLY");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Assemblyid).HasColumnName("ASSEMBLYID");

                entity.Property(e => e.Assemlbyid).HasColumnName("ASSEMLBYID");

                entity.Property(e => e.Basetableid)
                    .HasColumnName("BASETABLEID")
                    .HasMaxLength(255);

                entity.Property(e => e.Preddate).HasColumnName("PREDDATE");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Rsrc).HasColumnName("RSRC");

                entity.HasOne(d => d.Assembly)
                    .WithMany(p => p.AsshistoryAssembly)
                    .HasForeignKey(d => d.Assemblyid)
                    .HasConstraintName("FK28E2B2F314030E1E");

                entity.HasOne(d => d.Assemlby)
                    .WithMany(p => p.AsshistoryAssemlby)
                    .HasForeignKey(d => d.Assemlbyid)
                    .HasConstraintName("FK28E2B2F3148B6D72");
            });

            modelBuilder.Entity<Boqitem>(entity =>
            {
                entity.ToTable("BOQITEM");

                entity.HasIndex(e => e.Code)
                    .HasName("IDX_CODE");

                entity.HasIndex(e => e.Editorid)
                    .HasName("IDX_EDITORID");

                entity.HasIndex(e => e.Estimator)
                    .HasName("IDX_ESTIMATORID");

                entity.HasIndex(e => e.Generationid)
                    .HasName("IDX_GENID");

                entity.HasIndex(e => e.Paramitemid)
                    .HasName("IDX_PARAMITEM");

                entity.HasIndex(e => e.Publisheditemcode)
                    .HasName("IDX_PBCODE");

                entity.HasIndex(e => e.Publishedrevisioncode)
                    .HasName("IDX_PBRVCODE");

                entity.HasIndex(e => e.Wrslkp)
                    .HasName("IDX_WSLKP");

                entity.HasIndex(e => new { e.Code, e.Prjid })
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Boqitemid).HasColumnName("BOQITEMID");

                entity.Property(e => e.Accuracy)
                    .HasColumnName("ACCURACY")
                    .HasMaxLength(255);

                entity.Property(e => e.Actbased).HasColumnName("ACTBASED");

                entity.Property(e => e.Adjprod)
                    .HasColumnName("ADJPROD")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Adjprodform).HasColumnName("ADJPRODFORM");

                entity.Property(e => e.Asrt).HasColumnName("ASRT");

                entity.Property(e => e.Asscost)
                    .HasColumnName("ASSCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Assrate)
                    .HasColumnName("ASSRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Asstotalform).HasColumnName("ASSTOTALFORM");

                entity.Property(e => e.Aumhform).HasColumnName("AUMHFORM");

                entity.Property(e => e.Aunitmhours)
                    .HasColumnName("AUNITMHOURS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Awdind)
                    .HasColumnName("AWDIND")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Awdins)
                    .HasColumnName("AWDINS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Awdmat)
                    .HasColumnName("AWDMAT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Awdmhours)
                    .HasColumnName("AWDMHOURS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Awdship)
                    .HasColumnName("AWDSHIP")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Awdsub)
                    .HasColumnName("AWDSUB")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Awdtotal)
                    .HasColumnName("AWDTOTAL")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Bimmaterial).HasColumnName("BIMMATERIAL");

                entity.Property(e => e.Bimtype).HasColumnName("BIMTYPE");

                entity.Property(e => e.CalculatedRate)
                    .HasColumnName("CALCULATED_RATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.CalculatedTotalCost)
                    .HasColumnName("CALCULATED_TOTAL_COST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cmrt).HasColumnName("CMRT");

                entity.Property(e => e.Cnqt).HasColumnName("CNQT");

                entity.Property(e => e.Code).HasColumnName("CODE");

                entity.Property(e => e.Concost)
                    .HasColumnName("CONCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Conrate)
                    .HasColumnName("CONRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Contotalform)
                    .HasColumnName("CONTOTALFORM")
                    .HasMaxLength(255);

                entity.Property(e => e.CreateDate).HasColumnName("CREATE_DATE");

                entity.Property(e => e.Createuserid)
                    .HasColumnName("CREATEUSERID")
                    .HasMaxLength(255);

                entity.Property(e => e.Cuscum10form).HasColumnName("CUSCUM10FORM");

                entity.Property(e => e.Cuscum11form).HasColumnName("CUSCUM11FORM");

                entity.Property(e => e.Cuscum12form).HasColumnName("CUSCUM12FORM");

                entity.Property(e => e.Cuscum13form).HasColumnName("CUSCUM13FORM");

                entity.Property(e => e.Cuscum14form).HasColumnName("CUSCUM14FORM");

                entity.Property(e => e.Cuscum15form).HasColumnName("CUSCUM15FORM");

                entity.Property(e => e.Cuscum16form).HasColumnName("CUSCUM16FORM");

                entity.Property(e => e.Cuscum17form).HasColumnName("CUSCUM17FORM");

                entity.Property(e => e.Cuscum18form).HasColumnName("CUSCUM18FORM");

                entity.Property(e => e.Cuscum19form).HasColumnName("CUSCUM19FORM");

                entity.Property(e => e.Cuscum1form).HasColumnName("CUSCUM1FORM");

                entity.Property(e => e.Cuscum20form).HasColumnName("CUSCUM20FORM");

                entity.Property(e => e.Cuscum2form).HasColumnName("CUSCUM2FORM");

                entity.Property(e => e.Cuscum3form).HasColumnName("CUSCUM3FORM");

                entity.Property(e => e.Cuscum4form).HasColumnName("CUSCUM4FORM");

                entity.Property(e => e.Cuscum5form).HasColumnName("CUSCUM5FORM");

                entity.Property(e => e.Cuscum6form).HasColumnName("CUSCUM6FORM");

                entity.Property(e => e.Cuscum7form).HasColumnName("CUSCUM7FORM");

                entity.Property(e => e.Cuscum8form).HasColumnName("CUSCUM8FORM");

                entity.Property(e => e.Cuscum9form).HasColumnName("CUSCUM9FORM");

                entity.Property(e => e.Cuscumrate1)
                    .HasColumnName("CUSCUMRATE1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cuscumrate10)
                    .HasColumnName("CUSCUMRATE10")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cuscumrate11)
                    .HasColumnName("CUSCUMRATE11")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cuscumrate12)
                    .HasColumnName("CUSCUMRATE12")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cuscumrate13)
                    .HasColumnName("CUSCUMRATE13")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cuscumrate14)
                    .HasColumnName("CUSCUMRATE14")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cuscumrate15)
                    .HasColumnName("CUSCUMRATE15")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cuscumrate16)
                    .HasColumnName("CUSCUMRATE16")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cuscumrate17)
                    .HasColumnName("CUSCUMRATE17")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cuscumrate18)
                    .HasColumnName("CUSCUMRATE18")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cuscumrate19)
                    .HasColumnName("CUSCUMRATE19")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cuscumrate2)
                    .HasColumnName("CUSCUMRATE2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cuscumrate20)
                    .HasColumnName("CUSCUMRATE20")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cuscumrate3)
                    .HasColumnName("CUSCUMRATE3")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cuscumrate4)
                    .HasColumnName("CUSCUMRATE4")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cuscumrate5)
                    .HasColumnName("CUSCUMRATE5")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cuscumrate6)
                    .HasColumnName("CUSCUMRATE6")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cuscumrate7)
                    .HasColumnName("CUSCUMRATE7")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cuscumrate8)
                    .HasColumnName("CUSCUMRATE8")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cuscumrate9)
                    .HasColumnName("CUSCUMRATE9")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusdate1).HasColumnName("CUSDATE1");

                entity.Property(e => e.Cusdate2).HasColumnName("CUSDATE2");

                entity.Property(e => e.Cusdate3).HasColumnName("CUSDATE3");

                entity.Property(e => e.Cusdate4).HasColumnName("CUSDATE4");

                entity.Property(e => e.Cusdate5).HasColumnName("CUSDATE5");

                entity.Property(e => e.Cusper1)
                    .HasColumnName("CUSPER1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusper10)
                    .HasColumnName("CUSPER10")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusper10form).HasColumnName("CUSPER10FORM");

                entity.Property(e => e.Cusper11)
                    .HasColumnName("CUSPER11")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusper11form).HasColumnName("CUSPER11FORM");

                entity.Property(e => e.Cusper12)
                    .HasColumnName("CUSPER12")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusper12form).HasColumnName("CUSPER12FORM");

                entity.Property(e => e.Cusper13)
                    .HasColumnName("CUSPER13")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusper13form).HasColumnName("CUSPER13FORM");

                entity.Property(e => e.Cusper14)
                    .HasColumnName("CUSPER14")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusper14form).HasColumnName("CUSPER14FORM");

                entity.Property(e => e.Cusper15)
                    .HasColumnName("CUSPER15")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusper15form).HasColumnName("CUSPER15FORM");

                entity.Property(e => e.Cusper16)
                    .HasColumnName("CUSPER16")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusper16form).HasColumnName("CUSPER16FORM");

                entity.Property(e => e.Cusper17)
                    .HasColumnName("CUSPER17")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusper17form).HasColumnName("CUSPER17FORM");

                entity.Property(e => e.Cusper18)
                    .HasColumnName("CUSPER18")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusper18form).HasColumnName("CUSPER18FORM");

                entity.Property(e => e.Cusper19)
                    .HasColumnName("CUSPER19")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusper19form).HasColumnName("CUSPER19FORM");

                entity.Property(e => e.Cusper1form).HasColumnName("CUSPER1FORM");

                entity.Property(e => e.Cusper2)
                    .HasColumnName("CUSPER2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusper20)
                    .HasColumnName("CUSPER20")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusper20form).HasColumnName("CUSPER20FORM");

                entity.Property(e => e.Cusper2form).HasColumnName("CUSPER2FORM");

                entity.Property(e => e.Cusper3)
                    .HasColumnName("CUSPER3")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusper3form).HasColumnName("CUSPER3FORM");

                entity.Property(e => e.Cusper4)
                    .HasColumnName("CUSPER4")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusper4form).HasColumnName("CUSPER4FORM");

                entity.Property(e => e.Cusper5)
                    .HasColumnName("CUSPER5")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusper5form).HasColumnName("CUSPER5FORM");

                entity.Property(e => e.Cusper6)
                    .HasColumnName("CUSPER6")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusper6form).HasColumnName("CUSPER6FORM");

                entity.Property(e => e.Cusper7)
                    .HasColumnName("CUSPER7")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusper7form).HasColumnName("CUSPER7FORM");

                entity.Property(e => e.Cusper8)
                    .HasColumnName("CUSPER8")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusper8form).HasColumnName("CUSPER8FORM");

                entity.Property(e => e.Cusper9)
                    .HasColumnName("CUSPER9")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusper9form).HasColumnName("CUSPER9FORM");

                entity.Property(e => e.Cusrate1)
                    .HasColumnName("CUSRATE1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate10)
                    .HasColumnName("CUSRATE10")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate10form).HasColumnName("CUSRATE10FORM");

                entity.Property(e => e.Cusrate11)
                    .HasColumnName("CUSRATE11")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate11form).HasColumnName("CUSRATE11FORM");

                entity.Property(e => e.Cusrate12)
                    .HasColumnName("CUSRATE12")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate12form).HasColumnName("CUSRATE12FORM");

                entity.Property(e => e.Cusrate13)
                    .HasColumnName("CUSRATE13")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate13form).HasColumnName("CUSRATE13FORM");

                entity.Property(e => e.Cusrate14)
                    .HasColumnName("CUSRATE14")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate14form).HasColumnName("CUSRATE14FORM");

                entity.Property(e => e.Cusrate15)
                    .HasColumnName("CUSRATE15")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate15form).HasColumnName("CUSRATE15FORM");

                entity.Property(e => e.Cusrate16)
                    .HasColumnName("CUSRATE16")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate16form).HasColumnName("CUSRATE16FORM");

                entity.Property(e => e.Cusrate17)
                    .HasColumnName("CUSRATE17")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate17form).HasColumnName("CUSRATE17FORM");

                entity.Property(e => e.Cusrate18)
                    .HasColumnName("CUSRATE18")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate18form).HasColumnName("CUSRATE18FORM");

                entity.Property(e => e.Cusrate19)
                    .HasColumnName("CUSRATE19")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate19form).HasColumnName("CUSRATE19FORM");

                entity.Property(e => e.Cusrate1form).HasColumnName("CUSRATE1FORM");

                entity.Property(e => e.Cusrate2)
                    .HasColumnName("CUSRATE2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate20)
                    .HasColumnName("CUSRATE20")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate20form).HasColumnName("CUSRATE20FORM");

                entity.Property(e => e.Cusrate2form).HasColumnName("CUSRATE2FORM");

                entity.Property(e => e.Cusrate3)
                    .HasColumnName("CUSRATE3")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate3form).HasColumnName("CUSRATE3FORM");

                entity.Property(e => e.Cusrate4)
                    .HasColumnName("CUSRATE4")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate4form).HasColumnName("CUSRATE4FORM");

                entity.Property(e => e.Cusrate5)
                    .HasColumnName("CUSRATE5")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate5form).HasColumnName("CUSRATE5FORM");

                entity.Property(e => e.Cusrate6)
                    .HasColumnName("CUSRATE6")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate6form).HasColumnName("CUSRATE6FORM");

                entity.Property(e => e.Cusrate7)
                    .HasColumnName("CUSRATE7")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate7form).HasColumnName("CUSRATE7FORM");

                entity.Property(e => e.Cusrate8)
                    .HasColumnName("CUSRATE8")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate8form).HasColumnName("CUSRATE8FORM");

                entity.Property(e => e.Cusrate9)
                    .HasColumnName("CUSRATE9")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusrate9form).HasColumnName("CUSRATE9FORM");

                entity.Property(e => e.Custxt1)
                    .HasColumnName("CUSTXT1")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt10)
                    .HasColumnName("CUSTXT10")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt10form).HasColumnName("CUSTXT10FORM");

                entity.Property(e => e.Custxt11)
                    .HasColumnName("CUSTXT11")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt11form).HasColumnName("CUSTXT11FORM");

                entity.Property(e => e.Custxt12)
                    .HasColumnName("CUSTXT12")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt12form).HasColumnName("CUSTXT12FORM");

                entity.Property(e => e.Custxt13)
                    .HasColumnName("CUSTXT13")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt13form).HasColumnName("CUSTXT13FORM");

                entity.Property(e => e.Custxt14)
                    .HasColumnName("CUSTXT14")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt14form).HasColumnName("CUSTXT14FORM");

                entity.Property(e => e.Custxt15)
                    .HasColumnName("CUSTXT15")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt15form).HasColumnName("CUSTXT15FORM");

                entity.Property(e => e.Custxt16)
                    .HasColumnName("CUSTXT16")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt16form).HasColumnName("CUSTXT16FORM");

                entity.Property(e => e.Custxt17)
                    .HasColumnName("CUSTXT17")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt17form).HasColumnName("CUSTXT17FORM");

                entity.Property(e => e.Custxt18)
                    .HasColumnName("CUSTXT18")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt18form).HasColumnName("CUSTXT18FORM");

                entity.Property(e => e.Custxt19)
                    .HasColumnName("CUSTXT19")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt19form).HasColumnName("CUSTXT19FORM");

                entity.Property(e => e.Custxt1form).HasColumnName("CUSTXT1FORM");

                entity.Property(e => e.Custxt2)
                    .HasColumnName("CUSTXT2")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt20)
                    .HasColumnName("CUSTXT20")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt20form).HasColumnName("CUSTXT20FORM");

                entity.Property(e => e.Custxt21)
                    .HasColumnName("CUSTXT21")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt21form).HasColumnName("CUSTXT21FORM");

                entity.Property(e => e.Custxt22)
                    .HasColumnName("CUSTXT22")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt22form).HasColumnName("CUSTXT22FORM");

                entity.Property(e => e.Custxt23)
                    .HasColumnName("CUSTXT23")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt23form).HasColumnName("CUSTXT23FORM");

                entity.Property(e => e.Custxt24)
                    .HasColumnName("CUSTXT24")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt24form).HasColumnName("CUSTXT24FORM");

                entity.Property(e => e.Custxt25)
                    .HasColumnName("CUSTXT25")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt25form).HasColumnName("CUSTXT25FORM");

                entity.Property(e => e.Custxt2form).HasColumnName("CUSTXT2FORM");

                entity.Property(e => e.Custxt3)
                    .HasColumnName("CUSTXT3")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt3form).HasColumnName("CUSTXT3FORM");

                entity.Property(e => e.Custxt4)
                    .HasColumnName("CUSTXT4")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt4form).HasColumnName("CUSTXT4FORM");

                entity.Property(e => e.Custxt5)
                    .HasColumnName("CUSTXT5")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt5form).HasColumnName("CUSTXT5FORM");

                entity.Property(e => e.Custxt6)
                    .HasColumnName("CUSTXT6")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt6form).HasColumnName("CUSTXT6FORM");

                entity.Property(e => e.Custxt7)
                    .HasColumnName("CUSTXT7")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt7form).HasColumnName("CUSTXT7FORM");

                entity.Property(e => e.Custxt8)
                    .HasColumnName("CUSTXT8")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt8form).HasColumnName("CUSTXT8FORM");

                entity.Property(e => e.Custxt9)
                    .HasColumnName("CUSTXT9")
                    .HasMaxLength(255);

                entity.Property(e => e.Custxt9form).HasColumnName("CUSTXT9FORM");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Dscform).HasColumnName("DSCFORM");

                entity.Property(e => e.Duration)
                    .HasColumnName("DURATION")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Durationform).HasColumnName("DURATIONFORM");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Eqrt).HasColumnName("EQRT");

                entity.Property(e => e.Eqtyform).HasColumnName("EQTYFORM");

                entity.Property(e => e.Equcost)
                    .HasColumnName("EQUCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Equhours)
                    .HasColumnName("EQUHOURS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Equrate)
                    .HasColumnName("EQURATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Equtotalform).HasColumnName("EQUTOTALFORM");

                entity.Property(e => e.Escalation)
                    .HasColumnName("ESCALATION")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Estimator)
                    .HasColumnName("ESTIMATOR")
                    .HasMaxLength(255);

                entity.Property(e => e.Estquant)
                    .HasColumnName("ESTQUANT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Extracode1)
                    .HasColumnName("EXTRACODE1")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode10)
                    .HasColumnName("EXTRACODE10")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode2)
                    .HasColumnName("EXTRACODE2")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode3)
                    .HasColumnName("EXTRACODE3")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode4)
                    .HasColumnName("EXTRACODE4")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode5)
                    .HasColumnName("EXTRACODE5")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode6)
                    .HasColumnName("EXTRACODE6")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode7)
                    .HasColumnName("EXTRACODE7")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode8)
                    .HasColumnName("EXTRACODE8")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode9)
                    .HasColumnName("EXTRACODE9")
                    .HasMaxLength(255);

                entity.Property(e => e.Fabcost)
                    .HasColumnName("FABCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fabrate)
                    .HasColumnName("FABRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fixedcost)
                    .HasColumnName("FIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Flag).HasColumnName("FLAG");

                entity.Property(e => e.Gekcode)
                    .HasColumnName("GEKCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Generationid)
                    .HasColumnName("GENERATIONID")
                    .HasMaxLength(255);

                entity.Property(e => e.Glbparamitemid).HasColumnName("GLBPARAMITEMID");

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.HasAssform).HasColumnName("HAS_ASSFORM");

                entity.Property(e => e.HasProductivity).HasColumnName("HAS_PRODUCTIVITY");

                entity.Property(e => e.HasPvform).HasColumnName("HAS_PVFORM");

                entity.Property(e => e.Labcost)
                    .HasColumnName("LABCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Labrate)
                    .HasColumnName("LABRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Labtotalform).HasColumnName("LABTOTALFORM");

                entity.Property(e => e.LastUpdate).HasColumnName("LAST_UPDATE");

                entity.Property(e => e.Lbrt).HasColumnName("LBRT");

                entity.Property(e => e.Location)
                    .HasColumnName("LOCATION")
                    .HasMaxLength(255);

                entity.Property(e => e.Loccountry)
                    .HasColumnName("LOCCOUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Locfac)
                    .HasColumnName("LOCFAC")
                    .HasMaxLength(255);

                entity.Property(e => e.Locprof)
                    .HasColumnName("LOCPROF")
                    .HasMaxLength(255);

                entity.Property(e => e.Locstate)
                    .HasColumnName("LOCSTATE")
                    .HasMaxLength(255);

                entity.Property(e => e.Manhours)
                    .HasColumnName("MANHOURS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Markup)
                    .HasColumnName("MARKUP")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Markupform).HasColumnName("MARKUPFORM");

                entity.Property(e => e.Mart).HasColumnName("MART");

                entity.Property(e => e.Matcost)
                    .HasColumnName("MATCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Matquoterate)
                    .HasColumnName("MATQUOTERATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Matrate)
                    .HasColumnName("MATRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Matrescost)
                    .HasColumnName("MATRESCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Mattotalform).HasColumnName("MATTOTALFORM");

                entity.Property(e => e.Measquant)
                    .HasColumnName("MEASQUANT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Mhfacform).HasColumnName("MHFACFORM");

                entity.Property(e => e.Mhoursfactor)
                    .HasColumnName("MHOURSFACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Mqtyform).HasColumnName("MQTYFORM");

                entity.Property(e => e.Notes).HasColumnName("NOTES");

                entity.Property(e => e.Offeredpriceform).HasColumnName("OFFEREDPRICEFORM");

                entity.Property(e => e.Offprice)
                    .HasColumnName("OFFPRICE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Offrate)
                    .HasColumnName("OFFRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Offrateform).HasColumnName("OFFRATEFORM");

                entity.Property(e => e.Offsecrate)
                    .HasColumnName("OFFSECRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Offsecrateform).HasColumnName("OFFSECRATEFORM");

                entity.Property(e => e.Paramcode)
                    .HasColumnName("PARAMCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Paramitemid).HasColumnName("PARAMITEMID");

                entity.Property(e => e.PaymentDate).HasColumnName("PAYMENT_DATE");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Prodfacform).HasColumnName("PRODFACFORM");

                entity.Property(e => e.Prodfactor)
                    .HasColumnName("PRODFACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Prodform).HasColumnName("PRODFORM");

                entity.Property(e => e.Productivity)
                    .HasColumnName("PRODUCTIVITY")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Publisheditemcode)
                    .HasColumnName("PUBLISHEDITEMCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Publishedrate)
                    .HasColumnName("PUBLISHEDRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Publishedrevisioncode)
                    .HasColumnName("PUBLISHEDREVISIONCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Puex1factor)
                    .HasColumnName("PUEX1FACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Puex2factor)
                    .HasColumnName("PUEX2FACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Puex3factor)
                    .HasColumnName("PUEX3FACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Puex4factor)
                    .HasColumnName("PUEX4FACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Puex5factor)
                    .HasColumnName("PUEX5FACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Puex6factor)
                    .HasColumnName("PUEX6FACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Puex7factor)
                    .HasColumnName("PUEX7FACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Pugekfactor)
                    .HasColumnName("PUGEKFACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Pugrcfactor)
                    .HasColumnName("PUGRCFACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.PvVars).HasColumnName("PV_VARS");

                entity.Property(e => e.Qtyform).HasColumnName("QTYFORM");

                entity.Property(e => e.Qtylossform).HasColumnName("QTYLOSSFORM");

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Quantloss)
                    .HasColumnName("QUANTLOSS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rateform).HasColumnName("RATEFORM");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Rollup)
                    .HasColumnName("ROLLUP")
                    .HasMaxLength(255);

                entity.Property(e => e.Sbrt).HasColumnName("SBRT");

                entity.Property(e => e.Scheduled).HasColumnName("SCHEDULED");

                entity.Property(e => e.SecondUnit)
                    .HasColumnName("SECOND_UNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Secqtyform).HasColumnName("SECQTYFORM");

                entity.Property(e => e.Secquantity)
                    .HasColumnName("SECQUANTITY")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Secrate)
                    .HasColumnName("SECRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Secrateform).HasColumnName("SECRATEFORM");

                entity.Property(e => e.Secunitform).HasColumnName("SECUNITFORM");

                entity.Property(e => e.Shipcost)
                    .HasColumnName("SHIPCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Shiprate)
                    .HasColumnName("SHIPRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(255);

                entity.Property(e => e.Subcost)
                    .HasColumnName("SUBCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Subquoterate)
                    .HasColumnName("SUBQUOTERATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Subrate)
                    .HasColumnName("SUBRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Subtotalform).HasColumnName("SUBTOTALFORM");

                entity.Property(e => e.Surfacetype)
                    .HasColumnName("SURFACETYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Totalcost)
                    .HasColumnName("TOTALCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Totalcostform).HasColumnName("TOTALCOSTFORM");

                entity.Property(e => e.Ttlform).HasColumnName("TTLFORM");

                entity.Property(e => e.Umhform).HasColumnName("UMHFORM");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Unitmhours)
                    .HasColumnName("UNITMHOURS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.UnitsDiv)
                    .HasColumnName("UNITS_DIV")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Unitsdivform).HasColumnName("UNITSDIVFORM");

                entity.Property(e => e.Vars).HasColumnName("VARS");

                entity.Property(e => e.Wbs2code)
                    .HasColumnName("WBS2CODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Wbs2form).HasColumnName("WBS2FORM");

                entity.Property(e => e.Wbscode)
                    .HasColumnName("WBSCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Wbsform).HasColumnName("WBSFORM");

                entity.Property(e => e.Wrslkp)
                    .HasColumnName("WRSLKP")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Paramitem)
                    .WithMany(p => p.Boqitem)
                    .HasForeignKey(d => d.Paramitemid)
                    .HasConstraintName("FK2EC202B7B8FEF034");
            });

            modelBuilder.Entity<BoqitemAssembly>(entity =>
            {
                entity.ToTable("BOQITEM_ASSEMBLY");

                entity.HasIndex(e => e.Assemblyid)
                    .HasName("IDX_ASSEMBLY");

                entity.HasIndex(e => e.Boqitemid)
                    .HasName("IDX_BOQITEM");

                entity.HasIndex(e => e.Paramitemid)
                    .HasName("IDX_PARAMITEM");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Boqitemassemblyid).HasColumnName("BOQITEMASSEMBLYID");

                entity.Property(e => e.Assemblyid).HasColumnName("ASSEMBLYID");

                entity.Property(e => e.Boqitemid).HasColumnName("BOQITEMID");

                entity.Property(e => e.Concost)
                    .HasColumnName("CONCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Costcenter)
                    .HasColumnName("COSTCENTER")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Equcost)
                    .HasColumnName("EQUCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor3)
                    .HasColumnName("FACTOR3")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fconrate)
                    .HasColumnName("FCONRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fequrate)
                    .HasColumnName("FEQURATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Ffabrate)
                    .HasColumnName("FFABRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Finalfixedcost)
                    .HasColumnName("FINALFIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fixedcost)
                    .HasColumnName("FIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Flabrate)
                    .HasColumnName("FLABRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fmatrate)
                    .HasColumnName("FMATRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fshprate)
                    .HasColumnName("FSHPRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fsubrate)
                    .HasColumnName("FSUBRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Labcost)
                    .HasColumnName("LABCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.LastUpdate).HasColumnName("LAST_UPDATE");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255);

                entity.Property(e => e.Mattotcost)
                    .HasColumnName("MATTOTCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Paramitemid).HasColumnName("PARAMITEMID");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.PvVars).HasColumnName("PV_VARS");

                entity.Property(e => e.Qtypuformstate).HasColumnName("QTYPUFORMSTATE");

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qtypunitform).HasColumnName("QTYPUNITFORM");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Subcost)
                    .HasColumnName("SUBCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Totalcost)
                    .HasColumnName("TOTALCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Totalunits)
                    .HasColumnName("TOTALUNITS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Usertotalunits).HasColumnName("USERTOTALUNITS");

                entity.Property(e => e.Variablecost)
                    .HasColumnName("VARIABLECOST")
                    .HasColumnType("numeric(30, 10)");

                entity.HasOne(d => d.Assembly)
                    .WithMany(p => p.BoqitemAssembly)
                    .HasForeignKey(d => d.Assemblyid)
                    .HasConstraintName("FK9CA97A6E14030E1E");

                entity.HasOne(d => d.Boqitem)
                    .WithMany(p => p.BoqitemAssembly)
                    .HasForeignKey(d => d.Boqitemid)
                    .HasConstraintName("FK9CA97A6E89F3BCA6");

                entity.HasOne(d => d.Paramitem)
                    .WithMany(p => p.BoqitemAssembly)
                    .HasForeignKey(d => d.Paramitemid)
                    .HasConstraintName("FK9CA97A6EB8FEF034");
            });

            modelBuilder.Entity<BoqitemCondition>(entity =>
            {
                entity.ToTable("BOQITEM_CONDITION");

                entity.HasIndex(e => e.Boqitemid)
                    .HasName("IDX_BOQITEM");

                entity.HasIndex(e => e.Conditionid)
                    .HasName("IDX_CONDITION");

                entity.HasIndex(e => e.Paramitemid)
                    .HasName("IDX_PARAMITEM");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Boqitemconditionid).HasColumnName("BOQITEMCONDITIONID");

                entity.Property(e => e.Boqitemid).HasColumnName("BOQITEMID");

                entity.Property(e => e.Conditionid).HasColumnName("CONDITIONID");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fqty)
                    .HasColumnName("FQTY")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Funit)
                    .HasColumnName("FUNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.LastUpdate).HasColumnName("LAST_UPDATE");

                entity.Property(e => e.Overqty)
                    .HasColumnName("OVERQTY")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Overunit)
                    .HasColumnName("OVERUNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Paramitemid).HasColumnName("PARAMITEMID");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Selqty)
                    .HasColumnName("SELQTY")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Selqtyname)
                    .HasColumnName("SELQTYNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Selunit)
                    .HasColumnName("SELUNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Sumup)
                    .HasColumnName("SUMUP")
                    .HasColumnType("numeric(30, 10)");

                entity.HasOne(d => d.Boqitem)
                    .WithMany(p => p.BoqitemCondition)
                    .HasForeignKey(d => d.Boqitemid)
                    .HasConstraintName("FK7725C17389F3BCA6");

                entity.HasOne(d => d.Condition)
                    .WithMany(p => p.BoqitemCondition)
                    .HasForeignKey(d => d.Conditionid)
                    .HasConstraintName("FK7725C1733A120306");

                entity.HasOne(d => d.Paramitem)
                    .WithMany(p => p.BoqitemCondition)
                    .HasForeignKey(d => d.Paramitemid)
                    .HasConstraintName("FK7725C173B8FEF034");
            });

            modelBuilder.Entity<BoqitemConsumable>(entity =>
            {
                entity.ToTable("BOQITEM_CONSUMABLE");

                entity.HasIndex(e => e.Boqitemid)
                    .HasName("IDX_BOQITEM");

                entity.HasIndex(e => e.Consumableid)
                    .HasName("IDX_CONSUMABLE");

                entity.HasIndex(e => e.Paramitemid)
                    .HasName("IDX_PARAMITEM");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Boqitemconsumableid).HasColumnName("BOQITEMCONSUMABLEID");

                entity.Property(e => e.Boqitemid).HasColumnName("BOQITEMID");

                entity.Property(e => e.Consumableid).HasColumnName("CONSUMABLEID");

                entity.Property(e => e.Costcenter)
                    .HasColumnName("COSTCENTER")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Divider)
                    .HasColumnName("DIVIDER")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Finalfixedcost)
                    .HasColumnName("FINALFIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fixedcost)
                    .HasColumnName("FIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.LastUpdate).HasColumnName("LAST_UPDATE");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255);

                entity.Property(e => e.Paramitemid).HasColumnName("PARAMITEMID");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.PvVars).HasColumnName("PV_VARS");

                entity.Property(e => e.Qtypuformstate).HasColumnName("QTYPUFORMSTATE");

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qtypunitform).HasColumnName("QTYPUNITFORM");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Totalcost)
                    .HasColumnName("TOTALCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Totalunits)
                    .HasColumnName("TOTALUNITS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Usertotalunits).HasColumnName("USERTOTALUNITS");

                entity.Property(e => e.Variablecost)
                    .HasColumnName("VARIABLECOST")
                    .HasColumnType("numeric(30, 10)");

                entity.HasOne(d => d.Boqitem)
                    .WithMany(p => p.BoqitemConsumable)
                    .HasForeignKey(d => d.Boqitemid)
                    .HasConstraintName("FK9B2394EB89F3BCA6");

                entity.HasOne(d => d.Consumable)
                    .WithMany(p => p.BoqitemConsumable)
                    .HasForeignKey(d => d.Consumableid)
                    .HasConstraintName("FK9B2394EBFFA537BE");

                entity.HasOne(d => d.Paramitem)
                    .WithMany(p => p.BoqitemConsumable)
                    .HasForeignKey(d => d.Paramitemid)
                    .HasConstraintName("FK9B2394EBB8FEF034");
            });

            modelBuilder.Entity<BoqitemEquipment>(entity =>
            {
                entity.ToTable("BOQITEM_EQUIPMENT");

                entity.HasIndex(e => e.Boqitemid)
                    .HasName("IDX_BOQITEM");

                entity.HasIndex(e => e.Equipmentid)
                    .HasName("IDX_EQUIPMENT");

                entity.HasIndex(e => e.Paramitemid)
                    .HasName("IDX_PARAMITEM");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Boqitemequipmentid).HasColumnName("BOQITEMEQUIPMENTID");

                entity.Property(e => e.Boqitemid).HasColumnName("BOQITEMID");

                entity.Property(e => e.Costcenter)
                    .HasColumnName("COSTCENTER")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Energyprice)
                    .HasColumnName("ENERGYPRICE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Equipmentid).HasColumnName("EQUIPMENTID");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor3)
                    .HasColumnName("FACTOR3")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fdeprate)
                    .HasColumnName("FDEPRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Finalfixedcost)
                    .HasColumnName("FINALFIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fixedcost)
                    .HasColumnName("FIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fuelrate)
                    .HasColumnName("FUELRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.LastUpdate).HasColumnName("LAST_UPDATE");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255);

                entity.Property(e => e.Paramitemid).HasColumnName("PARAMITEMID");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.PvVars).HasColumnName("PV_VARS");

                entity.Property(e => e.Qtypuformstate).HasColumnName("QTYPUFORMSTATE");

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qtypunitform).HasColumnName("QTYPUNITFORM");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Totalcost)
                    .HasColumnName("TOTALCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Totalunits)
                    .HasColumnName("TOTALUNITS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Unithours)
                    .HasColumnName("UNITHOURS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Usertotalunits).HasColumnName("USERTOTALUNITS");

                entity.Property(e => e.Variablecost)
                    .HasColumnName("VARIABLECOST")
                    .HasColumnType("numeric(30, 10)");

                entity.HasOne(d => d.Boqitem)
                    .WithMany(p => p.BoqitemEquipment)
                    .HasForeignKey(d => d.Boqitemid)
                    .HasConstraintName("FKEAA439E689F3BCA6");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.BoqitemEquipment)
                    .HasForeignKey(d => d.Equipmentid)
                    .HasConstraintName("FKEAA439E6B2878194");

                entity.HasOne(d => d.Paramitem)
                    .WithMany(p => p.BoqitemEquipment)
                    .HasForeignKey(d => d.Paramitemid)
                    .HasConstraintName("FKEAA439E6B8FEF034");
            });

            modelBuilder.Entity<BoqitemLabor>(entity =>
            {
                entity.ToTable("BOQITEM_LABOR");

                entity.HasIndex(e => e.Boqitemid)
                    .HasName("IDX_BOQITEM");

                entity.HasIndex(e => e.Laborid)
                    .HasName("IDX_LABOR");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Boqitemlaborid).HasColumnName("BOQITEMLABORID");

                entity.Property(e => e.Boqitemid).HasColumnName("BOQITEMID");

                entity.Property(e => e.Costcenter)
                    .HasColumnName("COSTCENTER")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor3)
                    .HasColumnName("FACTOR3")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Finalfixedcost)
                    .HasColumnName("FINALFIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fixedcost)
                    .HasColumnName("FIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Laborid).HasColumnName("LABORID");

                entity.Property(e => e.LastUpdate).HasColumnName("LAST_UPDATE");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255);

                entity.Property(e => e.Paramitemid).HasColumnName("PARAMITEMID");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.PvVars).HasColumnName("PV_VARS");

                entity.Property(e => e.Qtypuformstate).HasColumnName("QTYPUFORMSTATE");

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qtypunitform).HasColumnName("QTYPUNITFORM");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Totalcost)
                    .HasColumnName("TOTALCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Totalunits)
                    .HasColumnName("TOTALUNITS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Unithours)
                    .HasColumnName("UNITHOURS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Usertotalunits).HasColumnName("USERTOTALUNITS");

                entity.Property(e => e.Variablecost)
                    .HasColumnName("VARIABLECOST")
                    .HasColumnType("numeric(30, 10)");

                entity.HasOne(d => d.Boqitem)
                    .WithMany(p => p.BoqitemLabor)
                    .HasForeignKey(d => d.Boqitemid)
                    .HasConstraintName("FKD8B6C88889F3BCA6");

                entity.HasOne(d => d.Labor)
                    .WithMany(p => p.BoqitemLabor)
                    .HasForeignKey(d => d.Laborid)
                    .HasConstraintName("FKD8B6C8885C7E33D4");

                entity.HasOne(d => d.Paramitem)
                    .WithMany(p => p.BoqitemLabor)
                    .HasForeignKey(d => d.Paramitemid)
                    .HasConstraintName("FKD8B6C888B8FEF034");
            });

            modelBuilder.Entity<BoqitemMaterial>(entity =>
            {
                entity.ToTable("BOQITEM_MATERIAL");

                entity.HasIndex(e => e.Boqitemid)
                    .HasName("IDX_BOQITEM");

                entity.HasIndex(e => e.Materialid)
                    .HasName("IDX_MATERIAL");

                entity.HasIndex(e => e.Paramitemid)
                    .HasName("IDX_PARAMITEM");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.HasIndex(e => e.Quoteitemid)
                    .HasName("IDX_QUOTEITEM");

                entity.Property(e => e.Boqitemmaterialid).HasColumnName("BOQITEMMATERIALID");

                entity.Property(e => e.Boqitemid).HasColumnName("BOQITEMID");

                entity.Property(e => e.Costcenter)
                    .HasColumnName("COSTCENTER")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Divider)
                    .HasColumnName("DIVIDER")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Escalation)
                    .HasColumnName("ESCALATION")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Finalfixedcost)
                    .HasColumnName("FINALFIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fixedcost)
                    .HasColumnName("FIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.LastUpdate).HasColumnName("LAST_UPDATE");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255);

                entity.Property(e => e.Materialid).HasColumnName("MATERIALID");

                entity.Property(e => e.Paramitemid).HasColumnName("PARAMITEMID");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.PvVars).HasColumnName("PV_VARS");

                entity.Property(e => e.Qtypuformstate).HasColumnName("QTYPUFORMSTATE");

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qtypunitform).HasColumnName("QTYPUNITFORM");

                entity.Property(e => e.Quoteitemid).HasColumnName("QUOTEITEMID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Totalcost)
                    .HasColumnName("TOTALCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Totalunits)
                    .HasColumnName("TOTALUNITS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Usertotalunits).HasColumnName("USERTOTALUNITS");

                entity.Property(e => e.Variablecost)
                    .HasColumnName("VARIABLECOST")
                    .HasColumnType("numeric(30, 10)");

                entity.HasOne(d => d.Boqitem)
                    .WithMany(p => p.BoqitemMaterial)
                    .HasForeignKey(d => d.Boqitemid)
                    .HasConstraintName("FKC4BEA1AF89F3BCA6");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.BoqitemMaterial)
                    .HasForeignKey(d => d.Materialid)
                    .HasConstraintName("FKC4BEA1AF2461A27E");

                entity.HasOne(d => d.Paramitem)
                    .WithMany(p => p.BoqitemMaterial)
                    .HasForeignKey(d => d.Paramitemid)
                    .HasConstraintName("FKC4BEA1AFB8FEF034");

                entity.HasOne(d => d.Quoteitem)
                    .WithMany(p => p.BoqitemMaterial)
                    .HasForeignKey(d => d.Quoteitemid)
                    .HasConstraintName("FKC4BEA1AF37613E66");
            });

            modelBuilder.Entity<BoqitemSubcontractor>(entity =>
            {
                entity.ToTable("BOQITEM_SUBCONTRACTOR");

                entity.HasIndex(e => e.Boqitemid)
                    .HasName("IDX_BOQITEM");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.HasIndex(e => e.Subcontractorid)
                    .HasName("IDX_SUBCONTRACTOR");

                entity.Property(e => e.Boqitemsubcontractorid).HasColumnName("BOQITEMSUBCONTRACTORID");

                entity.Property(e => e.Boqitemid).HasColumnName("BOQITEMID");

                entity.Property(e => e.Costcenter)
                    .HasColumnName("COSTCENTER")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor3)
                    .HasColumnName("FACTOR3")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Finalfixedcost)
                    .HasColumnName("FINALFIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fixedcost)
                    .HasColumnName("FIXEDCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.LastUpdate).HasColumnName("LAST_UPDATE");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255);

                entity.Property(e => e.Paramitemid).HasColumnName("PARAMITEMID");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.PvVars).HasColumnName("PV_VARS");

                entity.Property(e => e.Qtypuformstate).HasColumnName("QTYPUFORMSTATE");

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qtypunitform).HasColumnName("QTYPUNITFORM");

                entity.Property(e => e.Quoteitemid).HasColumnName("QUOTEITEMID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Subcontractorid).HasColumnName("SUBCONTRACTORID");

                entity.Property(e => e.Totalcost)
                    .HasColumnName("TOTALCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Totalunits)
                    .HasColumnName("TOTALUNITS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Usertotalunits).HasColumnName("USERTOTALUNITS");

                entity.Property(e => e.Variablecost)
                    .HasColumnName("VARIABLECOST")
                    .HasColumnType("numeric(30, 10)");

                entity.HasOne(d => d.Boqitem)
                    .WithMany(p => p.BoqitemSubcontractor)
                    .HasForeignKey(d => d.Boqitemid)
                    .HasConstraintName("FK7EC9710D89F3BCA6");

                entity.HasOne(d => d.Paramitem)
                    .WithMany(p => p.BoqitemSubcontractor)
                    .HasForeignKey(d => d.Paramitemid)
                    .HasConstraintName("FK7EC9710DB8FEF034");

                entity.HasOne(d => d.Quoteitem)
                    .WithMany(p => p.BoqitemSubcontractor)
                    .HasForeignKey(d => d.Quoteitemid)
                    .HasConstraintName("FK7EC9710D37613E66");

                entity.HasOne(d => d.Subcontractor)
                    .WithMany(p => p.BoqitemSubcontractor)
                    .HasForeignKey(d => d.Subcontractorid)
                    .HasConstraintName("FK7EC9710D7C0276B4");
            });

            modelBuilder.Entity<Boqitemmetadata>(entity =>
            {
                entity.ToTable("BOQITEMMETADATA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Columnname)
                    .HasColumnName("COLUMNNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Fieldkey)
                    .HasColumnName("FIELDKEY")
                    .HasMaxLength(255);

                entity.Property(e => e.Fieldname)
                    .HasColumnName("FIELDNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Initialdisplayname)
                    .HasColumnName("INITIALDISPLAYNAME")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Cndon>(entity =>
            {
                entity.HasKey(e => e.Conditionid)
                    .HasName("PK__CNDON__AF05447C9B23AD4C");

                entity.ToTable("CNDON");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Conditionid).HasColumnName("CONDITIONID");

                entity.Property(e => e.Bidno).HasColumnName("BIDNO");

                entity.Property(e => e.Bimmaterial).HasColumnName("BIMMATERIAL");

                entity.Property(e => e.Bimtype)
                    .HasColumnName("BIMTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Building)
                    .HasColumnName("BUILDING")
                    .HasMaxLength(255);

                entity.Property(e => e.Cndid).HasColumnName("CNDID");

                entity.Property(e => e.Cndno).HasColumnName("CNDNO");

                entity.Property(e => e.Cndtype)
                    .HasColumnName("CNDTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Dbname)
                    .HasColumnName("DBNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Fctstate).HasColumnName("FCTSTATE");

                entity.Property(e => e.Formula1)
                    .HasColumnName("FORMULA1")
                    .HasMaxLength(255);

                entity.Property(e => e.Formula2)
                    .HasColumnName("FORMULA2")
                    .HasMaxLength(255);

                entity.Property(e => e.Formula3)
                    .HasColumnName("FORMULA3")
                    .HasMaxLength(255);

                entity.Property(e => e.Formulaf).HasColumnName("FORMULAF");

                entity.Property(e => e.Globalid)
                    .HasColumnName("GLOBALID")
                    .HasMaxLength(255);

                entity.Property(e => e.Host)
                    .HasColumnName("HOST")
                    .HasMaxLength(255);

                entity.Property(e => e.Layer)
                    .HasColumnName("LAYER")
                    .HasMaxLength(255);

                entity.Property(e => e.Location)
                    .HasColumnName("LOCATION")
                    .HasMaxLength(255);

                entity.Property(e => e.Operand).HasColumnName("OPERAND");

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(255);

                entity.Property(e => e.Pickdata).HasColumnName("PICKDATA");

                entity.Property(e => e.Picktype).HasColumnName("PICKTYPE");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Qty1)
                    .HasColumnName("QTY1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qty1name)
                    .HasColumnName("QTY1NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Qty2)
                    .HasColumnName("QTY2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qty2name)
                    .HasColumnName("QTY2NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Qty3)
                    .HasColumnName("QTY3")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qty3name)
                    .HasColumnName("QTY3NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Qtyf)
                    .HasColumnName("QTYF")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qtyfname)
                    .HasColumnName("QTYFNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Storey)
                    .HasColumnName("STOREY")
                    .HasMaxLength(255);

                entity.Property(e => e.Takeofftype)
                    .HasColumnName("TAKEOFFTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Unit1)
                    .HasColumnName("UNIT1")
                    .HasMaxLength(255);

                entity.Property(e => e.Unit2)
                    .HasColumnName("UNIT2")
                    .HasMaxLength(255);

                entity.Property(e => e.Unit3)
                    .HasColumnName("UNIT3")
                    .HasMaxLength(255);

                entity.Property(e => e.Unitf)
                    .HasColumnName("UNITF")
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .HasColumnName("USERNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Virt).HasColumnName("VIRT");
            });

            modelBuilder.Entity<Cnmhistory>(entity =>
            {
                entity.ToTable("CNMHISTORY");

                entity.HasIndex(e => e.Consumableid)
                    .HasName("IDX_CONSUMABLE");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Basetableid)
                    .HasColumnName("BASETABLEID")
                    .HasMaxLength(255);

                entity.Property(e => e.Consumableid).HasColumnName("CONSUMABLEID");

                entity.Property(e => e.Preddate).HasColumnName("PREDDATE");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Rsrc).HasColumnName("RSRC");

                entity.HasOne(d => d.Consumable)
                    .WithMany(p => p.Cnmhistory)
                    .HasForeignKey(d => d.Consumableid)
                    .HasConstraintName("FKBCD85CF2FFA537BE");
            });

            modelBuilder.Entity<Conceptuals>(entity =>
            {
                entity.HasKey(e => e.Conceptualid)
                    .HasName("PK__CONCEPTU__46D7EFE56EC083AF");

                entity.ToTable("CONCEPTUALS");

                entity.HasIndex(e => e.Paramoutputid)
                    .HasName("IDX_PARAMOUTPUT");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Conceptualid).HasColumnName("CONCEPTUALID");

                entity.Property(e => e.Cc01eq).HasColumnName("CC01EQ");

                entity.Property(e => e.Cc02eq).HasColumnName("CC02EQ");

                entity.Property(e => e.Cc03eq).HasColumnName("CC03EQ");

                entity.Property(e => e.Cc04eq).HasColumnName("CC04EQ");

                entity.Property(e => e.Cc05eq).HasColumnName("CC05EQ");

                entity.Property(e => e.Cc06eq).HasColumnName("CC06EQ");

                entity.Property(e => e.Cc07eq).HasColumnName("CC07EQ");

                entity.Property(e => e.Cc08eq).HasColumnName("CC08EQ");

                entity.Property(e => e.Cc09eq).HasColumnName("CC09EQ");

                entity.Property(e => e.Cc10eq).HasColumnName("CC10EQ");

                entity.Property(e => e.Cc11eq).HasColumnName("CC11EQ");

                entity.Property(e => e.Cc12eq).HasColumnName("CC12EQ");

                entity.Property(e => e.Cc13eq).HasColumnName("CC13EQ");

                entity.Property(e => e.Cc14eq).HasColumnName("CC14EQ");

                entity.Property(e => e.Cc15eq).HasColumnName("CC15EQ");

                entity.Property(e => e.Cc16eq).HasColumnName("CC16EQ");

                entity.Property(e => e.Cc17eq).HasColumnName("CC17EQ");

                entity.Property(e => e.Cc18eq).HasColumnName("CC18EQ");

                entity.Property(e => e.Cc19eq).HasColumnName("CC19EQ");

                entity.Property(e => e.Cc20eq).HasColumnName("CC20EQ");

                entity.Property(e => e.Conrate).HasColumnName("CONRATE");

                entity.Property(e => e.Cr01eq).HasColumnName("CR01EQ");

                entity.Property(e => e.Cr02eq).HasColumnName("CR02EQ");

                entity.Property(e => e.Cr03eq).HasColumnName("CR03EQ");

                entity.Property(e => e.Cr04eq).HasColumnName("CR04EQ");

                entity.Property(e => e.Cr05eq).HasColumnName("CR05EQ");

                entity.Property(e => e.Cr06eq).HasColumnName("CR06EQ");

                entity.Property(e => e.Cr07eq).HasColumnName("CR07EQ");

                entity.Property(e => e.Cr08eq).HasColumnName("CR08EQ");

                entity.Property(e => e.Cr09eq).HasColumnName("CR09EQ");

                entity.Property(e => e.Cr10eq).HasColumnName("CR10EQ");

                entity.Property(e => e.Cr11eq).HasColumnName("CR11EQ");

                entity.Property(e => e.Cr12eq).HasColumnName("CR12EQ");

                entity.Property(e => e.Cr13eq).HasColumnName("CR13EQ");

                entity.Property(e => e.Cr14eq).HasColumnName("CR14EQ");

                entity.Property(e => e.Cr15eq).HasColumnName("CR15EQ");

                entity.Property(e => e.Cr16eq).HasColumnName("CR16EQ");

                entity.Property(e => e.Cr17eq).HasColumnName("CR17EQ");

                entity.Property(e => e.Cr18eq).HasColumnName("CR18EQ");

                entity.Property(e => e.Cr19eq).HasColumnName("CR19EQ");

                entity.Property(e => e.Cr20eq).HasColumnName("CR20EQ");

                entity.Property(e => e.Crewfacs)
                    .HasColumnName("CREWFACS")
                    .HasMaxLength(255);

                entity.Property(e => e.Crews).HasColumnName("CREWS");

                entity.Property(e => e.Ct01eq).HasColumnName("CT01EQ");

                entity.Property(e => e.Ct02eq).HasColumnName("CT02EQ");

                entity.Property(e => e.Ct03eq).HasColumnName("CT03EQ");

                entity.Property(e => e.Ct04eq).HasColumnName("CT04EQ");

                entity.Property(e => e.Ct05eq).HasColumnName("CT05EQ");

                entity.Property(e => e.Ct06eq).HasColumnName("CT06EQ");

                entity.Property(e => e.Ct07eq).HasColumnName("CT07EQ");

                entity.Property(e => e.Ct08eq).HasColumnName("CT08EQ");

                entity.Property(e => e.Ct09eq).HasColumnName("CT09EQ");

                entity.Property(e => e.Ct10eq).HasColumnName("CT10EQ");

                entity.Property(e => e.Ct11eq).HasColumnName("CT11EQ");

                entity.Property(e => e.Ct12eq).HasColumnName("CT12EQ");

                entity.Property(e => e.Ct13eq).HasColumnName("CT13EQ");

                entity.Property(e => e.Ct14eq).HasColumnName("CT14EQ");

                entity.Property(e => e.Ct15eq).HasColumnName("CT15EQ");

                entity.Property(e => e.Ct16eq).HasColumnName("CT16EQ");

                entity.Property(e => e.Ct17eq).HasColumnName("CT17EQ");

                entity.Property(e => e.Ct18eq).HasColumnName("CT18EQ");

                entity.Property(e => e.Ct19eq).HasColumnName("CT19EQ");

                entity.Property(e => e.Ct20eq).HasColumnName("CT20EQ");

                entity.Property(e => e.Ct21eq).HasColumnName("CT21EQ");

                entity.Property(e => e.Ct22eq).HasColumnName("CT22EQ");

                entity.Property(e => e.Ct23eq).HasColumnName("CT23EQ");

                entity.Property(e => e.Ct24eq).HasColumnName("CT24EQ");

                entity.Property(e => e.Ct25eq).HasColumnName("CT25EQ");

                entity.Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasMaxLength(255);

                entity.Property(e => e.Descconcat).HasColumnName("DESCCONCAT");

                entity.Property(e => e.Dtunit)
                    .HasColumnName("DTUNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Duty).HasColumnName("DUTY");

                entity.Property(e => e.Equdeprate).HasColumnName("EQUDEPRATE");

                entity.Property(e => e.Equfucrate).HasColumnName("EQUFUCRATE");

                entity.Property(e => e.Equfulrate).HasColumnName("EQUFULRATE");

                entity.Property(e => e.Equfutrate).HasColumnName("EQUFUTRATE");

                entity.Property(e => e.Equlubrate).HasColumnName("EQULUBRATE");

                entity.Property(e => e.Equresrate).HasColumnName("EQURESRATE");

                entity.Property(e => e.Equsprrate).HasColumnName("EQUSPRRATE");

                entity.Property(e => e.Equtrsrate).HasColumnName("EQUTRSRATE");

                entity.Property(e => e.Exectype).HasColumnName("EXECTYPE");

                entity.Property(e => e.Extracode1).HasColumnName("EXTRACODE1");

                entity.Property(e => e.Extracode2).HasColumnName("EXTRACODE2");

                entity.Property(e => e.Extracode3).HasColumnName("EXTRACODE3");

                entity.Property(e => e.Extracode4).HasColumnName("EXTRACODE4");

                entity.Property(e => e.Extracode5).HasColumnName("EXTRACODE5");

                entity.Property(e => e.Extracode6).HasColumnName("EXTRACODE6");

                entity.Property(e => e.Extracode7).HasColumnName("EXTRACODE7");

                entity.Property(e => e.Gekcode).HasColumnName("GEKCODE");

                entity.Property(e => e.Groupcode).HasColumnName("GROUPCODE");

                entity.Property(e => e.Labika).HasColumnName("LABIKA");

                entity.Property(e => e.Labrate).HasColumnName("LABRATE");

                entity.Property(e => e.Massflow).HasColumnName("MASSFLOW");

                entity.Property(e => e.Matfab).HasColumnName("MATFAB");

                entity.Property(e => e.Matrate).HasColumnName("MATRATE");

                entity.Property(e => e.Matship).HasColumnName("MATSHIP");

                entity.Property(e => e.Mfunit)
                    .HasColumnName("MFUNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Notesconcat).HasColumnName("NOTESCONCAT");

                entity.Property(e => e.Operpress).HasColumnName("OPERPRESS");

                entity.Property(e => e.Opertemp).HasColumnName("OPERTEMP");

                entity.Property(e => e.Opunit)
                    .HasColumnName("OPUNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Otunit)
                    .HasColumnName("OTUNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Paramoutputid).HasColumnName("PARAMOUTPUTID");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Rawmat1)
                    .HasColumnName("RAWMAT1")
                    .HasMaxLength(255);

                entity.Property(e => e.Rawmat2)
                    .HasColumnName("RAWMAT2")
                    .HasMaxLength(255);

                entity.Property(e => e.Rawmat3)
                    .HasColumnName("RAWMAT3")
                    .HasMaxLength(255);

                entity.Property(e => e.Rawmat4)
                    .HasColumnName("RAWMAT4")
                    .HasMaxLength(255);

                entity.Property(e => e.Rawmat5)
                    .HasColumnName("RAWMAT5")
                    .HasMaxLength(255);

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Refdate).HasColumnName("REFDATE");

                entity.Property(e => e.Rel1)
                    .HasColumnName("REL1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rel2)
                    .HasColumnName("REL2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rel3)
                    .HasColumnName("REL3")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rel4)
                    .HasColumnName("REL4")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rel5)
                    .HasColumnName("REL5")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Subika).HasColumnName("SUBIKA");

                entity.Property(e => e.Subrate).HasColumnName("SUBRATE");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255);

                entity.Property(e => e.Titleconcat).HasColumnName("TITLECONCAT");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Vfunit)
                    .HasColumnName("VFUNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Volflow).HasColumnName("VOLFLOW");

                entity.Property(e => e.Weightrate).HasColumnName("WEIGHTRATE");

                entity.Property(e => e.Weightunit)
                    .HasColumnName("WEIGHTUNIT")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Paramoutput)
                    .WithMany(p => p.Conceptuals)
                    .HasForeignKey(d => d.Paramoutputid)
                    .HasConstraintName("FK86A6435B62282EA1");
            });

            modelBuilder.Entity<Consumable>(entity =>
            {
                entity.ToTable("CONSUMABLE");

                entity.HasIndex(e => e.Databaseid)
                    .HasName("IDX_MDBID");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Consumableid).HasColumnName("CONSUMABLEID");

                entity.Property(e => e.Accrights)
                    .HasColumnName("ACCRIGHTS")
                    .HasMaxLength(255);

                entity.Property(e => e.Burate)
                    .HasColumnName("BURATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Conceptual).HasColumnName("CONCEPTUAL");

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Createdate).HasColumnName("CREATEDATE");

                entity.Property(e => e.Createuser)
                    .HasColumnName("CREATEUSER")
                    .HasMaxLength(255);

                entity.Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasMaxLength(255);

                entity.Property(e => e.Databasecreationdate).HasColumnName("DATABASECREATIONDATE");

                entity.Property(e => e.Databaseid).HasColumnName("DATABASEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode1)
                    .HasColumnName("EXTRACODE1")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode10)
                    .HasColumnName("EXTRACODE10")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode2)
                    .HasColumnName("EXTRACODE2")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode3)
                    .HasColumnName("EXTRACODE3")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode4)
                    .HasColumnName("EXTRACODE4")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode5)
                    .HasColumnName("EXTRACODE5")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode6)
                    .HasColumnName("EXTRACODE6")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode7)
                    .HasColumnName("EXTRACODE7")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode8)
                    .HasColumnName("EXTRACODE8")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode9)
                    .HasColumnName("EXTRACODE9")
                    .HasMaxLength(255);

                entity.Property(e => e.Gekcode)
                    .HasColumnName("GEKCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Keyw).HasColumnName("KEYW");

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255);

                entity.Property(e => e.Overtype).HasColumnName("OVERTYPE");

                entity.Property(e => e.Predicted).HasColumnName("PREDICTED");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Project)
                    .HasColumnName("PROJECT")
                    .HasMaxLength(255);

                entity.Property(e => e.Qty)
                    .HasColumnName("QTY")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Rescode)
                    .HasColumnName("RESCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Stateprovince)
                    .HasColumnName("STATEPROVINCE")
                    .HasMaxLength(255);

                entity.Property(e => e.Tchtype).HasColumnName("TCHTYPE");

                entity.Property(e => e.Tcolor).HasColumnName("TCOLOR");

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Trdate).HasColumnName("TRDATE");

                entity.Property(e => e.Tregtype).HasColumnName("TREGTYPE");

                entity.Property(e => e.Trids).HasColumnName("TRIDS");

                entity.Property(e => e.Tunit)
                    .HasColumnName("TUNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Tval)
                    .HasColumnName("TVAL")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Virtual).HasColumnName("VIRTUAL");
            });

            modelBuilder.Entity<Equhistory>(entity =>
            {
                entity.ToTable("EQUHISTORY");

                entity.HasIndex(e => e.Equipmentid)
                    .HasName("IDX_EQUIPMENT");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Basetableid)
                    .HasColumnName("BASETABLEID")
                    .HasMaxLength(255);

                entity.Property(e => e.Equipmentid).HasColumnName("EQUIPMENTID");

                entity.Property(e => e.Preddate).HasColumnName("PREDDATE");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Rsrc).HasColumnName("RSRC");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.Equhistory)
                    .HasForeignKey(d => d.Equipmentid)
                    .HasConstraintName("FKA141F32BB2878194");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.ToTable("EQUIPMENT");

                entity.HasIndex(e => e.Databaseid)
                    .HasName("IDX_MDBID");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Equipmentid).HasColumnName("EQUIPMENTID");

                entity.Property(e => e.Accrights)
                    .HasColumnName("ACCRIGHTS")
                    .HasMaxLength(255);

                entity.Property(e => e.Burate)
                    .HasColumnName("BURATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Conceptual).HasColumnName("CONCEPTUAL");

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Createdate).HasColumnName("CREATEDATE");

                entity.Property(e => e.Createuser)
                    .HasColumnName("CREATEUSER")
                    .HasMaxLength(255);

                entity.Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasMaxLength(255);

                entity.Property(e => e.Databasecreationdate).HasColumnName("DATABASECREATIONDATE");

                entity.Property(e => e.Databaseid).HasColumnName("DATABASEID");

                entity.Property(e => e.DeprecationCalcMethod).HasColumnName("DEPRECATION_CALC_METHOD");

                entity.Property(e => e.DepreciationYears)
                    .HasColumnName("DEPRECIATION_YEARS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Depreciationrate)
                    .HasColumnName("DEPRECIATIONRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode1)
                    .HasColumnName("EXTRACODE1")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode10)
                    .HasColumnName("EXTRACODE10")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode2)
                    .HasColumnName("EXTRACODE2")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode3)
                    .HasColumnName("EXTRACODE3")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode4)
                    .HasColumnName("EXTRACODE4")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode5)
                    .HasColumnName("EXTRACODE5")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode6)
                    .HasColumnName("EXTRACODE6")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode7)
                    .HasColumnName("EXTRACODE7")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode8)
                    .HasColumnName("EXTRACODE8")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode9)
                    .HasColumnName("EXTRACODE9")
                    .HasMaxLength(255);

                entity.Property(e => e.Fuelconsumption)
                    .HasColumnName("FUELCONSUMPTION")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fuelrate)
                    .HasColumnName("FUELRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Fueltype)
                    .HasColumnName("FUELTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Gekcode)
                    .HasColumnName("GEKCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.InitAquasitionPrice)
                    .HasColumnName("INIT_AQUASITION_PRICE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.InterestRate)
                    .HasColumnName("INTEREST_RATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Keyw).HasColumnName("KEYW");

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Lubricatesrate)
                    .HasColumnName("LUBRICATESRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Make)
                    .HasColumnName("MAKE")
                    .HasMaxLength(255);

                entity.Property(e => e.Model)
                    .HasColumnName("MODEL")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255);

                entity.Property(e => e.OccupationHoursPerMonth)
                    .HasColumnName("OCCUPATION_HOURS_PER_MONTH")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.OccupationalFactor)
                    .HasColumnName("OCCUPATIONAL_FACTOR")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Overtype).HasColumnName("OVERTYPE");

                entity.Property(e => e.Predicted).HasColumnName("PREDICTED");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Rescode)
                    .HasColumnName("RESCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Reservationrate)
                    .HasColumnName("RESERVATIONRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.SalvageValue)
                    .HasColumnName("SALVAGE_VALUE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Sparepartsrate)
                    .HasColumnName("SPAREPARTSRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.State)
                    .HasColumnName("STATE")
                    .HasMaxLength(255);

                entity.Property(e => e.Tchtype).HasColumnName("TCHTYPE");

                entity.Property(e => e.Tcolor).HasColumnName("TCOLOR");

                entity.Property(e => e.Tiresrate)
                    .HasColumnName("TIRESRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Totalrate)
                    .HasColumnName("TOTALRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Trdate).HasColumnName("TRDATE");

                entity.Property(e => e.Tregtype).HasColumnName("TREGTYPE");

                entity.Property(e => e.Trids).HasColumnName("TRIDS");

                entity.Property(e => e.Tunit)
                    .HasColumnName("TUNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Tval)
                    .HasColumnName("TVAL")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Virtual).HasColumnName("VIRTUAL");
            });

            modelBuilder.Entity<Extracode1>(entity =>
            {
                entity.HasKey(e => e.Groupcodeid)
                    .HasName("PK__EXTRACOD__7408C9411410CB97");

                entity.ToTable("EXTRACODE1");

                entity.HasIndex(e => e.Groupcode)
                    .HasName("IDX_GROUPCODE");

                entity.Property(e => e.Groupcodeid).HasColumnName("GROUPCODEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255);

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Extracode2>(entity =>
            {
                entity.HasKey(e => e.Groupcodeid)
                    .HasName("PK__EXTRACOD__7408C94117BF41A3");

                entity.ToTable("EXTRACODE2");

                entity.HasIndex(e => e.Groupcode)
                    .HasName("IDX_GROUPCODE");

                entity.Property(e => e.Groupcodeid).HasColumnName("GROUPCODEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255);

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Extracode3>(entity =>
            {
                entity.HasKey(e => e.Groupcodeid)
                    .HasName("PK__EXTRACOD__7408C941A40FBCA2");

                entity.ToTable("EXTRACODE3");

                entity.HasIndex(e => e.Groupcode)
                    .HasName("IDX_GROUPCODE");

                entity.Property(e => e.Groupcodeid).HasColumnName("GROUPCODEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255);

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Extracode4>(entity =>
            {
                entity.HasKey(e => e.Groupcodeid)
                    .HasName("PK__EXTRACOD__7408C94184A77066");

                entity.ToTable("EXTRACODE4");

                entity.HasIndex(e => e.Groupcode)
                    .HasName("IDX_GROUPCODE");

                entity.Property(e => e.Groupcodeid).HasColumnName("GROUPCODEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255);

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Extracode5>(entity =>
            {
                entity.HasKey(e => e.Groupcodeid)
                    .HasName("PK__EXTRACOD__7408C941854D082A");

                entity.ToTable("EXTRACODE5");

                entity.HasIndex(e => e.Groupcode)
                    .HasName("IDX_GROUPCODE");

                entity.Property(e => e.Groupcodeid).HasColumnName("GROUPCODEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255);

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Extracode6>(entity =>
            {
                entity.HasKey(e => e.Groupcodeid)
                    .HasName("PK__EXTRACOD__7408C941E558F32F");

                entity.ToTable("EXTRACODE6");

                entity.HasIndex(e => e.Groupcode)
                    .HasName("IDX_GROUPCODE");

                entity.Property(e => e.Groupcodeid).HasColumnName("GROUPCODEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255);

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Extracode7>(entity =>
            {
                entity.HasKey(e => e.Groupcodeid)
                    .HasName("PK__EXTRACOD__7408C94186B9314B");

                entity.ToTable("EXTRACODE7");

                entity.HasIndex(e => e.Groupcode)
                    .HasName("IDX_GROUPCODE");

                entity.Property(e => e.Groupcodeid).HasColumnName("GROUPCODEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255);

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Fncton>(entity =>
            {
                entity.HasKey(e => e.Functionid)
                    .HasName("PK__FNCTON__466C3FDF081C44D2");

                entity.ToTable("FNCTON");

                entity.HasIndex(e => e.Name)
                    .HasName("IDX_FNAME");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Functionid).HasColumnName("FUNCTIONID");

                entity.Property(e => e.Createdate).HasColumnName("CREATEDATE");

                entity.Property(e => e.Createuserid)
                    .HasColumnName("CREATEUSERID")
                    .HasMaxLength(255);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Grouping)
                    .HasColumnName("GROUPING")
                    .HasMaxLength(255);

                entity.Property(e => e.Impl).HasColumnName("IMPL");

                entity.Property(e => e.Lang)
                    .HasColumnName("LANG")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Prttype)
                    .HasColumnName("PRTTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Pswd)
                    .HasColumnName("PSWD")
                    .HasMaxLength(255);

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Restype)
                    .HasColumnName("RESTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Snum).HasColumnName("SNUM");

                entity.Property(e => e.Takeoff).HasColumnName("TAKEOFF");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<FnctonArgument>(entity =>
            {
                entity.HasKey(e => e.Fargid)
                    .HasName("PK__FNCTON_A__E10CD26F0916125A");

                entity.ToTable("FNCTON_ARGUMENT");

                entity.HasIndex(e => e.Fid)
                    .HasName("IDX_FUNCTION");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Fargid).HasColumnName("FARGID");

                entity.Property(e => e.Artype)
                    .HasColumnName("ARTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Defval).HasColumnName("DEFVAL");

                entity.Property(e => e.Depsta).HasColumnName("DEPSTA");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editable).HasColumnName("EDITABLE");

                entity.Property(e => e.Fid).HasColumnName("FID");

                entity.Property(e => e.Grouping)
                    .HasColumnName("GROUPING")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Sellist).HasColumnName("SELLIST");

                entity.Property(e => e.Sorder).HasColumnName("SORDER");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Valsta).HasColumnName("VALSTA");

                entity.Property(e => e.Varscount).HasColumnName("VARSCOUNT");

                entity.HasOne(d => d.F)
                    .WithMany(p => p.FnctonArgument)
                    .HasForeignKey(d => d.Fid)
                    .HasConstraintName("FK8C659444F8BAE1EC");
            });

            modelBuilder.Entity<Gekcode>(entity =>
            {
                entity.ToTable("GEKCODE");

                entity.HasIndex(e => e.Groupcode)
                    .HasName("IDX_GROUPCODE");

                entity.Property(e => e.Gekcodeid).HasColumnName("GEKCODEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255);

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Groupcode>(entity =>
            {
                entity.ToTable("GROUPCODE");

                entity.HasIndex(e => e.Groupcode1)
                    .HasName("IDX_GROUPCODE");

                entity.Property(e => e.Groupcodeid).HasColumnName("GROUPCODEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Groupcode1)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Notes).HasColumnName("NOTES");

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Ifcelement>(entity =>
            {
                entity.HasKey(e => e.Elemid)
                    .HasName("PK__IFCELEME__A19832A359C3268F");

                entity.ToTable("IFCELEMENT");

                entity.HasIndex(e => e.Ifcid)
                    .HasName("IDX_IGID");

                entity.HasIndex(e => e.Ifcmodel)
                    .HasName("IDX_IMODEL");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Elemid).HasColumnName("ELEMID");

                entity.Property(e => e.Bottomelev)
                    .HasColumnName("BOTTOMELEV")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cndid).HasColumnName("CNDID");

                entity.Property(e => e.Decomposes).HasColumnName("DECOMPOSES");

                entity.Property(e => e.Ifcappname).HasColumnName("IFCAPPNAME");

                entity.Property(e => e.Ifcbuilding)
                    .HasColumnName("IFCBUILDING")
                    .HasMaxLength(255);

                entity.Property(e => e.Ifccolor)
                    .HasColumnName("IFCCOLOR")
                    .HasMaxLength(255);

                entity.Property(e => e.Ifcdate)
                    .HasColumnName("IFCDATE")
                    .HasColumnType("date");

                entity.Property(e => e.Ifcdescription).HasColumnName("IFCDESCRIPTION");

                entity.Property(e => e.Ifcfile).HasColumnName("IFCFILE");

                entity.Property(e => e.Ifcfname)
                    .HasColumnName("IFCFNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Ifcid)
                    .HasColumnName("IFCID")
                    .HasMaxLength(255);

                entity.Property(e => e.Ifclabel)
                    .HasColumnName("IFCLABEL")
                    .HasMaxLength(255);

                entity.Property(e => e.Ifclayer)
                    .HasColumnName("IFCLAYER")
                    .HasMaxLength(255);

                entity.Property(e => e.Ifclocation).HasColumnName("IFCLOCATION");

                entity.Property(e => e.Ifcmaterial)
                    .HasColumnName("IFCMATERIAL")
                    .HasMaxLength(255);

                entity.Property(e => e.Ifcmodel)
                    .HasColumnName("IFCMODEL")
                    .HasMaxLength(255);

                entity.Property(e => e.Ifcname)
                    .HasColumnName("IFCNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Ifcobjecttype)
                    .HasColumnName("IFCOBJECTTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Ifcqty1)
                    .HasColumnName("IFCQTY1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Ifcqty2)
                    .HasColumnName("IFCQTY2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Ifcqty3)
                    .HasColumnName("IFCQTY3")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Ifcqtyname1)
                    .HasColumnName("IFCQTYNAME1")
                    .HasMaxLength(255);

                entity.Property(e => e.Ifcqtyname2)
                    .HasColumnName("IFCQTYNAME2")
                    .HasMaxLength(255);

                entity.Property(e => e.Ifcqtyname3)
                    .HasColumnName("IFCQTYNAME3")
                    .HasMaxLength(255);

                entity.Property(e => e.Ifcstorey)
                    .HasColumnName("IFCSTOREY")
                    .HasMaxLength(255);

                entity.Property(e => e.Ifctitle).HasColumnName("IFCTITLE");

                entity.Property(e => e.Ifctransparency).HasColumnName("IFCTRANSPARENCY");

                entity.Property(e => e.Ifctype)
                    .HasColumnName("IFCTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Ifcuom1)
                    .HasColumnName("IFCUOM1")
                    .HasMaxLength(255);

                entity.Property(e => e.Ifcuom2)
                    .HasColumnName("IFCUOM2")
                    .HasMaxLength(255);

                entity.Property(e => e.Ifcuom3)
                    .HasColumnName("IFCUOM3")
                    .HasMaxLength(255);

                entity.Property(e => e.Ifczone)
                    .HasColumnName("IFCZONE")
                    .HasMaxLength(255);

                entity.Property(e => e.Parentid)
                    .HasColumnName("PARENTID")
                    .HasMaxLength(255);

                entity.Property(e => e.Parentspaceid)
                    .HasColumnName("PARENTSPACEID")
                    .HasMaxLength(255);

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Topelev)
                    .HasColumnName("TOPELEV")
                    .HasColumnType("numeric(30, 10)");
            });

            modelBuilder.Entity<Ifcproperty>(entity =>
            {
                entity.HasKey(e => e.Propid)
                    .HasName("PK__IFCPROPE__FDD62FBD06A5B186");

                entity.ToTable("IFCPROPERTY");

                entity.HasIndex(e => e.Elemid)
                    .HasName("IDX_ELEMID");

                entity.HasIndex(e => e.Ifcpropname)
                    .HasName("IDX_PNAME");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Propid).HasColumnName("PROPID");

                entity.Property(e => e.Elemid).HasColumnName("ELEMID");

                entity.Property(e => e.Ifcisnum).HasColumnName("IFCISNUM");

                entity.Property(e => e.Ifcmtuom)
                    .HasColumnName("IFCMTUOM")
                    .HasMaxLength(255);

                entity.Property(e => e.Ifcnumval)
                    .HasColumnName("IFCNUMVAL")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Ifcpropgroup)
                    .HasColumnName("IFCPROPGROUP")
                    .HasMaxLength(255);

                entity.Property(e => e.Ifcpropname)
                    .HasColumnName("IFCPROPNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Ifcqtytype).HasColumnName("IFCQTYTYPE");

                entity.Property(e => e.Ifcvalue)
                    .HasColumnName("IFCVALUE")
                    .HasMaxLength(255);

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.HasOne(d => d.Elem)
                    .WithMany(p => p.Ifcproperty)
                    .HasForeignKey(d => d.Elemid)
                    .HasConstraintName("FK2A8C29BE515D4A5");
            });

            modelBuilder.Entity<Labhistory>(entity =>
            {
                entity.ToTable("LABHISTORY");

                entity.HasIndex(e => e.Laborid)
                    .HasName("IDX_LABOR");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Basetableid)
                    .HasColumnName("BASETABLEID")
                    .HasMaxLength(255);

                entity.Property(e => e.Laborid).HasColumnName("LABORID");

                entity.Property(e => e.Preddate).HasColumnName("PREDDATE");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Rsrc).HasColumnName("RSRC");

                entity.HasOne(d => d.Labor)
                    .WithMany(p => p.Labhistory)
                    .HasForeignKey(d => d.Laborid)
                    .HasConstraintName("FK5546C6675C7E33D4");
            });

            modelBuilder.Entity<Labor>(entity =>
            {
                entity.ToTable("LABOR");

                entity.HasIndex(e => e.Databaseid)
                    .HasName("IDX_MDBID");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Laborid).HasColumnName("LABORID");

                entity.Property(e => e.Accrights)
                    .HasColumnName("ACCRIGHTS")
                    .HasMaxLength(255);

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(255);

                entity.Property(e => e.Burate)
                    .HasColumnName("BURATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.City)
                    .HasColumnName("CITY")
                    .HasMaxLength(255);

                entity.Property(e => e.Conceptual).HasColumnName("CONCEPTUAL");

                entity.Property(e => e.Contactperson)
                    .HasColumnName("CONTACTPERSON")
                    .HasMaxLength(255);

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Createdate).HasColumnName("CREATEDATE");

                entity.Property(e => e.Createuser)
                    .HasColumnName("CREATEUSER")
                    .HasMaxLength(255);

                entity.Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasMaxLength(255);

                entity.Property(e => e.Databasecreationdate).HasColumnName("DATABASECREATIONDATE");

                entity.Property(e => e.Databaseid).HasColumnName("DATABASEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode1)
                    .HasColumnName("EXTRACODE1")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode10)
                    .HasColumnName("EXTRACODE10")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode2)
                    .HasColumnName("EXTRACODE2")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode3)
                    .HasColumnName("EXTRACODE3")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode4)
                    .HasColumnName("EXTRACODE4")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode5)
                    .HasColumnName("EXTRACODE5")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode6)
                    .HasColumnName("EXTRACODE6")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode7)
                    .HasColumnName("EXTRACODE7")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode8)
                    .HasColumnName("EXTRACODE8")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode9)
                    .HasColumnName("EXTRACODE9")
                    .HasMaxLength(255);

                entity.Property(e => e.Faxnumber)
                    .HasColumnName("FAXNUMBER")
                    .HasMaxLength(255);

                entity.Property(e => e.Gekcode)
                    .HasColumnName("GEKCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Ika)
                    .HasColumnName("IKA")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Keyw).HasColumnName("KEYW");

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Mobilenumber)
                    .HasColumnName("MOBILENUMBER")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255);

                entity.Property(e => e.Overtype).HasColumnName("OVERTYPE");

                entity.Property(e => e.Phonenumber)
                    .HasColumnName("PHONENUMBER")
                    .HasMaxLength(255);

                entity.Property(e => e.Predicted).HasColumnName("PREDICTED");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Project)
                    .HasColumnName("PROJECT")
                    .HasMaxLength(255);

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Rescode)
                    .HasColumnName("RESCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Stateprovince)
                    .HasColumnName("STATEPROVINCE")
                    .HasMaxLength(255);

                entity.Property(e => e.Tchtype).HasColumnName("TCHTYPE");

                entity.Property(e => e.Tcolor).HasColumnName("TCOLOR");

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Totalrate)
                    .HasColumnName("TOTALRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Trdate).HasColumnName("TRDATE");

                entity.Property(e => e.Tregtype).HasColumnName("TREGTYPE");

                entity.Property(e => e.Trids).HasColumnName("TRIDS");

                entity.Property(e => e.Tunit)
                    .HasColumnName("TUNIT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Tval)
                    .HasColumnName("TVAL")
                    .HasMaxLength(255);

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Virtual).HasColumnName("VIRTUAL");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("MATERIAL");

                entity.HasIndex(e => e.Databaseid)
                    .HasName("IDX_MDBID");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.HasIndex(e => e.Supplierid)
                    .HasName("IDX_SUPPLIER");

                entity.Property(e => e.Materialid).HasColumnName("MATERIALID");

                entity.Property(e => e.Accrights)
                    .HasColumnName("ACCRIGHTS")
                    .HasMaxLength(255);

                entity.Property(e => e.Accuracy)
                    .HasColumnName("ACCURACY")
                    .HasMaxLength(255);

                entity.Property(e => e.Bimmaterial).HasColumnName("BIMMATERIAL");

                entity.Property(e => e.Bimtype)
                    .HasColumnName("BIMTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Burate)
                    .HasColumnName("BURATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Conceptual).HasColumnName("CONCEPTUAL");

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Createdate).HasColumnName("CREATEDATE");

                entity.Property(e => e.Createuser)
                    .HasColumnName("CREATEUSER")
                    .HasMaxLength(255);

                entity.Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasMaxLength(255);

                entity.Property(e => e.Databasecreationdate).HasColumnName("DATABASECREATIONDATE");

                entity.Property(e => e.Databaseid).HasColumnName("DATABASEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Distance)
                    .HasColumnName("DISTANCE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Distunit)
                    .HasColumnName("DISTUNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Duty)
                    .HasColumnName("DUTY")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Dutyut)
                    .HasColumnName("DUTYUT")
                    .HasMaxLength(255);

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode1)
                    .HasColumnName("EXTRACODE1")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode10)
                    .HasColumnName("EXTRACODE10")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode2)
                    .HasColumnName("EXTRACODE2")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode3)
                    .HasColumnName("EXTRACODE3")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode4)
                    .HasColumnName("EXTRACODE4")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode5)
                    .HasColumnName("EXTRACODE5")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode6)
                    .HasColumnName("EXTRACODE6")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode7)
                    .HasColumnName("EXTRACODE7")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode8)
                    .HasColumnName("EXTRACODE8")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode9)
                    .HasColumnName("EXTRACODE9")
                    .HasMaxLength(255);

                entity.Property(e => e.Fabrate)
                    .HasColumnName("FABRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Gekcode)
                    .HasColumnName("GEKCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Inclusion)
                    .HasColumnName("INCLUSION")
                    .HasMaxLength(255);

                entity.Property(e => e.Keyw).HasColumnName("KEYW");

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Msflow)
                    .HasColumnName("MSFLOW")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Msflowut)
                    .HasColumnName("MSFLOWUT")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255);

                entity.Property(e => e.Opres)
                    .HasColumnName("OPRES")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Opresut)
                    .HasColumnName("OPRESUT")
                    .HasMaxLength(255);

                entity.Property(e => e.Optemput)
                    .HasColumnName("OPTEMPUT")
                    .HasMaxLength(255);

                entity.Property(e => e.Optmp)
                    .HasColumnName("OPTMP")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Overtype).HasColumnName("OVERTYPE");

                entity.Property(e => e.Predicted).HasColumnName("PREDICTED");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Project)
                    .HasColumnName("PROJECT")
                    .HasMaxLength(255);

                entity.Property(e => e.Qty)
                    .HasColumnName("QTY")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rawmat)
                    .HasColumnName("RAWMAT")
                    .HasMaxLength(255);

                entity.Property(e => e.Rawmat2)
                    .HasColumnName("RAWMAT2")
                    .HasMaxLength(255);

                entity.Property(e => e.Rawmat3)
                    .HasColumnName("RAWMAT3")
                    .HasMaxLength(255);

                entity.Property(e => e.Rawmat4)
                    .HasColumnName("RAWMAT4")
                    .HasMaxLength(255);

                entity.Property(e => e.Rawmat5)
                    .HasColumnName("RAWMAT5")
                    .HasMaxLength(255);

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Reliance)
                    .HasColumnName("RELIANCE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Reliance2)
                    .HasColumnName("RELIANCE2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Reliance3)
                    .HasColumnName("RELIANCE3")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Reliance4)
                    .HasColumnName("RELIANCE4")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Reliance5)
                    .HasColumnName("RELIANCE5")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rescode)
                    .HasColumnName("RESCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Shiprate)
                    .HasColumnName("SHIPRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Stateprovince)
                    .HasColumnName("STATEPROVINCE")
                    .HasMaxLength(255);

                entity.Property(e => e.Supplierid).HasColumnName("SUPPLIERID");

                entity.Property(e => e.Suppliername)
                    .HasColumnName("SUPPLIERNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Tchtype).HasColumnName("TCHTYPE");

                entity.Property(e => e.Tcolor).HasColumnName("TCOLOR");

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Totalrate)
                    .HasColumnName("TOTALRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Trdate).HasColumnName("TRDATE");

                entity.Property(e => e.Tregtype).HasColumnName("TREGTYPE");

                entity.Property(e => e.Trids).HasColumnName("TRIDS");

                entity.Property(e => e.Tunit)
                    .HasColumnName("TUNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Tval)
                    .HasColumnName("TVAL")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Virtual).HasColumnName("VIRTUAL");

                entity.Property(e => e.Vlflowut)
                    .HasColumnName("VLFLOWUT")
                    .HasMaxLength(255);

                entity.Property(e => e.Volflow)
                    .HasColumnName("VOLFLOW")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Weight)
                    .HasColumnName("WEIGHT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Weightunit)
                    .HasColumnName("WEIGHTUNIT")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Material)
                    .HasForeignKey(d => d.Supplierid)
                    .HasConstraintName("FK40795527D05B2C5E");
            });

            modelBuilder.Entity<Mathistory>(entity =>
            {
                entity.ToTable("MATHISTORY");

                entity.HasIndex(e => e.Materialid)
                    .HasName("IDX_MATERIAL");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Basetableid)
                    .HasColumnName("BASETABLEID")
                    .HasMaxLength(255);

                entity.Property(e => e.Materialid).HasColumnName("MATERIALID");

                entity.Property(e => e.Preddate).HasColumnName("PREDDATE");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Rsrc).HasColumnName("RSRC");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.Mathistory)
                    .HasForeignKey(d => d.Materialid)
                    .HasConstraintName("FK97655F342461A27E");
            });

            modelBuilder.Entity<Ostdbcon>(entity =>
            {
                entity.HasKey(e => e.Ostconid)
                    .HasName("PK__OSTDBCON__BA2974565FAD6A9C");

                entity.ToTable("OSTDBCON");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Ostconid).HasColumnName("OSTCONID");

                entity.Property(e => e.Databasename)
                    .HasColumnName("DATABASENAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Host)
                    .HasColumnName("HOST")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(255);

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Username)
                    .HasColumnName("USERNAME")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Paramcondition>(entity =>
            {
                entity.HasKey(e => e.Conditionid)
                    .HasName("PK__PARAMCON__AF05447C394666BD");

                entity.ToTable("PARAMCONDITION");

                entity.HasIndex(e => e.Paraminputid)
                    .HasName("IDX_PARAMINPUT");

                entity.HasIndex(e => e.Paramitemid)
                    .HasName("IDX_PARAMITEM");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Conditionid).HasColumnName("CONDITIONID");

                entity.Property(e => e.Bidno).HasColumnName("BIDNO");

                entity.Property(e => e.Bimmaterial).HasColumnName("BIMMATERIAL");

                entity.Property(e => e.Bimtype)
                    .HasColumnName("BIMTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Building)
                    .HasColumnName("BUILDING")
                    .HasMaxLength(255);

                entity.Property(e => e.Cndid).HasColumnName("CNDID");

                entity.Property(e => e.Cndno).HasColumnName("CNDNO");

                entity.Property(e => e.Cndtype)
                    .HasColumnName("CNDTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Dbname)
                    .HasColumnName("DBNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Fctstate).HasColumnName("FCTSTATE");

                entity.Property(e => e.Formula1)
                    .HasColumnName("FORMULA1")
                    .HasMaxLength(255);

                entity.Property(e => e.Formula2)
                    .HasColumnName("FORMULA2")
                    .HasMaxLength(255);

                entity.Property(e => e.Formula3)
                    .HasColumnName("FORMULA3")
                    .HasMaxLength(255);

                entity.Property(e => e.Formulaf).HasColumnName("FORMULAF");

                entity.Property(e => e.Globalid)
                    .HasColumnName("GLOBALID")
                    .HasMaxLength(255);

                entity.Property(e => e.Host)
                    .HasColumnName("HOST")
                    .HasMaxLength(255);

                entity.Property(e => e.Layer)
                    .HasColumnName("LAYER")
                    .HasMaxLength(255);

                entity.Property(e => e.Location)
                    .HasColumnName("LOCATION")
                    .HasMaxLength(255);

                entity.Property(e => e.Paraminputid).HasColumnName("PARAMINPUTID");

                entity.Property(e => e.Paramitemid).HasColumnName("PARAMITEMID");

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(255);

                entity.Property(e => e.Pickdata).HasColumnName("PICKDATA");

                entity.Property(e => e.Picktype).HasColumnName("PICKTYPE");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Qty1)
                    .HasColumnName("QTY1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qty1name)
                    .HasColumnName("QTY1NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Qty2)
                    .HasColumnName("QTY2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qty2name)
                    .HasColumnName("QTY2NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Qty3)
                    .HasColumnName("QTY3")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qty3name)
                    .HasColumnName("QTY3NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Qtyf)
                    .HasColumnName("QTYF")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qtyfname)
                    .HasColumnName("QTYFNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Selqty).HasColumnName("SELQTY");

                entity.Property(e => e.Storey)
                    .HasColumnName("STOREY")
                    .HasMaxLength(255);

                entity.Property(e => e.Takeofftype)
                    .HasColumnName("TAKEOFFTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255);

                entity.Property(e => e.Unit1)
                    .HasColumnName("UNIT1")
                    .HasMaxLength(255);

                entity.Property(e => e.Unit2)
                    .HasColumnName("UNIT2")
                    .HasMaxLength(255);

                entity.Property(e => e.Unit3)
                    .HasColumnName("UNIT3")
                    .HasMaxLength(255);

                entity.Property(e => e.Unitf)
                    .HasColumnName("UNITF")
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .HasColumnName("USERNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Virt).HasColumnName("VIRT");

                entity.HasOne(d => d.Paraminput)
                    .WithMany(p => p.Paramcondition)
                    .HasForeignKey(d => d.Paraminputid)
                    .HasConstraintName("FK5664872E68123411");

                entity.HasOne(d => d.Paramitem)
                    .WithMany(p => p.Paramcondition)
                    .HasForeignKey(d => d.Paramitemid)
                    .HasConstraintName("FK5664872EB8FEF034");
            });

            modelBuilder.Entity<Paraminput>(entity =>
            {
                entity.ToTable("PARAMINPUT");

                entity.HasIndex(e => e.Paramitemid)
                    .HasName("IDX_PARAMITEM");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Paraminputid).HasColumnName("PARAMINPUTID");

                entity.Property(e => e.Arsizevar)
                    .HasColumnName("ARSIZEVAR")
                    .HasMaxLength(255);

                entity.Property(e => e.Artype)
                    .HasColumnName("ARTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Calcvaldigits).HasColumnName("CALCVALDIGITS");

                entity.Property(e => e.Calcvalue).HasColumnName("CALCVALUE");

                entity.Property(e => e.Comment).HasColumnName("COMMENT");

                entity.Property(e => e.Datatype)
                    .HasColumnName("DATATYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Defvalue).HasColumnName("DEFVALUE");

                entity.Property(e => e.Dependency).HasColumnName("DEPENDENCY");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editable).HasColumnName("EDITABLE");

                entity.Property(e => e.Frmrowvis).HasColumnName("FRMROWVIS");

                entity.Property(e => e.Grouping)
                    .HasColumnName("GROUPING")
                    .HasMaxLength(255);

                entity.Property(e => e.Hidden).HasColumnName("HIDDEN");

                entity.Property(e => e.Lbl)
                    .HasColumnName("LBL")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Paramitemid).HasColumnName("PARAMITEMID");

                entity.Property(e => e.Pblk).HasColumnName("PBLK");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Selection).HasColumnName("SELECTION");

                entity.Property(e => e.Sortorder).HasColumnName("SORTORDER");

                entity.Property(e => e.Stoval).HasColumnName("STOVAL");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Validation).HasColumnName("VALIDATION");

                entity.Property(e => e.Wasshown).HasColumnName("WASSHOWN");

                entity.HasOne(d => d.Paramitem)
                    .WithMany(p => p.Paraminput)
                    .HasForeignKey(d => d.Paramitemid)
                    .HasConstraintName("FK38777B5DB8FEF034");
            });

            modelBuilder.Entity<Paramitem>(entity =>
            {
                entity.ToTable("PARAMITEM");

                entity.HasIndex(e => e.Boqitemid)
                    .HasName("IDX_BOQITEM");

                entity.HasIndex(e => e.Databaseid)
                    .HasName("IDX_MDBID");

                entity.HasIndex(e => e.Groupidentity)
                    .HasName("IDX_GROUPIDENTITY");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.HasIndex(e => e.Title)
                    .HasName("IDX_TITLE");

                entity.Property(e => e.Paramitemid).HasColumnName("PARAMITEMID");

                entity.Property(e => e.Accrights)
                    .HasColumnName("ACCRIGHTS")
                    .HasMaxLength(255);

                entity.Property(e => e.Boqitemid).HasColumnName("BOQITEMID");

                entity.Property(e => e.Cmodel).HasColumnName("CMODEL");

                entity.Property(e => e.Createdate).HasColumnName("CREATEDATE");

                entity.Property(e => e.Createuserid)
                    .HasColumnName("CREATEUSERID")
                    .HasMaxLength(255);

                entity.Property(e => e.Databasecreationdate).HasColumnName("DATABASECREATIONDATE");

                entity.Property(e => e.Databaseid).HasColumnName("DATABASEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode1)
                    .HasColumnName("EXTRACODE1")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode10)
                    .HasColumnName("EXTRACODE10")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode2)
                    .HasColumnName("EXTRACODE2")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode3)
                    .HasColumnName("EXTRACODE3")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode4)
                    .HasColumnName("EXTRACODE4")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode5)
                    .HasColumnName("EXTRACODE5")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode6)
                    .HasColumnName("EXTRACODE6")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode7)
                    .HasColumnName("EXTRACODE7")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode8)
                    .HasColumnName("EXTRACODE8")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode9)
                    .HasColumnName("EXTRACODE9")
                    .HasMaxLength(255);

                entity.Property(e => e.Gekcode)
                    .HasColumnName("GEKCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Glbid).HasColumnName("GLBID");

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Groupidentity)
                    .HasColumnName("GROUPIDENTITY")
                    .HasMaxLength(255);

                entity.Property(e => e.Groupname)
                    .HasColumnName("GROUPNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Icon)
                    .HasColumnName("ICON")
                    .HasMaxLength(255);

                entity.Property(e => e.Keyw).HasColumnName("KEYW");

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Loc)
                    .HasColumnName("LOC")
                    .HasMaxLength(255);

                entity.Property(e => e.Multunitqty).HasColumnName("MULTUNITQTY");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255);

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Prttype)
                    .HasColumnName("PRTTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Pswd)
                    .HasColumnName("PSWD")
                    .HasMaxLength(255);

                entity.Property(e => e.Qty)
                    .HasColumnName("QTY")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Rescode)
                    .HasColumnName("RESCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Samplerate)
                    .HasColumnName("SAMPLERATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Snum).HasColumnName("SNUM");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255);

                entity.Property(e => e.Titleequ).HasColumnName("TITLEEQU");

                entity.Property(e => e.Totalcost)
                    .HasColumnName("TOTALCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Variable)
                    .HasColumnName("VARIABLE")
                    .HasMaxLength(255);

                entity.Property(e => e.Wasexploded).HasColumnName("WASEXPLODED");

                entity.Property(e => e.Wbs)
                    .HasColumnName("WBS")
                    .HasMaxLength(255);

                entity.Property(e => e.Wbs2)
                    .HasColumnName("WBS2")
                    .HasMaxLength(255);

                entity.HasOne(d => d.BoqitemNavigation)
                    .WithMany(p => p.ParamitemNavigation)
                    .HasForeignKey(d => d.Boqitemid)
                    .HasConstraintName("FK1A98950089F3BCA6");
            });

            modelBuilder.Entity<Paramoutput>(entity =>
            {
                entity.ToTable("PARAMOUTPUT");

                entity.HasIndex(e => e.Paramitemid)
                    .HasName("IDX_PARAMITEM");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Paramoutputid).HasColumnName("PARAMOUTPUTID");

                entity.Property(e => e.Conloceq).HasColumnName("CONLOCEQ");

                entity.Property(e => e.Equloceq).HasColumnName("EQULOCEQ");

                entity.Property(e => e.Factoreq).HasColumnName("FACTOREQ");

                entity.Property(e => e.Generation).HasColumnName("GENERATION");

                entity.Property(e => e.Labloceq).HasColumnName("LABLOCEQ");

                entity.Property(e => e.Loopvar)
                    .HasColumnName("LOOPVAR")
                    .HasMaxLength(255);

                entity.Property(e => e.Matloceq).HasColumnName("MATLOCEQ");

                entity.Property(e => e.Paramitemid).HasColumnName("PARAMITEMID");

                entity.Property(e => e.Prdeq).HasColumnName("PRDEQ");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Qtyeq).HasColumnName("QTYEQ");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Resids).HasColumnName("RESIDS");

                entity.Property(e => e.Sortorder).HasColumnName("SORTORDER");

                entity.Property(e => e.Subloceq).HasColumnName("SUBLOCEQ");

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.HasOne(d => d.Paramitem)
                    .WithMany(p => p.Paramoutput)
                    .HasForeignKey(d => d.Paramitemid)
                    .HasConstraintName("FKE11967AEB8FEF034");
            });

            modelBuilder.Entity<Paramreturn>(entity =>
            {
                entity.ToTable("PARAMRETURN");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Paramreturnid).HasColumnName("PARAMRETURNID");

                entity.Property(e => e.Paramitemid).HasColumnName("PARAMITEMID");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Reteq).HasColumnName("RETEQ");

                entity.HasOne(d => d.Paramitem)
                    .WithMany(p => p.Paramreturn)
                    .HasForeignKey(d => d.Paramitemid)
                    .HasConstraintName("FKE5568BDDB8FEF034");
            });

            modelBuilder.Entity<Prjprop>(entity =>
            {
                entity.ToTable("PRJPROP");

                entity.HasIndex(e => e.Pkey)
                    .HasName("IDX_PROPKEY");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Pkey)
                    .HasColumnName("PKEY")
                    .HasMaxLength(255);

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Pval).HasColumnName("PVAL");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");
            });

            modelBuilder.Entity<Prjuserprop>(entity =>
            {
                entity.ToTable("PRJUSERPROP");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Pkey)
                    .HasColumnName("PKEY")
                    .HasMaxLength(255);

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Propuser)
                    .HasColumnName("PROPUSER")
                    .HasMaxLength(255);

                entity.Property(e => e.Pval).HasColumnName("PVAL");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");
            });

            modelBuilder.Entity<Projectspecvar>(entity =>
            {
                entity.ToTable("PROJECTSPECVAR");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.HasIndex(e => e.Templateid)
                    .HasName("IDX_PROJECTTEMPLATE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cellx).HasColumnName("CELLX");

                entity.Property(e => e.Celly).HasColumnName("CELLY");

                entity.Property(e => e.Databasetemplateid).HasColumnName("DATABASETEMPLATEID");

                entity.Property(e => e.Databasetemplatename)
                    .HasColumnName("DATABASETEMPLATENAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Datatype)
                    .HasColumnName("DATATYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Defval).HasColumnName("DEFVAL");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Hidden).HasColumnName("HIDDEN");

                entity.Property(e => e.Isnumber).HasColumnName("ISNUMBER");

                entity.Property(e => e.Mandatory).HasColumnName("MANDATORY");

                entity.Property(e => e.Mapped).HasColumnName("MAPPED");

                entity.Property(e => e.Name).HasColumnName("NAME");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Pushfield)
                    .HasColumnName("PUSHFIELD")
                    .HasMaxLength(255);

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Sheetno).HasColumnName("SHEETNO");

                entity.Property(e => e.Sortorder).HasColumnName("SORTORDER");

                entity.Property(e => e.Stoval).HasColumnName("STOVAL");

                entity.Property(e => e.Stovalnum)
                    .HasColumnName("STOVALNUM")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Templateid).HasColumnName("TEMPLATEID");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Projectspecvar)
                    .HasForeignKey(d => d.Templateid)
                    .HasConstraintName("FKD3E10C539A9C964D");
            });

            modelBuilder.Entity<Projecttemplate>(entity =>
            {
                entity.ToTable("PROJECTTEMPLATE");

                entity.HasIndex(e => e.Databaseid)
                    .HasName("IDX_MDBID");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Allowviewers).HasColumnName("ALLOWVIEWERS");

                entity.Property(e => e.Createdate).HasColumnName("CREATEDATE");

                entity.Property(e => e.Createuser)
                    .HasColumnName("CREATEUSER")
                    .HasMaxLength(255);

                entity.Property(e => e.Databaseid).HasColumnName("DATABASEID");

                entity.Property(e => e.Dbcreatedate).HasColumnName("DBCREATEDATE");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Hasbuildups).HasColumnName("HASBUILDUPS");

                entity.Property(e => e.Hasdistributors).HasColumnName("HASDISTRIBUTORS");

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Pblk).HasColumnName("PBLK");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Templateid).HasColumnName("TEMPLATEID");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255);

                entity.Property(e => e.Userid)
                    .HasColumnName("USERID")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Projecttemplate)
                    .HasForeignKey(d => d.Templateid)
                    .HasConstraintName("FKD8968A734DF865AC");
            });

            modelBuilder.Entity<Projectwbs>(entity =>
            {
                entity.ToTable("PROJECTWBS");

                entity.HasIndex(e => e.Code)
                    .HasName("IDX_GROUPCODE");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Projectwbsid).HasColumnName("PROJECTWBSID");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Itemcode)
                    .HasColumnName("ITEMCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Projectwbs2>(entity =>
            {
                entity.HasKey(e => e.Projectwbsid)
                    .HasName("PK__PROJECTW__2089D484BB7D7933");

                entity.ToTable("PROJECTWBS2");

                entity.HasIndex(e => e.Code)
                    .HasName("IDX_GROUPCODE");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Projectwbsid).HasColumnName("PROJECTWBSID");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Itemcode)
                    .HasColumnName("ITEMCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Queryresource>(entity =>
            {
                entity.HasKey(e => e.Qresid)
                    .HasName("PK__QUERYRES__E123B43816936CD2");

                entity.ToTable("QUERYRESOURCE");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Qresid).HasColumnName("QRESID");

                entity.Property(e => e.Ascdng).HasColumnName("ASCDNG");

                entity.Property(e => e.Cc01eq).HasColumnName("CC01EQ");

                entity.Property(e => e.Cc02eq).HasColumnName("CC02EQ");

                entity.Property(e => e.Cc03eq).HasColumnName("CC03EQ");

                entity.Property(e => e.Cc04eq).HasColumnName("CC04EQ");

                entity.Property(e => e.Cc05eq).HasColumnName("CC05EQ");

                entity.Property(e => e.Cc06eq).HasColumnName("CC06EQ");

                entity.Property(e => e.Cc07eq).HasColumnName("CC07EQ");

                entity.Property(e => e.Cc08eq).HasColumnName("CC08EQ");

                entity.Property(e => e.Cc09eq).HasColumnName("CC09EQ");

                entity.Property(e => e.Cc10eq).HasColumnName("CC10EQ");

                entity.Property(e => e.Cc11eq).HasColumnName("CC11EQ");

                entity.Property(e => e.Cc12eq).HasColumnName("CC12EQ");

                entity.Property(e => e.Cc13eq).HasColumnName("CC13EQ");

                entity.Property(e => e.Cc14eq).HasColumnName("CC14EQ");

                entity.Property(e => e.Cc15eq).HasColumnName("CC15EQ");

                entity.Property(e => e.Cc16eq).HasColumnName("CC16EQ");

                entity.Property(e => e.Cc17eq).HasColumnName("CC17EQ");

                entity.Property(e => e.Cc18eq).HasColumnName("CC18EQ");

                entity.Property(e => e.Cc19eq).HasColumnName("CC19EQ");

                entity.Property(e => e.Cc20eq).HasColumnName("CC20EQ");

                entity.Property(e => e.Cr01eq).HasColumnName("CR01EQ");

                entity.Property(e => e.Cr02eq).HasColumnName("CR02EQ");

                entity.Property(e => e.Cr03eq).HasColumnName("CR03EQ");

                entity.Property(e => e.Cr04eq).HasColumnName("CR04EQ");

                entity.Property(e => e.Cr05eq).HasColumnName("CR05EQ");

                entity.Property(e => e.Cr06eq).HasColumnName("CR06EQ");

                entity.Property(e => e.Cr07eq).HasColumnName("CR07EQ");

                entity.Property(e => e.Cr08eq).HasColumnName("CR08EQ");

                entity.Property(e => e.Cr09eq).HasColumnName("CR09EQ");

                entity.Property(e => e.Cr10eq).HasColumnName("CR10EQ");

                entity.Property(e => e.Cr11eq).HasColumnName("CR11EQ");

                entity.Property(e => e.Cr12eq).HasColumnName("CR12EQ");

                entity.Property(e => e.Cr13eq).HasColumnName("CR13EQ");

                entity.Property(e => e.Cr14eq).HasColumnName("CR14EQ");

                entity.Property(e => e.Cr15eq).HasColumnName("CR15EQ");

                entity.Property(e => e.Cr16eq).HasColumnName("CR16EQ");

                entity.Property(e => e.Cr17eq).HasColumnName("CR17EQ");

                entity.Property(e => e.Cr18eq).HasColumnName("CR18EQ");

                entity.Property(e => e.Cr19eq).HasColumnName("CR19EQ");

                entity.Property(e => e.Cr20eq).HasColumnName("CR20EQ");

                entity.Property(e => e.Ct01eq).HasColumnName("CT01EQ");

                entity.Property(e => e.Ct02eq).HasColumnName("CT02EQ");

                entity.Property(e => e.Ct03eq).HasColumnName("CT03EQ");

                entity.Property(e => e.Ct04eq).HasColumnName("CT04EQ");

                entity.Property(e => e.Ct05eq).HasColumnName("CT05EQ");

                entity.Property(e => e.Ct06eq).HasColumnName("CT06EQ");

                entity.Property(e => e.Ct07eq).HasColumnName("CT07EQ");

                entity.Property(e => e.Ct08eq).HasColumnName("CT08EQ");

                entity.Property(e => e.Ct09eq).HasColumnName("CT09EQ");

                entity.Property(e => e.Ct10eq).HasColumnName("CT10EQ");

                entity.Property(e => e.Ct11eq).HasColumnName("CT11EQ");

                entity.Property(e => e.Ct12eq).HasColumnName("CT12EQ");

                entity.Property(e => e.Ct13eq).HasColumnName("CT13EQ");

                entity.Property(e => e.Ct14eq).HasColumnName("CT14EQ");

                entity.Property(e => e.Ct15eq).HasColumnName("CT15EQ");

                entity.Property(e => e.Ct16eq).HasColumnName("CT16EQ");

                entity.Property(e => e.Ct17eq).HasColumnName("CT17EQ");

                entity.Property(e => e.Ct18eq).HasColumnName("CT18EQ");

                entity.Property(e => e.Ct19eq).HasColumnName("CT19EQ");

                entity.Property(e => e.Ct20eq).HasColumnName("CT20EQ");

                entity.Property(e => e.Ct21eq).HasColumnName("CT21EQ");

                entity.Property(e => e.Ct22eq).HasColumnName("CT22EQ");

                entity.Property(e => e.Ct23eq).HasColumnName("CT23EQ");

                entity.Property(e => e.Ct24eq).HasColumnName("CT24EQ");

                entity.Property(e => e.Ct25eq).HasColumnName("CT25EQ");

                entity.Property(e => e.Dsceq).HasColumnName("DSCEQ");

                entity.Property(e => e.Exectype).HasColumnName("EXECTYPE");

                entity.Property(e => e.Gc1eq).HasColumnName("GC1EQ");

                entity.Property(e => e.Gc2eq).HasColumnName("GC2EQ");

                entity.Property(e => e.Gc3eq).HasColumnName("GC3EQ");

                entity.Property(e => e.Gc4eq).HasColumnName("GC4EQ");

                entity.Property(e => e.Gc5eq).HasColumnName("GC5EQ");

                entity.Property(e => e.Gc6eq).HasColumnName("GC6EQ");

                entity.Property(e => e.Gc7eq).HasColumnName("GC7EQ");

                entity.Property(e => e.Gc8eq).HasColumnName("GC8EQ");

                entity.Property(e => e.Gc9eq).HasColumnName("GC9EQ");

                entity.Property(e => e.Jsonurl)
                    .HasColumnName("JSONURL")
                    .HasMaxLength(255);

                entity.Property(e => e.Loceq).HasColumnName("LOCEQ");

                entity.Property(e => e.Ntseq).HasColumnName("NTSEQ");

                entity.Property(e => e.Ordfld)
                    .HasColumnName("ORDFLD")
                    .HasMaxLength(255);

                entity.Property(e => e.Paramoutputid).HasColumnName("PARAMOUTPUTID");

                entity.Property(e => e.Pdteq).HasColumnName("PDTEQ");

                entity.Property(e => e.Piceq).HasColumnName("PICEQ");

                entity.Property(e => e.Prdeq).HasColumnName("PRDEQ");

                entity.Property(e => e.Prfeq).HasColumnName("PRFEQ");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Restype)
                    .HasColumnName("RESTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Sngsel).HasColumnName("SNGSEL");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255);

                entity.Property(e => e.Tlteq).HasColumnName("TLTEQ");

                entity.Property(e => e.Type).HasColumnName("TYPE");

                entity.Property(e => e.Wb1eq).HasColumnName("WB1EQ");

                entity.Property(e => e.Wb2eq).HasColumnName("WB2EQ");

                entity.HasOne(d => d.Paramoutput)
                    .WithMany(p => p.Queryresource)
                    .HasForeignKey(d => d.Paramoutputid)
                    .HasConstraintName("FKCB7ACB662282EA1");
            });

            modelBuilder.Entity<Queryrow>(entity =>
            {
                entity.HasKey(e => e.Qrowid)
                    .HasName("PK__QUERYROW__4AE9FF7B3045E9C5");

                entity.ToTable("QUERYROW");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.HasIndex(e => e.Qresid)
                    .HasName("IDX_QUERYRESOURCE");

                entity.Property(e => e.Qrowid).HasColumnName("QROWID");

                entity.Property(e => e.Cndn).HasColumnName("CNDN");

                entity.Property(e => e.Ctype)
                    .HasColumnName("CTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Fname)
                    .HasColumnName("FNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Qresid).HasColumnName("QRESID");

                entity.Property(e => e.Qrowscount).HasColumnName("QROWSCOUNT");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Rname)
                    .HasColumnName("RNAME")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Qres)
                    .WithMany(p => p.Queryrow)
                    .HasForeignKey(d => d.Qresid)
                    .HasConstraintName("FKE91C7C12AB986C17");
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.HasKey(e => e.Expenseid)
                    .HasName("PK__QUOTE__D98AC998D736A7B1");

                entity.ToTable("QUOTE");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Expenseid).HasColumnName("EXPENSEID");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(255);

                entity.Property(e => e.Bccmail)
                    .HasColumnName("BCCMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.Ccmail)
                    .HasColumnName("CCMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.City)
                    .HasColumnName("CITY")
                    .HasMaxLength(255);

                entity.Property(e => e.Company)
                    .HasColumnName("COMPANY")
                    .HasMaxLength(255);

                entity.Property(e => e.Contact)
                    .HasColumnName("CONTACT")
                    .HasMaxLength(255);

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Createdate).HasColumnName("CREATEDATE");

                entity.Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasMaxLength(255);

                entity.Property(e => e.Delivery).HasColumnName("DELIVERY");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.Fax)
                    .HasColumnName("FAX")
                    .HasMaxLength(255);

                entity.Property(e => e.Geopos)
                    .HasColumnName("GEOPOS")
                    .HasMaxLength(255);

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(255);

                entity.Property(e => e.Hasmatrate).HasColumnName("HASMATRATE");

                entity.Property(e => e.Mobile)
                    .HasColumnName("MOBILE")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes).HasColumnName("NOTES");

                entity.Property(e => e.Performance).HasColumnName("PERFORMANCE");

                entity.Property(e => e.Phone)
                    .HasColumnName("PHONE")
                    .HasMaxLength(255);

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Quotetempid).HasColumnName("QUOTETEMPID");

                entity.Property(e => e.Quotetype)
                    .HasColumnName("QUOTETYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Receiveddate).HasColumnName("RECEIVEDDATE");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Sentdate).HasColumnName("SENTDATE");

                entity.Property(e => e.Statepro)
                    .HasColumnName("STATEPRO")
                    .HasMaxLength(255);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(255);

                entity.Property(e => e.Subject)
                    .HasColumnName("SUBJECT")
                    .HasMaxLength(255);

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255);

                entity.Property(e => e.Tomail)
                    .HasColumnName("TOMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Quoteitem>(entity =>
            {
                entity.ToTable("QUOTEITEM");

                entity.HasIndex(e => e.Boqitemid)
                    .HasName("IDX_BOQITEM");

                entity.HasIndex(e => e.Databaseid)
                    .HasName("IDX_MDBID");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.HasIndex(e => e.Quotationid)
                    .HasName("IDX_QUOTATION");

                entity.HasIndex(e => e.Status)
                    .HasName("IDX_STATUS");

                entity.HasIndex(e => e.Supdbid)
                    .HasName("IDX_SUPPLIER");

                entity.Property(e => e.Quoteitemid).HasColumnName("QUOTEITEMID");

                entity.Property(e => e.Boqitemid).HasColumnName("BOQITEMID");

                entity.Property(e => e.Databaseid).HasColumnName("DATABASEID");

                entity.Property(e => e.Dbcreatedate).HasColumnName("DBCREATEDATE");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Finalrate)
                    .HasColumnName("FINALRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Indirect)
                    .HasColumnName("INDIRECT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Insurance)
                    .HasColumnName("INSURANCE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Manhours)
                    .HasColumnName("MANHOURS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Matrate)
                    .HasColumnName("MATRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Parqrty)
                    .HasColumnName("PARQRTY")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Quotationid).HasColumnName("QUOTATIONID");

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Rsrc).HasColumnName("RSRC");

                entity.Property(e => e.Shipmentcost)
                    .HasColumnName("SHIPMENTCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(255);

                entity.Property(e => e.Supdbid).HasColumnName("SUPDBID");

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Boqitem)
                    .WithMany(p => p.Quoteitem)
                    .HasForeignKey(d => d.Boqitemid)
                    .HasConstraintName("FK4DBD2B6F89F3BCA6");

                entity.HasOne(d => d.Quotation)
                    .WithMany(p => p.Quoteitem)
                    .HasForeignKey(d => d.Quotationid)
                    .HasConstraintName("FK4DBD2B6F28564966");
            });

            modelBuilder.Entity<Ratebuildup>(entity =>
            {
                entity.ToTable("RATEBUILDUP");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.HasIndex(e => e.Resid)
                    .HasName("IDX_RESID");

                entity.HasIndex(e => e.Resprjid)
                    .HasName("IDX_RESPRJID");

                entity.HasIndex(e => e.Templateid)
                    .HasName("IDX_PROJECTTEMPLATE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Calcformula).HasColumnName("CALCFORMULA");

                entity.Property(e => e.Dbcreatedate).HasColumnName("DBCREATEDATE");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Onln).HasColumnName("ONLN");

                entity.Property(e => e.Overrate1).HasColumnName("OVERRATE1");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Rate0)
                    .HasColumnName("RATE0")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rate1)
                    .HasColumnName("RATE1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rate10)
                    .HasColumnName("RATE10")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rate11)
                    .HasColumnName("RATE11")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rate12)
                    .HasColumnName("RATE12")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rate13)
                    .HasColumnName("RATE13")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rate14)
                    .HasColumnName("RATE14")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rate2)
                    .HasColumnName("RATE2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rate3)
                    .HasColumnName("RATE3")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rate4)
                    .HasColumnName("RATE4")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rate5)
                    .HasColumnName("RATE5")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rate6)
                    .HasColumnName("RATE6")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rate7)
                    .HasColumnName("RATE7")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rate8)
                    .HasColumnName("RATE8")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rate9)
                    .HasColumnName("RATE9")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Resid).HasColumnName("RESID");

                entity.Property(e => e.Resprjid).HasColumnName("RESPRJID");

                entity.Property(e => e.Restype)
                    .HasColumnName("RESTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Templateid).HasColumnName("TEMPLATEID");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Ratebuildup)
                    .HasForeignKey(d => d.Templateid)
                    .HasConstraintName("FK969BFC899A9C964D");
            });

            modelBuilder.Entity<Ratebuildupcols>(entity =>
            {
                entity.ToTable("RATEBUILDUPCOLS");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.HasIndex(e => e.Templateid)
                    .HasName("IDX_PROJECTTEMPLATE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Applyall).HasColumnName("APPLYALL");

                entity.Property(e => e.Colact0).HasColumnName("COLACT0");

                entity.Property(e => e.Colact1).HasColumnName("COLACT1");

                entity.Property(e => e.Colact10).HasColumnName("COLACT10");

                entity.Property(e => e.Colact11).HasColumnName("COLACT11");

                entity.Property(e => e.Colact12).HasColumnName("COLACT12");

                entity.Property(e => e.Colact13).HasColumnName("COLACT13");

                entity.Property(e => e.Colact14).HasColumnName("COLACT14");

                entity.Property(e => e.Colact2).HasColumnName("COLACT2");

                entity.Property(e => e.Colact3).HasColumnName("COLACT3");

                entity.Property(e => e.Colact4).HasColumnName("COLACT4");

                entity.Property(e => e.Colact5).HasColumnName("COLACT5");

                entity.Property(e => e.Colact6).HasColumnName("COLACT6");

                entity.Property(e => e.Colact7).HasColumnName("COLACT7");

                entity.Property(e => e.Colact8).HasColumnName("COLACT8");

                entity.Property(e => e.Colact9).HasColumnName("COLACT9");

                entity.Property(e => e.Coldefval0)
                    .HasColumnName("COLDEFVAL0")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Coldefval1)
                    .HasColumnName("COLDEFVAL1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Coldefval10)
                    .HasColumnName("COLDEFVAL10")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Coldefval11)
                    .HasColumnName("COLDEFVAL11")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Coldefval12)
                    .HasColumnName("COLDEFVAL12")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Coldefval13)
                    .HasColumnName("COLDEFVAL13")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Coldefval14)
                    .HasColumnName("COLDEFVAL14")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Coldefval2)
                    .HasColumnName("COLDEFVAL2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Coldefval3)
                    .HasColumnName("COLDEFVAL3")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Coldefval4)
                    .HasColumnName("COLDEFVAL4")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Coldefval5)
                    .HasColumnName("COLDEFVAL5")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Coldefval6)
                    .HasColumnName("COLDEFVAL6")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Coldefval7)
                    .HasColumnName("COLDEFVAL7")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Coldefval8)
                    .HasColumnName("COLDEFVAL8")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Coldefval9)
                    .HasColumnName("COLDEFVAL9")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Colform0).HasColumnName("COLFORM0");

                entity.Property(e => e.Colform1).HasColumnName("COLFORM1");

                entity.Property(e => e.Colform10).HasColumnName("COLFORM10");

                entity.Property(e => e.Colform11).HasColumnName("COLFORM11");

                entity.Property(e => e.Colform12).HasColumnName("COLFORM12");

                entity.Property(e => e.Colform13).HasColumnName("COLFORM13");

                entity.Property(e => e.Colform14).HasColumnName("COLFORM14");

                entity.Property(e => e.Colform2).HasColumnName("COLFORM2");

                entity.Property(e => e.Colform3).HasColumnName("COLFORM3");

                entity.Property(e => e.Colform4).HasColumnName("COLFORM4");

                entity.Property(e => e.Colform5).HasColumnName("COLFORM5");

                entity.Property(e => e.Colform6).HasColumnName("COLFORM6");

                entity.Property(e => e.Colform7).HasColumnName("COLFORM7");

                entity.Property(e => e.Colform8).HasColumnName("COLFORM8");

                entity.Property(e => e.Colform9).HasColumnName("COLFORM9");

                entity.Property(e => e.Colname0).HasColumnName("COLNAME0");

                entity.Property(e => e.Colname1).HasColumnName("COLNAME1");

                entity.Property(e => e.Colname10).HasColumnName("COLNAME10");

                entity.Property(e => e.Colname11).HasColumnName("COLNAME11");

                entity.Property(e => e.Colname12).HasColumnName("COLNAME12");

                entity.Property(e => e.Colname13).HasColumnName("COLNAME13");

                entity.Property(e => e.Colname14).HasColumnName("COLNAME14");

                entity.Property(e => e.Colname2).HasColumnName("COLNAME2");

                entity.Property(e => e.Colname3).HasColumnName("COLNAME3");

                entity.Property(e => e.Colname4).HasColumnName("COLNAME4");

                entity.Property(e => e.Colname5).HasColumnName("COLNAME5");

                entity.Property(e => e.Colname6).HasColumnName("COLNAME6");

                entity.Property(e => e.Colname7).HasColumnName("COLNAME7");

                entity.Property(e => e.Colname8).HasColumnName("COLNAME8");

                entity.Property(e => e.Colname9).HasColumnName("COLNAME9");

                entity.Property(e => e.Coltype0).HasColumnName("COLTYPE0");

                entity.Property(e => e.Coltype1).HasColumnName("COLTYPE1");

                entity.Property(e => e.Coltype10).HasColumnName("COLTYPE10");

                entity.Property(e => e.Coltype11).HasColumnName("COLTYPE11");

                entity.Property(e => e.Coltype12).HasColumnName("COLTYPE12");

                entity.Property(e => e.Coltype13).HasColumnName("COLTYPE13");

                entity.Property(e => e.Coltype14).HasColumnName("COLTYPE14");

                entity.Property(e => e.Coltype2).HasColumnName("COLTYPE2");

                entity.Property(e => e.Coltype3).HasColumnName("COLTYPE3");

                entity.Property(e => e.Coltype4).HasColumnName("COLTYPE4");

                entity.Property(e => e.Coltype5).HasColumnName("COLTYPE5");

                entity.Property(e => e.Coltype6).HasColumnName("COLTYPE6");

                entity.Property(e => e.Coltype7).HasColumnName("COLTYPE7");

                entity.Property(e => e.Coltype8).HasColumnName("COLTYPE8");

                entity.Property(e => e.Coltype9).HasColumnName("COLTYPE9");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Restype).HasColumnName("RESTYPE");

                entity.Property(e => e.Rowformula).HasColumnName("ROWFORMULA");

                entity.Property(e => e.Sortpref).HasColumnName("SORTPREF");

                entity.Property(e => e.Tablepref).HasColumnName("TABLEPREF");

                entity.Property(e => e.Templateid).HasColumnName("TEMPLATEID");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Ratebuildupcols)
                    .HasForeignKey(d => d.Templateid)
                    .HasConstraintName("FKB7E836FC9A9C964D");
            });

            modelBuilder.Entity<Ratedistrib>(entity =>
            {
                entity.ToTable("RATEDISTRIB");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.HasIndex(e => e.Templateid)
                    .HasName("IDX_PROJECTTEMPLATE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Balanced).HasColumnName("BALANCED");

                entity.Property(e => e.Cellx).HasColumnName("CELLX");

                entity.Property(e => e.Celly).HasColumnName("CELLY");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Distranges).HasColumnName("DISTRANGES");

                entity.Property(e => e.Distrates).HasColumnName("DISTRATES");

                entity.Property(e => e.Disttype).HasColumnName("DISTTYPE");

                entity.Property(e => e.Dstrbtd).HasColumnName("DSTRBTD");

                entity.Property(e => e.Mapped).HasColumnName("MAPPED");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Sheetno).HasColumnName("SHEETNO");

                entity.Property(e => e.Sortorder).HasColumnName("SORTORDER");

                entity.Property(e => e.Stovalnum)
                    .HasColumnName("STOVALNUM")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Targetcostfield)
                    .HasColumnName("TARGETCOSTFIELD")
                    .HasMaxLength(255);

                entity.Property(e => e.Targetfield)
                    .HasColumnName("TARGETFIELD")
                    .HasMaxLength(255);

                entity.Property(e => e.Templateid).HasColumnName("TEMPLATEID");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Ratedistrib)
                    .HasForeignKey(d => d.Templateid)
                    .HasConstraintName("FKEC7F0CA59A9C964D");
            });

            modelBuilder.Entity<Rawmaterial>(entity =>
            {
                entity.HasKey(e => e.Rawmatid)
                    .HasName("PK__RAWMATER__3C967267CC786019");

                entity.ToTable("RAWMATERIAL");

                entity.HasIndex(e => e.Code)
                    .HasName("IDX_CODE");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.HasIndex(e => e.RateDate)
                    .HasName("IDX_RATEDATE");

                entity.Property(e => e.Rawmatid).HasColumnName("RAWMATID");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.RateDate).HasColumnName("RATE_DATE");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");
            });

            modelBuilder.Entity<Subcontractor>(entity =>
            {
                entity.ToTable("SUBCONTRACTOR");

                entity.HasIndex(e => e.Databaseid)
                    .HasName("IDX_MDBID");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Subcontractorid).HasColumnName("SUBCONTRACTORID");

                entity.Property(e => e.Accrights)
                    .HasColumnName("ACCRIGHTS")
                    .HasMaxLength(255);

                entity.Property(e => e.Accuracy)
                    .HasColumnName("ACCURACY")
                    .HasMaxLength(255);

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(255);

                entity.Property(e => e.Burate)
                    .HasColumnName("BURATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.City)
                    .HasColumnName("CITY")
                    .HasMaxLength(255);

                entity.Property(e => e.Company)
                    .HasColumnName("COMPANY")
                    .HasMaxLength(255);

                entity.Property(e => e.Conceptual).HasColumnName("CONCEPTUAL");

                entity.Property(e => e.Contactperson)
                    .HasColumnName("CONTACTPERSON")
                    .HasMaxLength(255);

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Createdate).HasColumnName("CREATEDATE");

                entity.Property(e => e.Createuser)
                    .HasColumnName("CREATEUSER")
                    .HasMaxLength(255);

                entity.Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasMaxLength(255);

                entity.Property(e => e.Databasecreationdate).HasColumnName("DATABASECREATIONDATE");

                entity.Property(e => e.Databaseid).HasColumnName("DATABASEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode1)
                    .HasColumnName("EXTRACODE1")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode10)
                    .HasColumnName("EXTRACODE10")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode2)
                    .HasColumnName("EXTRACODE2")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode3)
                    .HasColumnName("EXTRACODE3")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode4)
                    .HasColumnName("EXTRACODE4")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode5)
                    .HasColumnName("EXTRACODE5")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode6)
                    .HasColumnName("EXTRACODE6")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode7)
                    .HasColumnName("EXTRACODE7")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode8)
                    .HasColumnName("EXTRACODE8")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode9)
                    .HasColumnName("EXTRACODE9")
                    .HasMaxLength(255);

                entity.Property(e => e.Faxnumber)
                    .HasColumnName("FAXNUMBER")
                    .HasMaxLength(255);

                entity.Property(e => e.Gekcode)
                    .HasColumnName("GEKCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Ika)
                    .HasColumnName("IKA")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Inclusion)
                    .HasColumnName("INCLUSION")
                    .HasMaxLength(255);

                entity.Property(e => e.Keyw).HasColumnName("KEYW");

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Matrate)
                    .HasColumnName("MATRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Mobilenumber)
                    .HasColumnName("MOBILENUMBER")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255);

                entity.Property(e => e.Overtype).HasColumnName("OVERTYPE");

                entity.Property(e => e.Performance)
                    .HasColumnName("PERFORMANCE")
                    .HasMaxLength(255);

                entity.Property(e => e.Phonenumber)
                    .HasColumnName("PHONENUMBER")
                    .HasMaxLength(255);

                entity.Property(e => e.Predicted).HasColumnName("PREDICTED");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Project)
                    .HasColumnName("PROJECT")
                    .HasMaxLength(255);

                entity.Property(e => e.Qty)
                    .HasColumnName("QTY")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Rescode)
                    .HasColumnName("RESCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Stateprovince)
                    .HasColumnName("STATEPROVINCE")
                    .HasMaxLength(255);

                entity.Property(e => e.Tchtype).HasColumnName("TCHTYPE");

                entity.Property(e => e.Tcolor).HasColumnName("TCOLOR");

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Totalrate)
                    .HasColumnName("TOTALRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Trdate).HasColumnName("TRDATE");

                entity.Property(e => e.Tregtype).HasColumnName("TREGTYPE");

                entity.Property(e => e.Trids).HasColumnName("TRIDS");

                entity.Property(e => e.Tunit)
                    .HasColumnName("TUNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Tval)
                    .HasColumnName("TVAL")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(255);

                entity.Property(e => e.Virtual).HasColumnName("VIRTUAL");
            });

            modelBuilder.Entity<Subhistory>(entity =>
            {
                entity.ToTable("SUBHISTORY");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.HasIndex(e => e.Subcontractorid)
                    .HasName("IDX_SUBCONTRACTOR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Basetableid)
                    .HasColumnName("BASETABLEID")
                    .HasMaxLength(255);

                entity.Property(e => e.Preddate).HasColumnName("PREDDATE");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Rsrc).HasColumnName("RSRC");

                entity.Property(e => e.Subcontractorid).HasColumnName("SUBCONTRACTORID");

                entity.HasOne(d => d.Subcontractor)
                    .WithMany(p => p.Subhistory)
                    .HasForeignKey(d => d.Subcontractorid)
                    .HasConstraintName("FK98A18A547C0276B4");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("SUPPLIER");

                entity.HasIndex(e => e.Databaseid)
                    .HasName("IDX_MDBID");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.HasIndex(e => e.Title)
                    .HasName("IDX_TITLE");

                entity.Property(e => e.Supplierid).HasColumnName("SUPPLIERID");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(255);

                entity.Property(e => e.City)
                    .HasColumnName("CITY")
                    .HasMaxLength(255);

                entity.Property(e => e.Contactperson)
                    .HasColumnName("CONTACTPERSON")
                    .HasMaxLength(255);

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Createdate).HasColumnName("CREATEDATE");

                entity.Property(e => e.Createuser)
                    .HasColumnName("CREATEUSER")
                    .HasMaxLength(255);

                entity.Property(e => e.Databasecreationdate).HasColumnName("DATABASECREATIONDATE");

                entity.Property(e => e.Databaseid).HasColumnName("DATABASEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode1)
                    .IsRequired()
                    .HasColumnName("EXTRACODE1")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode10)
                    .IsRequired()
                    .HasColumnName("EXTRACODE10")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode2)
                    .IsRequired()
                    .HasColumnName("EXTRACODE2")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode3)
                    .IsRequired()
                    .HasColumnName("EXTRACODE3")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode4)
                    .IsRequired()
                    .HasColumnName("EXTRACODE4")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode5)
                    .IsRequired()
                    .HasColumnName("EXTRACODE5")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode6)
                    .IsRequired()
                    .HasColumnName("EXTRACODE6")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode7)
                    .IsRequired()
                    .HasColumnName("EXTRACODE7")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode8)
                    .IsRequired()
                    .HasColumnName("EXTRACODE8")
                    .HasMaxLength(255);

                entity.Property(e => e.Extracode9)
                    .IsRequired()
                    .HasColumnName("EXTRACODE9")
                    .HasMaxLength(255);

                entity.Property(e => e.Faxnumber)
                    .HasColumnName("FAXNUMBER")
                    .HasMaxLength(255);

                entity.Property(e => e.Gekcode)
                    .HasColumnName("GEKCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Geoloc)
                    .HasColumnName("GEOLOC")
                    .HasMaxLength(255);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Mobilenumber)
                    .HasColumnName("MOBILENUMBER")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255);

                entity.Property(e => e.Performance)
                    .HasColumnName("PERFORMANCE")
                    .HasMaxLength(255);

                entity.Property(e => e.Phonenumber)
                    .HasColumnName("PHONENUMBER")
                    .HasMaxLength(255);

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Rescode)
                    .HasColumnName("RESCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Stateprovince)
                    .HasColumnName("STATEPROVINCE")
                    .HasMaxLength(255);

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Wscolident>(entity =>
            {
                entity.ToTable("WSCOLIDENT");

                entity.HasIndex(e => e.Mappingid)
                    .HasName("IDX_WSDATAMAPPING");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Colindex).HasColumnName("COLINDEX");

                entity.Property(e => e.Coltype).HasColumnName("COLTYPE");

                entity.Property(e => e.Exauma).HasColumnName("EXAUMA");

                entity.Property(e => e.Fieldmap).HasColumnName("FIELDMAP");

                entity.Property(e => e.Fileprefix).HasColumnName("FILEPREFIX");

                entity.Property(e => e.Fldname)
                    .HasColumnName("FLDNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Fldtype).HasColumnName("FLDTYPE");

                entity.Property(e => e.Mapaction).HasColumnName("MAPACTION");

                entity.Property(e => e.Mappingid).HasColumnName("MAPPINGID");

                entity.Property(e => e.Munique).HasColumnName("MUNIQUE");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Sheetprefix).HasColumnName("SHEETPREFIX");

                entity.Property(e => e.Splitfield)
                    .HasColumnName("SPLITFIELD")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Mapping)
                    .WithMany(p => p.Wscolident)
                    .HasForeignKey(d => d.Mappingid)
                    .HasConstraintName("FK1FF56F4CBCB673A4");
            });

            modelBuilder.Entity<Wsdatamapping>(entity =>
            {
                entity.ToTable("WSDATAMAPPING");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Celldtingn).HasColumnName("CELLDTINGN");

                entity.Property(e => e.Commentdetect).HasColumnName("COMMENTDETECT");

                entity.Property(e => e.Groupcol).HasColumnName("GROUPCOL");

                entity.Property(e => e.Keepitems).HasColumnName("KEEPITEMS");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Tableprefer).HasColumnName("TABLEPREFER");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255);

                entity.Property(e => e.Treedetect).HasColumnName("TREEDETECT");

                entity.Property(e => e.Treemapping).HasColumnName("TREEMAPPING");

                entity.Property(e => e.Xcellfile).HasColumnName("XCELLFILE");
            });

            modelBuilder.Entity<Wsfile>(entity =>
            {
                entity.ToTable("WSFILE");

                entity.HasIndex(e => e.Filerevid)
                    .HasName("IDX_WSREVISION");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Actsheets).HasColumnName("ACTSHEETS");

                entity.Property(e => e.Filerevid).HasColumnName("FILEREVID");

                entity.Property(e => e.Findex).HasColumnName("FINDEX");

                entity.Property(e => e.Fpath)
                    .HasColumnName("FPATH")
                    .HasMaxLength(255);

                entity.Property(e => e.Numsheets).HasColumnName("NUMSHEETS");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Tcmfile).HasColumnName("TCMFILE");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255);

                entity.Property(e => e.Xcellfile).HasColumnName("XCELLFILE");

                entity.Property(e => e.Xmlfile).HasColumnName("XMLFILE");

                entity.HasOne(d => d.Filerev)
                    .WithMany(p => p.Wsfile)
                    .HasForeignKey(d => d.Filerevid)
                    .HasConstraintName("FK99282A5859F4EE84");
            });

            modelBuilder.Entity<Wsrevision>(entity =>
            {
                entity.ToTable("WSREVISION");

                entity.HasIndex(e => e.Mappingid)
                    .HasName("IDX_WSDATAMAPPING");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Createdate).HasColumnName("CREATEDATE");

                entity.Property(e => e.Createuserid)
                    .HasColumnName("CREATEUSERID")
                    .HasMaxLength(255);

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Mappingid).HasColumnName("MAPPINGID");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Selected).HasColumnName("SELECTED");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Mapping)
                    .WithMany(p => p.Wsrevision)
                    .HasForeignKey(d => d.Mappingid)
                    .HasConstraintName("FK364016B7BCB673A4");
            });

            modelBuilder.Entity<Xcellfile>(entity =>
            {
                entity.HasKey(e => e.Xcellid)
                    .HasName("PK__XCELLFIL__C594AC250ADFE194");

                entity.ToTable("XCELLFILE");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Xcellid).HasColumnName("XCELLID");

                entity.Property(e => e.Cellx).HasColumnName("CELLX");

                entity.Property(e => e.Celly).HasColumnName("CELLY");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.Sheet).HasColumnName("SHEET");

                entity.Property(e => e.Xcellfile1).HasColumnName("XCELLFILE");
            });

            modelBuilder.Entity<Xchangerate>(entity =>
            {
                entity.ToTable("XCHANGERATE");

                entity.HasIndex(e => e.FromCurrency)
                    .HasName("IDX_FROMCUR");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.HasIndex(e => e.RateDate)
                    .HasName("IDX_RATEDATE");

                entity.HasIndex(e => e.ToCurrency)
                    .HasName("IDX_TOCUR");

                entity.Property(e => e.Xchangerateid).HasColumnName("XCHANGERATEID");

                entity.Property(e => e.FromCurrency)
                    .HasColumnName("FROM_CURRENCY")
                    .HasMaxLength(255);

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.RateDate).HasColumnName("RATE_DATE");

                entity.Property(e => e.RefId).HasColumnName("REF__ID");

                entity.Property(e => e.ToCurrency)
                    .HasColumnName("TO_CURRENCY")
                    .HasMaxLength(255);
            });
        }
    }
}
