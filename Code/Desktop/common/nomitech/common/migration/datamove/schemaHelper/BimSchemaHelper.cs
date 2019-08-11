using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.migration.datamove.schemaHelper
{
	using BaseEntityMetadataKeeper = nomitech.common.migration.datamove.metadataKeeper.BaseEntityMetadataKeeper;
	using BimEntityMetadataKeeper = nomitech.common.migration.datamove.metadataKeeper.BimEntityMetadataKeeper;
	using PersistentClass = org.hibernate.mapping.PersistentClass;

	public class BimSchemaHelper : BaseSchemaHelper<BimEntityMetadataKeeper>
	{
	  internal static readonly string[] ignoredTables = new string[] {"BC_GPUSERVER", "BC_PROJECT", "BC_SCENE"};

	  internal long? modelId;

	  public BimSchemaHelper(long? paramLong)
	  {
		this.modelId = paramLong;
		this.allClasses = AllClasses;
		init();
	  }

	  internal override BimEntityMetadataKeeper createMetadataKeeper(PersistentClass paramPersistentClass)
	  {
		  return new BimEntityMetadataKeeper(this, this.modelId, paramPersistentClass);
	  }

	  internal static IList<PersistentClass> AllClasses
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			CostOSBimEngineDBUtil.Instance.Configuration.ClassMappings.forEachRemaining(paramPersistentClass => paramList.add(paramPersistentClass));
			System.Predicate predicate = paramPersistentClass =>
			{
			string str = paramPersistentClass.Table.Name.ToUpper();
			foreach (string str1 in ignoredTables)
			{
			  if (str.Equals(str1))
			  {
				return false;
			  }
			}
			return str.StartsWith("BC_", StringComparison.Ordinal);
			};
			System.Collections.IComparer comparator = (paramPersistentClass1, paramPersistentClass2) => paramPersistentClass1.Table.Name.equalsIgnoreCase("BC_MODEL") ? (paramPersistentClass2.Table.Name.equalsIgnoreCase("BC_MODEL") ? 0 : -1) : (paramPersistentClass2.Table.Name.equalsIgnoreCase("BC_MODEL") ? 1 : paramPersistentClass1.Table.Name.compareTo(paramPersistentClass2.Table.Name));
			return (System.Collections.IList)arrayList.Where(predicate).OrderBy(comparator).ToList();
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\datamove\schemaHelper\BimSchemaHelper.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}