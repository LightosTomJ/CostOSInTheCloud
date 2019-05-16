using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Models
{
    public partial class CostOSContext : DbContext
    {
        public CostOSContext()
        {
        }

        public CostOSContext(DbContextOptions<CostOSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assembly> Assembly { get; set; }
        public virtual DbSet<AssemblyChild> AssemblyChild { get; set; }
        public virtual DbSet<AssemblyConsumable> AssemblyConsumable { get; set; }
        public virtual DbSet<AssemblyEquipment> AssemblyEquipment { get; set; }
        public virtual DbSet<AssemblyHhistory> AssemblyHhistory { get; set; }
        public virtual DbSet<AssemblyLabor> AssemblyLabor { get; set; }
        public virtual DbSet<AssemblyMaterial> AssemblyMaterial { get; set; }
        public virtual DbSet<AssemblySubcontractor> AssemblySubcontractor { get; set; }
        public virtual DbSet<BoQitem> BoQitem { get; set; }
        public virtual DbSet<BoQitemAssembly> BoQitemAssembly { get; set; }
        public virtual DbSet<BoQitemCondition> BoQitemCondition { get; set; }
        public virtual DbSet<BoQitemConsumable> BoQitemConsumable { get; set; }
        public virtual DbSet<BoQitemEquipment> BoQitemEquipment { get; set; }
        public virtual DbSet<BoQitemLlabor> BoQitemLlabor { get; set; }
        public virtual DbSet<BoQitemMaterial> BoQitemMaterial { get; set; }
        public virtual DbSet<BoQitemSubcontractor> BoQitemSubcontractor { get; set; }
        public virtual DbSet<Cndon> Cndon { get; set; }
        public virtual DbSet<CnmHistory> CnmHistory { get; set; }
        public virtual DbSet<Conceptuals> Conceptuals { get; set; }
        public virtual DbSet<Consumable> Consumable { get; set; }
        public virtual DbSet<EquHistory> EquHistory { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<ExchangeRate> ExchangeRate { get; set; }
        public virtual DbSet<Expenses> Expenses { get; set; }
        public virtual DbSet<ExtraCode1> ExtraCode1 { get; set; }
        public virtual DbSet<ExtraCode10> ExtraCode10 { get; set; }
        public virtual DbSet<ExtraCode2> ExtraCode2 { get; set; }
        public virtual DbSet<ExtraCode3> ExtraCode3 { get; set; }
        public virtual DbSet<ExtraCode4> ExtraCode4 { get; set; }
        public virtual DbSet<ExtraCode5> ExtraCode5 { get; set; }
        public virtual DbSet<ExtraCode6> ExtraCode6 { get; set; }
        public virtual DbSet<ExtraCode7> ExtraCode7 { get; set; }
        public virtual DbSet<ExtraCode8> ExtraCode8 { get; set; }
        public virtual DbSet<ExtraCode9> ExtraCode9 { get; set; }
        public virtual DbSet<FieldCustom> FieldCustom { get; set; }
        public virtual DbSet<Filtro> Filtro { get; set; }
        public virtual DbSet<FiltroProperty> FiltroProperty { get; set; }
        public virtual DbSet<FldFn> FldFn { get; set; }
        public virtual DbSet<Fncton> Fncton { get; set; }
        public virtual DbSet<FnctonArgument> FnctonArgument { get; set; }
        public virtual DbSet<Gekcode> Gekcode { get; set; }
        public virtual DbSet<GlbProp> GlbProp { get; set; }
        public virtual DbSet<GroupCode> GroupCode { get; set; }
        public virtual DbSet<LabHistory> LabHistory { get; set; }
        public virtual DbSet<Labor> Labor { get; set; }
        public virtual DbSet<LayoutC> LayoutC { get; set; }
        public virtual DbSet<LayoutCpanel> LayoutCpanel { get; set; }
        public virtual DbSet<LocFactor> LocFactor { get; set; }
        public virtual DbSet<LocProf> LocProf { get; set; }
        public virtual DbSet<MatHistory> MatHistory { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<OstDbcon> OstDbcon { get; set; }
        public virtual DbSet<ParamCondition> ParamCondition { get; set; }
        public virtual DbSet<ParamInput> ParamInput { get; set; }
        public virtual DbSet<ParamItem> ParamItem { get; set; }
        public virtual DbSet<ParamOutput> ParamOutput { get; set; }
        public virtual DbSet<ParamReturn> ParamReturn { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PrjProp> PrjProp { get; set; }
        public virtual DbSet<ProjectAccess> ProjectAccess { get; set; }
        public virtual DbSet<ProjectEps> ProjectEps { get; set; }
        public virtual DbSet<ProjectInfo> ProjectInfo { get; set; }
        public virtual DbSet<ProjectUrl> ProjectUrl { get; set; }
        public virtual DbSet<ProjectUser> ProjectUser { get; set; }
        public virtual DbSet<ProjectWbs> ProjectWbs { get; set; }
        public virtual DbSet<ProjectWbs2> ProjectWbs2 { get; set; }
        public virtual DbSet<QueryResource> QueryResource { get; set; }
        public virtual DbSet<QueryRow> QueryRow { get; set; }
        public virtual DbSet<Quote> Quote { get; set; }
        public virtual DbSet<QuoteItem> QuoteItem { get; set; }
        public virtual DbSet<RawMaterial> RawMaterial { get; set; }
        public virtual DbSet<Rpdfn> Rpdfn { get; set; }
        public virtual DbSet<SubHistory> SubHistory { get; set; }
        public virtual DbSet<Subcontractor> Subcontractor { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<TakeOffArea> TakeOffArea { get; set; }
        public virtual DbSet<TakeOffCon> TakeOffCon { get; set; }
        public virtual DbSet<TakeOffLine> TakeOffLine { get; set; }
        public virtual DbSet<TakeOffPoint> TakeOffPoint { get; set; }
        public virtual DbSet<TakeOffTriangle> TakeOffTriangle { get; set; }
        public virtual DbSet<UnitAlias> UnitAlias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectsV13;Database=CostOS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Assembly>(entity =>
            {
                entity.Property(e => e.Assemblyid).HasColumnName("ASSEMBLYID");

                entity.Property(e => e.Accrights)
                    .HasColumnName("ACCRIGHTS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Accuracy)
                    .HasColumnName("ACCURACY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Actbased).HasColumnName("ACTBASED");

                entity.Property(e => e.Bimmaterial).HasColumnName("BIMMATERIAL");

                entity.Property(e => e.Bimtype)
                    .HasColumnName("BIMTYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Conrate)
                    .HasColumnName("CONRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Createdate)
                    .HasColumnName("CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Createuser)
                    .HasColumnName("CREATEUSER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Custxt1)
                    .HasColumnName("CUSTXT1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Custxt10)
                    .HasColumnName("CUSTXT10")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Custxt11)
                    .HasColumnName("CUSTXT11")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Custxt12)
                    .HasColumnName("CUSTXT12")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Custxt13)
                    .HasColumnName("CUSTXT13")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Custxt14)
                    .HasColumnName("CUSTXT14")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Custxt15)
                    .HasColumnName("CUSTXT15")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Custxt16)
                    .HasColumnName("CUSTXT16")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Custxt17)
                    .HasColumnName("CUSTXT17")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Custxt18)
                    .HasColumnName("CUSTXT18")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Custxt19)
                    .HasColumnName("CUSTXT19")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Custxt2)
                    .HasColumnName("CUSTXT2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Custxt20)
                    .HasColumnName("CUSTXT20")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Custxt3)
                    .HasColumnName("CUSTXT3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Custxt4)
                    .HasColumnName("CUSTXT4")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Custxt5)
                    .HasColumnName("CUSTXT5")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Custxt6)
                    .HasColumnName("CUSTXT6")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Custxt7)
                    .HasColumnName("CUSTXT7")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Custxt8)
                    .HasColumnName("CUSTXT8")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Custxt9)
                    .HasColumnName("CUSTXT9")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Databasecreationdate).HasColumnName("DATABASECREATIONDATE");

                entity.Property(e => e.Databaseid).HasColumnName("DATABASEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Equrate)
                    .HasColumnName("EQURATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Extracode1)
                    .HasColumnName("EXTRACODE1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode10)
                    .IsRequired()
                    .HasColumnName("EXTRACODE10")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode2)
                    .IsRequired()
                    .HasColumnName("EXTRACODE2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode3)
                    .IsRequired()
                    .HasColumnName("EXTRACODE3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode4)
                    .IsRequired()
                    .HasColumnName("EXTRACODE4")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode5)
                    .IsRequired()
                    .HasColumnName("EXTRACODE5")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode6)
                    .IsRequired()
                    .HasColumnName("EXTRACODE6")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode7)
                    .IsRequired()
                    .HasColumnName("EXTRACODE7")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode8)
                    .IsRequired()
                    .HasColumnName("EXTRACODE8")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode9)
                    .IsRequired()
                    .HasColumnName("EXTRACODE9")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gekcode)
                    .HasColumnName("GEKCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Keyw).HasColumnName("KEYW");

                entity.Property(e => e.Labrate)
                    .HasColumnName("LABRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Matrate)
                    .HasColumnName("MATRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Productivity)
                    .HasColumnName("PRODUCTIVITY")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Project)
                    .HasColumnName("PROJECT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Publishedcode)
                    .HasColumnName("PUBLISHEDCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Publishedrate)
                    .HasColumnName("PUBLISHEDRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Qty)
                    .HasColumnName("QTY")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Stateprovince)
                    .HasColumnName("STATEPROVINCE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Subrate)
                    .HasColumnName("SUBRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Uehours)
                    .HasColumnName("UEHOURS")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Umhours)
                    .HasColumnName("UMHOURS")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Virtual).HasColumnName("VIRTUAL");

                entity.Property(e => e.Virtualcon).HasColumnName("VIRTUALCON");

                entity.Property(e => e.Virtualequ).HasColumnName("VIRTUALEQU");

                entity.Property(e => e.Virtuallab).HasColumnName("VIRTUALLAB");

                entity.Property(e => e.Virtualmat).HasColumnName("VIRTUALMAT");

                entity.Property(e => e.Virtualsub).HasColumnName("VIRTUALSUB");
            });

            modelBuilder.Entity<AssemblyChild>(entity =>
            {
                entity.Property(e => e.Assemblychildid).HasColumnName("ASSEMBLYCHILDID");

                entity.Property(e => e.Assemblyid).HasColumnName("ASSEMBLYID");

                entity.Property(e => e.Childid).HasColumnName("CHILDID");

                entity.Property(e => e.Divider)
                    .HasColumnName("DIVIDER")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Exchangerate)
                    .HasColumnName("EXCHANGERATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("decimal(30, 10)");
            });

            modelBuilder.Entity<AssemblyConsumable>(entity =>
            {
                entity.Property(e => e.Assemblyconsumableid).HasColumnName("ASSEMBLYCONSUMABLEID");

                entity.Property(e => e.Assemblyid).HasColumnName("ASSEMBLYID");

                entity.Property(e => e.Consumableid).HasColumnName("CONSUMABLEID");

                entity.Property(e => e.Divider)
                    .HasColumnName("DIVIDER")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Exchangerate)
                    .HasColumnName("EXCHANGERATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("decimal(30, 10)");

                entity.HasOne(d => d.Assembly)
                    .WithMany(p => p.AssemblyConsumable)
                    .HasForeignKey(d => d.Assemblyid)
                    .HasConstraintName("FKAssemblyConsumable1");

                entity.HasOne(d => d.Consumable)
                    .WithMany(p => p.AssemblyConsumable)
                    .HasForeignKey(d => d.Consumableid)
                    .HasConstraintName("FKAssemblyConsumable2");
            });

            modelBuilder.Entity<AssemblyEquipment>(entity =>
            {
                entity.Property(e => e.Assemblyequipmentid).HasColumnName("ASSEMBLYEQUIPMENTID");

                entity.Property(e => e.Assemblyid).HasColumnName("ASSEMBLYID");

                entity.Property(e => e.Energyprice)
                    .HasColumnName("ENERGYPRICE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Equipmentid).HasColumnName("EQUIPMENTID");

                entity.Property(e => e.Exchangerate)
                    .HasColumnName("EXCHANGERATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor3)
                    .HasColumnName("FACTOR3")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Fdeprate)
                    .HasColumnName("FDEPRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Finalfuelrate)
                    .HasColumnName("FINALFUELRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Fuelrate)
                    .HasColumnName("FUELRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("decimal(30, 10)");

                entity.HasOne(d => d.Assembly)
                    .WithMany(p => p.AssemblyEquipment)
                    .HasForeignKey(d => d.Assemblyid)
                    .HasConstraintName("FKAssemblyEquipment1");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.AssemblyEquipment)
                    .HasForeignKey(d => d.Equipmentid)
                    .HasConstraintName("FKAssemblyEquipment2");
            });

            modelBuilder.Entity<AssemblyHhistory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Assemblyid).HasColumnName("ASSEMBLYID");

                entity.Property(e => e.Assemlbyid).HasColumnName("ASSEMLBYID");

                entity.Property(e => e.Basetableid)
                    .HasColumnName("BASETABLEID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Preddate)
                    .HasColumnName("PREDDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Resource).HasColumnName("RESOURCE");

                entity.Property(e => e.Rsrc).HasColumnName("RSRC");

                entity.HasOne(d => d.Assembly)
                    .WithMany(p => p.AssemblyHhistoryAssembly)
                    .HasForeignKey(d => d.Assemblyid)
                    .HasConstraintName("FKAssHistory1");

                entity.HasOne(d => d.Assemlby)
                    .WithMany(p => p.AssemblyHhistoryAssemlby)
                    .HasForeignKey(d => d.Assemlbyid)
                    .HasConstraintName("FKAssHistory2");
            });

            modelBuilder.Entity<AssemblyLabor>(entity =>
            {
                entity.Property(e => e.Assemblylaborid).HasColumnName("ASSEMBLYLABORID");

                entity.Property(e => e.Assemblyid).HasColumnName("ASSEMBLYID");

                entity.Property(e => e.Exchangerate)
                    .HasColumnName("EXCHANGERATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor3)
                    .HasColumnName("FACTOR3")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Fikarate)
                    .HasColumnName("FIKARATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Laborid).HasColumnName("LABORID");

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("decimal(30, 10)");

                entity.HasOne(d => d.Assembly)
                    .WithMany(p => p.AssemblyLabor)
                    .HasForeignKey(d => d.Assemblyid)
                    .HasConstraintName("FKAssemblyLabor1");

                entity.HasOne(d => d.Labor)
                    .WithMany(p => p.AssemblyLabor)
                    .HasForeignKey(d => d.Laborid)
                    .HasConstraintName("FKAssemblyLabor2");
            });

            modelBuilder.Entity<AssemblyMaterial>(entity =>
            {
                entity.Property(e => e.Assemblymaterialid).HasColumnName("ASSEMBLYMATERIALID");

                entity.Property(e => e.Assemblyid).HasColumnName("ASSEMBLYID");

                entity.Property(e => e.Divider)
                    .HasColumnName("DIVIDER")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Exchangerate)
                    .HasColumnName("EXCHANGERATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Materialid).HasColumnName("MATERIALID");

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("decimal(30, 10)");

                entity.HasOne(d => d.Assembly)
                    .WithMany(p => p.AssemblyMaterial)
                    .HasForeignKey(d => d.Assemblyid)
                    .HasConstraintName("FKAssemblyMaterial1");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.AssemblyMaterial)
                    .HasForeignKey(d => d.Materialid)
                    .HasConstraintName("FKAssemblyMaterial2");
            });

            modelBuilder.Entity<AssemblySubcontractor>(entity =>
            {
                entity.Property(e => e.Assemblysubcontractorid).HasColumnName("ASSEMBLYSUBCONTRACTORID");

                entity.Property(e => e.Assemblyid).HasColumnName("ASSEMBLYID");

                entity.Property(e => e.Exchangerate)
                    .HasColumnName("EXCHANGERATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor3)
                    .HasColumnName("FACTOR3")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Fikarate)
                    .HasColumnName("FIKARATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Subcontractorid).HasColumnName("SUBCONTRACTORID");

                entity.HasOne(d => d.Assembly)
                    .WithMany(p => p.AssemblySubcontractor)
                    .HasForeignKey(d => d.Assemblyid)
                    .HasConstraintName("FKAssemblySubcontractor1");

                entity.HasOne(d => d.Subcontractor)
                    .WithMany(p => p.AssemblySubcontractor)
                    .HasForeignKey(d => d.Subcontractorid)
                    .HasConstraintName("FKAssemblySubcontractor2");
            });

            modelBuilder.Entity<BoQitem>(entity =>
            {
                entity.ToTable("BoQItem");

                entity.Property(e => e.Boqitemid).HasColumnName("BOQITEMID");

                entity.Property(e => e.Accuracy)
                    .HasColumnName("ACCURACY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Actbased).HasColumnName("ACTBASED");

                entity.Property(e => e.Activityid)
                    .HasColumnName("ACTIVITYID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Adjprod)
                    .HasColumnName("ADJPROD")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Adjprodform).HasColumnName("ADJPRODFORM");

                entity.Property(e => e.Asrt).HasColumnName("ASRT");

                entity.Property(e => e.Asscost)
                    .HasColumnName("ASSCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Assrate)
                    .HasColumnName("ASSRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Asstotalform).HasColumnName("ASSTOTALFORM");

                entity.Property(e => e.Aumhform).HasColumnName("AUMHFORM");

                entity.Property(e => e.Aunitmhours)
                    .HasColumnName("AUNITMHOURS")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.CalculatedRate)
                    .HasColumnName("CALCULATED_RATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.CalculatedTotalCost)
                    .HasColumnName("CALCULATED_TOTAL_COST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cmrt).HasColumnName("CMRT");

                entity.Property(e => e.Cnqt).HasColumnName("CNQT");

                entity.Property(e => e.Code).HasColumnName("CODE");

                entity.Property(e => e.Concost)
                    .HasColumnName("CONCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Conrate)
                    .HasColumnName("CONRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Contotalform).HasColumnName("CONTOTALFORM");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Createuserid)
                    .HasColumnName("CREATEUSERID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cuscum1form).HasColumnName("CUSCUM1FORM");

                entity.Property(e => e.Cuscum2form).HasColumnName("CUSCUM2FORM");

                entity.Property(e => e.Cuscum3form).HasColumnName("CUSCUM3FORM");

                entity.Property(e => e.Cuscum4form).HasColumnName("CUSCUM4FORM");

                entity.Property(e => e.Cuscum5form).HasColumnName("CUSCUM5FORM");

                entity.Property(e => e.Cuscumrate1)
                    .HasColumnName("CUSCUMRATE1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cuscumrate2)
                    .HasColumnName("CUSCUMRATE2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cuscumrate3)
                    .HasColumnName("CUSCUMRATE3")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cuscumrate4)
                    .HasColumnName("CUSCUMRATE4")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cuscumrate5)
                    .HasColumnName("CUSCUMRATE5")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cusper1)
                    .HasColumnName("CUSPER1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cusper10)
                    .HasColumnName("CUSPER10")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cusper10form).HasColumnName("CUSPER10FORM");

                entity.Property(e => e.Cusper1form).HasColumnName("CUSPER1FORM");

                entity.Property(e => e.Cusper2)
                    .HasColumnName("CUSPER2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cusper2form).HasColumnName("CUSPER2FORM");

                entity.Property(e => e.Cusper3)
                    .HasColumnName("CUSPER3")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cusper3form).HasColumnName("CUSPER3FORM");

                entity.Property(e => e.Cusper4)
                    .HasColumnName("CUSPER4")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cusper4form).HasColumnName("CUSPER4FORM");

                entity.Property(e => e.Cusper5)
                    .HasColumnName("CUSPER5")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cusper5form).HasColumnName("CUSPER5FORM");

                entity.Property(e => e.Cusper6)
                    .HasColumnName("CUSPER6")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cusper6form).HasColumnName("CUSPER6FORM");

                entity.Property(e => e.Cusper7)
                    .HasColumnName("CUSPER7")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cusper7form).HasColumnName("CUSPER7FORM");

                entity.Property(e => e.Cusper8)
                    .HasColumnName("CUSPER8")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cusper8form).HasColumnName("CUSPER8FORM");

                entity.Property(e => e.Cusper9)
                    .HasColumnName("CUSPER9")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cusper9form).HasColumnName("CUSPER9FORM");

                entity.Property(e => e.Cusrate1)
                    .HasColumnName("CUSRATE1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cusrate10)
                    .HasColumnName("CUSRATE10")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cusrate10form).HasColumnName("CUSRATE10FORM");

                entity.Property(e => e.Cusrate1form).HasColumnName("CUSRATE1FORM");

                entity.Property(e => e.Cusrate2)
                    .HasColumnName("CUSRATE2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cusrate2form).HasColumnName("CUSRATE2FORM");

                entity.Property(e => e.Cusrate3)
                    .HasColumnName("CUSRATE3")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cusrate3form).HasColumnName("CUSRATE3FORM");

                entity.Property(e => e.Cusrate4)
                    .HasColumnName("CUSRATE4")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cusrate4form).HasColumnName("CUSRATE4FORM");

                entity.Property(e => e.Cusrate5)
                    .HasColumnName("CUSRATE5")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cusrate5form).HasColumnName("CUSRATE5FORM");

                entity.Property(e => e.Cusrate6)
                    .HasColumnName("CUSRATE6")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cusrate6form).HasColumnName("CUSRATE6FORM");

                entity.Property(e => e.Cusrate7)
                    .HasColumnName("CUSRATE7")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cusrate7form).HasColumnName("CUSRATE7FORM");

                entity.Property(e => e.Cusrate8)
                    .HasColumnName("CUSRATE8")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cusrate8form).HasColumnName("CUSRATE8FORM");

                entity.Property(e => e.Cusrate9)
                    .HasColumnName("CUSRATE9")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Cusrate9form).HasColumnName("CUSRATE9FORM");

                entity.Property(e => e.Custxt1).HasColumnName("CUSTXT1");

                entity.Property(e => e.Custxt10).HasColumnName("CUSTXT10");

                entity.Property(e => e.Custxt10form).HasColumnName("CUSTXT10FORM");

                entity.Property(e => e.Custxt11).HasColumnName("CUSTXT11");

                entity.Property(e => e.Custxt11form).HasColumnName("CUSTXT11FORM");

                entity.Property(e => e.Custxt12).HasColumnName("CUSTXT12");

                entity.Property(e => e.Custxt12form).HasColumnName("CUSTXT12FORM");

                entity.Property(e => e.Custxt13).HasColumnName("CUSTXT13");

                entity.Property(e => e.Custxt13form).HasColumnName("CUSTXT13FORM");

                entity.Property(e => e.Custxt14).HasColumnName("CUSTXT14");

                entity.Property(e => e.Custxt14form).HasColumnName("CUSTXT14FORM");

                entity.Property(e => e.Custxt15).HasColumnName("CUSTXT15");

                entity.Property(e => e.Custxt15form).HasColumnName("CUSTXT15FORM");

                entity.Property(e => e.Custxt16).HasColumnName("CUSTXT16");

                entity.Property(e => e.Custxt16form).HasColumnName("CUSTXT16FORM");

                entity.Property(e => e.Custxt17).HasColumnName("CUSTXT17");

                entity.Property(e => e.Custxt17form).HasColumnName("CUSTXT17FORM");

                entity.Property(e => e.Custxt18).HasColumnName("CUSTXT18");

                entity.Property(e => e.Custxt18form).HasColumnName("CUSTXT18FORM");

                entity.Property(e => e.Custxt19).HasColumnName("CUSTXT19");

                entity.Property(e => e.Custxt19form).HasColumnName("CUSTXT19FORM");

                entity.Property(e => e.Custxt1form).HasColumnName("CUSTXT1FORM");

                entity.Property(e => e.Custxt2).HasColumnName("CUSTXT2");

                entity.Property(e => e.Custxt20).HasColumnName("CUSTXT20");

                entity.Property(e => e.Custxt20form).HasColumnName("CUSTXT20FORM");

                entity.Property(e => e.Custxt2form).HasColumnName("CUSTXT2FORM");

                entity.Property(e => e.Custxt3).HasColumnName("CUSTXT3");

                entity.Property(e => e.Custxt3form).HasColumnName("CUSTXT3FORM");

                entity.Property(e => e.Custxt4).HasColumnName("CUSTXT4");

                entity.Property(e => e.Custxt4form).HasColumnName("CUSTXT4FORM");

                entity.Property(e => e.Custxt5).HasColumnName("CUSTXT5");

                entity.Property(e => e.Custxt5form).HasColumnName("CUSTXT5FORM");

                entity.Property(e => e.Custxt6).HasColumnName("CUSTXT6");

                entity.Property(e => e.Custxt6form).HasColumnName("CUSTXT6FORM");

                entity.Property(e => e.Custxt7).HasColumnName("CUSTXT7");

                entity.Property(e => e.Custxt7form).HasColumnName("CUSTXT7FORM");

                entity.Property(e => e.Custxt8).HasColumnName("CUSTXT8");

                entity.Property(e => e.Custxt8form).HasColumnName("CUSTXT8FORM");

                entity.Property(e => e.Custxt9).HasColumnName("CUSTXT9");

                entity.Property(e => e.Custxt9form).HasColumnName("CUSTXT9FORM");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Dscform).HasColumnName("DSCFORM");

                entity.Property(e => e.Duration)
                    .HasColumnName("DURATION")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Durationform).HasColumnName("DURATIONFORM");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Eqrt).HasColumnName("EQRT");

                entity.Property(e => e.Eqtyform).HasColumnName("EQTYFORM");

                entity.Property(e => e.Equcost)
                    .HasColumnName("EQUCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Equhours)
                    .HasColumnName("EQUHOURS")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Equrate)
                    .HasColumnName("EQURATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Equtotalform).HasColumnName("EQUTOTALFORM");

                entity.Property(e => e.Escalation)
                    .HasColumnName("ESCALATION")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Estimass)
                    .HasColumnName("ESTIMASS")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Estimasscost)
                    .HasColumnName("ESTIMASSCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Estimator)
                    .HasColumnName("ESTIMATOR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Estimcon)
                    .HasColumnName("ESTIMCON")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Estimconcost)
                    .HasColumnName("ESTIMCONCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Estimcost)
                    .HasColumnName("ESTIMCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Estimequ)
                    .HasColumnName("ESTIMEQU")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Estimequcost)
                    .HasColumnName("ESTIMEQUCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Estimfab)
                    .HasColumnName("ESTIMFAB")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Estimfabcost)
                    .HasColumnName("ESTIMFABCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Estimlab)
                    .HasColumnName("ESTIMLAB")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Estimlabcost)
                    .HasColumnName("ESTIMLABCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Estimmat)
                    .HasColumnName("ESTIMMAT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Estimmatcost)
                    .HasColumnName("ESTIMMATCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Estimrate)
                    .HasColumnName("ESTIMRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Estimship)
                    .HasColumnName("ESTIMSHIP")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Estimshpcost)
                    .HasColumnName("ESTIMSHPCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Estimsub)
                    .HasColumnName("ESTIMSUB")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Estimsubcost)
                    .HasColumnName("ESTIMSUBCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Estquant)
                    .HasColumnName("ESTQUANT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Extracode1)
                    .HasColumnName("EXTRACODE1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode10)
                    .HasColumnName("EXTRACODE10")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode2)
                    .HasColumnName("EXTRACODE2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode3)
                    .HasColumnName("EXTRACODE3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode4)
                    .HasColumnName("EXTRACODE4")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode5)
                    .HasColumnName("EXTRACODE5")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode6)
                    .HasColumnName("EXTRACODE6")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode7)
                    .HasColumnName("EXTRACODE7")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode8)
                    .HasColumnName("EXTRACODE8")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode9)
                    .HasColumnName("EXTRACODE9")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fabcost)
                    .HasColumnName("FABCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Fabrate)
                    .HasColumnName("FABRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Flag).HasColumnName("FLAG");

                entity.Property(e => e.Gekcode)
                    .HasColumnName("GEKCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Generationid)
                    .HasColumnName("GENERATIONID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HasProductivity).HasColumnName("HAS_PRODUCTIVITY");

                entity.Property(e => e.Labcost)
                    .HasColumnName("LABCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Labrate)
                    .HasColumnName("LABRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Labtotalform).HasColumnName("LABTOTALFORM");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("LAST_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lbrt).HasColumnName("LBRT");

                entity.Property(e => e.Location)
                    .HasColumnName("LOCATION")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Loccountry)
                    .HasColumnName("LOCCOUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Locfac)
                    .HasColumnName("LOCFAC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Locprof)
                    .HasColumnName("LOCPROF")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Locstate)
                    .HasColumnName("LOCSTATE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Manhours)
                    .HasColumnName("MANHOURS")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Markup)
                    .HasColumnName("MARKUP")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Markupform).HasColumnName("MARKUPFORM");

                entity.Property(e => e.Mart).HasColumnName("MART");

                entity.Property(e => e.Matcost)
                    .HasColumnName("MATCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Matrate)
                    .HasColumnName("MATRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Matrescost)
                    .HasColumnName("MATRESCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Mattotalform).HasColumnName("MATTOTALFORM");

                entity.Property(e => e.Measquant)
                    .HasColumnName("MEASQUANT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Mhfacform).HasColumnName("MHFACFORM");

                entity.Property(e => e.Mhoursfactor)
                    .HasColumnName("MHOURSFACTOR")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Mqtyform).HasColumnName("MQTYFORM");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Offeredpriceform).HasColumnName("OFFEREDPRICEFORM");

                entity.Property(e => e.Offprice)
                    .HasColumnName("OFFPRICE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Offrate)
                    .HasColumnName("OFFRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Offrateform).HasColumnName("OFFRATEFORM");

                entity.Property(e => e.Offsecrate)
                    .HasColumnName("OFFSECRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Offsecrateform).HasColumnName("OFFSECRATEFORM");

                entity.Property(e => e.Paramcode)
                    .HasColumnName("PARAMCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Paramitemid).HasColumnName("PARAMITEMID");

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("PAYMENT_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Prodfacform).HasColumnName("PRODFACFORM");

                entity.Property(e => e.Prodfactor)
                    .HasColumnName("PRODFACTOR")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Prodform).HasColumnName("PRODFORM");

                entity.Property(e => e.Productivity)
                    .HasColumnName("PRODUCTIVITY")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Publisheditemcode)
                    .HasColumnName("PUBLISHEDITEMCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Publishedrate)
                    .HasColumnName("PUBLISHEDRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Publishedrevisioncode)
                    .HasColumnName("PUBLISHEDREVISIONCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qtyform).HasColumnName("QTYFORM");

                entity.Property(e => e.Qtylossform).HasColumnName("QTYLOSSFORM");

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Quantloss)
                    .HasColumnName("QUANTLOSS")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Quotmat)
                    .HasColumnName("QUOTMAT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Quotmatcost)
                    .HasColumnName("QUOTMATCOST")
                    .HasColumnType("decimal(19, 2)");

                entity.Property(e => e.Quotsub)
                    .HasColumnName("QUOTSUB")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Quotsubcost)
                    .HasColumnName("QUOTSUBCOST")
                    .HasColumnType("decimal(19, 2)");

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Rateform).HasColumnName("RATEFORM");

                entity.Property(e => e.Rollup)
                    .HasColumnName("ROLLUP")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sbrt).HasColumnName("SBRT");

                entity.Property(e => e.Scheduled).HasColumnName("SCHEDULED");

                entity.Property(e => e.SecondUnit)
                    .HasColumnName("SECOND_UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Secqtyform).HasColumnName("SECQTYFORM");

                entity.Property(e => e.Secquantity)
                    .HasColumnName("SECQUANTITY")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Secrate)
                    .HasColumnName("SECRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Secrateform).HasColumnName("SECRATEFORM");

                entity.Property(e => e.Secunitform).HasColumnName("SECUNITFORM");

                entity.Property(e => e.Shipcost)
                    .HasColumnName("SHIPCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Shiprate)
                    .HasColumnName("SHIPRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Subcost)
                    .HasColumnName("SUBCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Subrate)
                    .HasColumnName("SUBRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Subtotalform).HasColumnName("SUBTOTALFORM");

                entity.Property(e => e.Surfacetype)
                    .HasColumnName("SURFACETYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Totalcost)
                    .HasColumnName("TOTALCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Totalcostform).HasColumnName("TOTALCOSTFORM");

                entity.Property(e => e.Ttlform).HasColumnName("TTLFORM");

                entity.Property(e => e.Umhform).HasColumnName("UMHFORM");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Unitmhours)
                    .HasColumnName("UNITMHOURS")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.UnitsDiv)
                    .HasColumnName("UNITS_DIV")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unitsdivform).HasColumnName("UNITSDIVFORM");

                entity.Property(e => e.Wbs2code)
                    .HasColumnName("WBS2CODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Wbs2form).HasColumnName("WBS2FORM");

                entity.Property(e => e.Wbscode)
                    .HasColumnName("WBSCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Wbsform).HasColumnName("WBSFORM");
            });

            modelBuilder.Entity<BoQitemAssembly>(entity =>
            {
                entity.ToTable("BoQItemAssembly");

                entity.Property(e => e.Boqitemassemblyid).HasColumnName("BOQITEMASSEMBLYID");

                entity.Property(e => e.Assemblyid).HasColumnName("ASSEMBLYID");

                entity.Property(e => e.Boqitemid).HasColumnName("BOQITEMID");

                entity.Property(e => e.Concost)
                    .HasColumnName("CONCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Costcenter)
                    .HasColumnName("COSTCENTER")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Equcost)
                    .HasColumnName("EQUCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor3)
                    .HasColumnName("FACTOR3")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Fconrate)
                    .HasColumnName("FCONRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Fequrate)
                    .HasColumnName("FEQURATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Ffabrate)
                    .HasColumnName("FFABRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Flabrate)
                    .HasColumnName("FLABRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Fmatrate)
                    .HasColumnName("FMATRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Fshprate)
                    .HasColumnName("FSHPRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Fsubrate)
                    .HasColumnName("FSUBRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Labcost)
                    .HasColumnName("LABCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("LAST_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Mattotcost)
                    .HasColumnName("MATTOTCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Subcost)
                    .HasColumnName("SUBCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Totalcost)
                    .HasColumnName("TOTALCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Totalunits)
                    .HasColumnName("TOTALUNITS")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Usertotalunits).HasColumnName("USERTOTALUNITS");

                entity.HasOne(d => d.Assembly)
                    .WithMany(p => p.BoQitemAssembly)
                    .HasForeignKey(d => d.Assemblyid)
                    .HasConstraintName("FKBoQItemAssembly1");
            });

            modelBuilder.Entity<BoQitemCondition>(entity =>
            {
                entity.ToTable("BoQItemCondition");

                entity.Property(e => e.Boqitemconditionid).HasColumnName("BOQITEMCONDITIONID");

                entity.Property(e => e.Boqitemid).HasColumnName("BOQITEMID");

                entity.Property(e => e.Conditionid).HasColumnName("CONDITIONID");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Fqty)
                    .HasColumnName("FQTY")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Funit)
                    .HasColumnName("FUNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("LAST_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Selqty)
                    .HasColumnName("SELQTY")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Selqtyname)
                    .HasColumnName("SELQTYNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Selunit)
                    .HasColumnName("SELUNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sumup)
                    .HasColumnName("SUMUP")
                    .HasColumnType("decimal(30, 10)");

                entity.HasOne(d => d.Condition)
                    .WithMany(p => p.BoQitemCondition)
                    .HasForeignKey(d => d.Conditionid)
                    .HasConstraintName("FKBoQItemCondition1");
            });

            modelBuilder.Entity<BoQitemConsumable>(entity =>
            {
                entity.ToTable("BoQItemConsumable");

                entity.Property(e => e.Boqitemconsumableid).HasColumnName("BOQITEMCONSUMABLEID");

                entity.Property(e => e.Boqitemid).HasColumnName("BOQITEMID");

                entity.Property(e => e.Consumableid).HasColumnName("CONSUMABLEID");

                entity.Property(e => e.Costcenter)
                    .HasColumnName("COSTCENTER")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Divider)
                    .HasColumnName("DIVIDER")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("LAST_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Totalcost)
                    .HasColumnName("TOTALCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Totalunits)
                    .HasColumnName("TOTALUNITS")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Usertotalunits).HasColumnName("USERTOTALUNITS");

                entity.HasOne(d => d.Consumable)
                    .WithMany(p => p.BoQitemConsumable)
                    .HasForeignKey(d => d.Consumableid)
                    .HasConstraintName("FKBoQItemConsumable2");
            });

            modelBuilder.Entity<BoQitemEquipment>(entity =>
            {
                entity.ToTable("BoQItemEquipment");

                entity.Property(e => e.Boqitemequipmentid).HasColumnName("BOQITEMEQUIPMENTID");

                entity.Property(e => e.Boqitemid).HasColumnName("BOQITEMID");

                entity.Property(e => e.Costcenter)
                    .HasColumnName("COSTCENTER")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Energyprice)
                    .HasColumnName("ENERGYPRICE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Equipmentid).HasColumnName("EQUIPMENTID");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor3)
                    .HasColumnName("FACTOR3")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Fdeprate)
                    .HasColumnName("FDEPRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Fuelrate)
                    .HasColumnName("FUELRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("LAST_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Totalcost)
                    .HasColumnName("TOTALCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Totalunits)
                    .HasColumnName("TOTALUNITS")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Usertotalunits).HasColumnName("USERTOTALUNITS");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.BoQitemEquipment)
                    .HasForeignKey(d => d.Equipmentid)
                    .HasConstraintName("FKBoQItemEquipment2");
            });

            modelBuilder.Entity<BoQitemLlabor>(entity =>
            {
                entity.HasKey(e => e.Boqitemlaborid)
                    .HasName("PK__boqitem___55613AAA6C513217");

                entity.ToTable("BoQItemLlabor");

                entity.Property(e => e.Boqitemlaborid).HasColumnName("BOQITEMLABORID");

                entity.Property(e => e.Boqitemid).HasColumnName("BOQITEMID");

                entity.Property(e => e.Costcenter)
                    .HasColumnName("COSTCENTER")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor3)
                    .HasColumnName("FACTOR3")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Laborid).HasColumnName("LABORID");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("LAST_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Totalcost)
                    .HasColumnName("TOTALCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Totalunits)
                    .HasColumnName("TOTALUNITS")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Usertotalunits).HasColumnName("USERTOTALUNITS");

                entity.HasOne(d => d.Labor)
                    .WithMany(p => p.BoQitemLlabor)
                    .HasForeignKey(d => d.Laborid)
                    .HasConstraintName("FKBoQItemLabor1");
            });

            modelBuilder.Entity<BoQitemMaterial>(entity =>
            {
                entity.ToTable("BoQItemMaterial");

                entity.Property(e => e.Boqitemmaterialid).HasColumnName("BOQITEMMATERIALID");

                entity.Property(e => e.Boqitemid).HasColumnName("BOQITEMID");

                entity.Property(e => e.Costcenter)
                    .HasColumnName("COSTCENTER")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Divider)
                    .HasColumnName("DIVIDER")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Escalation)
                    .HasColumnName("ESCALATION")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("LAST_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Materialid).HasColumnName("MATERIALID");

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Quoteitemid).HasColumnName("QUOTEITEMID");

                entity.Property(e => e.Totalcost)
                    .HasColumnName("TOTALCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Totalunits)
                    .HasColumnName("TOTALUNITS")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Usertotalunits).HasColumnName("USERTOTALUNITS");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.BoQitemMaterial)
                    .HasForeignKey(d => d.Materialid)
                    .HasConstraintName("FKBoQItemMaterial1");

                entity.HasOne(d => d.Quoteitem)
                    .WithMany(p => p.BoQitemMaterial)
                    .HasForeignKey(d => d.Quoteitemid)
                    .HasConstraintName("FKBoQItemMaterial2");
            });

            modelBuilder.Entity<BoQitemSubcontractor>(entity =>
            {
                entity.ToTable("BoQItemSubcontractor");

                entity.Property(e => e.Boqitemsubcontractorid).HasColumnName("BOQITEMSUBCONTRACTORID");

                entity.Property(e => e.Boqitemid).HasColumnName("BOQITEMID");

                entity.Property(e => e.Costcenter)
                    .HasColumnName("COSTCENTER")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor3)
                    .HasColumnName("FACTOR3")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("LAST_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Localcountry)
                    .HasColumnName("LOCALCOUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Localfactor)
                    .HasColumnName("LOCALFACTOR")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Localstate)
                    .HasColumnName("LOCALSTATE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Quoteitemid).HasColumnName("QUOTEITEMID");

                entity.Property(e => e.Subcontractorid).HasColumnName("SUBCONTRACTORID");

                entity.Property(e => e.Totalcost)
                    .HasColumnName("TOTALCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Totalunits)
                    .HasColumnName("TOTALUNITS")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Usertotalunits).HasColumnName("USERTOTALUNITS");

                entity.HasOne(d => d.Quoteitem)
                    .WithMany(p => p.BoQitemSubcontractor)
                    .HasForeignKey(d => d.Quoteitemid)
                    .HasConstraintName("FKBoQItemSubcontractor1");

                entity.HasOne(d => d.Subcontractor)
                    .WithMany(p => p.BoQitemSubcontractor)
                    .HasForeignKey(d => d.Subcontractorid)
                    .HasConstraintName("FKBoQItemSubcontractor2");
            });

            modelBuilder.Entity<Cndon>(entity =>
            {
                entity.HasKey(e => e.Conditionid)
                    .HasName("PK__cndon__AF05447C7BCFAC67");

                entity.Property(e => e.Conditionid).HasColumnName("CONDITIONID");

                entity.Property(e => e.Bidno).HasColumnName("BIDNO");

                entity.Property(e => e.Bimmaterial).HasColumnName("BIMMATERIAL");

                entity.Property(e => e.Bimtype)
                    .HasColumnName("BIMTYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Building)
                    .HasColumnName("BUILDING")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cndid).HasColumnName("CNDID");

                entity.Property(e => e.Cndno).HasColumnName("CNDNO");

                entity.Property(e => e.Cndtype)
                    .HasColumnName("CNDTYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Dbname)
                    .HasColumnName("DBNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Fctstate).HasColumnName("FCTSTATE");

                entity.Property(e => e.Formula1)
                    .HasColumnName("FORMULA1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Formula2)
                    .HasColumnName("FORMULA2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Formula3)
                    .HasColumnName("FORMULA3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Formulaf).HasColumnName("FORMULAF");

                entity.Property(e => e.Globalid)
                    .HasColumnName("GLOBALID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Host)
                    .HasColumnName("HOST")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Layer)
                    .HasColumnName("LAYER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasColumnName("LOCATION")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qty1)
                    .HasColumnName("QTY1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Qty1name)
                    .HasColumnName("QTY1NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qty2)
                    .HasColumnName("QTY2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Qty2name)
                    .HasColumnName("QTY2NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qty3)
                    .HasColumnName("QTY3")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Qty3name)
                    .HasColumnName("QTY3NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qtyf)
                    .HasColumnName("QTYF")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Qtyfname)
                    .HasColumnName("QTYFNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Storey)
                    .HasColumnName("STOREY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Takeofftype)
                    .HasColumnName("TAKEOFFTYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Unit1)
                    .HasColumnName("UNIT1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Unit2)
                    .HasColumnName("UNIT2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Unit3)
                    .HasColumnName("UNIT3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Unitf)
                    .HasColumnName("UNITF")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("USERNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Virt).HasColumnName("VIRT");
            });

            modelBuilder.Entity<CnmHistory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Basetableid)
                    .HasColumnName("BASETABLEID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Consumableid).HasColumnName("CONSUMABLEID");

                entity.Property(e => e.Preddate)
                    .HasColumnName("PREDDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Resource).HasColumnName("RESOURCE");

                entity.Property(e => e.Rsrc).HasColumnName("RSRC");

                entity.HasOne(d => d.Consumable)
                    .WithMany(p => p.CnmHistory)
                    .HasForeignKey(d => d.Consumableid)
                    .HasConstraintName("FKCNMHistory1");
            });

            modelBuilder.Entity<Conceptuals>(entity =>
            {
                entity.HasKey(e => e.Conceptualid)
                    .HasName("PK__conceptu__46D7EFE59509D83D");

                entity.Property(e => e.Conceptualid).HasColumnName("CONCEPTUALID");

                entity.Property(e => e.Cc01eq).HasColumnName("CC01EQ");

                entity.Property(e => e.Cc02eq).HasColumnName("CC02EQ");

                entity.Property(e => e.Cc03eq).HasColumnName("CC03EQ");

                entity.Property(e => e.Cc04eq).HasColumnName("CC04EQ");

                entity.Property(e => e.Cc05eq).HasColumnName("CC05EQ");

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

                entity.Property(e => e.Crewfacs)
                    .HasColumnName("CREWFACS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

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

                entity.Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Descconcat).HasColumnName("DESCCONCAT");

                entity.Property(e => e.Dtunit)
                    .HasColumnName("DTUNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Duty).HasColumnName("DUTY");

                entity.Property(e => e.Equdeprate).HasColumnName("EQUDEPRATE");

                entity.Property(e => e.Equfucrate).HasColumnName("EQUFUCRATE");

                entity.Property(e => e.Equfulrate).HasColumnName("EQUFULRATE");

                entity.Property(e => e.Equfutrate).HasColumnName("EQUFUTRATE");

                entity.Property(e => e.Equlubrate).HasColumnName("EQULUBRATE");

                entity.Property(e => e.Equresrate).HasColumnName("EQURESRATE");

                entity.Property(e => e.Equsprrate).HasColumnName("EQUSPRRATE");

                entity.Property(e => e.Equtrsrate).HasColumnName("EQUTRSRATE");

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
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Notesconcat).HasColumnName("NOTESCONCAT");

                entity.Property(e => e.Operpress).HasColumnName("OPERPRESS");

                entity.Property(e => e.Opertemp).HasColumnName("OPERTEMP");

                entity.Property(e => e.Opunit)
                    .HasColumnName("OPUNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Otunit)
                    .HasColumnName("OTUNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Paramoutputid).HasColumnName("PARAMOUTPUTID");

                entity.Property(e => e.Rawmat1)
                    .HasColumnName("RAWMAT1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rawmat2)
                    .HasColumnName("RAWMAT2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rawmat3)
                    .HasColumnName("RAWMAT3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rawmat4)
                    .HasColumnName("RAWMAT4")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rawmat5)
                    .HasColumnName("RAWMAT5")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Refdate)
                    .HasColumnName("REFDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Rel1)
                    .HasColumnName("REL1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Rel2)
                    .HasColumnName("REL2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Rel3)
                    .HasColumnName("REL3")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Rel4)
                    .HasColumnName("REL4")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Rel5)
                    .HasColumnName("REL5")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Subika).HasColumnName("SUBIKA");

                entity.Property(e => e.Subrate).HasColumnName("SUBRATE");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Titleconcat).HasColumnName("TITLECONCAT");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Vfunit)
                    .HasColumnName("VFUNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Volflow).HasColumnName("VOLFLOW");

                entity.Property(e => e.Weight)
                    .HasColumnName("WEIGHT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Weightrate).HasColumnName("WEIGHTRATE");

                entity.Property(e => e.Weightunit)
                    .HasColumnName("WEIGHTUNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Paramoutput)
                    .WithMany(p => p.Conceptuals)
                    .HasForeignKey(d => d.Paramoutputid)
                    .HasConstraintName("FKConceptuals1");
            });

            modelBuilder.Entity<Consumable>(entity =>
            {
                entity.Property(e => e.Consumableid).HasColumnName("CONSUMABLEID");

                entity.Property(e => e.Accrights)
                    .HasColumnName("ACCRIGHTS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Conceptual).HasColumnName("CONCEPTUAL");

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Createdate)
                    .HasColumnName("CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Createuser)
                    .HasColumnName("CREATEUSER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Databasecreationdate).HasColumnName("DATABASECREATIONDATE");

                entity.Property(e => e.Databaseid).HasColumnName("DATABASEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode1)
                    .IsRequired()
                    .HasColumnName("EXTRACODE1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode10)
                    .IsRequired()
                    .HasColumnName("EXTRACODE10")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode2)
                    .IsRequired()
                    .HasColumnName("EXTRACODE2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode3)
                    .IsRequired()
                    .HasColumnName("EXTRACODE3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode4)
                    .IsRequired()
                    .HasColumnName("EXTRACODE4")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode5)
                    .IsRequired()
                    .HasColumnName("EXTRACODE5")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode6)
                    .IsRequired()
                    .HasColumnName("EXTRACODE6")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode7)
                    .IsRequired()
                    .HasColumnName("EXTRACODE7")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode8)
                    .IsRequired()
                    .HasColumnName("EXTRACODE8")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode9)
                    .IsRequired()
                    .HasColumnName("EXTRACODE9")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gekcode)
                    .HasColumnName("GEKCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Keyw).HasColumnName("KEYW");

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Predicted).HasColumnName("PREDICTED");

                entity.Property(e => e.Project)
                    .HasColumnName("PROJECT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qty)
                    .HasColumnName("QTY")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Stateprovince)
                    .HasColumnName("STATEPROVINCE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tchtype).HasColumnName("TCHTYPE");

                entity.Property(e => e.Tcolor).HasColumnName("TCOLOR");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Trdate)
                    .HasColumnName("TRDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Tregtype).HasColumnName("TREGTYPE");

                entity.Property(e => e.Trids).HasColumnName("TRIDS");

                entity.Property(e => e.Tunit)
                    .HasColumnName("TUNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tval)
                    .HasColumnName("TVAL")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Virtual).HasColumnName("VIRTUAL");
            });

            modelBuilder.Entity<EquHistory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Basetableid)
                    .HasColumnName("BASETABLEID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Equipmentid).HasColumnName("EQUIPMENTID");

                entity.Property(e => e.Preddate)
                    .HasColumnName("PREDDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Resource).HasColumnName("RESOURCE");

                entity.Property(e => e.Rsrc).HasColumnName("RSRC");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.EquHistory)
                    .HasForeignKey(d => d.Equipmentid)
                    .HasConstraintName("FKEquHistory1");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.Equipmentid).HasColumnName("EQUIPMENTID");

                entity.Property(e => e.Accrights)
                    .HasColumnName("ACCRIGHTS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Conceptual).HasColumnName("CONCEPTUAL");

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Createdate)
                    .HasColumnName("CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Createuser)
                    .HasColumnName("CREATEUSER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Databasecreationdate).HasColumnName("DATABASECREATIONDATE");

                entity.Property(e => e.Databaseid).HasColumnName("DATABASEID");

                entity.Property(e => e.DeprecationCalcMethod).HasColumnName("DEPRECATION_CALC_METHOD");

                entity.Property(e => e.DepreciationYears)
                    .HasColumnName("DEPRECIATION_YEARS")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Depreciationrate)
                    .HasColumnName("DEPRECIATIONRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode1)
                    .IsRequired()
                    .HasColumnName("EXTRACODE1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode10)
                    .IsRequired()
                    .HasColumnName("EXTRACODE10")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode2)
                    .IsRequired()
                    .HasColumnName("EXTRACODE2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode3)
                    .IsRequired()
                    .HasColumnName("EXTRACODE3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode4)
                    .IsRequired()
                    .HasColumnName("EXTRACODE4")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode5)
                    .IsRequired()
                    .HasColumnName("EXTRACODE5")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode6)
                    .IsRequired()
                    .HasColumnName("EXTRACODE6")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode7)
                    .IsRequired()
                    .HasColumnName("EXTRACODE7")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode8)
                    .IsRequired()
                    .HasColumnName("EXTRACODE8")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode9)
                    .IsRequired()
                    .HasColumnName("EXTRACODE9")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fuelconsumption)
                    .HasColumnName("FUELCONSUMPTION")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Fuelrate)
                    .HasColumnName("FUELRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Fueltype)
                    .HasColumnName("FUELTYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gekcode)
                    .HasColumnName("GEKCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InitAquasitionPrice)
                    .HasColumnName("INIT_AQUASITION_PRICE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.InterestRate)
                    .HasColumnName("INTEREST_RATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Keyw).HasColumnName("KEYW");

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lubricatesrate)
                    .HasColumnName("LUBRICATESRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Make)
                    .HasColumnName("MAKE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasColumnName("MODEL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OccupationHoursPerMonth)
                    .HasColumnName("OCCUPATION_HOURS_PER_MONTH")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.OccupationalFactor)
                    .HasColumnName("OCCUPATIONAL_FACTOR")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Predicted).HasColumnName("PREDICTED");

                entity.Property(e => e.Reservationrate)
                    .HasColumnName("RESERVATIONRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.SalvageValue)
                    .HasColumnName("SALVAGE_VALUE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Sparepartsrate)
                    .HasColumnName("SPAREPARTSRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.State)
                    .HasColumnName("STATE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tchtype).HasColumnName("TCHTYPE");

                entity.Property(e => e.Tcolor).HasColumnName("TCOLOR");

                entity.Property(e => e.Tiresrate)
                    .HasColumnName("TIRESRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Totalrate)
                    .HasColumnName("TOTALRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Trdate)
                    .HasColumnName("TRDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Tregtype).HasColumnName("TREGTYPE");

                entity.Property(e => e.Trids).HasColumnName("TRIDS");

                entity.Property(e => e.Tunit)
                    .HasColumnName("TUNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tval)
                    .HasColumnName("TVAL")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Virtual).HasColumnName("VIRTUAL");
            });

            modelBuilder.Entity<ExchangeRate>(entity =>
            {
                entity.HasKey(e => e.Xchangerateid)
                    .HasName("PK__xchanger__CC082C6675242736");

                entity.Property(e => e.Xchangerateid).HasColumnName("XCHANGERATEID");

                entity.Property(e => e.FromCurrency)
                    .HasColumnName("FROM_CURRENCY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.RateDate)
                    .HasColumnName("RATE_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ToCurrency)
                    .HasColumnName("TO_CURRENCY")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Expenses>(entity =>
            {
                entity.HasKey(e => e.Expenseid)
                    .HasName("PK__expenses__D98AC998AAD427D4");

                entity.Property(e => e.Expenseid).HasColumnName("EXPENSEID");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CustomRate)
                    .HasColumnName("CUSTOM_RATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.LaborRate)
                    .HasColumnName("LABOR_RATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.MaterialRate)
                    .HasColumnName("MATERIAL_RATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.MiscRate)
                    .HasColumnName("MISC_RATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Months)
                    .HasColumnName("MONTHS")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Percent)
                    .HasColumnName("PERCENT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Prcnt)
                    .HasColumnName("PRCNT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.SubcontractorsRate)
                    .HasColumnName("SUBCONTRACTORS_RATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExtraCode1>(entity =>
            {
                entity.HasKey(e => e.Groupcodeid)
                    .HasName("PK__extracod__7408C9417C85EA88");

                entity.Property(e => e.Groupcodeid).HasColumnName("GROUPCODEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExtraCode10>(entity =>
            {
                entity.HasKey(e => e.Groupcodeid)
                    .HasName("PK__extracod__7408C9412FAB9C77");

                entity.Property(e => e.Groupcodeid).HasColumnName("GROUPCODEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExtraCode2>(entity =>
            {
                entity.HasKey(e => e.Groupcodeid)
                    .HasName("PK__extracod__7408C9413DB14BC5");

                entity.Property(e => e.Groupcodeid).HasColumnName("GROUPCODEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExtraCode3>(entity =>
            {
                entity.HasKey(e => e.Groupcodeid)
                    .HasName("PK__extracod__7408C9412FA2E8AF");

                entity.Property(e => e.Groupcodeid).HasColumnName("GROUPCODEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExtraCode4>(entity =>
            {
                entity.HasKey(e => e.Groupcodeid)
                    .HasName("PK__extracod__7408C94114B7B874");

                entity.Property(e => e.Groupcodeid).HasColumnName("GROUPCODEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExtraCode5>(entity =>
            {
                entity.HasKey(e => e.Groupcodeid)
                    .HasName("PK__extracod__7408C941FBC41802");

                entity.Property(e => e.Groupcodeid).HasColumnName("GROUPCODEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExtraCode6>(entity =>
            {
                entity.HasKey(e => e.Groupcodeid)
                    .HasName("PK__extracod__7408C94197C37425");

                entity.Property(e => e.Groupcodeid).HasColumnName("GROUPCODEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExtraCode7>(entity =>
            {
                entity.HasKey(e => e.Groupcodeid)
                    .HasName("PK__extracod__7408C9419C2AA27D");

                entity.Property(e => e.Groupcodeid).HasColumnName("GROUPCODEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExtraCode8>(entity =>
            {
                entity.HasKey(e => e.Groupcodeid)
                    .HasName("PK__extracod__7408C94120367405");

                entity.Property(e => e.Groupcodeid).HasColumnName("GROUPCODEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExtraCode9>(entity =>
            {
                entity.HasKey(e => e.Groupcodeid)
                    .HasName("PK__extracod__7408C941C5157E4F");

                entity.Property(e => e.Groupcodeid).HasColumnName("GROUPCODEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FieldCustom>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Defsel)
                    .HasColumnName("DEFSEL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Displayname)
                    .HasColumnName("DISPLAYNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Editable).HasColumnName("EDITABLE");

                entity.Property(e => e.Formula).HasColumnName("FORMULA");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Resource)
                    .HasColumnName("RESOURCE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rsrc)
                    .HasColumnName("RSRC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sellist).HasColumnName("SELLIST");

                entity.Property(e => e.Selvals).HasColumnName("SELVALS");
            });

            modelBuilder.Entity<Filtro>(entity =>
            {
                entity.Property(e => e.Filtroid).HasColumnName("FILTROID");

                entity.Property(e => e.Filtrodescription)
                    .HasColumnName("FILTRODESCRIPTION")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Filtroname)
                    .HasColumnName("FILTRONAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Filtrotype)
                    .HasColumnName("FILTROTYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<FiltroProperty>(entity =>
            {
                entity.Property(e => e.Filtropropertyid).HasColumnName("FILTROPROPERTYID");

                entity.Property(e => e.Field)
                    .HasColumnName("FIELD")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Filtroid).HasColumnName("FILTROID");

                entity.Property(e => e.Filtropropertiescount).HasColumnName("FILTROPROPERTIESCOUNT");

                entity.Property(e => e.Restriction)
                    .HasColumnName("RESTRICTION")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Used).HasColumnName("USED");

                entity.Property(e => e.Usetype)
                    .HasColumnName("USETYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FldFn>(entity =>
            {
                entity.Property(e => e.Fldfnid).HasColumnName("FLDFNID");

                entity.Property(e => e.Fpath)
                    .HasColumnName("FPATH")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ftype)
                    .HasColumnName("FTYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rpdfnfildefcount).HasColumnName("RPDFNFILDEFCOUNT");

                entity.Property(e => e.Rpdfnid).HasColumnName("RPDFNID");

                entity.HasOne(d => d.Rpdfn)
                    .WithMany(p => p.FldFn)
                    .HasForeignKey(d => d.Rpdfnid)
                    .HasConstraintName("FKfldfn1");
            });

            modelBuilder.Entity<Fncton>(entity =>
            {
                entity.HasKey(e => e.Functionid)
                    .HasName("PK__fncton__466C3FDF4C28CADF");

                entity.Property(e => e.Functionid).HasColumnName("FUNCTIONID");

                entity.Property(e => e.Createdate)
                    .HasColumnName("CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Createuserid)
                    .HasColumnName("CREATEUSERID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Grouping)
                    .HasColumnName("GROUPING")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Impl).HasColumnName("IMPL");

                entity.Property(e => e.Lang)
                    .HasColumnName("LANG")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Prttype)
                    .HasColumnName("PRTTYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pswd)
                    .HasColumnName("PSWD")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Restype)
                    .HasColumnName("RESTYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Snum).HasColumnName("SNUM");

                entity.Property(e => e.Takeoff).HasColumnName("TAKEOFF");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FnctonArgument>(entity =>
            {
                entity.HasKey(e => e.Fargid)
                    .HasName("PK__fncton_a__E10CD26F6E6D009D");

                entity.Property(e => e.Fargid).HasColumnName("FARGID");

                entity.Property(e => e.Artype)
                    .HasColumnName("ARTYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Defval)
                    .HasColumnName("DEFVAL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Depsta).HasColumnName("DEPSTA");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editable).HasColumnName("EDITABLE");

                entity.Property(e => e.Fid).HasColumnName("FID");

                entity.Property(e => e.Grouping)
                    .HasColumnName("GROUPING")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sellist).HasColumnName("SELLIST");

                entity.Property(e => e.Sorder).HasColumnName("SORDER");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Valsta).HasColumnName("VALSTA");

                entity.Property(e => e.Varscount).HasColumnName("VARSCOUNT");

                entity.HasOne(d => d.F)
                    .WithMany(p => p.FnctonArgument)
                    .HasForeignKey(d => d.Fid)
                    .HasConstraintName("FKFnctonArgument1");
            });

            modelBuilder.Entity<Gekcode>(entity =>
            {
                entity.ToTable("GEKCode");

                entity.Property(e => e.Gekcodeid).HasColumnName("GEKCODEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GlbProp>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Pkey)
                    .HasColumnName("PKEY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pval).HasColumnName("PVAL");
            });

            modelBuilder.Entity<GroupCode>(entity =>
            {
                entity.Property(e => e.Groupcodeid).HasColumnName("GROUPCODEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Groupcode1)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LabHistory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Basetableid)
                    .HasColumnName("BASETABLEID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Laborid).HasColumnName("LABORID");

                entity.Property(e => e.Preddate)
                    .HasColumnName("PREDDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Resource).HasColumnName("RESOURCE");

                entity.Property(e => e.Rsrc).HasColumnName("RSRC");

                entity.HasOne(d => d.Labor)
                    .WithMany(p => p.LabHistory)
                    .HasForeignKey(d => d.Laborid)
                    .HasConstraintName("FKLabHistory1");
            });

            modelBuilder.Entity<Labor>(entity =>
            {
                entity.Property(e => e.Laborid).HasColumnName("LABORID");

                entity.Property(e => e.Accrights)
                    .HasColumnName("ACCRIGHTS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("CITY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Conceptual).HasColumnName("CONCEPTUAL");

                entity.Property(e => e.Contactperson)
                    .HasColumnName("CONTACTPERSON")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Createdate)
                    .HasColumnName("CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Createuser)
                    .HasColumnName("CREATEUSER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Databasecreationdate).HasColumnName("DATABASECREATIONDATE");

                entity.Property(e => e.Databaseid).HasColumnName("DATABASEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode1)
                    .IsRequired()
                    .HasColumnName("EXTRACODE1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode10)
                    .IsRequired()
                    .HasColumnName("EXTRACODE10")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode2)
                    .IsRequired()
                    .HasColumnName("EXTRACODE2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode3)
                    .IsRequired()
                    .HasColumnName("EXTRACODE3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode4)
                    .IsRequired()
                    .HasColumnName("EXTRACODE4")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode5)
                    .IsRequired()
                    .HasColumnName("EXTRACODE5")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode6)
                    .IsRequired()
                    .HasColumnName("EXTRACODE6")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode7)
                    .IsRequired()
                    .HasColumnName("EXTRACODE7")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode8)
                    .IsRequired()
                    .HasColumnName("EXTRACODE8")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode9)
                    .IsRequired()
                    .HasColumnName("EXTRACODE9")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Faxnumber)
                    .HasColumnName("FAXNUMBER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gekcode)
                    .HasColumnName("GEKCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ika)
                    .HasColumnName("IKA")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Keyw).HasColumnName("KEYW");

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mobilenumber)
                    .HasColumnName("MOBILENUMBER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phonenumber)
                    .HasColumnName("PHONENUMBER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Predicted).HasColumnName("PREDICTED");

                entity.Property(e => e.Project)
                    .HasColumnName("PROJECT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Stateprovince)
                    .HasColumnName("STATEPROVINCE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tchtype).HasColumnName("TCHTYPE");

                entity.Property(e => e.Tcolor).HasColumnName("TCOLOR");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Totalrate)
                    .HasColumnName("TOTALRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Trdate)
                    .HasColumnName("TRDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Tregtype).HasColumnName("TREGTYPE");

                entity.Property(e => e.Trids).HasColumnName("TRIDS");

                entity.Property(e => e.Tunit)
                    .HasColumnName("TUNIT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Tval)
                    .HasColumnName("TVAL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Virtual).HasColumnName("VIRTUAL");
            });

            modelBuilder.Entity<LayoutC>(entity =>
            {
                entity.ToTable("layoutC");

                entity.Property(e => e.Layoutcid).HasColumnName("LAYOUTCID");

                entity.Property(e => e.Creatorid)
                    .HasColumnName("CREATORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Csep).HasColumnName("CSEP");

                entity.Property(e => e.Csepclr)
                    .HasColumnName("CSEPCLR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Dflt).HasColumnName("DFLT");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.F1clr)
                    .HasColumnName("F1CLR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.F1name)
                    .HasColumnName("F1NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.F1size).HasColumnName("F1SIZE");

                entity.Property(e => e.F1style).HasColumnName("F1STYLE");

                entity.Property(e => e.F1undl).HasColumnName("F1UNDL");

                entity.Property(e => e.F2clr)
                    .HasColumnName("F2CLR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.F2name)
                    .HasColumnName("F2NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.F2size).HasColumnName("F2SIZE");

                entity.Property(e => e.F2style).HasColumnName("F2STYLE");

                entity.Property(e => e.F2undl).HasColumnName("F2UNDL");

                entity.Property(e => e.F3clr)
                    .HasColumnName("F3CLR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.F3name)
                    .HasColumnName("F3NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.F3size).HasColumnName("F3SIZE");

                entity.Property(e => e.F3style).HasColumnName("F3STYLE");

                entity.Property(e => e.F3undl).HasColumnName("F3UNDL");

                entity.Property(e => e.F4clr)
                    .HasColumnName("F4CLR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.F4name)
                    .HasColumnName("F4NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.F4size).HasColumnName("F4SIZE");

                entity.Property(e => e.F4style).HasColumnName("F4STYLE");

                entity.Property(e => e.F4undl).HasColumnName("F4UNDL");

                entity.Property(e => e.F5clr)
                    .HasColumnName("F5CLR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.F5name)
                    .HasColumnName("F5NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.F5size).HasColumnName("F5SIZE");

                entity.Property(e => e.F5style).HasColumnName("F5STYLE");

                entity.Property(e => e.F5undl).HasColumnName("F5UNDL");

                entity.Property(e => e.Flundl).HasColumnName("FLUNDL");

                entity.Property(e => e.Fnclr)
                    .HasColumnName("FNCLR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fnname)
                    .HasColumnName("FNNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fnsize).HasColumnName("FNSIZE");

                entity.Property(e => e.Fnstyle).HasColumnName("FNSTYLE");

                entity.Property(e => e.Fnundl).HasColumnName("FNUNDL");

                entity.Property(e => e.Fuclr)
                    .HasColumnName("FUCLR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Funame)
                    .HasColumnName("FUNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fusize).HasColumnName("FUSIZE");

                entity.Property(e => e.Fustyle).HasColumnName("FUSTYLE");

                entity.Property(e => e.Fuundl).HasColumnName("FUUNDL");

                entity.Property(e => e.Gridclr)
                    .HasColumnName("GRIDCLR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gridon).HasColumnName("GRIDON");

                entity.Property(e => e.Grpname)
                    .HasColumnName("GRPNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Hgridon).HasColumnName("HGRIDON");

                entity.Property(e => e.L1bclr)
                    .HasColumnName("L1BCLR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.L2bclr)
                    .HasColumnName("L2BCLR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.L3bclr)
                    .HasColumnName("L3BCLR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.L4bclr)
                    .HasColumnName("L4BCLR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.L5bclr)
                    .HasColumnName("L5BCLR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lfbclr)
                    .HasColumnName("LFBCLR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lfclr)
                    .HasColumnName("LFCLR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lfname)
                    .HasColumnName("LFNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lfsize).HasColumnName("LFSIZE");

                entity.Property(e => e.Lfstyle).HasColumnName("LFSTYLE");

                entity.Property(e => e.Lnbclr)
                    .HasColumnName("LNBCLR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Mltln).HasColumnName("MLTLN");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pblk).HasColumnName("PBLK");

                entity.Property(e => e.Rowhead).HasColumnName("ROWHEAD");

                entity.Property(e => e.Rowstrp).HasColumnName("ROWSTRP");

                entity.Property(e => e.Rs1clr)
                    .HasColumnName("RS1CLR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rs2clr)
                    .HasColumnName("RS2CLR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Selectedgk)
                    .HasColumnName("SELECTEDGK")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Showtree).HasColumnName("SHOWTREE");

                entity.Property(e => e.Spangrp).HasColumnName("SPANGRP");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Unbclr)
                    .HasColumnName("UNBCLR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Visibtabs).HasColumnName("VISIBTABS");
            });

            modelBuilder.Entity<LayoutCpanel>(entity =>
            {
                entity.ToTable("LayoutCPanel");

                entity.Property(e => e.Layoutcpanelid).HasColumnName("LAYOUTCPANELID");

                entity.Property(e => e.Assment).HasColumnName("ASSMENT");

                entity.Property(e => e.Autoresize).HasColumnName("AUTORESIZE");

                entity.Property(e => e.Columns)
                    .HasColumnName("COLUMNS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Columnwidths)
                    .HasColumnName("COLUMNWIDTHS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Dsgrp).HasColumnName("DSGRP");

                entity.Property(e => e.Filters).HasColumnName("FILTERS");

                entity.Property(e => e.Grpcols).HasColumnName("GRPCOLS");

                entity.Property(e => e.Grpn).HasColumnName("GRPN");

                entity.Property(e => e.Grpords).HasColumnName("GRPORDS");

                entity.Property(e => e.Layoutcid).HasColumnName("LAYOUTCID");

                entity.Property(e => e.Layoutcpanelcount).HasColumnName("LAYOUTCPANELCOUNT");

                entity.Property(e => e.Lockedcols).HasColumnName("LOCKEDCOLS");

                entity.Property(e => e.Prefcols).HasColumnName("PREFCOLS");

                entity.Property(e => e.Rowheight).HasColumnName("ROWHEIGHT");

                entity.Property(e => e.Side).HasColumnName("SIDE");

                entity.Property(e => e.Sortedcols).HasColumnName("SORTEDCOLS");

                entity.Property(e => e.Sortindex).HasColumnName("SORTINDEX");

                entity.Property(e => e.Sorttypeup).HasColumnName("SORTTYPEUP");

                entity.Property(e => e.Vizer).HasColumnName("VIZER");

                entity.Property(e => e.Vsble).HasColumnName("VSBLE");

                entity.Property(e => e.Xtralvl).HasColumnName("XTRALVL");

                entity.HasOne(d => d.Layoutc)
                    .WithMany(p => p.LayoutCpanel)
                    .HasForeignKey(d => d.Layoutcid)
                    .HasConstraintName("FKLayouCPanel1");
            });

            modelBuilder.Entity<LocFactor>(entity =>
            {
                entity.HasKey(e => e.Lfid)
                    .HasName("PK__locfacto__6E7E2C1C2CDCDFE4");

                entity.Property(e => e.Lfid).HasColumnName("LFID");

                entity.Property(e => e.Assfac)
                    .HasColumnName("ASSFAC")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Codetype)
                    .HasColumnName("CODETYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Confac)
                    .HasColumnName("CONFAC")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Equfac)
                    .HasColumnName("EQUFAC")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Faccount).HasColumnName("FACCOUNT");

                entity.Property(e => e.Fid).HasColumnName("FID");

                entity.Property(e => e.Geopoly).HasColumnName("GEOPOLY");

                entity.Property(e => e.Labfac)
                    .HasColumnName("LABFAC")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Matfac)
                    .HasColumnName("MATFAC")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Online).HasColumnName("ONLINE");

                entity.Property(e => e.Onln).HasColumnName("ONLN");

                entity.Property(e => e.Parentecode)
                    .HasColumnName("PARENTECODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Subfac)
                    .HasColumnName("SUBFAC")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Tocity)
                    .HasColumnName("TOCITY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tocountry)
                    .HasColumnName("TOCOUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tostate)
                    .HasColumnName("TOSTATE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tozipcode)
                    .HasColumnName("TOZIPCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.F)
                    .WithMany(p => p.LocFactor)
                    .HasForeignKey(d => d.Fid)
                    .HasConstraintName("FKLocFactor1");
            });

            modelBuilder.Entity<LocProf>(entity =>
            {
                entity.HasKey(e => e.Functionid)
                    .HasName("PK__locprof__466C3FDF38BC9927");

                entity.Property(e => e.Functionid).HasColumnName("FUNCTIONID");

                entity.Property(e => e.Createdate)
                    .HasColumnName("CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Createuserid)
                    .HasColumnName("CREATEUSERID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fromcountry)
                    .HasColumnName("FROMCOUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fromstate)
                    .HasColumnName("FROMSTATE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Supstate).HasColumnName("SUPSTATE");
            });

            modelBuilder.Entity<MatHistory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Basetableid)
                    .HasColumnName("BASETABLEID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Materialid).HasColumnName("MATERIALID");

                entity.Property(e => e.Preddate)
                    .HasColumnName("PREDDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Resource).HasColumnName("RESOURCE");

                entity.Property(e => e.Rsrc).HasColumnName("RSRC");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.MatHistory)
                    .HasForeignKey(d => d.Materialid)
                    .HasConstraintName("FKMatHistory1");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.Property(e => e.Materialid).HasColumnName("MATERIALID");

                entity.Property(e => e.Accrights)
                    .HasColumnName("ACCRIGHTS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Accuracy)
                    .HasColumnName("ACCURACY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Bimmaterial).HasColumnName("BIMMATERIAL");

                entity.Property(e => e.Bimtype)
                    .HasColumnName("BIMTYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Conceptual).HasColumnName("CONCEPTUAL");

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Createdate)
                    .HasColumnName("CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Createuser)
                    .HasColumnName("CREATEUSER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Databasecreationdate).HasColumnName("DATABASECREATIONDATE");

                entity.Property(e => e.Databaseid).HasColumnName("DATABASEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Distance)
                    .HasColumnName("DISTANCE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Distunit)
                    .HasColumnName("DISTUNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Duty)
                    .HasColumnName("DUTY")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Dutyut)
                    .HasColumnName("DUTYUT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode1)
                    .IsRequired()
                    .HasColumnName("EXTRACODE1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode10)
                    .IsRequired()
                    .HasColumnName("EXTRACODE10")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode2)
                    .IsRequired()
                    .HasColumnName("EXTRACODE2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode3)
                    .IsRequired()
                    .HasColumnName("EXTRACODE3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode4)
                    .IsRequired()
                    .HasColumnName("EXTRACODE4")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode5)
                    .IsRequired()
                    .HasColumnName("EXTRACODE5")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode6)
                    .IsRequired()
                    .HasColumnName("EXTRACODE6")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode7)
                    .IsRequired()
                    .HasColumnName("EXTRACODE7")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode8)
                    .IsRequired()
                    .HasColumnName("EXTRACODE8")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode9)
                    .IsRequired()
                    .HasColumnName("EXTRACODE9")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fabrate)
                    .HasColumnName("FABRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Gekcode)
                    .HasColumnName("GEKCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Inclusion)
                    .HasColumnName("INCLUSION")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Keyw).HasColumnName("KEYW");

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Msflow)
                    .HasColumnName("MSFLOW")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Msflowut)
                    .HasColumnName("MSFLOWUT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Opres)
                    .HasColumnName("OPRES")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Opresut)
                    .HasColumnName("OPRESUT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Optemput)
                    .HasColumnName("OPTEMPUT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Optmp)
                    .HasColumnName("OPTMP")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Predicted).HasColumnName("PREDICTED");

                entity.Property(e => e.Project)
                    .HasColumnName("PROJECT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qty)
                    .HasColumnName("QTY")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Rawmat)
                    .HasColumnName("RAWMAT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rawmat2)
                    .HasColumnName("RAWMAT2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rawmat3)
                    .HasColumnName("RAWMAT3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rawmat4)
                    .HasColumnName("RAWMAT4")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rawmat5)
                    .HasColumnName("RAWMAT5")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Reliance)
                    .HasColumnName("RELIANCE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Reliance2)
                    .HasColumnName("RELIANCE2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Reliance3)
                    .HasColumnName("RELIANCE3")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Reliance4)
                    .HasColumnName("RELIANCE4")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Reliance5)
                    .HasColumnName("RELIANCE5")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Shiprate)
                    .HasColumnName("SHIPRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Stateprovince)
                    .HasColumnName("STATEPROVINCE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Supplierid).HasColumnName("SUPPLIERID");

                entity.Property(e => e.Suppliername)
                    .HasColumnName("SUPPLIERNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tchtype).HasColumnName("TCHTYPE");

                entity.Property(e => e.Tcolor).HasColumnName("TCOLOR");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Totalrate)
                    .HasColumnName("TOTALRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Trdate)
                    .HasColumnName("TRDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Tregtype).HasColumnName("TREGTYPE");

                entity.Property(e => e.Trids).HasColumnName("TRIDS");

                entity.Property(e => e.Tunit)
                    .HasColumnName("TUNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tval)
                    .HasColumnName("TVAL")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Virtual).HasColumnName("VIRTUAL");

                entity.Property(e => e.Vlflowut)
                    .HasColumnName("VLFLOWUT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Volflow)
                    .HasColumnName("VOLFLOW")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Weight)
                    .HasColumnName("WEIGHT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Weightunit)
                    .HasColumnName("WEIGHTUNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Material)
                    .HasForeignKey(d => d.Supplierid)
                    .HasConstraintName("FKMaterial1");
            });

            modelBuilder.Entity<OstDbcon>(entity =>
            {
                entity.HasKey(e => e.Ostconid)
                    .HasName("PK__ostdbcon__BA2974563113244E");

                entity.ToTable("OstDBCon");

                entity.Property(e => e.Ostconid).HasColumnName("OSTCONID");

                entity.Property(e => e.Databasename)
                    .HasColumnName("DATABASENAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Host)
                    .HasColumnName("HOST")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("USERNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ParamCondition>(entity =>
            {
                entity.HasKey(e => e.Conditionid)
                    .HasName("PK__paramcon__AF05447CFA90F133");

                entity.Property(e => e.Conditionid).HasColumnName("CONDITIONID");

                entity.Property(e => e.Bidno).HasColumnName("BIDNO");

                entity.Property(e => e.Bimmaterial).HasColumnName("BIMMATERIAL");

                entity.Property(e => e.Bimtype)
                    .HasColumnName("BIMTYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Building)
                    .HasColumnName("BUILDING")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cndid).HasColumnName("CNDID");

                entity.Property(e => e.Cndno).HasColumnName("CNDNO");

                entity.Property(e => e.Cndtype)
                    .HasColumnName("CNDTYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Dbname)
                    .HasColumnName("DBNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Fctstate).HasColumnName("FCTSTATE");

                entity.Property(e => e.Formula1)
                    .HasColumnName("FORMULA1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Formula2)
                    .HasColumnName("FORMULA2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Formula3)
                    .HasColumnName("FORMULA3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Formulaf).HasColumnName("FORMULAF");

                entity.Property(e => e.Globalid)
                    .HasColumnName("GLOBALID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Host)
                    .HasColumnName("HOST")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Layer)
                    .HasColumnName("LAYER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasColumnName("LOCATION")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Paraminputid).HasColumnName("PARAMINPUTID");

                entity.Property(e => e.Paramitemid).HasColumnName("PARAMITEMID");

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qty1)
                    .HasColumnName("QTY1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Qty1name)
                    .HasColumnName("QTY1NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qty2)
                    .HasColumnName("QTY2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Qty2name)
                    .HasColumnName("QTY2NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qty3)
                    .HasColumnName("QTY3")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Qty3name)
                    .HasColumnName("QTY3NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qtyf)
                    .HasColumnName("QTYF")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Qtyfname)
                    .HasColumnName("QTYFNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Selqty).HasColumnName("SELQTY");

                entity.Property(e => e.Storey)
                    .HasColumnName("STOREY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Takeofftype)
                    .HasColumnName("TAKEOFFTYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Unit1)
                    .HasColumnName("UNIT1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Unit2)
                    .HasColumnName("UNIT2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Unit3)
                    .HasColumnName("UNIT3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Unitf)
                    .HasColumnName("UNITF")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("USERNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Virt).HasColumnName("VIRT");

                entity.HasOne(d => d.Paraminput)
                    .WithMany(p => p.ParamCondition)
                    .HasForeignKey(d => d.Paraminputid)
                    .HasConstraintName("FKParamCondition1");
            });

            modelBuilder.Entity<ParamInput>(entity =>
            {
                entity.Property(e => e.Paraminputid).HasColumnName("PARAMINPUTID");

                entity.Property(e => e.Artype)
                    .HasColumnName("ARTYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Datatype)
                    .HasColumnName("DATATYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Defvalue).HasColumnName("DEFVALUE");

                entity.Property(e => e.Dependency).HasColumnName("DEPENDENCY");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editable).HasColumnName("EDITABLE");

                entity.Property(e => e.Grouping)
                    .HasColumnName("GROUPING")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Hidden).HasColumnName("HIDDEN");

                entity.Property(e => e.Lbl)
                    .HasColumnName("LBL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Paramitemid).HasColumnName("PARAMITEMID");

                entity.Property(e => e.Pblk).HasColumnName("PBLK");

                entity.Property(e => e.Selection).HasColumnName("SELECTION");

                entity.Property(e => e.Sortorder).HasColumnName("SORTORDER");

                entity.Property(e => e.Stoval)
                    .HasColumnName("STOVAL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Validation).HasColumnName("VALIDATION");
            });

            modelBuilder.Entity<ParamItem>(entity =>
            {
                entity.Property(e => e.Paramitemid).HasColumnName("PARAMITEMID");

                entity.Property(e => e.Accrights)
                    .HasColumnName("ACCRIGHTS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cmodel).HasColumnName("CMODEL");

                entity.Property(e => e.Createdate)
                    .HasColumnName("CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Createuserid)
                    .HasColumnName("CREATEUSERID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Databasecreationdate).HasColumnName("DATABASECREATIONDATE");

                entity.Property(e => e.Databaseid).HasColumnName("DATABASEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode1)
                    .HasColumnName("EXTRACODE1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode10)
                    .HasColumnName("EXTRACODE10")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode2)
                    .HasColumnName("EXTRACODE2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode3)
                    .HasColumnName("EXTRACODE3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode4)
                    .HasColumnName("EXTRACODE4")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode5)
                    .HasColumnName("EXTRACODE5")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode6)
                    .HasColumnName("EXTRACODE6")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode7)
                    .HasColumnName("EXTRACODE7")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode8)
                    .HasColumnName("EXTRACODE8")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode9)
                    .HasColumnName("EXTRACODE9")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gekcode)
                    .HasColumnName("GEKCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Groupname)
                    .HasColumnName("GROUPNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Icon)
                    .HasColumnName("ICON")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Keyw).HasColumnName("KEYW");

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Loc)
                    .HasColumnName("LOC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Prttype)
                    .HasColumnName("PRTTYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pswd)
                    .HasColumnName("PSWD")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qty)
                    .HasColumnName("QTY")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Samplerate)
                    .HasColumnName("SAMPLERATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Snum).HasColumnName("SNUM");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Totalcost)
                    .HasColumnName("TOTALCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Variable)
                    .HasColumnName("VARIABLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Wbs)
                    .HasColumnName("WBS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Wbs2)
                    .HasColumnName("WBS2")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ParamOutput>(entity =>
            {
                entity.Property(e => e.Paramoutputid).HasColumnName("PARAMOUTPUTID");

                entity.Property(e => e.Conloceq).HasColumnName("CONLOCEQ");

                entity.Property(e => e.Equloceq).HasColumnName("EQULOCEQ");

                entity.Property(e => e.Factoreq).HasColumnName("FACTOREQ");

                entity.Property(e => e.Generation).HasColumnName("GENERATION");

                entity.Property(e => e.Labloceq).HasColumnName("LABLOCEQ");

                entity.Property(e => e.Matloceq).HasColumnName("MATLOCEQ");

                entity.Property(e => e.Paramitemid).HasColumnName("PARAMITEMID");

                entity.Property(e => e.Prdeq).HasColumnName("PRDEQ");

                entity.Property(e => e.Qtyeq).HasColumnName("QTYEQ");

                entity.Property(e => e.Resids).HasColumnName("RESIDS");

                entity.Property(e => e.Sortorder).HasColumnName("SORTORDER");

                entity.Property(e => e.Subloceq).HasColumnName("SUBLOCEQ");

                entity.Property(e => e.Title).HasColumnName("TITLE");
            });

            modelBuilder.Entity<ParamReturn>(entity =>
            {
                entity.Property(e => e.Paramreturnid).HasColumnName("PARAMRETURNID");

                entity.Property(e => e.Paramitemid).HasColumnName("PARAMITEMID");

                entity.Property(e => e.Reteq).HasColumnName("RETEQ");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Paymentid).HasColumnName("PAYMENTID");

                entity.Property(e => e.Category)
                    .HasColumnName("CATEGORY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CustomCompensation)
                    .HasColumnName("CUSTOM_COMPENSATION")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Factor)
                    .HasColumnName("FACTOR")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Months)
                    .HasColumnName("MONTHS")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.PaymentAmount)
                    .HasColumnName("PAYMENT_AMOUNT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Paymentincid).HasColumnName("PAYMENTINCID");
            });

            modelBuilder.Entity<PrjProp>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Pkey)
                    .HasColumnName("PKEY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Projecturlid).HasColumnName("PROJECTURLID");

                entity.Property(e => e.Pval).HasColumnName("PVAL");

                entity.HasOne(d => d.Projecturl)
                    .WithMany(p => p.PrjProp)
                    .HasForeignKey(d => d.Projecturlid)
                    .HasConstraintName("FKPrjProp1");
            });

            modelBuilder.Entity<ProjectAccess>(entity =>
            {
                entity.HasKey(e => e.Paid)
                    .HasName("PK__projecta__5986FD6D712C40D9");

                entity.Property(e => e.Paid).HasColumnName("PAID");

                entity.Property(e => e.Acccon).HasColumnName("ACCCON");

                entity.Property(e => e.Aladd).HasColumnName("ALADD");

                entity.Property(e => e.Alrem).HasColumnName("ALREM");

                entity.Property(e => e.Alupd).HasColumnName("ALUPD");

                entity.Property(e => e.Puid).HasColumnName("PUID");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Pu)
                    .WithMany(p => p.ProjectAccess)
                    .HasForeignKey(d => d.Puid)
                    .HasConstraintName("FKProjectAccess1");
            });

            modelBuilder.Entity<ProjectEps>(entity =>
            {
                entity.ToTable("ProjectEPS");

                entity.Property(e => e.Projectepsid).HasColumnName("PROJECTEPSID");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Parentid).HasColumnName("PARENTID");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjectInfo>(entity =>
            {
                entity.Property(e => e.Projectinfoid).HasColumnName("PROJECTINFOID");

                entity.Property(e => e.Basement)
                    .HasColumnName("BASEMENT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Bimtakeoff).HasColumnName("BIMTAKEOFF");

                entity.Property(e => e.Client)
                    .HasColumnName("CLIENT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Clientbudget)
                    .HasColumnName("CLIENTBUDGET")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Codestyle)
                    .HasColumnName("CODESTYLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Contractor)
                    .HasColumnName("CONTRACTOR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Createdate)
                    .HasColumnName("CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Creatorid)
                    .HasColumnName("CREATORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Duration).HasColumnName("DURATION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Epscode)
                    .HasColumnName("EPSCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Floors).HasColumnName("FLOORS");

                entity.Property(e => e.Geoloc)
                    .HasColumnName("GEOLOC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Location)
                    .HasColumnName("LOCATION")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Locfac).HasColumnName("LOCFAC");

                entity.Property(e => e.Locprof)
                    .HasColumnName("LOCPROF")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Mainsite)
                    .HasColumnName("MAINSITE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Offeredprice)
                    .HasColumnName("OFFEREDPRICE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Ostakeoff).HasColumnName("OSTAKEOFF");

                entity.Property(e => e.Primavera).HasColumnName("PRIMAVERA");

                entity.Property(e => e.Prjsubcat)
                    .HasColumnName("PRJSUBCAT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Prjtype)
                    .HasColumnName("PRJTYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Projectepsid).HasColumnName("PROJECTEPSID");

                entity.Property(e => e.Selfac)
                    .HasColumnName("SELFAC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasColumnName("STATE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Storagetype)
                    .HasColumnName("STORAGETYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Subdate)
                    .HasColumnName("SUBDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Totalcost)
                    .HasColumnName("TOTALCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Unitcost)
                    .HasColumnName("UNITCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.HasOne(d => d.Projecteps)
                    .WithMany(p => p.ProjectInfo)
                    .HasForeignKey(d => d.Projectepsid)
                    .HasConstraintName("FKProjectInfo1");
            });

            modelBuilder.Entity<ProjectUrl>(entity =>
            {
                entity.ToTable("ProjectURL");

                entity.Property(e => e.Projecturlid).HasColumnName("PROJECTURLID");

                entity.Property(e => e.Approved).HasColumnName("APPROVED");

                entity.Property(e => e.Completed).HasColumnName("COMPLETED");

                entity.Property(e => e.Createdate)
                    .HasColumnName("CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Creuserid)
                    .HasColumnName("CREUSERID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Dbhost)
                    .HasColumnName("DBHOST")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Dbname)
                    .HasColumnName("DBNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Dbport)
                    .HasColumnName("DBPORT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Dbpswd)
                    .HasColumnName("DBPSWD")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Dbsrv).HasColumnName("DBSRV");

                entity.Property(e => e.Dbusr)
                    .HasColumnName("DBUSR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Defrev).HasColumnName("DEFREV");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Esttotal)
                    .HasColumnName("ESTTOTAL")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Markuptotal)
                    .HasColumnName("MARKUPTOTAL")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pending).HasColumnName("PENDING");

                entity.Property(e => e.Projectinfoid).HasColumnName("PROJECTINFOID");

                entity.Property(e => e.Qrecv).HasColumnName("QRECV");

                entity.Property(e => e.Qsent).HasColumnName("QSENT");

                entity.Property(e => e.Quotedtotal)
                    .HasColumnName("QUOTEDTOTAL")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Rvson)
                    .HasColumnName("RVSON")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Underreview).HasColumnName("UNDERREVIEW");

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Projectinfo)
                    .WithMany(p => p.ProjectUrl)
                    .HasForeignKey(d => d.Projectinfoid)
                    .HasConstraintName("FKProjectURL1");
            });

            modelBuilder.Entity<ProjectUser>(entity =>
            {
                entity.HasKey(e => e.Puid)
                    .HasName("PK__projectu__B280976D9D7EC668");

                entity.Property(e => e.Puid).HasColumnName("PUID");

                entity.Property(e => e.Aditms).HasColumnName("ADITMS");

                entity.Property(e => e.Admn).HasColumnName("ADMN");

                entity.Property(e => e.Aquote).HasColumnName("AQUOTE");

                entity.Property(e => e.Editms).HasColumnName("EDITMS");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Esclte).HasColumnName("ESCLTE");

                entity.Property(e => e.Estim).HasColumnName("ESTIM");

                entity.Property(e => e.Projectinfoid).HasColumnName("PROJECTINFOID");

                entity.Property(e => e.Props).HasColumnName("PROPS");

                entity.Property(e => e.Rmitms).HasColumnName("RMITMS");

                entity.Property(e => e.Rquote).HasColumnName("RQUOTE");

                entity.Property(e => e.Rsrc).HasColumnName("RSRC");

                entity.Property(e => e.Squote).HasColumnName("SQUOTE");

                entity.Property(e => e.Takeoff).HasColumnName("TAKEOFF");

                entity.Property(e => e.Uname)
                    .HasColumnName("UNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Userid)
                    .HasColumnName("USERID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Vaitms).HasColumnName("VAITMS");

                entity.Property(e => e.Wbs).HasColumnName("WBS");

                entity.Property(e => e.Xchange).HasColumnName("XCHANGE");

                entity.HasOne(d => d.Projectinfo)
                    .WithMany(p => p.ProjectUser)
                    .HasForeignKey(d => d.Projectinfoid)
                    .HasConstraintName("FKProjectUser1");
            });

            modelBuilder.Entity<ProjectWbs>(entity =>
            {
                entity.ToTable("ProjectWBS");

                entity.Property(e => e.Projectwbsid).HasColumnName("PROJECTWBSID");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Itemcode)
                    .HasColumnName("ITEMCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Projectinfoid).HasColumnName("PROJECTINFOID");

                entity.Property(e => e.Projectname)
                    .HasColumnName("PROJECTNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Projectinfo)
                    .WithMany(p => p.ProjectWbs)
                    .HasForeignKey(d => d.Projectinfoid)
                    .HasConstraintName("FKProjectWBS1");
            });

            modelBuilder.Entity<ProjectWbs2>(entity =>
            {
                entity.HasKey(e => e.Projectwbsid)
                    .HasName("PK__projectw__2089D4847DB828B2");

                entity.ToTable("ProjectWBS2");

                entity.Property(e => e.Projectwbsid).HasColumnName("PROJECTWBSID");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Itemcode)
                    .HasColumnName("ITEMCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Projectinfoid).HasColumnName("PROJECTINFOID");

                entity.Property(e => e.Projectname)
                    .HasColumnName("PROJECTNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Ufact)
                    .HasColumnName("UFACT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Projectinfo)
                    .WithMany(p => p.ProjectWbs2)
                    .HasForeignKey(d => d.Projectinfoid)
                    .HasConstraintName("FKProjectWBS2");
            });

            modelBuilder.Entity<QueryResource>(entity =>
            {
                entity.HasKey(e => e.Qresid)
                    .HasName("PK__queryres__E123B438F83C7683");

                entity.Property(e => e.Qresid).HasColumnName("QRESID");

                entity.Property(e => e.Ascdng).HasColumnName("ASCDNG");

                entity.Property(e => e.Cc01eq).HasColumnName("CC01EQ");

                entity.Property(e => e.Cc02eq).HasColumnName("CC02EQ");

                entity.Property(e => e.Cc03eq).HasColumnName("CC03EQ");

                entity.Property(e => e.Cc04eq).HasColumnName("CC04EQ");

                entity.Property(e => e.Cc05eq).HasColumnName("CC05EQ");

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

                entity.Property(e => e.Dsceq).HasColumnName("DSCEQ");

                entity.Property(e => e.Gc1eq).HasColumnName("GC1EQ");

                entity.Property(e => e.Gc2eq).HasColumnName("GC2EQ");

                entity.Property(e => e.Gc3eq).HasColumnName("GC3EQ");

                entity.Property(e => e.Gc4eq).HasColumnName("GC4EQ");

                entity.Property(e => e.Gc5eq).HasColumnName("GC5EQ");

                entity.Property(e => e.Gc6eq).HasColumnName("GC6EQ");

                entity.Property(e => e.Gc7eq).HasColumnName("GC7EQ");

                entity.Property(e => e.Gc8eq).HasColumnName("GC8EQ");

                entity.Property(e => e.Gc9eq).HasColumnName("GC9EQ");

                entity.Property(e => e.Loceq).HasColumnName("LOCEQ");

                entity.Property(e => e.Ntseq).HasColumnName("NTSEQ");

                entity.Property(e => e.Ordfld)
                    .HasColumnName("ORDFLD")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Paramoutputid).HasColumnName("PARAMOUTPUTID");

                entity.Property(e => e.Pdteq).HasColumnName("PDTEQ");

                entity.Property(e => e.Piceq).HasColumnName("PICEQ");

                entity.Property(e => e.Prdeq).HasColumnName("PRDEQ");

                entity.Property(e => e.Prfeq).HasColumnName("PRFEQ");

                entity.Property(e => e.Restype)
                    .HasColumnName("RESTYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sngsel).HasColumnName("SNGSEL");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tlteq).HasColumnName("TLTEQ");

                entity.Property(e => e.Wb1eq).HasColumnName("WB1EQ");

                entity.Property(e => e.Wb2eq).HasColumnName("WB2EQ");

                entity.HasOne(d => d.Paramoutput)
                    .WithMany(p => p.QueryResource)
                    .HasForeignKey(d => d.Paramoutputid)
                    .HasConstraintName("FKQueryResource1");
            });

            modelBuilder.Entity<QueryRow>(entity =>
            {
                entity.HasKey(e => e.Qrowid)
                    .HasName("PK__queryrow__4AE9FF7B5045096D");

                entity.Property(e => e.Qrowid).HasColumnName("QROWID");

                entity.Property(e => e.Cndn).HasColumnName("CNDN");

                entity.Property(e => e.Ctype)
                    .HasColumnName("CTYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .HasColumnName("FNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qresid).HasColumnName("QRESID");

                entity.Property(e => e.Qrowscount).HasColumnName("QROWSCOUNT");

                entity.Property(e => e.Rname)
                    .HasColumnName("RNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Qres)
                    .WithMany(p => p.QueryRow)
                    .HasForeignKey(d => d.Qresid)
                    .HasConstraintName("FKQueryRow1");
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.HasKey(e => e.Expenseid)
                    .HasName("PK__quote__D98AC9980A04B225");

                entity.Property(e => e.Expenseid).HasColumnName("EXPENSEID");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Bccmail)
                    .HasColumnName("BCCMAIL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ccmail)
                    .HasColumnName("CCMAIL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("CITY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .HasColumnName("COMPANY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Contact)
                    .HasColumnName("CONTACT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Createdate)
                    .HasColumnName("CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Delivery).HasColumnName("DELIVERY");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasColumnName("FAX")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Geopos)
                    .HasColumnName("GEOPOS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Hasmatrate).HasColumnName("HASMATRATE");

                entity.Property(e => e.Mobile)
                    .HasColumnName("MOBILE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Performance).HasColumnName("PERFORMANCE");

                entity.Property(e => e.Phone)
                    .HasColumnName("PHONE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Quotetype)
                    .HasColumnName("QUOTETYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Receiveddate)
                    .HasColumnName("RECEIVEDDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sentdate)
                    .HasColumnName("SENTDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Statepro)
                    .HasColumnName("STATEPRO")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasColumnName("SUBJECT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tomail)
                    .HasColumnName("TOMAIL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QuoteItem>(entity =>
            {
                entity.Property(e => e.Quoteitemid).HasColumnName("QUOTEITEMID");

                entity.Property(e => e.Boqitemid).HasColumnName("BOQITEMID");

                entity.Property(e => e.Databaseid).HasColumnName("DATABASEID");

                entity.Property(e => e.Dbcreatedate).HasColumnName("DBCREATEDATE");

                entity.Property(e => e.Factor1)
                    .HasColumnName("FACTOR1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Factor2)
                    .HasColumnName("FACTOR2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Finalrate)
                    .HasColumnName("FINALRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Insurance)
                    .HasColumnName("INSURANCE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Parqrty)
                    .HasColumnName("PARQRTY")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Quotationid).HasColumnName("QUOTATIONID");

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Rsrc).HasColumnName("RSRC");

                entity.Property(e => e.Shipmentcost)
                    .HasColumnName("SHIPMENTCOST")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Supdbid).HasColumnName("SUPDBID");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Quotation)
                    .WithMany(p => p.QuoteItem)
                    .HasForeignKey(d => d.Quotationid)
                    .HasConstraintName("FKQuoteItem1");
            });

            modelBuilder.Entity<RawMaterial>(entity =>
            {
                entity.HasKey(e => e.Rawmatid)
                    .HasName("PK__rawmater__3C967267F39E90BC");

                entity.Property(e => e.Rawmatid).HasColumnName("RAWMATID");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.RateDate)
                    .HasColumnName("RATE_DATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Rpdfn>(entity =>
            {
                entity.ToTable("RPDFN");

                entity.Property(e => e.Rpdfnid).HasColumnName("RPDFNID");

                entity.Property(e => e.Rcredate)
                    .HasColumnName("RCREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Rcreuser)
                    .HasColumnName("RCREUSER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rdesc).HasColumnName("RDESC");

                entity.Property(e => e.Rdsgn)
                    .HasColumnName("RDSGN")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Redtid)
                    .HasColumnName("REDTID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rgrp)
                    .HasColumnName("RGRP")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ricn)
                    .HasColumnName("RICN")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rlastupd)
                    .HasColumnName("RLASTUPD")
                    .HasColumnType("datetime");

                entity.Property(e => e.Rname)
                    .HasColumnName("RNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rpblk).HasColumnName("RPBLK");

                entity.Property(e => e.Rusrrep).HasColumnName("RUSRREP");
            });

            modelBuilder.Entity<SubHistory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Basetableid)
                    .HasColumnName("BASETABLEID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Preddate)
                    .HasColumnName("PREDDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Resource).HasColumnName("RESOURCE");

                entity.Property(e => e.Rsrc).HasColumnName("RSRC");

                entity.Property(e => e.Subcontractorid).HasColumnName("SUBCONTRACTORID");

                entity.HasOne(d => d.Subcontractor)
                    .WithMany(p => p.SubHistory)
                    .HasForeignKey(d => d.Subcontractorid)
                    .HasConstraintName("FKSubHistory1");
            });

            modelBuilder.Entity<Subcontractor>(entity =>
            {
                entity.Property(e => e.Subcontractorid).HasColumnName("SUBCONTRACTORID");

                entity.Property(e => e.Accrights)
                    .HasColumnName("ACCRIGHTS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Accuracy)
                    .HasColumnName("ACCURACY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("CITY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .HasColumnName("COMPANY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Conceptual).HasColumnName("CONCEPTUAL");

                entity.Property(e => e.Contactperson)
                    .HasColumnName("CONTACTPERSON")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Createdate)
                    .HasColumnName("CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Createuser)
                    .HasColumnName("CREATEUSER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Databasecreationdate).HasColumnName("DATABASECREATIONDATE");

                entity.Property(e => e.Databaseid).HasColumnName("DATABASEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode1)
                    .IsRequired()
                    .HasColumnName("EXTRACODE1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode10)
                    .IsRequired()
                    .HasColumnName("EXTRACODE10")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode2)
                    .IsRequired()
                    .HasColumnName("EXTRACODE2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode3)
                    .IsRequired()
                    .HasColumnName("EXTRACODE3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode4)
                    .IsRequired()
                    .HasColumnName("EXTRACODE4")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode5)
                    .IsRequired()
                    .HasColumnName("EXTRACODE5")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode6)
                    .IsRequired()
                    .HasColumnName("EXTRACODE6")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode7)
                    .IsRequired()
                    .HasColumnName("EXTRACODE7")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode8)
                    .IsRequired()
                    .HasColumnName("EXTRACODE8")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode9)
                    .IsRequired()
                    .HasColumnName("EXTRACODE9")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Faxnumber)
                    .HasColumnName("FAXNUMBER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gekcode)
                    .HasColumnName("GEKCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ika)
                    .HasColumnName("IKA")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Inclusion)
                    .HasColumnName("INCLUSION")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Keyw).HasColumnName("KEYW");

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mobilenumber)
                    .HasColumnName("MOBILENUMBER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Performance)
                    .HasColumnName("PERFORMANCE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phonenumber)
                    .HasColumnName("PHONENUMBER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Predicted).HasColumnName("PREDICTED");

                entity.Property(e => e.Project)
                    .HasColumnName("PROJECT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qty)
                    .HasColumnName("QTY")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Stateprovince)
                    .HasColumnName("STATEPROVINCE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tchtype).HasColumnName("TCHTYPE");

                entity.Property(e => e.Tcolor).HasColumnName("TCOLOR");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Totalrate)
                    .HasColumnName("TOTALRATE")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Trdate)
                    .HasColumnName("TRDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Tregtype).HasColumnName("TREGTYPE");

                entity.Property(e => e.Trids).HasColumnName("TRIDS");

                entity.Property(e => e.Tunit)
                    .HasColumnName("TUNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tval)
                    .HasColumnName("TVAL")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Virtual).HasColumnName("VIRTUAL");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.Supplierid).HasColumnName("SUPPLIERID");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("CITY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Contactperson)
                    .HasColumnName("CONTACTPERSON")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Createdate)
                    .HasColumnName("CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Createuser)
                    .HasColumnName("CREATEUSER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Databasecreationdate).HasColumnName("DATABASECREATIONDATE");

                entity.Property(e => e.Databaseid).HasColumnName("DATABASEID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode1)
                    .IsRequired()
                    .HasColumnName("EXTRACODE1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode10)
                    .IsRequired()
                    .HasColumnName("EXTRACODE10")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode2)
                    .IsRequired()
                    .HasColumnName("EXTRACODE2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode3)
                    .IsRequired()
                    .HasColumnName("EXTRACODE3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode4)
                    .IsRequired()
                    .HasColumnName("EXTRACODE4")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode5)
                    .IsRequired()
                    .HasColumnName("EXTRACODE5")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode6)
                    .IsRequired()
                    .HasColumnName("EXTRACODE6")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode7)
                    .IsRequired()
                    .HasColumnName("EXTRACODE7")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode8)
                    .IsRequired()
                    .HasColumnName("EXTRACODE8")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Extracode9)
                    .IsRequired()
                    .HasColumnName("EXTRACODE9")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Faxnumber)
                    .HasColumnName("FAXNUMBER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gekcode)
                    .HasColumnName("GEKCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Geoloc)
                    .HasColumnName("GEOLOC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mobilenumber)
                    .HasColumnName("MOBILENUMBER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Performance)
                    .HasColumnName("PERFORMANCE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phonenumber)
                    .HasColumnName("PHONENUMBER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Stateprovince)
                    .HasColumnName("STATEPROVINCE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TakeOffArea>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aid).HasColumnName("AID");

                entity.Property(e => e.Areacount).HasColumnName("AREACOUNT");

                entity.Property(e => e.Blankfill).HasColumnName("BLANKFILL");

                entity.Property(e => e.Conline).HasColumnName("CONLINE");

                entity.Property(e => e.Tension)
                    .HasColumnName("TENSION")
                    .HasColumnType("decimal(30, 10)");

                entity.HasOne(d => d.A)
                    .WithMany(p => p.TakeOffArea)
                    .HasForeignKey(d => d.Aid)
                    .HasConstraintName("FKTakeOffArea1");
            });

            modelBuilder.Entity<TakeOffCon>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cndtype)
                    .HasColumnName("CNDTYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Colour)
                    .HasColumnName("COLOUR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Createdate)
                    .HasColumnName("CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Createuserid)
                    .HasColumnName("CREATEUSERID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Depth)
                    .HasColumnName("DEPTH")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Elevation).HasColumnName("ELEVATION");

                entity.Property(e => e.Grouping)
                    .HasColumnName("GROUPING")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Height)
                    .HasColumnName("HEIGHT")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("LASTUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Patterntype).HasColumnName("PATTERNTYPE");

                entity.Property(e => e.Projectinfoid).HasColumnName("PROJECTINFOID");

                entity.Property(e => e.Qty1)
                    .HasColumnName("QTY1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Qty1type)
                    .HasColumnName("QTY1TYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qty2)
                    .HasColumnName("QTY2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Qty2type)
                    .HasColumnName("QTY2TYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Qty3)
                    .HasColumnName("QTY3")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Qty3type)
                    .HasColumnName("QTY3TYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Samples).HasColumnName("SAMPLES");

                entity.Property(e => e.Shapetype).HasColumnName("SHAPETYPE");

                entity.Property(e => e.Takeoff)
                    .HasColumnName("TAKEOFF")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Thickness)
                    .HasColumnName("THICKNESS")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Uom1)
                    .HasColumnName("UOM1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Uom2)
                    .HasColumnName("UOM2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Uom3)
                    .HasColumnName("UOM3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Width)
                    .HasColumnName("WIDTH")
                    .HasColumnType("decimal(30, 10)");

                entity.HasOne(d => d.Projectinfo)
                    .WithMany(p => p.TakeOffCon)
                    .HasForeignKey(d => d.Projectinfoid)
                    .HasConstraintName("FKTakeOffCon1");
            });

            modelBuilder.Entity<TakeOffLine>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ex)
                    .HasColumnName("EX")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Ey)
                    .HasColumnName("EY")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Lid).HasColumnName("LID");

                entity.Property(e => e.Linescount).HasColumnName("LINESCOUNT");

                entity.Property(e => e.Sx)
                    .HasColumnName("SX")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Sy)
                    .HasColumnName("SY")
                    .HasColumnType("decimal(30, 10)");

                entity.HasOne(d => d.L)
                    .WithMany(p => p.TakeOffLine)
                    .HasForeignKey(d => d.Lid)
                    .HasConstraintName("FKTakeOffline1");
            });

            modelBuilder.Entity<TakeOffPoint>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.Property(e => e.Elevcount).HasColumnName("ELEVCOUNT");

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.Pointcount).HasColumnName("POINTCOUNT");

                entity.Property(e => e.Polycount).HasColumnName("POLYCOUNT");

                entity.Property(e => e.Sid).HasColumnName("SID");

                entity.Property(e => e.Xpos)
                    .HasColumnName("XPOS")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Ypos)
                    .HasColumnName("YPOS")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Zpos)
                    .HasColumnName("ZPOS")
                    .HasColumnType("decimal(30, 10)");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.TakeOffPoint)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FKTakeOffPoint1");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.TakeOffPoint)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("FKTakeOffPoint2");

                entity.HasOne(d => d.S)
                    .WithMany(p => p.TakeOffPoint)
                    .HasForeignKey(d => d.Sid)
                    .HasConstraintName("FKTakeOffPoint3");
            });

            modelBuilder.Entity<TakeOffTriangle>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Tid).HasColumnName("TID");

                entity.Property(e => e.Triacount).HasColumnName("TRIACOUNT");

                entity.Property(e => e.Xpos1)
                    .HasColumnName("XPOS1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Xpos2)
                    .HasColumnName("XPOS2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Xpos3)
                    .HasColumnName("XPOS3")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Ypos1)
                    .HasColumnName("YPOS1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Ypos2)
                    .HasColumnName("YPOS2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Ypos3)
                    .HasColumnName("YPOS3")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Zpos1)
                    .HasColumnName("ZPOS1")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Zpos2)
                    .HasColumnName("ZPOS2")
                    .HasColumnType("decimal(30, 10)");

                entity.Property(e => e.Zpos3)
                    .HasColumnName("ZPOS3")
                    .HasColumnType("decimal(30, 10)");

                entity.HasOne(d => d.T)
                    .WithMany(p => p.TakeOffTriangle)
                    .HasForeignKey(d => d.Tid)
                    .HasConstraintName("FKTakeOffTriangle1");
            });

            modelBuilder.Entity<UnitAlias>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Frunit)
                    .HasColumnName("FRUNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tounit)
                    .HasColumnName("TOUNIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
