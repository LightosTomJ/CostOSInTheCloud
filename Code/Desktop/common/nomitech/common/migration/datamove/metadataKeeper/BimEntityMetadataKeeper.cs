using System;

namespace Desktop.common.nomitech.common.migration.datamove.metadataKeeper
{
	using BimSchemaHelper = nomitech.common.migration.datamove.schemaHelper.BimSchemaHelper;
	using PersistentClass = org.hibernate.mapping.PersistentClass;

	public class BimEntityMetadataKeeper : BaseEntityMetadataKeeper
	{
	  internal long? modelId;

	  public BimEntityMetadataKeeper(BimSchemaHelper paramBimSchemaHelper, long? paramLong, PersistentClass paramPersistentClass) : base(paramBimSchemaHelper, paramPersistentClass)
	  {
		this.modelId = paramLong;
		this.parentTableIgnoreUpdates.Add("BC_MODEL");
	  }

	  internal override string getFilterColumn(string paramString)
	  {
		  return paramString.Equals("BC_MODEL", StringComparison.OrdinalIgnoreCase) ? "ID" : "MODEL_ID";
	  }

	  internal override long? FilterValue
	  {
		  get
		  {
			  return this.modelId;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\datamove\metadataKeeper\BimEntityMetadataKeeper.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}