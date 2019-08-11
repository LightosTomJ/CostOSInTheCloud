using System;
using System.Collections.Generic;
using System.IO;

namespace Desktop.common.nomitech.common.migration.rsmeans
{
	using LocalizationFactorTable = nomitech.common.db.local.LocalizationFactorTable;
	using LocalizationProfileTable = nomitech.common.db.local.LocalizationProfileTable;
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using LocationData = nomitech.common.migration.location.LocationData;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	using StringUtils = nomitech.common.util.StringUtils;
	using Transaction = org.hibernate.Transaction;

	public class CCIToLocalizationLoader
	{
	  private long? localizationProfileId = null;

	  private bool online;

	  public const string CCI14 = "CCI2014";

	  public const string CCI17 = "CCI2017";

	  private string CCI;

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private CCIToLocalizationLoader(String paramString1, boolean paramBoolean, String paramString2) throws Exception
	  private CCIToLocalizationLoader(string paramString1, bool paramBoolean, string paramString2)
	  {
		this.online = paramBoolean;
		this.CCI = paramString2;
		File file1 = new File(paramString1 + File.separator + "City Cost Index" + File.separator + paramString2 + ".up");
		File file2 = new File(paramString1 + File.separator + "City Cost Index" + File.separator + paramString2 + ".sys");
		try
		{
		  DatabaseDBUtil.currentSession().beginTransaction();
		  Console.WriteLine("PROCESSING: " + file1.AbsolutePath);
		  loadCCI(file1, "US", "extraCode1", "RSMeans Unit Cost Base");
		  Transaction transaction = DatabaseDBUtil.currentSession().Transaction;
		  transaction.commit();
		  DatabaseDBUtil.currentSession().beginTransaction();
		  Console.WriteLine("PROCESSING: " + file2.AbsolutePath);
		  loadCCI(file2, "US", "extraCode3", "RSMeans Assemblies Base");
		  transaction = DatabaseDBUtil.currentSession().Transaction;
		  transaction.commit();
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  Transaction transaction = DatabaseDBUtil.currentSession().Transaction;
		  if (transaction.Active)
		  {
			transaction.rollback();
		  }
		  DatabaseDBUtil.closeSession();
		  throw exception;
		}
		DatabaseDBUtil.closeSession();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadCCI(java.io.File paramFile, String paramString1, String paramString2, String paramString3) throws Exception
	  private void loadCCI(File paramFile, string paramString1, string paramString2, string paramString3)
	  {
		StreamReader bufferedReader = new StreamReader(paramFile);
		LocalizationProfileTable localizationProfileTable = new LocalizationProfileTable();
		localizationProfileTable.SupportsState = false;
		localizationProfileTable.ProfileName = paramString3;
		localizationProfileTable.CreateDate = DateTime.Now;
		localizationProfileTable.LastUpdate = DateTime.Now;
		localizationProfileTable.CreateUserId = "rsmeans";
		localizationProfileTable.EditorId = "rsmeans";
		localizationProfileTable.FromCountry = "US";
		localizationProfileTable.FromState = "US AVERAGE";
		long? long = (long?)DatabaseDBUtil.currentSession().save(localizationProfileTable);
		localizationProfileTable = (LocalizationProfileTable)DatabaseDBUtil.currentSession().load(typeof(LocalizationProfileTable), long);
		this.localizationProfileId = long;
		if (localizationProfileTable.Factors == null)
		{
		  localizationProfileTable.Factors = new List<object>();
		}
		sbyte b = 0;
		while (true)
		{
		  string str1 = bufferedReader.ReadLine();
		  if (string.ReferenceEquals(str1, null))
		  {
			break;
		  }
		  string str2 = str1.Substring(0, 4);
		  string str3 = str1.Substring(4, 3);
		  string str4 = str1.Substring(7, 2);
		  string str5 = StringUtils.removeSpacesFromEnd(str1.Substring(9, 23));
		  string str6 = str1.Substring(32, 3);
		  string str7 = StringUtils.removeSpacesFromStart(str1.Substring(35, 12));
		  string str8 = StringUtils.removeSpacesFromStart(str1.Substring(47, 12));
		  string str9 = StringUtils.removeSpacesFromStart(str1.Substring(59, 12));
		  LocalizationFactorTable localizationFactorTable = new LocalizationFactorTable();
		  localizationFactorTable.AssemblyFactor = BigDecimalMath.ONE;
		  localizationFactorTable.EquipmentFactor = BigDecimalMath.ONE;
		  localizationFactorTable.Online = true;
		  localizationFactorTable.EditorId = "rsmeans";
		  localizationFactorTable.SubcontractorFactor = BigDecimalMath.ONE;
		  localizationFactorTable.LaborFactor = new BigDecimalFixed(str8);
		  localizationFactorTable.MaterialFactor = new BigDecimalFixed(str7);
		  localizationFactorTable.ConsumableFactor = BigDecimalMath.ONE;
		  LocationData locationData = null;
		  if (locationData == null)
		  {
			locationData = new LocationData();
			locationData.City = str5.ToUpper();
			locationData.State = str4.ToUpper();
			locationData.Country = paramString1;
			locationData.ZipCode = str3;
			locationData.GeoPolygon = "";
			Console.WriteLine("LOADED: " + str3 + ", " + str4 + ", " + str5 + "," + paramString1);
		  }
		  localizationFactorTable.ToCountry = locationData.Country;
		  localizationFactorTable.ToState = locationData.State;
		  localizationFactorTable.ToCity = locationData.City;
		  localizationFactorTable.ToZipCode = locationData.ZipCode;
		  localizationFactorTable.GroupCodeName = paramString2;
		  localizationFactorTable.ParentCode = str6;
		  localizationFactorTable.GeoPolygon = locationData.GeoPolygon;
		  localizationFactorTable.LocalizationProfileTable = localizationProfileTable;
		  localizationProfileTable.Factors.Add(localizationFactorTable);
		  DatabaseDBUtil.currentSession().save(localizationFactorTable);
		  if (++b % 'Ǵ' == 'ǳ')
		  {
			DatabaseDBUtil.currentSession().Transaction.commit();
			DatabaseDBUtil.currentSession().beginTransaction();
			Console.WriteLine("Committed " + b + " factors");
		  }
		}
		bufferedReader.Close();
		DatabaseDBUtil.currentSession().update(localizationProfileTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static System.Nullable<long> loadUnitCCI(String paramString1, boolean paramBoolean, String paramString2) throws Exception
	  public static long? loadUnitCCI(string paramString1, bool paramBoolean, string paramString2)
	  {
		  return (new CCIToLocalizationLoader(paramString1, paramBoolean, paramString2)).localizationProfileId;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\rsmeans\CCIToLocalizationLoader.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}