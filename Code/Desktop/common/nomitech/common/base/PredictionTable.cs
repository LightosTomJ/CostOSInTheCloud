using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.@base
{

	public interface PredictionTable : BaseTable
	{
	  bool? Predicted {get;set;}


	  int? TrendChartType {get;set;}


	  decimal TrendValue {get;set;}


	  string TrendUnit {get;set;}


	  int? TrendColorCode {get;set;}


	  int? TrendRegType {get;set;}


	  string TrendIds {get;set;}


	  DateTime TrendDate {get;set;}


	  ISet<ResourceHistoryTable> ResourceHistorySet {get;set;}

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\base\PredictionTable.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}