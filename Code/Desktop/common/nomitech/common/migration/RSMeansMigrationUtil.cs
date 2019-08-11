using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Numerics;

namespace Desktop.common.nomitech.common.migration
{
	using GroupCode = nomitech.common.@base.GroupCode;
	using ResourceToAssignmentTable = nomitech.common.@base.ResourceToAssignmentTable;
	using AssemblyEquipmentTable = nomitech.common.db.local.AssemblyEquipmentTable;
	using AssemblyLaborTable = nomitech.common.db.local.AssemblyLaborTable;
	using AssemblyMaterialTable = nomitech.common.db.local.AssemblyMaterialTable;
	using AssemblyTable = nomitech.common.db.local.AssemblyTable;
	using EquipmentTable = nomitech.common.db.local.EquipmentTable;
	using ExtraCode1Table = nomitech.common.db.local.ExtraCode1Table;
	using LaborTable = nomitech.common.db.local.LaborTable;
	using MaterialTable = nomitech.common.db.local.MaterialTable;
	using SubcontractorTable = nomitech.common.db.local.SubcontractorTable;
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using BlankResourceInitializer = nomitech.common.expr.boqitem.BlankResourceInitializer;
	using MasterFormatLoader = Desktop.common.nomitech.common.migration.rsmeans.MasterFormatLoader;
	using RSMeansCrewItem = Desktop.common.nomitech.common.migration.rsmeans.RSMeansCrewItem;
	using RSMeansEquipmentCrewItem = Desktop.common.nomitech.common.migration.rsmeans.RSMeansEquipmentCrewItem;
	using RSMeansLaborItem = Desktop.common.nomitech.common.migration.rsmeans.RSMeansLaborItem;
	using RSMeansUOMConverter = Desktop.common.nomitech.common.migration.rsmeans.RSMeansUOMConverter;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	using StringUtils = nomitech.common.util.StringUtils;
	using Session = org.hibernate.Session;
	using Transaction = org.hibernate.Transaction;

	public class RSMeansMigrationUtil
	{
	  private const double HOURS_OF_DAY = 8.0D;

	  private const double HOURS_OF_WEEK = 40.0D;

	  private const double HOURS_OF_MONTH = 160.0D;

	  private IDictionary<string, string> FILES_TOS_MIGRATE = new SortedDictionary();

	  private bool USE_O_AND_P = true;

	  private bool USE_O_AND_P_LABORS = true;

	  private int CLEAR_SESSION_INTERVAL = 500;

	  private int PROGRESS_SHOW_INTERVAL = 2000;

	  private bool USE_COST_BOOK_DUPLICATES = false;

	  private IDictionary<string, string> DISTINCT_VALUES_MAP = new Hashtable(50000);

	  private IDictionary<string, GroupCode> masterFormat04Map = null;

	  private IDictionary<string, string> referencePDF = null;

	  private IDictionary<string, string> graphicsPDF = null;

	  private string unitCostDataFolder = null;

	  private string referenceFolder = null;

	  private string laborCrewFolder = null;

	  private DateTime lastUpdate = DateTime.Now;

	  private IDictionary<string, IList<RSMeansCrewItem>> crewMetCache = null;

	  private IDictionary<string, string> crewDescriptionCache = null;

	  private IDictionary<string, RSMeansLaborItem> laborOpenCache = null;

	  private IDictionary<string, RSMeansLaborItem> laborResiCache = null;

	  private IDictionary<string, RSMeansLaborItem> laborRRCache = null;

	  private IDictionary<string, RSMeansLaborItem> laborStandardCache = null;

	  private IDictionary<string, RSMeansEquipmentCrewItem> equCrewCache = null;

