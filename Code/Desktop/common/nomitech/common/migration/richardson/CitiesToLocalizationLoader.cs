using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.migration.richardson
{
	using LocalizationFactorTable = nomitech.common.db.local.LocalizationFactorTable;
	using LocalizationProfileTable = nomitech.common.db.local.LocalizationProfileTable;
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using LocationData = nomitech.common.migration.location.LocationData;
	using LocationDataRetriever = nomitech.common.migration.location.LocationDataRetriever;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;

	public class CitiesToLocalizationLoader
	{
	  private Connection con;

	  private IDictionary<string, RichardsonCity> citiesMap = new Hashtable();

	  private IDictionary<string, double> averagesMap = new Hashtable();

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private CitiesToLocalizationLoader(java.sql.Connection paramConnection) throws Exception
	  private CitiesToLocalizationLoader(Connection paramConnection)
	  {
		this.con = paramConnection;
		Console.WriteLine("Caching cities...");
		loadCities();
		Console.WriteLine("Caching averages...");
		loadAverages();
		Console.WriteLine("Loading the location profile...");
		try
		{
		  loadProfile();
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  DatabaseDBUtil.currentSession().Transaction.rollback();
		  DatabaseDBUtil.closeSession();
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadCities() throws Exception
	  private void loadCities()
	  {
		string str = "SELECT * FROM CITIES";
		PreparedStatement preparedStatement = this.con.prepareStatement(str);
		ResultSet resultSet = preparedStatement.executeQuery();
		while (resultSet.next())
		{
		  string str1 = resultSet.getString(1);
		  string str2 = resultSet.getString(2);
		  string str3 = resultSet.getString(3);
		  string str4 = resultSet.getString(4);
		  string str5 = resultSet.getString(5);
		  string str6 = resultSet.getString(6);
		  string str7 = resultSet.getString(7);
		  string str8 = resultSet.getString(8);
		  this.citiesMap[str8] = new RichardsonCity(this, str1, str2, str3, str4, str5, str6, str7, str8);
		}
		preparedStatement.close();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadAverages() throws Exception
	  private void loadAverages()
	  {
		string str = "SELECT CRAFT_ID,BASE,FRINGES FROM CRAFT WHERE city_id = '0RICH0'";
		PreparedStatement preparedStatement = this.con.prepareStatement(str);
		ResultSet resultSet = preparedStatement.executeQuery();
		while (resultSet.next())
		{
		  string str1 = resultSet.getString(1);
		  double? double1;
		  double? double2;
		  this.averagesMap[str1] = (double2 = (double1 = Convert.ToDouble(resultSet.getDouble(2))).valueOf(resultSet.getDouble(3))).valueOf(double1.Value + double2.Value);
		}
		preparedStatement.close();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void loadProfile() throws Exception
	  private void loadProfile()
	  {
		DatabaseDBUtil.currentSession().beginTransaction();
		LocalizationProfileTable localizationProfileTable = new LocalizationProfileTable();
		localizationProfileTable.SupportsState = false;
		localizationProfileTable.ProfileName = "Richardson Base";
		localizationProfileTable.CreateDate = DateTime.Now;
		localizationProfileTable.LastUpdate = DateTime.Now;
		localizationProfileTable.CreateUserId = "richardson";
		localizationProfileTable.EditorId = "richardson";
		localizationProfileTable.FromCountry = "US";
		localizationProfileTable.FromState = "US AVERAGE";
		long? long = (long?)DatabaseDBUtil.currentSession().save(localizationProfileTable);
		localizationProfileTable = (LocalizationProfileTable)DatabaseDBUtil.currentSession().load(typeof(LocalizationProfileTable), long);
		if (localizationProfileTable.Factors == null)
		{
		  localizationProfileTable.Factors = new List<object>();
		}
		string str = "SELECT * FROM CRAFT";
		PreparedStatement preparedStatement = this.con.prepareStatement(str);
		ResultSet resultSet = preparedStatement.executeQuery();
		sbyte b = 0;
		while (resultSet.next())
		{
		  int? integer = Convert.ToInt32(resultSet.getInt(1));
		  string str1 = resultSet.getString(2);
		  string str2 = resultSet.getString(3);
		  string str3 = resultSet.getString(4);
		  double? double1;
		  double? double2 = (double1 = Convert.ToDouble(resultSet.getDouble(5))).valueOf(resultSet.getDouble(6));
		  string str4 = resultSet.getString(7);
		  if (str1.Equals("0RICH0"))
		  {
			continue;
		  }
		  double? double3 = (double?)this.averagesMap[str3];
		  RichardsonCity richardsonCity = (RichardsonCity)this.citiesMap[str1];
		  double d = (double1.Value + double2.Value) / double3.Value;
		  LocalizationFactorTable localizationFactorTable = new LocalizationFactorTable();
		  localizationFactorTable.AssemblyFactor = BigDecimalMath.ONE;
		  localizationFactorTable.EquipmentFactor = BigDecimalMath.ONE;
		  localizationFactorTable.Online = true;
		  localizationFactorTable.EditorId = "richardson";
		  localizationFactorTable.SubcontractorFactor = BigDecimalMath.ONE;
		  localizationFactorTable.LaborFactor = new BigDecimalFixed("" + d);
		  localizationFactorTable.MaterialFactor = BigDecimalMath.ONE;
		  localizationFactorTable.ConsumableFactor = BigDecimalMath.ONE;
		  string str5 = richardsonCity.CountryCode;
		  if (str5.Equals("USA"))
		  {
			str5 = "US";
		  }
		  else if (str5.Equals("CAN"))
		  {
			str5 = "CA";
		  }
		  LocationData locationData = LocationDataRetriever.Instance.retrieveForNorthAmericaData(richardsonCity.ZipCode, richardsonCity.StateCode, richardsonCity.City, str5);
		  if (locationData == null)
		  {
			Console.WriteLine("NO LOCATION DATA FOUND FOR: " + richardsonCity);
			continue;
		  }
		  localizationFactorTable.ToCountry = locationData.Country;
		  localizationFactorTable.ToState = locationData.State;
		  localizationFactorTable.ToCity = locationData.City;
		  localizationFactorTable.ToZipCode = locationData.ZipCode;
		  localizationFactorTable.GroupCodeName = "";
		  localizationFactorTable.ParentCode = str3;
		  localizationFactorTable.GeoPolygon = locationData.GeoPolygon;
		  localizationFactorTable.LocalizationProfileTable = localizationProfileTable;
		  localizationProfileTable.Factors.Add(localizationFactorTable);
		  Console.WriteLine("I AM SAVING: " + localizationFactorTable.ToCountry + ", " + localizationFactorTable.ToState + ", " + localizationFactorTable.ToCity + ", " + localizationFactorTable.ToZipCode);
		  DatabaseDBUtil.currentSession().save(localizationFactorTable);
		  if (++b % 'Ǵ' == 'ǳ')
		  {
			DatabaseDBUtil.currentSession().Transaction.commit();
			DatabaseDBUtil.currentSession().beginTransaction();
			Console.WriteLine("\n\n\n\n\n\nCommitted " + b + " factors");
		  }
		}
		preparedStatement.close();
		DatabaseDBUtil.currentSession().Transaction.commit();
		DatabaseDBUtil.closeSession();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void loadFactors(java.sql.Connection paramConnection) throws Exception
	  public static void loadFactors(Connection paramConnection)
	  {
		  new CitiesToLocalizationLoader(paramConnection);
	  }

	  private class RichardsonCity
	  {
		  private readonly CitiesToLocalizationLoader outerInstance;

		internal string cityAndState;

		internal string stateCode;

		internal string countryCode;

		internal string city;

		internal string county;

		internal string zipCode;

		internal string state;

		internal string cityId;

		public RichardsonCity(CitiesToLocalizationLoader outerInstance, string param1String1, string param1String2, string param1String3, string param1String4, string param1String5, string param1String6, string param1String7, string param1String8)
		{
			this.outerInstance = outerInstance;
		  this.cityAndState = param1String1;
		  this.stateCode = param1String2;
		  this.countryCode = param1String3;
		  this.city = param1String4;
		  this.county = param1String5;
		  this.zipCode = param1String6;
		  this.state = param1String7;
		  this.cityId = param1String8;
		  if (string.ReferenceEquals(param1String4, null))
		  {
			this.city = "";
		  }
		  if (string.ReferenceEquals(param1String6, null))
		  {
			this.zipCode = "";
		  }
		  if (string.ReferenceEquals(param1String5, null))
		  {
			this.county = "";
		  }
		  if (string.ReferenceEquals(param1String7, null))
		  {
			this.state = "";
		  }
		  if (string.ReferenceEquals(param1String2, null))
		  {
			this.stateCode = "";
		  }
		}

		public virtual string CityAndState
		{
			get
			{
				return this.cityAndState;
			}
		}

		public virtual string StateCode
		{
			get
			{
				return this.stateCode;
			}
		}

		public virtual string CountryCode
		{
			get
			{
				return this.countryCode;
			}
		}

		public virtual string City
		{
			get
			{
				return this.city;
			}
		}

		public virtual string County
		{
			get
			{
				return this.county;
			}
		}

		public virtual string ZipCode
		{
			get
			{
				return this.zipCode;
			}
		}

		public virtual string State
		{
			get
			{
				return this.state;
			}
		}

		public virtual string CityId
		{
			get
			{
				return this.cityId;
			}
		}

		public override string ToString()
		{
			return this.countryCode + ", " + this.state + "," + this.county + ", " + this.city + ", " + this.zipCode;
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\richardson\CitiesToLocalizationLoader.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}