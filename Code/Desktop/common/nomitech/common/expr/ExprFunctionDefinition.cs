using System;
using System.Collections.Generic;
using System.Text;

namespace Desktop.common.nomitech.common.expr
{
	using FunctionArgumentTable = nomitech.common.db.local.FunctionArgumentTable;
	using FunctionTable = nomitech.common.db.local.FunctionTable;
	using IExprFunction = org.boris.expr.IExprFunction;
	using ParameterizedCompletion = org.fife.ui.autocomplete.ParameterizedCompletion;
	using Parameter = org.fife.ui.autocomplete.ParameterizedCompletion.Parameter;

	[Serializable]
	public class ExprFunctionDefinition : ExprDefinition
	{
	  private ParameterizedCompletion.Parameter[] @params;

	  private string grouping;

	  private bool takeoff = false;

	  public ExprFunctionDefinition(FunctionTable paramFunctionTable) : base(paramFunctionTable.Name, paramFunctionTable.ResultType, paramFunctionTable.Description)
	  {
		this.takeoff = paramFunctionTable.Takeoff.Value;
		List<object> arrayList = new List<object>();
		this.grouping = paramFunctionTable.Grouping;
		foreach (FunctionArgumentTable functionArgumentTable in paramFunctionTable.FunctionArgumentList)
		{
		  string str1 = functionArgumentTable.Type;
		  if (str1.Equals("datatype.calcvalue") || str1.Equals("datatype.image") || str1.Equals("datatype.notes"))
		  {
			continue;
		  }
		  ParameterizedCompletion.Parameter parameter = null;
		  if (str1.Equals("datatype.decimal") || str1.Equals("datatype.integer") || str1.Equals("datatype.takeoff"))
		  {
			parameter = new ParameterizedCompletion.Parameter("number", functionArgumentTable.Name);
		  }
		  else if (str1.Equals("datatype.date"))
		  {
			parameter = new ParameterizedCompletion.Parameter("date", functionArgumentTable.Name);
		  }
		  else if (str1.Equals("datatype.array"))
		  {
			parameter = new ParameterizedCompletion.Parameter("array", functionArgumentTable.Name);
		  }
		  else if (str1.Equals("datatype.boolean"))
		  {
			parameter = new ParameterizedCompletion.Parameter("boolean", functionArgumentTable.Name);
		  }
		  else if (str1.Equals("datatype.locfactor"))
		  {
			parameter = new ParameterizedCompletion.Parameter("locfactor", functionArgumentTable.Name);
		  }
		  else if (str1.Equals("datatype.list") || str1.Equals("datatype.text"))
		  {
			parameter = new ParameterizedCompletion.Parameter("text", functionArgumentTable.Name);
		  }
		  else
		  {
			parameter = new ParameterizedCompletion.Parameter("text", functionArgumentTable.Name);
		  }
		  arrayList.Add(parameter);
		}
		this.@params = (ParameterizedCompletion.Parameter[])arrayList.ToArray(typeof(ParameterizedCompletion.Parameter));
		string str = paramFunctionTable.ResultType;
		if (string.ReferenceEquals(str, null))
		{
		  str = "datatype.decimal";
		}
		if (str.Equals("datatype.decimal") || str.Equals("datatype.integer") || str.Equals("datatype.takeoff"))
		{
		  str = "number";
		}
		else if (str.Equals("datatype.date"))
		{
		  str = "date";
		}
		else if (str.Equals("datatype.calcvalue"))
		{
		  str = "const_number";
		}
		else if (str.Equals("datatype.array"))
		{
		  str = "array";
		}
		else if (str.Equals("datatype.image"))
		{
		  str = "const_text";
		}
		else if (str.Equals("datatype.notes"))
		{
		  str = "const_text";
		}
		else if (str.Equals("datatype.boolean"))
		{
		  str = "boolean";
		}
		else if (str.Equals("datatype.list") || str.Equals("datatype.text"))
		{
		  str = "text";
		}
		else if (str.Equals("datatype.locfactor"))
		{
		  str = "locfactor";
		}
		else
		{
		  str = "text";
		}
		ReturnType = str;
	  }

	  public ExprFunctionDefinition(string paramString1, ParameterizedCompletion.Parameter[] paramArrayOfParameter, string paramString2, string paramString3) : base(paramString1, paramString2, paramString3)
	  {
		this.@params = paramArrayOfParameter;
		this.grouping = null;
	  }

	  public ExprFunctionDefinition(string paramString1, string paramString2, ParameterizedCompletion.Parameter[] paramArrayOfParameter, string paramString3, string paramString4) : base(paramString1, paramString3, paramString4)
	  {
		this.@params = paramArrayOfParameter;
		this.grouping = paramString2;
	  }

	  public virtual ParameterizedCompletion.Parameter[] Params
	  {
		  get
		  {
			  return this.@params;
		  }
		  set
		  {
			  this.@params = value;
		  }
	  }


	  public virtual bool Takeoff
	  {
		  get
		  {
			  return this.takeoff;
		  }
		  set
		  {
			  this.takeoff = value;
		  }
	  }


	  public virtual string Grouping
	  {
		  get
		  {
			  return this.grouping;
		  }
	  }

	  public override string Definition
	  {
		  get
		  {
			  return Usage + " : " + ReturnType;
		  }
	  }

	  public override string Usage
	  {
		  get
		  {
			StringBuilder stringBuffer = new StringBuilder();
			stringBuffer.Append(this.name);
			stringBuffer.Append("(");
			for (sbyte b = 0; b < this.@params.Length; b++)
			{
			  stringBuffer.Append(this.@params[b].Name);
			  if (b + true != this.@params.Length)
			  {
				stringBuffer.Append(",");
			  }
			}
			stringBuffer.Append(")");
			return stringBuffer.ToString();
		  }
	  }

	  public virtual string getJSInvocation(IExprFunction paramIExprFunction)
	  {
		StringBuilder stringBuffer = new StringBuilder();
		stringBuffer.Append(this.name);
		stringBuffer.Append("(");
		for (sbyte b = 0; b < this.@params.Length; b++)
		{
		  stringBuffer.Append(this.@params[b].Name);
		  if (b + true != this.@params.Length)
		  {
			stringBuffer.Append(",");
		  }
		}
		stringBuffer.Append(") {\n");
		stringBuffer.Append("\n}");
		return stringBuffer.ToString();
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\ExprFunctionDefinition.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}