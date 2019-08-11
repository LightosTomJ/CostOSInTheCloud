using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.expr
{
	using ArrayAbsArray = Desktop.common.nomitech.common.expr.arrays.ArrayAbsArray;
	using ArrayAddColumn = Desktop.common.nomitech.common.expr.arrays.ArrayAddColumn;
	using ArrayColumnCount = Desktop.common.nomitech.common.expr.arrays.ArrayColumnCount;
	using ArrayColumnIndex = Desktop.common.nomitech.common.expr.arrays.ArrayColumnIndex;
	using ArrayCreate = Desktop.common.nomitech.common.expr.arrays.ArrayCreate;
	using ArrayCreateBlank = Desktop.common.nomitech.common.expr.arrays.ArrayCreateBlank;
	using ArrayDivideArray = Desktop.common.nomitech.common.expr.arrays.ArrayDivideArray;
	using ArrayDivideNumber = Desktop.common.nomitech.common.expr.arrays.ArrayDivideNumber;
	using ArrayFromArrayCustom = Desktop.common.nomitech.common.expr.arrays.ArrayFromArrayCustom;
	using ArrayFromAssemblyArray = Desktop.common.nomitech.common.expr.arrays.ArrayFromAssemblyArray;
	using ArrayFromAssemblyArrayPartial = Desktop.common.nomitech.common.expr.arrays.ArrayFromAssemblyArrayPartial;
	using ArrayFromText = Desktop.common.nomitech.common.expr.arrays.ArrayFromText;
	using ArrayGet = Desktop.common.nomitech.common.expr.arrays.ArrayGet;
	using ArrayGetFirstNumber = Desktop.common.nomitech.common.expr.arrays.ArrayGetFirstNumber;
	using ArrayGetFromAssemblyArray = Desktop.common.nomitech.common.expr.arrays.ArrayGetFromAssemblyArray;
	using ArrayIndex = Desktop.common.nomitech.common.expr.arrays.ArrayIndex;
	using ArrayMerge = Desktop.common.nomitech.common.expr.arrays.ArrayMerge;
	using ArrayMinusArray = Desktop.common.nomitech.common.expr.arrays.ArrayMinusArray;
	using ArrayMinusNumber = Desktop.common.nomitech.common.expr.arrays.ArrayMinusNumber;
	using ArrayMultiplyArray = Desktop.common.nomitech.common.expr.arrays.ArrayMultiplyArray;
	using ArrayMultiplyNumber = Desktop.common.nomitech.common.expr.arrays.ArrayMultiplyNumber;
	using ArrayPlusArray = Desktop.common.nomitech.common.expr.arrays.ArrayPlusArray;
	using ArrayPlusNumber = Desktop.common.nomitech.common.expr.arrays.ArrayPlusNumber;
	using ArrayRowCount = Desktop.common.nomitech.common.expr.arrays.ArrayRowCount;
	using ArrayRowIndex = Desktop.common.nomitech.common.expr.arrays.ArrayRowIndex;
	using ArrayTitle = Desktop.common.nomitech.common.expr.arrays.ArrayTitle;
	using CellValue = Desktop.common.nomitech.common.expr.arrays.CellValue;
	using SubColumnArray = Desktop.common.nomitech.common.expr.arrays.SubColumnArray;
	using SubRowArray = Desktop.common.nomitech.common.expr.arrays.SubRowArray;
	using BoqItemId = Desktop.common.nomitech.common.expr.boqitem.BoqItemId;
	using ExtractCodeLevel = Desktop.common.nomitech.common.expr.codes.ExtractCodeLevel;
	using ExtractCodeLevelFactor = Desktop.common.nomitech.common.expr.codes.ExtractCodeLevelFactor;
	using ExtractCodeLevelNotes = Desktop.common.nomitech.common.expr.codes.ExtractCodeLevelNotes;
	using ExtractCodeLevelUnit = Desktop.common.nomitech.common.expr.codes.ExtractCodeLevelUnit;
	using DATE = Desktop.common.nomitech.common.expr.function.DATE;
	using NowLocal = Desktop.common.nomitech.common.expr.function.NowLocal;
	using POWER = Desktop.common.nomitech.common.expr.function.POWER;
	using SUBSTITUTE = Desktop.common.nomitech.common.expr.function.SUBSTITUTE;
	using TEXT = Desktop.common.nomitech.common.expr.function.TEXT;
	using CityFromLocation = Desktop.common.nomitech.common.expr.location.CityFromLocation;
	using CountryFromLocation = Desktop.common.nomitech.common.expr.location.CountryFromLocation;
	using FactorFromLocation = Desktop.common.nomitech.common.expr.location.FactorFromLocation;
	using StateFromLocation = Desktop.common.nomitech.common.expr.location.StateFromLocation;
	using ZipCodeFromLocation = Desktop.common.nomitech.common.expr.location.ZipCodeFromLocation;
	using ParamItemId = Desktop.common.nomitech.common.expr.paramitem.ParamItemId;
	using ProjectCode = Desktop.common.nomitech.common.expr.project.ProjectCode;
	using ProjectCountry = Desktop.common.nomitech.common.expr.project.ProjectCountry;
	using ProjectCurrency = Desktop.common.nomitech.common.expr.project.ProjectCurrency;
	using ProjectDatabaseName = Desktop.common.nomitech.common.expr.project.ProjectDatabaseName;
	using ProjectDurationInMonths = Desktop.common.nomitech.common.expr.project.ProjectDurationInMonths;
	using ProjectHQL = Desktop.common.nomitech.common.expr.project.ProjectHQL;
	using ProjectId = Desktop.common.nomitech.common.expr.project.ProjectId;
	using ProjectLocation = Desktop.common.nomitech.common.expr.project.ProjectLocation;
	using ProjectName = Desktop.common.nomitech.common.expr.project.ProjectName;
	using ProjectSQL = Desktop.common.nomitech.common.expr.project.ProjectSQL;
	using ProjectStartDate = Desktop.common.nomitech.common.expr.project.ProjectStartDate;
	using ProjectStateProvince = Desktop.common.nomitech.common.expr.project.ProjectStateProvince;
	using ProjectVariable = Desktop.common.nomitech.common.expr.project.ProjectVariable;
	using ProjectVariableAsNumber = Desktop.common.nomitech.common.expr.project.ProjectVariableAsNumber;
	using ResourceDBHQL = Desktop.common.nomitech.common.expr.project.ResourceDBHQL;
	using ResourceDBSQL = Desktop.common.nomitech.common.expr.project.ResourceDBSQL;
	using SheetRowAt = Desktop.common.nomitech.common.expr.project.variables.SheetRowAt;
	using SheetValueAt = Desktop.common.nomitech.common.expr.project.variables.SheetValueAt;
	using BimQuantityTakeoff = Desktop.common.nomitech.common.expr.takeoff.BimQuantityTakeoff;
	using GlobalTakeoffQuantity = Desktop.common.nomitech.common.expr.takeoff.GlobalTakeoffQuantity;
	using QuantityTakeoffAdd = Desktop.common.nomitech.common.expr.takeoff.QuantityTakeoffAdd;
	using FormatDateToText = Desktop.common.nomitech.common.expr.util.FormatDateToText;
	using FormatTextToDate = Desktop.common.nomitech.common.expr.util.FormatTextToDate;
	using IsArgInShowing = Desktop.common.nomitech.common.expr.util.IsArgInShowing;
	using IsArgInValidAndShowing = Desktop.common.nomitech.common.expr.util.IsArgInValidAndShowing;
	using Unit1ToUnit2 = Desktop.common.nomitech.common.expr.util.Unit1ToUnit2;
	using Unit1ToUnit2Div = Desktop.common.nomitech.common.expr.util.Unit1ToUnit2Div;
	using Expr = org.boris.expr.Expr;
	using ExprException = org.boris.expr.ExprException;
	using ExprFunction = org.boris.expr.ExprFunction;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using IExprFunction = org.boris.expr.IExprFunction;
	using IFunctionProvider = org.boris.expr.function.IFunctionProvider;
	using ABS = org.boris.expr.function.excel.ABS;
	using ACOS = org.boris.expr.function.excel.ACOS;
	using ACOSH = org.boris.expr.function.excel.ACOSH;
	using AND = org.boris.expr.function.excel.AND;
	using ASIN = org.boris.expr.function.excel.ASIN;
	using ASINH = org.boris.expr.function.excel.ASINH;
	using ATAN = org.boris.expr.function.excel.ATAN;
	using ATAN2 = org.boris.expr.function.excel.ATAN2;
	using ATANH = org.boris.expr.function.excel.ATANH;
	using AVEDEV = org.boris.expr.function.excel.AVEDEV;
	using AVERAGE = org.boris.expr.function.excel.AVERAGE;
	using AVERAGEA = org.boris.expr.function.excel.AVERAGEA;
	using BETADIST = org.boris.expr.function.excel.BETADIST;
	using BETAINV = org.boris.expr.function.excel.BETAINV;
	using BINOMDIST = org.boris.expr.function.excel.BINOMDIST;
	using CEILING = org.boris.expr.function.excel.CEILING;
	using CHAR = org.boris.expr.function.excel.CHAR;
	using CHIDIST = org.boris.expr.function.excel.CHIDIST;
	using CHIINV = org.boris.expr.function.excel.CHIINV;
	using CHOOSE = org.boris.expr.function.excel.CHOOSE;
	using CLEAN = org.boris.expr.function.excel.CLEAN;
	using CODE = org.boris.expr.function.excel.CODE;
	using COMBIN = org.boris.expr.function.excel.COMBIN;
	using CONCATENATE = org.boris.expr.function.excel.CONCATENATE;
	using CONFIDENCE = org.boris.expr.function.excel.CONFIDENCE;
	using CORREL = org.boris.expr.function.excel.CORREL;
	using COS = org.boris.expr.function.excel.COS;
	using COSH = org.boris.expr.function.excel.COSH;
	using COUNT = org.boris.expr.function.excel.COUNT;
	using COUNTA = org.boris.expr.function.excel.COUNTA;
	using COVAR = org.boris.expr.function.excel.COVAR;
	using CRITBINOM = org.boris.expr.function.excel.CRITBINOM;
	using DAY = org.boris.expr.function.excel.DAY;
	using DB = org.boris.expr.function.excel.DB;
	using DCOUNT = org.boris.expr.function.excel.DCOUNT;
	using DCOUNTA = org.boris.expr.function.excel.DCOUNTA;
	using DDB = org.boris.expr.function.excel.DDB;
	using DEGREES = org.boris.expr.function.excel.DEGREES;
	using DEVSQ = org.boris.expr.function.excel.DEVSQ;
	using DGET = org.boris.expr.function.excel.DGET;
	using DMAX = org.boris.expr.function.excel.DMAX;
	using DMIN = org.boris.expr.function.excel.DMIN;
	using DPRODUCT = org.boris.expr.function.excel.DPRODUCT;
	using DSTDEV = org.boris.expr.function.excel.DSTDEV;
	using DSTDEVP = org.boris.expr.function.excel.DSTDEVP;
	using DSUM = org.boris.expr.function.excel.DSUM;
	using DVAR = org.boris.expr.function.excel.DVAR;
	using DVARP = org.boris.expr.function.excel.DVARP;
	using EVEN = org.boris.expr.function.excel.EVEN;
	using EXACT = org.boris.expr.function.excel.EXACT;
	using EXP = org.boris.expr.function.excel.EXP;
	using EXPONDIST = org.boris.expr.function.excel.EXPONDIST;
	using FACT = org.boris.expr.function.excel.FACT;
	using FALSE = org.boris.expr.function.excel.FALSE;
	using FDIST = org.boris.expr.function.excel.FDIST;
	using FIND = org.boris.expr.function.excel.FIND;
	using FINV = org.boris.expr.function.excel.FINV;
	using FLOOR = org.boris.expr.function.excel.FLOOR;
	using FORECAST = org.boris.expr.function.excel.FORECAST;
	using FREQUENCY = org.boris.expr.function.excel.FREQUENCY;
	using GEOMEAN = org.boris.expr.function.excel.GEOMEAN;
	using HOUR = org.boris.expr.function.excel.HOUR;
	using IF = org.boris.expr.function.excel.IF;
	using INDIRECT = org.boris.expr.function.excel.INDIRECT;
	using INFO = org.boris.expr.function.excel.INFO;
	using INT = org.boris.expr.function.excel.INT;
	using ISBLANK = org.boris.expr.function.excel.ISBLANK;
	using ISERR = org.boris.expr.function.excel.ISERR;
	using ISLOGICAL = org.boris.expr.function.excel.ISLOGICAL;
	using ISNA = org.boris.expr.function.excel.ISNA;
	using ISNONTEXT = org.boris.expr.function.excel.ISNONTEXT;
	using ISNUMBER = org.boris.expr.function.excel.ISNUMBER;
	using ISREF = org.boris.expr.function.excel.ISREF;
	using ISTEXT = org.boris.expr.function.excel.ISTEXT;
	using KURT = org.boris.expr.function.excel.KURT;
	using LEFT = org.boris.expr.function.excel.LEFT;
	using LEN = org.boris.expr.function.excel.LEN;
	using LN = org.boris.expr.function.excel.LN;
	using LOG = org.boris.expr.function.excel.LOG;
	using LOG10 = org.boris.expr.function.excel.LOG10;
	using LOWER = org.boris.expr.function.excel.LOWER;
	using MATCH = org.boris.expr.function.excel.MATCH;
	using MAX = org.boris.expr.function.excel.MAX;
	using MAXA = org.boris.expr.function.excel.MAXA;
	using MID = org.boris.expr.function.excel.MID;
	using MIN = org.boris.expr.function.excel.MIN;
	using MINA = org.boris.expr.function.excel.MINA;
	using MINUTE = org.boris.expr.function.excel.MINUTE;
	using MOD = org.boris.expr.function.excel.MOD;
	using MODE = org.boris.expr.function.excel.MODE;
	using MONTH = org.boris.expr.function.excel.MONTH;
	using N = org.boris.expr.function.excel.N;
	using NA = org.boris.expr.function.excel.NA;
	using NORMSDIST = org.boris.expr.function.excel.NORMSDIST;
	using NOT = org.boris.expr.function.excel.NOT;
	using NOW = org.boris.expr.function.excel.NOW;
	using ODD = org.boris.expr.function.excel.ODD;
	using OR = org.boris.expr.function.excel.OR;
	using PERMUT = org.boris.expr.function.excel.PERMUT;
	using PI = org.boris.expr.function.excel.PI;
	using PRODUCT = org.boris.expr.function.excel.PRODUCT;
	using PROPER = org.boris.expr.function.excel.PROPER;
	using RADIANS = org.boris.expr.function.excel.RADIANS;
	using RAND = org.boris.expr.function.excel.RAND;
	using REPLACE = org.boris.expr.function.excel.REPLACE;
	using REPT = org.boris.expr.function.excel.REPT;
	using RIGHT = org.boris.expr.function.excel.RIGHT;
	using ROUND = org.boris.expr.function.excel.ROUND;
	using ROUNDDOWN = org.boris.expr.function.excel.ROUNDDOWN;
	using ROUNDUP = org.boris.expr.function.excel.ROUNDUP;
	using ROW = org.boris.expr.function.excel.ROW;
	using ROWS = org.boris.expr.function.excel.ROWS;
	using SEARCH = org.boris.expr.function.excel.SEARCH;
	using SECOND = org.boris.expr.function.excel.SECOND;
	using SIGN = org.boris.expr.function.excel.SIGN;
	using SIN = org.boris.expr.function.excel.SIN;
	using SINH = org.boris.expr.function.excel.SINH;
	using SQRT = org.boris.expr.function.excel.SQRT;
	using STDEV = org.boris.expr.function.excel.STDEV;
	using STDEVP = org.boris.expr.function.excel.STDEVP;
	using SUM = org.boris.expr.function.excel.SUM;
	using SUMSQ = org.boris.expr.function.excel.SUMSQ;
	using SYD = org.boris.expr.function.excel.SYD;
	using T = org.boris.expr.function.excel.T;
	using TAN = org.boris.expr.function.excel.TAN;
	using TANH = org.boris.expr.function.excel.TANH;
	using TIME = org.boris.expr.function.excel.TIME;
	using TODAY = org.boris.expr.function.excel.TODAY;
	using TRIM = org.boris.expr.function.excel.TRIM;
	using TRUE = org.boris.expr.function.excel.TRUE;
	using TRUNC = org.boris.expr.function.excel.TRUNC;
	using TYPE = org.boris.expr.function.excel.TYPE;
	using UPPER = org.boris.expr.function.excel.UPPER;
	using VALUE = org.boris.expr.function.excel.VALUE;
	using VAR = org.boris.expr.function.excel.VAR;
	using VARA = org.boris.expr.function.excel.VARA;
	using VARP = org.boris.expr.function.excel.VARP;
	using VARPA = org.boris.expr.function.excel.VARPA;
	using VDB = org.boris.expr.function.excel.VDB;
	using WEEKDAY = org.boris.expr.function.excel.WEEKDAY;
	using YEAR = org.boris.expr.function.excel.YEAR;
	using ParameterizedCompletion = org.fife.ui.autocomplete.ParameterizedCompletion;

	public class ExprExcelFunctionProvider : IFunctionProvider
	{
	  public const string NUMBER = "number";

	  public const string TEXT = "text";

	  public const string BOOLEAN = "boolean";

	  public const string DATE = "date";

	  public const string LOCFACTOR = "locfactor";

	  public const string CONSTNUMBER = "const_number";

	  public const string CONSTTEXT = "const_text";

	  public const string ARRAY = "array";

	  public const string ARGUMENT_IN_FUNCTIONS = "Argument-In Functions";

	  public const string ARRAY_FUNCTIONS = "Array Functions";

	  public const string ASSEMBLY_FUNCTIONS = "Assembly Functions";

	  public const string PROJECT_FUNCTIONS = "Project Functions";

	  public const string CONVERSION_FUNCTIONS = "Conversion Functions";

	  public const string MATH_FUNCTIONS = "Math Functions";

	  public const string LOGICAL_FUNCTIONS = "Logical Functions";

	  public const string TEXT_FUNCTIONS = "Text Functions";

	  public const string INFORMATION_FUNCTIONS = "Information Functions";

	  public const string DATE_FUNCTIONS = "Date & Time Functions";

	  public const string FINANCIAL_FUNCTIONS = "Financial Functions";

	  public const string DATABASE_FUNCTIONS = "Database Functions";

	  public const string STATISTICAL_FUNCTIONS = "Statistical Functions";

	  public const string ENGINEERING_FUNCTIONS = "Engineering Functions";

	  public const string LOOKUP_FUNCTIONS = "Lookup & Reference Functions";

	  public const string LOCATION_FUNCTIONS = "Location Factors Functions";

	  private static IDictionary<string, IExprFunction> functions = new Hashtable();

	  private static IDictionary<string, ExprFunctionDefinition> definitions = new Hashtable();

	  public static bool isExcelFunction(string paramString)
	  {
		paramString = paramString.ToUpper();
		return (paramString.Equals("PRJSTARTDATE") || paramString.Equals("PRJSTATEPROVINCE") || paramString.Equals("PRJLOCATION") || paramString.Equals("PRJDURATION") || paramString.Equals("ARG_SHOWING") || paramString.Equals("ARG_VALID_SHOWING") || paramString.Equals("PRJSTATEPROVINCE") || paramString.Equals("PRJLOCATION") || paramString.Equals("UNIT1_TO_UNIT2") || paramString.Equals("UNIT1_TO_UNIT2_DIV") || paramString.Equals("FACTOR_FROM_LOCATION") || paramString.Equals("COUNTRY_FROM_LOCATION") || paramString.Equals("STATE_FROM_LOCATION") || paramString.Equals("CITY_FROM_LOCATION") || paramString.Equals("ZIPCODE_FROM_LOCATION") || paramString.Equals("EXTRACT_GROUP_CODE")) ? false : hasFunctionName(paramString);
	  }

	  public static IDictionary<string, IExprFunction> Functions
	  {
		  get
		  {
			  return functions;
		  }
	  }

	  public static IDictionary<string, ExprFunctionDefinition> Definitions
	  {
		  get
		  {
			  return definitions;
		  }
	  }

	  public virtual bool hasFunction(ExprFunction paramExprFunction)
	  {
		  return functions.ContainsKey(paramExprFunction.Name.ToUpper());
	  }

	  public static bool hasFunctionName(string paramString)
	  {
		  return functions.ContainsKey(paramString.ToUpper());
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.ExprFunction paramExprFunction) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, ExprFunction paramExprFunction)
	  {
		IExprFunction iExprFunction = (IExprFunction)functions[paramExprFunction.Name.ToUpper()];
		if (iExprFunction != null)
		{
		  try
		  {
			return iExprFunction.evaluate(paramIEvaluationContext, paramExprFunction.Args);
		  }
		  catch (ExprException exprException)
		  {
			string str = "";
			foreach (Expr expr in paramExprFunction.Args)
			{
			  str = str + expr.ToString();
			}
			Console.Error.WriteLine("on function " + paramExprFunction.Name + ", " + str);
			throw exprException;
		  }
		}
		return null;
	  }

	  public static IList<string> AvailableGroupings
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			foreach (string str1 in definitions.Keys)
			{
			  ExprFunctionDefinition exprFunctionDefinition = (ExprFunctionDefinition)definitions[str1];
			  string str2 = exprFunctionDefinition.Grouping;
			  if (!arrayList.Contains(str2))
			  {
				arrayList.Add(str2);
			  }
			}
			return arrayList;
		  }
	  }

	  static ExprExcelFunctionProvider()
	  {
		functions["ABS"] = new ABS();
		definitions["ABS"] = new ExprFunctionDefinition("ABS", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "num")}"number", "Returns the absolute value of a number");
		functions["ACOS"] = new ACOS();
		definitions["ACOS"] = new ExprFunctionDefinition("ACOS", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "num")}"number", "Returns the arccosine (in radians) of a number.");
		functions["ACOSH"] = new ACOSH();
		definitions["ACOSH"] = new ExprFunctionDefinition("ACOSH", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "num")}"number", "Returns the inverse hyperbolic cosine of a number.");
		functions["AND"] = new AND();
		definitions["AND"] = new ExprFunctionDefinition("AND", "Logical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("boolean", "condition1"),
			new ParameterizedCompletion.Parameter("boolean", "condition2"),
			new ParameterizedCompletion.Parameter("boolean", "conditionN")
		}"boolean", "Returns TRUE if all conditions are TRUE. It returns FALSE if any of the conditions are FALSE.");
		functions["ASIN"] = new ASIN();
		definitions["ASIN"] = new ExprFunctionDefinition("ASIN", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "num")}"number", "Returns the arcsine (in radians) of a number");
		functions["ASINH"] = new ASINH();
		definitions["ASINH"] = new ExprFunctionDefinition("ASINH", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "num")}"number", "Returns the inverse hyperbolic sine of a number");
		functions["ATAN"] = new ATAN();
		definitions["ATAN"] = new ExprFunctionDefinition("ATAN", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "num")}"number", "Returns the arctangent (in radians) of a number");
		functions["ATAN2"] = new ATAN2();
		definitions["ATAN2"] = new ExprFunctionDefinition("ATAN2", "Math Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "x_coordinate"),
			new ParameterizedCompletion.Parameter("number", "y_coordinate")
		}"number", "Returns the arctangent (in radians) of (x,y) coordinates");
		functions["ATANH"] = new ATANH();
		definitions["ATANH"] = new ExprFunctionDefinition("ATANH", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "num")}"number", "Returns the inverse hyperbolic tangent of a number");
		functions["AVEDEV"] = new AVEDEV();
		definitions["AVEDEV"] = new ExprFunctionDefinition("AVEDEV", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "num1"),
			new ParameterizedCompletion.Parameter("number", "num2"),
			new ParameterizedCompletion.Parameter("number", "numN"),
			new ParameterizedCompletion.Parameter("number", "number_n")
		}"number", "Returns the average of the absolute deviations of the numbers provided");
		functions["AVERAGE"] = new AVERAGE();
		definitions["AVERAGE"] = new ExprFunctionDefinition("AVERAGE", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "num1"),
			new ParameterizedCompletion.Parameter("number", "num2"),
			new ParameterizedCompletion.Parameter("number", "numN"),
			new ParameterizedCompletion.Parameter("number", "number_n")
		}"number", "Returns the average (arithmetic mean) of the numbers provided");
		functions["AVERAGEA"] = new AVERAGEA();
		definitions["AVERAGEA"] = new ExprFunctionDefinition("AVERAGEA", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "num1"),
			new ParameterizedCompletion.Parameter("number", "num2"),
			new ParameterizedCompletion.Parameter("number", "numN"),
			new ParameterizedCompletion.Parameter("number", "number_n")
		}"number", "Returns the average (arithmetic mean) of the numbers provided. The AverageA function is different from the Average function in that it treats TRUE as a value of 1 and FALSE as a value of 0");
		functions["BETADIST"] = new BETADIST();
		definitions["BETADIST"] = new ExprFunctionDefinition("BETADIST", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "x"),
			new ParameterizedCompletion.Parameter("number", "alpha"),
			new ParameterizedCompletion.Parameter("number", "beta"),
			new ParameterizedCompletion.Parameter("number", "lower_bound"),
			new ParameterizedCompletion.Parameter("number", "upper_bound")
		}"number", "Returns the cumulative beta probability density function");
		functions["BETAINV"] = new BETAINV();
		definitions["BETAINV"] = new ExprFunctionDefinition("BETAINV", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "probability"),
			new ParameterizedCompletion.Parameter("number", "alpha"),
			new ParameterizedCompletion.Parameter("number", "beta"),
			new ParameterizedCompletion.Parameter("number", "lower_bound"),
			new ParameterizedCompletion.Parameter("number", "upper_bound")
		}"number", "Returns the inverse of the cumulative beta probability density function");
		functions["BINOMDIST"] = new BINOMDIST();
		definitions["BINOMDIST"] = new ExprFunctionDefinition("BINOMDIST", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "num_success"),
			new ParameterizedCompletion.Parameter("number", "num_trial"),
			new ParameterizedCompletion.Parameter("number", "prob_success"),
			new ParameterizedCompletion.Parameter("number", "cumulative")
		}"number", "Returns the individual term binomial distribution probability");
		functions["CEILING"] = new CEILING();
		definitions["CEILING"] = new ExprFunctionDefinition("CEILING", "Math Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "num"),
			new ParameterizedCompletion.Parameter("number", "significance")
		}"number", "Returns a number rounded up based on a multiple of significance");
		functions["CHAR"] = new CHAR();
		definitions["CHAR"] = new ExprFunctionDefinition("CHAR", "Text Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "ascii_value")}"text", "Returns the character based on the ASCII value");
		functions["CHIDIST"] = new CHIDIST();
		definitions["CHIDIST"] = new ExprFunctionDefinition("CHIDIST", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "x"),
			new ParameterizedCompletion.Parameter("number", "degrees_freedom")
		}"number", "Returns the one-tailed probability of the chi-squared distribution");
		functions["CHIINV"] = new CHIINV();
		definitions["CHIINV"] = new ExprFunctionDefinition("CHIINV", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "probability"),
			new ParameterizedCompletion.Parameter("number", "degrees_freedom")
		}"number", "Calculates the inverse of the right-tailed probability of the chi-square distribution");
		functions["CHOOSE"] = new CHOOSE();
		definitions["CHOOSE"] = new ExprFunctionDefinition("CHOOSE", "Lookup & Reference Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "position"),
			new ParameterizedCompletion.Parameter("number", "value1"),
			new ParameterizedCompletion.Parameter("number", "value2"),
			new ParameterizedCompletion.Parameter("number", "valueN")
		}"number", "Returns a value from a list of values based on a given position");
		functions["CLEAN"] = new CLEAN();
		definitions["CLEAN"] = new ExprFunctionDefinition("CLEAN", "Text Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("text", "text")}"text", "Removes all nonprintable characters from a string");
		functions["CODE"] = new CODE();
		definitions["CODE"] = new ExprFunctionDefinition("CODE", "Text Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("text", "text")}"text", "Removes returns the ASCII value of a character or the first character in a cell");
		functions["COMBIN"] = new COMBIN();
		definitions["COMBIN"] = new ExprFunctionDefinition("COMBIN", "Math Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "num"),
			new ParameterizedCompletion.Parameter("number", "chosen")
		}"number", "Returns the combinations for a specified number of items");
		functions["CONCATENATE"] = new CONCATENATE();
		definitions["CONCATENATE"] = new ExprFunctionDefinition("CONCATENATE", "Text Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "text1"),
			new ParameterizedCompletion.Parameter("text", "text2"),
			new ParameterizedCompletion.Parameter("text", "textN")
		}"text", "Allows you to join 2 or more strings together");
		definitions["NTHCOMELEM"] = new ExprFunctionDefinition("NTHCOMELEM", "Text Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "text1"),
			new ParameterizedCompletion.Parameter("text", "text2"),
			new ParameterizedCompletion.Parameter("text", "textN")
		}"text", "get the n-th comma seperated element");
		functions["CONFIDENCE"] = new CONFIDENCE();
		definitions["CONFIDENCE"] = new ExprFunctionDefinition("CONFIDENCE", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "alpha"),
			new ParameterizedCompletion.Parameter("number", "standard_dev"),
			new ParameterizedCompletion.Parameter("number", "size")
		}"number", "Returns a value that you can use to construct a confidence interval for a population mean");
		functions["CORREL"] = new CORREL();
		definitions["CORREL"] = new ExprFunctionDefinition("CORREL", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "array1"),
			new ParameterizedCompletion.Parameter("number", "array2")
		}"number", "Returns the correlation coefficient of the array1 and array2 cell ranges");
		functions["COS"] = new COS();
		definitions["COS"] = new ExprFunctionDefinition("COS", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "num")}"number", "Returns the cosine of an angle");
		functions["COSH"] = new COSH();
		definitions["COSH"] = new ExprFunctionDefinition("COSH", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "num")}"number", "Returns the hyperbolic cosine of a number");
		functions["COUNT"] = new COUNT();
		definitions["COUNT"] = new ExprFunctionDefinition("COUNT", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "argument1"),
			new ParameterizedCompletion.Parameter("number", "argument2"),
			new ParameterizedCompletion.Parameter("number", "argument_n")
		}"number", "Counts the number of cells that contain numbers as well as the number of arguments that contain numbers");
		functions["COUNTA"] = new COUNTA();
		definitions["COUNTA"] = new ExprFunctionDefinition("COUNTA", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "argument1"),
			new ParameterizedCompletion.Parameter("number", "argument2"),
			new ParameterizedCompletion.Parameter("number", "argument_n")
		}"number", "Counts the number of cells that are not empty as well as the number of arguments that contain values");
		functions["COVAR"] = new COVAR();
		definitions["COVAR"] = new ExprFunctionDefinition("COVAR", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "array1"),
			new ParameterizedCompletion.Parameter("text", "array2")
		}"number", "Returns the covariance, the average of the products of deviations for two data sets");
		functions["CRITBINOM"] = new CRITBINOM();
		definitions["CRITBINOM"] = new ExprFunctionDefinition("CRITBINOM", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "trials"),
			new ParameterizedCompletion.Parameter("number", "probability_s"),
			new ParameterizedCompletion.Parameter("number", "alpha")
		}"number", "Returns the inverse of the Cumulative Binomial Distribution");
		functions["DATE"] = new DATE();
		definitions["DATE"] = new ExprFunctionDefinition("DATE", "Date & Time Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "year"),
			new ParameterizedCompletion.Parameter("number", "month"),
			new ParameterizedCompletion.Parameter("number", "day")
		}"number", "Returns the serial number of a date");
		functions["DATEPARSE"] = new FormatTextToDate();
		definitions["DATEPARSE"] = new ExprFunctionDefinition("DATEPARSE", "Date & Time Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "text"),
			new ParameterizedCompletion.Parameter("text", "format")
		}"number", "Parses text1 to a date using format, eg (dd/MM/yyyy");
		functions["DATEFORMAT"] = new FormatDateToText();
		definitions["DATEFORMAT"] = new ExprFunctionDefinition("DATEFORMAT", "Date & Time Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "date"),
			new ParameterizedCompletion.Parameter("text", "format")
		}"number", "Formats date to text using format, eg (dd/MM/yyyy)");
		functions["DAY"] = new DAY();
		definitions["DAY"] = new ExprFunctionDefinition("DAY", "Date & Time Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "date")}"number", "Returns the day of the month (a number from 1 to 31) given a date value");
		functions["DB"] = new DB();
		definitions["DB"] = new ExprFunctionDefinition("DB", "Financial Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "cost"),
			new ParameterizedCompletion.Parameter("number", "salvage"),
			new ParameterizedCompletion.Parameter("number", "life"),
			new ParameterizedCompletion.Parameter("number", "period"),
			new ParameterizedCompletion.Parameter("number", "number_months")
		}"number", "Returns the depreciation of an asset for a given time period based on the fixed-declining balance method");
		functions["DCOUNT"] = new DCOUNT();
		definitions["DCOUNT"] = new ExprFunctionDefinition("DCOUNT", "Database Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "range"),
			new ParameterizedCompletion.Parameter("number", "field"),
			new ParameterizedCompletion.Parameter("number", "criteria")
		}"number", "Returns the depreciation of an asset for a given time period based on the fixed-declining balance method");
		functions["DCOUNTA"] = new DCOUNTA();
		definitions["DCOUNTA"] = new ExprFunctionDefinition("DCOUNTA", "Database Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "range"),
			new ParameterizedCompletion.Parameter("number", "field"),
			new ParameterizedCompletion.Parameter("number", "criteria")
		}"number", "Returns the number of cells in a column or database that contains nonblank values and meets a given criteria");
		functions["DDB"] = new DDB();
		definitions["DDB"] = new ExprFunctionDefinition("DDB", "Database Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "cost"),
			new ParameterizedCompletion.Parameter("number", "salvage"),
			new ParameterizedCompletion.Parameter("number", "life"),
			new ParameterizedCompletion.Parameter("number", "period"),
			new ParameterizedCompletion.Parameter("number", "factor")
		}"number", "Returns the depreciation of an asset for a given time period based on the double-declining balance method");
		functions["DEGREES"] = new DEGREES();
		definitions["DEGREES"] = new ExprFunctionDefinition("DEGREES", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "radians")}"number", "Converts radians into degrees");
		functions["DEVSQ"] = new DEVSQ();
		definitions["DEVSQ"] = new ExprFunctionDefinition("DEVSQ", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "number1"),
			new ParameterizedCompletion.Parameter("number", "number2"),
			new ParameterizedCompletion.Parameter("number", "numN")
		}"number", "Returns the sum of squares of deviations of data points from their sample mean");
		functions["DGET"] = new DGET();
		definitions["DGET"] = new ExprFunctionDefinition("DGET", "Database Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "database"),
			new ParameterizedCompletion.Parameter("number", "field"),
			new ParameterizedCompletion.Parameter("number", "criteria")
		}"number", "Retrieves from a database a single record that matches a given criteria");
		functions["DMAX"] = new DMAX();
		definitions["DMAX"] = new ExprFunctionDefinition("DMAX", "Database Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "database"),
			new ParameterizedCompletion.Parameter("number", "field"),
			new ParameterizedCompletion.Parameter("number", "criteria")
		}"number", "Returns the largest number in a column in a list or database, based on a given criteria");
		functions["DMIN"] = new DMIN();
		definitions["DMIN"] = new ExprFunctionDefinition("DMIN", "Database Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "database"),
			new ParameterizedCompletion.Parameter("number", "field"),
			new ParameterizedCompletion.Parameter("number", "criteria")
		}"number", "Returns the smallest number in a column in a list or database, based on a given criteria");
		functions["DPRODUCT"] = new DPRODUCT();
		definitions["DPRODUCT"] = new ExprFunctionDefinition("DPRODUCT", "Database Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "database"),
			new ParameterizedCompletion.Parameter("number", "field"),
			new ParameterizedCompletion.Parameter("number", "criteria")
		}"number", "Returns the product of the numbers in a column in a list or database, based on a given criteria");
		functions["DSTDEV"] = new DSTDEV();
		definitions["DSTDEV"] = new ExprFunctionDefinition("DSTDEV", "Database Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "database"),
			new ParameterizedCompletion.Parameter("number", "field"),
			new ParameterizedCompletion.Parameter("number", "criteria")
		}"number", "Returns the standard deviation of a population based on a sample of numbers in a column in a list or database, based on a given criteria");
		functions["DSTDEVP"] = new DSTDEVP();
		definitions["DSTDEVP"] = new ExprFunctionDefinition("DSTDEVP", "Database Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "database"),
			new ParameterizedCompletion.Parameter("number", "field"),
			new ParameterizedCompletion.Parameter("number", "criteria")
		}"number", "Returns the standard deviation of a population based on the entire population of numbers in a column in a list or database, based on a given criteria");
		functions["DSUM"] = new DSUM();
		definitions["DSUM"] = new ExprFunctionDefinition("DSUM", "Database Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "range"),
			new ParameterizedCompletion.Parameter("number", "field"),
			new ParameterizedCompletion.Parameter("number", "criteria")
		}"number", "Sums the numbers in a column or database that meets a given criteria");
		functions["DVAR"] = new DVAR();
		definitions["DVAR"] = new ExprFunctionDefinition("DVAR", "Database Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "database"),
			new ParameterizedCompletion.Parameter("number", "field"),
			new ParameterizedCompletion.Parameter("number", "criteria")
		}"number", "Returns the variance of a population based on a sample of numbers in a column in a list or database, based on a given criteria");
		functions["DVARP"] = new DVARP();
		definitions["DVARP"] = new ExprFunctionDefinition("DVARP", "Database Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "database"),
			new ParameterizedCompletion.Parameter("number", "field"),
			new ParameterizedCompletion.Parameter("number", "criteria")
		}"number", "Returns the variance of a population based on the entire population of numbers in a column in a list or database, based on a given criteria");
		functions["EVEN"] = new EVEN();
		definitions["EVEN"] = new ExprFunctionDefinition("EVEN", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "num")}"number", "Rounds a number up to the nearest even integer. If the number is negative, the number is rounded away from zero");
		functions["EXACT"] = new EXACT();
		definitions["EXACT"] = new ExprFunctionDefinition("EXACT", "Text Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "text1"),
			new ParameterizedCompletion.Parameter("text", "text2")
		}"boolean", "Compares two strings and returns TRUE if both values are the same. Otherwise, it will return FALSE");
		functions["EXP"] = new EXP();
		definitions["EXP"] = new ExprFunctionDefinition("EXP", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "num")}"number", "Returns number raised to the nth power, where e = 2.71828183");
		functions["EXPONDIST"] = new EXPONDIST();
		definitions["EXPONDIST"] = new ExprFunctionDefinition("EXPONDIST", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "x"),
			new ParameterizedCompletion.Parameter("number", "lambda"),
			new ParameterizedCompletion.Parameter("text", "lambda")
		}"number", "Returns the value of the exponential distribution for a give value of x");
		functions["FACT"] = new FACT();
		definitions["FACT"] = new ExprFunctionDefinition("FACT", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "num")}"number", "Returns the factorial of a number");
		functions["FALSE"] = new FALSE();
		definitions["FALSE"] = new ExprFunctionDefinition("FALSE", "Logical Functions", new ParameterizedCompletion.Parameter[0], "boolean", "Returns a logical value of FALSE");
		functions["FDIST"] = new FDIST();
		definitions["FDIST"] = new ExprFunctionDefinition("FDIST", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "x"),
			new ParameterizedCompletion.Parameter("number", "degrees_freedom1"),
			new ParameterizedCompletion.Parameter("number", "degrees_freedom2")
		}"number", "Returns the F probability distribution");
		functions["FIND"] = new FIND();
		definitions["FIND"] = new ExprFunctionDefinition("FIND", "Text Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "text1"),
			new ParameterizedCompletion.Parameter("text", "text2"),
			new ParameterizedCompletion.Parameter("number", "start_position")
		}"number", "Returns the location of a substring in a string");
		functions["FINV"] = new FINV();
		definitions["FINV"] = new ExprFunctionDefinition("FINV", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "probability"),
			new ParameterizedCompletion.Parameter("number", "degrees_freedom1"),
			new ParameterizedCompletion.Parameter("number", "degrees_freedom2")
		}"number", "Returns the inverse of the F probability distribution");
		functions["FLOOR"] = new FLOOR();
		definitions["FLOOR"] = new ExprFunctionDefinition("FLOOR", "Math Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "num"),
			new ParameterizedCompletion.Parameter("number", "significance")
		}"number", "Returns a number rounded down based on a multiple of significance");
		functions["FORECAST"] = new FORECAST();
		definitions["FORECAST"] = new ExprFunctionDefinition("FORECAST", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "x-value"),
			new ParameterizedCompletion.Parameter("number", "known_y_values"),
			new ParameterizedCompletion.Parameter("number", "known_x_values")
		}"number", "Returns a prediction of a future value based on existing values provided");
		functions["FREQUENCY"] = new FREQUENCY();
		definitions["FREQUENCY"] = new ExprFunctionDefinition("FREQUENCY", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "data_array"),
			new ParameterizedCompletion.Parameter("number", "bins_array")
		}"number", "Returns a frequency distribution as a vertical array");
		functions["GEOMEAN"] = new GEOMEAN();
		definitions["GEOMEAN"] = new ExprFunctionDefinition("GEOMEAN", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "number1"),
			new ParameterizedCompletion.Parameter("number", "number2"),
			new ParameterizedCompletion.Parameter("number", "N")
		}"number", "Returns the geometric mean of an array or range of positive data");
		functions["HOUR"] = new HOUR();
		definitions["HOUR"] = new ExprFunctionDefinition("HOUR", "Date & Time Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "serial_number")}"number", "Returns the hour of a time value(from 0 to 23)");
		functions["IF"] = new IF();
		definitions["IF"] = new ExprFunctionDefinition("IF", "Logical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "condition"),
			new ParameterizedCompletion.Parameter("number", "value_if_true"),
			new ParameterizedCompletion.Parameter("number", "value_if_false")
		}"number", "Returns one value if a specified condition evaluates to TRUE, or another value if it evaluates to FALSE");
		functions["INDIRECT"] = new INDIRECT();
		definitions["INDIRECT"] = new ExprFunctionDefinition("INDIRECT", "Lookup & Reference Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "string_reference"),
			new ParameterizedCompletion.Parameter("number", "ref_style")
		}"number", "Returns the reference to a cell based on its string representation");
		functions["INFO"] = new INFO();
		definitions["INFO"] = new ExprFunctionDefinition("INFO", "Information Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("text", "type")}"text", "Returns information about the operating environment");
		functions["INT"] = new INT();
		definitions["INT"] = new ExprFunctionDefinition("INT", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "expression")}"number", "Returns the integer portion of a number");
		functions["ISBLANK"] = new ISBLANK();
		definitions["ISBLANK"] = new ExprFunctionDefinition("ISBLANK", "Information Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "value")}"boolean", "Checks for blank or null values");
		functions["ISERR"] = new ISERR();
		definitions["ISERR"] = new ExprFunctionDefinition("ISERR", "Information Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "value")}"boolean", "Checks for error values");
		functions["ISLOGICAL"] = new ISLOGICAL();
		definitions["ISLOGICAL"] = new ExprFunctionDefinition("ISLOGICAL", "Information Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "value")}"boolean", "Checks for  for a logical value (ie: TRUE or FALSE)");
		functions["ISNA"] = new ISNA();
		definitions["ISNA"] = new ExprFunctionDefinition("ISNA", "Information Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "value")}"boolean", "Checks for a #N/A (value not available) error");
		functions["ISNONTEXT"] = new ISNONTEXT();
		definitions["ISNONTEXT"] = new ExprFunctionDefinition("ISNONTEXT", "Information Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "value")}"boolean", "Checks for a value that is not text");
		functions["ISNUMBER"] = new ISNUMBER();
		definitions["ISNUMBER"] = new ExprFunctionDefinition("ISNUMBER", "Information Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "value")}"boolean", "Checks for a numeric value");
		functions["ISREF"] = new ISREF();
		definitions["ISREF"] = new ExprFunctionDefinition("ISREF", "Information Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "value")}"boolean", "Checks for a reference");
		functions["ISTEXT"] = new ISTEXT();
		definitions["ISTEXT"] = new ExprFunctionDefinition("ISTEXT", "Information Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "value")}"boolean", "Checks for a text value");
		functions["KURT"] = new KURT();
		definitions["KURT"] = new ExprFunctionDefinition("KURT", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "number1"),
			new ParameterizedCompletion.Parameter("number", "number2"),
			new ParameterizedCompletion.Parameter("number", "N")
		}"number", "Returns the kurtosis of a data set");
		functions["LEFT"] = new LEFT();
		definitions["LEFT"] = new ExprFunctionDefinition("LEFT", "Text Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "text"),
			new ParameterizedCompletion.Parameter("number", "number_of_characters")
		}"text", "Extracts a substring from a string, starting from the left-most character");
		functions["LEN"] = new LEN();
		definitions["LEN"] = new ExprFunctionDefinition("LEN", "Text Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("text", "text")}"number", "Returns the length of the specified string");
		functions["LN"] = new LN();
		definitions["LN"] = new ExprFunctionDefinition("LN", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "num")}"number", "Returns the natural logarithm of a number");
		functions["LOG"] = new LOG();
		definitions["LOG"] = new ExprFunctionDefinition("LOG", "Math Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "num"),
			new ParameterizedCompletion.Parameter("number", "base")
		}"number", "Returns the logarithm of a number to a specified base, base is optional");
		functions["LOG10"] = new LOG10();
		definitions["LOG10"] = new ExprFunctionDefinition("LOG10", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "num")}"number", "Returns the base-10 logarithm of a number");
		functions["LOWER"] = new LOWER();
		definitions["LOWER"] = new ExprFunctionDefinition("LOWER", "Text Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("text", "text")}"text", "Converts all letters in the specified string to lowercase");
		functions["MATCH"] = new MATCH();
		definitions["MATCH"] = new ExprFunctionDefinition("MATCH", "Lookup & Reference Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "value"),
			new ParameterizedCompletion.Parameter("number", "array"),
			new ParameterizedCompletion.Parameter("number", "match_type")
		}"number", "Searches for a value in an array and returns the relative position of that item");
		functions["MAX"] = new MAX();
		definitions["MAX"] = new ExprFunctionDefinition("MAX", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "number1"),
			new ParameterizedCompletion.Parameter("number", "number2"),
			new ParameterizedCompletion.Parameter("number", "Nnumber_n")
		}"number", "Returns the largest value from the numbers provided");
		functions["MAXA"] = new MAXA();
		definitions["MAXA"] = new ExprFunctionDefinition("MAXA", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "value1"),
			new ParameterizedCompletion.Parameter("number", "value2"),
			new ParameterizedCompletion.Parameter("number", "Nvalue_n")
		}"number", "Returns the largest value from the values provided");
		functions["MID"] = new MID();
		definitions["MID"] = new ExprFunctionDefinition("MID", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "text"),
			new ParameterizedCompletion.Parameter("number", "start_position"),
			new ParameterizedCompletion.Parameter("number", "number_of_characters")
		}"text", "Extracts a substring from a string (starting at any position)");
		functions["MIN"] = new MIN();
		definitions["MIN"] = new ExprFunctionDefinition("MIN", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "number1"),
			new ParameterizedCompletion.Parameter("number", "number2"),
			new ParameterizedCompletion.Parameter("number", "Nnumber_n")
		}"number", "Returns the smallest value from the numbers provided");
		functions["MINA"] = new MINA();
		definitions["MINA"] = new ExprFunctionDefinition("MINA", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "value1"),
			new ParameterizedCompletion.Parameter("number", "value2"),
			new ParameterizedCompletion.Parameter("number", "Nvalue_n")
		}"number", " Returns the smallest value from the values provided. The MinA function compares numbers, text, and logical values (TRUE or FALSE)");
		functions["MINUTE"] = new MINUTE();
		definitions["MINUTE"] = new ExprFunctionDefinition("MINUTE", "Date & Time Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "serial_number")}"number", "Returns the minute of a time value (from 0 to 59)");
		functions["MOD"] = new MOD();
		definitions["MOD"] = new ExprFunctionDefinition("MOD", "Math Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "number"),
			new ParameterizedCompletion.Parameter("number", "divisor")
		}"number", "Returns the remainder after a number is divided by a divisor");
		functions["MODE"] = new MODE();
		definitions["MODE"] = new ExprFunctionDefinition("MODE", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "number1"),
			new ParameterizedCompletion.Parameter("number", "number2"),
			new ParameterizedCompletion.Parameter("number", "Nnumber255")
		}"number", "Tells you the most frequently occurring value in a list of numbers");
		functions["MONTH"] = new MONTH();
		definitions["MONTH"] = new ExprFunctionDefinition("MONTH", "Date & Time Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "date_value")}"number", "Returns the month(a number from 1 to 12) given a date value");
		functions["N"] = new N();
		definitions["N"] = new ExprFunctionDefinition("N", "Information Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "value")}"number", "The Excel N function converts data into a numeric value");
		functions["NA"] = new NA();
		definitions["NA"] = new ExprFunctionDefinition("NA", "Information Functions", new ParameterizedCompletion.Parameter[0], "number", "Returns the #N/A error value");
		functions["NORMSDIST"] = new NORMSDIST();
		definitions["NORMSDIST"] = new ExprFunctionDefinition("NORMSDIST", "Statistical Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "z")}"number", "Returns the standard normal cumulative distribution function");
		functions["NOT"] = new NOT();
		definitions["NOT"] = new ExprFunctionDefinition("NOT", "Logical Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("boolean", "logical_value")}"boolean", "Returns the reversed logical value");
		functions["NOW"] = new NOW();
		definitions["NOW"] = new ExprFunctionDefinition("NOW", "Date & Time Functions", new ParameterizedCompletion.Parameter[0], "number", "Returns the current system date and time");
		functions["NOW_LOCAL"] = new NowLocal();
		definitions["NOW_LOCAL"] = new ExprFunctionDefinition("NOW_LOCAL", "Date & Time Functions", new ParameterizedCompletion.Parameter[0], "number", "Returns the current local date and time.");
		functions["ODD"] = new ODD();
		definitions["ODD"] = new ExprFunctionDefinition("ODD", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "num")}"number", "Rounds a number up to the nearest odd integer");
		functions["OR"] = new OR();
		definitions["OR"] = new ExprFunctionDefinition("OR", "Logical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("boolean", "condition1"),
			new ParameterizedCompletion.Parameter("boolean", "condition2"),
			new ParameterizedCompletion.Parameter("boolean", "conditionN")
		}"boolean", "Returns TRUE if any of the conditions are TRUE.Otherwise, it returns FALSE");
		functions["PERMUT"] = new PERMUT();
		definitions["PERMUT"] = new ExprFunctionDefinition("PERMUT", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "num"),
			new ParameterizedCompletion.Parameter("number", "chosen")
		}"number", "Returns the number of permutations for a specified number of items");
		functions["PI"] = new PI();
		definitions["PI"] = new ExprFunctionDefinition("PI", "Math Functions", new ParameterizedCompletion.Parameter[0], "number", " Returns the mathematical constant called pi, which is 3.14159265358979");
		functions["POWER"] = new POWER();
		definitions["POWER"] = new ExprFunctionDefinition("POWER", "Math Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "num"),
			new ParameterizedCompletion.Parameter("number", "power")
		}"number", " Returns the result of a number raised to a given power");
		functions["PRODUCT"] = new PRODUCT();
		definitions["PRODUCT"] = new ExprFunctionDefinition("PRODUCT", "Math Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "number1"),
			new ParameterizedCompletion.Parameter("number", "number2"),
			new ParameterizedCompletion.Parameter("number", "Nnumber_n")
		}"number", "Multiplies the numbers and returns the product");
		functions["PROPER"] = new PROPER();
		definitions["PROPER"] = new ExprFunctionDefinition("PROPER", "Text Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("text", "text")}"text", "Sets the first character in each word to uppercase and the rest to lowercase");
		functions["RADIANS"] = new RADIANS();
		definitions["RADIANS"] = new ExprFunctionDefinition("RADIANS", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "degrees")}"number", "Converts degrees into radians");
		functions["RAND"] = new RAND();
		definitions["RAND"] = new ExprFunctionDefinition("RAND", "Math Functions", new ParameterizedCompletion.Parameter[0], "number", "Returns a random number that is greater than or equal to 0 and less than 1");
		functions["REPLACE"] = new REPLACE();
		definitions["REPLACE"] = new ExprFunctionDefinition("REPLACE", "Text Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "old_text"),
			new ParameterizedCompletion.Parameter("number", "start"),
			new ParameterizedCompletion.Parameter("number", "number_of_chars"),
			new ParameterizedCompletion.Parameter("text", "new_text")
		}"text", "Replaces a sequence of characters in a string with another set of characters");
		functions["REPT"] = new REPT();
		definitions["REPT"] = new ExprFunctionDefinition("REPT", "Text Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "text"),
			new ParameterizedCompletion.Parameter("number", "num")
		}"text", "Returns a repeated text value a specified number of times");
		functions["RIGHT"] = new RIGHT();
		definitions["RIGHT"] = new ExprFunctionDefinition("RIGHT", "Text Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "text"),
			new ParameterizedCompletion.Parameter("number", "number_of_characters")
		}"text", "Extracts a substring from a string starting from the right-most character");
		functions["ROUND"] = new ROUND();
		definitions["ROUND"] = new ExprFunctionDefinition("ROUND", "Math Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "num"),
			new ParameterizedCompletion.Parameter("number", "digits")
		}"number", "Returns a number rounded to a specified number of digits");
		functions["ROUNDDOWN"] = new ROUNDDOWN();
		definitions["ROUNDDOWN"] = new ExprFunctionDefinition("ROUNDDOWN", "Math Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "num"),
			new ParameterizedCompletion.Parameter("number", "digits")
		}"number", "Returns a number rounded down to a specified number of digits.Always rounds towards 0.)");
		functions["ROUNDUP"] = new ROUNDUP();
		definitions["ROUNDUP"] = new ExprFunctionDefinition("ROUNDUP", "Math Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "num"),
			new ParameterizedCompletion.Parameter("number", "digits")
		}"number", "Returns a number rounded up to a specified number of digits.Rounds away from 0.)");
		functions["ROW"] = new ROW();
		definitions["ROW"] = new ExprFunctionDefinition("ROW", "Lookup & Reference Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "reference")}"number", "Returns the row number of a cell reference");
		functions["ROWS"] = new ROWS();
		definitions["ROWS"] = new ExprFunctionDefinition("ROWS", "Lookup & Reference Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "reference")}"number", "Returns the number of rows in a cell reference");
		functions["SEARCH"] = new SEARCH();
		definitions["SEARCH"] = new ExprFunctionDefinition("SEARCH", "Text Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "text1"),
			new ParameterizedCompletion.Parameter("text", "text2"),
			new ParameterizedCompletion.Parameter("number", "start_position")
		}"number", "Returns the location of a substring in a string.The search is NOT case-sensitive");
		functions["SECOND"] = new SECOND();
		definitions["SECOND"] = new ExprFunctionDefinition("SECOND", "Date & Time Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "serial_number")}"number", "Returns the second of a time value (from 0 to 59)");
		functions["SIGN"] = new SIGN();
		definitions["SIGN"] = new ExprFunctionDefinition("SIGN", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "num")}"number", "Returns the sign of a number. If the number is positive, the Sign function will return. If the number is negative, the Sign function will return. If the number is 0, the Sign function will return 0");
		functions["SIN"] = new SIN();
		definitions["SIN"] = new ExprFunctionDefinition("SIN", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "num")}"number", "Returns the sine of an angle");
		functions["SINH"] = new SINH();
		definitions["SINH"] = new ExprFunctionDefinition("SINH", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "num")}"number", "Returns the hyperbolic sine of a number");
		functions["SQRT"] = new SQRT();
		definitions["SQRT"] = new ExprFunctionDefinition("SQRT", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "num")}"number", "Returns the square root of a number");
		functions["STDEV"] = new STDEV();
		definitions["STDEV"] = new ExprFunctionDefinition("STDEV", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "number1"),
			new ParameterizedCompletion.Parameter("number", "number2"),
			new ParameterizedCompletion.Parameter("number", "Nnumber_n")
		}"number", "Returns the standard deviation of a population based on a sample of numbers");
		functions["STDEVP"] = new STDEVP();
		definitions["STDEVP"] = new ExprFunctionDefinition("STDEVP", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "number1"),
			new ParameterizedCompletion.Parameter("number", "number2"),
			new ParameterizedCompletion.Parameter("number", "Nnumber_n")
		}"number", "Returns the standard deviation of a population based on an entire population of numbers");
		functions["SUBSTITUTE"] = new SUBSTITUTE();
		definitions["SUBSTITUTE"] = new ExprFunctionDefinition("SUBSTITUTE", "Text Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "text"),
			new ParameterizedCompletion.Parameter("text", "old_text"),
			new ParameterizedCompletion.Parameter("text", "new_text"),
			new ParameterizedCompletion.Parameter("number", "nth_appearance")
		}"text", "Replaces a set of characters with another");
		functions["SUM"] = new SUM();
		definitions["SUM"] = new ExprFunctionDefinition("SUM", "Math Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "number1"),
			new ParameterizedCompletion.Parameter("number", "number2"),
			new ParameterizedCompletion.Parameter("number", "Nnumber_n")
		}"number", "Adds all numbers in a range of cells and returns the result");
		functions["SUMSQ"] = new SUMSQ();
		definitions["SUMSQ"] = new ExprFunctionDefinition("SUMSQ", "Math Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "value1"),
			new ParameterizedCompletion.Parameter("number", "value2"),
			new ParameterizedCompletion.Parameter("number", "Nvalue_n")
		}"number", "Returns the sum of the squares of a series of values");
		functions["SYD"] = new SYD();
		definitions["SYD"] = new ExprFunctionDefinition("SYD", "Financial Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "cost"),
			new ParameterizedCompletion.Parameter("number", "salvage"),
			new ParameterizedCompletion.Parameter("number", "life"),
			new ParameterizedCompletion.Parameter("number", "period")
		}"number", "Returns the depreciation of an asset for a given time period based on the sum-of-years' digits depreciation method");
		functions["T"] = new T();
		definitions["T"] = new ExprFunctionDefinition("T", "Text Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "value")}"text", "Tests whether a supplied value is text and if so, returns the supplied text; If not, returns an empty text string");
		functions["TAN"] = new TAN();
		definitions["TAN"] = new ExprFunctionDefinition("TAN", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "num")}"number", "Returns the tangent of an angle");
		functions["TANH"] = new TANH();
		definitions["TANH"] = new ExprFunctionDefinition("TANH", "Math Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "num")}"number", "Returns the hyperbolic tangent of a number");
		functions["TEXT"] = new TEXT();
		definitions["TEXT"] = new ExprFunctionDefinition("TEXT", "Text Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "value"),
			new ParameterizedCompletion.Parameter("text", "format")
		}"number", "Returns a value converted to text with a specified format");
		functions["TIME"] = new TIME();
		definitions["TIME"] = new ExprFunctionDefinition("TIME", "Date & Time Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "hour"),
			new ParameterizedCompletion.Parameter("number", "minute"),
			new ParameterizedCompletion.Parameter("number", "second")
		}"number", "Returns the decimal number for a particular time");
		functions["TODAY"] = new TODAY();
		definitions["TODAY"] = new ExprFunctionDefinition("TODAY", "Date & Time Functions", new ParameterizedCompletion.Parameter[0], "number", "Returns the current system date");
		functions["TRIM"] = new TRIM();
		definitions["TRIM"] = new ExprFunctionDefinition("TRIM", "Text Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("text", "text")}"text", "Returns a text value with the leading and trailing spaces removed");
		functions["TRUE"] = new TRUE();
		definitions["TRUE"] = new ExprFunctionDefinition("TRUE", "Logical Functions", new ParameterizedCompletion.Parameter[0], "boolean", "Returns a logical value of TRUE");
		functions["TRUNC"] = new TRUNC();
		definitions["TRUNC"] = new ExprFunctionDefinition("TRUNC", "Math Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "num"),
			new ParameterizedCompletion.Parameter("number", "digits")
		}"number", "Returns a number truncated to a specified number of digits");
		functions["TYPE"] = new TYPE();
		definitions["TYPE"] = new ExprFunctionDefinition("TYPE", "Information Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("text", "value")}"boolean", "Returns the type of a value");
		functions["UPPER"] = new UPPER();
		definitions["UPPER"] = new ExprFunctionDefinition("UPPER", "Text Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("text", "text")}"text", "Allows you to convert text to all uppercase");
		functions["VALUE"] = new VALUE();
		definitions["VALUE"] = new ExprFunctionDefinition("VALUE", "Text Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "text")}"number", "Converts a text value that represents a number to a number");
		functions["VAR"] = new VAR();
		definitions["VAR"] = new ExprFunctionDefinition("VAR", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "number1"),
			new ParameterizedCompletion.Parameter("number", "number2"),
			new ParameterizedCompletion.Parameter("number", "Nnumber_n")
		}"number", "Returns the variance of a population based on a sample of numbers");
		functions["VARA"] = new VARA();
		definitions["VARA"] = new ExprFunctionDefinition("VARA", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "value1"),
			new ParameterizedCompletion.Parameter("text", "value2"),
			new ParameterizedCompletion.Parameter("text", "Nvalue_n")
		}"boolean", "Returns the variance of a population based on a sample of numbers, text, and logical values (ie: TRUE or FALSE)");
		functions["VARP"] = new VARP();
		definitions["VARP"] = new ExprFunctionDefinition("VARP", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "number1"),
			new ParameterizedCompletion.Parameter("number", "number2"),
			new ParameterizedCompletion.Parameter("number", "Nnumber_n")
		}"number", "Returns the variance of a population based on an entire population of numbers");
		functions["VARPA"] = new VARPA();
		definitions["VARPA"] = new ExprFunctionDefinition("VARPA", "Statistical Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "value1"),
			new ParameterizedCompletion.Parameter("text", "value2"),
			new ParameterizedCompletion.Parameter("text", "Nvalue_n")
		}"boolean", "Returns the variance of a population based on an entire population of numbers, text, and logical values (ie: TRUE or FALSE)");
		functions["VDB"] = new VDB();
		definitions["VDB"] = new ExprFunctionDefinition("VDB", "Financial Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "cost"),
			new ParameterizedCompletion.Parameter("number", "salvage"),
			new ParameterizedCompletion.Parameter("number", "life"),
			new ParameterizedCompletion.Parameter("number", "start_period"),
			new ParameterizedCompletion.Parameter("number", "end_period"),
			new ParameterizedCompletion.Parameter("number", "factor"),
			new ParameterizedCompletion.Parameter("boolean", "no_switch")
		}"boolean", "Returns the depreciation of an asset for a given time period based on a variable declining balance depreciation method");
		functions["WEEKDAY"] = new WEEKDAY();
		definitions["WEEKDAY"] = new ExprFunctionDefinition("WEEKDAY", "Date & Time Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "serial_number"),
			new ParameterizedCompletion.Parameter("number", "return_value")
		}"number", "Returns a number representing the day of the week, given a date value");
		functions["YEAR"] = new YEAR();
		definitions["YEAR"] = new ExprFunctionDefinition("YEAR", "Date & Time Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "date_value")}"number", "Returns a four-digit year(a number from 1900 to 9999) given a date value");
		functions["PRJHQL"] = new ProjectHQL();
		definitions["PRJHQL"] = new ExprFunctionDefinition("PRJHQL", "Project Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "sql_query"),
			new ParameterizedCompletion.Parameter("text", "sqlParam1")
		}"array", "Creates an HQL Query on the Project Database, and returns the results as an array of values.");
		functions["PRJSQL"] = new ProjectSQL();
		definitions["PRJSQL"] = new ExprFunctionDefinition("PRJSQL", "Project Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "sql_query"),
			new ParameterizedCompletion.Parameter("text", "sqlParam1")
		}"array", "Creates an SQL Query on the Project Database, and returns the results as an array of values.");
		functions["RESDBHQL"] = new ResourceDBHQL();
		definitions["RESDBHQL"] = new ExprFunctionDefinition("RESDBHQL", "Project Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "sql_query"),
			new ParameterizedCompletion.Parameter("text", "sqlParam1")
		}"array", "Creates an HQL Query on the Resources Database, and returns the results as an array of values.");
		functions["RESDBSQL"] = new ResourceDBSQL();
		definitions["RESDBSQL"] = new ExprFunctionDefinition("RESDBSQL", "Project Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "sql_query"),
			new ParameterizedCompletion.Parameter("text", "sqlParam1")
		}"array", "Creates an SQL Query on the Resources Database, and returns the results as an array of values.");
		functions["BIMQTO"] = new BimQuantityTakeoff();
		definitions["BIMQTO"] = new ExprFunctionDefinition("BIMQTO", "Project Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "bimModel"),
			new ParameterizedCompletion.Parameter("text", "objectType"),
			new ParameterizedCompletion.Parameter("text", "qtyName"),
			new ParameterizedCompletion.Parameter("text", "qtyUom"),
			new ParameterizedCompletion.Parameter("text", "whereClause"),
			new ParameterizedCompletion.Parameter("text", "whereClauseParam1")
		}"number", "Creates an Automatic Quantity Takeoff on the specified selecting all the specified objectTypes with qtyName and qtyUom, optional where clause is available.");
		functions["QTOADD"] = new QuantityTakeoffAdd();
		definitions["QTOADD"] = new ExprFunctionDefinition("QTOADD", "Project Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "takeoff1"),
			new ParameterizedCompletion.Parameter("number", "takeoff2")
		}"number", "Creates a new takeoff element from the takeoff parameters.");
		functions["GLOBAL_QUANTITY"] = new GlobalTakeoffQuantity();
		definitions["GLOBAL_QUANTITY"] = new ExprFunctionDefinition("GLOBAL_QUANTITY", "Project Functions", new ParameterizedCompletion.Parameter[0], "number", "Returns the assembly global quantity or 1 if not existing.");
		functions["CURRENT_ASSEMBLY_ID"] = new ParamItemId();
		definitions["CURRENT_ASSEMBLY_ID"] = new ExprFunctionDefinition("CURRENT_ASSEMBLY_ID", "Assembly Functions", new ParameterizedCompletion.Parameter[0], "number", "Returns the id of the current loaded assembly or 0 if it is new assembly or not existing.");
		functions["CURRENT_SELECTED_BOQ_IDS"] = new BoqItemId();
		definitions["CURRENT_SELECTED_BOQ_IDS"] = new ExprFunctionDefinition("CURRENT_SELECTED_BOQ_IDS", "Array Functions", new ParameterizedCompletion.Parameter[0], "array", "Returns the selected boq item ids of the selected project as an 1-column array, or 0 if no project or boq items selected.");
		functions["PRJSTARTDATE"] = new ProjectStartDate();
		definitions["PRJSTARTDATE"] = new ExprFunctionDefinition("PRJSTARTDATE", "Project Functions", new ParameterizedCompletion.Parameter[0], "date", "Returns the start date of the current project");
		functions["PRJDURATION"] = new ProjectDurationInMonths();
		definitions["PRJDURATION"] = new ExprFunctionDefinition("PRJDURATION", "Project Functions", new ParameterizedCompletion.Parameter[0], "number", "Returns an integer representing the current projects duration in months");
		functions["PRJLOCATION"] = new ProjectLocation();
		definitions["PRJLOCATION"] = new ExprFunctionDefinition("PRJLOCATION", "Project Functions", new ParameterizedCompletion.Parameter[0], "text", "Returns a text string representing the location of the current project");
		functions["PRJSTATEPROVINCE"] = new ProjectStateProvince();
		definitions["PRJSTATEPROVINCE"] = new ExprFunctionDefinition("PRJSTATEPROVINCE", "Project Functions", new ParameterizedCompletion.Parameter[0], "text", "Returns the state province of the current project");
		functions["PRJCOUNTRY"] = new ProjectCountry();
		definitions["PRJCOUNTRY"] = new ExprFunctionDefinition("PRJCOUNTRY", "Project Functions", new ParameterizedCompletion.Parameter[0], "text", "Returns the country of the current project");
		functions["PRJCODE"] = new ProjectCode();
		definitions["PRJCODE"] = new ExprFunctionDefinition("PRJCODE", "Project Functions", new ParameterizedCompletion.Parameter[0], "text", "Returns the code of the current project");
		functions["PRJID"] = new ProjectId();
		definitions["PRJID"] = new ExprFunctionDefinition("PRJID", "Project Functions", new ParameterizedCompletion.Parameter[0], "number", "Returns the id number of the current project/(url)");
		functions["PRJNAME"] = new ProjectName();
		definitions["PRJNAME"] = new ExprFunctionDefinition("PRJNAME", "Project Functions", new ParameterizedCompletion.Parameter[0], "text", "Returns the name of the current project");
		functions["PRJDBNAME"] = new ProjectDatabaseName();
		definitions["PRJDBNAME"] = new ExprFunctionDefinition("PRJDBNAME", "Project Functions", new ParameterizedCompletion.Parameter[0], "text", "Returns the sql server database name of the current project");
		functions["PRJCURRENCY"] = new ProjectCurrency();
		definitions["PRJCURRENCY"] = new ExprFunctionDefinition("PRJCURRENCY", "Project Functions", new ParameterizedCompletion.Parameter[0], "text", "Returns the currency code of the current project");
		functions["PRJVARIABLE"] = new ProjectVariable();
		definitions["PRJVARIABLE"] = new ExprFunctionDefinition("PRJVARIABLE", "Project Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("text", "pvName")}"text", "Returns the project variable value of the current project");
		functions["VAR"] = new ProjectVariableAsNumber();
		definitions["VAR"] = new ExprFunctionDefinition("VAR", "Project Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("text", "\"\"")}"text", "Returns the project variable value (as number) of the current project or 0 if value is not a number or value is not found.");
		functions["SHEET_ROW_AT"] = new SheetRowAt();
		definitions["SHEET_ROW_AT"] = new ExprFunctionDefinition("SHEET_ROW_AT", "Project Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "sheetName"),
			new ParameterizedCompletion.Parameter("number", "colIndex"),
			new ParameterizedCompletion.Parameter("text", "value")
		}"number", "Returns the row index or -1 if nothing found, given the column index as NUMBER and the value as TEXT, in the specified sheet.\n--colIndex is 1-based");
		functions["SHEET_VALUE_AT"] = new SheetValueAt();
		definitions["SHEET_VALUE_AT"] = new ExprFunctionDefinition("SHEET_VALUE_AT", "Project Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "sheetName"),
			new ParameterizedCompletion.Parameter("number", "rowIndex"),
			new ParameterizedCompletion.Parameter("number", "colIndex"),
			new ParameterizedCompletion.Parameter("text", "returnValue")
		}"text", "Returns the value as TEXT, given the row index as NUMBER and the column index as NUMBER, in the specified sheet.\n--rowIndex, colIndex are 1-based\n--returnValue as TEXT, is the value to return if sheet name does not exist, rowIndex or colIndex are out of range, or any other problem occurs");
		functions["ARG_SHOWING"] = new IsArgInShowing();
		definitions["ARG_SHOWING"] = new ExprFunctionDefinition("ARG_SHOWING", "Argument-In Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("text", "argInName")}"text", "Checks if the supplied argument in name is shown on the form page.");
		functions["ARG_VALID_SHOWING"] = new IsArgInValidAndShowing();
		definitions["ARG_VALID_SHOWING"] = new ExprFunctionDefinition("ARG_VALID_SHOWING", "Argument-In Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("text", "argInName")}"text", "Checks if the supplied argument in name is shown on the form page and is valid as well.");
		functions["ARRAY_COLUMN_COUNT"] = new ArrayColumnCount();
		definitions["ARRAY_COLUMN_COUNT"] = new ExprFunctionDefinition("ARRAY_COLUMN_COUNT", "Array Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("array", "array")}"array", "Returns the columns count of an Array.");
		functions["ARRAY_ROW_COUNT"] = new ArrayRowCount();
		definitions["ARRAY_ROW_COUNT"] = new ExprFunctionDefinition("ARRAY_ROW_COUNT", "Array Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("array", "array")}"array", "Returns the rows count of an Array.");
		functions["ARRAY_GET"] = new ArrayGet();
		definitions["ARRAY_GET"] = new ExprFunctionDefinition("ARRAY_GET", "Array Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("array", "array"),
			new ParameterizedCompletion.Parameter("number", "columnIndex"),
			new ParameterizedCompletion.Parameter("array", "rowIndex")
		}"array", "Returns the value (number/text) of the array in the specified indexed position.");
		functions["ARRAY_GET_FN"] = new ArrayGetFirstNumber();
		definitions["ARRAY_GET_FN"] = new ExprFunctionDefinition("ARRAY_GET_FN", "Array Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("array", "array")}"array", "Returns the first value of the array as a number, 0 if not found or text.");
		functions["ARRAY_CREATE"] = new ArrayCreate();
		definitions["ARRAY_CREATE"] = new ExprFunctionDefinition("ARRAY_CREATE", "Array Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "columnCount"),
			new ParameterizedCompletion.Parameter("number", "rowData")
		}"array", "Creates a new Array with columnCount columns and specified data from parameters.");
		functions["ARRAY_CREATE_BLANK"] = new ArrayCreateBlank();
		definitions["ARRAY_CREATE_BLANK"] = new ExprFunctionDefinition("ARRAY_CREATE_BLANK", "Array Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "columnCount"),
			new ParameterizedCompletion.Parameter("number", "rowCount"),
			new ParameterizedCompletion.Parameter("text", "defBlankValue")
		}"array", "Creates a Blank new Array with rowCount, columnCount and a default blank value.");
		functions["ARRAY_MERGE"] = new ArrayMerge();
		definitions["ARRAY_MERGE"] = new ExprFunctionDefinition("ARRAY_MERGE", "Array Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("number", "columnCount"),
			new ParameterizedCompletion.Parameter("array", "inArray1"),
			new ParameterizedCompletion.Parameter("array", "inArray2")
		}"array", "Creates a new Array with columnCount columns that contains the merged arrays or data.");
		functions["ARRAY_ADD_COLUMN"] = new ArrayAddColumn();
		definitions["ARRAY_ADD_COLUMN"] = new ExprFunctionDefinition("ARRAY_ADD_COLUMN", "Array Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("array", "array1"),
			new ParameterizedCompletion.Parameter("number", "array2")
		}"array", "Adds more columns to array1 with data from array2, array3 etc.");
		functions["ARRAY_TITLE"] = new ArrayTitle();
		definitions["ARRAY_TITLE"] = new ExprFunctionDefinition("ARRAY_TITLE", "Array Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("array", "array"),
			new ParameterizedCompletion.Parameter("text", "columnTitles")
		}"array", "Creates a new Array with same data adding the specified column titles on first the row of the array.");
		functions["ARRAY_PLUS_ARRAY"] = new ArrayPlusArray();
		definitions["ARRAY_PLUS_ARRAY"] = new ExprFunctionDefinition("ARRAY_PLUS_ARRAY", "Array Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("array", "array1"),
			new ParameterizedCompletion.Parameter("array", "array2")
		}"array", "Creates a new Array that is the result of adding array1 to array2 to array3 etc.");
		functions["ARRAY_MINUS_ARRAY"] = new ArrayMinusArray();
		definitions["ARRAY_MINUS_ARRAY"] = new ExprFunctionDefinition("ARRAY_MINUS_ARRAY", "Array Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("array", "array1"),
			new ParameterizedCompletion.Parameter("array", "array2")
		}"array", "Creates a new Array that is the result of subtracting array2 from array1 etc.");
		functions["ARRAY_MULT_ARRAY"] = new ArrayMultiplyArray();
		definitions["ARRAY_MULT_ARRAY"] = new ExprFunctionDefinition("ARRAY_MULT_ARRAY", "Array Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("array", "array1"),
			new ParameterizedCompletion.Parameter("array", "array2")
		}"array", "Creates a new Array that is the result of multiplying array1 with array2, array3 etc.");
		functions["ARRAY_DIV_ARRAY"] = new ArrayDivideArray();
		definitions["ARRAY_DIV_ARRAY"] = new ExprFunctionDefinition("ARRAY_DIV_ARRAY", "Array Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("array", "array1"),
			new ParameterizedCompletion.Parameter("array", "array2")
		}"array", "Creates a new Array that is the result of dividing array2 from array1 etc.");
		functions["ARRAY_LOOP_INDEX"] = new ArrayIndex();
		definitions["ARRAY_LOOP_INDEX"] = new ExprFunctionDefinition("ARRAY_LOOP_INDEX", "Array Functions", new ParameterizedCompletion.Parameter[0], "number", "Returns the index of the currently looping array, applies to generation condition items.");
		functions["ARRAY_CELL_ROW_INDEX"] = new ArrayIndex();
		definitions["ARRAY_CELL_ROW_INDEX"] = new ExprFunctionDefinition("ARRAY_CELL_ROW_INDEX", "Array Functions", new ParameterizedCompletion.Parameter[0], "number", "Returns the index of the cell's row, applies when doing nested calculations in input Arrays.");
		functions["ARRAY_CELL_VALUE"] = new CellValue();
		definitions["ARRAY_CELL_VALUE"] = new ExprFunctionDefinition("ARRAY_CELL_VALUE", "Array Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("number", "columnIndex")}"number", "Returns the value of the cell in the specified columnIndex, applies to Assembly Arrays with Formulas only.");
		functions["ARRAY_ABS"] = new ArrayAbsArray();
		definitions["ARRAY_ABS"] = new ExprFunctionDefinition("ARRAY_ABS", "Array Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("array", "array")}"array", "Returns a new array that contains the absolute values of the parameter.");
		functions["ARRAY_FROM_TEXT"] = new ArrayFromText();
		definitions["ARRAY_FROM_TEXT"] = new ExprFunctionDefinition("ARRAY_FROM_TEXT", "Array Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "text"),
			new ParameterizedCompletion.Parameter("text", "spliter")
		}"array", "Returns an array from a text string by splitting down the text based on the spliter.");
		functions["ARRAY_PLUS_NUMBER"] = new ArrayPlusNumber();
		definitions["ARRAY_PLUS_NUMBER"] = new ExprFunctionDefinition("ARRAY_PLUS_NUMBER", "Array Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("array", "array"),
			new ParameterizedCompletion.Parameter("number", "valueToAdd")
		}"array", "Returns a new array that contains the array values plus the valueToAdd.");
		functions["ARRAY_MINUS_NUMBER"] = new ArrayMinusNumber();
		definitions["ARRAY_MINUS_NUMBER"] = new ExprFunctionDefinition("ARRAY_MINUS_NUMBER", "Array Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("array", "array"),
			new ParameterizedCompletion.Parameter("number", "valueToSubtract")
		}"array", "Returns a new array that contains the array values subtracted by the specified number.");
		functions["ARRAY_MULT_NUMBER"] = new ArrayMultiplyNumber();
		definitions["ARRAY_MULT_NUMBER"] = new ExprFunctionDefinition("ARRAY_MULT_NUMBER", "Array Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("array", "array"),
			new ParameterizedCompletion.Parameter("number", "valueToMult")
		}"array", "Returns a new array that contains the array values multiplied with the specified number.");
		functions["ARRAY_DIV_NUMBER"] = new ArrayDivideNumber();
		definitions["ARRAY_DIV_NUMBER"] = new ExprFunctionDefinition("ARRAY_DIV_NUMBER", "Array Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("array", "array"),
			new ParameterizedCompletion.Parameter("number", "valueToDivide")
		}"array", "Returns a new array that contains the array values divided by the specified number.");
		functions["ARRAY_SUB_COLUMN"] = new SubColumnArray();
		definitions["ARRAY_SUB_COLUMN"] = new ExprFunctionDefinition("ARRAY_SUB_COLUMN", "Array Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("array", "sourceArray"),
			new ParameterizedCompletion.Parameter("number", "colIndex")
		}"array", "Creates a new Sub-Array from the specified column indices.");
		functions["ARRAY_SUB_ROW"] = new SubRowArray();
		definitions["ARRAY_SUB_ROW"] = new ExprFunctionDefinition("ARRAY_SUB_ROW", "Array Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("array", "sourceArray"),
			new ParameterizedCompletion.Parameter("number", "colIndex")
		}"array", "Creates a new Sub-Array from the specified row indices.");
		functions["ARRAY_COLUMN_INDEX"] = new ArrayColumnIndex();
		definitions["ARRAY_COLUMN_INDEX"] = new ExprFunctionDefinition("ARRAY_COLUMN_INDEX", "Array Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("array", "array"),
			new ParameterizedCompletion.Parameter("text", "colName")
		}"array", "Finds and returns the index of a column from the colName parameter.");
		functions["ARRAY_ROW_INDEX"] = new ArrayRowIndex();
		definitions["ARRAY_ROW_INDEX"] = new ExprFunctionDefinition("ARRAY_ROW_INDEX", "Array Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("array", "array"),
			new ParameterizedCompletion.Parameter("text", "rowName"),
			new ParameterizedCompletion.Parameter("number", "colIndex")
		}"array", "Finds and returns the index of a row from the rowName parameter at the specified column Index.");
		ParameterizedCompletion.Parameter parameter1 = new ParameterizedCompletion.Parameter("text", "value");
		parameter1.Description = "the STOVAL value of the array input argument in project database";
		ParameterizedCompletion.Parameter parameter2 = new ParameterizedCompletion.Parameter("boolean", "supportFormulas");
		parameter2.Description = "TRUE() if assembly array has formulas, FALSE() otherwise";
		ParameterizedCompletion.Parameter parameter3 = new ParameterizedCompletion.Parameter("boolean", "showHeader");
		parameter3.Description = "TRUE() to show header row, FALSE() otherwise";
		functions["ARRAY_FROM_ASSEMBLY_ARRAY"] = new ArrayFromAssemblyArray();
		definitions["ARRAY_FROM_ASSEMBLY_ARRAY"] = new ExprFunctionDefinition("ARRAY_FROM_ASSEMBLY_ARRAY", "Array Functions", new ParameterizedCompletion.Parameter[] {parameter1, parameter2, parameter3}, "array", "Returns an array as defined in the Assembly interview. Example: ARRAY_FROM_ASSEMBLY_ARRAY(ARRAY_GET(PRJSQL(\"SELECT STOVAL FROM PARAMINPUT WHERE PRJID=? AND NAME='Pro_CPR_array'\",PRJID()),1,1),TRUE(),TRUE())");
		ParameterizedCompletion.Parameter parameter4 = new ParameterizedCompletion.Parameter("text", "value");
		parameter4.Description = "the STOVAL value of the array input argument in project database";
		ParameterizedCompletion.Parameter parameter5 = new ParameterizedCompletion.Parameter("number", "startColIndex");
		parameter5.Description = "the column index to start with";
		ParameterizedCompletion.Parameter parameter6 = new ParameterizedCompletion.Parameter("number", "numOfCols");
		parameter6.Description = "the number of columns to show after start column index";
		ParameterizedCompletion.Parameter parameter7 = new ParameterizedCompletion.Parameter("boolean", "supportFormulas");
		parameter7.Description = "TRUE() if assembly array has formulas, FALSE() otherwise";
		ParameterizedCompletion.Parameter parameter8 = new ParameterizedCompletion.Parameter("boolean", "showHeader");
		parameter8.Description = "TRUE() to show header row, FALSE() otherwise";
		functions["ARRAY_FROM_ASSEMBLY_ARRAY_PARTIAL"] = new ArrayFromAssemblyArrayPartial();
		definitions["ARRAY_FROM_ASSEMBLY_ARRAY_PARTIAL"] = new ExprFunctionDefinition("ARRAY_FROM_ASSEMBLY_ARRAY_PARTIAL", "Array Functions", new ParameterizedCompletion.Parameter[] {parameter4, parameter5, parameter6, parameter7, parameter8}, "array", "Returns an array as defined in the Assembly interview. Example: ARRAY_FROM_ASSEMBLY_ARRAY_PARTIAL(ARRAY_GET(PRJSQL(\"SELECT STOVAL FROM PARAMINPUT WHERE PRJID=? AND NAME='Pro_CPR_array'\",PRJID()),1,1),2,3,TRUE(),TRUE())");
		ParameterizedCompletion.Parameter parameter9 = new ParameterizedCompletion.Parameter("text", "value");
		parameter9.Description = "the STOVAL value of the array input argument in project database";
		ParameterizedCompletion.Parameter parameter10 = new ParameterizedCompletion.Parameter("number", "rowIndex");
		parameter10.Description = "the row index to query";
		ParameterizedCompletion.Parameter parameter11 = new ParameterizedCompletion.Parameter("number", "colIndex");
		parameter11.Description = "the column index to query";
		ParameterizedCompletion.Parameter parameter12 = new ParameterizedCompletion.Parameter("boolean", "supportFormulas");
		parameter12.Description = "TRUE() if assembly array has formulas, FALSE() otherwise";
		ParameterizedCompletion.Parameter parameter13 = new ParameterizedCompletion.Parameter("boolean", "includeHeader");
		parameter13.Description = "TRUE() to include header row, FALSE() otherwise";
		functions["ARRAY_GET_FROM_ASSEMBLY_ARRAY"] = new ArrayGetFromAssemblyArray();
		definitions["ARRAY_GET_FROM_ASSEMBLY_ARRAY"] = new ExprFunctionDefinition("ARRAY_GET_FROM_ASSEMBLY_ARRAY", "Array Functions", new ParameterizedCompletion.Parameter[] {parameter9, parameter10, parameter11, parameter12, parameter13}, "array", "Returns the value of an assembly array in the specified row and column index. Example: ARRAY_GET_FROM_ASSEMBLY_ARRAY(ARRAY_GET(PRJSQL(\"SELECT STOVAL FROM PARAMINPUT WHERE PRJID=? AND NAME='Unit_Rates_Array'\",PRJID()),1,1),2,3,TRUE(),FALSE())");
		ParameterizedCompletion.Parameter parameter14 = new ParameterizedCompletion.Parameter("array", "array");
		parameter14.Description = "the array to iterate through";
		ParameterizedCompletion.Parameter parameter15 = new ParameterizedCompletion.Parameter("text", "textToSearch");
		parameter15.Description = "the text to search";
		ParameterizedCompletion.Parameter parameter16 = new ParameterizedCompletion.Parameter("number", "colToSearchText");
		parameter16.Description = "the column index to search for text";
		ParameterizedCompletion.Parameter parameter17 = new ParameterizedCompletion.Parameter("number", "size1");
		parameter17.Description = "the size1 to find in range1";
		ParameterizedCompletion.Parameter parameter18 = new ParameterizedCompletion.Parameter("number", "beginColRange1");
		parameter18.Description = "the begin column index in range1";
		ParameterizedCompletion.Parameter parameter19 = new ParameterizedCompletion.Parameter("number", "endColRange1");
		parameter19.Description = "the end column index in range1";
		ParameterizedCompletion.Parameter parameter20 = new ParameterizedCompletion.Parameter("number", "size2");
		parameter20.Description = "the size2 to find in range2 [If no size2 put 0]";
		ParameterizedCompletion.Parameter parameter21 = new ParameterizedCompletion.Parameter("number", "beginColRange2");
		parameter21.Description = "the begin column index in range2 [If no size2 put 0]";
		ParameterizedCompletion.Parameter parameter22 = new ParameterizedCompletion.Parameter("number", "endColRange2");
		parameter22.Description = "the end column index in range2 [If no size2 put 0]";
		ParameterizedCompletion.Parameter parameter23 = new ParameterizedCompletion.Parameter("number", "colToReturn");
		parameter23.Description = "the column index to return";
		functions["ARRAY_FROM_ARRAY_CUSTOM"] = new ArrayFromArrayCustom();
		definitions["ARRAY_FROM_ARRAY_CUSTOM"] = new ExprFunctionDefinition("ARRAY_FROM_ARRAY_CUSTOM", "Array Functions", new ParameterizedCompletion.Parameter[] {parameter14, parameter15, parameter16, parameter17, parameter18, parameter19, parameter20, parameter21, parameter22, parameter23}, "array", "Returns a list of values as an 1-column array, using data of the return column (colToReturn), when given text matches and size1, size2 are in range1, range2 respectively");
		functions["UNIT1_TO_UNIT2"] = new Unit1ToUnit2();
		definitions["UNIT1_TO_UNIT2"] = new ExprFunctionDefinition("UNIT1_TO_UNIT2", "Conversion Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("text", "unitOfMeasure")}"text", "Automatically chooses a unit to the opposite system (ie from metric to imperial and vice versa).");
		functions["UNIT1_TO_UNIT2_DIV"] = new Unit1ToUnit2Div();
		definitions["UNIT1_TO_UNIT2_DIV"] = new ExprFunctionDefinition("UNIT1_TO_UNIT2_DIV", "Conversion Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("text", "unitOfMeasure")}"text", "Automatically chooses a unit to the opposite system and return the conversion factor from unit 1 to unit 2.");
		functions["EXTRACT_GROUP_CODE"] = new ExtractCodeLevel();
		definitions["EXTRACT_GROUP_CODE"] = new ExprFunctionDefinition("EXTRACT_GROUP_CODE", "Conversion Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "groupCodeName"),
			new ParameterizedCompletion.Parameter("text", "groupCode"),
			new ParameterizedCompletion.Parameter("boolean", "titleOnly"),
			new ParameterizedCompletion.Parameter("number", "level")
		}"text", "Returns the parent code of a specified group code in the parent level specified, full code or title only.");
		functions["EXTRACT_GROUP_CODE_UNIT"] = new ExtractCodeLevelUnit();
		definitions["EXTRACT_GROUP_CODE_UNIT"] = new ExprFunctionDefinition("EXTRACT_GROUP_CODE_UNIT", "Conversion Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "groupCodeName"),
			new ParameterizedCompletion.Parameter("text", "groupCode"),
			new ParameterizedCompletion.Parameter("number", "level")
		}"text", "Returns the unit of a specified group code in the parent level specified.");
		functions["EXTRACT_GROUP_CODE_NOTES"] = new ExtractCodeLevelNotes();
		definitions["EXTRACT_GROUP_CODE_NOTES"] = new ExprFunctionDefinition("EXTRACT_GROUP_CODE_NOTES", "Conversion Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "groupCodeName"),
			new ParameterizedCompletion.Parameter("text", "groupCode"),
			new ParameterizedCompletion.Parameter("number", "level")
		}"text", "Returns the notes of a specified group code in the parent level specified.");
		functions["EXTRACT_GROUP_CODE_FACTOR"] = new ExtractCodeLevelFactor();
		definitions["EXTRACT_GROUP_CODE_FACTOR"] = new ExprFunctionDefinition("EXTRACT_GROUP_CODE_FACTOR", "Conversion Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("text", "groupCodeName"),
			new ParameterizedCompletion.Parameter("text", "groupCode"),
			new ParameterizedCompletion.Parameter("number", "level")
		}"text", "Returns the parent unit factor of a specified group code in the parent level specified.");
		functions["FACTOR_FROM_LOCATION"] = new FactorFromLocation();
		definitions["FACTOR_FROM_LOCATION"] = new ExprFunctionDefinition("FACTOR_FROM_LOCATION", "Location Factors Functions", new ParameterizedCompletion.Parameter[]
		{
			new ParameterizedCompletion.Parameter("locfactor", "location"),
			new ParameterizedCompletion.Parameter("locfactor", "factorType")
		}"number", "Returns the factor of the location according to the type specified, use 0:Productivity, 1:Equipment, 2:Subcontractor, 3:Labor, 4. Material, 5. Consumale");
		functions["COUNTRY_FROM_LOCATION"] = new CountryFromLocation();
		definitions["COUNTRY_FROM_LOCATION"] = new ExprFunctionDefinition("COUNTRY_FROM_LOCATION", "Location Factors Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("locfactor", "location")}"text", "Returns the country of the location.");
		functions["STATE_FROM_LOCATION"] = new StateFromLocation();
		definitions["STATE_FROM_LOCATION"] = new ExprFunctionDefinition("STATE_FROM_LOCATION", "Location Factors Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("locfactor", "location")}"text", "Returns the state of the location.");
		functions["CITY_FROM_LOCATION"] = new CityFromLocation();
		definitions["CITY_FROM_LOCATION"] = new ExprFunctionDefinition("CITY_FROM_LOCATION", "Location Factors Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("locfactor", "location")}"text", "Returns the city of the location.");
		functions["ZIPCODE_FROM_LOCATION"] = new ZipCodeFromLocation();
		definitions["ZIPCODE_FROM_LOCATION"] = new ExprFunctionDefinition("ZIPCODE_FROM_LOCATION", "Location Factors Functions", new ParameterizedCompletion.Parameter[] {new ParameterizedCompletion.Parameter("locfactor", "location")}"text", "Returns the zip code of the location.");
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\ExprExcelFunctionProvider.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}