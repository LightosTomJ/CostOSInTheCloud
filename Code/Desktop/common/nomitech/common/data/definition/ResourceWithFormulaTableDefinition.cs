namespace Desktop.common.nomitech.common.data.definition
{
	using FieldCustomizationTable = nomitech.common.db.local.FieldCustomizationTable;
	using BoqItemTable = nomitech.common.db.project.BoqItemTable;
	using ExprWithDefinition = nomitech.common.expr.ExprWithDefinition;
	using FieldLookupUtil = nomitech.common.fields.FieldLookupUtil;

	public abstract class ResourceWithFormulaTableDefinition : ResourceTableDefinition
	{
	  private const string formulaSuffix = "Formula";

	  public virtual bool fieldSupportsFormula(string paramString)
	  {
		paramString = paramString + "Formula";
		foreach (string str in FormulaFields)
		{
		  if (str.Equals(paramString))
		  {
			return true;
		  }
		}
		return false;
	  }

	  public virtual string fieldToFormulaField(string paramString)
	  {
		  return fieldSupportsFormula(paramString) ? (paramString + "Formula") : null;
	  }

	  public abstract string[] FormulaFields {get;}

	  public abstract string[] getAvailableVariables(string paramString);

	  public abstract ExprWithDefinition[] getAvailableVariableDefinitions(string paramString);

	  public virtual bool isFieldFormulaEditable(string paramString)
	  {
		if (!fieldSupportsFormula(paramString))
		{
		  return false;
		}
		FieldCustomizationTable fieldCustomizationTable = FieldLookupUtil.Instance.customizationForField(paramString, "boqitem");
		bool? @bool = fieldCustomizationTable.Editable;
		return (@bool == null) ? BoqItemTable.isFieldEditable(paramString) : @bool.Value;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\data\definition\ResourceWithFormulaTableDefinition.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}