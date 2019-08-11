using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Desktop.common.nomitech.common
{
	using ProjectPropertyTable = Desktop.common.nomitech.common.db.local.ProjectPropertyTable;
	using ProjectUserPropertyTable = Desktop.common.nomitech.common.db.project.ProjectUserPropertyTable;
	using AddOnUtil = Desktop.common.nomitech.common.util.AddOnUtil;
	using IPToCountryUtil = Desktop.common.nomitech.common.util.IPToCountryUtil;
	using StringUtils = Desktop.common.nomitech.common.util.StringUtils;
	using Transaction = org.hibernate.Transaction;

	public class ProjectDBProperties : Properties
	{
	  private const long serialVersionUID = 1L;

	  public static string PROPERTIES_VERSION = "6.3.0";

	  public static readonly string[] FIELDS = new string[] {"project.code", "project.name", "project.revision", "project.eps", "project.accessmode", "project.unit", "project.floors", "project.description", "project.client", "project.country", "project.contractor.name", "project.contractor.signature", "project.contractor.logo", "project.client.name", "project.client.budget", "project.client.duration", "project.location", "project.geolocation", "project.state.province", "project.diesel.price", "project.petrol.price", "project.electricity.price", "project.other.energy.price", "project.energy.prices.use", "project.lube.price", "project.calculation.manual", "project.workspacetype", "project.currency.rss", "project.main.site.mobilization", "project.office.installation", "project.office.equipment", "project.onshore.equipment.transportation", "project.offshore.equipment.transportation", "project.transportation.oftools", "project.mobilization.misc", "project.expatriate.accomodation", "project.tcn.camp", "project.main.site.running", "project.general.use.equipment", "project.salaries", "project.salaries.iscalculated", "project.salaries.job.title", "project.salaries.salary", "project.salaries.months", "project.salaries.insuranceandtax", "project.demobilization", "project.various", "project.engineer.services", "project.electricity.bills", "project.phone.bills", "project.water.bills", "project.itsupport", "project.supplies", "project.msr.misc", "project.agent.case1", "project.withholdings.case1", "project.insurance.case1", "project.financing.case1", "project.bonds.case1", "project.taxes.case1", "project.head.office.case1", "project.risk.and.profit.case1", "project.agent.case2", "project.withholdings.case2", "project.insurance.case2", "project.financing.case2", "project.bonds.case2", "project.taxes.case2", "project.head.office.case2", "project.risk.and.profit.case2", "project.agent.case3", "project.withholdings.case3", "project.insurance.case3", "project.financing.case3", "project.bonds.case3", "project.taxes.case3", "project.head.office.case3", "project.risk.and.profit.case3", "project.bonds.calculator.use", "project.hellenicBonds.p", "project.hellenicBonds.v", "project.hellenicBonds.e", "project.hellenicBonds.c", "project.submission.date", "project.currency.symbol", "project.decimal.scale", "project.divider.scale", "project.rounding.mode", "boqitem.columns", "boqitem.column.widths", "boqitem.sort.index", "boqitem.sort.typeup", "boqitem.category.type", "boqitem.header.autoresize", "boqitem.header.rowheight", "boqitem.labor.columns", "boqitem.labor.column.widths", "boqitem.labor.sort.index", "boqitem.labor.sort.typeup", "boqitem.labor.header.autoresize", "boqitem.labor.header.rowheight", "boqitem.consumable.columns", "boqitem.consumable.column.widths", "boqitem.consumable.sort.index", "boqitem.consumable.sort.typeup", "boqitem.consumable.header.autoresize", "boqitem.consumable.header.rowheight", "boqitem.condition.columns", "boqitem.condition.column.widths", "boqitem.condition.sort.index", "boqitem.condition.sort.typeup", "boqitem.condition.header.autoresize", "boqitem.condition.header.rowheight", "boqitem.quotes.columns", "boqitem.quotes.column.widths", "boqitem.quotes.sort.index", "boqitem.quotes.sort.typeup", "boqitem.quotes.header.autoresize", "boqitem.quotes.header.rowheight", "primavera.connected", "primavera.username", "primavera.password", "primavera.isremote", "primavera.host", "primavera.port", "primavera.type", "primavera.database", "boqitem.subcontractor.columns", "boqitem.subcontractor.column.widths", "boqitem.subcontractor.sort.index", "boqitem.subcontractor.sort.typeup", "boqitem.subcontractor.header.autoresize", "boqitem.subcontractor.header.rowheight", "boqitem.equipment.columns", "boqitem.equipment.column.widths", "boqitem.equipment.sort.index", "boqitem.equipment.sort.typeup", "boqitem.equipment.header.autoresize", "boqitem.equipment.header.rowheight", "boqitem.material.columns", "boqitem.material.column.widths", "boqitem.material.sort.index", "boqitem.material.sort.typeup", "boqitem.material.header.autoresize", "boqitem.material.header.rowheight", "boqitem.assembly.columns", "boqitem.assembly.column.widths", "boqitem.assembly.sort.index", "boqitem.assembly.sort.typeup", "boqitem.assembly.header.autoresize", "boqitem.assembly.header.rowheight", "costos.estimating.version"};

	  private File o_propFile = null;

	  private ProjectDBUtil o_prjDBUtil = null;

	  private string previousVersion = null;

	  private bool manualCalculation = false;

	  [Obsolete]
	  public ProjectDBProperties(string paramString)
	  {
		this.o_propFile = new File(paramString);
		if (this.o_propFile.File)
		{
		  try
		  {
			loadDBProperties(new FileStream(this.o_propFile, FileMode.Open, FileAccess.Read));
		  }
		  catch (Exception)
		  {
			createDBProperties();
			try
			{
			  storeDBProperties();
			}
			catch (Exception)
			{
			}
		  }
		}
		else
		{
		  createDBProperties();
		  try
		  {
			storeDBProperties();
		  }
		  catch (Exception)
		  {
		  }
		}
	  }

	  public ProjectDBProperties(ProjectDBUtil paramProjectDBUtil, string paramString)
	  {
		this.o_prjDBUtil = paramProjectDBUtil;
		File file = new File(paramString);
		if (file.File)
		{
		  try
		  {
			loadDBProperties(new FileStream(file, FileMode.Open, FileAccess.Read));
			storeDBProperties();
		  }
		  catch (Exception)
		  {
			createDBProperties();
			try
			{
			  storeDBProperties();
			}
			catch (Exception)
			{
			}
		  }
		}
		else
		{
		  createDBProperties();
		  try
		  {
			storeDBProperties();
		  }
		  catch (Exception)
		  {
		  }
		}
	  }

	  public ProjectDBProperties(ProjectDBUtil paramProjectDBUtil, bool paramBoolean)
	  {
		createDBProperties();
		this.o_prjDBUtil = paramProjectDBUtil;
		if (paramBoolean)
		{
		  reloadProperties();
		}
	  }

	  public virtual void reloadProperties()
	  {
		if (this.o_prjDBUtil == null)
		{
		  return;
		}
		string str = "from ProjectPropertyTable as o where o.projectId = " + this.o_prjDBUtil.ProjectUrlId;
		if (this.o_prjDBUtil is ProjectFileDBUtil)
		{
		  str = "from ProjectPropertyTable as o";
		}
		foreach (ProjectPropertyTable projectPropertyTable in this.o_prjDBUtil.currentSession().createQuery(str).list())
		{
		  setProperty(projectPropertyTable.PropKey, projectPropertyTable.PropValue);
		}
		str = "from ProjectUserPropertyTable as o where o.projectId = " + this.o_prjDBUtil.ProjectUrlId + " and o.userId like :userId";
		if (this.o_prjDBUtil is ProjectFileDBUtil)
		{
		  str = "from ProjectUserPropertyTable as o where o.userId like :userId";
		}
		foreach (ProjectUserPropertyTable projectUserPropertyTable in this.o_prjDBUtil.currentSession().createQuery(str).setString("userId", DatabaseDBUtil.Properties.UserId).list())
		{
		  setProperty(projectUserPropertyTable.PropKey, projectUserPropertyTable.PropValue);
		}
		this.o_prjDBUtil.closeSession();
		try
		{
		  processLoadedProperties();
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
	  }

	  public virtual void createDBProperties()
	  {
		for (sbyte b = 0; b < FIELDS.Length; b++)
		{
		  setProperty(FIELDS[b], "");
		}
		ManualCalculation = false;
		setProperty("project.currency.rss", "themoneyconverter.com");
		setProperty("costos.estimating.version", PROPERTIES_VERSION);
	  }

	  public virtual void storeDBProperties()
	  {
		  storeDBProperties(true, true);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void storeDBProperties(boolean paramBoolean1, boolean paramBoolean2) throws Exception
	  public virtual void storeDBProperties(bool paramBoolean1, bool paramBoolean2)
	  {
		if (this.o_propFile == null)
		{
		  string str = DatabaseDBUtil.Properties.UserId;
		  bool @bool = !this.o_prjDBUtil.DBLoaded ? 1 : 0;
		  if (!this.o_prjDBUtil.DBLoaded)
		  {
			this.o_prjDBUtil.loadDB();
		  }
		  Transaction transaction = this.o_prjDBUtil.currentSession().beginTransaction();
		  try
		  {
			System.Collections.IDictionary map1 = loadProjectPropertiesMap();
			System.Collections.IDictionary map2 = loadProjectUserPropertiesMap();
			bool bool1 = (map2.Count > 0) ? 1 : 0;
			foreach (object @object in keySet())
			{
			  string str1 = @object.ToString();
			  bool bool2 = isUserPropKey(str1);
			  string str2 = base.getProperty(str1.ToString());
			  ProjectPropertyTable projectPropertyTable = (ProjectPropertyTable)map1[str1];
			  ProjectUserPropertyTable projectUserPropertyTable = (ProjectUserPropertyTable)map2[str1];
			  if (projectPropertyTable == null)
			  {
				projectPropertyTable = new ProjectPropertyTable();
				projectPropertyTable.PropKey = str1.ToString();
				projectPropertyTable.PropValue = str2;
				this.o_prjDBUtil.currentSession().save(projectPropertyTable);
			  }
			  else if ((!bool2 || !bool1) && !StringUtils.checkEquality(str2, projectPropertyTable.PropValue))
			  {
				projectPropertyTable.PropKey = str1.ToString();
				projectPropertyTable.PropValue = str2;
				this.o_prjDBUtil.currentSession().update(projectPropertyTable);
			  }
			  if (bool2)
			  {
				if (projectUserPropertyTable == null)
				{
				  projectUserPropertyTable = new ProjectUserPropertyTable();
				  projectUserPropertyTable.PropKey = str1.ToString();
				  projectUserPropertyTable.PropValue = str2;
				  projectUserPropertyTable.UserId = str;
				  this.o_prjDBUtil.currentSession().save(projectUserPropertyTable);
				  continue;
				}
				if (!StringUtils.checkEquality(str2, projectUserPropertyTable.PropValue))
				{
				  projectUserPropertyTable.PropKey = str1.ToString();
				  projectUserPropertyTable.PropValue = str2;
				  this.o_prjDBUtil.currentSession().update(projectUserPropertyTable);
				}
			  }
			}
			transaction.commit();
		  }
		  catch (Exception exception)
		  {
			if (transaction.Active)
			{
			  transaction.rollback();
			}
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
			this.o_prjDBUtil.closeSession();
			if (@bool)
			{
			  this.o_prjDBUtil.unloadDB();
			}
			throw exception;
		  }
		  this.o_prjDBUtil.closeSession();
		  if (@bool)
		  {
			this.o_prjDBUtil.unloadDB();
		  }
		  return;
		}
		try
		{
		  if (!this.o_propFile.File)
		  {
			this.o_propFile.createNewFile();
		  }
		  FileStream fileOutputStream = new FileStream(this.o_propFile, FileMode.Create, FileAccess.Write);
		  store(fileOutputStream, "CostOS Project Properties");
		  fileOutputStream.Flush();
		  fileOutputStream.Close();
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
	  }

	  private IDictionary<string, ProjectPropertyTable> loadProjectPropertiesMap()
	  {
		Hashtable hashMap = new Hashtable();
		string str = "from ProjectPropertyTable as o where o.projectId = " + this.o_prjDBUtil.ProjectUrlId;
		if (this.o_prjDBUtil is ProjectFileDBUtil)
		{
		  str = "from ProjectPropertyTable as o";
		}
		System.Collections.IList list = this.o_prjDBUtil.currentSession().createQuery(str).list();
		foreach (ProjectPropertyTable projectPropertyTable in list)
		{
		  hashMap[projectPropertyTable.PropKey] = projectPropertyTable;
		}
		return hashMap;
	  }

	  private IDictionary<string, ProjectUserPropertyTable> loadProjectUserPropertiesMap()
	  {
		Hashtable hashMap = new Hashtable();
		string str = "from ProjectUserPropertyTable as o where o.projectId = " + this.o_prjDBUtil.ProjectUrlId + " and ";
		if (this.o_prjDBUtil is ProjectFileDBUtil)
		{
		  str = "from ProjectUserPropertyTable as o where ";
		}
		System.Collections.IList list = this.o_prjDBUtil.currentSession().createQuery(str + " o.userId like :userId").setString("userId", DatabaseDBUtil.Properties.UserId).list();
		foreach (ProjectUserPropertyTable projectUserPropertyTable in list)
		{
		  hashMap[projectUserPropertyTable.PropKey] = projectUserPropertyTable;
		}
		return hashMap;
	  }

	  private bool isUserPropKey(string paramString)
	  {
		  return (paramString.StartsWith("boqitem.", StringComparison.Ordinal) || paramString.StartsWith("visualizer.", StringComparison.Ordinal));
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void loadDBProperties(java.io.FileInputStream paramFileInputStream) throws Exception
	  public virtual void loadDBProperties(FileStream paramFileInputStream)
	  {
		load(paramFileInputStream);
		processLoadedProperties();
		paramFileInputStream.Close();
	  }

	  private void processLoadedProperties()
	  {
		if (!base.getProperty("costos.estimating.version").Equals(PROPERTIES_VERSION))
		{
		  if (string.ReferenceEquals(base.getProperty("project.country"), null))
		  {
			setProperty("project.country", "EU");
		  }
		  if (string.ReferenceEquals(base.getProperty("boqitem.condition.columns"), null))
		  {
			setProperty("boqitem.condition.columns", "0;2;3;4;5;10;11;12;13;");
			setProperty("boqitem.condition.column.widths", "420;70;53;76;85;79;74;65;64;");
			setProperty("boqitem.condition.sort.index", "0");
			setProperty("boqitem.condition.sort.typeup", "true");
			setProperty("boqitem.condition.header.autoresize", "true");
			setProperty("boqitem.condition.header.rowheight", "21");
		  }
		  if (string.ReferenceEquals(base.getProperty("boqitem.quotes.columns"), null))
		  {
			setProperty("boqitem.quotes.columns", "1;2;4;15;16;19;21;");
			setProperty("boqitem.quotes.column.widths", "101;345;86;66;72;106;106;");
			setProperty("boqitem.quotes.sort.index", "0");
			setProperty("boqitem.quotes.sort.typeup", "true");
			setProperty("boqitem.quotes.header.autoresize", "true");
			setProperty("boqitem.quotes.header.rowheight", "21");
		  }
		  this.previousVersion = base.getProperty("costos.estimating.version");
		  setProperty("costos.estimating.version", PROPERTIES_VERSION);
		}
		if (!string.ReferenceEquals(PreviousVersion, null) && isOlderVersionFrom(PreviousVersion, "3.8.7"))
		{
		  Console.WriteLine("CONVERTING DATE");
		  SimpleDateFormat simpleDateFormat1 = new SimpleDateFormat("HH:mm:ss d-MMM-yyyy", new Locale("en"));
		  SimpleDateFormat simpleDateFormat2 = new SimpleDateFormat("HH:mm:ss d-MMM-yyyy", new Locale("el"));
		  DateTime date = DateTime.Now;
		  try
		  {
			date = simpleDateFormat1.parse(getProperty("project.submission.date"));
			Console.WriteLine("FOUND ENGLISH: " + date);
		  }
		  catch (Exception)
		  {
			date = simpleDateFormat2.parse(getProperty("project.submission.date"));
			Console.WriteLine("FOUND GREEK: " + date);
		  }
		  setDateProperty("project.submission.date", date);
		}
		if (string.ReferenceEquals(base.getProperty("project.workspacetype"), null))
		{
		  setProperty("project.workspacetype", "Project");
		}
		if (string.ReferenceEquals(base.getProperty("project.accessmode"), null))
		{
		  setProperty("project.accessmode", "CEP File");
		}
		if (string.ReferenceEquals(base.getProperty("project.unit"), null))
		{
		  setProperty("project.unit", "M2");
		}
		if (string.ReferenceEquals(base.getProperty("project.geolocation"), null))
		{
		  double[] arrayOfDouble = IPToCountryUtil.EuropeGeoPosition;
		  setProperty("project.geolocation", arrayOfDouble[0] + "," + arrayOfDouble[1]);
		}
		if (string.ReferenceEquals(base.getProperty("project.floors"), null))
		{
		  setProperty("project.floors", "0");
		}
		if (base.getProperty("boqitem.category.type").Equals("wbs"))
		{
		  setProperty("boqitem.category.type", "wbsCode");
		}
		if (string.ReferenceEquals(base.getProperty("project.calculation.manual"), null))
		{
		  setProperty("project.calculation.manual", "false");
		  this.manualCalculation = false;
		}
		if (string.ReferenceEquals(base.getProperty("time.unit.day1"), null))
		{
		  double d1 = 8.0D;
		  setDoubleProperty("time.unit.day1", d1);
		  setDoubleProperty("time.unit.day2", d1);
		  setDoubleProperty("time.unit.day3", d1);
		  setDoubleProperty("time.unit.day4", d1);
		  setDoubleProperty("time.unit.day5", d1);
		  double d2 = 40.0D;
		  setDoubleProperty("time.unit.week1", d2);
		  setDoubleProperty("time.unit.week2", d2);
		  setDoubleProperty("time.unit.week3", d2);
		  setDoubleProperty("time.unit.week4", d2);
		  setDoubleProperty("time.unit.week5", d2);
		  double d3 = 160.0D;
		  setDoubleProperty("time.unit.month1", d3);
		  setDoubleProperty("time.unit.month2", d3);
		  setDoubleProperty("time.unit.month3", d3);
		  setDoubleProperty("time.unit.month4", d3);
		  setDoubleProperty("time.unit.month5", d3);
		  storeDBProperties();
		}
		string str = base.getProperty("project.code");
		setProperty("project.code", str.ToUpper());
		this.manualCalculation = getBooleanProperty("project.calculation.manual");
		this.previousVersion = base.getProperty("costos.estimating.version");
	  }

	  public virtual bool ManualCalculation
	  {
		  set
		  {
			this.manualCalculation = value;
			setBooleanProperty("project.calculation.manual", value);
		  }
		  get
		  {
			  return this.manualCalculation;
		  }
	  }


	  public virtual void setIntProperty(string paramString, int paramInt)
	  {
		  setProperty(paramString, Convert.ToString(paramInt));
	  }

	  public virtual int getIntProperty(string paramString)
	  {
		try
		{
		  return int.Parse(base.getProperty(paramString));
		}
		catch (System.FormatException)
		{
		  Console.Error.WriteLine("Integer project property \"" + paramString + "\" does not exist, returning 0.");
		  return 0;
		}
	  }

	  public virtual int getIntProperty(string paramString, int paramInt)
	  {
		try
		{
		  string str = base.getProperty(paramString);
		  return StringUtils.isNullOrBlank(str) ? paramInt : int.Parse(str);
		}
		catch (System.FormatException)
		{
		  return paramInt;
		}
	  }

	  public virtual void setDoubleProperty(string paramString, double paramDouble)
	  {
		  setProperty(paramString, Convert.ToString(paramDouble));
	  }

	  public virtual double getDoubleProperty(string paramString)
	  {
		try
		{
		  return double.Parse(base.getProperty(paramString));
		}
		catch (System.FormatException)
		{
		  Console.Error.WriteLine("Double project property \"" + paramString + "\" does not exist, returning 0.");
		  return 0.0D;
		}
	  }

	  public virtual void setLongProperty(string paramString, int paramInt)
	  {
		  setProperty(paramString, Convert.ToString(paramInt));
	  }

	  public virtual long getLongProperty(string paramString)
	  {
		try
		{
		  return long.Parse(base.getProperty(paramString));
		}
		catch (System.FormatException)
		{
		  Console.Error.WriteLine("Integer project property \"" + paramString + "\" does not exist, returning 0.");
		  return 0L;
		}
	  }

	  public virtual string getProperty(string paramString1, string paramString2)
	  {
		string str = base.getProperty(paramString1);
		if (string.ReferenceEquals(str, null))
		{
		  setProperty(paramString1, paramString2);
		  return paramString2;
		}
		return str;
	  }

	  public virtual string getProperty(string paramString)
	  {
		  return base.getProperty(paramString);
	  }

	  public virtual void setEncProperty(string paramString1, string paramString2)
	  {
		  setProperty(paramString1, AddOnUtil.Instance.encryptHexString(paramString2));
	  }

	  public virtual string getEncProperty(string paramString)
	  {
		  return (string.ReferenceEquals(paramString, null) || string.ReferenceEquals(base.getProperty(paramString), null)) ? null : AddOnUtil.Instance.decryptHexString(base.getProperty(paramString));
	  }

	  public virtual void setBooleanProperty(string paramString, bool paramBoolean)
	  {
		  setProperty(paramString, (paramBoolean == true) ? "true" : "false");
	  }

	  public virtual bool getBooleanProperty(string paramString, bool paramBoolean)
	  {
		string str = base.getProperty(paramString);
		if (string.ReferenceEquals(str, null))
		{
		  setProperty(paramString, "" + paramBoolean);
		  return paramBoolean;
		}
		return str.Equals("true");
	  }

	  public virtual bool getBooleanProperty(string paramString)
	  {
		string str = base.getProperty(paramString);
		return (string.ReferenceEquals(str, null)) ? false : (str.Equals("true"));
	  }

	  public virtual Properties Properties
	  {
		  set
		  {
			System.Collections.IEnumerator iterator = value.Keys.GetEnumerator();
			while (iterator.MoveNext())
			{
			  string str = iterator.Current.ToString();
			  setProperty(str, value.getProperty(str));
			}
		  }
	  }

	  public virtual void setIntArrayProperty(string paramString, int[] paramArrayOfInt)
	  {
		string str = "";
		for (sbyte b = 0; b < paramArrayOfInt.Length; b++)
		{
		  str = str + paramArrayOfInt[b] + ";";
		}
		setProperty(paramString, str);
	  }

	  public virtual int[] getIntArrayProperty(string paramString)
	  {
		List<object> vector = new List<object>();
		string str = base.getProperty(paramString);
		if (string.ReferenceEquals(str, null))
		{
		  return new int[0];
		}
		for (sbyte b1 = 0; b1 < str.Length; b1++)
		{
		  for (int i = b1 + true; i <= str.Length; i++)
		  {
			string str1 = str.Substring(b1, i - b1);
			if (str1.EndsWith(";", StringComparison.Ordinal))
			{
			  vector.Add(str.Substring(b1, (i - 1) - b1));
			  b1 = i - 1;
			  i = str.Length;
			}
		  }
		}
		int[] arrayOfInt = new int[vector.Count];
		for (sbyte b2 = 0; b2 < vector.Count; b2++)
		{
		  try
		  {
			arrayOfInt[b2] = int.Parse((string)vector[b2]);
		  }
		  catch (System.FormatException numberFormatException)
		  {
			Console.WriteLine(numberFormatException.ToString());
			Console.Write(numberFormatException.StackTrace);
		  }
		}
		return arrayOfInt;
	  }

	  public virtual void setFontProperty(string paramString, Font paramFont)
	  {
		string str = paramFont.Name;
		int i = paramFont.Style;
		int j = paramFont.Size;
		setProperty(paramString, "" + str + ";" + i + ";" + j + ";");
	  }

	  public virtual Font getFontProperty(string paramString)
	  {
		string str1 = base.getProperty(paramString);
		string str2 = str1.Substring(0, str1.IndexOf(";", StringComparison.Ordinal));
		string str3 = StringHelper.SubstringSpecial(str1, str2.Length + 1, str1.IndexOf(";", str2.Length + 1, StringComparison.Ordinal));
		string str4 = StringHelper.SubstringSpecial(str1, str2.Length + str3.Length + 2, str1.LastIndexOf(";", StringComparison.Ordinal));
		int i = int.Parse(str3);
		int j = int.Parse(str4);
		return new Font(str2, i, j);
	  }

	  public virtual Font getFontProperty(string paramString, Font paramFont)
	  {
		if (string.ReferenceEquals(base.getProperty(paramString), null))
		{
		  setFontProperty(paramString, paramFont);
		  return paramFont;
		}
		return getFontProperty(paramString);
	  }

	  public virtual void setColorProperty(string paramString, Color paramColor)
	  {
		int i = paramColor.Red;
		int j = paramColor.Green;
		int k = paramColor.Blue;
		setProperty(paramString, "" + i + ";" + j + ";" + k + ";");
	  }

	  public virtual Color getColorProperty(string paramString)
	  {
		string str1 = base.getProperty(paramString);
		string str2 = str1.Substring(0, str1.IndexOf(";", StringComparison.Ordinal));
		string str3 = StringHelper.SubstringSpecial(str1, str2.Length + 1, str1.IndexOf(";", str2.Length + 1, StringComparison.Ordinal));
		string str4 = StringHelper.SubstringSpecial(str1, str2.Length + str3.Length + 2, str1.LastIndexOf(";", StringComparison.Ordinal));
		int i = int.Parse(str2);
		int j = int.Parse(str3);
		int k = int.Parse(str4);
		return new Color(i, j, k);
	  }

	  public virtual Color getColorProperty(string paramString, Color paramColor)
	  {
		if (string.ReferenceEquals(base.getProperty(paramString), null))
		{
		  setColorProperty(paramString, paramColor);
		  return paramColor;
		}
		return getColorProperty(paramString);
	  }

	  public virtual void setStringArrayProperty(string paramString, string[] paramArrayOfString)
	  {
		string str = "";
		for (sbyte b = 0; b < paramArrayOfString.Length; b++)
		{
		  str = str + paramArrayOfString[b] + ";";
		}
		setProperty(paramString, str);
	  }

	  public virtual string[] getStringArrayProperty(string paramString)
	  {
		List<object> vector = new List<object>();
		string str = base.getProperty(paramString);
		if (string.ReferenceEquals(str, null))
		{
		  return new string[0];
		}
		for (sbyte b = 0; b < str.Length; b++)
		{
		  for (int i = b + true; i <= str.Length; i++)
		  {
			string str1 = str.Substring(b, i - b);
			if (str1.EndsWith(";", StringComparison.Ordinal))
			{
			  vector.Add(str.Substring(b, (i - 1) - b));
			  b = i - 1;
			  i = str.Length;
			}
		  }
		}
		return (string[])vector.ToArray(typeof(string));
	  }

	  public virtual string PreviousVersion
	  {
		  get
		  {
			  return this.previousVersion;
		  }
		  set
		  {
			  this.previousVersion = value;
		  }
	  }


	  public virtual bool isOlderVersionFromCurrent(string paramString)
	  {
		  return StringUtils.isOlderVersionFrom(paramString, PROPERTIES_VERSION);
	  }

	  public virtual bool isOlderVersionFrom(string paramString1, string paramString2)
	  {
		  return StringUtils.isOlderVersionFrom(paramString1, paramString2);
	  }

	  public static string CostosVersion
	  {
		  set
		  {
			  PROPERTIES_VERSION = value;
		  }
	  }

	  public virtual DateTime getDateProperty(string paramString)
	  {
		try
		{
		  return new DateTime((Convert.ToInt64(base.getProperty(paramString))));
		}
		catch (Exception)
		{
		  Console.WriteLine("I COULD NOT PARSE: " + base.getProperty(paramString));
		  return DateTime.Now;
		}
	  }

	  public virtual void setDateProperty(string paramString, DateTime paramDate)
	  {
		  setProperty(paramString, "" + paramDate.Ticks);
	  }

	  public virtual IDictionary<string, object> convertToMap()
	  {
		System.Collections.IEnumerator enumeration = keys();
		Hashtable hashMap = new Hashtable(size());
		while (enumeration.MoveNext())
		{
		  string str = (string)enumeration.Current;
		  hashMap[str] = base.getProperty(str);
		}
		return hashMap;
	  }

	  public virtual decimal getHoursFromUnit(string paramString)
	  {
		switch (paramString.ToUpper())
		{
		  case "HOUR":
			return decimal.One;
		  case "DAY":
			return new decimal(8.0D);
		  case "DAY1":
			return new decimal((string.ReferenceEquals(getProperty("time.unit.day1"), null)) ? 8.0D : getDoubleProperty("time.unit.day1"));
		  case "DAY2":
			return new decimal((string.ReferenceEquals(getProperty("time.unit.day2"), null)) ? 8.0D : getDoubleProperty("time.unit.day2"));
		  case "DAY3":
			return new decimal((string.ReferenceEquals(getProperty("time.unit.day3"), null)) ? 8.0D : getDoubleProperty("time.unit.day3"));
		  case "DAY4":
			return new decimal((string.ReferenceEquals(getProperty("time.unit.day4"), null)) ? 8.0D : getDoubleProperty("time.unit.day4"));
		  case "DAY5":
			return new decimal((string.ReferenceEquals(getProperty("time.unit.day5"), null)) ? 8.0D : getDoubleProperty("time.unit.day5"));
		  case "WEEK":
			return new decimal(40.0D);
		  case "WEEK1":
			return new decimal((string.ReferenceEquals(getProperty("time.unit.week1"), null)) ? 40.0D : getDoubleProperty("time.unit.week1"));
		  case "WEEK2":
			return new decimal((string.ReferenceEquals(getProperty("time.unit.week2"), null)) ? 40.0D : getDoubleProperty("time.unit.week2"));
		  case "WEEK3":
			return new decimal((string.ReferenceEquals(getProperty("time.unit.week3"), null)) ? 40.0D : getDoubleProperty("time.unit.week3"));
		  case "WEEK4":
			return new decimal((string.ReferenceEquals(getProperty("time.unit.week4"), null)) ? 40.0D : getDoubleProperty("time.unit.week4"));
		  case "WEEK5":
			return new decimal((string.ReferenceEquals(getProperty("time.unit.week5"), null)) ? 40.0D : getDoubleProperty("time.unit.week5"));
		  case "MONTH":
			return new decimal(160.0D);
		  case "MONTH1":
			return new decimal((string.ReferenceEquals(getProperty("time.unit.month1"), null)) ? 160.0D : getDoubleProperty("time.unit.month1"));
		  case "MONTH2":
			return new decimal((string.ReferenceEquals(getProperty("time.unit.month2"), null)) ? 160.0D : getDoubleProperty("time.unit.month2"));
		  case "MONTH3":
			return new decimal((string.ReferenceEquals(getProperty("time.unit.month3"), null)) ? 160.0D : getDoubleProperty("time.unit.month3"));
		  case "MONTH4":
			return new decimal((string.ReferenceEquals(getProperty("time.unit.month4"), null)) ? 160.0D : getDoubleProperty("time.unit.month4"));
		  case "MONTH5":
			return new decimal((string.ReferenceEquals(getProperty("time.unit.month5"), null)) ? 160.0D : getDoubleProperty("time.unit.month5"));
		}
		return decimal.One;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\ProjectDBProperties.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}