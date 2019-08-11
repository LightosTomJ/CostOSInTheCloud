using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Numerics;

namespace Desktop.common.nomitech.common.migration
{
	using BaseTableItem = nomitech.common.@base.BaseTableItem;
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
	using ParamItemInputTable = nomitech.common.db.local.ParamItemInputTable;
	using ParamItemOutputTable = nomitech.common.db.local.ParamItemOutputTable;
	using ParamItemTable = nomitech.common.db.local.ParamItemTable;
	using SubcontractorTable = nomitech.common.db.local.SubcontractorTable;
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using BlankResourceInitializer = nomitech.common.expr.boqitem.BlankResourceInitializer;
	using CCIToLocalizationLoader = Desktop.common.nomitech.common.migration.rsmeans.CCIToLocalizationLoader;
	using FactorData = Desktop.common.nomitech.common.migration.rsmeans.FactorData;
	using GraphicExtractorUtil = Desktop.common.nomitech.common.migration.rsmeans.GraphicExtractorUtil;
	using MasterFormatLoader = Desktop.common.nomitech.common.migration.rsmeans.MasterFormatLoader;
	using RSMeansCrewItem = Desktop.common.nomitech.common.migration.rsmeans.RSMeansCrewItem;
	using RSMeansEquipmentCrewItem = Desktop.common.nomitech.common.migration.rsmeans.RSMeansEquipmentCrewItem;
	using RSMeansLaborItem = Desktop.common.nomitech.common.migration.rsmeans.RSMeansLaborItem;
	using RSMeansUOMConverter = Desktop.common.nomitech.common.migration.rsmeans.RSMeansUOMConverter;
	using UniFormatLoader = Desktop.common.nomitech.common.migration.rsmeans.UniFormatLoader;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	using ImageUtils = nomitech.common.util.ImageUtils;
	using StringUtils = nomitech.common.util.StringUtils;
	using Query = org.hibernate.Query;
	using Session = org.hibernate.Session;
	using Transaction = org.hibernate.Transaction;

	public class RSMeansMigrationUtil2014
	{
	  private const bool ONLINE_REFERENCE = false;

	  private const string EDITION = "2014";

	  private const string SMALLEDITION = "14";

	  private const double HOURS_OF_DAY = 8.0D;

	  private const double HOURS_OF_WEEK = 40.0D;

	  private const double HOURS_OF_MONTH = 160.0D;

	  private IDictionary<string, string> UNITCOST_FILES_TO_MIGRATE = new SortedDictionary();

	  private IDictionary<string, string> ASSEMBLIES_FILES_TO_MIGRATE = new SortedDictionary();

	  private bool USE_O_AND_P = true;

	  private bool USE_O_AND_P_LABORS = true;

	  private int CLEAR_SESSION_INTERVAL = 500;

	  private int PROGRESS_SHOW_INTERVAL = 2000;

	  private bool USE_COST_BOOK_DUPLICATES = false;

	  private IDictionary<string, string> DISTINCT_VALUES_MAP = new Hashtable(50000);

	  private string LOCATION_PROFILE_ID = "L";

	  private string DEFAULT_LOCATION_FACTOR = "US;;ALABAMA;;ANNISTON;;362";

	  private IDictionary<string, GroupCode> masterFormat04Map = null;

	  private IDictionary<string, GroupCode> uniFormatMap = null;

	  private IDictionary<string, string> referenceUnitCostPDF = null;

	  private IDictionary<string, string> graphicsUnitCostPDF = null;

	  private IDictionary<string, string> referenceAssembliesPDF = null;

	  private IDictionary<string, string> graphicsAssembliesPDF = null;

	  private IDictionary<string, string> graphicsAssembliesText = new Hashtable();

	  private IDictionary<string, string> graphicsAssembliesHtml = new Hashtable();

	  private string unitCostDataFolder = null;

	  private string assembliesDataFolder = null;

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

	  private IDictionary<string, long> processedAssembliesMap = new Hashtable();

