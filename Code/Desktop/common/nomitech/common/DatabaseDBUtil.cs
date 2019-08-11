using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common
{
	using BaseDBProperties = Desktop.common.nomitech.common.@base.BaseDBProperties;
	using BaseDBUtil = Desktop.common.nomitech.common.@base.BaseDBUtil;
	using BaseTable = Desktop.common.nomitech.common.@base.BaseTable;
	using GroupCodesProvider = Desktop.common.nomitech.common.@base.GroupCodesProvider;
	using LayoutPanelTable = Desktop.common.nomitech.common.db.layout.LayoutPanelTable;
	using LayoutTable = Desktop.common.nomitech.common.db.layout.LayoutTable;
	using AssemblyTable = Desktop.common.nomitech.common.db.local.AssemblyTable;
	using FileDefinitionTable = Desktop.common.nomitech.common.db.local.FileDefinitionTable;
	using FilterPropertyTable = Desktop.common.nomitech.common.db.local.FilterPropertyTable;
	using FilterTable = Desktop.common.nomitech.common.db.local.FilterTable;
	using FunctionArgumentTable = Desktop.common.nomitech.common.db.local.FunctionArgumentTable;
	using FunctionTable = Desktop.common.nomitech.common.db.local.FunctionTable;
	using LocalizationFactorTable = Desktop.common.nomitech.common.db.local.LocalizationFactorTable;
	using LocalizationProfileTable = Desktop.common.nomitech.common.db.local.LocalizationProfileTable;
	using MaterialTable = Desktop.common.nomitech.common.db.local.MaterialTable;
	using ParamItemConceptualResourceTable = Desktop.common.nomitech.common.db.local.ParamItemConceptualResourceTable;
	using ParamItemInputTable = Desktop.common.nomitech.common.db.local.ParamItemInputTable;
	using ParamItemOutputTable = Desktop.common.nomitech.common.db.local.ParamItemOutputTable;
	using ParamItemQueryResourceTable = Desktop.common.nomitech.common.db.local.ParamItemQueryResourceTable;
	using ParamItemTable = Desktop.common.nomitech.common.db.local.ParamItemTable;
	using ProjectEPSTable = Desktop.common.nomitech.common.db.local.ProjectEPSTable;
	using ProjectInfoTable = Desktop.common.nomitech.common.db.local.ProjectInfoTable;
	using ProjectUrlTable = Desktop.common.nomitech.common.db.local.ProjectUrlTable;
	using ProjectUserTable = Desktop.common.nomitech.common.db.local.ProjectUserTable;
	using ProjectWBS2Table = Desktop.common.nomitech.common.db.local.ProjectWBS2Table;
	using ProjectWBSTable = Desktop.common.nomitech.common.db.local.ProjectWBSTable;
	using ReportDefinitionTable = Desktop.common.nomitech.common.db.local.ReportDefinitionTable;
	using SupplierTable = Desktop.common.nomitech.common.db.local.SupplierTable;
	using TakeoffAreaTable = Desktop.common.nomitech.common.db.local.TakeoffAreaTable;
	using TakeoffConditionTable = Desktop.common.nomitech.common.db.local.TakeoffConditionTable;
	using TakeoffLegendTable = Desktop.common.nomitech.common.db.local.TakeoffLegendTable;
	using TakeoffLineTable = Desktop.common.nomitech.common.db.local.TakeoffLineTable;
	using TakeoffPointTable = Desktop.common.nomitech.common.db.local.TakeoffPointTable;
	using TakeoffTriangleTable = Desktop.common.nomitech.common.db.local.TakeoffTriangleTable;
	using ProjectExcelFile = Desktop.common.nomitech.common.db.project.ProjectExcelFile;
	using ProjectTemplateTable = Desktop.common.nomitech.common.db.project.ProjectTemplateTable;
	using ProjectVariableTable = Desktop.common.nomitech.common.db.project.ProjectVariableTable;
	using RateBuildUpColumnsTable = Desktop.common.nomitech.common.db.project.RateBuildUpColumnsTable;
	using RateBuildUpTable = Desktop.common.nomitech.common.db.project.RateBuildUpTable;
	using RateDistributorTable = Desktop.common.nomitech.common.db.project.RateDistributorTable;
	using HqlParameterWithValue = Desktop.common.nomitech.common.db.util.HqlParameterWithValue;
	using HqlResultValue = Desktop.common.nomitech.common.db.util.HqlResultValue;
	using ProgressCallback = Desktop.common.nomitech.common.util.ProgressCallback;
	using Analyzer = org.apache.lucene.analysis.Analyzer;
	using HibernateException = org.hibernate.HibernateException;
	using Session = org.hibernate.Session;

	public class DatabaseDBUtil
	{
	  public const string WEB_SERVICE_METHOD = "ws";

	  public const string EJB3_RMI_METHOD = "rmi";

	  private static BaseDBUtil s_baseDBUtil = null;

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void setCurrentDBUtil(Desktop.common.nomitech.common.base.BaseDBUtil paramBaseDBUtil) throws Exception
	  public static BaseDBUtil CurrentDBUtil
	  {
		  set
		  {
			  s_baseDBUtil = value;
		  }
		  get
		  {
			  return s_baseDBUtil;
		  }
	  }


//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static boolean checkDBUtilLoaded(Desktop.common.nomitech.common.base.BaseDBUtil paramBaseDBUtil) throws Exception
	  public static bool checkDBUtilLoaded(BaseDBUtil paramBaseDBUtil)
	  {
		  return (s_baseDBUtil == null) ? false : s_baseDBUtil.Equals(paramBaseDBUtil);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void testAuthorizedUser(String paramString1, String paramString2, String paramString3, String paramString4) throws Exception
	  public static void testAuthorizedUser(string paramString1, string paramString2, string paramString3, string paramString4)
	  {
		  s_baseDBUtil.testAuthorizedUser(paramString1, paramString2, paramString3, paramString4);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static boolean testAuthorizedUser(String paramString1, String paramString2) throws Exception
	  public static bool testAuthorizedUser(string paramString1, string paramString2)
	  {
		  return s_baseDBUtil.testAuthorizedUser(paramString1, paramString2);
	  }

	  public static void notifyDataChanged(BaseTable paramBaseTable)
	  {
		  s_baseDBUtil.notifyDataChanged(paramBaseTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void changePassword(String paramString1, String paramString2, String paramString3) throws Exception
	  public static void changePassword(string paramString1, string paramString2, string paramString3)
	  {
		  s_baseDBUtil.changePassword(paramString1, paramString2, paramString3);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void loadDB(Desktop.common.nomitech.common.base.GroupCodesProvider paramGroupCodesProvider, String paramString1, String paramString2, boolean paramBoolean) throws Exception
	  public static void loadDB(GroupCodesProvider paramGroupCodesProvider, string paramString1, string paramString2, bool paramBoolean)
	  {
		  s_baseDBUtil.loadDB(paramGroupCodesProvider, paramString1, paramString2, paramBoolean);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static boolean initDB(String paramString1, String paramString2) throws Exception
	  public static bool initDB(string paramString1, string paramString2)
	  {
		  return s_baseDBUtil.initDB(paramString1, paramString2);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void importDB(java.io.File paramFile, String paramString1, String paramString2, Desktop.common.nomitech.common.util.ProgressCallback paramProgressCallback) throws Exception
	  public static void importDB(File paramFile, string paramString1, string paramString2, ProgressCallback paramProgressCallback)
	  {
		  s_baseDBUtil.importDB(paramFile, paramString1, paramString2, paramProgressCallback);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void exportDB(java.io.File paramFile, String paramString1, String paramString2, Desktop.common.nomitech.common.util.ProgressCallback paramProgressCallback) throws Exception
	  public static void exportDB(File paramFile, string paramString1, string paramString2, ProgressCallback paramProgressCallback)
	  {
		  s_baseDBUtil.exportDB(paramFile, paramString1, paramString2, paramProgressCallback);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void exportDB(java.io.File paramFile, Desktop.common.nomitech.common.util.ProgressCallback paramProgressCallback) throws Exception
	  public static void exportDB(File paramFile, ProgressCallback paramProgressCallback)
	  {
		  s_baseDBUtil.exportDB(paramFile, paramProgressCallback);
	  }

	  public static void unloadDB(bool paramBoolean)
	  {
		  s_baseDBUtil.unloadDB(paramBoolean);
	  }

	  public static bool hasOpenedSession()
	  {
		  return s_baseDBUtil.hasOpenedSession();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static org.hibernate.Session currentSession() throws org.hibernate.HibernateException
	  public static Session currentSession()
	  {
		  return s_baseDBUtil.currentSession();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.util.List loadBulk(Class paramClass, System.Nullable<long>[] paramArrayOfLong) throws Exception
	  public static System.Collections.IList loadBulk(Type paramClass, long?[] paramArrayOfLong)
	  {
		  return s_baseDBUtil.loadBulk(paramClass, paramArrayOfLong);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static int executeUpdate(String paramString1, String paramString2, java.util.List<long> paramList) throws Exception
	  public static int executeUpdate(string paramString1, string paramString2, IList<long> paramList)
	  {
		  return s_baseDBUtil.executeUpdate(paramString1, paramString2, paramList);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.util.List<long> executeLongQuery(String paramString1, String paramString2, java.util.List<long> paramList) throws Exception
	  public static IList<long> executeLongQuery(string paramString1, string paramString2, IList<long> paramList)
	  {
		  return s_baseDBUtil.executeLongQuery(paramString1, paramString2, paramList);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.util.List<Desktop.common.nomitech.common.db.util.HqlResultValue[]> executeHqlQuery(String paramString, java.util.List<Desktop.common.nomitech.common.db.util.HqlParameterWithValue> paramList) throws Exception
	  public static IList<HqlResultValue[]> executeHqlQuery(string paramString, IList<HqlParameterWithValue> paramList)
	  {
		  return s_baseDBUtil.executeHqlQuery(paramString, paramList);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void bulkSaveOrUpdate(Class paramClass, java.util.List paramList) throws Exception
	  public static void bulkSaveOrUpdate(Type paramClass, System.Collections.IList paramList)
	  {
		  s_baseDBUtil.bulkSaveOrUpdate(paramClass, paramList);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.util.List loadAllDeepCopy(Class paramClass) throws Exception
	  public static System.Collections.IList loadAllDeepCopy(Type paramClass)
	  {
		  return s_baseDBUtil.loadAllDeepCopy(paramClass);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.util.List fullTextSearchSession(String paramString1, String[] paramArrayOfString, Class[] paramArrayOfClass, org.apache.lucene.analysis.Analyzer paramAnalyzer, int paramInt, String paramString2, boolean paramBoolean) throws Exception
	  public static System.Collections.IList fullTextSearchSession(string paramString1, string[] paramArrayOfString, Type[] paramArrayOfClass, Analyzer paramAnalyzer, int paramInt, string paramString2, bool paramBoolean)
	  {
		  return s_baseDBUtil.fullTextSearchSession(paramString1, paramArrayOfString, paramArrayOfClass, paramAnalyzer, paramInt, paramString2, paramBoolean);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.util.List fullTextSearchSession(String paramString1, Class paramClass, int paramInt, String paramString2, boolean paramBoolean) throws Exception
	  public static System.Collections.IList fullTextSearchSession(string paramString1, Type paramClass, int paramInt, string paramString2, bool paramBoolean)
	  {
		  return s_baseDBUtil.fullTextSearchSession(paramString1, paramClass, paramInt, paramString2, paramBoolean);
	  }

	  public static void closeSession()
	  {
		  s_baseDBUtil.closeSession();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void connectDB(Desktop.common.nomitech.common.base.GroupCodesProvider paramGroupCodesProvider, String paramString1, String paramString2, String paramString3, String paramString4) throws Exception
	  public static void connectDB(GroupCodesProvider paramGroupCodesProvider, string paramString1, string paramString2, string paramString3, string paramString4)
	  {
		  s_baseDBUtil.connectDB(paramGroupCodesProvider, paramString1, paramString2, paramString3, paramString4);
	  }

	  public static BaseDBProperties Properties
	  {
		  get
		  {
			  return s_baseDBUtil.Properties;
		  }
	  }

	  public static BaseDBProperties reloadProperties()
	  {
		  return s_baseDBUtil.reloadProperties();
	  }

	  public static BaseDBProperties reloadProperties(string paramString)
	  {
		  return s_baseDBUtil.reloadProperties(paramString);
	  }

	  public static string InstallDirectory
	  {
		  set
		  {
			  s_baseDBUtil.InstallDirectory = value;
		  }
	  }

	  public static bool LocalCommunication
	  {
		  get
		  {
			  return s_baseDBUtil.LocalCommunication;
		  }
	  }

	  public static bool Enterprise
	  {
		  get
		  {
			  return s_baseDBUtil.Enterprise;
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.io.Serializable associateAssemblyResource(Desktop.common.nomitech.common.db.local.AssemblyTable paramAssemblyTable, Desktop.common.nomitech.common.base.BaseTable paramBaseTable, java.io.Serializable paramSerializable) throws Exception
	  public static Serializable associateAssemblyResource(AssemblyTable paramAssemblyTable, BaseTable paramBaseTable, Serializable paramSerializable)
	  {
		  return s_baseDBUtil.associateAssemblyResource(paramAssemblyTable, paramBaseTable, paramSerializable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deassociateAssemblyResource(java.io.Serializable paramSerializable) throws Exception
	  public static void deassociateAssemblyResource(Serializable paramSerializable)
	  {
		  s_baseDBUtil.deassociateAssemblyResource(paramSerializable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateFilterWithProperty(Desktop.common.nomitech.common.db.local.FilterTable paramFilterTable, Desktop.common.nomitech.common.db.local.FilterPropertyTable paramFilterPropertyTable) throws Exception
	  public static void associateFilterWithProperty(FilterTable paramFilterTable, FilterPropertyTable paramFilterPropertyTable)
	  {
		  s_baseDBUtil.associateFilterWithProperty(paramFilterTable, paramFilterPropertyTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateReportWithFile(Desktop.common.nomitech.common.db.local.ReportDefinitionTable paramReportDefinitionTable, Desktop.common.nomitech.common.db.local.FileDefinitionTable paramFileDefinitionTable) throws Exception
	  public static void associateReportWithFile(ReportDefinitionTable paramReportDefinitionTable, FileDefinitionTable paramFileDefinitionTable)
	  {
		  s_baseDBUtil.associateReportWithFile(paramReportDefinitionTable, paramFileDefinitionTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateFunctionWithArgument(Desktop.common.nomitech.common.db.local.FunctionTable paramFunctionTable, Desktop.common.nomitech.common.db.local.FunctionArgumentTable paramFunctionArgumentTable) throws Exception
	  public static void associateFunctionWithArgument(FunctionTable paramFunctionTable, FunctionArgumentTable paramFunctionArgumentTable)
	  {
		  s_baseDBUtil.associateFunctionWithArgument(paramFunctionTable, paramFunctionArgumentTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateLayoutWithPanel(Desktop.common.nomitech.common.db.layout.LayoutTable paramLayoutTable, Desktop.common.nomitech.common.db.layout.LayoutPanelTable paramLayoutPanelTable) throws Exception
	  public static void associateLayoutWithPanel(LayoutTable paramLayoutTable, LayoutPanelTable paramLayoutPanelTable)
	  {
		  s_baseDBUtil.associateLayoutWithPanel(paramLayoutTable, paramLayoutPanelTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateProfileWithFactor(Desktop.common.nomitech.common.db.local.LocalizationProfileTable paramLocalizationProfileTable, Desktop.common.nomitech.common.db.local.LocalizationFactorTable paramLocalizationFactorTable) throws Exception
	  public static void associateProfileWithFactor(LocalizationProfileTable paramLocalizationProfileTable, LocalizationFactorTable paramLocalizationFactorTable)
	  {
		  s_baseDBUtil.associateProfileWithFactor(paramLocalizationProfileTable, paramLocalizationFactorTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deassociateFactorFromProfile(Desktop.common.nomitech.common.db.local.LocalizationFactorTable paramLocalizationFactorTable) throws Exception
	  public static void deassociateFactorFromProfile(LocalizationFactorTable paramLocalizationFactorTable)
	  {
		  s_baseDBUtil.deassociateFactor(paramLocalizationFactorTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deassociateFilterWithProperty(Desktop.common.nomitech.common.db.local.FilterPropertyTable paramFilterPropertyTable) throws Exception
	  public static void deassociateFilterWithProperty(FilterPropertyTable paramFilterPropertyTable)
	  {
		  s_baseDBUtil.deassociateFilterProperty(paramFilterPropertyTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deassociateFileDefinition(Desktop.common.nomitech.common.db.local.FileDefinitionTable paramFileDefinitionTable) throws Exception
	  public static void deassociateFileDefinition(FileDefinitionTable paramFileDefinitionTable)
	  {
		  s_baseDBUtil.deassociateFileDefinition(paramFileDefinitionTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deassociateFunctionWithArgument(Desktop.common.nomitech.common.db.local.FunctionArgumentTable paramFunctionArgumentTable) throws Exception
	  public static void deassociateFunctionWithArgument(FunctionArgumentTable paramFunctionArgumentTable)
	  {
		  s_baseDBUtil.deassociateFunctionArgument(paramFunctionArgumentTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void removeFilterPropertys(Desktop.common.nomitech.common.db.local.FilterTable paramFilterTable) throws Exception
	  public static void removeFilterPropertys(FilterTable paramFilterTable)
	  {
		  s_baseDBUtil.removeFilterPropertys(paramFilterTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void removeFunctionArguments(Desktop.common.nomitech.common.db.local.FunctionTable paramFunctionTable) throws Exception
	  public static void removeFunctionArguments(FunctionTable paramFunctionTable)
	  {
		  s_baseDBUtil.removeFunctionArguments(paramFunctionTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateSupplierWithMaterial(Desktop.common.nomitech.common.db.local.SupplierTable paramSupplierTable, Desktop.common.nomitech.common.db.local.MaterialTable paramMaterialTable) throws Exception
	  public static void associateSupplierWithMaterial(SupplierTable paramSupplierTable, MaterialTable paramMaterialTable)
	  {
		  s_baseDBUtil.associateSupplierWithMaterial(paramSupplierTable, paramMaterialTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deassociateMaterialFromSupplier(Desktop.common.nomitech.common.db.local.MaterialTable paramMaterialTable) throws Exception
	  public static void deassociateMaterialFromSupplier(MaterialTable paramMaterialTable)
	  {
		  s_baseDBUtil.deassociateMaterialFromSupplier(paramMaterialTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateParamItemWithInput(Desktop.common.nomitech.common.db.local.ParamItemTable paramParamItemTable, Desktop.common.nomitech.common.db.local.ParamItemInputTable paramParamItemInputTable) throws Exception
	  public static void associateParamItemWithInput(ParamItemTable paramParamItemTable, ParamItemInputTable paramParamItemInputTable)
	  {
		  s_baseDBUtil.associateParamItemWithInput(paramParamItemTable, paramParamItemInputTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deassociateInputFromParamItem(Desktop.common.nomitech.common.db.local.ParamItemInputTable paramParamItemInputTable) throws Exception
	  public static void deassociateInputFromParamItem(ParamItemInputTable paramParamItemInputTable)
	  {
		  s_baseDBUtil.deassociateInputFromParamItem(paramParamItemInputTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateParamItemWithOutput(Desktop.common.nomitech.common.db.local.ParamItemTable paramParamItemTable, Desktop.common.nomitech.common.db.local.ParamItemOutputTable paramParamItemOutputTable) throws Exception
	  public static void associateParamItemWithOutput(ParamItemTable paramParamItemTable, ParamItemOutputTable paramParamItemOutputTable)
	  {
		  s_baseDBUtil.associateParamItemWithOutput(paramParamItemTable, paramParamItemOutputTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deassociateOutputFromParamItem(Desktop.common.nomitech.common.db.local.ParamItemOutputTable paramParamItemOutputTable) throws Exception
	  public static void deassociateOutputFromParamItem(ParamItemOutputTable paramParamItemOutputTable)
	  {
		  s_baseDBUtil.deassociateOutputFromParamItem(paramParamItemOutputTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateWBSWithProjectInfo(Desktop.common.nomitech.common.db.local.ProjectInfoTable paramProjectInfoTable, Desktop.common.nomitech.common.db.local.ProjectWBSTable paramProjectWBSTable) throws Exception
	  public static void associateWBSWithProjectInfo(ProjectInfoTable paramProjectInfoTable, ProjectWBSTable paramProjectWBSTable)
	  {
		  s_baseDBUtil.associateWBSWithProjectInfo(paramProjectInfoTable, paramProjectWBSTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateWBS2WithProjectInfo(Desktop.common.nomitech.common.db.local.ProjectInfoTable paramProjectInfoTable, Desktop.common.nomitech.common.db.local.ProjectWBS2Table paramProjectWBS2Table) throws Exception
	  public static void associateWBS2WithProjectInfo(ProjectInfoTable paramProjectInfoTable, ProjectWBS2Table paramProjectWBS2Table)
	  {
		  s_baseDBUtil.associateWBS2WithProjectInfo(paramProjectInfoTable, paramProjectWBS2Table);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deassociateWBSFromProjectInfo(Desktop.common.nomitech.common.db.local.ProjectWBSTable paramProjectWBSTable) throws Exception
	  public static void deassociateWBSFromProjectInfo(ProjectWBSTable paramProjectWBSTable)
	  {
		  s_baseDBUtil.deassociateWBSFromProjectInfo(paramProjectWBSTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deassociateWBS2FromProjectInfo(Desktop.common.nomitech.common.db.local.ProjectWBS2Table paramProjectWBS2Table) throws Exception
	  public static void deassociateWBS2FromProjectInfo(ProjectWBS2Table paramProjectWBS2Table)
	  {
		  s_baseDBUtil.deassociateWBS2FromProjectInfo(paramProjectWBS2Table);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static Desktop.common.nomitech.common.db.local.AssemblyTable updateAndRecalculateAssembly(Desktop.common.nomitech.common.db.local.AssemblyTable paramAssemblyTable, boolean paramBoolean) throws Exception
	  public static AssemblyTable updateAndRecalculateAssembly(AssemblyTable paramAssemblyTable, bool paramBoolean)
	  {
		  return s_baseDBUtil.recalculateAndUpdate(paramAssemblyTable, paramBoolean);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.math.BigDecimal recalculateAssemblyRate(Desktop.common.nomitech.common.db.local.AssemblyTable paramAssemblyTable) throws Exception
	  public static decimal recalculateAssemblyRate(AssemblyTable paramAssemblyTable)
	  {
		  return s_baseDBUtil.recalculateAssemblyRate(paramAssemblyTable);
	  }

	  public static string getPathOfJrxml(string paramString, Type paramClass, long? paramLong)
	  {
		  return s_baseDBUtil.getPathOfJrxml(paramString, paramClass, paramLong);
	  }

	  public static string getPathOfImage(string paramString, Type paramClass, long? paramLong)
	  {
		  return s_baseDBUtil.getPathOfImage(paramString, paramClass, paramLong);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static String uploadIcon(String paramString, Class paramClass) throws Exception
	  public static string uploadIcon(string paramString, Type paramClass)
	  {
		  return s_baseDBUtil.uploadIcon(paramString, paramClass);
	  }

	  public static string uploadImage(string paramString, Type paramClass, long? paramLong)
	  {
		  return s_baseDBUtil.uploadImage(paramString, paramClass, paramLong);
	  }

	  public static string uploadJrxml(string paramString, Type paramClass, long? paramLong)
	  {
		  return s_baseDBUtil.uploadJrxml(paramString, paramClass, paramLong);
	  }

	  public static string getPathOfIcon(string paramString, Type paramClass, int paramInt)
	  {
		  return s_baseDBUtil.getPathOfIcon(paramString, paramClass, paramInt);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static boolean deleteIconIfNotReferred(String paramString, Class paramClass) throws Exception
	  public static bool deleteIconIfNotReferred(string paramString, Type paramClass)
	  {
		  return s_baseDBUtil.deleteIcon(paramString, paramClass);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static boolean deleteImage(String paramString, Class paramClass, System.Nullable<long> paramLong) throws Exception
	  public static bool deleteImage(string paramString, Type paramClass, long? paramLong)
	  {
		  return s_baseDBUtil.deleteImage(paramString, paramClass, paramLong);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static boolean deleteJrxml(String paramString, Class paramClass, System.Nullable<long> paramLong) throws Exception
	  public static bool deleteJrxml(string paramString, Type paramClass, long? paramLong)
	  {
		  return s_baseDBUtil.deleteJrxml(paramString, paramClass, paramLong);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.util.List<String> getAvailableReportGroupings() throws Exception
	  public static IList<string> AvailableReportGroupings
	  {
		  get
		  {
			  return s_baseDBUtil.AvailableReportGroupings;
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.util.List<String> getParamItemInputGroupings() throws Exception
	  public static IList<string> ParamItemInputGroupings
	  {
		  get
		  {
			  return s_baseDBUtil.ParamItemInputGroupings;
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.util.List<String> getAvailableVariables(System.Nullable<long> paramLong) throws Exception
	  public static IList<string> getAvailableVariables(long? paramLong)
	  {
		  return s_baseDBUtil.getAvailableVariables(paramLong);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateParamItemOutputWithConResource(Desktop.common.nomitech.common.db.local.ParamItemConceptualResourceTable paramParamItemConceptualResourceTable, Desktop.common.nomitech.common.db.local.ParamItemOutputTable paramParamItemOutputTable) throws Exception
	  public static void associateParamItemOutputWithConResource(ParamItemConceptualResourceTable paramParamItemConceptualResourceTable, ParamItemOutputTable paramParamItemOutputTable)
	  {
		  s_baseDBUtil.associateParamItemOutputWithConResource(paramParamItemConceptualResourceTable, paramParamItemOutputTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deassociateConResourceFromOutput(Desktop.common.nomitech.common.db.local.ParamItemConceptualResourceTable paramParamItemConceptualResourceTable) throws Exception
	  public static void deassociateConResourceFromOutput(ParamItemConceptualResourceTable paramParamItemConceptualResourceTable)
	  {
		  s_baseDBUtil.deassociateConResourceFromOutput(paramParamItemConceptualResourceTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateParamItemOutputWithQueryResource(Desktop.common.nomitech.common.db.local.ParamItemQueryResourceTable paramParamItemQueryResourceTable, Desktop.common.nomitech.common.db.local.ParamItemOutputTable paramParamItemOutputTable) throws Exception
	  public static void associateParamItemOutputWithQueryResource(ParamItemQueryResourceTable paramParamItemQueryResourceTable, ParamItemOutputTable paramParamItemOutputTable)
	  {
		  s_baseDBUtil.associateParamItemOutputWithQueryResource(paramParamItemQueryResourceTable, paramParamItemOutputTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deassociateQueryResourceFromOutput(Desktop.common.nomitech.common.db.local.ParamItemQueryResourceTable paramParamItemQueryResourceTable) throws Exception
	  public static void deassociateQueryResourceFromOutput(ParamItemQueryResourceTable paramParamItemQueryResourceTable)
	  {
		  s_baseDBUtil.deassociateQueryResourceFromOutput(paramParamItemQueryResourceTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateProjectWithUrl(Desktop.common.nomitech.common.db.local.ProjectInfoTable paramProjectInfoTable, Desktop.common.nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable) throws Exception
	  public static void associateProjectWithUrl(ProjectInfoTable paramProjectInfoTable, ProjectUrlTable paramProjectUrlTable)
	  {
		  s_baseDBUtil.associateProjectWithUrl(paramProjectInfoTable, paramProjectUrlTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deassociateUrlFromProject(Desktop.common.nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable) throws Exception
	  public static void deassociateUrlFromProject(ProjectUrlTable paramProjectUrlTable)
	  {
		  s_baseDBUtil.deassociateUrlFromProject(paramProjectUrlTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateProjectWithUser(Desktop.common.nomitech.common.db.local.ProjectInfoTable paramProjectInfoTable, Desktop.common.nomitech.common.db.local.ProjectUserTable paramProjectUserTable) throws Exception
	  public static void associateProjectWithUser(ProjectInfoTable paramProjectInfoTable, ProjectUserTable paramProjectUserTable)
	  {
		  s_baseDBUtil.associateProjectWithUser(paramProjectInfoTable, paramProjectUserTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deassociateUserFromProject(Desktop.common.nomitech.common.db.local.ProjectUserTable paramProjectUserTable) throws Exception
	  public static void deassociateUserFromProject(ProjectUserTable paramProjectUserTable)
	  {
		  s_baseDBUtil.deassociateUserFromProject(paramProjectUserTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateEPSWithProject(Desktop.common.nomitech.common.db.local.ProjectEPSTable paramProjectEPSTable, Desktop.common.nomitech.common.db.local.ProjectInfoTable paramProjectInfoTable) throws Exception
	  public static void associateEPSWithProject(ProjectEPSTable paramProjectEPSTable, ProjectInfoTable paramProjectInfoTable)
	  {
		  s_baseDBUtil.associateEPSWithProject(paramProjectEPSTable, paramProjectInfoTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deassociateProjectFromEPS(Desktop.common.nomitech.common.db.local.ProjectInfoTable paramProjectInfoTable) throws Exception
	  public static void deassociateProjectFromEPS(ProjectInfoTable paramProjectInfoTable)
	  {
		  s_baseDBUtil.deassociateProjectFromEPS(paramProjectInfoTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateProjectWithCondition(Desktop.common.nomitech.common.db.local.ProjectInfoTable paramProjectInfoTable, Desktop.common.nomitech.common.db.local.TakeoffConditionTable paramTakeoffConditionTable) throws Exception
	  public static void associateProjectWithCondition(ProjectInfoTable paramProjectInfoTable, TakeoffConditionTable paramTakeoffConditionTable)
	  {
		  s_baseDBUtil.associateProjectWithCondition(paramProjectInfoTable, paramTakeoffConditionTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deassociateConditionFromProject(Desktop.common.nomitech.common.db.local.TakeoffConditionTable paramTakeoffConditionTable) throws Exception
	  public static void deassociateConditionFromProject(TakeoffConditionTable paramTakeoffConditionTable)
	  {
		  s_baseDBUtil.deassociateConditionFromProject(paramTakeoffConditionTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.util.List<Desktop.common.nomitech.common.db.local.ProjectInfoTable> loadProjectInfosWithUrls(System.Nullable<long>[] paramArrayOfLong) throws Exception
	  public static IList<ProjectInfoTable> loadProjectInfosWithUrls(long?[] paramArrayOfLong)
	  {
		  return s_baseDBUtil.loadProjectInfosWithUrls(paramArrayOfLong);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.util.List<Desktop.common.nomitech.common.db.local.ProjectInfoTable> findProjectInfosAndEPSsByQuery(String paramString) throws Exception
	  public static IList<ProjectInfoTable> findProjectInfosAndEPSsByQuery(string paramString)
	  {
		  return s_baseDBUtil.findProjectInfosAndEPSsByQuery(paramString);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.util.List<Desktop.common.nomitech.common.db.local.ProjectInfoTable> loadProjectInfosWithEPS(System.Nullable<long>[] paramArrayOfLong) throws Exception
	  public static IList<ProjectInfoTable> loadProjectInfosWithEPS(long?[] paramArrayOfLong)
	  {
		  return s_baseDBUtil.loadProjectInfosWithEPS(paramArrayOfLong);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.util.List<Desktop.common.nomitech.common.db.local.TakeoffConditionTable> findMapConditionsByQueryDeepCopy(String paramString) throws Exception
	  public static IList<TakeoffConditionTable> findMapConditionsByQueryDeepCopy(string paramString)
	  {
		  return s_baseDBUtil.findMapConditionsByQueryDeepCopy(paramString);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void setElevationSamplesOfLine(Desktop.common.nomitech.common.db.local.TakeoffLineTable paramTakeoffLineTable, java.util.List<Desktop.common.nomitech.common.db.local.TakeoffPointTable> paramList) throws Exception
	  public static void setElevationSamplesOfLine(TakeoffLineTable paramTakeoffLineTable, IList<TakeoffPointTable> paramList)
	  {
		  s_baseDBUtil.setElevationSamplesOfLine(paramTakeoffLineTable, paramList);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateConditionWithLine(Desktop.common.nomitech.common.db.local.TakeoffConditionTable paramTakeoffConditionTable, Desktop.common.nomitech.common.db.local.TakeoffLineTable paramTakeoffLineTable) throws Exception
	  public static void associateConditionWithLine(TakeoffConditionTable paramTakeoffConditionTable, TakeoffLineTable paramTakeoffLineTable)
	  {
		  s_baseDBUtil.associateConditionWithLine(paramTakeoffConditionTable, paramTakeoffLineTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void setPolygonOfArea(Desktop.common.nomitech.common.db.local.TakeoffAreaTable paramTakeoffAreaTable, java.util.List<Desktop.common.nomitech.common.db.local.TakeoffPointTable> paramList) throws Exception
	  public static void setPolygonOfArea(TakeoffAreaTable paramTakeoffAreaTable, IList<TakeoffPointTable> paramList)
	  {
		  s_baseDBUtil.setPolygonOfArea(paramTakeoffAreaTable, paramList);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void setTrianglesOfArea(Desktop.common.nomitech.common.db.local.TakeoffAreaTable paramTakeoffAreaTable, java.util.List<Desktop.common.nomitech.common.db.local.TakeoffTriangleTable> paramList) throws Exception
	  public static void setTrianglesOfArea(TakeoffAreaTable paramTakeoffAreaTable, IList<TakeoffTriangleTable> paramList)
	  {
		  s_baseDBUtil.setTrianglesOfArea(paramTakeoffAreaTable, paramList);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateConditionWithArea(Desktop.common.nomitech.common.db.local.TakeoffConditionTable paramTakeoffConditionTable, Desktop.common.nomitech.common.db.local.TakeoffAreaTable paramTakeoffAreaTable) throws Exception
	  public static void associateConditionWithArea(TakeoffConditionTable paramTakeoffConditionTable, TakeoffAreaTable paramTakeoffAreaTable)
	  {
		  s_baseDBUtil.associateConditionWithArea(paramTakeoffConditionTable, paramTakeoffAreaTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateConditionWithPoint(Desktop.common.nomitech.common.db.local.TakeoffConditionTable paramTakeoffConditionTable, Desktop.common.nomitech.common.db.local.TakeoffPointTable paramTakeoffPointTable) throws Exception
	  public static void associateConditionWithPoint(TakeoffConditionTable paramTakeoffConditionTable, TakeoffPointTable paramTakeoffPointTable)
	  {
		  s_baseDBUtil.associateConditionWithPoint(paramTakeoffConditionTable, paramTakeoffPointTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateConditionWithLegend(Desktop.common.nomitech.common.db.local.TakeoffConditionTable paramTakeoffConditionTable, Desktop.common.nomitech.common.db.local.TakeoffLegendTable paramTakeoffLegendTable) throws Exception
	  public static void associateConditionWithLegend(TakeoffConditionTable paramTakeoffConditionTable, TakeoffLegendTable paramTakeoffLegendTable)
	  {
		  s_baseDBUtil.associateConditionWithLegend(paramTakeoffConditionTable, paramTakeoffLegendTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateVariableWithTemplate(Desktop.common.nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, Desktop.common.nomitech.common.db.project.ProjectVariableTable paramProjectVariableTable) throws Exception
	  public static void associateVariableWithTemplate(ProjectTemplateTable paramProjectTemplateTable, ProjectVariableTable paramProjectVariableTable)
	  {
		  s_baseDBUtil.associateVariableWithTemplate(paramProjectTemplateTable, paramProjectVariableTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deassociateVariableFromTemplate(Desktop.common.nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, Desktop.common.nomitech.common.db.project.ProjectVariableTable paramProjectVariableTable) throws Exception
	  public static void deassociateVariableFromTemplate(ProjectTemplateTable paramProjectTemplateTable, ProjectVariableTable paramProjectVariableTable)
	  {
		  s_baseDBUtil.deassociateVariableFromTemplate(paramProjectTemplateTable, paramProjectVariableTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateBuildUpColumnWithTemplate(Desktop.common.nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, Desktop.common.nomitech.common.db.project.RateBuildUpColumnsTable paramRateBuildUpColumnsTable) throws Exception
	  public static void associateBuildUpColumnWithTemplate(ProjectTemplateTable paramProjectTemplateTable, RateBuildUpColumnsTable paramRateBuildUpColumnsTable)
	  {
		  s_baseDBUtil.associateBuildUpColumnWithTemplate(paramProjectTemplateTable, paramRateBuildUpColumnsTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deassociateBuildUpColumnFromTemplate(Desktop.common.nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, Desktop.common.nomitech.common.db.project.RateBuildUpColumnsTable paramRateBuildUpColumnsTable) throws Exception
	  public static void deassociateBuildUpColumnFromTemplate(ProjectTemplateTable paramProjectTemplateTable, RateBuildUpColumnsTable paramRateBuildUpColumnsTable)
	  {
		  s_baseDBUtil.deassociateBuildUpColumnFromTemplate(paramProjectTemplateTable, paramRateBuildUpColumnsTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateRateBuildUpWithTemplate(Desktop.common.nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, Desktop.common.nomitech.common.db.project.RateBuildUpTable paramRateBuildUpTable) throws Exception
	  public static void associateRateBuildUpWithTemplate(ProjectTemplateTable paramProjectTemplateTable, RateBuildUpTable paramRateBuildUpTable)
	  {
		  s_baseDBUtil.associateRateBuildUpWithTemplate(paramProjectTemplateTable, paramRateBuildUpTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deassociateRateBuildUpFromTemplate(Desktop.common.nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, Desktop.common.nomitech.common.db.project.RateBuildUpTable paramRateBuildUpTable) throws Exception
	  public static void deassociateRateBuildUpFromTemplate(ProjectTemplateTable paramProjectTemplateTable, RateBuildUpTable paramRateBuildUpTable)
	  {
		  s_baseDBUtil.deassociateRateBuildUpFromTemplate(paramProjectTemplateTable, paramRateBuildUpTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void associateDistributorWithTemplate(Desktop.common.nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, Desktop.common.nomitech.common.db.project.RateDistributorTable paramRateDistributorTable) throws Exception
	  public static void associateDistributorWithTemplate(ProjectTemplateTable paramProjectTemplateTable, RateDistributorTable paramRateDistributorTable)
	  {
		  s_baseDBUtil.associateDistributorWithTemplate(paramProjectTemplateTable, paramRateDistributorTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deassociateDistributorFromTemplate(Desktop.common.nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, Desktop.common.nomitech.common.db.project.RateDistributorTable paramRateDistributorTable) throws Exception
	  public static void deassociateDistributorFromTemplate(ProjectTemplateTable paramProjectTemplateTable, RateDistributorTable paramRateDistributorTable)
	  {
		  s_baseDBUtil.deassociateDistributorFromTemplate(paramProjectTemplateTable, paramRateDistributorTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static Desktop.common.nomitech.common.db.project.ProjectExcelFile associateExcelFileWithTemplate(System.Nullable<long> paramLong1, System.Nullable<long> paramLong2) throws Exception
	  public static ProjectExcelFile associateExcelFileWithTemplate(long? paramLong1, long? paramLong2)
	  {
		  return s_baseDBUtil.associateExcelFileWithTemplate(paramLong1, paramLong2);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void removeElevationSamplesFromLine(Desktop.common.nomitech.common.db.local.TakeoffLineTable paramTakeoffLineTable) throws Exception
	  public static void removeElevationSamplesFromLine(TakeoffLineTable paramTakeoffLineTable)
	  {
		  s_baseDBUtil.removeElevationSamplesFromLine(paramTakeoffLineTable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void updateTakeoffPoints(java.util.List<Desktop.common.nomitech.common.db.local.TakeoffPointTable> paramList) throws Exception
	  public static void updateTakeoffPoints(IList<TakeoffPointTable> paramList)
	  {
		  s_baseDBUtil.updateTakeoffPoints(paramList);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void updateTakeoffTriangles(java.util.List<Desktop.common.nomitech.common.db.local.TakeoffTriangleTable> paramList) throws Exception
	  public static void updateTakeoffTriangles(IList<TakeoffTriangleTable> paramList)
	  {
		  s_baseDBUtil.updateTakeoffTriangles(paramList);
	  }

	  public static int getParamItemInputCount(long? paramLong)
	  {
		try
		{
		  return s_baseDBUtil.getParamItemInputCount(paramLong);
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  return 0;
		}
	  }

	  public static int getParamItemOutputCount(long? paramLong)
	  {
		try
		{
		  return s_baseDBUtil.getParamItemOutputCount(paramLong);
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  return 0;
		}
	  }

	  public static int DbmsType
	  {
		  get
		  {
			  return s_baseDBUtil.DbmsType;
		  }
	  }

	  public static bool Loaded
	  {
		  get
		  {
			  return (s_baseDBUtil != null);
		  }
	  }

	  public static bool UserLogEnabled
	  {
		  get
		  {
			  return s_baseDBUtil.UserLogEnabled;
		  }
	  }

	  public static void setLocalConnection(string paramString1, string paramString2, string paramString3, int paramInt)
	  {
		  s_baseDBUtil.setLocalConnection(paramString1, paramString2, paramString3, paramInt);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\DatabaseDBUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}