using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.expr.takeoff
{
	using BIMQuantityType = nomitech.common.bim.BIMQuantityType;
	using ConditionTable = nomitech.common.db.project.ConditionTable;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	using StringUtils = nomitech.common.util.StringUtils;
	using Expr = org.boris.expr.Expr;
	using ExprArray = org.boris.expr.ExprArray;
	using ExprBoolean = org.boris.expr.ExprBoolean;
	using ExprDouble = org.boris.expr.ExprDouble;
	using ExprException = org.boris.expr.ExprException;
	using ExprInteger = org.boris.expr.ExprInteger;
	using ExprNumber = org.boris.expr.ExprNumber;
	using ExprString = org.boris.expr.ExprString;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;
	using Query = org.hibernate.Query;

	public class BimQuantityTakeoff : AbstractFunction
	{
	  private const string QUERY_QTO_PREFIX_SQL = "SELECT e.IFCTITLE as \"title\", e.IFCDESCRIPTION as \"description\", e.IFCBUILDING as \"building\", e.IFCSTOREY as \"storey\", e.IFCLAYER as \"layer\", e.IFCLOCATION as \"location\", e.IFCMATERIAL as \"bimMaterial\", e.IFCOBJECTTYPE as \"bimType\",e.IFCFILE as \"databaseName\", '  ' as \"username\", '  ' as \"password\", e.IFCFNAME as \"host\", e.CNDID as \"bidNo\", e.CNDID as \"cndNo\", e.CNDID as \"cndId\", e.IFCID as \"globalId\", e.IFCOBJECTTYPE as \"cndType\", 'BIM' as \"takeOffType\", e.IFCQTY2 as \"quantity2\", e.IFCQTY3 as \"quantity3\", NULL as \"quantityF\",e.IFCQTYNAME2 as \"quantity2Name\", e.IFCQTYNAME3 as \"quantity3Name\", '  ' as \"quantityFName\",e.IFCUOM2 as \"unit2\", e.IFCUOM3 as \"unit3\", '  ' as \"unitF\", '  ' as \"formulaF\", p.IFCPROPNAME as \"quantity1Name\", ':unitParam' as \"unit1\", (:quantityQuery) as \"quantity1\", 1 as \"defaultQuantity\" FROM IFCELEMENT AS e INNER JOIN IFCPROPERTY p ON e.ELEMID = p.ELEMID WHERE e.PRJID = :prjId AND (p.IFCNUMVAL is not null AND e.IFCMODEL = ':modelName' AND p.IFCPROPNAME = :propertyNameParam AND e.IFCOBJECTTYPE = ':objectTypeParam' AND p.IFCQTYTYPE = :quantityTypeParam)";

	  private static readonly ISet<string> s_ifcObjectTypes = new HashSet<object>();

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertMinArgCount(paramArrayOfExpr, 4);
		for (sbyte b = 0; b < paramArrayOfExpr.Length; b++)
		{
		  if (paramArrayOfExpr[b] is org.boris.expr.ExprEvaluatable)
		  {
			paramArrayOfExpr[b] = evalArg(paramIEvaluationContext, paramArrayOfExpr[b]);
		  }
		}
		string str1 = "p.IFCNUMVAL:unitFactorQuery";
		string str2 = (paramArrayOfExpr[0] is ExprString) ? ((ExprString)paramArrayOfExpr[0]).str : paramArrayOfExpr[0].ToString();
		string str3 = (paramArrayOfExpr[1] is ExprString) ? ((ExprString)paramArrayOfExpr[1]).str : paramArrayOfExpr[1].ToString();
		string str4 = (paramArrayOfExpr[2] is ExprString) ? ((ExprString)paramArrayOfExpr[2]).str : paramArrayOfExpr[2].ToString();
		string str5 = (paramArrayOfExpr[3] is ExprString) ? ((ExprString)paramArrayOfExpr[3]).str : paramArrayOfExpr[3].ToString();
		string str6 = (paramArrayOfExpr.Length >= 5) ? ((paramArrayOfExpr[4] is ExprString) ? ((ExprString)paramArrayOfExpr[4]).str : paramArrayOfExpr[4].ToString()) : null;
		int i = findQtyType(str5);
		ProjectDBUtil projectDBUtil = ProjectDBUtil.currentProjectDBUtil();
		if (projectDBUtil == null)
		{
		  return new ExprTakeoff(-1.0D, null);
		}
		decimal bigDecimal = BigDecimalMath.ZERO;
		ConditionTable[] arrayOfConditionTable = null;
		bool @bool = projectDBUtil.hasOpenedSession();
		try
		{
		  string str7 = "SELECT e.IFCTITLE as \"title\", e.IFCDESCRIPTION as \"description\", e.IFCBUILDING as \"building\", e.IFCSTOREY as \"storey\", e.IFCLAYER as \"layer\", e.IFCLOCATION as \"location\", e.IFCMATERIAL as \"bimMaterial\", e.IFCOBJECTTYPE as \"bimType\",e.IFCFILE as \"databaseName\", '  ' as \"username\", '  ' as \"password\", e.IFCFNAME as \"host\", e.CNDID as \"bidNo\", e.CNDID as \"cndNo\", e.CNDID as \"cndId\", e.IFCID as \"globalId\", e.IFCOBJECTTYPE as \"cndType\", 'BIM' as \"takeOffType\", e.IFCQTY2 as \"quantity2\", e.IFCQTY3 as \"quantity3\", NULL as \"quantityF\",e.IFCQTYNAME2 as \"quantity2Name\", e.IFCQTYNAME3 as \"quantity3Name\", '  ' as \"quantityFName\",e.IFCUOM2 as \"unit2\", e.IFCUOM3 as \"unit3\", '  ' as \"unitF\", '  ' as \"formulaF\", p.IFCPROPNAME as \"quantity1Name\", ':unitParam' as \"unit1\", (:quantityQuery) as \"quantity1\", 1 as \"defaultQuantity\" FROM IFCELEMENT AS e INNER JOIN IFCPROPERTY p ON e.ELEMID = p.ELEMID WHERE e.PRJID = :prjId AND (p.IFCNUMVAL is not null AND e.IFCMODEL = ':modelName' AND p.IFCPROPNAME = :propertyNameParam AND e.IFCOBJECTTYPE = ':objectTypeParam' AND p.IFCQTYTYPE = :quantityTypeParam)";
		  if (StringUtils.isNullOrBlank(str3))
		  {
			str7 = StringUtils.replaceAll(str7, "AND e.IFCOBJECTTYPE=':objectTypeParam'", "");
		  }
		  else
		  {
			str7 = StringUtils.replaceAll(str7, ":objectTypeParam", str3);
		  }
		  if (StringUtils.isNullOrBlank(str5))
		  {
			str7 = StringUtils.replaceAll(str7, "AND p.IFCQTYTYPE = :quantityTypeParam", "");
		  }
		  else
		  {
			str7 = StringUtils.replaceAll(str7, ":quantityTypeParam", "" + i);
		  }
		  str7 = StringUtils.replaceAll(str7, ":modelName", str2);
		  int j = 5;
		  if (!StringUtils.isNullOrBlank(str6))
		  {
			str7 = str7 + " AND (" + str6 + ")";
			j = 5 + StringUtils.numberOfOccurences(str6, '?');
		  }
		  int k = j;
		  string str8 = (k < paramArrayOfExpr.Length) ? ((ExprString)paramArrayOfExpr[k]).str : null;
		  if (!string.ReferenceEquals(str8, null))
		  {
			str7 = StringUtils.replaceAll(str7, ":quantityQuery", str8);
		  }
		  else
		  {
			str7 = StringUtils.replaceAll(str7, ":quantityQuery", str1);
			str7 = StringUtils.replaceAll(str7, ":unitFactorQuery", makeUnitFactorQuery(i, str5));
		  }
		  if (!str4.StartsWith("QUERY", StringComparison.Ordinal))
		  {
			str7 = StringUtils.replaceAll(str7, ":propertyNameParam", "'" + str4 + "'");
		  }
		  else
		  {
			str4 = StringUtils.replace(str4, "QUERY", "");
			str7 = StringUtils.replaceAll(str7, ":propertyNameParam", str4);
		  }
		  string str9 = (++k < paramArrayOfExpr.Length) ? ((ExprString)paramArrayOfExpr[k]).str : null;
		  string str10 = (++k < paramArrayOfExpr.Length) ? ((ExprString)paramArrayOfExpr[k]).str : null;
		  if (StringUtils.isNullOrBlank(str10))
		  {
			str7 = StringUtils.replaceAll(str7, ":unitParam", str5);
		  }
		  else
		  {
			str7 = StringUtils.replaceAll(str7, ":unitParam", str10);
		  }
		  str7 = StringUtils.replaceAll(str7, ":prjId", "" + projectDBUtil.ProjectUrlId);
		  Query query = projectDBUtil.currentSession().createSQLQuery(str7);
		  sbyte b1 = 5;
		  for (b1 = 5; b1 < j; b1++)
		  {
			sbyte b3 = b1;
			if (paramArrayOfExpr[b3] is ExprString)
			{
			  query = query.setString(b3 - 5, ((ExprString)paramArrayOfExpr[b3]).str);
			}
			else if (paramArrayOfExpr[b3] is ExprDouble)
			{
			  query = query.setDouble(b3 - 5, ((ExprDouble)paramArrayOfExpr[b3]).doubleValue());
			}
			else if (paramArrayOfExpr[b3] is ExprInteger)
			{
			  query = query.setInteger(b3 - 5, ((ExprInteger)paramArrayOfExpr[b3]).intValue());
			}
			else if (paramArrayOfExpr[b3] is ExprBoolean)
			{
			  query = query.setBoolean(b3 - 5, ((ExprBoolean)paramArrayOfExpr[b3]).booleanValue());
			}
			else if (paramArrayOfExpr[b3] is ExprArray)
			{
			  Expr[] arrayOfExpr = ((ExprArray)paramArrayOfExpr[b3]).InternalArray;
			  if (arrayOfExpr.Length == 0)
			  {
				return new ExprTakeoff(bigDecimal.doubleValue(), arrayOfConditionTable);
			  }
			  List<object> arrayList = new List<object>(arrayOfExpr.Length);
			  foreach (Expr expr in arrayOfExpr)
			  {
				if (expr is ExprNumber)
				{
				  arrayList.Add(Convert.ToDouble(((ExprNumber)expr).doubleValue()));
				}
				else if (expr is ExprString)
				{
				  arrayList.Add(((ExprString)paramArrayOfExpr[b3]).str);
				}
				else
				{
				  arrayList.Add(paramArrayOfExpr[b3].ToString());
				}
			  }
			  query = query.setParameter(b3 - 5, arrayList);
			}
			else
			{
			  query = query.setString(b3 - 5, paramArrayOfExpr[b3].ToString());
			}
		  }
		  System.Collections.IList list = query.list();
		  arrayOfConditionTable = new ConditionTable[list.Count];
		  sbyte b2 = 0;
		  foreach (object[] arrayOfObject in list)
		  {
			ConditionTable conditionTable = new ConditionTable();
			conditionTable.Title = castToString(arrayOfObject[0]);
			conditionTable.Description = castToString(arrayOfObject[1]);
			conditionTable.Building = castToString(arrayOfObject[2]);
			conditionTable.Storey = castToString(arrayOfObject[3]);
			conditionTable.Layer = castToString(arrayOfObject[4]);
			conditionTable.Location = castToString(arrayOfObject[5]);
			conditionTable.BimMaterial = castToString(arrayOfObject[6]);
			conditionTable.BimType = castToString(arrayOfObject[7]);
			conditionTable.DatabaseName = castToString(arrayOfObject[8]);
			conditionTable.Username = castToString(arrayOfObject[9]);
			conditionTable.Password = castToString(arrayOfObject[10]);
			conditionTable.Host = castToString(arrayOfObject[11]);
			conditionTable.BidNo = (int?)arrayOfObject[12];
			conditionTable.CndNo = (int?)arrayOfObject[13];
			conditionTable.CndId = (int?)arrayOfObject[14];
			conditionTable.GlobalId = castToString(arrayOfObject[15]);
			conditionTable.CndType = castToString(arrayOfObject[16]);
			conditionTable.TakeOffType = castToString(arrayOfObject[17]);
			conditionTable.Quantity2 = (decimal)arrayOfObject[18];
			conditionTable.Quantity3 = (decimal)arrayOfObject[19];
			conditionTable.QuantityF = (decimal)arrayOfObject[20];
			conditionTable.Quantity2Name = castToString(arrayOfObject[21]);
			conditionTable.Quantity3Name = castToString(arrayOfObject[22]);
			conditionTable.QuantityFName = castToString(arrayOfObject[23]);
			conditionTable.Unit2 = castToString(arrayOfObject[24]);
			conditionTable.Unit3 = castToString(arrayOfObject[25]);
			conditionTable.UnitF = castToString(arrayOfObject[26]);
			conditionTable.FormulaF = castToString(arrayOfObject[27]);
			conditionTable.Quantity1Name = castToString(arrayOfObject[28]);
			conditionTable.Unit1 = castToString(arrayOfObject[29]);
			conditionTable.Quantity1 = (decimal)arrayOfObject[30];
			conditionTable.PickType = ConditionTable.PICK_ELEMENTS;
			conditionTable.DefaultQuantity = Convert.ToInt32(1);
			bigDecimal = bigDecimal + conditionTable.Quantity1;
			if (!string.ReferenceEquals(str9, null))
			{
			  conditionTable.Quantity1Name = str9;
			}
			arrayOfConditionTable[b2++] = conditionTable;
		  }
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  if (!@bool)
		  {
			projectDBUtil.closeSession();
		  }
		  throw new ExprException(exception.Message);
		}
		if (!@bool)
		{
		  projectDBUtil.closeSession();
		}
		return new ExprTakeoff(bigDecimal.doubleValue(), arrayOfConditionTable);
	  }

	  private string castToString(object paramObject)
	  {
		if (paramObject is Clob)
		{
		  Clob clob = (Clob)paramObject;
		  try
		  {
			return clob.getSubString(1L, (int)clob.length());
		  }
		  catch (SQLException sQLException)
		  {
			Console.WriteLine(sQLException.ToString());
			Console.Write(sQLException.StackTrace);
		  }
		}
		return (paramObject == null) ? "" : paramObject.ToString();
	  }

	  private string makeUnitFactorQuery(int paramInt, string paramString)
	  {
		if (paramInt == 0)
		{
		  return "";
		}
		if (paramInt == BIMQuantityType.QTY_MILLI_METER)
		{
		  if (paramString.Equals("LM"))
		  {
			return "";
		  }
		  if (paramString.Equals("LCM"))
		  {
			return "*100";
		  }
		  if (paramString.Equals("FT") || paramString.Equals("LF"))
		  {
			return "*3.2808399";
		  }
		  if (paramString.Equals("IN") || paramString.Equals("LI"))
		  {
			return "*39.370078";
		  }
		}
		else if (paramInt == BIMQuantityType.QTY_SQUARE_METER)
		{
		  if (paramString.Equals("M2"))
		  {
			return "";
		  }
		  if (paramString.Equals("CM2"))
		  {
			return "*10000";
		  }
		  if (paramString.Equals("SF"))
		  {
			return "*0.09290304";
		  }
		  if (paramString.Equals("SY"))
		  {
			return "*1.195990046";
		  }
		  if (paramString.Equals("SI") || paramString.Equals("IN2"))
		  {
			return "*1550.0031";
		  }
		}
		else if (paramInt == BIMQuantityType.QTY_CUBIC_METER)
		{
		  if (paramString.Equals("M3"))
		  {
			return "";
		  }
		  if (paramString.Equals("CM3"))
		  {
			return "*1000000";
		  }
		  if (paramString.Equals("CF"))
		  {
			return "*35.3146667";
		  }
		  if (paramString.Equals("CY"))
		  {
			return "*1.307950619";
		  }
		  if (paramString.Equals("CI"))
		  {
			return "*61023.7441";
		  }
		}
		return "*0";
	  }

	  private int findQtyType(string paramString)
	  {
		  return (paramString.Equals("LCM") || paramString.Equals("LM") || paramString.Equals("FT") || paramString.Equals("LF") || paramString.Equals("LI") || paramString.Equals("IN")) ? BIMQuantityType.QTY_MILLI_METER : ((paramString.Equals("M2") || paramString.Equals("CM2") || paramString.Equals("SF") || paramString.Equals("SY") || paramString.Equals("SI") || paramString.Equals("IN2")) ? BIMQuantityType.QTY_SQUARE_METER : ((paramString.Equals("M3") || paramString.Equals("CM3") || paramString.Equals("CF") || paramString.Equals("CY") || paramString.Equals("CI")) ? BIMQuantityType.QTY_CUBIC_METER : ((paramString.Equals("EACH") || paramString.Equals("PCS")) ? 0 : -1)));
	  }

	  static BimQuantityTakeoff()
	  {
		s_ifcObjectTypes.Add("beam");
		s_ifcObjectTypes.Add("column");
		s_ifcObjectTypes.Add("wall");
		s_ifcObjectTypes.Add("door");
		s_ifcObjectTypes.Add("window");
		s_ifcObjectTypes.Add("footing");
		s_ifcObjectTypes.Add("slab");
		s_ifcObjectTypes.Add("roof");
		s_ifcObjectTypes.Add("railing");
		s_ifcObjectTypes.Add("staircase");
		s_ifcObjectTypes.Add("furniture");
		s_ifcObjectTypes.Add("object");
		s_ifcObjectTypes.Add("covering");
		s_ifcObjectTypes.Add("ceiling");
		s_ifcObjectTypes.Add("member");
		s_ifcObjectTypes.Add("ramp");
		s_ifcObjectTypes.Add("pile");
		s_ifcObjectTypes.Add("plate");
		s_ifcObjectTypes.Add("lightfixture");
		s_ifcObjectTypes.Add("grossareacompartment");
		s_ifcObjectTypes.Add("securecompartment");
		s_ifcObjectTypes.Add("elementpart");
		s_ifcObjectTypes.Add("space");
		s_ifcObjectTypes.Add("pipe");
		s_ifcObjectTypes.Add("fitting");
		s_ifcObjectTypes.Add("duct");
		s_ifcObjectTypes.Add("cable");
		s_ifcObjectTypes.Add("1");
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\takeoff\BimQuantityTakeoff.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}