	  private void init()
	  {
		this.UNITCOST_FILES_TO_MIGRATE["FACL"] = "Facility";
		this.ASSEMBLIES_FILES_TO_MIGRATE["Facility"] = "FAC";
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private RSMeansMigrationUtil2014(String paramString) throws Exception
	  private RSMeansMigrationUtil2014(string paramString)
	  {
		this.unitCostDataFolder = paramString + File.separator + "Unit Cost Data " + "2014";
		this.assembliesDataFolder = paramString + File.separator + "Assemblies Data " + "2014";
		this.laborCrewFolder = paramString + File.separator + "Labor-Eq-Crew";
		this.referenceFolder = paramString + File.separator + "Ref-Graphics";
		init();
		this.referenceUnitCostPDF = cacheUnitCostReferencePDF();
		this.graphicsUnitCostPDF = cacheUnitCostGraphicsPDF();
		this.referenceAssembliesPDF = cacheAssembliesReferencePDF();
		this.graphicsAssembliesPDF = cacheAssembliesGraphicsPDF();
		this.graphicsAssembliesText = loadGraphicsAssemliesText();
		this.graphicsAssembliesHtml = loadGraphicsAssemliesHtml();
		this.LOCATION_PROFILE_ID += loadCCI(paramString);
		loadMasterFormat();
		loadUniFormat();
		if (RSMeansUOMConverter.CONVERT_TO_METRIC)
		{
		  this.crewMetCache = cacheCrew("MET2014");
		}
		else
		{
		  this.crewMetCache = cacheCrew("STD2014");
		}
		Session session = DatabaseDBUtil.currentSession();
		Transaction transaction = session.beginTransaction();
		try
		{
		  Console.WriteLine("SAVING EQUIPMENT COST DATA: ");
		  loadEquipments(session);
		  this.laborOpenCache = cacheAndLoadLabors(session, "OPEN2014", ", Open Shop or Light Commercial Rate");
		  this.laborResiCache = cacheAndLoadLabors(session, "RESI2014", ", Residential Rate");
		  this.laborRRCache = cacheAndLoadLabors(session, "RR2014", ", Repair & Remodeling or Facility Rate");
		  this.laborStandardCache = cacheAndLoadLabors(session, "STD2014", "");
		  if (RSMeansUOMConverter.CONVERT_TO_METRIC)
		  {
			this.equCrewCache = cacheAndLoadEquipment(session, "EQM2014");
		  }
		  else
		  {
			this.equCrewCache = cacheAndLoadEquipment(session, "EQ2014");
		  }
		  saveCrewsAsAssemblies();
		  transaction.commit();
		}
		catch (Exception exception)
		{
		  transaction.rollback();
		  DatabaseDBUtil.closeSession();
		  throw exception;
		}
		DatabaseDBUtil.closeSession();
		loadUnitCostAndAssembliesData();
		mergeAssemblies();
	  }

	  private void saveCrewsAsAssemblies()
	  {
	  }

	  private string getUnitCostGraphicString(string paramString)
	  {
		string str = (string)this.graphicsUnitCostPDF[paramString];
		return (string.ReferenceEquals(str, null)) ? "" : ("\nGRAPHIC: http://www.costdatabase.eu/rsmeans/14/uc/graphics/" + str + ".PDF");
	  }

	  private string getUnitCostReferenceString(string paramString)
	  {
		string str = (string)this.referenceUnitCostPDF[paramString];
		return (string.ReferenceEquals(str, null)) ? "" : ("\nPDF: http://www.costdatabase.eu/rsmeans/14/uc/pdf/" + str + ".PDF");
	  }

	  private string getAssembliesGraphicString(string paramString)
	  {
		string str = (string)this.graphicsAssembliesPDF[paramString];
		return (string.ReferenceEquals(str, null)) ? "" : ("\nGRAPHIC: http://www.costdatabase.eu/rsmeans/14/as/graphics/" + str + ".PDF");
	  }

	  private string getAssembliesGraphicURL(string paramString)
	  {
		string str = (string)this.graphicsAssembliesPDF[paramString];
		return (string.ReferenceEquals(str, null)) ? "" : ("http://www.costdatabase.eu/rsmeans/as/14/graphics/" + str + ".PDF");
	  }

	  private string getAssembliesGraphicFILE(string paramString)
	  {
		string str = (string)this.graphicsAssembliesPDF[paramString];
		return (string.ReferenceEquals(str, null)) ? "" : Path.GetFullPath(this.referenceFolder + File.separator + "Assembly" + File.separator + "as" + File.separator + "graphics" + File.separator + str + ".PDF");
	  }

	  private string getAssembliesGraphicPNG(string paramString)
	  {
		string str = (string)this.graphicsAssembliesPDF[paramString];
		return (string.ReferenceEquals(str, null)) ? "" : Path.GetFullPath(this.referenceFolder + File.separator + "Assembly" + File.separator + "as" + File.separator + "graphics" + File.separator + str + ".PNG");
	  }

	  private string getAssembliesReferenceString(string paramString)
	  {
		string str = (string)this.referenceAssembliesPDF[paramString];
		return (string.ReferenceEquals(str, null)) ? "" : ("\nPDF: http://www.costdatabase.eu/rsmeans/14/as/pdf/" + str + ".PDF");
	  }

	  private string getAssembliesReferenceURL(string paramString)
	  {
		string str = (string)this.referenceAssembliesPDF[paramString];
		return (string.ReferenceEquals(str, null)) ? "" : ("http://www.costdatabase.eu/rsmeans/14/as/pdf/" + str + ".PDF");
	  }

	  private string getAssembliesReferenceFILE(string paramString)
	  {
		string str = (string)this.referenceAssembliesPDF[paramString];
		return (string.ReferenceEquals(str, null)) ? "" : Path.GetFullPath(this.referenceFolder + File.separator + "Assembly" + File.separator + "as" + File.separator + "pdf" + File.separator + str + ".PDF");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void doRename(String paramString) throws Exception
	  private void doRename(string paramString)
	  {
		File file = new File(paramString);
		if (!file.exists())
		{
		  Console.WriteLine("Could not execute import from directory " + paramString + " as it does not exist.");
		  return;
		}
		if (!file.Directory)
		{
		  Console.WriteLine("Could not execute import from directory " + paramString + " as it is not a directory.");
		  return;
		}
		string[] arrayOfString = file.list();
		for (sbyte b = 0; b < arrayOfString.Length; b++)
		{
		  string str1 = arrayOfString[b];
		  Console.WriteLine("Processing file " + str1);
		  string str2 = str1.ToUpper();
		  File file1 = new File(paramString + str1);
		  File file2 = new File(paramString + str2);
		  bool @bool = file1.renameTo(file2);
		  if (@bool)
		  {
			Console.WriteLine("SUCCESSFULLY renamed " + file + " to " + file2);
		  }
		  else
		  {
			Console.WriteLine("FAILED to rename " + file + " to " + file2);
		  }
		}
	  }

	  private IDictionary<string, string> loadGraphicsAssemliesText()
	  {
		Console.WriteLine("LOADING TEXT FROM GRAPHIC PDF");
		sbyte b = 0;
		foreach (string str1 in this.graphicsAssembliesPDF.Keys)
		{
		  string str2 = getAssembliesGraphicFILE(str1);
		  string str3 = null;
		  if (!StringUtils.isNullOrBlank(str2) && Directory.Exists(str2) || File.Exists(str2))
		  {
			str3 = GraphicExtractorUtil.extractTextFromPDF(str2);
			if (b++ % 20 == 0)
			{
			  Console.WriteLine("LOADED " + b + " PDFS OF TEXT");
			}
		  }
		  if (!string.ReferenceEquals(str3, null))
		  {
			this.graphicsAssembliesText[str1] = str3;
		  }
		}
		Console.WriteLine("DONE LOADING TEXT");
		return this.graphicsAssembliesText;
	  }

	  private IDictionary<string, string> loadGraphicsAssemliesHtml()
	  {
		Console.WriteLine("LOADING GRAPHIC ASSEMBLIES HTML");
		sbyte b = 0;
		foreach (string str1 in this.graphicsAssembliesPDF.Keys)
		{
		  string str2 = (string)this.graphicsAssembliesPDF[str1];
		  string str3 = (string)this.graphicsAssembliesText[str1];
		  string str4 = null;
		  if (!StringUtils.isNullOrBlank(str2))
		  {
			str4 = GraphicExtractorUtil.makeGraphicHTML(str2, str3);
			if (b++ % 20 == 0)
			{
			  Console.WriteLine("LOADED " + b + " PAGES OF HTML");
			}
		  }
		  if (!string.ReferenceEquals(str4, null))
		  {
			this.graphicsAssembliesHtml[str1] = str4;
		  }
		}
		Console.WriteLine("DONE LOADING ASSEMBLIES HTML");
		return this.graphicsAssembliesHtml;
	  }

	  private void renameToUpperCase()
	  {
		doRename(this.referenceFolder + File.separator + "Assembly" + File.separator + "as" + File.separator + "pdf" + File.separator);
		doRename(this.referenceFolder + File.separator + "Assembly" + File.separator + "as" + File.separator + "graphics" + File.separator);
	  }

	  private void convertPDFsToImages()
	  {
		string str = this.referenceFolder + File.separator + "Assembly" + File.separator + "as" + File.separator + "graphics" + File.separator;
		renameToUpperCase();
		Console.WriteLine("CONVERTING REFERENCE TABLES TO IMAGES");
		foreach (string str1 in this.referenceAssembliesPDF.Keys)
		{
		  string str2 = getAssembliesReferenceFILE(str1);
		  if (!StringUtils.isNullOrBlank(str2) && Directory.Exists(str2) || File.Exists(str2))
		  {
			string str3 = StringUtils.replaceAll(str2, ".PDF", ".JPG");
			if (!Directory.Exists(str3) || File.Exists(str3))
			{
			  ImageUtils.savePDFAsJPG(str2, str3);
			  Console.WriteLine("Converting: " + str2);
			  continue;
			}
			Console.WriteLine("IMAGE EXISTS: " + str3);
			continue;
		  }
		  Console.WriteLine("REFERENCE NOT FOUND: " + str2);
		}
		Console.WriteLine("CONVERTING GRAPHICS TO IMAGES");
		foreach (string str1 in this.graphicsAssembliesPDF.Keys)
		{
		  string str2 = getAssembliesGraphicFILE(str1);
		  if (!StringUtils.isNullOrBlank(str2) && Directory.Exists(str2) || File.Exists(str2))
		  {
			string str3 = StringUtils.replaceAll(str2, ".PDF", ".PNG");
			if (!Directory.Exists(str3) || File.Exists(str3))
			{
			  string str4 = (string)this.graphicsAssembliesPDF[str1];
			  GraphicExtractorUtil.extractImageFromPDF(str2, str, str4);
			  Console.WriteLine("Converting: " + str2);
			  continue;
			}
			Console.WriteLine("IMAGE EXISTS: " + str3);
			continue;
		  }
		  Console.WriteLine("GRAPHIC NOT FOUND: " + str2);
		}
		Console.WriteLine("END IMAGE CONVERSION");
	  }

	  private IDictionary<string, string> cacheUnitCostReferencePDF()
	  {
		Hashtable hashMap = new Hashtable();
		File file = new File(this.referenceFolder + File.separator + "Unit Cost" + File.separator + "Unit Cost References" + "2014" + ".txt");
		Console.WriteLine("PROCESSING UNIT COST REFERENCE FILE: " + file.AbsolutePath);
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

	  private IDictionary<string, string> cacheAssembliesReferencePDF()
	  {
		Hashtable hashMap = new Hashtable();
		File file = new File(this.referenceFolder + File.separator + "Assembly" + File.separator + "Assembly References " + "2014" + ".txt");
		Console.WriteLine("PROCESSING ASSEMBLIES REFERENCE FILE: " + file.AbsolutePath);
		StreamReader bufferedReader = new StreamReader(file);
		while (true)
		{
		  string str1 = bufferedReader.ReadLine();
		  if (string.ReferenceEquals(str1, null))
		  {
			break;
		  }
		  string str2 = StringUtils.removeSpacesFromEnd(str1.Substring(0, 8));
		  string str3 = StringUtils.removeSpacesFromEnd(str1.Substring(9, 9));
		  hashMap[str2] = str3.ToUpper();
		}
		bufferedReader.Close();
		return hashMap;
	  }

	  private IDictionary<string, string> cacheUnitCostGraphicsPDF()
	  {
		Hashtable hashMap = new Hashtable();
		File file = new File(this.referenceFolder + File.separator + "Unit Cost" + File.separator + "Unit Cost Graphics" + "2014" + ".txt");
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

	  private IDictionary<string, string> cacheAssembliesGraphicsPDF()
	  {
		Hashtable hashMap = new Hashtable();
		File file = new File(this.referenceFolder + File.separator + "Assembly" + File.separator + "Assembly Graphics " + "2014" + ".txt");
		Console.WriteLine("PROCESSING ASSEMBLIES GRAPHICS FILE: " + file.AbsolutePath);
		StreamReader bufferedReader = new StreamReader(file);
		while (true)
		{
		  string str1 = bufferedReader.ReadLine();
		  if (string.ReferenceEquals(str1, null))
		  {
			break;
		  }
		  string str2 = StringUtils.removeSpacesFromEnd(str1.Substring(0, 8));
		  string str3 = StringUtils.removeSpacesFromEnd(str1.Substring(9, 8));
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
		  string str4 = StringUtils.proper(StringUtils.removeSpacesFromEnd(str1.Substring(30, 36)));
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
		  string str2 = StringUtils.removeSpacesFromEnd(str1.Substring(0, 5)).ToUpper();
		  string str3 = StringUtils.proper(StringUtils.removeSpacesFromEnd(str1.Substring(5, 40)));
		  double d1 = (Convert.ToDouble(StringUtils.removeSpacesFromEnd(str1.Substring(45, 10))));
		  double d2 = (Convert.ToDouble(StringUtils.removeSpacesFromEnd(str1.Substring(55, 10))));
		  string str4 = (string)this.crewDescriptionCache[str2];
		  string str5 = (string)this.crewDescriptionCache[str2 + "A"];
		  string str6 = (string)this.crewDescriptionCache[str2 + "O"];
		  string str7 = (string)this.crewDescriptionCache[str2 + "I"];
		  LaborTable laborTable1 = BlankResourceInitializer.createBlankLabor(null);
		  laborTable1.ItemCode = str2;
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
		  laborTable1.ExtraCode1 = "";
		  laborTable1.ExtraCode2 = "";
		  laborTable1.ExtraCode3 = "";
		  laborTable1.ExtraCode4 = "";
		  laborTable1.ExtraCode5 = "";
		  laborTable1.ExtraCode6 = "";
		  laborTable1.ExtraCode7 = "";
		  laborTable1.ExtraCode8 = "";
		  laborTable1.ExtraCode9 = "";
		  laborTable1.ExtraCode10 = "";
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
			laborTable.ItemCode = str2 + "A";
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
			laborTable.ItemCode = str2 + "O";
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
			laborTable.ItemCode = str2 + "I";
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
		  string str2 = StringUtils.removeSpacesFromEnd(str1.Substring(12, 10));
		  string str3 = StringUtils.removeSpacesFromEnd(str1.Substring(22, 12));
		  string str4 = StringUtils.proper(StringUtils.removeSpacesFromEnd(str1.Substring(34, 35)));
		  double d = (Convert.ToDouble(StringUtils.removeSpacesFromEnd(str1.Substring(69, 11))));
		  GroupCode groupCode = (GroupCode)this.masterFormat04Map[str3.Substring(0, 8)];
		  if (groupCode == null)
		  {
			Console.WriteLine("I could not fing a code for: '" + str3.Substring(0, 8) + "'");
		  }
		  EquipmentTable equipmentTable = saveOrUpdateEquipmentTable(paramSession, groupCode, str3, str2, str4, "", ", this is the equipment crew rate used by assemblies for a rental rate search by MF04", d, "DAY");
		  hashMap[str3] = new RSMeansEquipmentCrewItem(str3, str4, d, (EquipmentTable)equipmentTable.clone());
		}
		bufferedReader.Close();
		return hashMap;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private System.Nullable<long> loadCCI(String paramString) throws Exception
	  private long? loadCCI(string paramString)
	  {
		  return CCIToLocalizationLoader.loadUnitCCI(paramString, this.LOCATION_PROFILE_ID.Equals("O"), "CCI2014");
	  }

	  private void loadMasterFormat()
	  {
		Console.WriteLine("\n\n\nLOADING: MF12.CSI");
		this.masterFormat04Map = MasterFormatLoader.loadCSI(this.unitCostDataFolder, this.assembliesDataFolder, "MF12.CSI");
	  }

	  private void loadUniFormat()
	  {
		Console.WriteLine("\n\n\nLOADING: UNIFORMAT II");
		this.uniFormatMap = UniFormatLoader.loadUniFormat(this.assembliesDataFolder, "ASMUNI14");
	  }

	  private void mergeAssemblies()
	  {
		Session session = DatabaseDBUtil.currentSession();
		session.beginTransaction();
		try
		{
		  System.Collections.IList list = session.createQuery("select distinct (o.extraCode3) from ParamItemTable o").list();
		  System.Collections.IEnumerator iterator = list.GetEnumerator();
		  int i = list.Count;
		  sbyte b = 0;
		  Console.WriteLine("\n\n\nCREATING " + i + " MERGED ASSEMBLIES");
		  while (iterator.MoveNext())
		  {
			string str = (string)iterator.Current;
			Query query = session.createQuery("from ParamItemTable o where o.extraCode3 = :c order by o.paramitemId");
			query.setString("c", str);
			Console.WriteLine("Processing [" + ++b + "/" + i + "] :" + str);
			MergedAssemblyGenerator.Instance.mergeToOne(session, query.list(), str);
			if (b % 10 == 0)
			{
			  session.Transaction.commit();
			  session.beginTransaction();
			}
		  }
		  session.Transaction.commit();
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  if (DatabaseDBUtil.currentSession().Transaction.Active)
		  {
			DatabaseDBUtil.currentSession().Transaction.rollback();
		  }
		}
		DatabaseDBUtil.closeSession();
		Console.WriteLine("Finished Merging Assemblies");
	  }

	  private IDictionary<string, RSMeansLaborItem> getLaborCacheForFile(string paramString)
	  {
		  return (paramString.StartsWith("LITE", StringComparison.Ordinal) || paramString.StartsWith("OPEN", StringComparison.Ordinal)) ? this.laborOpenCache : (paramString.StartsWith("RESI", StringComparison.Ordinal) ? this.laborResiCache : ((paramString.StartsWith("FACL", StringComparison.Ordinal) || paramString.StartsWith("R&R", StringComparison.Ordinal)) ? this.laborRRCache : this.laborStandardCache));
	  }

	  private bool isStandardLaborCache(string paramString)
	  {
		  return (paramString.StartsWith("LITE", StringComparison.Ordinal) || paramString.StartsWith("OPEN", StringComparison.Ordinal)) ? false : (paramString.StartsWith("RESI", StringComparison.Ordinal) ? false : (!(paramString.StartsWith("FACL", StringComparison.Ordinal) || paramString.StartsWith("R&R", StringComparison.Ordinal))));
	  }

	  private string getCostBookForFile(string paramString)
	  {
		  return !this.USE_COST_BOOK_DUPLICATES ? ((paramString.StartsWith("LITE", StringComparison.Ordinal) || paramString.StartsWith("OPEN", StringComparison.Ordinal)) ? "Lite Commercial, Open Shop" : (paramString.StartsWith("RESI", StringComparison.Ordinal) ? "Residential" : (paramString.StartsWith("METR", StringComparison.Ordinal) ? "Metric" : ((paramString.StartsWith("FACL", StringComparison.Ordinal) || paramString.StartsWith("R&R", StringComparison.Ordinal)) ? "Facilities, Repair & Remodeling" : "General Construction")))) : paramString;
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
		  ((ExtraCode1Table)extraCode1Table).EditorId = "csi";
		  ((ExtraCode1Table)extraCode1Table).Description = "";
		  ((ExtraCode1Table)extraCode1Table).LastUpdate = this.lastUpdate;
		  paramSession.save(extraCode1Table);
		  Console.WriteLine("ADDED MF AFTER: " + extraCode1Table.ToString());
		  this.masterFormat04Map[paramString1] = extraCode1Table;
		}
		return extraCode1Table;
	  }

	  private void loadUnitCostAndAssembliesData()
	  {
		Transaction transaction = null;
		try
		{
		  Console.WriteLine("///////////////////////////////////////");
		  Console.WriteLine("// UNIT COST DATA 2014               //");
		  Console.WriteLine("///////////////////////////////////////\n\n\n");
		  foreach (string str1 in this.UNITCOST_FILES_TO_MIGRATE.Keys)
		  {
			string str2 = (string)this.UNITCOST_FILES_TO_MIGRATE[str1];
			long l = DateTimeHelper.CurrentUnixTimeMillis();
			Console.WriteLine("\nSleeping for 1 secs and continuing to " + str2);
			System.GC.Collect();
			Thread.Sleep(1000L);
			transaction = DatabaseDBUtil.currentSession().beginTransaction();
			transaction = saveUnitCostData(DatabaseDBUtil.currentSession(), str2, str1);
			transaction.commit();
			DatabaseDBUtil.closeSession();
			Console.WriteLine("FINISHED AT: " + ((DateTimeHelper.CurrentUnixTimeMillis() - l) / 60000L) + " minutes");
		  }
		  Console.WriteLine("///////////////////////////////////////");
		  Console.WriteLine("// ASSEMBLIES DATA 2014              //");
		  Console.WriteLine("///////////////////////////////////////");
		  foreach (string str1 in this.ASSEMBLIES_FILES_TO_MIGRATE.Keys)
		  {
			string str2 = (string)this.ASSEMBLIES_FILES_TO_MIGRATE[str1];
			long l = DateTimeHelper.CurrentUnixTimeMillis();
			Console.WriteLine("\nSleeping for 1 secs and continuing to " + str1);
			System.GC.Collect();
			Thread.Sleep(1000L);
			transaction = DatabaseDBUtil.currentSession().beginTransaction();
			transaction = saveAssembliesData(DatabaseDBUtil.currentSession(), str1, str2);
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
//ORIGINAL LINE: private org.hibernate.Transaction saveAssembliesData(org.hibernate.Session paramSession, String paramString1, String paramString2) throws Exception
	  private Transaction saveAssembliesData(Session paramSession, string paramString1, string paramString2)
	  {
		File file1 = new File(this.assembliesDataFolder + File.separator + paramString1 + File.separator + "ASMDES" + "14" + "." + paramString2);
		File file2 = new File(this.assembliesDataFolder + File.separator + paramString1 + File.separator + "ASSMUP" + "14" + "." + paramString2);
		File file3 = new File(this.assembliesDataFolder + File.separator + paramString1 + File.separator + "ASSM" + "2014" + "." + paramString2);
		Console.WriteLine("PROCESSING: " + file1.AbsolutePath);
		Console.WriteLine("CACHING FACTORS AND LINEITEMS...");
		System.Collections.IDictionary map = cacheFactors(paramSession, file3, file2, paramString2);
		StreamReader bufferedReader = new StreamReader(file1);
		int i = 0;
		DatabaseDBUtil.closeSession();
		paramSession = DatabaseDBUtil.currentSession();
		paramSession.beginTransaction();
		while (true)
		{
		  string str1 = bufferedReader.ReadLine();
		  if (string.ReferenceEquals(str1, null))
		  {
			break;
		  }
		  string str2 = str1.Substring(0, 12);
		  string str3 = str2.Substring(0, 8);
		  string str4 = StringUtils.proper(StringUtils.proper(StringUtils.removeSpacesFromEnd(str1.Substring(12, 255))));
		  string str5 = StringUtils.removeSpacesFromEnd(str1.Substring(267, 8));
		  long? long = (long?)this.processedAssembliesMap[str2];
		  if (long != null)
		  {
			ParamItemTable paramItemTable1 = (ParamItemTable)DatabaseDBUtil.currentSession().load(typeof(ParamItemTable), long);
			paramItemTable1.AccessRights = paramItemTable1.AccessRights + "," + paramString2;
			paramItemTable1.Description = paramItemTable1.Title + ", UNIFORMAT II: " + str2 + ", CB: " + paramItemTable1.AccessRights + getAssembliesReferenceString(str3) + getAssembliesGraphicString(str3);
			DatabaseDBUtil.currentSession().update(paramItemTable1);
			if (i++ % this.CLEAR_SESSION_INTERVAL == 0)
			{
			  DatabaseDBUtil.currentSession().Transaction.commit();
			  DatabaseDBUtil.closeSession();
			  DatabaseDBUtil.currentSession().beginTransaction();
			}
			continue;
		  }
		  double d1 = 0.0D;
		  double d2 = 0.0D;
		  double d3 = 0.0D;
		  try
		  {
			d1 = (Convert.ToDouble(StringUtils.removeAllSpaces(str1.Substring(275, 14))));
		  }
		  catch (Exception)
		  {
		  }
		  try
		  {
			d2 = (Convert.ToDouble(StringUtils.removeAllSpaces(str1.Substring(289, 14))));
		  }
		  catch (Exception)
		  {
		  }
		  try
		  {
			d3 = (Convert.ToDouble(StringUtils.removeAllSpaces(str1.Substring(303, 14))));
		  }
		  catch (Exception)
		  {
		  }
		  GroupCode groupCode = (GroupCode)this.uniFormatMap[str3];
		  string str6 = paramString2;
		  ParamItemTable paramItemTable = saveOrUpdateParamItemTable(DatabaseDBUtil.currentSession(), groupCode, str2, str4, str5, d1, d2, d3, str6, paramString2);
		  System.Collections.IList list = (System.Collections.IList)map[str2];
		  assignResourcesToParamItem(DatabaseDBUtil.currentSession(), paramItemTable, list, str6, str3);
		  this.processedAssembliesMap[str2] = paramItemTable.Id.Value;
		  if (this.PROGRESS_SHOW_INTERVAL != -1 && i % this.PROGRESS_SHOW_INTERVAL == 0)
		  {
			Console.WriteLine(paramString2 + " PROCESSED: " + i);
		  }
		  if (i++ % this.CLEAR_SESSION_INTERVAL == 0)
		  {
			DatabaseDBUtil.currentSession().Transaction.commit();
			DatabaseDBUtil.closeSession();
			DatabaseDBUtil.currentSession().beginTransaction();
		  }
		}
		map.Clear();
		bufferedReader.Close();
		return DatabaseDBUtil.currentSession().Transaction;
	  }

	  private void assignResourcesToParamItem(Session paramSession, ParamItemTable paramParamItemTable, IList<FactorData> paramList, string paramString1, string paramString2)
	  {
		if (paramParamItemTable.InputSet == null)
		{
		  paramParamItemTable.InputSet = new HashSet<object>();
		  paramParamItemTable.OutputSet = new HashSet<object>();
		}
		string str1 = (string)this.graphicsAssembliesHtml[paramString2];
		string str2 = "A. Localization";
		sbyte b1 = 1;
		if (!StringUtils.isNullOrBlank(str1))
		{
		  ParamItemInputTable paramItemInputTable1 = new ParamItemInputTable();
		  paramItemInputTable1.DataType = "datatype.notes";
		  paramItemInputTable1.DefaultValue = str1;
		  paramItemInputTable1.DependencyStatement = "";
		  paramItemInputTable1.ValidationStatement = "";
		  paramItemInputTable1.Description = "";
		  paramItemInputTable1.Grouping = "A. Specification";
		  paramItemInputTable1.SelectionList = "";
		  paramItemInputTable1.SortOrder = Convert.ToInt32(b1++);
		  paramItemInputTable1.Name = "Graphic";
		  paramItemInputTable1.Label = paramItemInputTable1.Name;
		  paramItemInputTable1.Pblk = false;
		  paramItemInputTable1.Hidden = false;
		  paramItemInputTable1.ParamItemTable = paramParamItemTable;
		  long? long1 = (long?)paramSession.save(paramItemInputTable1);
		  paramItemInputTable1 = (ParamItemInputTable)paramSession.load(typeof(ParamItemInputTable), long1);
		  paramParamItemTable.InputSet.Add(paramItemInputTable1);
		  paramSession.update(paramItemInputTable1);
		  str2 = "B. Localization";
		}
		ParamItemInputTable paramItemInputTable = new ParamItemInputTable();
		paramItemInputTable.Name = "UseLocation";
		paramItemInputTable.Label = paramItemInputTable.Name;
		paramItemInputTable.DataType = "datatype.boolean";
		paramItemInputTable.DefaultValue = "FALSE";
		paramItemInputTable.DependencyStatement = "";
		paramItemInputTable.ValidationStatement = "";
		paramItemInputTable.Description = "Click to use location factors";
		paramItemInputTable.Grouping = str2;
		paramItemInputTable.SelectionList = "";
		paramItemInputTable.SortOrder = Convert.ToInt32(b1++);
		paramItemInputTable.Pblk = true;
		paramItemInputTable.Hidden = false;
		paramItemInputTable.ParamItemTable = paramParamItemTable;
		long? long = (long?)paramSession.save(paramItemInputTable);
		paramItemInputTable = (ParamItemInputTable)paramSession.load(typeof(ParamItemInputTable), long);
		paramParamItemTable.InputSet.Add(paramItemInputTable);
		paramSession.update(paramItemInputTable);
		paramItemInputTable = new ParamItemInputTable();
		paramItemInputTable.Name = "Location";
		paramItemInputTable.Label = paramItemInputTable.Name;
		paramItemInputTable.DataType = "datatype.locfactor";
		paramItemInputTable.DependencyStatement = "UseLocation=TRUE()";
		paramItemInputTable.ValidationStatement = "";
		paramItemInputTable.Description = "Choose a location factor";
		paramItemInputTable.Grouping = str2;
		paramItemInputTable.SelectionList = this.LOCATION_PROFILE_ID;
		paramItemInputTable.DefaultValue = this.DEFAULT_LOCATION_FACTOR;
		paramItemInputTable.SortOrder = Convert.ToInt32(b1++);
		paramItemInputTable.Pblk = true;
		paramItemInputTable.Hidden = false;
		paramItemInputTable.ParamItemTable = paramParamItemTable;
		long = (long?)paramSession.save(paramItemInputTable);
		paramItemInputTable = (ParamItemInputTable)paramSession.load(typeof(ParamItemInputTable), long);
		paramParamItemTable.InputSet.Add(paramItemInputTable);
		paramSession.update(paramItemInputTable);
		string str3 = getAssembliesReferenceURL(paramString2);
		if (!StringUtils.isNullOrBlank(str3))
		{
		  paramItemInputTable = new ParamItemInputTable();
		  paramItemInputTable.DataType = "datatype.notes";
		  string str = StringUtils.replaceAll(str3, ".PDF", ".JPG");
		  paramItemInputTable.DefaultValue = "<html><a href=\"" + str3 + "\"><img border = 0 src=\"" + str + "\"/></a></html>";
		  paramItemInputTable.DependencyStatement = "";
		  paramItemInputTable.ValidationStatement = "";
		  paramItemInputTable.Description = "";
		  paramItemInputTable.Pblk = false;
		  paramItemInputTable.Hidden = false;
		  if (str2.StartsWith("A", StringComparison.Ordinal))
		  {
			paramItemInputTable.Grouping = "B. Reference Tables";
		  }
		  else
		  {
			paramItemInputTable.Grouping = "C. Reference Tables";
		  }
		  paramItemInputTable.SortOrder = Convert.ToInt32(b1++);
		  paramItemInputTable.SelectionList = "";
		  paramItemInputTable.Name = "ReferenceTable";
		  paramItemInputTable.Label = paramItemInputTable.Name;
		  paramItemInputTable.ParamItemTable = paramParamItemTable;
		  long = (long?)paramSession.save(paramItemInputTable);
		  paramItemInputTable = (ParamItemInputTable)paramSession.load(typeof(ParamItemInputTable), long);
		  paramParamItemTable.InputSet.Add(paramItemInputTable);
		  paramSession.update(paramItemInputTable);
		}
		sbyte b2 = 1;
		foreach (FactorData factorData in paramList)
		{
		  ParamItemOutputTable paramItemOutputTable = new ParamItemOutputTable();
		  paramItemOutputTable.Title = factorData.BaseTableItem.BaseTable.Title;
		  paramItemOutputTable.GenerationCondition = "TRUE()";
		  paramItemOutputTable.ProductivityEquation = "PRODUCTIVITY";
		  paramItemOutputTable.FactorEquation = "FACTOR";
		  paramItemOutputTable.EquLocEquation = "IF(UseLocation,Location,FACTOR)";
		  paramItemOutputTable.SubLocEquation = "FACTOR";
		  paramItemOutputTable.LabLocEquation = "IF(UseLocation,Location,FACTOR)";
		  paramItemOutputTable.MatLocEquation = "FACTOR";
		  paramItemOutputTable.ConLocEquation = "FACTOR";
		  if (factorData.ConversionFactor != 1.0D)
		  {
			paramItemOutputTable.QuantityEquation = factorData.Quantity + "/" + factorData.ConversionFactor;
		  }
		  else
		  {
			paramItemOutputTable.QuantityEquation = "" + factorData.Quantity;
		  }
		  paramItemOutputTable.SortOrder = Convert.ToInt32(b2++);
		  paramItemOutputTable.ResourceIds = factorData.BaseTableItem.ToString();
		  paramItemOutputTable.ParamItemTable = paramParamItemTable;
		  long = (long?)paramSession.save(paramItemOutputTable);
		  paramItemOutputTable = (ParamItemOutputTable)paramSession.load(typeof(ParamItemOutputTable), long);
		  paramParamItemTable.OutputSet.Add(paramItemOutputTable);
		}
		paramSession.update(paramParamItemTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private java.util.Map<String, java.util.List<Desktop.common.nomitech.common.migration.rsmeans.FactorData>> cacheFactors(org.hibernate.Session paramSession, java.io.File paramFile1, java.io.File paramFile2, String paramString) throws Exception
	  private IDictionary<string, IList<FactorData>> cacheFactors(Session paramSession, File paramFile1, File paramFile2, string paramString)
	  {
		Hashtable hashMap1 = new Hashtable();
		StreamReader bufferedReader = new StreamReader(paramFile2);
		int i = 0;
		Console.WriteLine("CACHING LINEITEMS...");
		while (true)
		{
		  string str1 = bufferedReader.ReadLine();
		  if (string.ReferenceEquals(str1, null))
		  {
			break;
		  }
		  string str2 = StringUtils.removeAllSpaces(str1.Substring(22, 12));
		  BaseTableItem baseTableItem = loadOrCreateBaseTableItem(paramSession, str1, paramString);
		  hashMap1[str2] = baseTableItem.clone();
		  if (this.PROGRESS_SHOW_INTERVAL != -1 && i % this.PROGRESS_SHOW_INTERVAL == 0)
		  {
			Console.WriteLine(paramString + " PROCESSED: " + i);
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
		Hashtable hashMap2 = new Hashtable();
		bufferedReader = new StreamReader(paramFile1);
		i = 0;
		Console.WriteLine("CACHING FACTORS...");
		while (true)
		{
		  string str = bufferedReader.ReadLine();
		  if (string.ReferenceEquals(str, null))
		  {
			break;
		  }
		  FactorData factorData = new FactorData(str);
		  factorData.BaseTableItem = (BaseTableItem)hashMap1[factorData.Mf04LineNumber];
		  System.Collections.IList list = (System.Collections.IList)hashMap2[factorData.AssemblyNumber];
		  if (list == null)
		  {
			list = new List<object>();
			hashMap2[factorData.AssemblyNumber] = list;
		  }
		  list.Add(factorData);
		}
		Console.WriteLine("STORED FACTORS " + hashMap2.Count);
		bufferedReader.Close();
		return hashMap2;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private nomitech.common.base.BaseTableItem loadOrCreateBaseTableItem(org.hibernate.Session paramSession, String paramString1, String paramString2) throws Exception
	  private BaseTableItem loadOrCreateBaseTableItem(Session paramSession, string paramString1, string paramString2)
	  {
		string str1 = StringUtils.removeAllSpaces(paramString1.Substring(12, 10));
		double d1 = (Convert.ToDouble(StringUtils.removeAllSpaces(paramString1.Substring(348, 12))));
		double d2 = (Convert.ToDouble(StringUtils.removeAllSpaces(paramString1.Substring(384, 12))));
		string str2 = StringUtils.removeSpacesFromEnd(paramString1.Substring(299, 5)).ToUpper();
		if (!this.USE_COST_BOOK_DUPLICATES)
		{
		  string str = null;
		  str = (string)this.DISTINCT_VALUES_MAP[str1 + d2];
		  if (!string.ReferenceEquals(str, null))
		  {
			return loadBaseTableItem(paramSession, str.ToString(), paramString2);
		  }
		}
		string str3 = StringUtils.removeAllSpaces(paramString1.Substring(22, 12));
		string str4 = StringUtils.proper(StringUtils.proper(StringUtils.removeSpacesFromEnd(paramString1.Substring(34, 255))));
		double d3 = (Convert.ToDouble(StringUtils.removeAllSpaces(paramString1.Substring(289, 10))));
		double d4 = (Convert.ToDouble(StringUtils.removeAllSpaces(paramString1.Substring(304, 12))));
		double d5 = (Convert.ToDouble(StringUtils.removeAllSpaces(paramString1.Substring(316, 12))));
		string str5 = StringUtils.removeSpacesFromEnd(paramString1.Substring(328, 8));
		double d6 = (Convert.ToDouble(StringUtils.removeAllSpaces(paramString1.Substring(336, 12))));
		double d7 = (Convert.ToDouble(StringUtils.removeAllSpaces(paramString1.Substring(360, 12))));
		double d8 = (Convert.ToDouble(StringUtils.removeAllSpaces(paramString1.Substring(372, 12))));
		GroupCode groupCode = (GroupCode)this.masterFormat04Map[str3.Substring(0, 8)];
		string str6 = getCostBookForFile(paramString2);
		SubcontractorTable subcontractorTable = null;
		MaterialTable materialTable = null;
		if (d6 != 0.0D)
		{
		  materialTable = saveOrUpdateMaterialTable(paramSession, groupCode, str3, str4, d6, str5, str1, str6, paramString2);
		  subcontractorTable = materialTable;
		}
		if (d5 != 0.0D || !str2.Equals(""))
		{
		  AssemblyTable assemblyTable = saveOrUpdateAssemblyTable(paramSession, groupCode, str3, str4, d5, d4, str2, d3, str5, str1, materialTable, getLaborCacheForFile(paramString2), str6, d2, paramString2);
		}
		else if (d6 == 0.0D)
		{
		  subcontractorTable = saveOrUpdateSubcontractorTable(paramSession, groupCode, str3, str4, d8, d2 - d8, str5, str1, str6, paramString2);
		}
		BaseTableItem baseTableItem = new BaseTableItem(subcontractorTable, false);
		if (!this.USE_COST_BOOK_DUPLICATES)
		{
		  this.DISTINCT_VALUES_MAP[str1 + d2] = baseTableItem.ToString();
		}
		return baseTableItem;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private nomitech.common.base.BaseTableItem loadBaseTableItem(org.hibernate.Session paramSession, String paramString1, String paramString2) throws Exception
	  private BaseTableItem loadBaseTableItem(Session paramSession, string paramString1, string paramString2)
	  {
		BaseTableItem baseTableItem = (BaseTableItem)BaseTableItem.loadItems(paramSession, new string[] {paramString1}, false)[0];
		if (baseTableItem.BaseTable is AssemblyTable)
		{
		  AssemblyTable assemblyTable = (AssemblyTable)baseTableItem.BaseTable;
		  if (assemblyTable.AccessRights.IndexOf(paramString2, StringComparison.Ordinal) == -1)
		  {
			assemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), assemblyTable.Id);
			assemblyTable.AccessRights = assemblyTable.AccessRights + "," + paramString2;
			paramSession.update(assemblyTable);
		  }
		}
		if (baseTableItem.BaseTable is MaterialTable)
		{
		  MaterialTable materialTable = (MaterialTable)baseTableItem.BaseTable;
		  if (materialTable.AccessRights.IndexOf(paramString2, StringComparison.Ordinal) == -1)
		  {
			materialTable = (MaterialTable)paramSession.load(typeof(MaterialTable), materialTable.Id);
			materialTable.AccessRights = materialTable.AccessRights + "," + paramString2;
			paramSession.update(materialTable);
		  }
		}
		if (baseTableItem.BaseTable is EquipmentTable)
		{
		  EquipmentTable equipmentTable = (EquipmentTable)baseTableItem.BaseTable;
		  if (equipmentTable.AccessRights.IndexOf(paramString2, StringComparison.Ordinal) == -1)
		  {
			equipmentTable = (EquipmentTable)paramSession.load(typeof(EquipmentTable), equipmentTable.Id);
			equipmentTable.AccessRights = equipmentTable.AccessRights + "," + paramString2;
			paramSession.update(equipmentTable);
		  }
		}
		if (baseTableItem.BaseTable is SubcontractorTable)
		{
		  SubcontractorTable subcontractorTable = (SubcontractorTable)baseTableItem.BaseTable;
		  if (subcontractorTable.AccessRights.IndexOf(paramString2, StringComparison.Ordinal) == -1)
		  {
			subcontractorTable = (SubcontractorTable)paramSession.load(typeof(SubcontractorTable), subcontractorTable.Id);
			subcontractorTable.AccessRights = subcontractorTable.AccessRights + "," + paramString2;
			paramSession.update(subcontractorTable);
		  }
		}
		return baseTableItem;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private org.hibernate.Transaction saveUnitCostData(org.hibernate.Session paramSession, String paramString1, String paramString2) throws Exception
	  private Transaction saveUnitCostData(Session paramSession, string paramString1, string paramString2)
	  {
		File file = new File(this.unitCostDataFolder + File.separator + paramString1 + File.separator + paramString2 + "2014" + ".SEQ");
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
		  double d2 = (Convert.ToDouble(StringUtils.removeAllSpaces(str1.Substring(384, 12))));
		  if (!this.USE_COST_BOOK_DUPLICATES && !paramString2.StartsWith("METR", StringComparison.Ordinal))
		  {
			string str = null;
			str = (string)this.DISTINCT_VALUES_MAP[str2 + d2];
			if (!string.ReferenceEquals(str, null))
			{
			  loadBaseTableItem(paramSession, str.ToString(), paramString2);
			  continue;
			}
		  }
		  string str4 = StringUtils.removeAllSpaces(str1.Substring(22, 12));
		  string str5 = StringUtils.proper(StringUtils.proper(StringUtils.removeSpacesFromEnd(str1.Substring(34, 255))));
		  double d3 = (Convert.ToDouble(StringUtils.removeAllSpaces(str1.Substring(289, 10))));
		  double d4 = (Convert.ToDouble(StringUtils.removeAllSpaces(str1.Substring(304, 12))));
		  double d5 = (Convert.ToDouble(StringUtils.removeAllSpaces(str1.Substring(316, 12))));
		  string str6 = StringUtils.removeSpacesFromEnd(str1.Substring(328, 8));
		  double d6 = (Convert.ToDouble(StringUtils.removeAllSpaces(str1.Substring(336, 12))));
		  double d7 = (Convert.ToDouble(StringUtils.removeAllSpaces(str1.Substring(360, 12))));
		  double d8 = (Convert.ToDouble(StringUtils.removeAllSpaces(str1.Substring(372, 12))));
		  GroupCode groupCode = (GroupCode)this.masterFormat04Map[str4.Substring(0, 8)];
		  string str7 = getCostBookForFile(paramString2);
		  if (groupCode == null)
		  {
			Console.WriteLine("\n I COULD NOT FIND A GROUP CODE FOR: " + str4 + " or " + str4.Substring(0, 8));
			continue;
		  }
		  MaterialTable materialTable = null;
		  SubcontractorTable subcontractorTable = null;
		  if (d6 != 0.0D)
		  {
			materialTable = saveOrUpdateMaterialTable(paramSession, groupCode, str4, str5, d6, str6, str2, str7, paramString2);
			subcontractorTable = materialTable;
		  }
		  if (d5 != 0.0D || !str3.Equals(""))
		  {
			AssemblyTable assemblyTable = saveOrUpdateAssemblyTable(paramSession, groupCode, str4, str5, d5, d4, str3, d3, str6, str2, materialTable, map, str7, d2, paramString2);
		  }
		  if (d6 == 0.0D)
		  {
			subcontractorTable = saveOrUpdateSubcontractorTable(paramSession, groupCode, str4, str5, d8, d2 - d8, str6, str2, str7, paramString2);
		  }
		  if (subcontractorTable == null)
		  {
			Console.WriteLine("I GOT NULL result for line:\n" + str1 + "\n" + d6 + "," + d1 + "," + d7 + "," + d5 + "," + str3);
		  }
		  else if (!this.USE_COST_BOOK_DUPLICATES && !paramString2.StartsWith("METR", StringComparison.Ordinal))
		  {
			this.DISTINCT_VALUES_MAP[str2 + d2] = (new BaseTableItem(subcontractorTable, false)).ToString();
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
		File file = new File(this.laborCrewFolder + File.separator + "EQM" + "2014" + ".SEQ");
		if (!RSMeansUOMConverter.CONVERT_TO_METRIC)
		{
		  file = new File(this.laborCrewFolder + File.separator + "EQ" + "2014" + ".SEQ");
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
		  string str3 = StringUtils.removeSpacesFromEnd(str1.Substring(12, 10));
		  string str4 = StringUtils.removeSpacesFromEnd(str1.Substring(34, 80));
		  string str5 = StringUtils.removeSpacesFromEnd(str1.Substring(114, 8));
		  double d1 = (Convert.ToDouble(StringUtils.removeSpacesFromEnd(str1.Substring(122, 12))));
		  double d2 = (Convert.ToDouble(StringUtils.removeSpacesFromEnd(str1.Substring(134, 12))));
		  double d3 = (Convert.ToDouble(StringUtils.removeSpacesFromEnd(str1.Substring(146, 12))));
		  double d4 = (Convert.ToDouble(StringUtils.removeSpacesFromEnd(str1.Substring(158, 12))));
		  double d5 = (Convert.ToDouble(StringUtils.removeSpacesFromEnd(str1.Substring(170, 2))));
		  GroupCode groupCode = checkAndGetCSI(str2, str4, paramSession);
		  if (str5.Equals(""))
		  {
			continue;
		  }
		  saveOrUpdateEquipmentTable(paramSession, groupCode, str2, str3, str4, ", daily", ", including " + d1 + " hourly operating cost, CREW EQUIP COST:" + d5, d2 + d1 * 8.0D, "DAY");
		  saveOrUpdateEquipmentTable(paramSession, groupCode, str2, str3, str4, ", weekly", ", including " + d1 + " hourly operating cost, CREW EQUIP COST:" + d5, d3 + d1 * 8.0D * 5.0D, "WEEK");
		  saveOrUpdateEquipmentTable(paramSession, groupCode, str2, str3, str4, ", monthly", ", including " + d1 + " hourly operating cost, CREW EQUIP COST:" + d5, d4 + d1 * 8.0D * 5.0D * 4.0D, "MONTH");
		}
		bufferedReader.Close();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private nomitech.common.db.local.AssemblyTable saveOrUpdateAssemblyTable(org.hibernate.Session paramSession, nomitech.common.base.GroupCode paramGroupCode, String paramString1, String paramString2, double paramDouble1, double paramDouble2, String paramString3, double paramDouble3, String paramString4, String paramString5, nomitech.common.db.local.MaterialTable paramMaterialTable, java.util.Map<String, Desktop.common.nomitech.common.migration.rsmeans.RSMeansLaborItem> paramMap, String paramString6, double paramDouble4, String paramString7) throws Exception
	  private AssemblyTable saveOrUpdateAssemblyTable(Session paramSession, GroupCode paramGroupCode, string paramString1, string paramString2, double paramDouble1, double paramDouble2, string paramString3, double paramDouble3, string paramString4, string paramString5, MaterialTable paramMaterialTable, IDictionary<string, RSMeansLaborItem> paramMap, string paramString6, double paramDouble4, string paramString7)
	  {
		AssemblyTable assemblyTable = BlankResourceInitializer.createBlankAssembly(null);
		string str = RSMeansUOMConverter.convertImperialToMetricUnit(paramString4);
		if (string.ReferenceEquals(str, null))
		{
		  throw new Exception("FATAL: UNIT WAS NULL FOR " + paramString4 + ". AND ACCT " + paramString1);
		}
		assemblyTable.ItemCode = paramString5;
		assemblyTable.PublishedRevisionCode = paramString5;
		assemblyTable.Title = StringUtils.makeShortTitle(paramString2);
		assemblyTable.GroupCode = "";
		assemblyTable.GekCode = "";
		assemblyTable.ExtraCode1 = paramGroupCode.ToString();
		assemblyTable.Keywords = getFullMasterFormat(paramGroupCode.getGroupCode());
		assemblyTable.ExtraCode2 = "";
		assemblyTable.ExtraCode3 = "";
		assemblyTable.ExtraCode4 = "";
		assemblyTable.ExtraCode5 = "";
		assemblyTable.ExtraCode6 = "";
		assemblyTable.ExtraCode7 = "";
		assemblyTable.ExtraCode8 = "";
		assemblyTable.ExtraCode9 = "";
		assemblyTable.ExtraCode10 = "";
		assemblyTable.Unit = str;
		assemblyTable.EditorId = "rsmeans";
		assemblyTable.StateProvince = "";
		assemblyTable.Country = "US";
		assemblyTable.Currency = "USD";
		assemblyTable.Productivity = RSMeansUOMConverter.convertImperialToMetricInverseRate(paramString4, new BigDecimalFixed(paramDouble2 / 8.0D));
		assemblyTable.Project = "";
		assemblyTable.PublishedRate = RSMeansUOMConverter.convertImperialToMetricRate(paramString4, new BigDecimalFixed(paramDouble4));
		assemblyTable.PublishedRevisionCode = paramString5;
		assemblyTable.Notes = "MF12: " + paramString1;
		assemblyTable.Description = paramString2 + ", SK: " + paramString5 + ", MF12: " + paramString1 + ", CB: " + paramString6 + getUnitCostReferenceString(paramGroupCode.getGroupCode()) + getUnitCostGraphicString(paramString1);
		assemblyTable.Virtual = false;
		assemblyTable.VirtualEquipment = false;
		assemblyTable.VirtualSubcontractor = false;
		assemblyTable.VirtualLabor = false;
		assemblyTable.VirtualMaterial = false;
		assemblyTable.VirtualConsumable = false;
		assemblyTable.LastUpdate = this.lastUpdate;
		assemblyTable.BimMaterial = "";
		assemblyTable.BimType = "";
		assemblyTable.Quantity = BigDecimalMath.ZERO;
		assemblyTable.Accuracy = "enum.quotation.accuracy.estimated";
		assemblyTable.CreateDate = assemblyTable.LastUpdate;
		assemblyTable.CreateUserId = "rsmeans";
		assemblyTable.AssemblyEquipmentSet = new HashSet<object>();
		assemblyTable.AssemblySubcontractorSet = new HashSet<object>();
		assemblyTable.AssemblyLaborSet = new HashSet<object>();
		assemblyTable.AssemblyMaterialSet = new HashSet<object>();
		assemblyTable.AssemblyConsumableSet = new HashSet<object>();
		assemblyTable.AccessRights = paramString7;
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
			  if (rSMeansLaborItem == null)
			  {
				Console.WriteLine("COULD NOT FIND CREW FOR: " + rSMeansCrewItem.Code + ". or " + rSMeansCrewItem.Code.ToUpper() + ".");
				Console.WriteLine("These are all the keys: ");
				foreach (string str1 in paramMap.Keys)
				{
				  Console.WriteLine("Key = " + str1);
				}
			  }
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
			  assemblyLaborTable.Factor2 = new BigDecimalFixed(paramDouble3);
			  assemblyLaborTable.Factor3 = BigDecimalMath.ONE;
			  assemblyLaborTable.ExchangeRate = BigDecimalMath.ONE;
			  assemblyLaborTable.QuantityPerUnit = BigDecimalMath.ONE;
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
			assemblyEquipmentTable.ExchangeRate = BigDecimalMath.ONE;
			assemblyEquipmentTable.QuantityPerUnit = BigDecimalMath.ONE;
			assemblyEquipmentTable.QuantityPerUnitFormula = "";
			assemblyEquipmentTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
			if (this.USE_O_AND_P)
			{
			  assemblyEquipmentTable.Factor3 = new BigDecimalFixed("1.1");
			}
			else
			{
			  assemblyEquipmentTable.Factor3 = new BigDecimalFixed("1");
			}
			assemblyEquipmentTable.LocalFactor = BigDecimalMath.ONE;
			assemblyEquipmentTable.LocalCountry = "";
			assemblyEquipmentTable.LocalStateProvince = "";
			assemblyEquipmentTable.EnergyPrice = BigDecimalMath.ZERO;
			assemblyEquipmentTable.FuelRate = BigDecimalMath.ZERO;
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
			assemblyMaterialTable.Factor1 = new BigDecimalFixed("1");
		  }
		  assemblyMaterialTable.Factor2 = new BigDecimalFixed("1");
		  assemblyMaterialTable.Factor3 = new BigDecimalFixed("1");
		  assemblyMaterialTable.QuantityPerUnit = BigDecimalMath.ONE;
		  assemblyMaterialTable.QuantityPerUnitFormula = "";
		  assemblyMaterialTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
		  assemblyMaterialTable.LastUpdate = assemblyTable.LastUpdate;
		  assemblyMaterialTable.LocalFactor = BigDecimalMath.ONE;
		  assemblyMaterialTable.LocalCountry = "";
		  assemblyMaterialTable.LocalStateProvince = "";
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
		  assemblyTable.recalculate();
		  paramSession.saveOrUpdate(assemblyTable);
		}
		return assemblyTable;
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
//ORIGINAL LINE: private nomitech.common.db.local.ParamItemTable saveOrUpdateParamItemTable(org.hibernate.Session paramSession, nomitech.common.base.GroupCode paramGroupCode, String paramString1, String paramString2, String paramString3, double paramDouble1, double paramDouble2, double paramDouble3, String paramString4, String paramString5) throws Exception
	  private ParamItemTable saveOrUpdateParamItemTable(Session paramSession, GroupCode paramGroupCode, string paramString1, string paramString2, string paramString3, double paramDouble1, double paramDouble2, double paramDouble3, string paramString4, string paramString5)
	  {
		null = BlankResourceInitializer.createBlankParamItem(null);
		null.ItemCode = paramString1;
		null.Title = StringUtils.makeShortTitle(paramString2);
		string str1 = RSMeansUOMConverter.convertImperialToMetricUnit(paramString3);
		if (string.ReferenceEquals(str1, null))
		{
		  throw new Exception("FATAL: UNIT WAS NULL FOR " + paramString3 + ". AND UNIFORMAT II " + paramString1);
		}
		string str2 = paramString1.Substring(0, 8);
		null.SampleRate = new BigDecimalFixed("" + paramDouble3);
		null.Variable = "";
		null.GroupName = "";
		null.Icon = "rsmeans";
		null.CostModel = false;
		null.GroupCode = "";
		null.GekCode = "";
		null.ExtraCode1 = "";
		null.ExtraCode2 = "";
		null.ExtraCode3 = paramGroupCode.ToString();
		null.Keywords = getFullUnitFormatII(paramGroupCode.getGroupCode());
		null.ExtraCode4 = "";
		null.ExtraCode5 = "";
		null.ExtraCode6 = "";
		null.ExtraCode7 = "";
		null.ExtraCode8 = "";
		null.ExtraCode9 = "";
		null.ExtraCode10 = "";
		null.Unit = str1;
		null.EditorId = "rsmeans";
		null.AccessRights = paramString5;
		null.Notes = "UNIFORMAT II: " + paramString1;
		null.Description = paramString2 + ", UNIFORMAT II: " + paramString1 + ", CB: " + paramString4 + getAssembliesReferenceString(str2) + getAssembliesGraphicString(str2);
		null.LastUpdate = this.lastUpdate;
		null.CreateDate = this.lastUpdate;
		null.CreateUserId = "rsmeans";
		long? long = null.ParamitemId;
		if (long == null)
		{
		  long = (long?)paramSession.save(null);
		}
		else
		{
		  paramSession.update(null);
		}
		return (ParamItemTable)DatabaseDBUtil.loadBulk(typeof(ParamItemTable), new long?[] {long})[0];
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private nomitech.common.db.local.SubcontractorTable saveOrUpdateSubcontractorTable(org.hibernate.Session paramSession, nomitech.common.base.GroupCode paramGroupCode, String paramString1, String paramString2, double paramDouble1, double paramDouble2, String paramString3, String paramString4, String paramString5, String paramString6) throws Exception
	  private SubcontractorTable saveOrUpdateSubcontractorTable(Session paramSession, GroupCode paramGroupCode, string paramString1, string paramString2, double paramDouble1, double paramDouble2, string paramString3, string paramString4, string paramString5, string paramString6)
	  {
		null = BlankResourceInitializer.createBlankSubcontractor(null);
		null.ItemCode = paramString4;
		null.Title = StringUtils.makeShortTitle(paramString2);
		string str = RSMeansUOMConverter.convertImperialToMetricUnit(paramString3);
		if (string.ReferenceEquals(str, null))
		{
		  throw new Exception("FATAL: UNIT WAS NULL FOR " + paramString3 + ". AND MF04 " + paramString1);
		}
		null.GroupCode = "";
		null.GekCode = "";
		null.ExtraCode1 = paramGroupCode.ToString();
		null.Keywords = getFullMasterFormat(paramGroupCode.getGroupCode());
		null.ExtraCode2 = "";
		null.ExtraCode3 = "";
		null.ExtraCode4 = "";
		null.ExtraCode5 = "";
		null.ExtraCode6 = "";
		null.ExtraCode7 = "";
		null.ExtraCode8 = "";
		null.ExtraCode9 = "";
		null.ExtraCode10 = "";
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
		null.Quantity = BigDecimalMath.ZERO;
		null.Notes = "MF12: " + paramString1;
		null.Description = paramString2 + ", SK: " + paramString4 + ", MF12: " + paramString1 + ", CB: " + paramString5 + getUnitCostReferenceString(paramGroupCode.getGroupCode()) + getUnitCostGraphicString(paramString1);
		null.LastUpdate = this.lastUpdate;
		null.CreateDate = this.lastUpdate;
		null.CreateUserId = "rsmeans";
		null.AccessRights = paramString6;
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
//ORIGINAL LINE: private nomitech.common.db.local.MaterialTable saveOrUpdateMaterialTable(org.hibernate.Session paramSession, nomitech.common.base.GroupCode paramGroupCode, String paramString1, String paramString2, double paramDouble, String paramString3, String paramString4, String paramString5, String paramString6) throws Exception
	  private MaterialTable saveOrUpdateMaterialTable(Session paramSession, GroupCode paramGroupCode, string paramString1, string paramString2, double paramDouble, string paramString3, string paramString4, string paramString5, string paramString6)
	  {
		null = BlankResourceInitializer.createBlankMaterial(null);
		null.ItemCode = paramString4;
		null.Title = StringUtils.makeShortTitle(paramString2);
		string str = RSMeansUOMConverter.convertImperialToMetricUnit(paramString3);
		if (string.ReferenceEquals(str, null))
		{
		  throw new Exception("FATAL: UNIT WAS NULL FOR " + paramString3 + ". AND MF04 " + paramString1);
		}
		null.GroupCode = "";
		null.GekCode = "";
		null.ExtraCode1 = paramGroupCode.ToString();
		null.Keywords = getFullMasterFormat(paramGroupCode.getGroupCode());
		null.ExtraCode2 = "";
		null.ExtraCode3 = "";
		null.ExtraCode4 = "";
		null.ExtraCode5 = "";
		null.ExtraCode6 = "";
		null.ExtraCode7 = "";
		null.ExtraCode8 = "";
		null.ExtraCode9 = "";
		null.ExtraCode10 = "";
		null.Unit = str;
		null.EditorId = "rsmeans";
		null.Weight = BigDecimalMath.ZERO;
		null.WeightUnit = "LB";
		null.RawMaterial = "enum.rm.unspecified";
		null.RawMaterialReliance = new BigDecimalFixed("100");
		null.Rate = RSMeansUOMConverter.convertImperialToMetricRate(paramString3, new BigDecimalFixed(paramDouble));
		null.Project = "";
		null.Country = "US";
		null.StateProvince = "USA AVERAGE";
		null.Currency = "USD";
		null.Notes = "MF12: " + paramString1;
		null.Description = paramString2 + ", SK: " + paramString4 + ", MF12: " + paramString1 + ", CB: " + paramString5 + getUnitCostReferenceString(paramGroupCode.getGroupCode()) + getUnitCostGraphicString(paramString1);
		null.LastUpdate = this.lastUpdate;
		null.Accuracy = "enum.quotation.accuracy.estimated";
		null.Inclusion = "enum.inclusion.matonly";
		null.Quantity = BigDecimalMath.ZERO;
		null.DistanceToSite = BigDecimalMath.ZERO;
		null.DistanceUnit = "MILE";
		null.ShipmentRate = BigDecimalMath.ZERO;
		null.FabricationRate = BigDecimalMath.ZERO;
		null.TotalRate = null.Rate;
		null.CreateDate = this.lastUpdate;
		null.CreateUserId = "rsmeans";
		null.BimMaterial = "";
		null.BimType = "";
		null.AccessRights = paramString6;
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
//ORIGINAL LINE: private nomitech.common.db.local.EquipmentTable saveOrUpdateEquipmentTable(org.hibernate.Session paramSession, nomitech.common.base.GroupCode paramGroupCode, String paramString1, String paramString2, String paramString3, String paramString4, String paramString5, double paramDouble, String paramString6) throws Exception
	  private EquipmentTable saveOrUpdateEquipmentTable(Session paramSession, GroupCode paramGroupCode, string paramString1, string paramString2, string paramString3, string paramString4, string paramString5, double paramDouble, string paramString6)
	  {
		null = BlankResourceInitializer.createBlankEquipment(null);
		null.ItemCode = paramString2;
		null.Title = paramString3 + paramString4;
		null.Model = "";
		null.Make = "";
		null.Currency = "USD";
		null.Country = "US";
		null.StateProvince = "USA AVERAGE";
		null.GroupCode = "";
		null.GekCode = "";
		null.ExtraCode1 = paramGroupCode.ToString();
		null.Keywords = getFullMasterFormat(paramGroupCode.getGroupCode());
		null.ExtraCode2 = "";
		null.ExtraCode3 = "";
		null.ExtraCode4 = "";
		null.ExtraCode5 = "";
		null.ExtraCode6 = "";
		null.ExtraCode7 = "";
		null.ExtraCode8 = "";
		null.ExtraCode9 = "";
		null.ExtraCode10 = "";
		null.EditorId = "rsmeans";
		string str = RSMeansUOMConverter.convertImperialToMetricUnit(paramString6);
		if (string.ReferenceEquals(str, null))
		{
		  throw new Exception("FATAL: UNIT WAS NULL FOR " + paramString6 + ". AND MF12 " + paramString1);
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
		if (paramString3.ToLower().IndexOf("diesel", StringComparison.Ordinal) != -1)
		{
		  null.FuelType = "DIESEL";
		}
		else if (paramString3.ToLower().IndexOf("gas", StringComparison.Ordinal) != -1)
		{
		  null.FuelType = "PETROL";
		}
		else if (paramString3.ToLower().IndexOf("electric", StringComparison.Ordinal) != -1)
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
		null.InitAquasitionPrice = BigDecimalMath.ZERO;
		null.InterestRate = new BigDecimalFixed("0.065");
		null.LubricatesRate = BigDecimalMath.ZERO;
		null.TiresRate = BigDecimalMath.ZERO;
		null.FuelConsumption = BigDecimalMath.ZERO;
		null.SparePartsRate = BigDecimalMath.ZERO;
		null.ReservationRate = RSMeansUOMConverter.convertImperialToMetricRate(paramString6, new BigDecimalFixed(paramDouble));
		null.DepreciationRate = BigDecimalMath.ZERO;
		null.FuelRate = BigDecimalMath.ZERO;
		null.TotalRate = RSMeansUOMConverter.convertImperialToMetricRate(paramString6, new BigDecimalFixed(paramDouble));
		null.Notes = "MF12: " + paramString1;
		null.Description = paramString3 + paramString4 + paramString5 + ", SK:" + paramString2 + ", MF12: " + paramString1 + getUnitCostReferenceString(paramGroupCode.getGroupCode()) + getUnitCostGraphicString(paramString1);
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

	  private string getFullUnitFormatII(string paramString)
	  {
		List<object> arrayList = new List<object>();
		while (paramString.IndexOf(".", StringComparison.Ordinal) != -1)
		{
		  paramString = paramString.Substring(0, paramString.LastIndexOf(".", StringComparison.Ordinal));
		  GroupCode groupCode = (GroupCode)this.uniFormatMap[StringUtils.replaceAll(paramString, ".", "")];
		  if (groupCode == null)
		  {
			Console.WriteLine("COULD NODE FIND PARENT CODE OF: " + paramString);
			continue;
		  }
		  arrayList.Add(groupCode);
		}
		StringBuilder stringBuffer = new StringBuilder();
		for (int i = arrayList.Count - 1; i >= 0; i--)
		{
		  stringBuffer = stringBuffer.Append(((GroupCode)arrayList[i]).Title);
		  if (i >= 0)
		  {
			stringBuffer = stringBuffer.Append(",");
		  }
		}
		return stringBuffer.ToString();
	  }

	  private string getFullMasterFormat(string paramString)
	  {
		string str1 = (paramString[0] + paramString[1]) + "000000";
		string str2 = (paramString[0] + paramString[1] + paramString[2] + paramString[3]) + "0000";
		string str3 = (paramString[0] + paramString[1] + paramString[2] + paramString[3] + paramString[4] + paramString[5]) + "00";
		string str4 = "" + paramString[0] + paramString[1] + paramString[2] + paramString[3] + paramString[4] + paramString[5] + paramString[6] + paramString[7];
		StringBuilder stringBuffer = new StringBuilder();
		stringBuffer.Append(str1 + "," + str2 + "," + str3 + "," + str4);
		return stringBuffer.ToString();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void migrateFromFolder(String paramString) throws Exception
	  public static void migrateFromFolder(string paramString)
	  {
		  new RSMeansMigrationUtil2014(paramString);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\RSMeansMigrationUtil2014.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}