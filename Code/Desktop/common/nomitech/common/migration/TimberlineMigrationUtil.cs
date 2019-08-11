using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Desktop.common.nomitech.common.migration
{
	using GroupCode = nomitech.common.@base.GroupCode;
	using ResourceToAssignmentTable = nomitech.common.@base.ResourceToAssignmentTable;
	using AssemblyConsumableTable = nomitech.common.db.local.AssemblyConsumableTable;
	using AssemblyEquipmentTable = nomitech.common.db.local.AssemblyEquipmentTable;
	using AssemblyLaborTable = nomitech.common.db.local.AssemblyLaborTable;
	using AssemblyMaterialTable = nomitech.common.db.local.AssemblyMaterialTable;
	using AssemblySubcontractorTable = nomitech.common.db.local.AssemblySubcontractorTable;
	using AssemblyTable = nomitech.common.db.local.AssemblyTable;
	using ConsumableTable = nomitech.common.db.local.ConsumableTable;
	using EquipmentTable = nomitech.common.db.local.EquipmentTable;
	using ExtraCode2Table = nomitech.common.db.local.ExtraCode2Table;
	using ExtraCode4Table = nomitech.common.db.local.ExtraCode4Table;
	using GekCodeTable = nomitech.common.db.local.GekCodeTable;
	using GroupCodeTable = nomitech.common.db.local.GroupCodeTable;
	using LaborTable = nomitech.common.db.local.LaborTable;
	using MaterialTable = nomitech.common.db.local.MaterialTable;
	using SubcontractorTable = nomitech.common.db.local.SubcontractorTable;
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using BlankResourceInitializer = nomitech.common.expr.boqitem.BlankResourceInitializer;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	using StringUtils = nomitech.common.util.StringUtils;
	using HSSFCell = org.apache.poi.hssf.usermodel.HSSFCell;
	using HSSFRow = org.apache.poi.hssf.usermodel.HSSFRow;
	using HSSFSheet = org.apache.poi.hssf.usermodel.HSSFSheet;
	using HSSFWorkbook = org.apache.poi.hssf.usermodel.HSSFWorkbook;
	using POIFSFileSystem = org.apache.poi.poifs.filesystem.POIFSFileSystem;
	using CellValue = org.apache.poi.ss.usermodel.CellValue;
	using FormulaEvaluator = org.apache.poi.ss.usermodel.FormulaEvaluator;
	using Session = org.hibernate.Session;

	public class TimberlineMigrationUtil
	{
	  private static readonly BigDecimalFixed HOURS_OF_DAY = new BigDecimalFixed("8");

	  private static readonly BigDecimalFixed HOURS_OF_WEEK = new BigDecimalFixed("40");

	  private static readonly BigDecimalFixed HOURS_OF_MONTH = new BigDecimalFixed("160");

	  private IDictionary<string, LaborTable> laborCache = new Hashtable();

	  private IDictionary<string, GroupCode> csiMap = new Hashtable();

	  private IDictionary<string, GroupCode> uniFormatMap = new Hashtable();

	  private IDictionary<string, GroupCode> dprPhaseMap = new Hashtable();

	  private IDictionary<string, GroupCode> cmicMap = new Hashtable();

	  private int rowsToCommit = 500;

	  private FormulaEvaluator o_evaluator;

	  private DateTime lastUpdate = DateTime.Now;

	  public TimberlineMigrationUtil(string paramString1, string paramString2, string paramString3, string paramString4)
	  {
		paramString1 = "C:\\DPR\\DB-SAVED\\MFL";
		paramString2 = "C:\\DPR\\DB-SAVED\\UNI";
		paramString3 = "C:\\DPR\\DB-SAVED\\CMiC.xls";
		paramString4 = "C:\\DPR\\DB-SAVED\\DPR Items DB.xls";
		Session session = DatabaseDBUtil.currentSession();
		session.beginTransaction();
		try
		{
		  Console.WriteLine("Starting Importing of Resources and Crews...");
		  session.Transaction.commit();
		  session.beginTransaction();
		  Console.WriteLine("PROCESSING CSI...");
		  loadCSI(session, paramString1);
		  session.Transaction.commit();
		  session.beginTransaction();
		  Console.WriteLine("PROCESSING UNI...");
		  loadUniFormat(session, paramString2);
		  session.Transaction.commit();
		  session.beginTransaction();
		  Console.WriteLine("PROCESSING CMIC...");
		  loadCmic(session, paramString3);
		  session.Transaction.commit();
		  session.beginTransaction();
		  Console.WriteLine("PROCESSING LINE ITEMS...");
		  loadLineItems(session, paramString4);
		  session.Transaction.commit();
		}
		catch (Exception exception)
		{
		  if (session.Transaction.Active)
		  {
			session.Transaction.rollback();
		  }
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		DatabaseDBUtil.closeSession();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private java.util.Map<String, nomitech.common.base.GroupCode> loadCSI(org.hibernate.Session paramSession, String paramString) throws Exception
	  private IDictionary<string, GroupCode> loadCSI(Session paramSession, string paramString)
	  {
		for (sbyte b = 1; b <= 3; b++)
		{
		  POIFSFileSystem pOIFSFileSystem = new POIFSFileSystem(new FileStream(paramString + b + ".xls", FileMode.Open, FileAccess.Read));
		  HSSFWorkbook hSSFWorkbook = new HSSFWorkbook(pOIFSFileSystem);
		  this.o_evaluator = hSSFWorkbook.CreationHelper.createFormulaEvaluator();
		  HSSFSheet hSSFSheet = hSSFWorkbook.getSheetAt(0);
		  int i = getRealNumberOfRows(hSSFSheet);
		  for (int j = 2; j < i; j++)
		  {
			if (j % this.rowsToCommit == 0)
			{
			  paramSession.Transaction.commit();
			  paramSession.Transaction.begin();
			  Console.WriteLine("Processing next 500...");
			}
			HSSFRow hSSFRow = hSSFSheet.getRow(j);
			string str = notNull(hSSFRow.getCell(0));
			if (!this.csiMap.ContainsKey(str))
			{
			  string str1 = str + "00";
			  string str2 = notNull(hSSFRow.getCell(1));
			  str1 = StringUtils.replaceAll(str1, ".", "");
			  int k = str2.LastIndexOf(" - ", StringComparison.Ordinal);
			  if (k != -1)
			  {
				str2 = str2.Substring(k + 3);
			  }
			  GroupCode groupCode = addGroupCode2(str1, str2);
			  this.csiMap[str] = groupCode;
			  paramSession.save(groupCode);
			  Console.WriteLine(str1 + " = " + str2);
			}
		  }
		  if (hSSFWorkbook != null)
		  {
			hSSFWorkbook.close();
		  }
		}
		return this.csiMap;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private java.util.Map<String, nomitech.common.base.GroupCode> loadUniFormat(org.hibernate.Session paramSession, String paramString) throws Exception
	  private IDictionary<string, GroupCode> loadUniFormat(Session paramSession, string paramString)
	  {
		for (sbyte b = 1; b <= 3; b++)
		{
		  POIFSFileSystem pOIFSFileSystem = new POIFSFileSystem(new FileStream(paramString + b + ".xls", FileMode.Open, FileAccess.Read));
		  HSSFWorkbook hSSFWorkbook = new HSSFWorkbook(pOIFSFileSystem);
		  this.o_evaluator = hSSFWorkbook.CreationHelper.createFormulaEvaluator();
		  HSSFSheet hSSFSheet = hSSFWorkbook.getSheetAt(0);
		  int i = getRealNumberOfRows(hSSFSheet);
		  for (int j = 2; j < i; j++)
		  {
			if (j % this.rowsToCommit == 0)
			{
			  paramSession.Transaction.commit();
			  paramSession.Transaction.begin();
			  Console.WriteLine("Processing next 500...");
			}
			HSSFRow hSSFRow = hSSFSheet.getRow(j);
			string str = notNull(hSSFRow.getCell(0));
			if (!this.csiMap.ContainsKey(str))
			{
			  string str1 = str;
			  if (b == 2)
			  {
				str1 = str1[0] + "." + str1.Substring(1, str1.Length - 1);
			  }
			  else if (b == 3)
			  {
				str1 = str1[0] + "." + str1.Substring(1, 2) + "." + str1.Substring(4, str1.Length - 4);
			  }
			  string str2 = notNull(hSSFRow.getCell(1));
			  str1 = StringUtils.replaceAll(str1, ".", "");
			  int k = str2.LastIndexOf(" - ", StringComparison.Ordinal);
			  if (k != -1)
			  {
				str2 = str2.Substring(k + 3);
			  }
			  GroupCode groupCode = addGroupCode4(str1, str2);
			  this.uniFormatMap[str] = groupCode;
			  paramSession.save(groupCode);
			  Console.WriteLine(str1 + " = " + str2);
			}
		  }
		  if (hSSFWorkbook != null)
		  {
			hSSFWorkbook.close();
		  }
		}
		return this.uniFormatMap;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private java.util.Map<String, nomitech.common.base.GroupCode> loadCmic(org.hibernate.Session paramSession, String paramString) throws Exception
	  private IDictionary<string, GroupCode> loadCmic(Session paramSession, string paramString)
	  {
		POIFSFileSystem pOIFSFileSystem = new POIFSFileSystem(new FileStream(paramString, FileMode.Open, FileAccess.Read));
		HSSFWorkbook hSSFWorkbook = new HSSFWorkbook(pOIFSFileSystem);
		this.o_evaluator = hSSFWorkbook.CreationHelper.createFormulaEvaluator();
		HSSFSheet hSSFSheet = hSSFWorkbook.getSheetAt(0);
		int i = getRealNumberOfRows(hSSFSheet);
		for (int j = 2; j < i; j++)
		{
		  if (j % this.rowsToCommit == 0)
		  {
			paramSession.Transaction.commit();
			paramSession.Transaction.begin();
			Console.WriteLine("Processing next 500...");
		  }
		  HSSFRow hSSFRow = hSSFSheet.getRow(j);
		  string str1 = notNull(hSSFRow.getCell(0));
		  string str2 = str1.ToString();
		  string str3 = notNull(hSSFRow.getCell(1));
		  string str4 = notNull(hSSFRow.getCell(2));
		  str2 = StringUtils.replaceAll(str2, "-", ".");
		  int k = str3.LastIndexOf(" - ", StringComparison.Ordinal);
		  if (k != -1)
		  {
			str3 = str3.Substring(k + 3);
		  }
		  GroupCode groupCode = addGroupCode6(str2, str3, str4);
		  this.cmicMap[str1] = groupCode;
		  paramSession.save(groupCode);
		  Console.WriteLine(str1 + " = " + str3);
		}
		if (hSSFWorkbook != null)
		{
		  hSSFWorkbook.close();
		}
		return this.cmicMap;
	  }

	  private GroupCode addGroupCode1(string paramString1, string paramString2)
	  {
		GroupCodeTable groupCodeTable = new GroupCodeTable();
		groupCodeTable.GroupCode = paramString1;
		groupCodeTable.Title = paramString2;
		groupCodeTable.Notes = "";
		groupCodeTable.Unit = "";
		groupCodeTable.UnitFactor = BigDecimalMath.ONE;
		groupCodeTable.Unit = "";
		groupCodeTable.EditorId = "admin";
		groupCodeTable.Description = "";
		groupCodeTable.LastUpdate = this.lastUpdate;
		return groupCodeTable;
	  }

	  private GroupCode addGroupCode2(string paramString1, string paramString2)
	  {
		GekCodeTable gekCodeTable = new GekCodeTable();
		gekCodeTable.GroupCode = paramString1;
		gekCodeTable.Title = paramString2;
		gekCodeTable.Notes = "";
		gekCodeTable.Unit = "";
		gekCodeTable.UnitFactor = BigDecimalMath.ONE;
		gekCodeTable.Unit = "";
		gekCodeTable.EditorId = "admin";
		gekCodeTable.Description = "";
		gekCodeTable.LastUpdate = this.lastUpdate;
		return gekCodeTable;
	  }

	  private GroupCode addGroupCode4(string paramString1, string paramString2)
	  {
		ExtraCode2Table extraCode2Table = new ExtraCode2Table();
		extraCode2Table.GroupCode = paramString1;
		extraCode2Table.Title = paramString2;
		extraCode2Table.Notes = "";
		extraCode2Table.Unit = "";
		extraCode2Table.UnitFactor = BigDecimalMath.ONE;
		extraCode2Table.Unit = "";
		extraCode2Table.EditorId = "admin";
		extraCode2Table.Description = "";
		extraCode2Table.LastUpdate = this.lastUpdate;
		return extraCode2Table;
	  }

	  private GroupCode addGroupCode6(string paramString1, string paramString2, string paramString3)
	  {
		ExtraCode4Table extraCode4Table = new ExtraCode4Table();
		extraCode4Table.GroupCode = paramString1;
		extraCode4Table.Title = paramString2;
		extraCode4Table.Notes = "";
		extraCode4Table.Unit = toCorrectUnit(paramString3);
		extraCode4Table.UnitFactor = BigDecimalMath.ONE;
		extraCode4Table.EditorId = "admin";
		extraCode4Table.Description = "";
		extraCode4Table.LastUpdate = this.lastUpdate;
		return extraCode4Table;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadLineItems(org.hibernate.Session paramSession, String paramString) throws Exception
	  private void loadLineItems(Session paramSession, string paramString)
	  {
		POIFSFileSystem pOIFSFileSystem = new POIFSFileSystem(new FileStream(paramString, FileMode.Open, FileAccess.Read));
		HSSFWorkbook hSSFWorkbook = new HSSFWorkbook(pOIFSFileSystem);
		this.o_evaluator = hSSFWorkbook.CreationHelper.createFormulaEvaluator();
		HSSFSheet hSSFSheet = hSSFWorkbook.getSheetAt(0);
		Console.WriteLine("Loading Line Items...");
		int i = getRealNumberOfRows(hSSFSheet);
		string str1 = null;
		string str2 = null;
		GroupCodeTable groupCodeTable = null;
		for (int j = 1; j < i; j++)
		{
		  if (j % this.rowsToCommit == 0)
		  {
			paramSession.Transaction.commit();
			paramSession.Transaction.begin();
			Console.WriteLine("Processing next 500...");
		  }
		  HSSFRow hSSFRow = hSSFSheet.getRow(j);
		  string str3 = notNull(hSSFRow.getCell(0));
		  string str4 = notNull(hSSFRow.getCell(1));
		  string str5 = notNull(hSSFRow.getCell(2));
		  string str6 = notNull(hSSFRow.getCell(3));
		  if (!StringUtils.isNullOrBlank(str3))
		  {
			Console.WriteLine(str5 + " - " + str6);
			str1 = str3;
			str1 = StringUtils.replaceAll(str1, ".00000", "");
			GroupCode groupCode = addGroupCode1(str1, str6);
			this.dprPhaseMap[str5] = groupCode;
			paramSession.save(groupCode);
		  }
		  else if (!StringUtils.isNullOrBlank(str4))
		  {
			Console.WriteLine(str5 + " - " + str6);
			str2 = str4;
			GroupCode groupCode = addGroupCode1(str2, str6);
			this.dprPhaseMap[str5] = groupCode;
			long? long = (long?)paramSession.save(groupCode);
			groupCodeTable = (GroupCodeTable)groupCode;
			groupCodeTable.GroupCodeId = long;
		  }
		  else
		  {
			decimal bigDecimal1 = notNullBigDecimal(hSSFRow.getCell(4), 1.0D);
			string str7 = toCorrectUnit(notNull(hSSFRow.getCell(5)));
			string str8 = notNull(hSSFRow.getCell(6));
			decimal bigDecimal2 = notNullBigDecimal(hSSFRow.getCell(7), 0.0D);
			string str9 = toCorrectUnit(notNull(hSSFRow.getCell(8)));
			decimal bigDecimal3 = notNullBigDecimal(hSSFRow.getCell(9), 0.0D);
			string str10 = toCorrectUnit(notNull(hSSFRow.getCell(10)));
			decimal bigDecimal4 = notNullBigDecimal(hSSFRow.getCell(11), 0.0D);
			string str11 = notNull(hSSFRow.getCell(12)).ToUpper();
			decimal bigDecimal5 = notNullBigDecimal(hSSFRow.getCell(13), 0.0D);
			string str12 = toCorrectUnit(notNull(hSSFRow.getCell(14)));
			decimal bigDecimal6 = notNullBigDecimal(hSSFRow.getCell(15), 0.0D);
			decimal bigDecimal7 = notNullBigDecimal(hSSFRow.getCell(16), 1.0D);
			string str13 = toCorrectUnit(notNull(hSSFRow.getCell(17)));
			decimal bigDecimal8 = notNullBigDecimal(hSSFRow.getCell(18), 1.0D);
			string str14 = toCorrectUnit(notNull(hSSFRow.getCell(19)));
			decimal bigDecimal9 = notNullBigDecimal(hSSFRow.getCell(20), 0.0D);
			string str15 = toCorrectUnit(notNull(hSSFRow.getCell(21)));
			decimal bigDecimal10 = notNullBigDecimal(hSSFRow.getCell(22), 0.0D);
			decimal bigDecimal11 = notNullBigDecimal(hSSFRow.getCell(23), 0.0D);
			string str16 = toCorrectUnit(notNull(hSSFRow.getCell(24)));
			decimal bigDecimal12 = notNullBigDecimal(hSSFRow.getCell(25), 0.0D);
			string str17 = toCorrectUnit(notNull(hSSFRow.getCell(26)));
			decimal bigDecimal13 = notNullBigDecimal(hSSFRow.getCell(27), 0.0D);
			string str18 = toCorrectUnit(notNull(hSSFRow.getCell(28)));
			decimal bigDecimal14 = notNullBigDecimal(hSSFRow.getCell(29), 0.0D);
			string str19 = toCorrectUnit(notNull(hSSFRow.getCell(30)));
			decimal bigDecimal15 = notNullBigDecimal(hSSFRow.getCell(31), 0.0D);
			decimal bigDecimal16 = notNullBigDecimal(hSSFRow.getCell(32), 1.0D);
			string str20 = toCorrectUnit(notNull(hSSFRow.getCell(33)));
			decimal bigDecimal17 = notNullBigDecimal(hSSFRow.getCell(34), 0.0D);
			string str21 = toCorrectUnit(notNull(hSSFRow.getCell(35)));
			decimal bigDecimal18 = notNullBigDecimal(hSSFRow.getCell(36), 1.0D);
			string str22 = toCorrectUnit(notNull(hSSFRow.getCell(37)));
			decimal bigDecimal19 = notNullBigDecimal(hSSFRow.getCell(38), 0.0D);
			string str23 = toCorrectUnit(notNull(hSSFRow.getCell(39)));
			decimal bigDecimal20 = notNullBigDecimal(hSSFRow.getCell(40), 0.0D);
			decimal bigDecimal21 = notNullBigDecimal(hSSFRow.getCell(41), 0.0D);
			string str24 = toCorrectUnit(notNull(hSSFRow.getCell(42)));
			decimal bigDecimal22 = notNullBigDecimal(hSSFRow.getCell(43), 0.0D);
			string str25 = toCorrectUnit(notNull(hSSFRow.getCell(44)));
			decimal bigDecimal23 = notNullBigDecimal(hSSFRow.getCell(45), 0.0D);
			string str26 = toCorrectUnit(notNull(hSSFRow.getCell(46)));
			decimal bigDecimal24 = notNullBigDecimal(hSSFRow.getCell(47), 0.0D);
			string str27 = toCorrectUnit(notNull(hSSFRow.getCell(48)));
			decimal bigDecimal25 = notNullBigDecimal(hSSFRow.getCell(49), 0.0D);
			decimal bigDecimal26 = notNullBigDecimal(hSSFRow.getCell(50), 0.0D);
			string str28 = toCorrectUnit(notNull(hSSFRow.getCell(51)));
			decimal bigDecimal27 = notNullBigDecimal(hSSFRow.getCell(52), 0.0D);
			Console.WriteLine(str5 + " - " + str6 + " " + str7 + " " + bigDecimal1 + " " + str8 + " " + bigDecimal27);
			string str29 = notNull(hSSFRow.getCell(53));
			string str30 = notNull(hSSFRow.getCell(54));
			string str31 = notNull(hSSFRow.getCell(55));
			string str32 = notNull(hSSFRow.getCell(56));
			string str33 = notNull(hSSFRow.getCell(57));
			string str34 = notNull(hSSFRow.getCell(58));
			string str35 = notNull(hSSFRow.getCell(59));
			AssemblyTable assemblyTable = BlankResourceInitializer.createBlankAssembly(null);
			assemblyTable.PublishedRevisionCode = str5;
			assemblyTable.Title = str6;
			assemblyTable.Unit = str7;
			assemblyTable.Currency = "USD";
			assemblyTable.Country = "US";
			assemblyTable.Quantity = bigDecimal1;
			assemblyTable.LastUpdate = this.lastUpdate;
			assemblyTable.Description = "";
			assemblyTable.LastUpdate = this.lastUpdate;
			assemblyTable.CreateDate = this.lastUpdate;
			assemblyTable.CreateUserId = "admin";
			assemblyTable.EditorId = "admin";
			if (groupCodeTable != null)
			{
			  assemblyTable.GroupCode = groupCodeTable.ToString();
			}
			if (!StringUtils.isNullOrBlank(str32))
			{
			  assemblyTable.ExtraCode2 = ((GroupCode)this.uniFormatMap[str32]).ToString();
			}
			else if (!StringUtils.isNullOrBlank(str31))
			{
			  assemblyTable.ExtraCode2 = ((GroupCode)this.uniFormatMap[str31]).ToString();
			}
			else if (!StringUtils.isNullOrBlank(str30))
			{
			  assemblyTable.ExtraCode2 = ((GroupCode)this.uniFormatMap[str30]).ToString();
			}
			assemblyTable.ExtraCode3 = assemblyTable.ExtraCode2;
			if (!StringUtils.isNullOrBlank(str35) && this.csiMap.ContainsKey(str35))
			{
			  assemblyTable.GekCode = ((GroupCode)this.csiMap[str35]).ToString();
			}
			else if (!StringUtils.isNullOrBlank(str34) && this.csiMap.ContainsKey(str34))
			{
			  assemblyTable.GekCode = ((GroupCode)this.csiMap[str34]).ToString();
			}
			else if (!StringUtils.isNullOrBlank(str33) && this.csiMap.ContainsKey(str33))
			{
			  assemblyTable.GekCode = ((GroupCode)this.csiMap[str33]).ToString();
			}
			if (!StringUtils.isNullOrBlank(str29))
			{
			  if (this.cmicMap.ContainsKey(str29))
			  {
				assemblyTable.ExtraCode4 = ((GroupCode)this.cmicMap[str29]).ToString();
			  }
			  else
			  {
				Console.WriteLine("Not Found: " + str29);
			  }
			}
			assemblyTable.ExtraCode1 = assemblyTable.GekCode;
			assemblyTable.AssemblyEquipmentSet = new HashSet<object>();
			assemblyTable.AssemblySubcontractorSet = new HashSet<object>();
			assemblyTable.AssemblyLaborSet = new HashSet<object>();
			assemblyTable.AssemblyMaterialSet = new HashSet<object>();
			assemblyTable.AssemblyConsumableSet = new HashSet<object>();
			long? long = (long?)paramSession.save(assemblyTable.clone());
			assemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), long);
			if (!StringUtils.isNullOrBlank(str8))
			{
			  LaborTable laborTable = (LaborTable)this.laborCache[str8];
			  if (laborTable == null)
			  {
				laborTable = BlankResourceInitializer.createBlankLabor(null);
				laborTable.Title = str8;
				laborTable.Unit = "HOUR";
				laborTable.Rate = bigDecimal5;
				laborTable.IKA = BigDecimalMath.ZERO;
				laborTable.Currency = "USD";
				laborTable.Country = "US";
				laborTable.LastUpdate = this.lastUpdate;
				laborTable.CreateDate = this.lastUpdate;
				laborTable.CreateUserId = "admin";
				laborTable.EditorId = "admin";
				long = (long?)paramSession.save(laborTable.clone());
				laborTable.Id = long;
				this.laborCache[str8] = laborTable;
			  }
			  else
			  {
				laborTable = (LaborTable)paramSession.load(typeof(LaborTable), laborTable.Id);
			  }
			  if (BigDecimalMath.cmp(bigDecimal4, BigDecimalMath.ZERO) <= 0 && BigDecimalMath.cmp(bigDecimal2, BigDecimalMath.ZERO) > 0)
			  {
				bigDecimal4 = BigDecimalMath.div(BigDecimalMath.ONE, bigDecimal2);
			  }
			  laborTable = (LaborTable)paramSession.load(typeof(LaborTable), laborTable.Id);
			  AssemblyLaborTable assemblyLaborTable = new AssemblyLaborTable();
			  assemblyLaborTable.Factor1 = BigDecimalMath.ONE;
			  assemblyLaborTable.Factor2 = BigDecimalMath.ONE;
			  assemblyLaborTable.Factor3 = BigDecimalMath.ONE;
			  assemblyLaborTable.ExchangeRate = BigDecimalMath.ONE;
			  assemblyLaborTable.QuantityPerUnit = bigDecimal4;
			  assemblyLaborTable.QuantityPerUnitFormula = "";
			  assemblyLaborTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
			  assemblyLaborTable.LocalFactor = BigDecimalMath.ONE;
			  assemblyLaborTable.LocalCountry = "";
			  assemblyLaborTable.LocalStateProvince = "";
			  assemblyLaborTable.LastUpdate = assemblyTable.LastUpdate;
			  long = (long?)paramSession.save(assemblyLaborTable);
			  assemblyLaborTable.AssemblyLaborId = long;
			  assemblyTable.AssemblyLaborSet.Add(assemblyLaborTable);
			  paramSession.saveOrUpdate(assemblyTable);
			  assemblyLaborTable.LaborTable = laborTable;
			  assemblyLaborTable.AssemblyTable = assemblyTable;
			  paramSession.saveOrUpdate(assemblyLaborTable);
			}
			if (bigDecimal14 != null && BigDecimalMath.cmp(bigDecimal14, BigDecimalMath.ZERO) > 0)
			{
			  if (bigDecimal11 != null && BigDecimalMath.cmp(bigDecimal11, BigDecimalMath.ZERO) > 0)
			  {
				decimal bigDecimal = bigDecimal13;
				if (BigDecimalMath.cmp(bigDecimal, BigDecimalMath.ZERO) <= 0 && BigDecimalMath.cmp(bigDecimal11, BigDecimalMath.ZERO) > 0)
				{
				  bigDecimal = BigDecimalMath.div(BigDecimalMath.ONE, bigDecimal11);
				}
				if (str7.Equals("DAY"))
				{
				  bigDecimal14 = BigDecimalMath.mult(bigDecimal14, BigDecimalMath.div(BigDecimalMath.ONE, HOURS_OF_DAY));
				}
				else if (str7.Equals("WEEK") || str7.Equals("WK"))
				{
				  bigDecimal14 = BigDecimalMath.mult(bigDecimal14, BigDecimalMath.div(BigDecimalMath.ONE, HOURS_OF_WEEK));
				}
				else if (str7.Equals("MONTH") || str7.Equals("MO"))
				{
				  bigDecimal14 = BigDecimalMath.mult(bigDecimal14, BigDecimalMath.div(BigDecimalMath.ONE, HOURS_OF_MONTH));
				}
				if (str19.Equals("WEEK"))
				{
				  bigDecimal = BigDecimalMath.mult(bigDecimal, HOURS_OF_WEEK);
				}
				else if (str19.Equals("MO") || str19.Equals("MONTH"))
				{
				  bigDecimal = BigDecimalMath.mult(bigDecimal, HOURS_OF_MONTH);
				}
				else if (str19.Equals("DAY"))
				{
				  bigDecimal = BigDecimalMath.mult(bigDecimal, HOURS_OF_DAY);
				}
				EquipmentTable equipmentTable = BlankResourceInitializer.createBlankEquipment(assemblyTable);
				equipmentTable.Title = assemblyTable.Title;
				equipmentTable.Unit = str19;
				equipmentTable.ReservationRate = bigDecimal14;
				equipmentTable.Currency = "USD";
				equipmentTable.EditorId = "admin";
				equipmentTable.Country = "US";
				equipmentTable.LastUpdate = this.lastUpdate;
				equipmentTable.CreateDate = this.lastUpdate;
				equipmentTable.CreateUserId = "admin";
				equipmentTable.EditorId = "admin";
				long = (long?)paramSession.save(equipmentTable.clone());
				equipmentTable.Id = long;
				equipmentTable = (EquipmentTable)paramSession.load(typeof(EquipmentTable), long);
				AssemblyEquipmentTable assemblyEquipmentTable = new AssemblyEquipmentTable();
				assemblyEquipmentTable.Factor1 = BigDecimalMath.ONE;
				assemblyEquipmentTable.Factor2 = BigDecimalMath.ONE;
				assemblyEquipmentTable.Factor3 = BigDecimalMath.ONE;
				assemblyEquipmentTable.ExchangeRate = BigDecimalMath.ONE;
				assemblyEquipmentTable.QuantityPerUnit = bigDecimal;
				assemblyEquipmentTable.QuantityPerUnitFormula = "";
				assemblyEquipmentTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
				assemblyEquipmentTable.LocalFactor = BigDecimalMath.ONE;
				assemblyEquipmentTable.LocalCountry = "";
				assemblyEquipmentTable.LocalStateProvince = "";
				assemblyEquipmentTable.EnergyPrice = BigDecimalMath.ZERO;
				assemblyEquipmentTable.FuelRate = BigDecimalMath.ZERO;
				assemblyEquipmentTable.LastUpdate = assemblyTable.LastUpdate;
				long = (long?)paramSession.save(assemblyEquipmentTable);
				assemblyEquipmentTable.AssemblyEquipmentId = long;
				assemblyTable.AssemblyEquipmentSet.Add(assemblyEquipmentTable);
				paramSession.saveOrUpdate(assemblyTable);
				assemblyEquipmentTable.EquipmentTable = equipmentTable;
				assemblyEquipmentTable.AssemblyTable = assemblyTable;
				paramSession.saveOrUpdate(assemblyEquipmentTable);
			  }
			  else
			  {
				createSubcontractor(paramSession, assemblyTable, "Equipment: " + assemblyTable.Title, bigDecimal14, str19, bigDecimal13);
			  }
			}
			if (bigDecimal9 != null && BigDecimalMath.cmp(bigDecimal9, BigDecimalMath.ZERO) > 0)
			{
			  MaterialTable materialTable = BlankResourceInitializer.createBlankMaterial(assemblyTable);
			  materialTable.Title = assemblyTable.Title;
			  materialTable.Unit = str15;
			  materialTable.Rate = bigDecimal9;
			  materialTable.Currency = "USD";
			  materialTable.EditorId = "admin";
			  materialTable.Country = "US";
			  materialTable.LastUpdate = this.lastUpdate;
			  materialTable.CreateDate = this.lastUpdate;
			  materialTable.CreateUserId = "admin";
			  materialTable.EditorId = "admin";
			  long = (long?)paramSession.save(materialTable.clone());
			  materialTable.Id = long;
			  materialTable = (MaterialTable)paramSession.load(typeof(MaterialTable), long);
			  AssemblyMaterialTable assemblyMaterialTable = new AssemblyMaterialTable();
			  assemblyMaterialTable.Factor1 = BigDecimalMath.ONE;
			  assemblyMaterialTable.Factor2 = BigDecimalMath.ONE;
			  assemblyMaterialTable.Factor3 = BigDecimalMath.ONE;
			  assemblyMaterialTable.ExchangeRate = BigDecimalMath.ONE;
			  assemblyMaterialTable.QuantityPerUnit = bigDecimal8;
			  assemblyMaterialTable.QuantityPerUnitFormula = "";
			  assemblyMaterialTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
			  assemblyMaterialTable.LocalFactor = BigDecimalMath.ONE;
			  assemblyMaterialTable.LocalCountry = "";
			  assemblyMaterialTable.LocalStateProvince = "";
			  assemblyMaterialTable.LastUpdate = assemblyTable.LastUpdate;
			  long = (long?)paramSession.save(assemblyMaterialTable);
			  assemblyMaterialTable.AssemblyMaterialId = long;
			  assemblyTable.AssemblyMaterialSet.Add(assemblyMaterialTable);
			  paramSession.saveOrUpdate(assemblyTable);
			  assemblyMaterialTable.MaterialTable = materialTable;
			  assemblyMaterialTable.AssemblyTable = assemblyTable;
			  paramSession.saveOrUpdate(assemblyMaterialTable);
			}
			if (bigDecimal24 != null && BigDecimalMath.cmp(bigDecimal24, BigDecimalMath.ZERO) > 0)
			{
			  createSubcontractor(paramSession, assemblyTable, assemblyTable.Title, bigDecimal24, str27, bigDecimal23);
			}
			if (bigDecimal19 != null && BigDecimalMath.cmp(bigDecimal19, BigDecimalMath.ZERO) > 0)
			{
			  ConsumableTable consumableTable = BlankResourceInitializer.createBlankConsumable(assemblyTable);
			  consumableTable.Title = assemblyTable.Title;
			  consumableTable.Unit = str23;
			  consumableTable.Rate = bigDecimal19;
			  consumableTable.Currency = "USD";
			  consumableTable.EditorId = "admin";
			  consumableTable.Country = "US";
			  consumableTable.LastUpdate = this.lastUpdate;
			  consumableTable.CreateDate = this.lastUpdate;
			  consumableTable.CreateUserId = "admin";
			  consumableTable.EditorId = "admin";
			  long = (long?)paramSession.save(consumableTable.clone());
			  consumableTable.Id = long;
			  consumableTable = (ConsumableTable)paramSession.load(typeof(ConsumableTable), long);
			  AssemblyConsumableTable assemblyConsumableTable = new AssemblyConsumableTable();
			  assemblyConsumableTable.Factor1 = BigDecimalMath.ONE;
			  assemblyConsumableTable.Factor2 = BigDecimalMath.ONE;
			  assemblyConsumableTable.Factor3 = BigDecimalMath.ONE;
			  assemblyConsumableTable.ExchangeRate = BigDecimalMath.ONE;
			  assemblyConsumableTable.QuantityPerUnit = bigDecimal18;
			  assemblyConsumableTable.QuantityPerUnitFormula = "";
			  assemblyConsumableTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
			  assemblyConsumableTable.LocalFactor = BigDecimalMath.ONE;
			  assemblyConsumableTable.LocalCountry = "";
			  assemblyConsumableTable.LocalStateProvince = "";
			  assemblyConsumableTable.LastUpdate = assemblyTable.LastUpdate;
			  long = (long?)paramSession.save(assemblyConsumableTable);
			  assemblyConsumableTable.AssemblyConsumableId = long;
			  assemblyTable.AssemblyConsumableSet.Add(assemblyConsumableTable);
			  paramSession.saveOrUpdate(assemblyTable);
			  assemblyConsumableTable.ConsumableTable = consumableTable;
			  assemblyConsumableTable.AssemblyTable = assemblyTable;
			  paramSession.saveOrUpdate(assemblyConsumableTable);
			}
			if (DatabaseDBUtil.LocalCommunication)
			{
			  assemblyTable.recalculate();
			  paramSession.saveOrUpdate(assemblyTable);
			}
		  }
		}
		if (hSSFWorkbook != null)
		{
		  hSSFWorkbook.close();
		}
	  }

	  private void createSubcontractor(Session paramSession, AssemblyTable paramAssemblyTable, string paramString1, decimal paramBigDecimal1, string paramString2, decimal paramBigDecimal2)
	  {
		SubcontractorTable subcontractorTable = BlankResourceInitializer.createBlankSubcontractor(paramAssemblyTable);
		subcontractorTable.Title = paramString1;
		subcontractorTable.Unit = paramString2;
		subcontractorTable.Rate = paramBigDecimal1;
		subcontractorTable.Currency = "USD";
		subcontractorTable.EditorId = "admin";
		subcontractorTable.Country = "US";
		subcontractorTable.LastUpdate = this.lastUpdate;
		subcontractorTable.CreateDate = this.lastUpdate;
		subcontractorTable.CreateUserId = "admin";
		subcontractorTable.EditorId = "admin";
		long? long = (long?)paramSession.save(subcontractorTable.clone());
		subcontractorTable.Id = long;
		subcontractorTable = (SubcontractorTable)paramSession.load(typeof(SubcontractorTable), long);
		AssemblySubcontractorTable assemblySubcontractorTable = new AssemblySubcontractorTable();
		assemblySubcontractorTable.Factor1 = BigDecimalMath.ONE;
		assemblySubcontractorTable.Factor2 = BigDecimalMath.ONE;
		assemblySubcontractorTable.Factor3 = BigDecimalMath.ONE;
		assemblySubcontractorTable.ExchangeRate = BigDecimalMath.ONE;
		assemblySubcontractorTable.QuantityPerUnit = paramBigDecimal2;
		assemblySubcontractorTable.QuantityPerUnitFormula = "";
		assemblySubcontractorTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
		assemblySubcontractorTable.LocalFactor = BigDecimalMath.ONE;
		assemblySubcontractorTable.LocalCountry = "";
		assemblySubcontractorTable.LocalStateProvince = "";
		assemblySubcontractorTable.LastUpdate = paramAssemblyTable.LastUpdate;
		long = (long?)paramSession.save(assemblySubcontractorTable);
		assemblySubcontractorTable.AssemblySubcontractorId = long;
		paramAssemblyTable.AssemblySubcontractorSet.Add(assemblySubcontractorTable);
		paramSession.saveOrUpdate(paramAssemblyTable);
		assemblySubcontractorTable.SubcontractorTable = subcontractorTable;
		assemblySubcontractorTable.AssemblyTable = paramAssemblyTable;
		paramSession.saveOrUpdate(assemblySubcontractorTable);
	  }

	  private string toCorrectUnit(string paramString)
	  {
		paramString = paramString.ToUpper();
		if (paramString.StartsWith("/", StringComparison.Ordinal))
		{
		  paramString = paramString.Substring(paramString.IndexOf("/", StringComparison.Ordinal) + 1);
		}
		return paramString.Equals("EA") ? "EACH" : ((paramString.Equals("HR") || paramString.Equals("HRS") || paramString.Equals("MH")) ? "HOUR" : (paramString.Equals("MO") ? "MONTH" : (paramString.Equals("WK") ? "WEEK" : (paramString.Equals("DY") ? "DAY" : paramString))));
	  }

	  private decimal notNullBigDecimal(HSSFCell paramHSSFCell, double paramDouble)
	  {
		decimal bigDecimal = new BigDecimalFixed("" + paramDouble);
		if (paramHSSFCell == null)
		{
		  return bigDecimal;
		}
		if (paramHSSFCell.CellType == 0)
		{
		  bigDecimal = new BigDecimalFixed("" + paramHSSFCell.NumericCellValue);
		}
		else if (paramHSSFCell.CellType == 2)
		{
		  CellValue cellValue = this.o_evaluator.evaluate(paramHSSFCell);
		  if (cellValue.CellType == 0)
		  {
			bigDecimal = new BigDecimalFixed("" + cellValue.NumberValue);
		  }
		}
		else
		{
		  try
		  {
			bigDecimal = new decimal(paramHSSFCell.RichStringCellValue.String);
		  }
		  catch (Exception)
		  {
			return bigDecimal;
		  }
		}
		return bigDecimal;
	  }

	  private string notNull(HSSFCell paramHSSFCell)
	  {
		string str = "";
		if (paramHSSFCell == null)
		{
		  return "";
		}
		if (paramHSSFCell != null && paramHSSFCell.CellType == 0)
		{
		  str = "" + paramHSSFCell.NumericCellValue;
		  if (str.EndsWith(".0", StringComparison.Ordinal))
		  {
			str = "" + (long)paramHSSFCell.NumericCellValue;
		  }
		}
		else if (paramHSSFCell != null && paramHSSFCell.CellType == 2)
		{
		  CellValue cellValue = null;
		  try
		  {
			cellValue = this.o_evaluator.evaluate(paramHSSFCell);
		  }
		  catch (Exception)
		  {
			Console.WriteLine("Could not evaluate: " + paramHSSFCell);
			return paramHSSFCell.ToString();
		  }
		  if (cellValue.CellType == 0)
		  {
			str = "" + cellValue.NumberValue;
		  }
		  else if (cellValue.CellType == 1)
		  {
			str = cellValue.StringValue;
		  }
		  else
		  {
			return "";
		  }
		}
		else
		{
		  str = paramHSSFCell.RichStringCellValue.String;
		}
		return (string.ReferenceEquals(str, null)) ? "" : str;
	  }

	  private int getRealNumberOfRows(HSSFSheet paramHSSFSheet)
	  {
		int i = paramHSSFSheet.PhysicalNumberOfRows;
		for (sbyte b = 1; b < i; b++)
		{
		  if (paramHSSFSheet.getRow(b) == null)
		  {
			return b;
		  }
		  int j = paramHSSFSheet.getRow(0).PhysicalNumberOfCells;
		  bool @bool = true;
		  for (sbyte b1 = 0; b1 < j; b1++)
		  {
			string str = null;
			str = notNull(paramHSSFSheet.getRow(b).getCell(b1));
			if (!str.Equals(""))
			{
			  @bool = false;
			}
		  }
		  if (@bool)
		  {
			return b;
		  }
		}
		return i;
	  }

	  public static void migrate(string paramString1, string paramString2, string paramString3, string paramString4)
	  {
		  new TimberlineMigrationUtil(paramString1, paramString2, paramString3, paramString4);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\TimberlineMigrationUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}