using System;

namespace Desktop.common.nomitech.common.@base
{

	public interface BaseTable : BaseEntity
	{
	  string Title {get;set;}


	  object Clone();

	  string ToString();

	  DateTime LastUpdate {get;}

	  decimal TableRate {get;}
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\base\BaseTable.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}