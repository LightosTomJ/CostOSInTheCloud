using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Models
{
    public partial class Costos2019Context : DbContext
    {
        public Costos2019Context()
        {
        }

        public Costos2019Context(DbContextOptions<Costos2019Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Ad> Ad { get; set; }
        public virtual DbSet<AlcAmusers> AlcAmusers { get; set; }
        public virtual DbSet<AlcGroups> AlcGroups { get; set; }
        public virtual DbSet<AlcObjectsInUse> AlcObjectsInUse { get; set; }
        public virtual DbSet<AlcObjectsStatus> AlcObjectsStatus { get; set; }
        public virtual DbSet<AlcSettingCodes> AlcSettingCodes { get; set; }
        public virtual DbSet<AlcUl> AlcUl { get; set; }
        public virtual DbSet<AlcUserGroups> AlcUserGroups { get; set; }
        public virtual DbSet<AlcUserSettings> AlcUserSettings { get; set; }
        public virtual DbSet<Assembly> Assembly { get; set; }
        public virtual DbSet<AssemblyChild> AssemblyChild { get; set; }
        public virtual DbSet<AssemblyConsumable> AssemblyConsumable { get; set; }
        public virtual DbSet<AssemblyEquipment> AssemblyEquipment { get; set; }
        public virtual DbSet<AssemblyLabor> AssemblyLabor { get; set; }
        public virtual DbSet<AssemblyMaterial> AssemblyMaterial { get; set; }
        public virtual DbSet<AssemblySubcontractor> AssemblySubcontractor { get; set; }
        public virtual DbSet<BcClassification> BcClassification { get; set; }
        public virtual DbSet<BcClassitem> BcClassitem { get; set; }
        public virtual DbSet<BcElemclassitem> BcElemclassitem { get; set; }
        public virtual DbSet<BcElemconnection> BcElemconnection { get; set; }
        public virtual DbSet<BcElemcovering> BcElemcovering { get; set; }
        public virtual DbSet<BcElement> BcElement { get; set; }
        public virtual DbSet<BcElementinfo> BcElementinfo { get; set; }
        public virtual DbSet<BcElemmaterial> BcElemmaterial { get; set; }
        public virtual DbSet<BcElemprop> BcElemprop { get; set; }
        public virtual DbSet<BcGeometry> BcGeometry { get; set; }
        public virtual DbSet<BcGeomfile> BcGeomfile { get; set; }
        public virtual DbSet<BcGpuserver> BcGpuserver { get; set; }
        public virtual DbSet<BcGroup> BcGroup { get; set; }
        public virtual DbSet<BcGroupelem> BcGroupelem { get; set; }
        public virtual DbSet<BcGroupprop> BcGroupprop { get; set; }
        public virtual DbSet<BcMaterial> BcMaterial { get; set; }
        public virtual DbSet<BcModel> BcModel { get; set; }
        public virtual DbSet<BcProject> BcProject { get; set; }
        public virtual DbSet<BcQuantity> BcQuantity { get; set; }
        public virtual DbSet<BcScene> BcScene { get; set; }
        public virtual DbSet<BcSpatialinfo> BcSpatialinfo { get; set; }
        public virtual DbSet<Benchmarkboqcolmap> Benchmarkboqcolmap { get; set; }
        public virtual DbSet<Boqitemmetadata> Boqitemmetadata { get; set; }
        public virtual DbSet<Cntrlog> Cntrlog { get; set; }
        public virtual DbSet<Cntrlogitem> Cntrlogitem { get; set; }
        public virtual DbSet<Conceptuals> Conceptuals { get; set; }
        public virtual DbSet<Consumable> Consumable { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Extalias> Extalias { get; set; }
        public virtual DbSet<Extdatasource> Extdatasource { get; set; }
        public virtual DbSet<Extquery> Extquery { get; set; }
        public virtual DbSet<Extracode1> Extracode1 { get; set; }
        public virtual DbSet<Extracode2> Extracode2 { get; set; }
        public virtual DbSet<Extracode3> Extracode3 { get; set; }
        public virtual DbSet<Extracode4> Extracode4 { get; set; }
        public virtual DbSet<Extracode5> Extracode5 { get; set; }
        public virtual DbSet<Extracode6> Extracode6 { get; set; }
        public virtual DbSet<Extracode7> Extracode7 { get; set; }
        public virtual DbSet<Fieldcustom> Fieldcustom { get; set; }
        public virtual DbSet<Filtro> Filtro { get; set; }
        public virtual DbSet<Filtroproperty> Filtroproperty { get; set; }
        public virtual DbSet<Fldfn> Fldfn { get; set; }
        public virtual DbSet<Fncton> Fncton { get; set; }
        public virtual DbSet<FnctonArgument> FnctonArgument { get; set; }
        public virtual DbSet<Gekcode> Gekcode { get; set; }
        public virtual DbSet<Glbprop> Glbprop { get; set; }
        public virtual DbSet<Groupcode> Groupcode { get; set; }
        public virtual DbSet<Labor> Labor { get; set; }
        public virtual DbSet<Layoutc> Layoutc { get; set; }
        public virtual DbSet<Layoutcpanel> Layoutcpanel { get; set; }
        public virtual DbSet<Lictbl> Lictbl { get; set; }
        public virtual DbSet<Locfactor> Locfactor { get; set; }
        public virtual DbSet<Locprof> Locprof { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<Paraminput> Paraminput { get; set; }
        public virtual DbSet<Paramitem> Paramitem { get; set; }
        public virtual DbSet<Paramoutput> Paramoutput { get; set; }
        public virtual DbSet<Paramreturn> Paramreturn { get; set; }
        public virtual DbSet<Principals> Principals { get; set; }
        public virtual DbSet<Prjdbms> Prjdbms { get; set; }
        public virtual DbSet<Prjprop> Prjprop { get; set; }
        public virtual DbSet<Projectaccess> Projectaccess { get; set; }
        public virtual DbSet<Projecteps> Projecteps { get; set; }
        public virtual DbSet<Projectinfo> Projectinfo { get; set; }
        public virtual DbSet<Projectspecvar> Projectspecvar { get; set; }
        public virtual DbSet<Projecttemplate> Projecttemplate { get; set; }
        public virtual DbSet<Projecturl> Projecturl { get; set; }
        public virtual DbSet<Projectuser> Projectuser { get; set; }
        public virtual DbSet<Projectusertemplate> Projectusertemplate { get; set; }
        public virtual DbSet<Queryresource> Queryresource { get; set; }
        public virtual DbSet<Queryrow> Queryrow { get; set; }
        public virtual DbSet<Quotetemplate> Quotetemplate { get; set; }
        public virtual DbSet<Ratebuildup> Ratebuildup { get; set; }
        public virtual DbSet<Ratebuildupcols> Ratebuildupcols { get; set; }
        public virtual DbSet<Ratedistrib> Ratedistrib { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Rpdfn> Rpdfn { get; set; }
        public virtual DbSet<Subcontractor> Subcontractor { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Takeoffarea> Takeoffarea { get; set; }
        public virtual DbSet<Takeoffcon> Takeoffcon { get; set; }
        public virtual DbSet<Takeofflegend> Takeofflegend { get; set; }
        public virtual DbSet<Takeoffline> Takeoffline { get; set; }
        public virtual DbSet<Takeoffpoint> Takeoffpoint { get; set; }
        public virtual DbSet<Takeofftriangle> Takeofftriangle { get; set; }
        public virtual DbSet<Teamalias> Teamalias { get; set; }
        public virtual DbSet<Unitalias> Unitalias { get; set; }
        public virtual DbSet<Userprop> Userprop { get; set; }
        public virtual DbSet<Usersessions> Usersessions { get; set; }
        public virtual DbSet<Wscolident> Wscolident { get; set; }
        public virtual DbSet<Wsdatamapping> Wsdatamapping { get; set; }
        public virtual DbSet<Wsfile> Wsfile { get; set; }
        public virtual DbSet<Wsrevision> Wsrevision { get; set; }
        public virtual DbSet<Xcellfile> Xcellfile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-QDVS6I6;Initial Catalog=Costos2019;Persist Security Info=False;User ID=admin;Password=admin");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Ad>(entity =>
            {
                entity.ToTable("AD");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Basedn)
                    .HasColumnName("BASEDN")
                    .HasMaxLength(255);

                entity.Property(e => e.Binddn)
                    .HasColumnName("BINDDN")
                    .HasMaxLength(255);

                entity.Property(e => e.Enable).HasColumnName("ENABLE");

                entity.Property(e => e.Hostname)
                    .HasColumnName("HOSTNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Isssl).HasColumnName("ISSSL");

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(255);

                entity.Property(e => e.Port).HasColumnName("PORT");

                entity.Property(e => e.Profile)
                    .HasColumnName("PROFILE")
                    .HasMaxLength(255);

                entity.Property(e => e.Searchfilter)
                    .HasColumnName("SEARCHFILTER")
                    .HasMaxLength(255);

                entity.Property(e => e.Statusmsg)
                    .HasColumnName("STATUSMSG")
                    .HasMaxLength(255);

                entity.Property(e => e.Synctime)
                    .HasColumnName("SYNCTIME")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<AlcAmusers>(entity =>
            {
                entity.HasKey(e => e.UserGid)
                    .HasName("alcAMUsers_I00");

                entity.ToTable("alcAMUsers");

                entity.HasIndex(e => e.UserId)
                    .HasName("alcAMUsers_I01")
                    .IsUnique();

                entity.Property(e => e.UserGid)
                    .HasColumnName("UserGID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AlcGroups>(entity =>
            {
                entity.ToTable("alcGroups");

                entity.HasIndex(e => e.Code)
                    .HasName("alcGroups_I01")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(300);
            });

            modelBuilder.Entity<AlcObjectsInUse>(entity =>
            {
                entity.HasKey(e => new { e.ObjId, e.UserId })
                    .HasName("alcObjectsInUse_I00");

                entity.ToTable("alcObjectsInUse");

                entity.Property(e => e.ObjId).HasMaxLength(250);
            });

            modelBuilder.Entity<AlcObjectsStatus>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("alcObjectsStatus_I00");

                entity.ToTable("alcObjectsStatus");

                entity.Property(e => e.ObjId)
                    .HasMaxLength(100)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<AlcSettingCodes>(entity =>
            {
                entity.ToTable("alcSettingCodes");

                entity.HasIndex(e => e.Code)
                    .HasName("alcSettingCodes_I01")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<AlcUl>(entity =>
            {
                entity.HasKey(e => e.Ulgid)
                    .HasName("alcUL_I00");

                entity.ToTable("alcUL");

                entity.Property(e => e.Ulgid)
                    .HasColumnName("ULGID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ulflag).HasColumnName("ULFlag");

                entity.Property(e => e.Ulla)
                    .HasColumnName("ULLA")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<AlcUserGroups>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.GroupId })
                    .HasName("alcUserGroups_I00");

                entity.ToTable("alcUserGroups");
            });

            modelBuilder.Entity<AlcUserSettings>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.SettingId })
                    .HasName("alcUserSettings_I00");

                entity.ToTable("alcUserSettings");
            });

            modelBuilder.Entity<Assembly>(entity =>
            {
                entity.ToTable("ASSEMBLY");

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

                entity.Property(e => e.PvVars).HasColumnName("PV_VARS");

                entity.Property(e => e.Qtypuformstate).HasColumnName("QTYPUFORMSTATE");

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qtypunitform).HasColumnName("QTYPUNITFORM");

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

                entity.Property(e => e.PvVars).HasColumnName("PV_VARS");

                entity.Property(e => e.Qtypuformstate).HasColumnName("QTYPUFORMSTATE");

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qtypunitform).HasColumnName("QTYPUNITFORM");

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

                entity.Property(e => e.PvVars).HasColumnName("PV_VARS");

                entity.Property(e => e.Qtypuformstate).HasColumnName("QTYPUFORMSTATE");

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qtypunitform).HasColumnName("QTYPUNITFORM");

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

                entity.Property(e => e.PvVars).HasColumnName("PV_VARS");

                entity.Property(e => e.Qtypuformstate).HasColumnName("QTYPUFORMSTATE");

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qtypunitform).HasColumnName("QTYPUNITFORM");

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

                entity.Property(e => e.PvVars).HasColumnName("PV_VARS");

                entity.Property(e => e.Qtypuformstate).HasColumnName("QTYPUFORMSTATE");

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qtypunitform).HasColumnName("QTYPUNITFORM");

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

                entity.Property(e => e.PvVars).HasColumnName("PV_VARS");

                entity.Property(e => e.Qtypuformstate).HasColumnName("QTYPUFORMSTATE");

                entity.Property(e => e.Qtypunit)
                    .HasColumnName("QTYPUNIT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qtypunitform).HasColumnName("QTYPUNITFORM");

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

            modelBuilder.Entity<BcClassification>(entity =>
            {
                entity.ToTable("BC_CLASSIFICATION");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Edition)
                    .HasColumnName("EDITION")
                    .HasMaxLength(256);

                entity.Property(e => e.Location)
                    .HasColumnName("LOCATION")
                    .HasMaxLength(256);

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(256);

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.BcClassification)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FKC233D3A44160E6D4");
            });

            modelBuilder.Entity<BcClassitem>(entity =>
            {
                entity.ToTable("BC_CLASSITEM");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassificationId).HasColumnName("CLASSIFICATION_ID");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(256);

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(256);

                entity.HasOne(d => d.Classification)
                    .WithMany(p => p.BcClassitem)
                    .HasForeignKey(d => d.ClassificationId)
                    .HasConstraintName("FK40761DEDA7E7EE9E");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.BcClassitem)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK40761DED4160E6D4");
            });

            modelBuilder.Entity<BcElemclassitem>(entity =>
            {
                entity.ToTable("BC_ELEMCLASSITEM");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassificationId).HasColumnName("CLASSIFICATION_ID");

                entity.Property(e => e.ElementId).HasColumnName("ELEMENT_ID");

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.HasOne(d => d.Classification)
                    .WithMany(p => p.BcElemclassitem)
                    .HasForeignKey(d => d.ClassificationId)
                    .HasConstraintName("FK50AC9A3E6D9AB94B");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.BcElemclassitem)
                    .HasForeignKey(d => d.ElementId)
                    .HasConstraintName("FK50AC9A3E53B05EAE");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.BcElemclassitem)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK50AC9A3E4160E6D4");
            });

            modelBuilder.Entity<BcElemconnection>(entity =>
            {
                entity.ToTable("BC_ELEMCONNECTION");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Globalid)
                    .HasColumnName("GLOBALID")
                    .HasMaxLength(256);

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(256);

                entity.Property(e => e.RelatedelemId).HasColumnName("RELATEDELEM_ID");

                entity.Property(e => e.Relatedtype).HasColumnName("RELATEDTYPE");

                entity.Property(e => e.RelatingelemId).HasColumnName("RELATINGELEM_ID");

                entity.Property(e => e.Relatingtype).HasColumnName("RELATINGTYPE");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.BcElemconnection)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FKA76BC36B4160E6D4");

                entity.HasOne(d => d.Relatedelem)
                    .WithMany(p => p.BcElemconnectionRelatedelem)
                    .HasForeignKey(d => d.RelatedelemId)
                    .HasConstraintName("FKA76BC36BEA8AB2B0");

                entity.HasOne(d => d.Relatingelem)
                    .WithMany(p => p.BcElemconnectionRelatingelem)
                    .HasForeignKey(d => d.RelatingelemId)
                    .HasConstraintName("FKA76BC36BA2CCAEA5");
            });

            modelBuilder.Entity<BcElemcovering>(entity =>
            {
                entity.ToTable("BC_ELEMCOVERING");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CoverelemId).HasColumnName("COVERELEM_ID");

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.Property(e => e.RelatingelemId).HasColumnName("RELATINGELEM_ID");

                entity.Property(e => e.Type).HasColumnName("TYPE");

                entity.HasOne(d => d.Coverelem)
                    .WithMany(p => p.BcElemcoveringCoverelem)
                    .HasForeignKey(d => d.CoverelemId)
                    .HasConstraintName("FK9B129C98B23BA5A4");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.BcElemcovering)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK9B129C984160E6D4");

                entity.HasOne(d => d.Relatingelem)
                    .WithMany(p => p.BcElemcoveringRelatingelem)
                    .HasForeignKey(d => d.RelatingelemId)
                    .HasConstraintName("FK9B129C98A2CCAEA5");
            });

            modelBuilder.Entity<BcElement>(entity =>
            {
                entity.ToTable("BC_ELEMENT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ContainedbyId).HasColumnName("CONTAINEDBY_ID");

                entity.Property(e => e.Globalid)
                    .HasColumnName("GLOBALID")
                    .HasMaxLength(256);

                entity.Property(e => e.Hasgeom).HasColumnName("HASGEOM");

                entity.Property(e => e.Layer)
                    .HasColumnName("LAYER")
                    .HasMaxLength(256);

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(256);

                entity.Property(e => e.ParentId).HasColumnName("PARENT_ID");

                entity.Property(e => e.Spatial).HasColumnName("SPATIAL");

                entity.Property(e => e.Tagid)
                    .HasColumnName("TAGID")
                    .HasMaxLength(256);

                entity.Property(e => e.Type).HasColumnName("TYPE");

                entity.Property(e => e.Typedesc)
                    .HasColumnName("TYPEDESC")
                    .HasMaxLength(256);

                entity.HasOne(d => d.Containedby)
                    .WithMany(p => p.InverseContainedby)
                    .HasForeignKey(d => d.ContainedbyId)
                    .HasConstraintName("FK1D1688DE4CA532E0");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.BcElement)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK1D1688DE4160E6D4");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK1D1688DEACC2EE40");
            });

            modelBuilder.Entity<BcElementinfo>(entity =>
            {
                entity.ToTable("BC_ELEMENTINFO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ElementId).HasColumnName("ELEMENT_ID");

                entity.Property(e => e.Label)
                    .HasColumnName("LABEL")
                    .HasMaxLength(256);

                entity.Property(e => e.Material)
                    .HasColumnName("MATERIAL")
                    .HasMaxLength(256);

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasMaxLength(256);

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.BcElementinfo)
                    .HasForeignKey(d => d.ElementId)
                    .HasConstraintName("FK2AED468C53B05EAE");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.BcElementinfo)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK2AED468C4160E6D4");
            });

            modelBuilder.Entity<BcElemmaterial>(entity =>
            {
                entity.ToTable("BC_ELEMMATERIAL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EleminfoId).HasColumnName("ELEMINFO_ID");

                entity.Property(e => e.MaterialId).HasColumnName("MATERIAL_ID");

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.Property(e => e.Thickness).HasColumnName("THICKNESS");

                entity.HasOne(d => d.Eleminfo)
                    .WithMany(p => p.BcElemmaterial)
                    .HasForeignKey(d => d.EleminfoId)
                    .HasConstraintName("FKC1DD6CF43F9ED03F");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.BcElemmaterial)
                    .HasForeignKey(d => d.MaterialId)
                    .HasConstraintName("FKC1DD6CF4BAA04896");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.BcElemmaterial)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FKC1DD6CF44160E6D4");
            });

            modelBuilder.Entity<BcElemprop>(entity =>
            {
                entity.ToTable("BC_ELEMPROP");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ElementId).HasColumnName("ELEMENT_ID");

                entity.Property(e => e.Grpname)
                    .HasColumnName("GRPNAME")
                    .HasMaxLength(256);

                entity.Property(e => e.Isnum).HasColumnName("ISNUM");

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(256);

                entity.Property(e => e.Numval)
                    .HasColumnName("NUMVAL")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qtytype).HasColumnName("QTYTYPE");

                entity.Property(e => e.Txtval).HasColumnName("TXTVAL");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.BcElemprop)
                    .HasForeignKey(d => d.ElementId)
                    .HasConstraintName("FK85BFA1B053B05EAE");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.BcElemprop)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK85BFA1B04160E6D4");
            });

            modelBuilder.Entity<BcGeometry>(entity =>
            {
                entity.ToTable("BC_GEOMETRY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ElementId).HasColumnName("ELEMENT_ID");

                entity.Property(e => e.GeomfileId).HasColumnName("GEOMFILE_ID");

                entity.Property(e => e.Globalid)
                    .HasColumnName("GLOBALID")
                    .HasMaxLength(256);

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.Property(e => e.Type).HasColumnName("TYPE");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.BcGeometry)
                    .HasForeignKey(d => d.ElementId)
                    .HasConstraintName("FKF441DAB053B05EAE");

                entity.HasOne(d => d.Geomfile)
                    .WithMany(p => p.BcGeometry)
                    .HasForeignKey(d => d.GeomfileId)
                    .HasConstraintName("FKF441DAB03E18A2E4");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.BcGeometry)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FKF441DAB04160E6D4");
            });

            modelBuilder.Entity<BcGeomfile>(entity =>
            {
                entity.ToTable("BC_GEOMFILE");

                entity.HasIndex(e => e.Fguid)
                    .HasName("UQ__BC_GEOMF__B7D10E46285D09C4")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Elemoffset).HasColumnName("ELEMOFFSET");

                entity.Property(e => e.Fdata).HasColumnName("FDATA");

                entity.Property(e => e.Fguid).HasColumnName("FGUID");

                entity.Property(e => e.Fname)
                    .HasColumnName("FNAME")
                    .HasMaxLength(256);

                entity.Property(e => e.Ftype).HasColumnName("FTYPE");

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.Property(e => e.Noelements).HasColumnName("NOELEMENTS");

                entity.Property(e => e.Novertices).HasColumnName("NOVERTICES");

                entity.Property(e => e.OriginalFormat)
                    .HasColumnName("ORIGINAL_FORMAT")
                    .HasMaxLength(255);

                entity.Property(e => e.SerializationType).HasColumnName("SERIALIZATION_TYPE");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.BcGeomfile)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FKF44224F64160E6D4");
            });

            modelBuilder.Entity<BcGpuserver>(entity =>
            {
                entity.ToTable("BC_GPUSERVER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.AvaMem).HasColumnName("AVA_MEM");

                entity.Property(e => e.Capacity).HasColumnName("CAPACITY");

                entity.Property(e => e.CurMem).HasColumnName("CUR_MEM");

                entity.Property(e => e.CurSessions).HasColumnName("CUR_SESSIONS");

                entity.Property(e => e.Dedicated).HasColumnName("DEDICATED");

                entity.Property(e => e.Hostname)
                    .HasColumnName("HOSTNAME")
                    .HasMaxLength(256);

                entity.Property(e => e.LastUpdate).HasColumnName("LAST_UPDATE");

                entity.Property(e => e.Maxsessions).HasColumnName("MAXSESSIONS");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(256);

                entity.Property(e => e.Onln).HasColumnName("ONLN");

                entity.Property(e => e.Paswd)
                    .HasColumnName("PASWD")
                    .HasMaxLength(256);

                entity.Property(e => e.Port)
                    .HasColumnName("PORT")
                    .HasMaxLength(50);

                entity.Property(e => e.Renderer)
                    .HasColumnName("RENDERER")
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .HasColumnName("USERNAME")
                    .HasMaxLength(256);

                entity.Property(e => e.Vendor)
                    .HasColumnName("VENDOR")
                    .HasMaxLength(512);
            });

            modelBuilder.Entity<BcGroup>(entity =>
            {
                entity.ToTable("BC_GROUP");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(1024);

                entity.Property(e => e.Globalid)
                    .HasColumnName("GLOBALID")
                    .HasMaxLength(256);

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(256);

                entity.Property(e => e.ParentId).HasColumnName("PARENT_ID");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasMaxLength(256);

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.BcGroup)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK467A74E14160E6D4");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK467A74E1B0A6081D");
            });

            modelBuilder.Entity<BcGroupelem>(entity =>
            {
                entity.ToTable("BC_GROUPELEM");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ElemId).HasColumnName("ELEM_ID");

                entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.HasOne(d => d.Elem)
                    .WithMany(p => p.BcGroupelem)
                    .HasForeignKey(d => d.ElemId)
                    .HasConstraintName("FKE8A39FF0CE3F453B");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.BcGroupelem)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FKE8A39FF0536DCE28");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.BcGroupelem)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FKE8A39FF04160E6D4");
            });

            modelBuilder.Entity<BcGroupprop>(entity =>
            {
                entity.ToTable("BC_GROUPPROP");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");

                entity.Property(e => e.Grpname)
                    .HasColumnName("GRPNAME")
                    .HasMaxLength(256);

                entity.Property(e => e.Isnum).HasColumnName("ISNUM");

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(256);

                entity.Property(e => e.Numval)
                    .HasColumnName("NUMVAL")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qtytype).HasColumnName("QTYTYPE");

                entity.Property(e => e.Txtval).HasColumnName("TXTVAL");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.BcGroupprop)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FKE8A8B7C4536DCE28");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.BcGroupprop)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FKE8A8B7C44160E6D4");
            });

            modelBuilder.Entity<BcMaterial>(entity =>
            {
                entity.ToTable("BC_MATERIAL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(256);

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(256);

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.BcMaterial)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK980D37654160E6D4");
            });

            modelBuilder.Entity<BcModel>(entity =>
            {
                entity.ToTable("BC_MODEL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Appname)
                    .HasColumnName("APPNAME")
                    .HasMaxLength(256);

                entity.Property(e => e.Defrev).HasColumnName("DEFREV");

                entity.Property(e => e.Failcause)
                    .HasColumnName("FAILCAUSE")
                    .HasMaxLength(256);

                entity.Property(e => e.Fpath)
                    .HasColumnName("FPATH")
                    .HasMaxLength(256);

                entity.Property(e => e.Globalid)
                    .HasColumnName("GLOBALID")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(256);

                entity.Property(e => e.Offsetx).HasColumnName("OFFSETX");

                entity.Property(e => e.Offsety).HasColumnName("OFFSETY");

                entity.Property(e => e.Offsetz).HasColumnName("OFFSETZ");

                entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");

                entity.Property(e => e.Rev)
                    .HasColumnName("REV")
                    .HasMaxLength(256);

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.VertexFactor).HasColumnName("VERTEX_FACTOR");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.BcModel)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK46CD798B161BBF74");
            });

            modelBuilder.Entity<BcProject>(entity =>
            {
                entity.ToTable("BC_PROJECT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(256);

                entity.Property(e => e.Deleted).HasColumnName("DELETED");

                entity.Property(e => e.Descr).HasColumnName("DESCR");

                entity.Property(e => e.Globalid)
                    .HasColumnName("GLOBALID")
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(256);

                entity.Property(e => e.ParentId).HasColumnName("PARENT_ID");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK6DC3B4FB6EDCC43");
            });

            modelBuilder.Entity<BcQuantity>(entity =>
            {
                entity.ToTable("BC_QUANTITY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ElementId).HasColumnName("ELEMENT_ID");

                entity.Property(e => e.Grpname)
                    .HasColumnName("GRPNAME")
                    .HasMaxLength(256);

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(256);

                entity.Property(e => e.Nameid).HasColumnName("NAMEID");

                entity.Property(e => e.Qtype).HasColumnName("QTYPE");

                entity.Property(e => e.Val)
                    .HasColumnName("VAL")
                    .HasColumnType("numeric(30, 10)");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.BcQuantity)
                    .HasForeignKey(d => d.ElementId)
                    .HasConstraintName("FK39A236C953B05EAE");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.BcQuantity)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK39A236C94160E6D4");
            });

            modelBuilder.Entity<BcScene>(entity =>
            {
                entity.ToTable("BC_SCENE");

                entity.HasIndex(e => e.Sguid)
                    .HasName("UQ__BC_SCENE__D7E146734A69B2CE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Sdata).HasColumnName("SDATA");

                entity.Property(e => e.Sguid).HasColumnName("SGUID");

                entity.Property(e => e.Sname)
                    .HasColumnName("SNAME")
                    .HasMaxLength(256);

                entity.Property(e => e.Stype).HasColumnName("STYPE");
            });

            modelBuilder.Entity<BcSpatialinfo>(entity =>
            {
                entity.ToTable("BC_SPATIALINFO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ElementId).HasColumnName("ELEMENT_ID");

                entity.Property(e => e.MaxX).HasColumnName("MAX_X");

                entity.Property(e => e.MaxY).HasColumnName("MAX_Y");

                entity.Property(e => e.MaxZ).HasColumnName("MAX_Z");

                entity.Property(e => e.MinX).HasColumnName("MIN_X");

                entity.Property(e => e.MinY).HasColumnName("MIN_Y");

                entity.Property(e => e.MinZ).HasColumnName("MIN_Z");

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.BcSpatialinfo)
                    .HasForeignKey(d => d.ElementId)
                    .HasConstraintName("FK63A4809453B05EAE");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.BcSpatialinfo)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK63A480944160E6D4");
            });

            modelBuilder.Entity<Benchmarkboqcolmap>(entity =>
            {
                entity.ToTable("BENCHMARKBOQCOLMAP");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aggregate)
                    .HasColumnName("AGGREGATE")
                    .HasMaxLength(255);

                entity.Property(e => e.Frombench)
                    .HasColumnName("FROMBENCH")
                    .HasMaxLength(255);

                entity.Property(e => e.Templateid).HasColumnName("TEMPLATEID");

                entity.Property(e => e.Toboq)
                    .HasColumnName("TOBOQ")
                    .HasMaxLength(255);

                entity.Property(e => e.Viewname)
                    .HasColumnName("VIEWNAME")
                    .HasMaxLength(255);
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

            modelBuilder.Entity<Cntrlog>(entity =>
            {
                entity.ToTable("CNTRLOG");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Fltr)
                    .HasColumnName("FLTR")
                    .HasMaxLength(255);

                entity.Property(e => e.Logdate).HasColumnName("LOGDATE");

                entity.Property(e => e.Oprtn).HasColumnName("OPRTN");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");

                entity.Property(e => e.Src)
                    .HasColumnName("SRC")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Cntrlogitem>(entity =>
            {
                entity.ToTable("CNTRLOGITEM");

                entity.HasIndex(e => e.Itemid)
                    .HasName("IDX_ITEMID");

                entity.HasIndex(e => e.Logid)
                    .HasName("IDX_LOGID");

                entity.HasIndex(e => e.Prjid)
                    .HasName("IDX_PRJID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fltr)
                    .HasColumnName("FLTR")
                    .HasMaxLength(255);

                entity.Property(e => e.Item).HasColumnName("ITEM");

                entity.Property(e => e.Itemid).HasColumnName("ITEMID");

                entity.Property(e => e.Logid).HasColumnName("LOGID");

                entity.Property(e => e.Oprtn).HasColumnName("OPRTN");

                entity.Property(e => e.Prjid).HasColumnName("PRJID");
            });

            modelBuilder.Entity<Conceptuals>(entity =>
            {
                entity.HasKey(e => e.Conceptualid)
                    .HasName("PK__CONCEPTU__46D7EFE50DD0E1F4");

                entity.ToTable("CONCEPTUALS");

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

                entity.Property(e => e.Consumableid).HasColumnName("CONSUMABLEID");

                entity.Property(e => e.Accrights)
                    .HasColumnName("ACCRIGHTS")
                    .HasMaxLength(255);

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

                entity.Property(e => e.Project)
                    .HasColumnName("PROJECT")
                    .HasMaxLength(255);

                entity.Property(e => e.Qty)
                    .HasColumnName("QTY")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("numeric(30, 10)");

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

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("COUNTRY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ccode)
                    .HasColumnName("CCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Cname)
                    .HasColumnName("CNAME")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("CURRENCY");

                entity.HasIndex(e => new { e.Cname, e.Symbol, e.Isocode, e.Isoflag })
                    .HasName("IDX_CNAME");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cname)
                    .HasColumnName("CNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Isocode)
                    .HasColumnName("ISOCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Isoflag)
                    .HasColumnName("ISOFLAG")
                    .HasMaxLength(255);

                entity.Property(e => e.Symbol)
                    .HasColumnName("SYMBOL")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.ToTable("EQUIPMENT");

                entity.Property(e => e.Equipmentid).HasColumnName("EQUIPMENTID");

                entity.Property(e => e.Accrights)
                    .HasColumnName("ACCRIGHTS")
                    .HasMaxLength(255);

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

            modelBuilder.Entity<Extalias>(entity =>
            {
                entity.HasKey(e => e.Aliasid)
                    .HasName("PK__EXTALIAS__747154194850CC2E");

                entity.ToTable("EXTALIAS");

                entity.Property(e => e.Aliasid).HasColumnName("ALIASID");

                entity.Property(e => e.Datamapping).HasColumnName("DATAMAPPING");

                entity.Property(e => e.Fromalias)
                    .HasColumnName("FROMALIAS")
                    .HasMaxLength(255);

                entity.Property(e => e.Fromaliasclassname)
                    .HasColumnName("FROMALIASCLASSNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Isquerycolumnid).HasColumnName("ISQUERYCOLUMNID");

                entity.Property(e => e.Linenumber).HasColumnName("LINENUMBER");

                entity.Property(e => e.Queryid).HasColumnName("QUERYID");

                entity.Property(e => e.Tofield)
                    .HasColumnName("TOFIELD")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Query)
                    .WithMany(p => p.Extalias)
                    .HasForeignKey(d => d.Queryid)
                    .HasConstraintName("FKC1E428CF25370FFF");
            });

            modelBuilder.Entity<Extdatasource>(entity =>
            {
                entity.HasKey(e => e.Datasourceid)
                    .HasName("PK__EXTDATAS__DFDD78413DB9D6FE");

                entity.ToTable("EXTDATASOURCE");

                entity.Property(e => e.Datasourceid).HasColumnName("DATASOURCEID");

                entity.Property(e => e.Createdate).HasColumnName("CREATEDATE");

                entity.Property(e => e.Createuser)
                    .HasColumnName("CREATEUSER")
                    .HasMaxLength(255);

                entity.Property(e => e.Dstitle)
                    .HasColumnName("DSTITLE")
                    .HasMaxLength(255);

                entity.Property(e => e.Dstype).HasColumnName("DSTYPE");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Jdbcdriver).HasColumnName("JDBCDRIVER");

                entity.Property(e => e.Jdbcpsw)
                    .HasColumnName("JDBCPSW")
                    .HasMaxLength(255);

                entity.Property(e => e.Jdbctype).HasColumnName("JDBCTYPE");

                entity.Property(e => e.Jdbcurl).HasColumnName("JDBCURL");

                entity.Property(e => e.Jdbcuser)
                    .HasColumnName("JDBCUSER")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");
            });

            modelBuilder.Entity<Extquery>(entity =>
            {
                entity.HasKey(e => e.Queryid)
                    .HasName("PK__EXTQUERY__A3AEB32A10357E82");

                entity.ToTable("EXTQUERY");

                entity.Property(e => e.Queryid).HasColumnName("QUERYID");

                entity.Property(e => e.Createdate).HasColumnName("CREATEDATE");

                entity.Property(e => e.Createuser)
                    .HasColumnName("CREATEUSER")
                    .HasMaxLength(255);

                entity.Property(e => e.Datasourceid).HasColumnName("DATASOURCEID");

                entity.Property(e => e.Dsquery).HasColumnName("DSQUERY");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Resourcetype)
                    .HasColumnName("RESOURCETYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Datasource)
                    .WithMany(p => p.Extquery)
                    .HasForeignKey(d => d.Datasourceid)
                    .HasConstraintName("FKC2C9AB47F85F6433");
            });

            modelBuilder.Entity<Extracode1>(entity =>
            {
                entity.HasKey(e => e.Groupcodeid)
                    .HasName("PK__EXTRACOD__7408C9414417DBEE");

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
                    .HasName("PK__EXTRACOD__7408C941917B58F5");

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
                    .HasName("PK__EXTRACOD__7408C9410736B225");

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
                    .HasName("PK__EXTRACOD__7408C941DEFC1A57");

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
                    .HasName("PK__EXTRACOD__7408C941CD8EFFD6");

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
                    .HasName("PK__EXTRACOD__7408C9417724EA02");

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
                    .HasName("PK__EXTRACOD__7408C941EC8BB887");

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

            modelBuilder.Entity<Fieldcustom>(entity =>
            {
                entity.ToTable("FIELDCUSTOM");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Defsel)
                    .HasColumnName("DEFSEL")
                    .HasMaxLength(255);

                entity.Property(e => e.Displayname)
                    .HasColumnName("DISPLAYNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Editable).HasColumnName("EDITABLE");

                entity.Property(e => e.Formula).HasColumnName("FORMULA");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Rsrc)
                    .HasColumnName("RSRC")
                    .HasMaxLength(255);

                entity.Property(e => e.Sellist).HasColumnName("SELLIST");

                entity.Property(e => e.Selvals).HasColumnName("SELVALS");
            });

            modelBuilder.Entity<Filtro>(entity =>
            {
                entity.ToTable("FILTRO");

                entity.Property(e => e.Filtroid).HasColumnName("FILTROID");

                entity.Property(e => e.Filtrodescription)
                    .HasColumnName("FILTRODESCRIPTION")
                    .HasMaxLength(255);

                entity.Property(e => e.Filtroname)
                    .HasColumnName("FILTRONAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Filtrotype)
                    .HasColumnName("FILTROTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");
            });

            modelBuilder.Entity<Filtroproperty>(entity =>
            {
                entity.ToTable("FILTROPROPERTY");

                entity.Property(e => e.Filtropropertyid).HasColumnName("FILTROPROPERTYID");

                entity.Property(e => e.Field)
                    .HasColumnName("FIELD")
                    .HasMaxLength(255);

                entity.Property(e => e.Filtroid).HasColumnName("FILTROID");

                entity.Property(e => e.Filtropropertiescount).HasColumnName("FILTROPROPERTIESCOUNT");

                entity.Property(e => e.Restriction)
                    .HasColumnName("RESTRICTION")
                    .HasMaxLength(255);

                entity.Property(e => e.Used).HasColumnName("USED");

                entity.Property(e => e.Usetype)
                    .HasColumnName("USETYPE")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Filtro)
                    .WithMany(p => p.Filtroproperty)
                    .HasForeignKey(d => d.Filtroid)
                    .HasConstraintName("FKDDE206DDF6543BAE");
            });

            modelBuilder.Entity<Fldfn>(entity =>
            {
                entity.ToTable("FLDFN");

                entity.Property(e => e.Fldfnid).HasColumnName("FLDFNID");

                entity.Property(e => e.Fpath)
                    .HasColumnName("FPATH")
                    .HasMaxLength(255);

                entity.Property(e => e.Ftype)
                    .HasColumnName("FTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Rpdfnfildefcount).HasColumnName("RPDFNFILDEFCOUNT");

                entity.Property(e => e.Rpdfnid).HasColumnName("RPDFNID");

                entity.HasOne(d => d.Rpdfn)
                    .WithMany(p => p.Fldfn)
                    .HasForeignKey(d => d.Rpdfnid)
                    .HasConstraintName("FK3FE018669939745");
            });

            modelBuilder.Entity<Fncton>(entity =>
            {
                entity.HasKey(e => e.Functionid)
                    .HasName("PK__FNCTON__466C3FDF554C24C2");

                entity.ToTable("FNCTON");

                entity.HasIndex(e => e.Name)
                    .HasName("IDX_FNAME");

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

                entity.Property(e => e.Prttype)
                    .HasColumnName("PRTTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Pswd)
                    .HasColumnName("PSWD")
                    .HasMaxLength(255);

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
                    .HasName("PK__FNCTON_A__E10CD26FA8382D0A");

                entity.ToTable("FNCTON_ARGUMENT");

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

            modelBuilder.Entity<Glbprop>(entity =>
            {
                entity.ToTable("GLBPROP");

                entity.HasIndex(e => e.Pkey)
                    .HasName("IDX_PROPKEY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Pkey)
                    .HasColumnName("PKEY")
                    .HasMaxLength(255);

                entity.Property(e => e.Pval).HasColumnName("PVAL");
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

            modelBuilder.Entity<Labor>(entity =>
            {
                entity.ToTable("LABOR");

                entity.Property(e => e.Laborid).HasColumnName("LABORID");

                entity.Property(e => e.Accrights)
                    .HasColumnName("ACCRIGHTS")
                    .HasMaxLength(255);

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(255);

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

                entity.Property(e => e.Project)
                    .HasColumnName("PROJECT")
                    .HasMaxLength(255);

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("numeric(30, 10)");

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

            modelBuilder.Entity<Layoutc>(entity =>
            {
                entity.ToTable("LAYOUTC");

                entity.Property(e => e.Layoutcid).HasColumnName("LAYOUTCID");

                entity.Property(e => e.Creatorid)
                    .HasColumnName("CREATORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Csep).HasColumnName("CSEP");

                entity.Property(e => e.Csepclr)
                    .HasColumnName("CSEPCLR")
                    .HasMaxLength(255);

                entity.Property(e => e.Dflt).HasColumnName("DFLT");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.F1clr)
                    .HasColumnName("F1CLR")
                    .HasMaxLength(255);

                entity.Property(e => e.F1name)
                    .HasColumnName("F1NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.F1size).HasColumnName("F1SIZE");

                entity.Property(e => e.F1style).HasColumnName("F1STYLE");

                entity.Property(e => e.F1undl).HasColumnName("F1UNDL");

                entity.Property(e => e.F2clr)
                    .HasColumnName("F2CLR")
                    .HasMaxLength(255);

                entity.Property(e => e.F2name)
                    .HasColumnName("F2NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.F2size).HasColumnName("F2SIZE");

                entity.Property(e => e.F2style).HasColumnName("F2STYLE");

                entity.Property(e => e.F2undl).HasColumnName("F2UNDL");

                entity.Property(e => e.F3clr)
                    .HasColumnName("F3CLR")
                    .HasMaxLength(255);

                entity.Property(e => e.F3name)
                    .HasColumnName("F3NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.F3size).HasColumnName("F3SIZE");

                entity.Property(e => e.F3style).HasColumnName("F3STYLE");

                entity.Property(e => e.F3undl).HasColumnName("F3UNDL");

                entity.Property(e => e.F4clr)
                    .HasColumnName("F4CLR")
                    .HasMaxLength(255);

                entity.Property(e => e.F4name)
                    .HasColumnName("F4NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.F4size).HasColumnName("F4SIZE");

                entity.Property(e => e.F4style).HasColumnName("F4STYLE");

                entity.Property(e => e.F4undl).HasColumnName("F4UNDL");

                entity.Property(e => e.F5clr)
                    .HasColumnName("F5CLR")
                    .HasMaxLength(255);

                entity.Property(e => e.F5name)
                    .HasColumnName("F5NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.F5size).HasColumnName("F5SIZE");

                entity.Property(e => e.F5style).HasColumnName("F5STYLE");

                entity.Property(e => e.F5undl).HasColumnName("F5UNDL");

                entity.Property(e => e.Flundl).HasColumnName("FLUNDL");

                entity.Property(e => e.Fnclr)
                    .HasColumnName("FNCLR")
                    .HasMaxLength(255);

                entity.Property(e => e.Fnname)
                    .HasColumnName("FNNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Fnsize).HasColumnName("FNSIZE");

                entity.Property(e => e.Fnstyle).HasColumnName("FNSTYLE");

                entity.Property(e => e.Fnundl).HasColumnName("FNUNDL");

                entity.Property(e => e.Fuclr)
                    .HasColumnName("FUCLR")
                    .HasMaxLength(255);

                entity.Property(e => e.Funame)
                    .HasColumnName("FUNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Fusize).HasColumnName("FUSIZE");

                entity.Property(e => e.Fustyle).HasColumnName("FUSTYLE");

                entity.Property(e => e.Fuundl).HasColumnName("FUUNDL");

                entity.Property(e => e.Gridclr)
                    .HasColumnName("GRIDCLR")
                    .HasMaxLength(255);

                entity.Property(e => e.Gridon).HasColumnName("GRIDON");

                entity.Property(e => e.Grpname)
                    .HasColumnName("GRPNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Hgridon).HasColumnName("HGRIDON");

                entity.Property(e => e.L1bclr)
                    .HasColumnName("L1BCLR")
                    .HasMaxLength(255);

                entity.Property(e => e.L2bclr)
                    .HasColumnName("L2BCLR")
                    .HasMaxLength(255);

                entity.Property(e => e.L3bclr)
                    .HasColumnName("L3BCLR")
                    .HasMaxLength(255);

                entity.Property(e => e.L4bclr)
                    .HasColumnName("L4BCLR")
                    .HasMaxLength(255);

                entity.Property(e => e.L5bclr)
                    .HasColumnName("L5BCLR")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Layoutroles)
                    .HasColumnName("LAYOUTROLES")
                    .HasMaxLength(255);

                entity.Property(e => e.Lfbclr)
                    .HasColumnName("LFBCLR")
                    .HasMaxLength(255);

                entity.Property(e => e.Lfclr)
                    .HasColumnName("LFCLR")
                    .HasMaxLength(255);

                entity.Property(e => e.Lfname)
                    .HasColumnName("LFNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Lfsize).HasColumnName("LFSIZE");

                entity.Property(e => e.Lfstyle).HasColumnName("LFSTYLE");

                entity.Property(e => e.Lnbclr)
                    .HasColumnName("LNBCLR")
                    .HasMaxLength(255);

                entity.Property(e => e.Mltln).HasColumnName("MLTLN");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Pblk).HasColumnName("PBLK");

                entity.Property(e => e.Rowhead).HasColumnName("ROWHEAD");

                entity.Property(e => e.Rowstrp).HasColumnName("ROWSTRP");

                entity.Property(e => e.Rs1clr)
                    .HasColumnName("RS1CLR")
                    .HasMaxLength(255);

                entity.Property(e => e.Rs2clr)
                    .HasColumnName("RS2CLR")
                    .HasMaxLength(255);

                entity.Property(e => e.Selectedgk)
                    .HasColumnName("SELECTEDGK")
                    .HasMaxLength(255);

                entity.Property(e => e.Showtree).HasColumnName("SHOWTREE");

                entity.Property(e => e.Spangrp).HasColumnName("SPANGRP");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Unbclr)
                    .HasColumnName("UNBCLR")
                    .HasMaxLength(255);

                entity.Property(e => e.Visibtabs).HasColumnName("VISIBTABS");

                entity.Property(e => e.Zoom).HasColumnName("ZOOM");
            });

            modelBuilder.Entity<Layoutcpanel>(entity =>
            {
                entity.ToTable("LAYOUTCPANEL");

                entity.Property(e => e.Layoutcpanelid).HasColumnName("LAYOUTCPANELID");

                entity.Property(e => e.Assment).HasColumnName("ASSMENT");

                entity.Property(e => e.Autoresize).HasColumnName("AUTORESIZE");

                entity.Property(e => e.Columns)
                    .HasColumnName("COLUMNS")
                    .HasMaxLength(255);

                entity.Property(e => e.Columnwidths)
                    .HasColumnName("COLUMNWIDTHS")
                    .HasMaxLength(255);

                entity.Property(e => e.Dsgrp).HasColumnName("DSGRP");

                entity.Property(e => e.Filtercols).HasColumnName("FILTERCOLS");

                entity.Property(e => e.Filters).HasColumnName("FILTERS");

                entity.Property(e => e.Grpcols).HasColumnName("GRPCOLS");

                entity.Property(e => e.Grpn).HasColumnName("GRPN");

                entity.Property(e => e.Grpords).HasColumnName("GRPORDS");

                entity.Property(e => e.Layoutcid).HasColumnName("LAYOUTCID");

                entity.Property(e => e.Layoutcpanelcount).HasColumnName("LAYOUTCPANELCOUNT");

                entity.Property(e => e.Lockedcols).HasColumnName("LOCKEDCOLS");

                entity.Property(e => e.Prefcols).HasColumnName("PREFCOLS");

                entity.Property(e => e.Rowheight).HasColumnName("ROWHEIGHT");

                entity.Property(e => e.Selvizer)
                    .HasColumnName("SELVIZER")
                    .HasMaxLength(255);

                entity.Property(e => e.Side).HasColumnName("SIDE");

                entity.Property(e => e.Sortedcols).HasColumnName("SORTEDCOLS");

                entity.Property(e => e.Sortindex).HasColumnName("SORTINDEX");

                entity.Property(e => e.Sorttypeup).HasColumnName("SORTTYPEUP");

                entity.Property(e => e.Vizer).HasColumnName("VIZER");

                entity.Property(e => e.Vsble).HasColumnName("VSBLE");

                entity.Property(e => e.Xtralvl).HasColumnName("XTRALVL");

                entity.HasOne(d => d.Layoutc)
                    .WithMany(p => p.Layoutcpanel)
                    .HasForeignKey(d => d.Layoutcid)
                    .HasConstraintName("FK159F2B2B74F88FBC");
            });

            modelBuilder.Entity<Lictbl>(entity =>
            {
                entity.ToTable("LICTBL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Hashkey).HasColumnName("HASHKEY");
            });

            modelBuilder.Entity<Locfactor>(entity =>
            {
                entity.HasKey(e => e.Lfid)
                    .HasName("PK__LOCFACTO__6E7E2C1C182B80EE");

                entity.ToTable("LOCFACTOR");

                entity.Property(e => e.Lfid).HasColumnName("LFID");

                entity.Property(e => e.Assfac)
                    .HasColumnName("ASSFAC")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Codetype)
                    .HasColumnName("CODETYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Confac)
                    .HasColumnName("CONFAC")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Equfac)
                    .HasColumnName("EQUFAC")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Faccount).HasColumnName("FACCOUNT");

                entity.Property(e => e.Fid).HasColumnName("FID");

                entity.Property(e => e.Geopoly).HasColumnName("GEOPOLY");

                entity.Property(e => e.Labfac)
                    .HasColumnName("LABFAC")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Matfac)
                    .HasColumnName("MATFAC")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Onln).HasColumnName("ONLN");

                entity.Property(e => e.Parentecode)
                    .HasColumnName("PARENTECODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Subfac)
                    .HasColumnName("SUBFAC")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Tocity)
                    .HasColumnName("TOCITY")
                    .HasMaxLength(255);

                entity.Property(e => e.Tocountry)
                    .HasColumnName("TOCOUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Tostate)
                    .HasColumnName("TOSTATE")
                    .HasMaxLength(255);

                entity.Property(e => e.Tozipcode)
                    .HasColumnName("TOZIPCODE")
                    .HasMaxLength(255);

                entity.HasOne(d => d.F)
                    .WithMany(p => p.Locfactor)
                    .HasForeignKey(d => d.Fid)
                    .HasConstraintName("FK66363C6F9B8D46AA");
            });

            modelBuilder.Entity<Locprof>(entity =>
            {
                entity.HasKey(e => e.Functionid)
                    .HasName("PK__LOCPROF__466C3FDFDEBF1D3B");

                entity.ToTable("LOCPROF");

                entity.Property(e => e.Functionid).HasColumnName("FUNCTIONID");

                entity.Property(e => e.Createdate).HasColumnName("CREATEDATE");

                entity.Property(e => e.Createuserid)
                    .HasColumnName("CREATEUSERID")
                    .HasMaxLength(255);

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Fromcountry)
                    .HasColumnName("FROMCOUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Fromstate)
                    .HasColumnName("FROMSTATE")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Supstate).HasColumnName("SUPSTATE");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("MATERIAL");

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

            modelBuilder.Entity<Paraminput>(entity =>
            {
                entity.ToTable("PARAMINPUT");

                entity.Property(e => e.Paraminputid).HasColumnName("PARAMINPUTID");

                entity.Property(e => e.Arsizevar)
                    .HasColumnName("ARSIZEVAR")
                    .HasMaxLength(255);

                entity.Property(e => e.Artype)
                    .HasColumnName("ARTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Calcvaldigits).HasColumnName("CALCVALDIGITS");

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

                entity.HasIndex(e => e.Groupidentity)
                    .HasName("IDX_GROUPIDENTITY");

                entity.HasIndex(e => e.Title)
                    .HasName("IDX_TITLE");

                entity.Property(e => e.Paramitemid).HasColumnName("PARAMITEMID");

                entity.Property(e => e.Accrights)
                    .HasColumnName("ACCRIGHTS")
                    .HasMaxLength(255);

                entity.Property(e => e.Cmodel).HasColumnName("CMODEL");

                entity.Property(e => e.Createdate).HasColumnName("CREATEDATE");

                entity.Property(e => e.Createuserid)
                    .HasColumnName("CREATEUSERID")
                    .HasMaxLength(255);

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

                entity.Property(e => e.Prttype)
                    .HasColumnName("PRTTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Pswd)
                    .HasColumnName("PSWD")
                    .HasMaxLength(255);

                entity.Property(e => e.Qty)
                    .HasColumnName("QTY")
                    .HasColumnType("numeric(30, 10)");

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

                entity.Property(e => e.Wbs)
                    .HasColumnName("WBS")
                    .HasMaxLength(255);

                entity.Property(e => e.Wbs2)
                    .HasColumnName("WBS2")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Paramoutput>(entity =>
            {
                entity.ToTable("PARAMOUTPUT");

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

                entity.Property(e => e.Qtyeq).HasColumnName("QTYEQ");

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

                entity.Property(e => e.Paramreturnid).HasColumnName("PARAMRETURNID");

                entity.Property(e => e.Paramitemid).HasColumnName("PARAMITEMID");

                entity.Property(e => e.Reteq).HasColumnName("RETEQ");

                entity.HasOne(d => d.Paramitem)
                    .WithMany(p => p.Paramreturn)
                    .HasForeignKey(d => d.Paramitemid)
                    .HasConstraintName("FKE5568BDDB8FEF034");
            });

            modelBuilder.Entity<Principals>(entity =>
            {
                entity.HasKey(e => e.Principalid)
                    .HasName("PK__PRINCIPA__2CBDF6F4A53A7AD1");

                entity.ToTable("PRINCIPALS");

                entity.Property(e => e.Principalid)
                    .HasColumnName("PRINCIPALID")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Authtype)
                    .HasColumnName("AUTHTYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasColumnName("COLOR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Enbl).HasColumnName("ENBL");

                entity.Property(e => e.Hashkey)
                    .HasColumnName("HASHKEY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Prjdbms>(entity =>
            {
                entity.ToTable("PRJDBMS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Dbname)
                    .HasColumnName("DBNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Hdbms).HasColumnName("HDBMS");

                entity.Property(e => e.Hinst)
                    .HasColumnName("HINST")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Hname)
                    .HasColumnName("HNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Hpass)
                    .HasColumnName("HPASS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Hport)
                    .HasColumnName("HPORT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Huser)
                    .HasColumnName("HUSER")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Prjprop>(entity =>
            {
                entity.ToTable("PRJPROP");

                entity.HasIndex(e => e.Pkey)
                    .HasName("IDX_PROPKEY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Pkey)
                    .HasColumnName("PKEY")
                    .HasMaxLength(255);

                entity.Property(e => e.Projecturlid).HasColumnName("PROJECTURLID");

                entity.Property(e => e.Pval).HasColumnName("PVAL");

                entity.HasOne(d => d.Projecturl)
                    .WithMany(p => p.Prjprop)
                    .HasForeignKey(d => d.Projecturlid)
                    .HasConstraintName("FK18184DEB7C786EFE");
            });

            modelBuilder.Entity<Projectaccess>(entity =>
            {
                entity.HasKey(e => e.Paid)
                    .HasName("PK__PROJECTA__5986FD6D03270BEF");

                entity.ToTable("PROJECTACCESS");

                entity.Property(e => e.Paid).HasColumnName("PAID");

                entity.Property(e => e.Acccon).HasColumnName("ACCCON");

                entity.Property(e => e.Aladd).HasColumnName("ALADD");

                entity.Property(e => e.Alrem).HasColumnName("ALREM");

                entity.Property(e => e.Alupd).HasColumnName("ALUPD");

                entity.Property(e => e.Puid).HasColumnName("PUID");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Pu)
                    .WithMany(p => p.Projectaccess)
                    .HasForeignKey(d => d.Puid)
                    .HasConstraintName("FK844DA19D4D514A55");
            });

            modelBuilder.Entity<Projecteps>(entity =>
            {
                entity.ToTable("PROJECTEPS");

                entity.HasIndex(e => e.Code)
                    .HasName("IDX_CODE");

                entity.Property(e => e.Projectepsid).HasColumnName("PROJECTEPSID");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Parentid).HasColumnName("PARENTID");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Projectinfo>(entity =>
            {
                entity.ToTable("PROJECTINFO");

                entity.Property(e => e.Projectinfoid).HasColumnName("PROJECTINFOID");

                entity.Property(e => e.Basement)
                    .HasColumnName("BASEMENT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Bimtakeoff).HasColumnName("BIMTAKEOFF");

                entity.Property(e => e.Client)
                    .HasColumnName("CLIENT")
                    .HasMaxLength(255);

                entity.Property(e => e.Clientbudget)
                    .HasColumnName("CLIENTBUDGET")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Codestyle)
                    .HasColumnName("CODESTYLE")
                    .HasMaxLength(255);

                entity.Property(e => e.Concost)
                    .HasColumnName("CONCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Contractor)
                    .HasColumnName("CONTRACTOR")
                    .HasMaxLength(255);

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.Createdate).HasColumnName("CREATEDATE");

                entity.Property(e => e.Creatorid)
                    .HasColumnName("CREATORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasMaxLength(255);

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

                entity.Property(e => e.Cusepsdate1).HasColumnName("CUSEPSDATE1");

                entity.Property(e => e.Cusepsdate10).HasColumnName("CUSEPSDATE10");

                entity.Property(e => e.Cusepsdate2).HasColumnName("CUSEPSDATE2");

                entity.Property(e => e.Cusepsdate3).HasColumnName("CUSEPSDATE3");

                entity.Property(e => e.Cusepsdate4).HasColumnName("CUSEPSDATE4");

                entity.Property(e => e.Cusepsdate5).HasColumnName("CUSEPSDATE5");

                entity.Property(e => e.Cusepsdate6).HasColumnName("CUSEPSDATE6");

                entity.Property(e => e.Cusepsdate7).HasColumnName("CUSEPSDATE7");

                entity.Property(e => e.Cusepsdate8).HasColumnName("CUSEPSDATE8");

                entity.Property(e => e.Cusepsdate9).HasColumnName("CUSEPSDATE9");

                entity.Property(e => e.Cusepsrate1)
                    .HasColumnName("CUSEPSRATE1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusepsrate10)
                    .HasColumnName("CUSEPSRATE10")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusepsrate2)
                    .HasColumnName("CUSEPSRATE2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusepsrate3)
                    .HasColumnName("CUSEPSRATE3")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusepsrate4)
                    .HasColumnName("CUSEPSRATE4")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusepsrate5)
                    .HasColumnName("CUSEPSRATE5")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusepsrate6)
                    .HasColumnName("CUSEPSRATE6")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusepsrate7)
                    .HasColumnName("CUSEPSRATE7")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusepsrate8)
                    .HasColumnName("CUSEPSRATE8")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusepsrate9)
                    .HasColumnName("CUSEPSRATE9")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Cusepstext1)
                    .HasColumnName("CUSEPSTEXT1")
                    .HasMaxLength(255);

                entity.Property(e => e.Cusepstext10)
                    .HasColumnName("CUSEPSTEXT10")
                    .HasMaxLength(255);

                entity.Property(e => e.Cusepstext11)
                    .HasColumnName("CUSEPSTEXT11")
                    .HasMaxLength(255);

                entity.Property(e => e.Cusepstext12)
                    .HasColumnName("CUSEPSTEXT12")
                    .HasMaxLength(255);

                entity.Property(e => e.Cusepstext13)
                    .HasColumnName("CUSEPSTEXT13")
                    .HasMaxLength(255);

                entity.Property(e => e.Cusepstext14)
                    .HasColumnName("CUSEPSTEXT14")
                    .HasMaxLength(255);

                entity.Property(e => e.Cusepstext15)
                    .HasColumnName("CUSEPSTEXT15")
                    .HasMaxLength(255);

                entity.Property(e => e.Cusepstext16)
                    .HasColumnName("CUSEPSTEXT16")
                    .HasMaxLength(255);

                entity.Property(e => e.Cusepstext17)
                    .HasColumnName("CUSEPSTEXT17")
                    .HasMaxLength(255);

                entity.Property(e => e.Cusepstext18)
                    .HasColumnName("CUSEPSTEXT18")
                    .HasMaxLength(255);

                entity.Property(e => e.Cusepstext19)
                    .HasColumnName("CUSEPSTEXT19")
                    .HasMaxLength(255);

                entity.Property(e => e.Cusepstext2)
                    .HasColumnName("CUSEPSTEXT2")
                    .HasMaxLength(255);

                entity.Property(e => e.Cusepstext20)
                    .HasColumnName("CUSEPSTEXT20")
                    .HasMaxLength(255);

                entity.Property(e => e.Cusepstext3)
                    .HasColumnName("CUSEPSTEXT3")
                    .HasMaxLength(255);

                entity.Property(e => e.Cusepstext4)
                    .HasColumnName("CUSEPSTEXT4")
                    .HasMaxLength(255);

                entity.Property(e => e.Cusepstext5)
                    .HasColumnName("CUSEPSTEXT5")
                    .HasMaxLength(255);

                entity.Property(e => e.Cusepstext6)
                    .HasColumnName("CUSEPSTEXT6")
                    .HasMaxLength(255);

                entity.Property(e => e.Cusepstext7)
                    .HasColumnName("CUSEPSTEXT7")
                    .HasMaxLength(255);

                entity.Property(e => e.Cusepstext8)
                    .HasColumnName("CUSEPSTEXT8")
                    .HasMaxLength(255);

                entity.Property(e => e.Cusepstext9)
                    .HasColumnName("CUSEPSTEXT9")
                    .HasMaxLength(255);

                entity.Property(e => e.Defrev)
                    .HasColumnName("DEFREV")
                    .HasMaxLength(255);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Duration).HasColumnName("DURATION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Epscode)
                    .HasColumnName("EPSCODE")
                    .HasMaxLength(255);

                entity.Property(e => e.Equcost)
                    .HasColumnName("EQUCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Equhours)
                    .HasColumnName("EQUHOURS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Floors).HasColumnName("FLOORS");

                entity.Property(e => e.Geoloc)
                    .HasColumnName("GEOLOC")
                    .HasMaxLength(255);

                entity.Property(e => e.Labcost)
                    .HasColumnName("LABCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Location)
                    .HasColumnName("LOCATION")
                    .HasMaxLength(255);

                entity.Property(e => e.Locfac).HasColumnName("LOCFAC");

                entity.Property(e => e.Locprof)
                    .HasColumnName("LOCPROF")
                    .HasMaxLength(255);

                entity.Property(e => e.Mainsite)
                    .HasColumnName("MAINSITE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Manhours)
                    .HasColumnName("MANHOURS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Matcost)
                    .HasColumnName("MATCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Offeredprice)
                    .HasColumnName("OFFEREDPRICE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Ostakeoff).HasColumnName("OSTAKEOFF");

                entity.Property(e => e.Primavera).HasColumnName("PRIMAVERA");

                entity.Property(e => e.Prjsubcat)
                    .HasColumnName("PRJSUBCAT")
                    .HasMaxLength(255);

                entity.Property(e => e.Prjtype)
                    .HasColumnName("PRJTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Projectepsid).HasColumnName("PROJECTEPSID");

                entity.Property(e => e.Selfac)
                    .HasColumnName("SELFAC")
                    .HasMaxLength(255);

                entity.Property(e => e.State)
                    .HasColumnName("STATE")
                    .HasMaxLength(255);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(255);

                entity.Property(e => e.Storagetype)
                    .HasColumnName("STORAGETYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Subcost)
                    .HasColumnName("SUBCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Subdate).HasColumnName("SUBDATE");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255);

                entity.Property(e => e.Totalcost)
                    .HasColumnName("TOTALCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Unit)
                    .HasColumnName("UNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Unitcost)
                    .HasColumnName("UNITCOST")
                    .HasColumnType("numeric(30, 10)");

                entity.HasOne(d => d.Projecteps)
                    .WithMany(p => p.Projectinfo)
                    .HasForeignKey(d => d.Projectepsid)
                    .HasConstraintName("FK48580F27CC46545E");
            });

            modelBuilder.Entity<Projectspecvar>(entity =>
            {
                entity.ToTable("PROJECTSPECVAR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cellx).HasColumnName("CELLX");

                entity.Property(e => e.Celly).HasColumnName("CELLY");

                entity.Property(e => e.Datatype)
                    .HasColumnName("DATATYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Defval).HasColumnName("DEFVAL");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Isnumber).HasColumnName("ISNUMBER");

                entity.Property(e => e.Mandatory).HasColumnName("MANDATORY");

                entity.Property(e => e.Mapped).HasColumnName("MAPPED");

                entity.Property(e => e.Name).HasColumnName("NAME");

                entity.Property(e => e.Pushfield)
                    .HasColumnName("PUSHFIELD")
                    .HasMaxLength(255);

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

            modelBuilder.Entity<Projecturl>(entity =>
            {
                entity.ToTable("PROJECTURL");

                entity.Property(e => e.Projecturlid).HasColumnName("PROJECTURLID");

                entity.Property(e => e.Approved).HasColumnName("APPROVED");

                entity.Property(e => e.Benchmarkid).HasColumnName("BENCHMARKID");

                entity.Property(e => e.Completed).HasColumnName("COMPLETED");

                entity.Property(e => e.Createdate).HasColumnName("CREATEDATE");

                entity.Property(e => e.Creuserid)
                    .HasColumnName("CREUSERID")
                    .HasMaxLength(255);

                entity.Property(e => e.Dbhost)
                    .HasColumnName("DBHOST")
                    .HasMaxLength(255);

                entity.Property(e => e.Dbname)
                    .HasColumnName("DBNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Dbport)
                    .HasColumnName("DBPORT")
                    .HasMaxLength(255);

                entity.Property(e => e.Dbprefix)
                    .HasColumnName("DBPREFIX")
                    .HasMaxLength(255);

                entity.Property(e => e.Dbpswd)
                    .HasColumnName("DBPSWD")
                    .HasMaxLength(255);

                entity.Property(e => e.Dbsingle).HasColumnName("DBSINGLE");

                entity.Property(e => e.Dbsrv).HasColumnName("DBSRV");

                entity.Property(e => e.Dbsrvname)
                    .HasColumnName("DBSRVNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Dbusr)
                    .HasColumnName("DBUSR")
                    .HasMaxLength(255);

                entity.Property(e => e.Defrev).HasColumnName("DEFREV");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Esttotal)
                    .HasColumnName("ESTTOTAL")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Frozen).HasColumnName("FROZEN");

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Markuptotal)
                    .HasColumnName("MARKUPTOTAL")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Mustrecalc).HasColumnName("MUSTRECALC");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Pending).HasColumnName("PENDING");

                entity.Property(e => e.Projectdbmsid).HasColumnName("PROJECTDBMSID");

                entity.Property(e => e.Projectinfoid).HasColumnName("PROJECTINFOID");

                entity.Property(e => e.Qrecv).HasColumnName("QRECV");

                entity.Property(e => e.Qsent).HasColumnName("QSENT");

                entity.Property(e => e.Quotedtotal)
                    .HasColumnName("QUOTEDTOTAL")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rvson)
                    .HasColumnName("RVSON")
                    .HasMaxLength(255);

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Underreview).HasColumnName("UNDERREVIEW");

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Projectdbms)
                    .WithMany(p => p.Projecturl)
                    .HasForeignKey(d => d.Projectdbmsid)
                    .HasConstraintName("FKA77EE3B6728B054");

                entity.HasOne(d => d.Projectinfo)
                    .WithMany(p => p.Projecturl)
                    .HasForeignKey(d => d.Projectinfoid)
                    .HasConstraintName("FKA77EE3B65B1C0C14");
            });

            modelBuilder.Entity<Projectuser>(entity =>
            {
                entity.HasKey(e => e.Puid)
                    .HasName("PK__PROJECTU__B280976DAE01320A");

                entity.ToTable("PROJECTUSER");

                entity.HasIndex(e => e.Userid)
                    .HasName("IDX_USERID");

                entity.Property(e => e.Puid).HasColumnName("PUID");

                entity.Property(e => e.Aditms).HasColumnName("ADITMS");

                entity.Property(e => e.Admn).HasColumnName("ADMN");

                entity.Property(e => e.Aquote).HasColumnName("AQUOTE");

                entity.Property(e => e.Editms).HasColumnName("EDITMS");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255);

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
                    .HasMaxLength(255);

                entity.Property(e => e.Userid)
                    .HasColumnName("USERID")
                    .HasMaxLength(255);

                entity.Property(e => e.Vaitms).HasColumnName("VAITMS");

                entity.Property(e => e.Varsadmin).HasColumnName("VARSADMIN");

                entity.Property(e => e.Varsusr).HasColumnName("VARSUSR");

                entity.Property(e => e.Varsviewer).HasColumnName("VARSVIEWER");

                entity.Property(e => e.Wbs).HasColumnName("WBS");

                entity.Property(e => e.Xchange).HasColumnName("XCHANGE");

                entity.HasOne(d => d.Projectinfo)
                    .WithMany(p => p.Projectuser)
                    .HasForeignKey(d => d.Projectinfoid)
                    .HasConstraintName("FK485D96445B1C0C14");
            });

            modelBuilder.Entity<Projectusertemplate>(entity =>
            {
                entity.HasKey(e => e.Templateid)
                    .HasName("PK__PROJECTU__9EE4AD53E6CDC359");

                entity.ToTable("PROJECTUSERTEMPLATE");

                entity.Property(e => e.Templateid).HasColumnName("TEMPLATEID");

                entity.Property(e => e.Aditms).HasColumnName("ADITMS");

                entity.Property(e => e.Admn).HasColumnName("ADMN");

                entity.Property(e => e.Aquote).HasColumnName("AQUOTE");

                entity.Property(e => e.Createdate).HasColumnName("CREATEDATE");

                entity.Property(e => e.Createuser)
                    .HasColumnName("CREATEUSER")
                    .HasMaxLength(255);

                entity.Property(e => e.Editms).HasColumnName("EDITMS");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Esclte).HasColumnName("ESCLTE");

                entity.Property(e => e.Estim).HasColumnName("ESTIM");

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Props).HasColumnName("PROPS");

                entity.Property(e => e.Rmitms).HasColumnName("RMITMS");

                entity.Property(e => e.Rquote).HasColumnName("RQUOTE");

                entity.Property(e => e.Rsrc).HasColumnName("RSRC");

                entity.Property(e => e.Squote).HasColumnName("SQUOTE");

                entity.Property(e => e.Takeoff).HasColumnName("TAKEOFF");

                entity.Property(e => e.Vaitms).HasColumnName("VAITMS");

                entity.Property(e => e.Varsadmin).HasColumnName("VARSADMIN");

                entity.Property(e => e.Varsusr).HasColumnName("VARSUSR");

                entity.Property(e => e.Varsviewer).HasColumnName("VARSVIEWER");

                entity.Property(e => e.Wbs).HasColumnName("WBS");

                entity.Property(e => e.Xchange).HasColumnName("XCHANGE");
            });

            modelBuilder.Entity<Queryresource>(entity =>
            {
                entity.HasKey(e => e.Qresid)
                    .HasName("PK__QUERYRES__E123B4389F14BE83");

                entity.ToTable("QUERYRESOURCE");

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
                    .HasName("PK__QUERYROW__4AE9FF7B82DF9D55");

                entity.ToTable("QUERYROW");

                entity.Property(e => e.Qrowid).HasColumnName("QROWID");

                entity.Property(e => e.Cndn).HasColumnName("CNDN");

                entity.Property(e => e.Ctype)
                    .HasColumnName("CTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Fname)
                    .HasColumnName("FNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Qresid).HasColumnName("QRESID");

                entity.Property(e => e.Qrowscount).HasColumnName("QROWSCOUNT");

                entity.Property(e => e.Rname)
                    .HasColumnName("RNAME")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Qres)
                    .WithMany(p => p.Queryrow)
                    .HasForeignKey(d => d.Qresid)
                    .HasConstraintName("FKE91C7C12AB986C17");
            });

            modelBuilder.Entity<Quotetemplate>(entity =>
            {
                entity.ToTable("QUOTETEMPLATE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Createdate).HasColumnName("CREATEDATE");

                entity.Property(e => e.Dflt).HasColumnName("DFLT");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Ismaterial).HasColumnName("ISMATERIAL");

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Layoutid).HasColumnName("LAYOUTID");

                entity.Property(e => e.Title).HasColumnName("TITLE");

                entity.Property(e => e.Xcellfile).HasColumnName("XCELLFILE");
            });

            modelBuilder.Entity<Ratebuildup>(entity =>
            {
                entity.ToTable("RATEBUILDUP");

                entity.HasIndex(e => e.Resid)
                    .HasName("IDX_RESID");

                entity.HasIndex(e => e.Resprjid)
                    .HasName("IDX_RESPRJID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Calcformula).HasColumnName("CALCFORMULA");

                entity.Property(e => e.Dbcreatedate).HasColumnName("DBCREATEDATE");

                entity.Property(e => e.Frate)
                    .HasColumnName("FRATE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Onln).HasColumnName("ONLN");

                entity.Property(e => e.Overrate1).HasColumnName("OVERRATE1");

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

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.Roleid)
                    .HasName("PK__ROLES__006568E9B1655874");

                entity.ToTable("ROLES");

                entity.Property(e => e.Roleid)
                    .HasColumnName("ROLEID")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Principalid)
                    .HasColumnName("PRINCIPALID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasColumnName("ROLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rolegroup)
                    .HasColumnName("ROLEGROUP")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rpdfn>(entity =>
            {
                entity.ToTable("RPDFN");

                entity.Property(e => e.Rpdfnid).HasColumnName("RPDFNID");

                entity.Property(e => e.Mltusrrpt).HasColumnName("MLTUSRRPT");

                entity.Property(e => e.Rcredate).HasColumnName("RCREDATE");

                entity.Property(e => e.Rcreuser)
                    .HasColumnName("RCREUSER")
                    .HasMaxLength(255);

                entity.Property(e => e.Rdesc).HasColumnName("RDESC");

                entity.Property(e => e.Rdsgn)
                    .HasColumnName("RDSGN")
                    .HasMaxLength(255);

                entity.Property(e => e.Redtid)
                    .HasColumnName("REDTID")
                    .HasMaxLength(255);

                entity.Property(e => e.Reportroles)
                    .HasColumnName("REPORTROLES")
                    .HasMaxLength(255);

                entity.Property(e => e.Reporttype)
                    .HasColumnName("REPORTTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Rgrp)
                    .HasColumnName("RGRP")
                    .HasMaxLength(255);

                entity.Property(e => e.Ricn)
                    .HasColumnName("RICN")
                    .HasMaxLength(255);

                entity.Property(e => e.Rjsurl)
                    .HasColumnName("RJSURL")
                    .HasMaxLength(255);

                entity.Property(e => e.Rlastupd).HasColumnName("RLASTUPD");

                entity.Property(e => e.Rname)
                    .HasColumnName("RNAME")
                    .HasMaxLength(255);

                entity.Property(e => e.Rpblk).HasColumnName("RPBLK");

                entity.Property(e => e.Rusrrep).HasColumnName("RUSRREP");
            });

            modelBuilder.Entity<Subcontractor>(entity =>
            {
                entity.ToTable("SUBCONTRACTOR");

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

                entity.Property(e => e.Project)
                    .HasColumnName("PROJECT")
                    .HasMaxLength(255);

                entity.Property(e => e.Qty)
                    .HasColumnName("QTY")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("numeric(30, 10)");

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

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("SUPPLIER");

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

            modelBuilder.Entity<Takeoffarea>(entity =>
            {
                entity.ToTable("TAKEOFFAREA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aid).HasColumnName("AID");

                entity.Property(e => e.Areacount).HasColumnName("AREACOUNT");

                entity.Property(e => e.Blankfill).HasColumnName("BLANKFILL");

                entity.Property(e => e.Conline).HasColumnName("CONLINE");

                entity.Property(e => e.Tension)
                    .HasColumnName("TENSION")
                    .HasColumnType("numeric(30, 10)");

                entity.HasOne(d => d.A)
                    .WithMany(p => p.Takeoffarea)
                    .HasForeignKey(d => d.Aid)
                    .HasConstraintName("FK1FE6B7F53EBE986C");
            });

            modelBuilder.Entity<Takeoffcon>(entity =>
            {
                entity.ToTable("TAKEOFFCON");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cndtype)
                    .HasColumnName("CNDTYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Colour)
                    .HasColumnName("COLOUR")
                    .HasMaxLength(255);

                entity.Property(e => e.Createdate).HasColumnName("CREATEDATE");

                entity.Property(e => e.Createuserid)
                    .HasColumnName("CREATEUSERID")
                    .HasMaxLength(255);

                entity.Property(e => e.Depth)
                    .HasColumnName("DEPTH")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Elevation).HasColumnName("ELEVATION");

                entity.Property(e => e.Grouping)
                    .HasColumnName("GROUPING")
                    .HasMaxLength(255);

                entity.Property(e => e.Height)
                    .HasColumnName("HEIGHT")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Patterntype).HasColumnName("PATTERNTYPE");

                entity.Property(e => e.Projectinfoid).HasColumnName("PROJECTINFOID");

                entity.Property(e => e.Qty1)
                    .HasColumnName("QTY1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qty1type)
                    .HasColumnName("QTY1TYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Qty2)
                    .HasColumnName("QTY2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qty2type)
                    .HasColumnName("QTY2TYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Qty3)
                    .HasColumnName("QTY3")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Qty3type)
                    .HasColumnName("QTY3TYPE")
                    .HasMaxLength(255);

                entity.Property(e => e.Samples).HasColumnName("SAMPLES");

                entity.Property(e => e.Shapetype).HasColumnName("SHAPETYPE");

                entity.Property(e => e.Takeoff)
                    .HasColumnName("TAKEOFF")
                    .HasMaxLength(255);

                entity.Property(e => e.Thickness)
                    .HasColumnName("THICKNESS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255);

                entity.Property(e => e.Uom1)
                    .HasColumnName("UOM1")
                    .HasMaxLength(255);

                entity.Property(e => e.Uom2)
                    .HasColumnName("UOM2")
                    .HasMaxLength(255);

                entity.Property(e => e.Uom3)
                    .HasColumnName("UOM3")
                    .HasMaxLength(255);

                entity.Property(e => e.Width)
                    .HasColumnName("WIDTH")
                    .HasColumnType("numeric(30, 10)");

                entity.HasOne(d => d.Projectinfo)
                    .WithMany(p => p.Takeoffcon)
                    .HasForeignKey(d => d.Projectinfoid)
                    .HasConstraintName("FK94988FA5B1C0C14");
            });

            modelBuilder.Entity<Takeofflegend>(entity =>
            {
                entity.ToTable("TAKEOFFLEGEND");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.Property(e => e.Fnt)
                    .HasColumnName("FNT")
                    .HasMaxLength(255);

                entity.Property(e => e.Fntcolor)
                    .HasColumnName("FNTCOLOR")
                    .HasMaxLength(255);

                entity.Property(e => e.Legtxt).HasColumnName("LEGTXT");

                entity.Property(e => e.Lgdcount).HasColumnName("LGDCOUNT");

                entity.Property(e => e.Rotangle)
                    .HasColumnName("ROTANGLE")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Xpos)
                    .HasColumnName("XPOS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Ypos)
                    .HasColumnName("YPOS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Zoom).HasColumnName("ZOOM");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Takeofflegend)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FKD327AD753EBE9FEE");
            });

            modelBuilder.Entity<Takeoffline>(entity =>
            {
                entity.ToTable("TAKEOFFLINE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ex)
                    .HasColumnName("EX")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Ey)
                    .HasColumnName("EY")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Lid).HasColumnName("LID");

                entity.Property(e => e.Linescount).HasColumnName("LINESCOUNT");

                entity.Property(e => e.Sx)
                    .HasColumnName("SX")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Sy)
                    .HasColumnName("SY")
                    .HasColumnType("numeric(30, 10)");

                entity.HasOne(d => d.L)
                    .WithMany(p => p.Takeoffline)
                    .HasForeignKey(d => d.Lid)
                    .HasConstraintName("FK1FEB975C3EBEC1B7");
            });

            modelBuilder.Entity<Takeoffpoint>(entity =>
            {
                entity.ToTable("TAKEOFFPOINT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.Property(e => e.Elevcount).HasColumnName("ELEVCOUNT");

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.Pointcount).HasColumnName("POINTCOUNT");

                entity.Property(e => e.Polycount).HasColumnName("POLYCOUNT");

                entity.Property(e => e.Sid).HasColumnName("SID");

                entity.Property(e => e.Xpos)
                    .HasColumnName("XPOS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Ypos)
                    .HasColumnName("YPOS")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Zpos)
                    .HasColumnName("ZPOS")
                    .HasColumnType("numeric(30, 10)");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Takeoffpoint)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FKDDC25B083EBE9FEE");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.Takeoffpoint)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("FKDDC25B08412B92EF");

                entity.HasOne(d => d.S)
                    .WithMany(p => p.Takeoffpoint)
                    .HasForeignKey(d => d.Sid)
                    .HasConstraintName("FKDDC25B08DC1D472B");
            });

            modelBuilder.Entity<Takeofftriangle>(entity =>
            {
                entity.ToTable("TAKEOFFTRIANGLE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Tid).HasColumnName("TID");

                entity.Property(e => e.Triacount).HasColumnName("TRIACOUNT");

                entity.Property(e => e.Xpos1)
                    .HasColumnName("XPOS1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Xpos2)
                    .HasColumnName("XPOS2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Xpos3)
                    .HasColumnName("XPOS3")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Ypos1)
                    .HasColumnName("YPOS1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Ypos2)
                    .HasColumnName("YPOS2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Ypos3)
                    .HasColumnName("YPOS3")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Zpos1)
                    .HasColumnName("ZPOS1")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Zpos2)
                    .HasColumnName("ZPOS2")
                    .HasColumnType("numeric(30, 10)");

                entity.Property(e => e.Zpos3)
                    .HasColumnName("ZPOS3")
                    .HasColumnType("numeric(30, 10)");

                entity.HasOne(d => d.T)
                    .WithMany(p => p.Takeofftriangle)
                    .HasForeignKey(d => d.Tid)
                    .HasConstraintName("FK99DDF570412BA1F3");
            });

            modelBuilder.Entity<Teamalias>(entity =>
            {
                entity.ToTable("TEAMALIAS");

                entity.HasIndex(e => e.Alias)
                    .HasName("IDX_ALIAS");

                entity.HasIndex(e => e.Team)
                    .HasName("IDX_TEAM");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Alias)
                    .HasColumnName("ALIAS")
                    .HasMaxLength(255);

                entity.Property(e => e.Team)
                    .HasColumnName("TEAM")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Unitalias>(entity =>
            {
                entity.ToTable("UNITALIAS");

                entity.HasIndex(e => e.Frunit)
                    .HasName("IDX_FROMUNIT");

                entity.HasIndex(e => e.Tounit)
                    .HasName("IDX_TOUNIT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Frunit)
                    .HasColumnName("FRUNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.Tounit)
                    .HasColumnName("TOUNIT")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Userprop>(entity =>
            {
                entity.ToTable("USERPROP");

                entity.HasIndex(e => e.Pkey)
                    .HasName("IDX_USERPROPKEY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Pkey)
                    .HasColumnName("PKEY")
                    .HasMaxLength(255);

                entity.Property(e => e.Pval).HasColumnName("PVAL");

                entity.Property(e => e.Userid)
                    .HasColumnName("USERID")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Usersessions>(entity =>
            {
                entity.ToTable("USERSESSIONS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LastupdateDate).HasColumnName("LASTUPDATE_DATE");

                entity.Property(e => e.LoggedinDate).HasColumnName("LOGGEDIN_DATE");

                entity.Property(e => e.Serialkey)
                    .HasColumnName("SERIALKEY")
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .HasColumnName("USERNAME")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Wscolident>(entity =>
            {
                entity.ToTable("WSCOLIDENT");

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

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Celldtingn).HasColumnName("CELLDTINGN");

                entity.Property(e => e.Commentdetect).HasColumnName("COMMENTDETECT");

                entity.Property(e => e.Groupcol).HasColumnName("GROUPCOL");

                entity.Property(e => e.Tableprefer).HasColumnName("TABLEPREFER");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(255);

                entity.Property(e => e.Treedetect).HasColumnName("TREEDETECT");

                entity.Property(e => e.Treemapping).HasColumnName("TREEMAPPING");
            });

            modelBuilder.Entity<Wsfile>(entity =>
            {
                entity.ToTable("WSFILE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Actsheets).HasColumnName("ACTSHEETS");

                entity.Property(e => e.Filerevid).HasColumnName("FILEREVID");

                entity.Property(e => e.Fpath)
                    .HasColumnName("FPATH")
                    .HasMaxLength(255);

                entity.Property(e => e.Numsheets).HasColumnName("NUMSHEETS");

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

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Createdate).HasColumnName("CREATEDATE");

                entity.Property(e => e.Createuserid)
                    .HasColumnName("CREATEUSERID")
                    .HasMaxLength(255);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Editorid)
                    .HasColumnName("EDITORID")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastupdate).HasColumnName("LASTUPDATE");

                entity.Property(e => e.Mappingid).HasColumnName("MAPPINGID");

                entity.Property(e => e.Pblk).HasColumnName("PBLK");

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
                    .HasName("PK__XCELLFIL__C594AC251DB7A0F6");

                entity.ToTable("XCELLFILE");

                entity.Property(e => e.Xcellid).HasColumnName("XCELLID");

                entity.Property(e => e.Cellx).HasColumnName("CELLX");

                entity.Property(e => e.Celly).HasColumnName("CELLY");

                entity.Property(e => e.Sheet).HasColumnName("SHEET");

                entity.Property(e => e.Xcellfile1).HasColumnName("XCELLFILE");
            });
        }
    }
}
