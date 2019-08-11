using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.expr.codes
{
	using GroupCode = Desktop.common.nomitech.common.@base.GroupCode;
	using StringUtils = Desktop.common.nomitech.common.util.StringUtils;
	using Expr = Desktop.common.org.boris.expr.Expr;
	using ExprBoolean = Desktop.common.org.boris.expr.ExprBoolean;
	using ExprException = Desktop.common.org.boris.expr.ExprException;
	using ExprNumber = Desktop.common.org.boris.expr.ExprNumber;
	using ExprString = Desktop.common.org.boris.expr.ExprString;
	using IEvaluationContext = Desktop.common.org.boris.expr.IEvaluationContext;
	using AbstractFunction = Desktop.common.org.boris.expr.function.AbstractFunction;

	public class ExtractCodeLevel : AbstractFunction
	{
	  private static GroupCodeUtilIntf s_groupCodeUtilIntf = null;

	  public static GroupCodeUtilIntf GroupCodeUtilIntf
	  {
		  set
		  {
			s_groupCodeUtilIntf = value;
			ExtractCodeLevelUnit.GroupCodeUtilIntf = value;
			ExtractCodeLevelFactor.GroupCodeUtilIntf = value;
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		if (s_groupCodeUtilIntf == null)
		{
		  throw new ExprException("FATAL: Group Code Utility Interface was not found!");
		}
		assertMinArgCount(paramArrayOfExpr, 2);
		assertMaxArgCount(paramArrayOfExpr, 4);
		string str1 = null;
		string str2 = null;
		int? integer = null;
		bool? @bool = Convert.ToBoolean(false);
		paramArrayOfExpr[0] = evalArg(paramIEvaluationContext, paramArrayOfExpr[0]);
		paramArrayOfExpr[1] = evalArg(paramIEvaluationContext, paramArrayOfExpr[1]);
		if (paramArrayOfExpr.Length > 2)
		{
		  paramArrayOfExpr[2] = evalArg(paramIEvaluationContext, paramArrayOfExpr[2]);
		}
		if (paramArrayOfExpr.Length > 3)
		{
		  paramArrayOfExpr[3] = evalArg(paramIEvaluationContext, paramArrayOfExpr[3]);
		}
		if (!(paramArrayOfExpr[0] is ExprString))
		{
		  throw new ExprException("Input " + paramArrayOfExpr[0].ToString() + " is not a String.");
		}
		str1 = ((ExprString)paramArrayOfExpr[0]).ToString().ToUpper();
		if (str1.Equals("WBS_CODE1"))
		{
		  str1 = "wbsCode";
		}
		else if (str1.Equals("WBS_CODE2"))
		{
		  str1 = "wbs2Code";
		}
		else if (str1.Equals("LOCATION"))
		{
		  str1 = "location";
		}
		else if (str1.Equals("GROUP_CODE1"))
		{
		  str1 = "groupCode";
		}
		else if (str1.Equals("GROUP_CODE2"))
		{
		  str1 = "gekCode";
		}
		else if (str1.Equals("GROUP_CODE3"))
		{
		  str1 = "extraCode1";
		}
		else if (str1.Equals("GROUP_CODE4"))
		{
		  str1 = "extraCode2";
		}
		else if (str1.Equals("GROUP_CODE5"))
		{
		  str1 = "extraCode3";
		}
		else if (str1.Equals("GROUP_CODE6"))
		{
		  str1 = "extraCode4";
		}
		else if (str1.Equals("GROUP_CODE7"))
		{
		  str1 = "extraCode5";
		}
		else if (str1.Equals("GROUP_CODE8"))
		{
		  str1 = "extraCode6";
		}
		else if (str1.Equals("GROUP_CODE9"))
		{
		  str1 = "extraCode7";
		}
		else
		{
		  throw new ExprException("Invalid group code name, please use the defined name eg. \"GROUP_CODE1\"");
		}
		if (!(paramArrayOfExpr[1] is ExprString))
		{
		  throw new ExprException("Input " + paramArrayOfExpr[1].ToString() + " is not a String.");
		}
		str2 = ((ExprString)paramArrayOfExpr[1]).ToString();
		if (StringUtils.isNullOrBlank(str2) || !s_groupCodeUtilIntf.checkCodeExists(str1, str2))
		{
		  return new ExprString("");
		}
		if (paramArrayOfExpr.Length > 2)
		{
		  if (!(paramArrayOfExpr[2] is ExprBoolean))
		  {
			throw new ExprException("Input " + paramArrayOfExpr[2].ToString() + " is not a Boolean.");
		  }
		  @bool = Convert.ToBoolean(((ExprBoolean)paramArrayOfExpr[2]).booleanValue());
		}
		if (paramArrayOfExpr.Length > 3)
		{
		  if (!(paramArrayOfExpr[3] is ExprNumber))
		  {
			throw new ExprException("Input " + paramArrayOfExpr[3].ToString() + " is not a Number.");
		  }
		  integer = Convert.ToInt32(((ExprNumber)paramArrayOfExpr[3]).intValue());
		}
		else
		{
		  GroupCode groupCode1 = s_groupCodeUtilIntf.extractCode(str1, str2);
		  return (groupCode1 == null) ? new ExprString("") : (@bool.Value ? new ExprString(groupCode1.Title) : new ExprString(s_groupCodeUtilIntf.formatCodeAndTitle(str1, groupCode1)));
		}
		GroupCode groupCode = s_groupCodeUtilIntf.extractCode(str1, str2);
		if (groupCode == null)
		{
		  return new ExprString("");
		}
		List<object> arrayList = new List<object>();
		string str3 = s_groupCodeUtilIntf.getCodeSystem(str1);
		while (!StringUtils.isNullOrBlank(str2))
		{
		  arrayList.Add(str2);
		  str2 = s_groupCodeUtilIntf.getParentOfCode(str3, str2);
		}
		int i = arrayList.Count - integer.Value;
		if (i < 0 || i >= arrayList.Count)
		{
		  return @bool.Value ? new ExprString(groupCode.Title) : new ExprString(s_groupCodeUtilIntf.formatCodeAndTitle(str1, groupCode));
		}
		str2 = (string)arrayList[i];
		groupCode = s_groupCodeUtilIntf.extractCode(str1, str2);
		return (groupCode == null) ? new ExprString(str2) : (@bool.Value ? new ExprString(groupCode.Title) : new ExprString(s_groupCodeUtilIntf.formatCodeAndTitle(str1, groupCode)));
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\codes\ExtractCodeLevel.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}