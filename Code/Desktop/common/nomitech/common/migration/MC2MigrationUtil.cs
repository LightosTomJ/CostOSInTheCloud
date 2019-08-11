using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Desktop.common.nomitech.common.migration
{
	using GroupCode = nomitech.common.@base.GroupCode;
	using ResourceTable = nomitech.common.@base.ResourceTable;
	using ResourceToAssignmentTable = nomitech.common.@base.ResourceToAssignmentTable;
	using AssemblyConsumableTable = nomitech.common.db.local.AssemblyConsumableTable;
	using AssemblyEquipmentTable = nomitech.common.db.local.AssemblyEquipmentTable;
	using AssemblyLaborTable = nomitech.common.db.local.AssemblyLaborTable;
	using AssemblyMaterialTable = nomitech.common.db.local.AssemblyMaterialTable;
	using AssemblySubcontractorTable = nomitech.common.db.local.AssemblySubcontractorTable;
	using AssemblyTable = nomitech.common.db.local.AssemblyTable;
	using ConsumableTable = nomitech.common.db.local.ConsumableTable;
	using EquipmentTable = nomitech.common.db.local.EquipmentTable;
	using GekCodeTable = nomitech.common.db.local.GekCodeTable;
	using GroupCodeTable = nomitech.common.db.local.GroupCodeTable;
	using LaborTable = nomitech.common.db.local.LaborTable;
	using MaterialTable = nomitech.common.db.local.MaterialTable;
	using SubcontractorTable = nomitech.common.db.local.SubcontractorTable;
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using BlankResourceInitializer = nomitech.common.expr.boqitem.BlankResourceInitializer;
	using MC2Crew = Desktop.common.nomitech.common.migration.mc2.MC2Crew;
	using MC2ResourceItem = Desktop.common.nomitech.common.migration.mc2.MC2ResourceItem;
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

	public class MC2MigrationUtil
	{
	  private static readonly BigDecimalFixed HOURS_OF_DAY = new BigDecimalFixed("8");

	  private static readonly BigDecimalFixed HOURS_OF_WEEK = new BigDecimalFixed("40");

	  private static readonly BigDecimalFixed HOURS_OF_MONTH = new BigDecimalFixed("160");

	  private IDictionary<string, ResourceTable> resourceCacheCrew = new Hashtable();

	  private IDictionary<string, MC2Crew> crewCache = new Hashtable();

	  private IDictionary<string, string> level1Csi33div = new Hashtable();

	  private IDictionary<string, string> level1Csi16div = new Hashtable();

	  private IDictionary<string, string> level2WorkCategory33 = new Hashtable();

	  private IDictionary<string, string> level2WorkCategory16 = new Hashtable();

	  private int rowsToCommit = 500;

	  private FormulaEvaluator o_evaluator;

	  private DateTime lastUpdate = DateTime.Now;

	  private bool IMPORT_CREWS_AS_LINE_ITEMS = true;

	  public MC2MigrationUtil(string paramString1, string paramString2, string paramString3, string paramString4)
	  {
		Session session = DatabaseDBUtil.currentSession();
		session.beginTransaction();
		try
		{
		  Console.WriteLine("Starting Importing of Resources and Crews...");
		  session.Transaction.commit();
		  session.beginTransaction();
		  loadGroupCodes(session, paramString2, paramString3);
		  session.Transaction.commit();
		  session.beginTransaction();
		  loadRanges(session, paramString2, paramString3);
		  session.Transaction.commit();
		  session.beginTransaction();
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

	  private void loadRanges(Session paramSession, string paramString1, string paramString2)
	  {
	  }

	  private void loadGroupCodes(Session paramSession, string paramString1, string paramString2)
	  {
		POIFSFileSystem pOIFSFileSystem = new POIFSFileSystem(new FileStream(paramString1, FileMode.Open, FileAccess.Read));
		HSSFWorkbook hSSFWorkbook = new HSSFWorkbook(pOIFSFileSystem);
		this.o_evaluator = hSSFWorkbook.CreationHelper.createFormulaEvaluator();
		HSSFSheet hSSFSheet1 = hSSFWorkbook.getSheetAt(5);
		HSSFSheet hSSFSheet2 = hSSFWorkbook.getSheetAt(6);
		HSSFSheet hSSFSheet3 = hSSFWorkbook.getSheetAt(0);
		HSSFSheet hSSFSheet4 = hSSFWorkbook.getSheetAt(4);
		int i = getRealNumberOfRows(hSSFSheet1);
		int j;
		for (j = 1; j < i; j++)
		{
		  if (j % this.rowsToCommit == 0)
		  {
			paramSession.Transaction.commit();
			paramSession.Transaction.begin();
			Console.WriteLine("Processing next 500...");
		  }
		  HSSFRow hSSFRow = hSSFSheet1.getRow(j);
		  string str1 = notNull(hSSFRow.getCell(0)) + "000000";
		  string str2 = notNull(hSSFRow.getCell(1));
		  str1 = StringUtils.replaceAll(str1, ".", "");
		  int k = str2.LastIndexOf(" - ", StringComparison.Ordinal);
		  if (k != -1)
		  {
			str2 = str2.Substring(k + 3);
		  }
		  this.level1Csi33div[str1] = str2;
		  paramSession.save(addGroupCode1(str1, str2));
		  Console.WriteLine(str1 + " = " + str2);
		}
		i = getRealNumberOfRows(hSSFSheet2);
		for (j = 1; j < i; j++)
		{
		  if (j % this.rowsToCommit == 0)
		  {
			paramSession.Transaction.commit();
			paramSession.Transaction.begin();
			Console.WriteLine("Processing next 500...");
		  }
		  HSSFRow hSSFRow = hSSFSheet2.getRow(j);
		  string str1 = notNull(hSSFRow.getCell(0)) + "000000";
		  string str2 = notNull(hSSFRow.getCell(1));
		  str1 = StringUtils.replaceAll(str1, ".", "");
		  int k = str2.LastIndexOf(" - ", StringComparison.Ordinal);
		  if (k != -1)
		  {
			str2 = str2.Substring(k + 3);
		  }
		  this.level1Csi16div[str1] = str2;
		  paramSession.save(addGroupCode2(str1, str2));
		  Console.WriteLine(str1 + " = " + str2);
		}
		i = getRealNumberOfRows(hSSFSheet3);
		for (j = 1; j < i; j++)
		{
		  if (j % this.rowsToCommit == 0)
		  {
			paramSession.Transaction.commit();
			paramSession.Transaction.begin();
			Console.WriteLine("Processing next 500...");
		  }
		  HSSFRow hSSFRow = hSSFSheet3.getRow(j);
		  string str1 = notNull(hSSFRow.getCell(0)) + "0000";
		  string str2 = notNull(hSSFRow.getCell(1));
		  str1 = StringUtils.replaceAll(str1, ".", "");
		  int k = str2.LastIndexOf(" - ", StringComparison.Ordinal);
		  if (k != -1)
		  {
			str2 = str2.Substring(k + 3);
		  }
		  paramSession.save(addGroupCode1(str1, str2));
		  this.level2WorkCategory33[str1] = str2;
		}
		i = getRealNumberOfRows(hSSFSheet4);
		for (j = 1; j < i; j++)
		{
		  if (j % this.rowsToCommit == 0)
		  {
			paramSession.Transaction.commit();
			paramSession.Transaction.begin();
			Console.WriteLine("Processing next 500...");
		  }
		  HSSFRow hSSFRow = hSSFSheet3.getRow(j);
		  string str1 = notNull(hSSFRow.getCell(0)) + "000000";
		  string str2 = notNull(hSSFRow.getCell(1));
		  str1 = StringUtils.replaceAll(str1, ".", "");
		  int k = str2.LastIndexOf(" - ", StringComparison.Ordinal);
		  if (k != -1)
		  {
			str2 = str2.Substring(k + 3);
		  }
		  paramSession.save(addGroupCode2(str1, str2));
		  this.level2WorkCategory16[str1] = str2;
		}
		if (hSSFWorkbook != null)
		{
		  hSSFWorkbook.close();
		}
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
		for (int j = 1; j < i; j++)
		{
		  if (j % this.rowsToCommit == 0)
		  {
			paramSession.Transaction.commit();
			paramSession.Transaction.begin();
			Console.WriteLine("Processing next 500...");
		  }
		  HSSFRow hSSFRow = hSSFSheet.getRow(j);
		  string str1 = notNull(hSSFRow.getCell(0));
		  string str2 = notNull(hSSFRow.getCell(1));
		  if (!str2.StartsWith("***", StringComparison.Ordinal))
		  {
			string str3 = notNull(hSSFRow.getCell(2));
			decimal bigDecimal1 = notNullBigDecimal(hSSFRow.getCell(3), 0.0D);
			decimal bigDecimal2 = notNullBigDecimal(hSSFRow.getCell(4), 0.0D);
			string str4 = notNull(hSSFRow.getCell(5));
			decimal bigDecimal3 = notNullBigDecimal(hSSFRow.getCell(6), 0.0D);
			string str5 = notNull(hSSFRow.getCell(7));
			string str6 = notNull(hSSFRow.getCell(8));
			decimal bigDecimal4 = notNullBigDecimal(hSSFRow.getCell(9), 0.0D);
			string str7 = notNull(hSSFRow.getCell(10));
			decimal bigDecimal5 = notNullBigDecimal(hSSFRow.getCell(11), 0.0D);
			decimal bigDecimal6 = notNullBigDecimal(hSSFRow.getCell(12), 0.0D);
			decimal bigDecimal7 = notNullBigDecimal(hSSFRow.getCell(13), 0.0D);
			string str8 = notNull(hSSFRow.getCell(14));
			decimal bigDecimal8 = notNullBigDecimal(hSSFRow.getCell(15), 0.0D);
			decimal bigDecimal9 = notNullBigDecimal(hSSFRow.getCell(16), 0.0D);
			decimal bigDecimal10 = notNullBigDecimal(hSSFRow.getCell(17), 0.0D);
			decimal bigDecimal11 = notNullBigDecimal(hSSFRow.getCell(18), 0.0D);
			decimal bigDecimal12 = notNullBigDecimal(hSSFRow.getCell(19), 0.0D);
			decimal bigDecimal13 = notNullBigDecimal(hSSFRow.getCell(20), 0.0D);
			decimal bigDecimal14 = notNullBigDecimal(hSSFRow.getCell(21), 0.0D);
			decimal bigDecimal15 = notNullBigDecimal(hSSFRow.getCell(22), 0.0D);
			string str9 = notNull(hSSFRow.getCell(23));
			string str10 = notNull(hSSFRow.getCell(24));
			string str11 = notNull(hSSFRow.getCell(25));
			decimal bigDecimal16 = notNullBigDecimal(hSSFRow.getCell(26), 0.0D);
			string str12 = notNull(hSSFRow.getCell(27));
			string str13 = notNull(hSSFRow.getCell(28));
			string str14 = notNull(hSSFRow.getCell(29));
			string str15 = notNull(hSSFRow.getCell(30));
			string str16 = notNull(hSSFRow.getCell(31));
			string str17 = notNull(hSSFRow.getCell(32));
			string str18 = notNull(hSSFRow.getCell(33));
			string str19 = notNull(hSSFRow.getCell(34));
			string str20 = notNull(hSSFRow.getCell(35));
			string str21 = notNull(hSSFRow.getCell(36));
			string str22 = notNull(hSSFRow.getCell(37));
			str20 = StringUtils.replaceAll(str20, ".", "") + "000000";
			str21 = StringUtils.replaceAll(str21, ".", "") + "000000";
			str19 = StringUtils.replaceAll(str19, ".", "") + "0000";
			str12 = StringUtils.replaceAll(str12, ".", "") + "0000";
			str1 = StringUtils.replaceAll(str1, ".", "");
			if (this.level1Csi33div.ContainsKey(str20))
			{
			  str20 = str20 + " - " + (string)this.level1Csi33div[str20];
			}
			if (this.level1Csi16div.ContainsKey(str21))
			{
			  str21 = str21 + " - " + (string)this.level1Csi16div[str21];
			}
			if (this.level2WorkCategory33.ContainsKey(str12))
			{
			  str12 = str12 + " - " + (string)this.level2WorkCategory33[str12];
			}
			if (this.level2WorkCategory16.ContainsKey(str19))
			{
			  str19 = str19 + " - " + (string)this.level2WorkCategory16[str19];
			}
			Console.WriteLine("For item " + str1 + " = " + str20 + " = " + str12);
			MC2Crew mC2Crew = (MC2Crew)this.crewCache[str5];
			AssemblyTable assemblyTable = BlankResourceInitializer.createBlankAssembly(null);
			assemblyTable.CustomText1 = str6;
			assemblyTable.CustomText2 = str20;
			assemblyTable.CustomText3 = str12;
			assemblyTable.CustomText5 = str21;
			assemblyTable.CustomText6 = str19;
			assemblyTable.CustomText17 = str17;
			assemblyTable.Title = str2;
			assemblyTable.GroupCode = str12.Equals("") ? str20 : str12;
			assemblyTable.GekCode = str19.Equals("") ? str21 : str19;
			if (mC2Crew != null)
			{
			  assemblyTable.Notes = mC2Crew.CrewId;
			}
			if (BigDecimalMath.cmp(bigDecimal3, BigDecimalMath.ZERO) > 0)
			{
			  assemblyTable.ActivityBased = true;
			  Console.WriteLine("Setting productivity for: " + str2 + " = " + bigDecimal3);
			  assemblyTable.Productivity = bigDecimal3;
			}
			assemblyTable.ItemCode = str1;
			assemblyTable.PublishedRevisionCode = str1;
			assemblyTable.Unit = str3;
			assemblyTable.LastUpdate = this.lastUpdate;
			assemblyTable.Description = str1 + " " + str2;
			assemblyTable.LastUpdate = this.lastUpdate;
			assemblyTable.CreateDate = this.lastUpdate;
			assemblyTable.CreateUserId = "admin";
			assemblyTable.EditorId = "admin";
			assemblyTable.AssemblyChildSet = new HashSet<object>();
			assemblyTable.AssemblyEquipmentSet = new HashSet<object>();
			assemblyTable.AssemblySubcontractorSet = new HashSet<object>();
			assemblyTable.AssemblyLaborSet = new HashSet<object>();
			assemblyTable.AssemblyMaterialSet = new HashSet<object>();
			assemblyTable.AssemblyConsumableSet = new HashSet<object>();
			long? long = (long?)paramSession.save(assemblyTable.clone());
			assemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), long);
			if (mC2Crew != null)
			{
			  foreach (MC2ResourceItem mC2ResourceItem in mC2Crew.CrewItems)
			  {
				assemblyTable = explodeCrewResourceItemToAssembly(paramSession, assemblyTable, mC2Crew, mC2ResourceItem);
			  }
			}
			if (BigDecimalMath.cmp(bigDecimal7, BigDecimalMath.ZERO) > 0)
			{
			  MaterialTable materialTable = BlankResourceInitializer.createBlankMaterial(assemblyTable);
			  materialTable.Rate = bigDecimal7;
			  long = (long?)paramSession.save(materialTable);
			  materialTable = (MaterialTable)paramSession.load(typeof(MaterialTable), long);
			  AssemblyMaterialTable assemblyMaterialTable = new AssemblyMaterialTable();
			  assemblyMaterialTable.Factor1 = BigDecimalMath.ONE;
			  assemblyMaterialTable.Factor2 = BigDecimalMath.ONE;
			  assemblyMaterialTable.Factor3 = BigDecimalMath.ONE;
			  assemblyMaterialTable.ExchangeRate = BigDecimalMath.ONE;
			  assemblyMaterialTable.QuantityPerUnit = BigDecimalMath.ONE;
			  assemblyMaterialTable.QuantityPerUnitFormula = "";
			  assemblyMaterialTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
			  assemblyMaterialTable.LocalFactor = BigDecimalMath.ONE;
			  assemblyMaterialTable.LocalCountry = "";
			  assemblyMaterialTable.LocalStateProvince = "";
			  assemblyMaterialTable.LastUpdate = assemblyTable.LastUpdate;
			  long = (long?)paramSession.save(assemblyMaterialTable);
			  assemblyMaterialTable.AssemblyMaterialId = long;
			  if (DatabaseDBUtil.LocalCommunication)
			  {
				assemblyTable.AssemblyMaterialSet.Add(assemblyMaterialTable);
				paramSession.saveOrUpdate(assemblyTable);
				assemblyMaterialTable.MaterialTable = materialTable;
				assemblyMaterialTable.AssemblyTable = assemblyTable;
				paramSession.saveOrUpdate(assemblyMaterialTable);
			  }
			  else
			  {
				assemblyMaterialTable = (AssemblyMaterialTable)DatabaseDBUtil.associateAssemblyResource(assemblyTable, materialTable, assemblyMaterialTable);
				assemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), assemblyTable.Id);
			  }
			}
			if (BigDecimalMath.cmp(bigDecimal8, BigDecimalMath.ZERO) > 0)
			{
			  SubcontractorTable subcontractorTable = BlankResourceInitializer.createBlankSubcontractor(assemblyTable);
			  subcontractorTable.Rate = bigDecimal8;
			  long = (long?)paramSession.save(subcontractorTable);
			  subcontractorTable = (SubcontractorTable)paramSession.load(typeof(SubcontractorTable), long);
			  AssemblySubcontractorTable assemblySubcontractorTable = new AssemblySubcontractorTable();
			  assemblySubcontractorTable.Factor1 = BigDecimalMath.ONE;
			  assemblySubcontractorTable.Factor2 = BigDecimalMath.ONE;
			  assemblySubcontractorTable.Factor3 = BigDecimalMath.ONE;
			  assemblySubcontractorTable.ExchangeRate = BigDecimalMath.ONE;
			  assemblySubcontractorTable.QuantityPerUnit = BigDecimalMath.ONE;
			  assemblySubcontractorTable.QuantityPerUnitFormula = "";
			  assemblySubcontractorTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
			  assemblySubcontractorTable.LocalFactor = BigDecimalMath.ONE;
			  assemblySubcontractorTable.LocalCountry = "";
			  assemblySubcontractorTable.LocalStateProvince = "";
			  assemblySubcontractorTable.LastUpdate = assemblyTable.LastUpdate;
			  long = (long?)paramSession.save(assemblySubcontractorTable);
			  assemblySubcontractorTable.AssemblySubcontractorId = long;
			  if (DatabaseDBUtil.LocalCommunication)
			  {
				assemblyTable.AssemblySubcontractorSet.Add(assemblySubcontractorTable);
				paramSession.saveOrUpdate(assemblyTable);
				assemblySubcontractorTable.SubcontractorTable = subcontractorTable;
				assemblySubcontractorTable.AssemblyTable = assemblyTable;
				paramSession.saveOrUpdate(assemblySubcontractorTable);
			  }
			  else
			  {
				assemblySubcontractorTable = (AssemblySubcontractorTable)DatabaseDBUtil.associateAssemblyResource(assemblyTable, subcontractorTable, assemblySubcontractorTable);
				assemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), assemblyTable.Id);
			  }
			}
			if (BigDecimalMath.cmp(bigDecimal11, BigDecimalMath.ZERO) > 0)
			{
			  ConsumableTable consumableTable = BlankResourceInitializer.createBlankConsumable(assemblyTable);
			  consumableTable.Rate = bigDecimal11;
			  long = (long?)paramSession.save(consumableTable);
			  consumableTable = (ConsumableTable)paramSession.load(typeof(ConsumableTable), long);
			  AssemblyConsumableTable assemblyConsumableTable = new AssemblyConsumableTable();
			  assemblyConsumableTable.Factor1 = BigDecimalMath.ONE;
			  assemblyConsumableTable.Factor2 = BigDecimalMath.ONE;
			  assemblyConsumableTable.Factor3 = BigDecimalMath.ONE;
			  assemblyConsumableTable.ExchangeRate = BigDecimalMath.ONE;
			  assemblyConsumableTable.QuantityPerUnit = BigDecimalMath.ONE;
			  assemblyConsumableTable.QuantityPerUnitFormula = "";
			  assemblyConsumableTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
			  assemblyConsumableTable.LocalFactor = BigDecimalMath.ONE;
			  assemblyConsumableTable.LocalCountry = "";
			  assemblyConsumableTable.LocalStateProvince = "";
			  assemblyConsumableTable.LastUpdate = assemblyTable.LastUpdate;
			  long = (long?)paramSession.save(assemblyConsumableTable);
			  assemblyConsumableTable.AssemblyConsumableId = long;
			  if (DatabaseDBUtil.LocalCommunication)
			  {
				assemblyTable.AssemblyConsumableSet.Add(assemblyConsumableTable);
				paramSession.saveOrUpdate(assemblyTable);
				assemblyConsumableTable.ConsumableTable = consumableTable;
				assemblyConsumableTable.AssemblyTable = assemblyTable;
				paramSession.saveOrUpdate(assemblyConsumableTable);
			  }
			  else
			  {
				assemblyConsumableTable = (AssemblyConsumableTable)DatabaseDBUtil.associateAssemblyResource(assemblyTable, consumableTable, assemblyConsumableTable);
				assemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), assemblyTable.Id);
			  }
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

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadResourcesAndCrews(org.hibernate.Session paramSession, String paramString) throws Exception
	  private void loadResourcesAndCrews(Session paramSession, string paramString)
	  {
		POIFSFileSystem pOIFSFileSystem = new POIFSFileSystem(new FileStream(paramString, FileMode.Open, FileAccess.Read));
		HSSFWorkbook hSSFWorkbook = new HSSFWorkbook(pOIFSFileSystem);
		this.o_evaluator = hSSFWorkbook.CreationHelper.createFormulaEvaluator();
		HSSFSheet hSSFSheet1 = hSSFWorkbook.getSheetAt(0);
		HSSFSheet hSSFSheet2 = hSSFWorkbook.getSheetAt(1);
		HSSFSheet hSSFSheet3 = hSSFWorkbook.getSheetAt(2);
		HSSFSheet hSSFSheet4 = hSSFWorkbook.getSheetAt(3);
		HSSFSheet hSSFSheet5 = hSSFWorkbook.getSheetAt(4);
		HSSFSheet hSSFSheet6 = hSSFWorkbook.getSheetAt(5);
		HSSFSheet hSSFSheet7 = hSSFWorkbook.getSheetAt(6);
		Console.WriteLine("Loading Labors for Crew...");
		loadAndCacheLaborsForCrew(hSSFSheet2, paramSession);
		paramSession.Transaction.commit();
		paramSession.Transaction.begin();
		Console.WriteLine("Loading Materials for Crew...");
		loadAndCacheMaterialsForCrew(hSSFSheet3, paramSession);
		paramSession.Transaction.commit();
		paramSession.Transaction.begin();
		Console.WriteLine("Loading Subcontracts for Crew...");
		loadAndCacheSubcontractsForCrew(hSSFSheet4, paramSession);
		paramSession.Transaction.commit();
		paramSession.Transaction.begin();
		Console.WriteLine("Loading Equipment for Crew...");
		loadAndCacheEquipmentForCrew(hSSFSheet5, paramSession, false);
		paramSession.Transaction.commit();
		paramSession.Transaction.begin();
		Console.WriteLine("Loading Equipment Rental for Crew...");
		loadAndCacheEquipmentForCrew(hSSFSheet6, paramSession, true);
		paramSession.Transaction.commit();
		paramSession.Transaction.begin();
		Console.WriteLine("Loading Consumables for Crew...");
		loadAndCacheConsumablesForCrew(hSSFSheet7, paramSession);
		paramSession.Transaction.commit();
		paramSession.Transaction.begin();
		Console.WriteLine("Loading Crews...");
		loadAndCacheCrews(hSSFSheet1, paramSession);
		if (hSSFWorkbook != null)
		{
		  hSSFWorkbook.close();
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadAndCacheCrews(org.apache.poi.hssf.usermodel.HSSFSheet paramHSSFSheet, org.hibernate.Session paramSession) throws Exception
	  private void loadAndCacheCrews(HSSFSheet paramHSSFSheet, Session paramSession)
	  {
		int i = getRealNumberOfRows(paramHSSFSheet);
		LinkedList linkedList = new LinkedList();
		for (int j = 1; j < i; j++)
		{
		  if (j % this.rowsToCommit == 500)
		  {
			paramSession.Transaction.commit();
			paramSession.Transaction.begin();
			Console.WriteLine("Processing next 500...");
		  }
		  HSSFRow hSSFRow = paramHSSFSheet.getRow(j);
		  string str1 = notNull(hSSFRow.getCell(0));
		  string str2 = notNull(hSSFRow.getCell(1));
		  string str3 = notNull(hSSFRow.getCell(2));
		  string str4 = notNull(hSSFRow.getCell(3));
		  string str5 = notNull(hSSFRow.getCell(4));
		  string str6 = notNull(hSSFRow.getCell(5));
		  decimal bigDecimal = notNullBigDecimal(hSSFRow.getCell(6), 1.0D);
		  string str7 = notNull(hSSFRow.getCell(7));
		  MC2Crew mC2Crew = (MC2Crew)this.crewCache[str1];
		  if (mC2Crew == null)
		  {
			mC2Crew = new MC2Crew(str1, str2, str3);
			linkedList.AddLast(mC2Crew);
			this.crewCache[str1] = mC2Crew;
		  }
		  mC2Crew.CrewItems.Add(new MC2ResourceItem(str5 + str4, str7, bigDecimal));
		}
		if (!this.IMPORT_CREWS_AS_LINE_ITEMS)
		{
		  return;
		}
		System.Collections.IEnumerator iterator = linkedList.GetEnumerator();
		sbyte b = 1;
		while (iterator.MoveNext())
		{
		  MC2Crew mC2Crew = (MC2Crew)iterator.Current;
		  if (b++ % this.rowsToCommit == 500)
		  {
			paramSession.Transaction.commit();
			paramSession.Transaction.begin();
		  }
		  AssemblyTable assemblyTable = BlankResourceInitializer.createBlankAssembly(null);
		  assemblyTable.Title = mC2Crew.CrewDescription;
		  assemblyTable.Notes = mC2Crew.CrewId;
		  assemblyTable.PublishedRevisionCode = mC2Crew.CrewId;
		  assemblyTable.Unit = mC2Crew.CrewUom;
		  assemblyTable.CustomText1 = "CREW";
		  assemblyTable.CustomText2 = "CREW";
		  assemblyTable.CustomText3 = "CREW";
		  assemblyTable.CustomText4 = "CREW";
		  assemblyTable.CustomText5 = "CREW";
		  assemblyTable.CustomText6 = "CREW";
		  assemblyTable.CustomText7 = "CREW";
		  assemblyTable.LastUpdate = this.lastUpdate;
		  assemblyTable.Description = mC2Crew.CrewDescription + ", CODE: " + mC2Crew.CrewId;
		  assemblyTable.LastUpdate = this.lastUpdate;
		  assemblyTable.CreateDate = this.lastUpdate;
		  assemblyTable.CreateUserId = "admin";
		  assemblyTable.EditorId = "admin";
		  assemblyTable.AssemblyEquipmentSet = new HashSet<object>();
		  assemblyTable.AssemblySubcontractorSet = new HashSet<object>();
		  assemblyTable.AssemblyLaborSet = new HashSet<object>();
		  assemblyTable.AssemblyMaterialSet = new HashSet<object>();
		  assemblyTable.AssemblyConsumableSet = new HashSet<object>();
		  long? long = (long?)paramSession.save(assemblyTable.clone());
		  assemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), long);
		  foreach (MC2ResourceItem mC2ResourceItem in mC2Crew.CrewItems)
		  {
			assemblyTable = explodeCrewResourceItemToAssembly(paramSession, assemblyTable, mC2Crew, mC2ResourceItem);
		  }
		  if (DatabaseDBUtil.LocalCommunication)
		  {
			assemblyTable.recalculate();
			paramSession.saveOrUpdate(assemblyTable);
		  }
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private nomitech.common.db.local.AssemblyTable explodeCrewResourceItemToAssembly(org.hibernate.Session paramSession, nomitech.common.db.local.AssemblyTable paramAssemblyTable, Desktop.common.nomitech.common.migration.mc2.MC2Crew paramMC2Crew, Desktop.common.nomitech.common.migration.mc2.MC2ResourceItem paramMC2ResourceItem) throws Exception
	  private AssemblyTable explodeCrewResourceItemToAssembly(Session paramSession, AssemblyTable paramAssemblyTable, MC2Crew paramMC2Crew, MC2ResourceItem paramMC2ResourceItem)
	  {
		ResourceTable resourceTable = (ResourceTable)this.resourceCacheCrew[paramMC2ResourceItem.ResourceCode];
		resourceTable = (ResourceTable)paramSession.load(resourceTable.GetType(), resourceTable.Id);
		if (resourceTable is LaborTable)
		{
		  AssemblyLaborTable assemblyLaborTable = new AssemblyLaborTable();
		  assemblyLaborTable.Factor1 = BigDecimalMath.ONE;
		  assemblyLaborTable.Factor2 = BigDecimalMath.ONE;
		  assemblyLaborTable.Factor3 = BigDecimalMath.ONE;
		  assemblyLaborTable.ExchangeRate = BigDecimalMath.ONE;
		  assemblyLaborTable.QuantityPerUnit = paramMC2ResourceItem.ResourceFactor;
		  assemblyLaborTable.QuantityPerUnitFormula = "";
		  assemblyLaborTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
		  assemblyLaborTable.LocalFactor = BigDecimalMath.ONE;
		  assemblyLaborTable.LocalCountry = "";
		  assemblyLaborTable.LocalStateProvince = "";
		  assemblyLaborTable.LastUpdate = paramAssemblyTable.LastUpdate;
		  long? long = (long?)paramSession.save(assemblyLaborTable);
		  assemblyLaborTable.AssemblyLaborId = long;
		  if (DatabaseDBUtil.LocalCommunication)
		  {
			paramAssemblyTable.AssemblyLaborSet.Add(assemblyLaborTable);
			paramSession.saveOrUpdate(paramAssemblyTable);
			assemblyLaborTable.LaborTable = (LaborTable)resourceTable;
			assemblyLaborTable.AssemblyTable = paramAssemblyTable;
			paramSession.saveOrUpdate(assemblyLaborTable);
		  }
		  else
		  {
			assemblyLaborTable = (AssemblyLaborTable)DatabaseDBUtil.associateAssemblyResource(paramAssemblyTable, (LaborTable)resourceTable, assemblyLaborTable);
			paramAssemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), paramAssemblyTable.Id);
		  }
		}
		else if (resourceTable is EquipmentTable)
		{
		  AssemblyEquipmentTable assemblyEquipmentTable = new AssemblyEquipmentTable();
		  assemblyEquipmentTable.Factor1 = BigDecimalMath.ONE;
		  assemblyEquipmentTable.Factor2 = BigDecimalMath.ONE;
		  assemblyEquipmentTable.Factor3 = BigDecimalMath.ONE;
		  assemblyEquipmentTable.ExchangeRate = BigDecimalMath.ONE;
		  decimal bigDecimal = paramMC2ResourceItem.ResourceFactor;
		  string str = paramMC2ResourceItem.ResourceUom.ToLower();
		  if (str.Equals("wk") || str.Equals("week"))
		  {
			bigDecimal = BigDecimalMath.mult(bigDecimal, HOURS_OF_WEEK);
		  }
		  else if (str.Equals("mo") || str.Equals("month"))
		  {
			bigDecimal = BigDecimalMath.mult(bigDecimal, HOURS_OF_MONTH);
		  }
		  else if (str.Equals("day"))
		  {
			bigDecimal = BigDecimalMath.mult(bigDecimal, HOURS_OF_DAY);
		  }
		  assemblyEquipmentTable.QuantityPerUnit = bigDecimal;
		  assemblyEquipmentTable.QuantityPerUnitFormula = "";
		  assemblyEquipmentTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
		  assemblyEquipmentTable.LocalFactor = BigDecimalMath.ONE;
		  assemblyEquipmentTable.LocalCountry = "";
		  assemblyEquipmentTable.LocalStateProvince = "";
		  assemblyEquipmentTable.EnergyPrice = BigDecimalMath.ZERO;
		  assemblyEquipmentTable.FuelRate = BigDecimalMath.ZERO;
		  assemblyEquipmentTable.LastUpdate = paramAssemblyTable.LastUpdate;
		  long? long = (long?)paramSession.save(assemblyEquipmentTable);
		  assemblyEquipmentTable.AssemblyEquipmentId = long;
		  if (DatabaseDBUtil.LocalCommunication)
		  {
			paramAssemblyTable.AssemblyEquipmentSet.Add(assemblyEquipmentTable);
			paramSession.saveOrUpdate(paramAssemblyTable);
			assemblyEquipmentTable.EquipmentTable = (EquipmentTable)resourceTable;
			assemblyEquipmentTable.AssemblyTable = paramAssemblyTable;
			paramSession.saveOrUpdate(assemblyEquipmentTable);
		  }
		  else
		  {
			assemblyEquipmentTable = (AssemblyEquipmentTable)DatabaseDBUtil.associateAssemblyResource(paramAssemblyTable, (EquipmentTable)resourceTable, assemblyEquipmentTable);
			paramAssemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), paramAssemblyTable.Id);
		  }
		}
		else if (resourceTable is SubcontractorTable)
		{
		  AssemblySubcontractorTable assemblySubcontractorTable = new AssemblySubcontractorTable();
		  assemblySubcontractorTable.Factor1 = BigDecimalMath.ONE;
		  assemblySubcontractorTable.Factor2 = BigDecimalMath.ONE;
		  assemblySubcontractorTable.Factor3 = BigDecimalMath.ONE;
		  assemblySubcontractorTable.ExchangeRate = BigDecimalMath.ONE;
		  assemblySubcontractorTable.QuantityPerUnit = paramMC2ResourceItem.ResourceFactor;
		  assemblySubcontractorTable.QuantityPerUnitFormula = "";
		  assemblySubcontractorTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
		  assemblySubcontractorTable.LocalFactor = BigDecimalMath.ONE;
		  assemblySubcontractorTable.LocalCountry = "";
		  assemblySubcontractorTable.LocalStateProvince = "";
		  assemblySubcontractorTable.LastUpdate = paramAssemblyTable.LastUpdate;
		  long? long = (long?)paramSession.save(assemblySubcontractorTable);
		  assemblySubcontractorTable.AssemblySubcontractorId = long;
		  if (DatabaseDBUtil.LocalCommunication)
		  {
			paramAssemblyTable.AssemblySubcontractorSet.Add(assemblySubcontractorTable);
			paramSession.saveOrUpdate(paramAssemblyTable);
			assemblySubcontractorTable.SubcontractorTable = (SubcontractorTable)resourceTable;
			assemblySubcontractorTable.AssemblyTable = paramAssemblyTable;
			paramSession.saveOrUpdate(assemblySubcontractorTable);
		  }
		  else
		  {
			assemblySubcontractorTable = (AssemblySubcontractorTable)DatabaseDBUtil.associateAssemblyResource(paramAssemblyTable, (SubcontractorTable)resourceTable, assemblySubcontractorTable);
			paramAssemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), paramAssemblyTable.Id);
		  }
		}
		else if (resourceTable is MaterialTable)
		{
		  AssemblyMaterialTable assemblyMaterialTable = new AssemblyMaterialTable();
		  assemblyMaterialTable.Factor1 = BigDecimalMath.ONE;
		  assemblyMaterialTable.Factor2 = BigDecimalMath.ONE;
		  assemblyMaterialTable.Factor3 = BigDecimalMath.ONE;
		  assemblyMaterialTable.ExchangeRate = BigDecimalMath.ONE;
		  assemblyMaterialTable.QuantityPerUnit = paramMC2ResourceItem.ResourceFactor;
		  assemblyMaterialTable.QuantityPerUnitFormula = "";
		  assemblyMaterialTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
		  assemblyMaterialTable.LocalFactor = BigDecimalMath.ONE;
		  assemblyMaterialTable.LocalCountry = "";
		  assemblyMaterialTable.LocalStateProvince = "";
		  assemblyMaterialTable.LastUpdate = paramAssemblyTable.LastUpdate;
		  long? long = (long?)paramSession.save(assemblyMaterialTable);
		  assemblyMaterialTable.AssemblyMaterialId = long;
		  if (DatabaseDBUtil.LocalCommunication)
		  {
			paramAssemblyTable.AssemblyMaterialSet.Add(assemblyMaterialTable);
			paramSession.saveOrUpdate(paramAssemblyTable);
			assemblyMaterialTable.MaterialTable = (MaterialTable)resourceTable;
			assemblyMaterialTable.AssemblyTable = paramAssemblyTable;
			paramSession.saveOrUpdate(assemblyMaterialTable);
		  }
		  else
		  {
			assemblyMaterialTable = (AssemblyMaterialTable)DatabaseDBUtil.associateAssemblyResource(paramAssemblyTable, (MaterialTable)resourceTable, assemblyMaterialTable);
			paramAssemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), paramAssemblyTable.Id);
		  }
		}
		else if (resourceTable is ConsumableTable)
		{
		  AssemblyConsumableTable assemblyConsumableTable = new AssemblyConsumableTable();
		  assemblyConsumableTable.Factor1 = BigDecimalMath.ONE;
		  assemblyConsumableTable.Factor2 = BigDecimalMath.ONE;
		  assemblyConsumableTable.Factor3 = BigDecimalMath.ONE;
		  assemblyConsumableTable.ExchangeRate = BigDecimalMath.ONE;
		  assemblyConsumableTable.QuantityPerUnit = paramMC2ResourceItem.ResourceFactor;
		  assemblyConsumableTable.QuantityPerUnitFormula = "";
		  assemblyConsumableTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;
		  assemblyConsumableTable.LocalFactor = BigDecimalMath.ONE;
		  assemblyConsumableTable.LocalCountry = "";
		  assemblyConsumableTable.LocalStateProvince = "";
		  assemblyConsumableTable.LastUpdate = paramAssemblyTable.LastUpdate;
		  long? long = (long?)paramSession.save(assemblyConsumableTable);
		  assemblyConsumableTable.AssemblyConsumableId = long;
		  if (DatabaseDBUtil.LocalCommunication)
		  {
			paramAssemblyTable.AssemblyConsumableSet.Add(assemblyConsumableTable);
			paramSession.saveOrUpdate(paramAssemblyTable);
			assemblyConsumableTable.ConsumableTable = (ConsumableTable)resourceTable;
			assemblyConsumableTable.AssemblyTable = paramAssemblyTable;
			paramSession.saveOrUpdate(assemblyConsumableTable);
		  }
		  else
		  {
			assemblyConsumableTable = (AssemblyConsumableTable)DatabaseDBUtil.associateAssemblyResource(paramAssemblyTable, (ConsumableTable)resourceTable, assemblyConsumableTable);
			paramAssemblyTable = (AssemblyTable)paramSession.load(typeof(AssemblyTable), paramAssemblyTable.Id);
		  }
		}
		return paramAssemblyTable;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadAndCacheLaborsForCrew(org.apache.poi.hssf.usermodel.HSSFSheet paramHSSFSheet, org.hibernate.Session paramSession) throws Exception
	  private void loadAndCacheLaborsForCrew(HSSFSheet paramHSSFSheet, Session paramSession)
	  {
		int i = getRealNumberOfRows(paramHSSFSheet);
		for (int j = 1; j < i; j++)
		{
		  if (j % this.rowsToCommit == 500)
		  {
			paramSession.Transaction.commit();
			paramSession.Transaction.begin();
		  }
		  HSSFRow hSSFRow = paramHSSFSheet.getRow(j);
		  string str1 = notNull(hSSFRow.getCell(0));
		  string str2 = notNull(hSSFRow.getCell(1));
		  string str3 = notNull(hSSFRow.getCell(2));
		  decimal bigDecimal1 = notNullBigDecimal(hSSFRow.getCell(3), 0.0D);
		  decimal bigDecimal2 = notNullBigDecimal(hSSFRow.getCell(4), 0.0D);
		  decimal bigDecimal3 = notNullBigDecimal(hSSFRow.getCell(5), 1.0D);
		  decimal bigDecimal4 = notNullBigDecimal(hSSFRow.getCell(6), 1.0D);
		  LaborTable laborTable = BlankResourceInitializer.createBlankLabor(null);
		  laborTable.Title = str2;
		  laborTable.Unit = "HOUR";
		  laborTable.Rate = bigDecimal1;
		  laborTable.IKA = bigDecimal2;
		  laborTable.Currency = "USD";
		  laborTable.Country = "US";
		  laborTable.Notes = str1;
		  laborTable.Description = str2 + ", CODE: " + str1;
		  laborTable.LastUpdate = this.lastUpdate;
		  laborTable.CreateDate = this.lastUpdate;
		  laborTable.CreateUserId = "admin";
		  laborTable.EditorId = "admin";
		  long? long = (long?)paramSession.save(laborTable.clone());
		  laborTable.Id = long;
		  this.resourceCacheCrew[str1 + "Labor"] = (LaborTable)laborTable.clone();
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadAndCacheMaterialsForCrew(org.apache.poi.hssf.usermodel.HSSFSheet paramHSSFSheet, org.hibernate.Session paramSession) throws Exception
	  private void loadAndCacheMaterialsForCrew(HSSFSheet paramHSSFSheet, Session paramSession)
	  {
		int i = getRealNumberOfRows(paramHSSFSheet);
		bool @bool = false;
		for (int j = 1; j < i; j++)
		{
		  if (j % this.rowsToCommit == 500)
		  {
			paramSession.Transaction.commit();
			paramSession.Transaction.begin();
		  }
		  HSSFRow hSSFRow = paramHSSFSheet.getRow(j);
		  string str1 = notNull(hSSFRow.getCell(0));
		  string str2 = notNull(hSSFRow.getCell(1));
		  string str3 = notNull(hSSFRow.getCell(2));
		  decimal bigDecimal = notNullBigDecimal(hSSFRow.getCell(3), 0.0D);
		  MaterialTable materialTable = BlankResourceInitializer.createBlankMaterial(null);
		  materialTable.Title = str2;
		  materialTable.Unit = str3;
		  materialTable.Rate = bigDecimal;
		  materialTable.Currency = "USD";
		  materialTable.EditorId = "admin";
		  materialTable.Country = "US";
		  materialTable.Notes = str1;
		  materialTable.Description = str2 + ", CODE: " + str1;
		  materialTable.LastUpdate = this.lastUpdate;
		  materialTable.CreateDate = this.lastUpdate;
		  materialTable.CreateUserId = "admin";
		  long? long = (long?)paramSession.save(materialTable.clone());
		  materialTable.Id = long;
		  this.resourceCacheCrew[str1 + "Material"] = (MaterialTable)materialTable.clone();
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadAndCacheSubcontractsForCrew(org.apache.poi.hssf.usermodel.HSSFSheet paramHSSFSheet, org.hibernate.Session paramSession) throws Exception
	  private void loadAndCacheSubcontractsForCrew(HSSFSheet paramHSSFSheet, Session paramSession)
	  {
		int i = getRealNumberOfRows(paramHSSFSheet);
		bool @bool = false;
		for (int j = 1; j < i; j++)
		{
		  if (j % this.rowsToCommit == 500)
		  {
			paramSession.Transaction.commit();
			paramSession.Transaction.begin();
		  }
		  HSSFRow hSSFRow = paramHSSFSheet.getRow(j);
		  string str1 = notNull(hSSFRow.getCell(0));
		  string str2 = notNull(hSSFRow.getCell(1));
		  string str3 = notNull(hSSFRow.getCell(2));
		  decimal bigDecimal = notNullBigDecimal(hSSFRow.getCell(3), 0.0D);
		  SubcontractorTable subcontractorTable = BlankResourceInitializer.createBlankSubcontractor(null);
		  subcontractorTable.Title = str2;
		  subcontractorTable.Unit = str3;
		  subcontractorTable.Rate = bigDecimal;
		  subcontractorTable.SubMaterialRate = BigDecimalMath.ZERO;
		  subcontractorTable.IKA = BigDecimalMath.ZERO;
		  subcontractorTable.Currency = "USD";
		  subcontractorTable.EditorId = "admin";
		  subcontractorTable.Country = "US";
		  subcontractorTable.Notes = str1;
		  subcontractorTable.Description = str2 + ", CODE: " + str1;
		  subcontractorTable.LastUpdate = this.lastUpdate;
		  subcontractorTable.CreateDate = this.lastUpdate;
		  subcontractorTable.CreateUserId = "admin";
		  long? long = (long?)paramSession.save(subcontractorTable.clone());
		  subcontractorTable.Id = long;
		  this.resourceCacheCrew[str1 + "Subcontract"] = (SubcontractorTable)subcontractorTable.clone();
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadAndCacheEquipmentForCrew(org.apache.poi.hssf.usermodel.HSSFSheet paramHSSFSheet, org.hibernate.Session paramSession, boolean paramBoolean) throws Exception
	  private void loadAndCacheEquipmentForCrew(HSSFSheet paramHSSFSheet, Session paramSession, bool paramBoolean)
	  {
		int i = getRealNumberOfRows(paramHSSFSheet);
		bool @bool = false;
		for (int j = 1; j < i; j++)
		{
		  if (j % this.rowsToCommit == 500)
		  {
			paramSession.Transaction.commit();
			paramSession.Transaction.begin();
		  }
		  HSSFRow hSSFRow = paramHSSFSheet.getRow(j);
		  string str1 = notNull(hSSFRow.getCell(0));
		  string str2 = notNull(hSSFRow.getCell(1));
		  string str3 = notNull(hSSFRow.getCell(2));
		  string str4 = str3.ToLower();
		  decimal bigDecimal = notNullBigDecimal(hSSFRow.getCell(3), 0.0D);
		  SubcontractorTable subcontractorTable = BlankResourceInitializer.createBlankEquipment(null);
		  if (str4.Equals("hour") || str4.Equals("hr") || str4.Equals("day") || str4.Equals("week") || str4.Equals("wk") || str4.Equals("month") || str4.Equals("mo"))
		  {
			subcontractorTable = BlankResourceInitializer.createBlankEquipment(null);
			if (str4.Equals("day"))
			{
			  bigDecimal = BigDecimalMath.mult(bigDecimal, BigDecimalMath.div(BigDecimalMath.ONE, HOURS_OF_DAY));
			}
			else if (str4.Equals("week") || str4.Equals("wk"))
			{
			  bigDecimal = BigDecimalMath.mult(bigDecimal, BigDecimalMath.div(BigDecimalMath.ONE, HOURS_OF_WEEK));
			}
			else if (str4.Equals("month") || str4.Equals("mo"))
			{
			  bigDecimal = BigDecimalMath.mult(bigDecimal, BigDecimalMath.div(BigDecimalMath.ONE, HOURS_OF_MONTH));
			}
			subcontractorTable.Unit = "HOUR";
			if (paramBoolean)
			{
			  ((EquipmentTable)subcontractorTable).ReservationRate = bigDecimal;
			  ((EquipmentTable)subcontractorTable).FuelType = "OTHER";
			}
			else
			{
			  ((EquipmentTable)subcontractorTable).LubricatesRate = bigDecimal;
			}
			((EquipmentTable)subcontractorTable).Currency = "USD";
			((EquipmentTable)subcontractorTable).Country = "US";
		  }
		  else
		  {
			subcontractorTable = BlankResourceInitializer.createBlankSubcontractor(null);
			subcontractorTable.Unit = str4;
			((SubcontractorTable)subcontractorTable).Rate = bigDecimal;
			((SubcontractorTable)subcontractorTable).Currency = "USD";
			((SubcontractorTable)subcontractorTable).Country = "US";
		  }
		  subcontractorTable.Title = str2;
		  subcontractorTable.EditorId = "admin";
		  subcontractorTable.Notes = str1;
		  subcontractorTable.Description = str2 + ", CODE: " + str1;
		  subcontractorTable.LastUpdate = this.lastUpdate;
		  subcontractorTable.CreateDate = this.lastUpdate;
		  subcontractorTable.CreateUserId = "admin";
		  long? long = (long?)paramSession.save(subcontractorTable.clone());
		  subcontractorTable.Id = long;
		  this.resourceCacheCrew[str1 + (paramBoolean ? "Equipment Rental" : "Equipment")] = (ResourceTable)subcontractorTable.clone();
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadAndCacheConsumablesForCrew(org.apache.poi.hssf.usermodel.HSSFSheet paramHSSFSheet, org.hibernate.Session paramSession) throws Exception
	  private void loadAndCacheConsumablesForCrew(HSSFSheet paramHSSFSheet, Session paramSession)
	  {
		int i = getRealNumberOfRows(paramHSSFSheet);
		bool @bool = false;
		for (int j = 1; j < i; j++)
		{
		  if (j % this.rowsToCommit == 500)
		  {
			paramSession.Transaction.commit();
			paramSession.Transaction.begin();
		  }
		  HSSFRow hSSFRow = paramHSSFSheet.getRow(j);
		  string str1 = notNull(hSSFRow.getCell(0));
		  string str2 = notNull(hSSFRow.getCell(1));
		  string str3 = notNull(hSSFRow.getCell(2));
		  decimal bigDecimal = notNullBigDecimal(hSSFRow.getCell(3), 0.0D);
		  ConsumableTable consumableTable = BlankResourceInitializer.createBlankConsumable(null);
		  consumableTable.Title = str2;
		  consumableTable.Unit = str3;
		  consumableTable.Rate = bigDecimal;
		  consumableTable.Currency = "USD";
		  consumableTable.EditorId = "admin";
		  consumableTable.Country = "US";
		  consumableTable.Notes = str1;
		  consumableTable.Description = str2 + ", CODE: " + str1;
		  consumableTable.LastUpdate = this.lastUpdate;
		  consumableTable.CreateDate = this.lastUpdate;
		  consumableTable.CreateUserId = "admin";
		  long? long = (long?)paramSession.save(consumableTable.clone());
		  consumableTable.Id = long;
		  this.resourceCacheCrew[str1 + "Temporary Material"] = (ResourceTable)consumableTable.clone();
		}
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
		  new MC2MigrationUtil(paramString1, paramString2, paramString3, paramString4);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\MC2MigrationUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}