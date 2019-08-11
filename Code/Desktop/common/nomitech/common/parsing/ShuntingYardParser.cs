using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.parsing
{
	using StringUtils = nomitech.common.util.StringUtils;

	public class ShuntingYardParser
	{
	  public const sbyte INFIX_OPERATOR_SET = 0;

	  public const sbyte EXCEL_RULES = 0;

	  private IDictionary<string, BaseOperator> operators = null;

	  private static ShuntingYardParser instance = null;

	  public static ShuntingYardParser getInstance(sbyte paramByte1, sbyte paramByte2)
	  {
		instance = new ShuntingYardParser(paramByte1, paramByte2);
		return instance;
	  }

	  protected internal ShuntingYardParser(ICollection<BaseOperator> paramCollection)
	  {
		this.operators = new Hashtable();
		foreach (BaseOperator baseOperator in paramCollection)
		{
		  this.operators[baseOperator.Symbol] = baseOperator;
		}
	  }

	  protected internal ShuntingYardParser(sbyte paramByte1, sbyte paramByte2)
	  {
		List<object> arrayList = new List<object>();
		if (paramByte2 == 0)
		{
		  arrayList.Add(new BaseOperator("*", false, 10));
		  arrayList.Add(new BaseOperator("/", false, 10));
		  arrayList.Add(new BaseOperator("+", false, 9));
		  arrayList.Add(new BaseOperator("-", false, 9));
		  arrayList.Add(new BaseOperator(">", false, 8));
		  arrayList.Add(new BaseOperator("<", false, 8));
		  arrayList.Add(new BaseOperator("=", false, 7));
		  arrayList.Add(new BaseOperator("~", false, 7));
		  arrayList.Add(new BaseOperator("&", false, 6));
		  arrayList.Add(new BaseOperator("|", false, 5));
		  this.operators = new Hashtable();
		  foreach (BaseOperator baseOperator in arrayList)
		  {
			this.operators[baseOperator.Symbol] = baseOperator;
		  }
		}
	  }

	  private static void addNode(Stack<ParseTreeNode> paramStack, string paramString)
	  {
		ParseTreeNode parseTreeNode1 = (ParseTreeNode)paramStack.Pop();
		ParseTreeNode parseTreeNode2 = (ParseTreeNode)paramStack.Pop();
		paramStack.Push(new ParseTreeNode(paramString, parseTreeNode2, parseTreeNode1));
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public ParseTreeNode convertInfixNotationToAST(String paramString) throws Exception
	  public virtual ParseTreeNode convertInfixNotationToAST(string paramString)
	  {
		System.Collections.Stack stack1 = new System.Collections.Stack();
		System.Collections.Stack stack2 = new System.Collections.Stack();
		string[] arrayOfString = paramString.Split("", true);
		sbyte b1 = 0;
		string str = "";
		bool @bool = true;
		for (sbyte b2 = 0; b2 < arrayOfString.Length; b2++)
		{
		  bool bool1;
		  string str1;
		  if (arrayOfString[b2].Equals(" "))
		  {
			b1 = 1;
		  }
		  else if (arrayOfString[b2].Equals("("))
		  {
			b1 = 2;
		  }
		  else if (arrayOfString[b2].Equals(")"))
		  {
			b1 = 3;
		  }
		  else
		  {
			b1 = 4;
		  }
		  switch (b1)
		  {
			case 1:
			  break;
			case 2:
			  stack1.Push("(");
			  break;
			case 3:
			  while (true)
			  {
				if (stack1.Count > 0)
				{
				  string str2 = (string)stack1.Pop();
				  if ("(".Equals(str2))
				  {
					break;
				  }
				  addNode(stack2, str2);
				  continue;
				}
				throw new System.InvalidOperationException("Unbalanced right parentheses");
			  }
			  break;
			default:
			  if (this.operators.ContainsKey(arrayOfString[b2]))
			  {
				@bool = false;
				BaseOperator baseOperator1 = (BaseOperator)this.operators[arrayOfString[b2]];
				BaseOperator baseOperator2;
				while (stack1.Count > 0 && null != (baseOperator2 = (BaseOperator)this.operators[stack1.Peek()]) && ((!baseOperator1.RightAssociative && 0 == baseOperator1.comparePrecedence(baseOperator2)) || baseOperator1.comparePrecedence(baseOperator2) < 0))
				{
				  stack1.Pop();
				  addNode(stack2, baseOperator2.Symbol + "");
				}
				stack1.Push(arrayOfString[b2]);
				break;
			  }
			  str1 = arrayOfString[b2];
			  bool1 = b2 + true;
			  while (b2 + true < arrayOfString.Length && !arrayOfString[b2 + true].Equals(" ") && !arrayOfString[b2 + true].Equals("(") && !arrayOfString[b2 + true].Equals(")") && !this.operators.ContainsKey(arrayOfString[b2 + true]))
			  {
				str1 = str1 + arrayOfString[b2 + true];
				b2++;
			  }
			  stack2.Push(new ParseTreeNode(str1, null, null));
			  break;
		  }
		}
		while (stack1.Count > 0)
		{
		  addNode(stack2, (string)stack1.Pop());
		}
		return (ParseTreeNode)stack2.Pop();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.List<String> getOperantsListForIce(String paramString) throws Exception
	  public virtual IList<string> getOperantsListForIce(string paramString)
	  {
		List<object> arrayList = new List<object>();
		System.Collections.Stack stack1 = new System.Collections.Stack();
		System.Collections.Stack stack2 = new System.Collections.Stack();
		string[] arrayOfString = paramString.Split("", true);
		sbyte b1 = 0;
		string str = "";
		bool @bool = true;
		for (sbyte b2 = 0; b2 < arrayOfString.Length; b2++)
		{
		  string str3;
		  string str2;
		  bool bool1;
		  string str1;
		  if (arrayOfString[b2].Equals(" ") || StringUtils.isNullOrBlank(arrayOfString[b2]))
		  {
			b1 = 1;
		  }
		  else if (arrayOfString[b2].Equals("("))
		  {
			b1 = 2;
		  }
		  else if (arrayOfString[b2].Equals(")"))
		  {
			b1 = 3;
		  }
		  else
		  {
			b1 = 4;
		  }
		  switch (b1)
		  {
			case 1:
			  break;
			case 2:
			  stack1.Push("(");
			  break;
			case 3:
			  while (true)
			  {
				if (stack1.Count > 0)
				{
				  string str4 = (string)stack1.Pop();
				  if ("(".Equals(str4))
				  {
					break;
				  }
				  addNode(stack2, str4);
				  continue;
				}
				throw new System.InvalidOperationException("Unbalanced right parentheses");
			  }
			  break;
			default:
			  if (this.operators.ContainsKey(arrayOfString[b2]))
			  {
				@bool = false;
				BaseOperator baseOperator1 = (BaseOperator)this.operators[arrayOfString[b2]];
				BaseOperator baseOperator2;
				while (stack1.Count > 0 && null != (baseOperator2 = (BaseOperator)this.operators[stack1.Peek()]) && ((!baseOperator1.RightAssociative && 0 == baseOperator1.comparePrecedence(baseOperator2)) || baseOperator1.comparePrecedence(baseOperator2) < 0))
				{
				  stack1.Pop();
				  addNode(stack2, baseOperator2.Symbol + "");
				}
				stack1.Push(arrayOfString[b2]);
				break;
			  }
			  str1 = arrayOfString[b2];
			  bool1 = b2 + true;
			  while (b2 + true < arrayOfString.Length && !arrayOfString[b2 + true].Equals(" ") && !arrayOfString[b2 + true].Equals("(") && !arrayOfString[b2 + true].Equals(")") && !this.operators.ContainsKey(arrayOfString[b2 + true]))
			  {
				str1 = str1 + arrayOfString[b2 + true];
				b2++;
			  }
			  str2 = null;
			  if (str1.EndsWith("R", StringComparison.Ordinal) && str1.LastIndexOf("R", StringComparison.Ordinal) != 0)
			  {
				str2 = str1.Substring(0, str1.Length - 1);
				stack2.Push(new ParseTreeNode(str2, null, null));
			  }
			  else if (str1.EndsWith("L", StringComparison.Ordinal) && str1.LastIndexOf("L", StringComparison.Ordinal) != 0)
			  {
				str2 = str1.Substring(0, str1.Length - 1);
				stack2.Push(new ParseTreeNode(str2, null, null));
			  }
			  else if (str1.EndsWith("\"", StringComparison.Ordinal))
			  {
				if (str1.Substring(0, str1.Length - 1).EndsWith("R", StringComparison.Ordinal) && str1.LastIndexOf("R", StringComparison.Ordinal) != 0)
				{
				  str2 = str1.Substring(0, str1.Length - 2);
				  stack2.Push(new ParseTreeNode(str2, null, null));
				}
				else if (str1.Substring(0, str1.Length - 1).EndsWith("L", StringComparison.Ordinal) && str1.LastIndexOf("L", StringComparison.Ordinal) != 0)
				{
				  str2 = str1.Substring(0, str1.Length - 1);
				  stack2.Push(new ParseTreeNode(str2, null, null));
				}
			  }
			  str3 = str1;
			  str1 = createValidNameForInput(str1);
			  if (!string.ReferenceEquals(str2, null) && !isNumeric(str2) && !str2.StartsWith("@", StringComparison.Ordinal))
			  {
				arrayList.Add(str2);
				stack2.Push(new ParseTreeNode(str1, null, null));
				break;
			  }
			  if (!string.ReferenceEquals(str1, null) && !isNumeric(str1) && !str1.StartsWith("@", StringComparison.Ordinal))
			  {
				arrayList.Add(str1);
				stack2.Push(new ParseTreeNode(str1, null, null));
				break;
			  }
			  stack2.Push(new ParseTreeNode(str1, null, null));
			  break;
		  }
		}
		while (stack1.Count > 0)
		{
		  addNode(stack2, (string)stack1.Pop());
		}
		return arrayList;
	  }

	  public static bool isNumeric(string paramString)
	  {
		try
		{
		  double d = double.Parse(paramString);
		}
		catch (System.FormatException)
		{
		  return false;
		}
		return true;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public ParseTreeNode convertInfixNotationToASTForIcePlugin(String paramString) throws Exception
	  public virtual ParseTreeNode convertInfixNotationToASTForIcePlugin(string paramString)
	  {
		System.Collections.Stack stack1 = new System.Collections.Stack();
		System.Collections.Stack stack2 = new System.Collections.Stack();
		string[] arrayOfString = paramString.Split("", true);
		sbyte b1 = 0;
		string str = "";
		bool @bool = true;
		for (sbyte b2 = 0; b2 < arrayOfString.Length; b2++)
		{
		  string str2;
		  bool bool1;
		  string str1;
		  if (arrayOfString[b2].Equals(" ") || arrayOfString[b2].Equals(""))
		  {
			b1 = 1;
		  }
		  else if (arrayOfString[b2].Equals("("))
		  {
			b1 = 2;
		  }
		  else if (arrayOfString[b2].Equals(")"))
		  {
			b1 = 3;
		  }
		  else
		  {
			b1 = 4;
		  }
		  switch (b1)
		  {
			case 1:
			  break;
			case 2:
			  stack1.Push("(");
			  break;
			case 3:
			  while (true)
			  {
				if (stack1.Count > 0)
				{
				  string str3 = (string)stack1.Pop();
				  if ("(".Equals(str3))
				  {
					break;
				  }
				  addNode(stack2, str3);
				  continue;
				}
				throw new System.InvalidOperationException("Unbalanced right parentheses");
			  }
			  break;
			default:
			  if (this.operators.ContainsKey(arrayOfString[b2]))
			  {
				@bool = false;
				BaseOperator baseOperator1 = (BaseOperator)this.operators[arrayOfString[b2]];
				BaseOperator baseOperator2;
				while (stack1.Count > 0 && null != (baseOperator2 = (BaseOperator)this.operators[stack1.Peek()]) && ((!baseOperator1.RightAssociative && 0 == baseOperator1.comparePrecedence(baseOperator2)) || baseOperator1.comparePrecedence(baseOperator2) < 0))
				{
				  stack1.Pop();
				  addNode(stack2, baseOperator2.Symbol + "");
				}
				stack1.Push(arrayOfString[b2]);
				break;
			  }
			  str1 = arrayOfString[b2];
			  bool1 = b2 + true;
			  while (b2 + true < arrayOfString.Length && !arrayOfString[b2 + true].Equals(" ") && !arrayOfString[b2 + true].Equals("(") && !arrayOfString[b2 + true].Equals(")") && !this.operators.ContainsKey(arrayOfString[b2 + true]))
			  {
				str1 = str1 + arrayOfString[b2 + true];
				b2++;
			  }
			  str2 = str1;
			  str1 = createValidNameForInput(str1);
			  if (str1.EndsWith("R", StringComparison.Ordinal) && str1.IndexOf("R", StringComparison.Ordinal) != 0)
			  {
				string str3 = str1.Substring(0, str1.Length - 1);
				str1 = "( ROUND( (" + str3 + "- INT(" + str3 + ")) * (10^( LEN(ROUND(" + str3 + " - INT(" + str3 + "),2))-2)),4))";
			  }
			  else if (str1.EndsWith("L", StringComparison.Ordinal) && str1.IndexOf("L", StringComparison.Ordinal) != 0)
			  {
				str1 = "INT(" + str1.Substring(0, str1.Length - 1) + ")";
			  }
			  else if (str1.EndsWith("\"", StringComparison.Ordinal))
			  {
				if (str1.Substring(0, str1.Length - 1).EndsWith("R", StringComparison.Ordinal) && str1.IndexOf("R", StringComparison.Ordinal) != 0)
				{
				  string str3 = str1.Substring(0, str1.Length - 2);
				  str1 = "( ROUND( (" + str3 + "- INT(" + str3 + ")) * (10^( LEN(ROUND(" + str3 + " - INT(" + str3 + "),2))-2)),4))";
				}
				else if (str1.Substring(0, str1.Length - 1).EndsWith("L", StringComparison.Ordinal) && str1.IndexOf("L", StringComparison.Ordinal) != 0)
				{
				  str1 = "INT(" + str1.Substring(0, str1.Length - 1) + "\")";
				}
			  }
			  stack2.Push(new ParseTreeNode(str1, null, null));
			  break;
		  }
		}
		while (stack1.Count > 0)
		{
		  addNode(stack2, (string)stack1.Pop());
		}
		return (ParseTreeNode)stack2.Pop();
	  }

	  private string createValidNameForInput(string paramString)
	  {
		if (paramString.Contains(".") || paramString.Contains("_") || paramString.Contains("\\") || paramString.Contains("/") || paramString.Contains("\"") || paramString.Contains("'"))
		{
		  string str = paramString;
		  paramString = paramString.replaceAll("\\.", "");
		  paramString = paramString.replaceAll("\\\\", "");
		  paramString = paramString.replaceAll("_", "");
		  paramString = paramString.replaceAll("/", "");
		  paramString = paramString.replaceAll("\"", "");
		  paramString = paramString.replaceAll("'", "");
		}
		return paramString;
	  }

	  public virtual string convertASToOtherNotation(ParseTreeNode paramParseTreeNode, string paramString, sbyte paramByte)
	  {
		  return (paramByte == 0) ? excelRules(paramParseTreeNode, paramString) : "";
	  }

	  public virtual string convertASTToExcelFormula(ParseTreeNode paramParseTreeNode, string paramString)
	  {
		  return excelRules(paramParseTreeNode, paramString);
	  }

	  private string excelRules(ParseTreeNode paramParseTreeNode, string paramString)
	  {
		  return (paramParseTreeNode == null) ? paramString : (paramParseTreeNode.Value.Equals("&") ? ("AND(" + excelRules(paramParseTreeNode.Left, paramString) + "," + excelRules(paramParseTreeNode.Right, paramString) + ")") : (paramParseTreeNode.Value.Equals("|") ? ("OR(" + excelRules(paramParseTreeNode.Left, paramString) + "," + excelRules(paramParseTreeNode.Right, paramString) + ")") : ((paramParseTreeNode.Value.Equals("-") || paramParseTreeNode.Value.Equals("+") || paramParseTreeNode.Value.Equals("/") || paramParseTreeNode.Value.Equals(">") || paramParseTreeNode.Value.Equals("<") || paramParseTreeNode.Value.Equals("*")) ? ("(" + excelRules(paramParseTreeNode.Left, paramString) + "" + paramParseTreeNode.Value + "" + excelRules(paramParseTreeNode.Right, paramString) + ")") : (paramParseTreeNode.Value.Equals("^") ? ("(" + excelRules(paramParseTreeNode.Left, paramString) + "" + paramParseTreeNode.Value + "" + excelRules(paramParseTreeNode.Right, paramString) + ")") : (paramParseTreeNode.Value.Equals("~") ? ("NOT(" + excelRules(paramParseTreeNode.Left, paramString) + "=" + excelRules(paramParseTreeNode.Right, paramString) + ")") : (paramParseTreeNode.Value.Equals("=") ? ("" + excelRules(paramParseTreeNode.Left, paramString) + "" + paramParseTreeNode.Value + "" + excelRules(paramParseTreeNode.Right, paramString) + "") : (paramString + "" + paramParseTreeNode.Value)))))));
	  }

	  public virtual string infixToExcelIce(string paramString)
	  {
		string str = "";
		ShuntingYardParser shuntingYardParser = getInstance((sbyte)0, (sbyte)0);
		ParseTreeNode parseTreeNode = shuntingYardParser.convertInfixNotationToASTForIcePlugin(paramString);
		return shuntingYardParser.convertASTToExcelFormula(parseTreeNode, str);
	  }

	  public virtual string infixToExcel(string paramString)
	  {
		string str = "";
		ShuntingYardParser shuntingYardParser = getInstance((sbyte)0, (sbyte)0);
		ParseTreeNode parseTreeNode = shuntingYardParser.convertInfixNotationToAST(paramString);
		return shuntingYardParser.convertASTToExcelFormula(parseTreeNode, str);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\parsing\ShuntingYardParser.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}