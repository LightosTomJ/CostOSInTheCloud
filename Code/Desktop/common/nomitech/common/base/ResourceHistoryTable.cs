using System;

namespace Desktop.common.nomitech.common.@base
{

	public interface ResourceHistoryTable
	{
	  string BaseTableId {get;set;}


	  string Resource {get;set;}


	  DateTime PredictionDate {get;set;}


	  ResourceTable ResourceTable {get;set;}


	  object clone();
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\base\ResourceHistoryTable.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}