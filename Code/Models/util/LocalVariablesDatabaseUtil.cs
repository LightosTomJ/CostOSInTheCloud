using System;
using System.Collections.Generic;
using System.Text;

namespace Models.util
{

	using Expr = org.boris.expr.Expr;
	using ExprDouble = org.boris.expr.ExprDouble;
	using ExprException = org.boris.expr.ExprException;

	using LocalVariablesEvaluationContext = nomitech.common.expr.localVars.LocalVariablesEvaluationContext;
	using StringUtils = nomitech.common.util.StringUtils;

	public class LocalVariablesDatabaseUtil
	{
		public static Dictionary<string, decimal> getLocalVariables(string varString)
		{
			Dictionary<string, decimal> localVars = new Dictionary<string, decimal>();

			if (StringUtils.isNotNullNotEmptyNotWhiteSpace(varString))
			{

				string[] rows = varString.Split(";", true);
				foreach (string row in rows)
				{
					string[] columns = row.Split(":", true);
					try
					{
						localVars[columns[0].ToUpper()] = new decimal(columns[2]);
					}
					catch (Exception)
					{
						continue;
					}
				}
			}
			return localVars;
		}

		public static object[] recalculate(string varString)
		{
			StringBuilder calculatedResult = new StringBuilder();
			ISet<string> varNames = new HashSet<string>();
			bool isThereChange = false;
			string varStringResult = "";
			if (StringUtils.isNotNullNotEmptyNotWhiteSpace(varString))
			{
				Dictionary<string, decimal> variableMap = getLocalVariables(varString);
				string[] rows = varString.Split(";", true);
				foreach (string row in rows)
				{
					string[] columns = row.Split(":", true);
					string name = columns[0];

					if (!StringUtils.isNotNullNotEmptyNotWhiteSpace(name))
					{
						continue;
					}
					string formula = columns[1];
					string result = columns[2];
					string descrpition = "";
					if (columns.Length > 3)
					{
						descrpition = columns[3];
					}
					if (StringUtils.isNotNullNotEmptyNotWhiteSpace(formula))
					{

						LocalVariablesEvaluationContext context = new LocalVariablesEvaluationContext(variableMap);
						Expr expr;
						try
						{
							expr = context.parseStatement(formula);
							if (expr is ExprDouble)
							{
								decimal rs = decimal.valueOf(((ExprDouble) expr).doubleValue());
								result = rs.ToString();
								varNames.addAll(context.VarNames);
							}
						}
						catch (ExprException e)
						{
							// TODO Auto-generated catch block
							Console.WriteLine(e.ToString());
							Console.Write(e.StackTrace);
						}
					}
					if (calculatedResult.ToString().Length > 0)
					{
						calculatedResult.Append(";");
					}
					calculatedResult.Append(name + ":" + formula + ":" + result + ":" + descrpition);
				}
				varStringResult = calculatedResult.ToString();
				if (!varString.Equals(calculatedResult.ToString()))
				{
					object[] obj = recalculate(varStringResult);
					varStringResult = (string) obj[0];
					varNames = (ISet<string>) obj[1];
				}
			}

			return new object[] {varStringResult, varNames};
		}

		public static bool variablesContainsPrjvar(string varString)
		{
			if (!StringUtils.isNotNullNotEmptyNotWhiteSpace(varString))
			{
				return false;
			}
			bool result = false;
			string[] rows = varString.Split(";", true);
			foreach (string row in rows)
			{
				string[] columns = row.Split(":", true);
				try
				{
					string formula = columns[1].ToUpper();
					if (formula.Contains("VAR(\"") || formula.Contains("PRJVARIABLE(\""))
					{
						return true;
					}

				}
				catch (Exception)
				{
					continue;
				}
			}
			return result;
		}

	}

}