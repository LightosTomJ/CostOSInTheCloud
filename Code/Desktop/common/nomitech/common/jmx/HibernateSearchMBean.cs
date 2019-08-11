using System;

namespace Desktop.common.nomitech.common.jmx
{
	using SessionFactory = org.hibernate.SessionFactory;
	using Configuration = org.hibernate.cfg.Configuration;
	using ServiceMBean = org.jboss.system.ServiceMBean;

	public interface HibernateSearchMBean : ServiceMBean, MBeanRegistration
	{
	  URL HarUrl {get;}

	  bool ScanForMappingsEnabled {get;set;}


	  string SessionFactoryName {get;set;}


	  ObjectName DeployedTreeCacheObjectName {get;set;}


	  ObjectName StatisticsServiceName {get;}

	  string Dialect {get;set;}


	  string Hbm2ddlAuto {get;set;}


	  string DatasourceName {get;set;}


	  string Username {get;set;}


	  string Password {set;}

	  bool? SqlCommentsEnabled {get;set;}


	  string DefaultSchema {get;set;}


	  string DefaultCatalog {get;set;}


	  int? MaxFetchDepth {get;set;}


	  int? JdbcBatchSize {get;set;}


	  int? JdbcFetchSize {get;set;}


	  bool? JdbcScrollableResultSetEnabled {get;set;}


	  bool? GetGeneratedKeysEnabled {get;set;}


	  bool? BatchVersionedDataEnabled {get;set;}


	  bool? StreamsForBinaryEnabled {get;set;}


	  string QuerySubstitutions {get;set;}


	  string CacheProviderClass {get;set;}


	  string CacheRegionPrefix {get;set;}


	  bool? MinimalPutsEnabled {get;set;}


	  bool? UseStructuredCacheEntriesEnabled {get;set;}


	  bool? SecondLevelCacheEnabled {get;set;}


	  bool? QueryCacheEnabled {get;set;}


	  bool? ShowSqlEnabled {get;set;}


	  bool? ReflectionOptimizationEnabled {get;set;}


	  bool? StatGenerationEnabled {get;set;}


	  string SessionFactoryInterceptor {get;set;}


	  string ListenerInjector {get;set;}


	  bool Dirty {get;}

	  bool SessionFactoryRunning {get;}

	  string Version {get;}

	  SessionFactory Instance {get;}

	  Configuration Configuration {get;}

	  DateTime RunningSince {get;}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void createSchema() throws Exception;
	  void createSchema();

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void dropSchema() throws Exception;
	  void dropSchema();

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void rebuildSessionFactory() throws Exception;
	  void rebuildSessionFactory();
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\jmx\HibernateSearchMBean.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}