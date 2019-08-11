using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.@base
{
	using LayoutPanelTable = nomitech.common.db.layout.LayoutPanelTable;
	using LayoutTable = nomitech.common.db.layout.LayoutTable;
	using AssemblyTable = nomitech.common.db.local.AssemblyTable;
	using FileDefinitionTable = nomitech.common.db.local.FileDefinitionTable;
	using FilterPropertyTable = nomitech.common.db.local.FilterPropertyTable;
	using FilterTable = nomitech.common.db.local.FilterTable;
	using FunctionArgumentTable = nomitech.common.db.local.FunctionArgumentTable;
	using FunctionTable = nomitech.common.db.local.FunctionTable;
	using LocalizationFactorTable = nomitech.common.db.local.LocalizationFactorTable;
	using LocalizationProfileTable = nomitech.common.db.local.LocalizationProfileTable;
	using MaterialTable = nomitech.common.db.local.MaterialTable;
	using ParamItemConceptualResourceTable = nomitech.common.db.local.ParamItemConceptualResourceTable;
	using ParamItemInputTable = nomitech.common.db.local.ParamItemInputTable;
	using ParamItemOutputTable = nomitech.common.db.local.ParamItemOutputTable;
	using ParamItemQueryResourceTable = nomitech.common.db.local.ParamItemQueryResourceTable;
	using ParamItemTable = nomitech.common.db.local.ParamItemTable;
	using ProjectEPSTable = nomitech.common.db.local.ProjectEPSTable;
	using ProjectInfoTable = nomitech.common.db.local.ProjectInfoTable;
	using ProjectUrlTable = nomitech.common.db.local.ProjectUrlTable;
	using ProjectUserTable = nomitech.common.db.local.ProjectUserTable;
	using ProjectWBS2Table = nomitech.common.db.local.ProjectWBS2Table;
	using ProjectWBSTable = nomitech.common.db.local.ProjectWBSTable;
	using ReportDefinitionTable = nomitech.common.db.local.ReportDefinitionTable;
	using SupplierTable = nomitech.common.db.local.SupplierTable;
	using TakeoffAreaTable = nomitech.common.db.local.TakeoffAreaTable;
	using TakeoffConditionTable = nomitech.common.db.local.TakeoffConditionTable;
	using TakeoffLegendTable = nomitech.common.db.local.TakeoffLegendTable;
	using TakeoffLineTable = nomitech.common.db.local.TakeoffLineTable;
	using TakeoffPointTable = nomitech.common.db.local.TakeoffPointTable;
	using TakeoffTriangleTable = nomitech.common.db.local.TakeoffTriangleTable;
	using ProjectExcelFile = nomitech.common.db.project.ProjectExcelFile;
	using ProjectTemplateTable = nomitech.common.db.project.ProjectTemplateTable;
	using ProjectVariableTable = nomitech.common.db.project.ProjectVariableTable;
	using RateBuildUpColumnsTable = nomitech.common.db.project.RateBuildUpColumnsTable;
	using RateBuildUpTable = nomitech.common.db.project.RateBuildUpTable;
	using RateDistributorTable = nomitech.common.db.project.RateDistributorTable;
	using HqlParameterWithValue = nomitech.common.db.util.HqlParameterWithValue;
	using HqlResultValue = nomitech.common.db.util.HqlResultValue;
	using ProgressCallback = nomitech.common.util.ProgressCallback;
	using Analyzer = org.apache.lucene.analysis.Analyzer;
	using HibernateException = org.hibernate.HibernateException;
	using Session = org.hibernate.Session;

	public interface BaseDBUtil
	{
	  bool LocalCommunication {get;}

	  bool Enterprise {get;}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: java.io.Serializable associateAssemblyResource(nomitech.common.db.local.AssemblyTable paramAssemblyTable, BaseTable paramBaseTable, java.io.Serializable paramSerializable) throws Exception;
	  Serializable associateAssemblyResource(AssemblyTable paramAssemblyTable, BaseTable paramBaseTable, Serializable paramSerializable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void deassociateAssemblyResource(java.io.Serializable paramSerializable) throws Exception;
	  void deassociateAssemblyResource(Serializable paramSerializable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void removeFilterPropertys(nomitech.common.db.local.FilterTable paramFilterTable) throws Exception;
	  void removeFilterPropertys(FilterTable paramFilterTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateFilterWithProperty(nomitech.common.db.local.FilterTable paramFilterTable, nomitech.common.db.local.FilterPropertyTable paramFilterPropertyTable) throws Exception;
	  void associateFilterWithProperty(FilterTable paramFilterTable, FilterPropertyTable paramFilterPropertyTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void deassociateFilterProperty(nomitech.common.db.local.FilterPropertyTable paramFilterPropertyTable) throws Exception;
	  void deassociateFilterProperty(FilterPropertyTable paramFilterPropertyTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateReportWithFile(nomitech.common.db.local.ReportDefinitionTable paramReportDefinitionTable, nomitech.common.db.local.FileDefinitionTable paramFileDefinitionTable) throws Exception;
	  void associateReportWithFile(ReportDefinitionTable paramReportDefinitionTable, FileDefinitionTable paramFileDefinitionTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void deassociateFileDefinition(nomitech.common.db.local.FileDefinitionTable paramFileDefinitionTable) throws Exception;
	  void deassociateFileDefinition(FileDefinitionTable paramFileDefinitionTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void removeFileDefinitions(nomitech.common.db.local.ReportDefinitionTable paramReportDefinitionTable) throws Exception;
	  void removeFileDefinitions(ReportDefinitionTable paramReportDefinitionTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateFunctionWithArgument(nomitech.common.db.local.FunctionTable paramFunctionTable, nomitech.common.db.local.FunctionArgumentTable paramFunctionArgumentTable) throws Exception;
	  void associateFunctionWithArgument(FunctionTable paramFunctionTable, FunctionArgumentTable paramFunctionArgumentTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void deassociateFunctionArgument(nomitech.common.db.local.FunctionArgumentTable paramFunctionArgumentTable) throws Exception;
	  void deassociateFunctionArgument(FunctionArgumentTable paramFunctionArgumentTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void removeFunctionArguments(nomitech.common.db.local.FunctionTable paramFunctionTable) throws Exception;
	  void removeFunctionArguments(FunctionTable paramFunctionTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: java.util.List loadBulk(Class paramClass, System.Nullable<long>[] paramArrayOfLong) throws Exception;
	  System.Collections.IList loadBulk(Type paramClass, long?[] paramArrayOfLong);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void bulkSaveOrUpdate(Class paramClass, java.util.List paramList) throws Exception;
	  void bulkSaveOrUpdate(Type paramClass, System.Collections.IList paramList);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: int executeUpdate(String paramString1, String paramString2, java.util.List<long> paramList) throws Exception;
	  int executeUpdate(string paramString1, string paramString2, IList<long> paramList);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: java.util.List<long> executeLongQuery(String paramString1, String paramString2, java.util.List<long> paramList) throws Exception;
	  IList<long> executeLongQuery(string paramString1, string paramString2, IList<long> paramList);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateSupplierWithMaterial(nomitech.common.db.local.SupplierTable paramSupplierTable, nomitech.common.db.local.MaterialTable paramMaterialTable) throws Exception;
	  void associateSupplierWithMaterial(SupplierTable paramSupplierTable, MaterialTable paramMaterialTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void deassociateMaterialFromSupplier(nomitech.common.db.local.MaterialTable paramMaterialTable) throws Exception;
	  void deassociateMaterialFromSupplier(MaterialTable paramMaterialTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void testAuthorizedUser(String paramString1, String paramString2, String paramString3, String paramString4) throws Exception;
	  void testAuthorizedUser(string paramString1, string paramString2, string paramString3, string paramString4);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: boolean testAuthorizedUser(String paramString1, String paramString2) throws Exception;
	  bool testAuthorizedUser(string paramString1, string paramString2);

	  void notifyDataChanged(BaseTable paramBaseTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void changePassword(String paramString1, String paramString2, String paramString3) throws Exception;
	  void changePassword(string paramString1, string paramString2, string paramString3);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void loadDB(GroupCodesProvider paramGroupCodesProvider, String paramString1, String paramString2, boolean paramBoolean) throws Exception;
	  void loadDB(GroupCodesProvider paramGroupCodesProvider, string paramString1, string paramString2, bool paramBoolean);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: boolean initDB(String paramString1, String paramString2) throws Exception;
	  bool initDB(string paramString1, string paramString2);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void importDB(java.io.File paramFile, String paramString1, String paramString2, nomitech.common.util.ProgressCallback paramProgressCallback) throws Exception;
	  void importDB(File paramFile, string paramString1, string paramString2, ProgressCallback paramProgressCallback);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void exportDB(java.io.File paramFile, String paramString1, String paramString2, nomitech.common.util.ProgressCallback paramProgressCallback) throws Exception;
	  void exportDB(File paramFile, string paramString1, string paramString2, ProgressCallback paramProgressCallback);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void exportDB(java.io.File paramFile, nomitech.common.util.ProgressCallback paramProgressCallback) throws Exception;
	  void exportDB(File paramFile, ProgressCallback paramProgressCallback);

	  void unloadDB(bool paramBoolean);

	  bool hasOpenedSession();

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: org.hibernate.Session currentSession() throws org.hibernate.HibernateException;
	  Session currentSession();

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: java.util.List fullTextSearchSession(String paramString1, String[] paramArrayOfString, Class[] paramArrayOfClass, org.apache.lucene.analysis.Analyzer paramAnalyzer, int paramInt, String paramString2, boolean paramBoolean) throws Exception;
	  System.Collections.IList fullTextSearchSession(string paramString1, string[] paramArrayOfString, Type[] paramArrayOfClass, Analyzer paramAnalyzer, int paramInt, string paramString2, bool paramBoolean);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: java.util.List fullTextSearchSession(String paramString1, Class paramClass, int paramInt, String paramString2, boolean paramBoolean) throws Exception;
	  System.Collections.IList fullTextSearchSession(string paramString1, Type paramClass, int paramInt, string paramString2, bool paramBoolean);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void closeSession() throws org.hibernate.HibernateException;
	  void closeSession();

	  bool deleteDirectory(File paramFile);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void connectDB(GroupCodesProvider paramGroupCodesProvider, String paramString1, String paramString2, String paramString3, String paramString4) throws Exception;
	  void connectDB(GroupCodesProvider paramGroupCodesProvider, string paramString1, string paramString2, string paramString3, string paramString4);

	  BaseDBProperties Properties {get;}

	  BaseDBProperties reloadProperties();

	  BaseDBProperties reloadProperties(string paramString);

	  string InstallDirectory {set;}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void removeLayoutPanels(nomitech.common.db.layout.LayoutTable paramLayoutTable) throws Exception;
	  void removeLayoutPanels(LayoutTable paramLayoutTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateLayoutWithPanel(nomitech.common.db.layout.LayoutTable paramLayoutTable, nomitech.common.db.layout.LayoutPanelTable paramLayoutPanelTable) throws Exception;
	  void associateLayoutWithPanel(LayoutTable paramLayoutTable, LayoutPanelTable paramLayoutPanelTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void deassociateLayoutPanel(nomitech.common.db.layout.LayoutPanelTable paramLayoutPanelTable) throws Exception;
	  void deassociateLayoutPanel(LayoutPanelTable paramLayoutPanelTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateProfileWithFactor(nomitech.common.db.local.LocalizationProfileTable paramLocalizationProfileTable, nomitech.common.db.local.LocalizationFactorTable paramLocalizationFactorTable) throws Exception;
	  void associateProfileWithFactor(LocalizationProfileTable paramLocalizationProfileTable, LocalizationFactorTable paramLocalizationFactorTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void deassociateFactor(nomitech.common.db.local.LocalizationFactorTable paramLocalizationFactorTable) throws Exception;
	  void deassociateFactor(LocalizationFactorTable paramLocalizationFactorTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateWBSWithProjectInfo(nomitech.common.db.local.ProjectInfoTable paramProjectInfoTable, nomitech.common.db.local.ProjectWBSTable paramProjectWBSTable) throws Exception;
	  void associateWBSWithProjectInfo(ProjectInfoTable paramProjectInfoTable, ProjectWBSTable paramProjectWBSTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateWBS2WithProjectInfo(nomitech.common.db.local.ProjectInfoTable paramProjectInfoTable, nomitech.common.db.local.ProjectWBS2Table paramProjectWBS2Table) throws Exception;
	  void associateWBS2WithProjectInfo(ProjectInfoTable paramProjectInfoTable, ProjectWBS2Table paramProjectWBS2Table);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void deassociateWBSFromProjectInfo(nomitech.common.db.local.ProjectWBSTable paramProjectWBSTable) throws Exception;
	  void deassociateWBSFromProjectInfo(ProjectWBSTable paramProjectWBSTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void deassociateWBS2FromProjectInfo(nomitech.common.db.local.ProjectWBS2Table paramProjectWBS2Table) throws Exception;
	  void deassociateWBS2FromProjectInfo(ProjectWBS2Table paramProjectWBS2Table);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateParamItemWithInput(nomitech.common.db.local.ParamItemTable paramParamItemTable, nomitech.common.db.local.ParamItemInputTable paramParamItemInputTable) throws Exception;
	  void associateParamItemWithInput(ParamItemTable paramParamItemTable, ParamItemInputTable paramParamItemInputTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void deassociateInputFromParamItem(nomitech.common.db.local.ParamItemInputTable paramParamItemInputTable) throws Exception;
	  void deassociateInputFromParamItem(ParamItemInputTable paramParamItemInputTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateParamItemWithOutput(nomitech.common.db.local.ParamItemTable paramParamItemTable, nomitech.common.db.local.ParamItemOutputTable paramParamItemOutputTable) throws Exception;
	  void associateParamItemWithOutput(ParamItemTable paramParamItemTable, ParamItemOutputTable paramParamItemOutputTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void deassociateOutputFromParamItem(nomitech.common.db.local.ParamItemOutputTable paramParamItemOutputTable) throws Exception;
	  void deassociateOutputFromParamItem(ParamItemOutputTable paramParamItemOutputTable);

	  string getPathOfJrxml(string paramString, Type paramClass, long? paramLong);

	  string uploadJrxml(string paramString, Type paramClass, long? paramLong);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: boolean deleteJrxml(String paramString, Class paramClass, System.Nullable<long> paramLong) throws Exception;
	  bool deleteJrxml(string paramString, Type paramClass, long? paramLong);

	  string getPathOfImage(string paramString, Type paramClass, long? paramLong);

	  string uploadImage(string paramString, Type paramClass, long? paramLong);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: boolean deleteImage(String paramString, Class paramClass, System.Nullable<long> paramLong) throws Exception;
	  bool deleteImage(string paramString, Type paramClass, long? paramLong);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: java.math.BigDecimal recalculateAssemblyRate(nomitech.common.db.local.AssemblyTable paramAssemblyTable) throws Exception;
	  decimal recalculateAssemblyRate(AssemblyTable paramAssemblyTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: nomitech.common.db.local.AssemblyTable recalculateAndUpdate(nomitech.common.db.local.AssemblyTable paramAssemblyTable, boolean paramBoolean) throws Exception;
	  AssemblyTable recalculateAndUpdate(AssemblyTable paramAssemblyTable, bool paramBoolean);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: String uploadIcon(String paramString, Class paramClass) throws Exception;
	  string uploadIcon(string paramString, Type paramClass);

	  string getPathOfIcon(string paramString, Type paramClass, int paramInt);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: boolean deleteIcon(String paramString, Class paramClass) throws Exception;
	  bool deleteIcon(string paramString, Type paramClass);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: java.util.List<String> getAvailableReportGroupings() throws Exception;
	  IList<string> AvailableReportGroupings {get;}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: java.util.List<String> getParamItemInputGroupings() throws Exception;
	  IList<string> ParamItemInputGroupings {get;}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: java.util.List<String> getAvailableVariables(System.Nullable<long> paramLong) throws Exception;
	  IList<string> getAvailableVariables(long? paramLong);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateParamItemOutputWithConResource(nomitech.common.db.local.ParamItemConceptualResourceTable paramParamItemConceptualResourceTable, nomitech.common.db.local.ParamItemOutputTable paramParamItemOutputTable) throws Exception;
	  void associateParamItemOutputWithConResource(ParamItemConceptualResourceTable paramParamItemConceptualResourceTable, ParamItemOutputTable paramParamItemOutputTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void deassociateConResourceFromOutput(nomitech.common.db.local.ParamItemConceptualResourceTable paramParamItemConceptualResourceTable) throws Exception;
	  void deassociateConResourceFromOutput(ParamItemConceptualResourceTable paramParamItemConceptualResourceTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateParamItemOutputWithQueryResource(nomitech.common.db.local.ParamItemQueryResourceTable paramParamItemQueryResourceTable, nomitech.common.db.local.ParamItemOutputTable paramParamItemOutputTable) throws Exception;
	  void associateParamItemOutputWithQueryResource(ParamItemQueryResourceTable paramParamItemQueryResourceTable, ParamItemOutputTable paramParamItemOutputTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void deassociateQueryResourceFromOutput(nomitech.common.db.local.ParamItemQueryResourceTable paramParamItemQueryResourceTable) throws Exception;
	  void deassociateQueryResourceFromOutput(ParamItemQueryResourceTable paramParamItemQueryResourceTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: int getParamItemInputCount(System.Nullable<long> paramLong) throws Exception;
	  int getParamItemInputCount(long? paramLong);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: int getParamItemOutputCount(System.Nullable<long> paramLong) throws Exception;
	  int getParamItemOutputCount(long? paramLong);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: java.util.List loadAllDeepCopy(Class paramClass) throws Exception;
	  System.Collections.IList loadAllDeepCopy(Type paramClass);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateProjectWithCondition(nomitech.common.db.local.ProjectInfoTable paramProjectInfoTable, nomitech.common.db.local.TakeoffConditionTable paramTakeoffConditionTable) throws Exception;
	  void associateProjectWithCondition(ProjectInfoTable paramProjectInfoTable, TakeoffConditionTable paramTakeoffConditionTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void deassociateConditionFromProject(nomitech.common.db.local.TakeoffConditionTable paramTakeoffConditionTable) throws Exception;
	  void deassociateConditionFromProject(TakeoffConditionTable paramTakeoffConditionTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateProjectWithUrl(nomitech.common.db.local.ProjectInfoTable paramProjectInfoTable, nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable) throws Exception;
	  void associateProjectWithUrl(ProjectInfoTable paramProjectInfoTable, ProjectUrlTable paramProjectUrlTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void deassociateUrlFromProject(nomitech.common.db.local.ProjectUrlTable paramProjectUrlTable) throws Exception;
	  void deassociateUrlFromProject(ProjectUrlTable paramProjectUrlTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateProjectWithUser(nomitech.common.db.local.ProjectInfoTable paramProjectInfoTable, nomitech.common.db.local.ProjectUserTable paramProjectUserTable) throws Exception;
	  void associateProjectWithUser(ProjectInfoTable paramProjectInfoTable, ProjectUserTable paramProjectUserTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void deassociateUserFromProject(nomitech.common.db.local.ProjectUserTable paramProjectUserTable) throws Exception;
	  void deassociateUserFromProject(ProjectUserTable paramProjectUserTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateEPSWithProject(nomitech.common.db.local.ProjectEPSTable paramProjectEPSTable, nomitech.common.db.local.ProjectInfoTable paramProjectInfoTable) throws Exception;
	  void associateEPSWithProject(ProjectEPSTable paramProjectEPSTable, ProjectInfoTable paramProjectInfoTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void deassociateProjectFromEPS(nomitech.common.db.local.ProjectInfoTable paramProjectInfoTable) throws Exception;
	  void deassociateProjectFromEPS(ProjectInfoTable paramProjectInfoTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: java.util.List<nomitech.common.db.local.ProjectInfoTable> loadProjectInfosWithUrls(System.Nullable<long>[] paramArrayOfLong) throws Exception;
	  IList<ProjectInfoTable> loadProjectInfosWithUrls(long?[] paramArrayOfLong);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: java.util.List<nomitech.common.db.local.ProjectInfoTable> loadProjectInfosWithEPS(System.Nullable<long>[] paramArrayOfLong) throws Exception;
	  IList<ProjectInfoTable> loadProjectInfosWithEPS(long?[] paramArrayOfLong);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: java.util.List<nomitech.common.db.local.ProjectInfoTable> findProjectInfosAndEPSsByQuery(String paramString) throws Exception;
	  IList<ProjectInfoTable> findProjectInfosAndEPSsByQuery(string paramString);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: java.util.List<nomitech.common.db.local.TakeoffConditionTable> findMapConditionsByQueryDeepCopy(String paramString) throws Exception;
	  IList<TakeoffConditionTable> findMapConditionsByQueryDeepCopy(string paramString);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateConditionWithLine(nomitech.common.db.local.TakeoffConditionTable paramTakeoffConditionTable, nomitech.common.db.local.TakeoffLineTable paramTakeoffLineTable) throws Exception;
	  void associateConditionWithLine(TakeoffConditionTable paramTakeoffConditionTable, TakeoffLineTable paramTakeoffLineTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateConditionWithArea(nomitech.common.db.local.TakeoffConditionTable paramTakeoffConditionTable, nomitech.common.db.local.TakeoffAreaTable paramTakeoffAreaTable) throws Exception;
	  void associateConditionWithArea(TakeoffConditionTable paramTakeoffConditionTable, TakeoffAreaTable paramTakeoffAreaTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateConditionWithPoint(nomitech.common.db.local.TakeoffConditionTable paramTakeoffConditionTable, nomitech.common.db.local.TakeoffPointTable paramTakeoffPointTable) throws Exception;
	  void associateConditionWithPoint(TakeoffConditionTable paramTakeoffConditionTable, TakeoffPointTable paramTakeoffPointTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateConditionWithLegend(nomitech.common.db.local.TakeoffConditionTable paramTakeoffConditionTable, nomitech.common.db.local.TakeoffLegendTable paramTakeoffLegendTable) throws Exception;
	  void associateConditionWithLegend(TakeoffConditionTable paramTakeoffConditionTable, TakeoffLegendTable paramTakeoffLegendTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void setElevationSamplesOfLine(nomitech.common.db.local.TakeoffLineTable paramTakeoffLineTable, java.util.List<nomitech.common.db.local.TakeoffPointTable> paramList) throws Exception;
	  void setElevationSamplesOfLine(TakeoffLineTable paramTakeoffLineTable, IList<TakeoffPointTable> paramList);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void setPolygonOfArea(nomitech.common.db.local.TakeoffAreaTable paramTakeoffAreaTable, java.util.List<nomitech.common.db.local.TakeoffPointTable> paramList) throws Exception;
	  void setPolygonOfArea(TakeoffAreaTable paramTakeoffAreaTable, IList<TakeoffPointTable> paramList);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void setTrianglesOfArea(nomitech.common.db.local.TakeoffAreaTable paramTakeoffAreaTable, java.util.List<nomitech.common.db.local.TakeoffTriangleTable> paramList) throws Exception;
	  void setTrianglesOfArea(TakeoffAreaTable paramTakeoffAreaTable, IList<TakeoffTriangleTable> paramList);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void removeElevationSamplesFromLine(nomitech.common.db.local.TakeoffLineTable paramTakeoffLineTable) throws Exception;
	  void removeElevationSamplesFromLine(TakeoffLineTable paramTakeoffLineTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void updateTakeoffPoints(java.util.List<nomitech.common.db.local.TakeoffPointTable> paramList) throws Exception;
	  void updateTakeoffPoints(IList<TakeoffPointTable> paramList);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void updateTakeoffTriangles(java.util.List<nomitech.common.db.local.TakeoffTriangleTable> paramList) throws Exception;
	  void updateTakeoffTriangles(IList<TakeoffTriangleTable> paramList);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateVariableWithTemplate(nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, nomitech.common.db.project.ProjectVariableTable paramProjectVariableTable) throws Exception;
	  void associateVariableWithTemplate(ProjectTemplateTable paramProjectTemplateTable, ProjectVariableTable paramProjectVariableTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void deassociateVariableFromTemplate(nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, nomitech.common.db.project.ProjectVariableTable paramProjectVariableTable) throws Exception;
	  void deassociateVariableFromTemplate(ProjectTemplateTable paramProjectTemplateTable, ProjectVariableTable paramProjectVariableTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateBuildUpColumnWithTemplate(nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, nomitech.common.db.project.RateBuildUpColumnsTable paramRateBuildUpColumnsTable) throws Exception;
	  void associateBuildUpColumnWithTemplate(ProjectTemplateTable paramProjectTemplateTable, RateBuildUpColumnsTable paramRateBuildUpColumnsTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void deassociateBuildUpColumnFromTemplate(nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, nomitech.common.db.project.RateBuildUpColumnsTable paramRateBuildUpColumnsTable) throws Exception;
	  void deassociateBuildUpColumnFromTemplate(ProjectTemplateTable paramProjectTemplateTable, RateBuildUpColumnsTable paramRateBuildUpColumnsTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateRateBuildUpWithTemplate(nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, nomitech.common.db.project.RateBuildUpTable paramRateBuildUpTable) throws Exception;
	  void associateRateBuildUpWithTemplate(ProjectTemplateTable paramProjectTemplateTable, RateBuildUpTable paramRateBuildUpTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void deassociateRateBuildUpFromTemplate(nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, nomitech.common.db.project.RateBuildUpTable paramRateBuildUpTable) throws Exception;
	  void deassociateRateBuildUpFromTemplate(ProjectTemplateTable paramProjectTemplateTable, RateBuildUpTable paramRateBuildUpTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void associateDistributorWithTemplate(nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, nomitech.common.db.project.RateDistributorTable paramRateDistributorTable) throws Exception;
	  void associateDistributorWithTemplate(ProjectTemplateTable paramProjectTemplateTable, RateDistributorTable paramRateDistributorTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void deassociateDistributorFromTemplate(nomitech.common.db.project.ProjectTemplateTable paramProjectTemplateTable, nomitech.common.db.project.RateDistributorTable paramRateDistributorTable) throws Exception;
	  void deassociateDistributorFromTemplate(ProjectTemplateTable paramProjectTemplateTable, RateDistributorTable paramRateDistributorTable);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: nomitech.common.db.project.ProjectExcelFile associateExcelFileWithTemplate(System.Nullable<long> paramLong1, System.Nullable<long> paramLong2) throws Exception;
	  ProjectExcelFile associateExcelFileWithTemplate(long? paramLong1, long? paramLong2);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: java.util.List<nomitech.common.db.util.HqlResultValue[]> executeHqlQuery(String paramString, java.util.List<nomitech.common.db.util.HqlParameterWithValue> paramList) throws Exception;
	  IList<HqlResultValue[]> executeHqlQuery(string paramString, IList<HqlParameterWithValue> paramList);

	  int DbmsType {get;}

	  bool UserLogEnabled {get;}

	  void setLocalConnection(string paramString1, string paramString2, string paramString3, int paramInt);
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\base\BaseDBUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}