	  private void init()
	  {
		this.FILES_TOS_MIGRATE["BCCD"] = "BCCD";
		this.FILES_TOS_MIGRATE["CIVL"] = "Civil";
		this.FILES_TOS_MIGRATE["COMM"] = "Commercial";
		this.FILES_TOS_MIGRATE["CONC"] = "Concrete";
		this.FILES_TOS_MIGRATE["ELEC"] = "Electrical";
		this.FILES_TOS_MIGRATE["FACL"] = "Facility";
		this.FILES_TOS_MIGRATE["GRN"] = "Green Building";
		this.FILES_TOS_MIGRATE["HVY"] = "Heavy";
		this.FILES_TOS_MIGRATE["INTR"] = "Interior";
		this.FILES_TOS_MIGRATE["LITE"] = "Light Commercial";
		this.FILES_TOS_MIGRATE["MSTR"] = "Master";
		this.FILES_TOS_MIGRATE["MECH"] = "Mechanical";
		this.FILES_TOS_MIGRATE["OPEN"] = "Open Shop";
		this.FILES_TOS_MIGRATE["PLUM"] = "Plumbing";
		this.FILES_TOS_MIGRATE["R&R"] = "Repair-Remodeling";
		this.FILES_TOS_MIGRATE["RESI"] = "Residential";
		this.FILES_TOS_MIGRATE["SITE"] = "Site Work";
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private RSMeansMigrationUtil(String paramString) throws Exception
	  private RSMeansMigrationUtil(string paramString)
	  {
		this.unitCostDataFolder = paramString + File.separator + "Unit Cost Data 2009";
		this.laborCrewFolder = paramString + File.separator + "Labor-Eq-Crew";
		this.referenceFolder = paramString + File.separator + "Ref-Graphics";
		init();
		loadMasterFormat();
		this.referencePDF = cacheReferencePDF();
		this.graphicsPDF = cacheGraphicsPDF();
		if (RSMeansUOMConverter.CONVERT_TO_METRIC)
		{
		  this.crewMetCache = cacheCrew("MET2009");
		}
		else
		{
		  this.crewMetCache = cacheCrew("STD2009");
		}
		Session session = DatabaseDBUtil.currentSession();
		Transaction transaction = session.beginTransaction();
		try
		{
		  Console.WriteLine("SAVING EQUIPMENT COST DATA: ");
		  loadEquipments(session);
		  this.laborOpenCache = cacheAndLoadLabors(session, "OPEN2009", ", Open Shop or Light Commercial Rate");
		  this.laborResiCache = cacheAndLoadLabors(session, "RESI2009", ", Residential Rate");
		  this.laborRRCache = cacheAndLoadLabors(session, "RR2009", ", Repair & Remodeling or Facility Rate");
		  this.laborStandardCache = cacheAndLoadLabors(session, "STD2009", "");
		  if (RSMeansUOMConverter.CONVERT_TO_METRIC)
		  {
			this.equCrewCache = cacheAndLoadEquipment(session, "EQM2009");
		  }
		  else
		  {
			this.equCrewCache = cacheAndLoadEquipment(session, "EQ2009");
		  }
		  transaction.commit();
		}
		catch (Exception exception)
		{
		  transaction.rollback();
		  DatabaseDBUtil.closeSession();
		  throw exception;
		}
		DatabaseDBUtil.closeSession();
		loadUnitCostData();
	  }

	  private string getGraphicString(string paramString)
	  {
		string str = (string)this.graphicsPDF[paramString];
		return (string.ReferenceEquals(str, null)) ? "" : ("\nGRAPHIC: http://www.costdatabase.eu/rsmeans/uc/graphics/" + str + ".PDF");
	  }

	  private string getReferenceString(string paramString)
	  {
		string str = (string)this.referencePDF[paramString];
		return (string.ReferenceEquals(str, null)) ? "" : ("\nPDF: http://www.costdatabase.eu/rsmeans/uc/pdf/" + str + ".pdf");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private java.util.Map<String, String> cacheReferencePDF() throws Exception
	  private IDictionary<string, string> cacheReferencePDF()
	  {
		Hashtable hashMap = new Hashtable();
		File file = new File(this.referenceFolder + File.separator + "Unit Cost" + File.separator + "Unit Cost References09.txt");
		Console.WriteLine("PROCESSING REFERENCE FILE: " + file.AbsolutePath);
		StreamReader bufferedReader = new StreamReader(file);
		while (true)
		{
		  string str1 = bufferedReader.ReadLine();
		  if (string.ReferenceEquals(str1, null))
		  {
			break;
		  }
		  string str2 = StringUtils.removeSpacesFromEnd(str1.Substring(0, 8));
		  string str3 = StringUtils.removeSpacesFromEnd(str1.Substring(17, 9));
		  hashMap[str2] = str3.ToUpper();
		}
		bufferedReader.Close();
		return hashMap;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private java.util.Map<String, String> cacheGraphicsPDF() throws Exception
	  private IDictionary<string, string> cacheGraphicsPDF()
	  {
		Hashtable hashMap = new Hashtable();
		File file = new File(this.referenceFolder + File.separator + "Unit Cost" + File.separator + "Unit Cost Graphics09.txt");
		Console.WriteLine("PROCESSING GRAPHICS FILE: " + file.AbsolutePath);
		StreamReader bufferedReader = new StreamReader(file);
		while (true)
		{
		  string str1 = bufferedReader.ReadLine();
		  if (string.ReferenceEquals(str1, null))
		  {
			break;
		  }
		  string str2 = StringUtils.removeSpacesFromEnd(str1.Substring(0, 12));
		  string str3 = StringUtils.removeSpacesFromEnd(str1.Substring(25, 8));
		  hashMap[str2] = str3.ToUpper();
		}
		bufferedReader.Close();
		return hashMap;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private java.util.Map<String, java.util.List<Desktop.common.nomitech.common.migration.rsmeans.RSMeansCrewItem>> cacheCrew(String paramString) throws Exception
	  private IDictionary<string, IList<RSMeansCrewItem>> cacheCrew(string paramString)
	  {
		Hashtable hashMap = new Hashtable();
		this.crewDescriptionCache = new Hashtable();
		File file = new File(this.laborCrewFolder + File.separator + paramString + ".CRW");
		Console.WriteLine("PROCESSING CRW: " + file.AbsolutePath);
		StreamReader bufferedReader = new StreamReader(file);
		while (true)
		{
		  string str1 = bufferedReader.ReadLine();
		  if (string.ReferenceEquals(str1, null))
		  {
			break;
		  }
		  string str2 = StringUtils.removeSpacesFromEnd(str1.Substring(0, 5));
		  double d = (Convert.ToDouble(StringUtils.removeSpacesFromEnd(str1.Substring(5, 12))));
		  string str3 = StringUtils.removeSpacesFromEnd(str1.Substring(17, 12));
		  string str4 = StringUtils.removeSpacesFromEnd(str1.Substring(30, 36));
		  System.Collections.IList list = (System.Collections.IList)hashMap[str2];
		  if (list == null)
		  {
			list = new List<object>();
		  }
		  this.crewDescriptionCache[str3] = str4;
		  list.Add(new RSMeansCrewItem(str2, d, str4, str3));
		  hashMap[str2] = list;
		}
		bufferedReader.Close();
		return hashMap;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private java.util.Map<String, Desktop.common.nomitech.common.migration.rsmeans.RSMeansLaborItem> cacheAndLoadLabors(org.hibernate.Session paramSession, String paramString1, String paramString2) throws Exception
	  private IDictionary<string, RSMeansLaborItem> cacheAndLoadLabors(Session paramSession, string paramString1, string paramString2)
	  {
		Hashtable hashMap = new Hashtable();
		File file = new File(this.laborCrewFolder + File.separator + paramString1 + ".LAB");
		Console.WriteLine("PROCESSING LAB: " + file.AbsolutePath);
		StreamReader bufferedReader = new StreamReader(file);
		while (true)
		{
		  string str1 = bufferedReader.ReadLine();
		  if (string.ReferenceEquals(str1, null))
		  {
			break;
		  }
		  string str2 = StringUtils.removeSpacesFromEnd(str1.Substring(0, 5));
		  string str3 = StringUtils.removeSpacesFromEnd(str1.Substring(5, 40));
		  double d1 = (Convert.ToDouble(StringUtils.removeSpacesFromEnd(str1.Substring(45, 10))));
		  double d2 = (Convert.ToDouble(StringUtils.removeSpacesFromEnd(str1.Substring(55, 10))));
		  string str4 = (string)this.crewDescriptionCache[str2];
		  string str5 = (string)this.crewDescriptionCache[str2 + "A"];
		  string str6 = (string)this.crewDescriptionCache[str2 + "O"];
		  string str7 = (string)this.crewDescriptionCache[str2 + "I"];
		  LaborTable laborTable1 = BlankResourceInitializer.createBlankLabor(null);
		  laborTable1.Title = str3;
		  laborTable1.StateProvince = "";
		  laborTable1.Unit = "HOUR";
		  laborTable1.Rate = new BigDecimalFixed(d1);
		  if (this.USE_O_AND_P_LABORS)
		  {
			laborTable1.IKA = new BigDecimalFixed(d2 - d1);
		  }
		  else
		  {
			laborTable1.IKA = BigDecimalMath.ONE;
		  }
		  laborTable1.Currency = "USD";
		  laborTable1.GroupCode = "";
		  laborTable1.GekCode = "";
		  laborTable1.Project = "";
		  laborTable1.EditorId = "rsmeans";
		  laborTable1.ContactPerson = "";
		  laborTable1.PhoneNumber = "";
		  laborTable1.MobileNumber = "";
		  laborTable1.FaxNumber = "";
		  laborTable1.Email = "";
		  laborTable1.Address = "";
		  laborTable1.City = "";
		  laborTable1.Country = "US";
		  laborTable1.Notes = "CODE: " + str2;
		  laborTable1.Description = str3 + paramString2 + ", CODE: " + str2 + ", TYPE: " + paramString1;
		  laborTable1.LastUpdate = this.lastUpdate;
		  laborTable1.CreateDate = this.lastUpdate;
		  laborTable1.CreateUserId = "rsmeans";
		  LaborTable laborTable2 = (LaborTable)laborTable1.clone();
		  if (!string.ReferenceEquals(str4, null) && (!string.ReferenceEquals(str5, null) || !string.ReferenceEquals(str6, null) || !string.ReferenceEquals(str7, null)))
		  {
			laborTable1.Title = str4 + ", " + laborTable1.Title;
			laborTable1.Description = str4 + ", " + laborTable1.Description;
		  }
		  long? long = (long?)paramSession.save(laborTable1);
		  laborTable1.LaborId = long;
		  hashMap[str2] = new RSMeansLaborItem(str2, str3, d1, d2, (LaborTable)laborTable1.clone());
		  if (!string.ReferenceEquals(str5, null))
		  {
			LaborTable laborTable = (LaborTable)laborTable2.clone();
			laborTable.Title = str5 + ", " + laborTable.Title;
			laborTable.Description = str5 + ", " + laborTable.Description;
			laborTable.Rate = laborTable.Rate * (new BigDecimalFixed("0.8"));
			laborTable.IKA = laborTable.IKA * (new BigDecimalFixed("0.8"));
			laborTable.Notes = "CODE: " + str2 + "A";
			long = (long?)paramSession.save(laborTable);
			laborTable.LaborId = long;
			hashMap[str2 + "A"] = new RSMeansLaborItem(str2, str3, d1 * 0.8D, d2 * 0.8D, (LaborTable)laborTable.clone());
		  }
		  if (!string.ReferenceEquals(str6, null))
		  {
			LaborTable laborTable = (LaborTable)laborTable2.clone();
			laborTable.Title = str6 + ", " + laborTable.Title;
			laborTable.Description = str6 + ", " + laborTable.Description;
			laborTable.Rate = laborTable.Rate;
			laborTable.IKA = laborTable.IKA + (new BigDecimalFixed("2"));
			laborTable.Notes = "CODE: " + str2 + "O";
			long = (long?)paramSession.save(laborTable);
			laborTable.LaborId = long;
			hashMap[str2 + "O"] = new RSMeansLaborItem(str2, str3, d1 + 2.0D, d2 + 2.0D, (LaborTable)laborTable.clone());
		  }
		  if (!string.ReferenceEquals(str7, null))
		  {
			LaborTable laborTable = (LaborTable)laborTable2.clone();
			laborTable.Title = str7 + ", " + laborTable.Title;
			laborTable.Description = str7 + ", " + laborTable.Description;
			laborTable.Rate = laborTable.Rate;
			laborTable.IKA = laborTable.IKA + (new BigDecimalFixed("0.5"));
			long = (long?)paramSession.save(laborTable);
			laborTable.Notes = "CODE: " + str2 + "I";
			laborTable.LaborId = long;
			hashMap[str2 + "I"] = new RSMeansLaborItem(str2, str3, d1 + 0.5D, d2 + 0.5D, (LaborTable)laborTable.clone());
		  }
		}
		bufferedReader.Close();
		return hashMap;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private java.util.Map<String, Desktop.common.nomitech.common.migration.rsmeans.RSMeansEquipmentCrewItem> cacheAndLoadEquipment(org.hibernate.Session paramSession, String paramString) throws Exception
	  private IDictionary<string, RSMeansEquipmentCrewItem> cacheAndLoadEquipment(Session paramSession, string paramString)
	  {
		Hashtable hashMap = new Hashtable();
		File file = new File(this.laborCrewFolder + File.separator + paramString + ".CRW");
		Console.WriteLine("PROCESSING EQU-CRW: " + file.AbsolutePath);
		StreamReader bufferedReader = new StreamReader(file);
		while (true)
		{
		  string str1 = bufferedReader.ReadLine();
		  if (string.ReferenceEquals(str1, null))
		  {
			break;
		  }
		  string str2 = StringUtils.removeSpacesFromEnd(str1.Substring(12, 12));
		  string str3 = StringUtils.removeSpacesFromEnd(str1.Substring(24, 35));
		  double d = (Convert.ToDouble(StringUtils.removeSpacesFromEnd(str1.Substring(59, 11))));
		  GroupCode groupCode = (GroupCode)this.masterFormat04Map[str2.Substring(0, 8)];
		  if (groupCode == null)
		  {
			Console.WriteLine("I could not fing a code for: '" + str2.Substring(0, 8) + "'");
		  }
		  EquipmentTable equipmentTable = saveOrUpdateEquipmentTable(paramSession, groupCode, str2, str3, "", ", this is the equipment crew rate used by assemblies for a rental rate search by MF04", d, "DAY");
		  hashMap[str2] = new RSMeansEquipmentCrewItem(str2, str3, d, (EquipmentTable)equipmentTable.clone());
		}
		bufferedReader.Close();
		return hashMap;
	  }

	  private void loadMasterFormat()
	  {
		Console.WriteLine("\n\n\nLOADING: MF04.CSI");
		this.masterFormat04Map = MasterFormatLoader.loadCSI(this.unitCostDataFolder, null, "MF04.CSI");
	  }

	  private IDictionary<string, RSMeansLaborItem> getLaborCacheForFile(string paramString)
	  {
		  return (paramString.StartsWith("LITE", StringComparison.Ordinal) || paramString.StartsWith("OPEN", StringComparison.Ordinal)) ? this.laborOpenCache : (paramString.StartsWith("RESI", StringComparison.Ordinal) ? this.laborResiCache : ((paramString.StartsWith("FACL", StringComparison.Ordinal) || paramString.StartsWith("R&R", StringComparison.Ordinal)) ? this.laborRRCache : this.laborStandardCache));
	  }

	  private string getStringSuffixForFile(string paramString)
	  {
		  return (paramString.StartsWith("LITE", StringComparison.Ordinal) || paramString.StartsWith("OPEN", StringComparison.Ordinal)) ? "1" : (paramString.StartsWith("RESI", StringComparison.Ordinal) ? "2" : ((paramString.StartsWith("FACL", StringComparison.Ordinal) || paramString.StartsWith("R&R", StringComparison.Ordinal)) ? "3" : "4"));
	  }

	  private string getCostBookForFile(string paramString)
	  {
		  return !this.USE_COST_BOOK_DUPLICATES ? ((paramString.StartsWith("LITE", StringComparison.Ordinal) || paramString.StartsWith("OPEN", StringComparison.Ordinal)) ? "Lite Commercial, Open Shop" : (paramString.StartsWith("RESI", StringComparison.Ordinal) ? "Residential" : ((paramString.StartsWith("FACL", StringComparison.Ordinal) || paramString.StartsWith("R&R", StringComparison.Ordinal)) ? "Facilities, Repair & Remodeling" : "General Construction"))) : paramString;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private nomitech.common.base.GroupCode checkAndGetCSI(String paramString1, String paramString2, org.hibernate.Session paramSession) throws Exception
	  private GroupCode checkAndGetCSI(string paramString1, string paramString2, Session paramSession)
	  {
		if (paramString1.Length > 8)
		{
		  paramString1 = paramString1.Substring(0, 8);
		}
		ExtraCode1Table extraCode1Table = (GroupCode)this.masterFormat04Map[paramString1];
		if (extraCode1Table == null)
		{
		  extraCode1Table = new ExtraCode1Table();
		  if (paramString1.Equals("01543305"))
		  {
			paramString1 = "01543300";
		  }
		  ((ExtraCode1Table)extraCode1Table).GroupCode = paramString1;
		  ((ExtraCode1Table)extraCode1Table).Title = paramString2;
		  ((ExtraCode1Table)extraCode1Table).Notes = "";
		  ((ExtraCode1Table)extraCode1Table).Unit = "";
		  ((ExtraCode1Table)extraCode1Table).UnitFactor = BigDecimalMath.ONE;
		  ((ExtraCode1Table)extraCode1Table).EditorId = "csi";
		  ((ExtraCode1Table)extraCode1Table).Description = "";
		  ((ExtraCode1Table)extraCode1Table).LastUpdate = this.lastUpdate;
		  paramSession.save(extraCode1Table);
		  Console.WriteLine("ADDED MF AFTER: " + extraCode1Table.ToString());
		  this.masterFormat04Map[paramString1] = extraCode1Table;
		}
		return extraCode1Table;
	  }

	  private void loadUnitCostData()
	  {
		Transaction transaction = null;
		try
		{
		  foreach (string str1 in this.FILES_TOS_MIGRATE.Keys)
		  {
			string str2 = (string)this.FILES_TOS_MIGRATE[str1];
			long l = DateTimeHelper.CurrentUnixTimeMillis();
			Console.WriteLine("\nSleeping for 30 secs and continuing to " + str2);
			System.GC.Collect();
			Thread.Sleep(30000L);
			transaction = DatabaseDBUtil.currentSession().beginTransaction();
			transaction = saveUnitCostData(DatabaseDBUtil.currentSession(), str2, str1);
			transaction.commit();
			DatabaseDBUtil.closeSession();
			Console.WriteLine("FINISHED AT: " + ((DateTimeHelper.CurrentUnixTimeMillis() - l) / 60000L) + " minutes");
		  }
		  Console.WriteLine("FINISHED SUCCESSFULLY");
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  if (transaction != null && transaction.Active)
		  {
			transaction.rollback();
			DatabaseDBUtil.closeSession();
		  }
		  throw exception;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private org.hibernate.Transaction saveUnitCostData(org.hibernate.Session paramSession, String paramString1, String paramString2) throws Exception
	  private Transaction saveUnitCostData(Session paramSession, string paramString1, string paramString2)
	  {
		File file = new File(this.unitCostDataFolder + File.separator + paramString1 + File.separator + paramString2 + "2009.SEQ");
		System.Collections.IDictionary map = getLaborCacheForFile(paramString2);
		int i = 0;
		Console.WriteLine("PROCESSING: " + file.AbsolutePath);
		StreamReader bufferedReader = new StreamReader(file);
		while (true)
		{
		  string str1 = bufferedReader.ReadLine();
		  if (string.ReferenceEquals(str1, null))
		  {
			break;
		  }
		  string str2 = StringUtils.removeAllSpaces(str1.Substring(12, 10));
		  double d1 = (Convert.ToDouble(StringUtils.removeAllSpaces(str1.Substring(348, 12))));
		  string str3 = StringUtils.removeSpacesFromEnd(str1.Substring(299, 5));
		  if (!this.USE_COST_BOOK_DUPLICATES)
		  {
			string str8 = null;
			string str9 = getStringSuffixForFile(paramString2);
			if (d1 != 0.0D)
			{
			  str8 = (string)this.DISTINCT_VALUES_MAP[str2 + str9];
			}
			else
			{
			  str8 = (string)this.DISTINCT_VALUES_MAP[str2];
			}
			if (string.ReferenceEquals(str8, null))
			{
			  if (d1 != 0.0D)
			  {
				this.DISTINCT_VALUES_MAP[str2 + str9] = "";
			  }
			  else
			  {
				this.DISTINCT_VALUES_MAP[str2] = "";
			  }
			}
			else
			{
			  continue;
			}
		  }
		  string str4 = StringUtils.removeAllSpaces(str1.Substring(22, 12));
		  string str5 = StringUtils.removeSpacesFromEnd(str1.Substring(34, 255));
		  double d2 = (Convert.ToDouble(StringUtils.removeAllSpaces(str1.Substring(289, 10))));
		  double d3 = (Convert.ToDouble(StringUtils.removeAllSpaces(str1.Substring(304, 12))));
		  double d4 = (Convert.ToDouble(StringUtils.removeAllSpaces(str1.Substring(316, 12))));
		  string str6 = StringUtils.removeSpacesFromEnd(str1.Substring(328, 8));
		  double d5 = (Convert.ToDouble(StringUtils.removeAllSpaces(str1.Substring(336, 12))));
		  double d6 = (Convert.ToDouble(StringUtils.removeAllSpaces(str1.Substring(360, 12))));
		  double d7 = (Convert.ToDouble(StringUtils.removeAllSpaces(str1.Substring(372, 12))));
		  double d8 = (Convert.ToDouble(StringUtils.removeAllSpaces(str1.Substring(384, 12))));
		  GroupCode groupCode = (GroupCode)this.masterFormat04Map[str4.Substring(0, 8)];
		  string str7 = getCostBookForFile(paramString2);
		  MaterialTable materialTable = null;
		  if (d5 != 0.0D)
		  {
			materialTable = saveOrUpdateMaterialTable(paramSession, groupCode, str4, str5, d5, str6, str2, str7);
		  }
		  if (d4 != 0.0D || !str3.Equals(""))
		  {
			saveOrUpdateAssemblyTable(paramSession, groupCode, str4, str5, d4, d3, str3, d2, str6, str2, materialTable, map, str7, d8);
		  }
		  if (d5 == 0.0D && d1 == 0.0D && d6 == 0.0D)
		  {
			saveOrUpdateSubcontractorTable(paramSession, groupCode, str4, str5, d7, d8 - d7, str6, str2, str7);
		  }
		  if (this.PROGRESS_SHOW_INTERVAL != -1 && i % this.PROGRESS_SHOW_INTERVAL == 0)
		  {
			Console.WriteLine(paramString2 + " PROCESSED: " + i);
		  }
		  if (i++ % this.CLEAR_SESSION_INTERVAL == 0)
		  {
			paramSession.Transaction.commit();
			DatabaseDBUtil.closeSession();
			paramSession = DatabaseDBUtil.currentSession();
			paramSession.beginTransaction();
		  }
		}
		bufferedReader.Close();
		return paramSession.Transaction;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadEquipments(org.hibernate.Session paramSession) throws Exception
	  private void loadEquipments(Session paramSession)
	  {
		File file = new File(this.laborCrewFolder + File.separator + "EQM2009.SEQ");
		if (!RSMeansUOMConverter.CONVERT_TO_METRIC)
		{
		  file = new File(this.laborCrewFolder + File.separator + "EQ2009.SEQ");
		}
		StreamReader bufferedReader = new StreamReader(file);
		while (true)
		{
		  string str1 = bufferedReader.ReadLine();
		  if (string.ReferenceEquals(str1, null))
		  {
			break;
		  }
		  string str2 = StringUtils.removeSpacesFromEnd(str1.Substring(0, 12));
		  string str3 = StringUtils.removeSpacesFromEnd(str1.Substring(24, 80));
		  string str4 = StringUtils.removeSpacesFromEnd(str1.Substring(104, 8));
		  double d1 = (Convert.ToDouble(StringUtils.removeSpacesFromEnd(str1.Substring(112, 12))));
		  double d2 = (Convert.ToDouble(StringUtils.removeSpacesFromEnd(str1.Substring(124, 12))));
		  double d3 = (Convert.ToDouble(StringUtils.removeSpacesFromEnd(str1.Substring(136, 12))));
		  double d4 = (Convert.ToDouble(StringUtils.removeSpacesFromEnd(str1.Substring(148, 12))));
		  double d5 = (Convert.ToDouble(StringUtils.removeSpacesFromEnd(str1.Substring(160, 12))));
		  GroupCode groupCode = checkAndGetCSI(str2, str3, paramSession);
		  if (str4.Equals(""))
		  {
			continue;
		  }
		  saveOrUpdateEquipmentTable(paramSession, groupCode, str2, str3, ", daily", ", including " + d1 + " hourly operating cost, CREW EQUIP COST:" + d5, d2 + d1 * 8.0D, "DAY");
		  saveOrUpdateEquipmentTable(paramSession, groupCode, str2, str3, ", weekly", ", including " + d1 + " hourly operating cost, CREW EQUIP COST:" + d5, d3 + d1 * 8.0D * 5.0D, "WEEK");
		  saveOrUpdateEquipmentTable(paramSession, groupCode, str2, str3, ", monthly", ", including " + d1 + " hourly operating cost, CREW EQUIP COST:" + d5, d4 + d1 * 8.0D * 5.0D * 4.0D, "MONTH");
		}
		bufferedReader.Close();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void saveOrUpdateAssemblyTable(org.hibernate.Session paramSession, nomitech.common.base.GroupCode paramGroupCode, String paramString1, String paramString2, double paramDouble1, double paramDouble2, String paramString3, double paramDouble3, String paramString4, String paramString5, nomitech.common.db.local.MaterialTable paramMaterialTable, java.util.Map<String, Desktop.common.nomitech.common.migration.rsmeans.RSMeansLaborItem> paramMap, String paramString6, double paramDouble4) throws Exception
	  private void saveOrUpdateAssemblyTable(Session paramSession, GroupCode paramGroupCode, string paramString1, string paramString2, double paramDouble1, double paramDouble2, string paramString3, double paramDouble3, string paramString4, string paramString5, MaterialTable paramMaterialTable, IDictionary<string, RSMeansLaborItem> paramMap, string paramString6, double paramDouble4)
	  {
		AssemblyTable assemblyTable = BlankResourceInitializer.createBlankAssembly(null);
		string str = RSMeansUOMConverter.convertImperialToMetricUnit(paramString4);
		if (string.ReferenceEquals(str, null))
		{
		  throw new Exception("FATAL: UNIT WAS NULL FOR " + paramString4 + ". AND ACCT " + paramString1);
		}
		assemblyTable.Title = StringUtils.makeShortTitle(paramString2);
		assemblyTable.GroupCode = "";
		assemblyTable.GekCode = "";
		assemblyTable.ExtraCode1 = paramGroupCode.ToString();
		assemblyTable.Unit = str;
		assemblyTable.EditorId = "rsmeans";
		assemblyTable.StateProvince = "";
		assemblyTable.Country = "US";
		assemblyTable.Currency = "USD";
		assemblyTable.Productivity = RSMeansUOMConverter.convertImperialToMetricInverseRate(paramString4, new BigDecimalFixed("" + (paramDouble2 / 8.0D)));
		assemblyTable.Project = "";
		assemblyTable.PublishedRate = RSMeansUOMConverter.convertImperialToMetricRate(paramString4, new BigDecimalFixed("" + paramDouble4));
		assemblyTable.PublishedRevisionCode = paramString5;
		assemblyTable.Notes = "MF04: " + paramString1;
		assemblyTable.Description = paramString2 + ", SK: " + paramString5 + ", MF04: " + paramString1 + ", CB: " + paramString6 + getReferenceString(paramGroupCode.getGroupCode()) + getGraphicString(paramString1);
		assemblyTable.LastUpdate = this.lastUpdate;
		assemblyTable.BimMaterial = "";
		assemblyTable.BimType = "";
		assemblyTable.Virtual = false;
		assemblyTable.VirtualEquipment = false;
		assemblyTable.VirtualSubcontractor = false;
		assemblyTable.VirtualLabor = false;
		assemblyTable.VirtualMaterial = false;
		assemblyTable.VirtualConsumable = false;
		assemblyTable.Quantity = BigDecimalMath.ZERO;
		assemblyTable.Accuracy = "enum.quotation.accuracy.estimated";
		assemblyTable.CreateDate = assemblyTable.LastUpdate;
		assemblyTable.CreateUserId = "rsmeans";
		Serializable serializable = assemblyTable.AssemblyId;
		if (serializable == null)
		{
		  serializable = paramSession.save(assemblyTable);
		}
		else
		{
		  paramSession.update(assemblyTable);
		}
		assemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), serializable);
		if (paramDouble1 != 0.0D)
		{
		  ISet<object> set = assemblyTable.AssemblyLaborSet;
		  if (set == null)
		  {
			assemblyTable.AssemblyLaborSet = new HashSet<object>();
		  }
		  foreach (RSMeansCrewItem rSMeansCrewItem in getOrCreateCrewItemList(paramString3))
		  {
			if (rSMeansCrewItem.Labor)
			{
			  RSMeansLaborItem rSMeansLaborItem = (RSMeansLaborItem)paramMap[rSMeansCrewItem.Code];
			  LaborTable laborTable = rSMeansLaborItem.LaborTable;
			  if (laborTable != null)
			  {
				if (DatabaseDBUtil.LocalCommunication)
				{
				  laborTable = (LaborTable)paramSession.get(typeof(LaborTable), laborTable.LaborId);
				}
				else
				{
				  laborTable = (LaborTable)DatabaseDBUtil.loadBulk(typeof(LaborTable), new long?[] {laborTable.LaborId})[0];
				}
			  }
			  AssemblyLaborTable assemblyLaborTable = new AssemblyLaborTable();
			  assemblyLaborTable.Factor1 = new BigDecimalFixed(rSMeansCrewItem.Quantity);
			  assemblyLaborTable.Factor2 = new BigDecimalFixed("" + paramDouble3);
			  assemblyLaborTable.Factor3 = BigDecimalMath.ONE;
			  assemblyLaborTable.QuantityPerUnit = BigDecimalFixed.ONE;
			  assemblyLaborTable.QuantityPerUnitFormula = "";
			  assemblyLaborTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
			  assemblyLaborTable.LocalFactor = BigDecimalMath.ONE;
			  assemblyLaborTable.LocalCountry = "";
			  assemblyLaborTable.LocalStateProvince = "";
			  assemblyLaborTable.LastUpdate = assemblyTable.LastUpdate;
			  long? long1 = (long?)paramSession.save(assemblyLaborTable);
			  assemblyLaborTable.AssemblyLaborId = long1;
			  if (DatabaseDBUtil.LocalCommunication)
			  {
				assemblyTable.AssemblyLaborSet.Add(assemblyLaborTable);
				paramSession.saveOrUpdate(assemblyTable);
				assemblyLaborTable.LaborTable = laborTable;
				assemblyLaborTable.AssemblyTable = assemblyTable;
				paramSession.saveOrUpdate(assemblyLaborTable);
				continue;
			  }
			  assemblyLaborTable = (AssemblyLaborTable)DatabaseDBUtil.associateAssemblyResource(assemblyTable, laborTable, assemblyLaborTable);
			  assemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), assemblyTable.Id);
			  continue;
			}
			RSMeansEquipmentCrewItem rSMeansEquipmentCrewItem = (RSMeansEquipmentCrewItem)this.equCrewCache[rSMeansCrewItem.Code];
			EquipmentTable equipmentTable = rSMeansEquipmentCrewItem.EquipmentTable;
			if (equipmentTable != null)
			{
			  if (DatabaseDBUtil.LocalCommunication)
			  {
				equipmentTable = (EquipmentTable)paramSession.get(typeof(EquipmentTable), equipmentTable.EquipmentId);
			  }
			  else
			  {
				equipmentTable = (EquipmentTable)DatabaseDBUtil.loadBulk(typeof(EquipmentTable), new long?[] {equipmentTable.EquipmentId})[0];
			  }
			}
			AssemblyEquipmentTable assemblyEquipmentTable = new AssemblyEquipmentTable();
			assemblyEquipmentTable.Factor1 = new BigDecimalFixed(rSMeansCrewItem.Quantity);
			assemblyEquipmentTable.Factor2 = new BigDecimalFixed(paramDouble3);
			if (this.USE_O_AND_P)
			{
			  assemblyEquipmentTable.Factor3 = new BigDecimalFixed("1.1");
			}
			else
			{
			  assemblyEquipmentTable.Factor3 = BigDecimalMath.ONE;
			}
			assemblyEquipmentTable.LocalFactor = BigDecimalMath.ONE;
			assemblyEquipmentTable.LocalCountry = "";
			assemblyEquipmentTable.LocalStateProvince = "";
			assemblyEquipmentTable.EnergyPrice = BigDecimalMath.ZERO;
			assemblyEquipmentTable.QuantityPerUnit = BigDecimalMath.ONE;
			assemblyEquipmentTable.QuantityPerUnitFormula = "";
			assemblyEquipmentTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
			assemblyEquipmentTable.LastUpdate = assemblyTable.LastUpdate;
			long? long = (long?)paramSession.save(assemblyEquipmentTable);
			assemblyEquipmentTable.AssemblyEquipmentId = long;
			if (DatabaseDBUtil.LocalCommunication)
			{
			  assemblyTable.AssemblyEquipmentSet.Add(assemblyEquipmentTable);
			  paramSession.saveOrUpdate(assemblyTable);
			  assemblyEquipmentTable.EquipmentTable = equipmentTable;
			  assemblyEquipmentTable.AssemblyTable = assemblyTable;
			  paramSession.saveOrUpdate(assemblyEquipmentTable);
			  continue;
			}
			assemblyEquipmentTable = (AssemblyEquipmentTable)DatabaseDBUtil.associateAssemblyResource(assemblyTable, equipmentTable, assemblyEquipmentTable);
			assemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), assemblyTable.Id);
		  }
		}
		if (paramMaterialTable != null)
		{
		  AssemblyMaterialTable assemblyMaterialTable = new AssemblyMaterialTable();
		  if (this.USE_O_AND_P)
		  {
			assemblyMaterialTable.Factor1 = new BigDecimalFixed("1.1");
		  }
		  else
		  {
			assemblyMaterialTable.Factor1 = BigDecimalMath.ONE;
		  }
		  assemblyMaterialTable.Factor2 = BigDecimalMath.ONE;
		  assemblyMaterialTable.Factor3 = BigDecimalMath.ONE;
		  assemblyMaterialTable.QuantityPerUnit = BigDecimalMath.ONE;
		  assemblyMaterialTable.QuantityPerUnitFormula = "";
		  assemblyMaterialTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
		  assemblyMaterialTable.LocalFactor = BigDecimalMath.ONE;
		  assemblyMaterialTable.LocalCountry = "";
		  assemblyMaterialTable.LocalStateProvince = "";
		  assemblyMaterialTable.LastUpdate = assemblyTable.LastUpdate;
		  long? long = (long?)paramSession.save(assemblyMaterialTable);
		  assemblyMaterialTable.AssemblyMaterialId = long;
		  if (DatabaseDBUtil.LocalCommunication)
		  {
			paramMaterialTable.AssemblyMaterialSet.Add(assemblyMaterialTable);
			paramSession.saveOrUpdate(paramMaterialTable);
			assemblyTable.AssemblyMaterialSet.Add(assemblyMaterialTable);
			paramSession.saveOrUpdate(assemblyTable);
			assemblyMaterialTable.MaterialTable = paramMaterialTable;
			assemblyMaterialTable.AssemblyTable = assemblyTable;
			paramSession.saveOrUpdate(assemblyMaterialTable);
		  }
		  else
		  {
			assemblyMaterialTable = (AssemblyMaterialTable)DatabaseDBUtil.associateAssemblyResource(assemblyTable, paramMaterialTable, assemblyMaterialTable);
			assemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), assemblyTable.Id);
		  }
		}
		if (DatabaseDBUtil.LocalCommunication)
		{
		  assemblyTable.calculateRate();
		  paramSession.saveOrUpdate(assemblyTable);
		}
	  }

	  private IList<RSMeansCrewItem> getOrCreateCrewItemList(string paramString)
	  {
		System.Collections.IList list = (System.Collections.IList)this.crewMetCache[paramString];
		if (list == null)
		{
		  list = new List<object>(1);
		  list.Add(new RSMeansCrewItem(paramString, 1.0D, "", paramString));
		}
		return list;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private nomitech.common.db.local.SubcontractorTable saveOrUpdateSubcontractorTable(org.hibernate.Session paramSession, nomitech.common.base.GroupCode paramGroupCode, String paramString1, String paramString2, double paramDouble1, double paramDouble2, String paramString3, String paramString4, String paramString5) throws Exception
	  private SubcontractorTable saveOrUpdateSubcontractorTable(Session paramSession, GroupCode paramGroupCode, string paramString1, string paramString2, double paramDouble1, double paramDouble2, string paramString3, string paramString4, string paramString5)
	  {
		null = BlankResourceInitializer.createBlankSubcontractor(null);
		null.Title = StringUtils.makeShortTitle(paramString2);
		string str = RSMeansUOMConverter.convertImperialToMetricUnit(paramString3);
		if (string.ReferenceEquals(str, null))
		{
		  throw new Exception("FATAL: UNIT WAS NULL FOR " + paramString3 + ". AND MF04 " + paramString1);
		}
		null.GroupCode = "";
		null.GekCode = "";
		null.ExtraCode1 = paramGroupCode.ToString();
		null.Unit = str;
		null.EditorId = "rsmeans";
		null.Address = "";
		null.ContactPerson = "";
		null.Rate = RSMeansUOMConverter.convertImperialToMetricRate(paramString3, new BigDecimalFixed(paramDouble1));
		if (this.USE_O_AND_P_LABORS)
		{
		  null.IKA = RSMeansUOMConverter.convertImperialToMetricRate(paramString3, new BigDecimalFixed(paramDouble2));
		}
		else
		{
		  null.IKA = BigDecimalMath.ZERO;
		}
		null.SubMaterialRate = BigDecimalMath.ZERO;
		null.City = "";
		null.Email = "";
		null.Company = "";
		null.FaxNumber = "";
		null.MobileNumber = "";
		null.PhoneNumber = "";
		null.Performance = "8";
		null.Url = "";
		null.Project = "";
		null.Country = "US";
		null.StateProvince = "USA AVERAGE";
		null.Currency = "USD";
		null.Accuracy = "enum.quotation.accuracy.estimated";
		null.Inclusion = "enum.inclusion.subonly";
		null.Quantity = new BigDecimalFixed(0);
		null.Notes = "MF04: " + paramString1;
		null.Description = paramString2 + ", SK: " + paramString4 + ", MF04: " + paramString1 + ", CB: " + paramString5 + getReferenceString(paramGroupCode.getGroupCode()) + getGraphicString(paramString1);
		null.LastUpdate = this.lastUpdate;
		null.CreateDate = this.lastUpdate;
		null.CreateUserId = "rsmeans";
		long? long = null.SubcontractorId;
		if (long == null)
		{
		  long = (long?)paramSession.save(null);
		}
		else
		{
		  paramSession.update(null);
		}
		return (SubcontractorTable)DatabaseDBUtil.loadBulk(typeof(SubcontractorTable), new long?[] {long})[0];
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private nomitech.common.db.local.MaterialTable saveOrUpdateMaterialTable(org.hibernate.Session paramSession, nomitech.common.base.GroupCode paramGroupCode, String paramString1, String paramString2, double paramDouble, String paramString3, String paramString4, String paramString5) throws Exception
	  private MaterialTable saveOrUpdateMaterialTable(Session paramSession, GroupCode paramGroupCode, string paramString1, string paramString2, double paramDouble, string paramString3, string paramString4, string paramString5)
	  {
		null = BlankResourceInitializer.createBlankMaterial(null);
		null.Title = StringUtils.makeShortTitle(paramString2);
		string str = RSMeansUOMConverter.convertImperialToMetricUnit(paramString3);
		if (string.ReferenceEquals(str, null))
		{
		  throw new Exception("FATAL: UNIT WAS NULL FOR " + paramString3 + ". AND MF04 " + paramString1);
		}
		null.GroupCode = "";
		null.GekCode = "";
		null.ExtraCode1 = paramGroupCode.ToString();
		null.Unit = str;
		null.EditorId = "rsmeans";
		null.Weight = BigDecimalMath.ZERO;
		null.WeightUnit = "LB";
		null.RawMaterial = "enum.rm.unspecified";
		null.RawMaterialReliance = BigDecimalMath.ZERO;
		null.RawMaterial2 = "enum.rm.unspecified";
		null.RawMaterialReliance2 = BigDecimalMath.ZERO;
		null.RawMaterial3 = "enum.rm.unspecified";
		null.RawMaterialReliance3 = BigDecimalMath.ZERO;
		null.RawMaterial4 = "enum.rm.unspecified";
		null.RawMaterialReliance4 = BigDecimalMath.ZERO;
		null.RawMaterial5 = "enum.rm.unspecified";
		null.RawMaterialReliance5 = BigDecimalMath.ZERO;
		null.Rate = RSMeansUOMConverter.convertImperialToMetricRate(paramString3, new BigDecimalFixed(paramDouble));
		null.Project = "";
		null.Country = "US";
		null.StateProvince = "";
		null.Currency = "USD";
		null.Notes = "MF04: " + paramString1;
		null.Description = paramString2 + ", SK: " + paramString4 + ", MF04: " + paramString1 + ", CB: " + paramString5 + getReferenceString(paramGroupCode.getGroupCode()) + getGraphicString(paramString1);
		null.LastUpdate = this.lastUpdate;
		null.CreateDate = this.lastUpdate;
		null.CreateUserId = "rsmeans";
		null.Accuracy = "enum.quotation.accuracy.estimated";
		null.Inclusion = "enum.inclusion.matonly";
		null.Quantity = new BigDecimalFixed(0);
		null.DistanceToSite = new BigDecimalFixed(0);
		null.DistanceUnit = "MILE";
		null.ShipmentRate = new BigDecimalFixed(0);
		null.FabricationRate = new BigDecimalFixed(0);
		null.TotalRate = null.Rate;
		long? long = null.MaterialId;
		if (long == null)
		{
		  long = (long?)paramSession.save(null);
		}
		else
		{
		  paramSession.update(null);
		}
		return (MaterialTable)DatabaseDBUtil.loadBulk(typeof(MaterialTable), new long?[] {long})[0];
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private nomitech.common.db.local.EquipmentTable saveOrUpdateEquipmentTable(org.hibernate.Session paramSession, nomitech.common.base.GroupCode paramGroupCode, String paramString1, String paramString2, String paramString3, String paramString4, double paramDouble, String paramString5) throws Exception
	  private EquipmentTable saveOrUpdateEquipmentTable(Session paramSession, GroupCode paramGroupCode, string paramString1, string paramString2, string paramString3, string paramString4, double paramDouble, string paramString5)
	  {
		null = BlankResourceInitializer.createBlankEquipment(null);
		null.Title = paramString2 + paramString3;
		null.Model = "";
		null.Make = "";
		null.Currency = "USD";
		null.Country = "US";
		null.StateProvince = "US AVERAGE";
		null.GroupCode = "";
		null.GekCode = "";
		null.ExtraCode1 = paramGroupCode.ToString();
		null.EditorId = "rsmeans";
		string str = RSMeansUOMConverter.convertImperialToMetricUnit(paramString5);
		if (string.ReferenceEquals(str, null))
		{
		  throw new Exception("FATAL: UNIT WAS NULL FOR " + paramString5 + ". AND MF04 " + paramString1);
		}
		null.Unit = "HOUR";
		if (str.Equals("DAY"))
		{
		  paramDouble *= 0.125D;
		}
		else if (str.Equals("WEEK"))
		{
		  paramDouble *= 0.025D;
		}
		else if (str.Equals("MONTH"))
		{
		  paramDouble *= 0.00625D;
		}
		if (paramString2.ToLower().IndexOf("diesel", StringComparison.Ordinal) != -1)
		{
		  null.FuelType = "DIESEL";
		}
		else if (paramString2.ToLower().IndexOf("gas", StringComparison.Ordinal) != -1)
		{
		  null.FuelType = "PETROL";
		}
		else if (paramString2.ToLower().IndexOf("electric", StringComparison.Ordinal) != -1)
		{
		  null.FuelType = "ELECTRIC";
		}
		else
		{
		  null.FuelType = "OTHER";
		}
		null.DepreciationCalculationMethod = EquipmentTable.USER_DEFINED_METHOD;
		null.DepreciationYears = BigInteger.Parse("6");
		null.OccupationalFactor = new BigDecimalFixed("0.73");
		null.OccupationHoursPerMonth = new BigDecimalFixed("175.0");
		null.InitAquasitionPrice = new BigDecimalFixed("0.0");
		null.InterestRate = new BigDecimalFixed("0.065");
		null.LubricatesRate = BigDecimalMath.ZERO;
		null.TiresRate = BigDecimalMath.ZERO;
		null.FuelConsumption = BigDecimalMath.ZERO;
		null.SparePartsRate = BigDecimalMath.ZERO;
		null.ReservationRate = RSMeansUOMConverter.convertImperialToMetricRate(paramString5, new BigDecimalFixed(paramDouble));
		null.DepreciationRate = BigDecimalMath.ZERO;
		null.FuelRate = BigDecimalMath.ZERO;
		null.TotalRate = RSMeansUOMConverter.convertImperialToMetricRate(paramString5, new BigDecimalFixed(paramDouble));
		null.Notes = "MF04: " + paramString1;
		null.Description = paramString2 + paramString3 + paramString4 + ", MF04: " + paramString1 + getReferenceString(paramGroupCode.getGroupCode()) + getGraphicString(paramString1);
		null.LastUpdate = this.lastUpdate;
		null.CreateDate = this.lastUpdate;
		null.CreateUserId = "rsmeans";
		long? long = null.EquipmentId;
		if (long == null)
		{
		  long = (long?)paramSession.save(null);
		}
		else
		{
		  paramSession.update(null);
		}
		return (EquipmentTable)DatabaseDBUtil.loadBulk(typeof(EquipmentTable), new long?[] {long})[0];
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void migrateFromFolder(String paramString) throws Exception
	  public static void migrateFromFolder(string paramString)
	  {
		  new RSMeansMigrationUtil(paramString);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\RSMeansMigrationUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}