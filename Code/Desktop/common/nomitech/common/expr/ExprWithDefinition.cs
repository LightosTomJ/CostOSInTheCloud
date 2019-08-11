using System;

namespace Desktop.common.nomitech.common.expr
{
	using FunctionArgumentTable = nomitech.common.db.local.FunctionArgumentTable;
	using ParamItemInputTable = nomitech.common.db.local.ParamItemInputTable;
	using IExprFunction = org.boris.expr.IExprFunction;

	public class ExprWithDefinition : object, Transferable, IComparable<ExprWithDefinition>
	{
	  private static readonly DataFlavor[] s_supportedDataFlavors = new DataFlavor[] {DataFlavors.exprWithDefinitionDataFlavor};

	  private IExprFunction exprFunction;

	  private ParamItemInputTable paramInput;

	  private FunctionArgumentTable functionArgument;

	  private ExprDefinition definition;

	  public ExprWithDefinition(string paramString1, string paramString2)
	  {
		  this.definition = new ExprDefinition(paramString1, paramString2, "");
	  }

	  public ExprWithDefinition(IExprFunction paramIExprFunction, ExprDefinition paramExprDefinition)
	  {
		this.exprFunction = paramIExprFunction;
		this.definition = paramExprDefinition;
	  }

	  public ExprWithDefinition(ParamItemInputTable paramParamItemInputTable, ExprDefinition paramExprDefinition)
	  {
		this.paramInput = paramParamItemInputTable;
		this.definition = paramExprDefinition;
	  }

	  public ExprWithDefinition(FunctionArgumentTable paramFunctionArgumentTable, ExprDefinition paramExprDefinition)
	  {
		this.functionArgument = paramFunctionArgumentTable;
		this.definition = paramExprDefinition;
	  }

	  public ExprWithDefinition(ExprDefinition paramExprDefinition)
	  {
		  this.definition = paramExprDefinition;
	  }

	  public override string ToString()
	  {
		  return Definition.ToString();
	  }

	  public override bool Equals(object paramObject)
	  {
		  return paramObject.ToString().Equals(ToString());
	  }

	  public virtual ParamItemInputTable ParamItemInputTable
	  {
		  get
		  {
			  return this.paramInput;
		  }
		  set
		  {
			  this.paramInput = value;
		  }
	  }


	  public virtual IExprFunction Function
	  {
		  get
		  {
			  return this.exprFunction;
		  }
		  set
		  {
			  this.exprFunction = value;
		  }
	  }


	  public virtual ExprDefinition Definition
	  {
		  get
		  {
			  return this.definition;
		  }
		  set
		  {
			  this.definition = value;
		  }
	  }


	  public virtual FunctionArgumentTable FunctionArgument
	  {
		  get
		  {
			  return this.functionArgument;
		  }
		  set
		  {
			  this.functionArgument = value;
		  }
	  }


	  public virtual DataFlavor[] TransferDataFlavors
	  {
		  get
		  {
			  return s_supportedDataFlavors;
		  }
	  }

	  public virtual bool isDataFlavorSupported(DataFlavor paramDataFlavor)
	  {
		  return DataFlavors.exprWithDefinitionDataFlavor.Equals(paramDataFlavor);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public Object getTransferData(java.awt.datatransfer.DataFlavor paramDataFlavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
	  public virtual object getTransferData(DataFlavor paramDataFlavor)
	  {
		if (DataFlavors.exprWithDefinitionDataFlavor.Equals(paramDataFlavor))
		{
		  return this;
		}
		throw new UnsupportedFlavorException(paramDataFlavor);
	  }

	  public virtual int CompareTo(ExprWithDefinition paramExprWithDefinition)
	  {
		  return -paramExprWithDefinition.definition.Name.CompareTo(this.definition.Name);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\ExprWithDefinition.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}