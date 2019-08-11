using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Desktop.common.nomitech.common.util
{
	using Currency = nomitech.common.currency.Currency;
	using GlobalCurrencyIntf = nomitech.common.currency.GlobalCurrencyIntf;
	using ExchangeRateTable = nomitech.common.db.project.ExchangeRateTable;
	using RawMaterialTable = nomitech.common.db.project.RawMaterialTable;
	using Query = org.hibernate.Query;
	using Session = org.hibernate.Session;

	public class ExchangeRateUtil
	{
	  private static GlobalCurrencyIntf s_interface;

	  private static IDictionary<string, decimal> s_exchangeRateCache = new ConcurrentDictionary();

	  public static GlobalCurrencyIntf GlobalCurrencyIntf
	  {
		  set
		  {
			  s_interface = value;
		  }
	  }

	  private static string constructKey(ProjectDBUtil paramProjectDBUtil, string paramString1, string paramString2, DateTime paramDate)
	  {
		if (paramDate == null)
		{
		  return paramProjectDBUtil.ProjectUrlId + "_" + paramString1 + "_" + paramString2 + "_null";
		}
		GregorianCalendar gregorianCalendar = new GregorianCalendar();
		gregorianCalendar.Time = paramDate;
		return paramProjectDBUtil.ProjectUrlId + "_" + paramString1 + "_" + paramString2 + "_" + gregorianCalendar.get(2) + "_" + gregorianCalendar.get(1);
	  }

	  public static void clearExchangeRatesCache()
	  {
		  s_exchangeRateCache.Clear();
	  }

	  public static decimal findExchangeRate(ProjectDBUtil paramProjectDBUtil, string paramString, DateTime paramDate)
	  {
		if (paramProjectDBUtil == null || StringUtils.isNullOrBlank(paramString))
		{
		  return BigDecimalMath.ONE;
		}
		Currency currency = s_interface.findCurrencyBySymbol(paramProjectDBUtil.Properties.getProperty("project.currency.symbol"));
		if (currency.Code.Equals(paramString))
		{
		  return BigDecimalMath.ONE;
		}
		string str = constructKey(paramProjectDBUtil, currency.Code, paramString, paramDate);
		decimal bigDecimal1 = (decimal)s_exchangeRateCache[str];
		if (bigDecimal1 != null)
		{
		  return bigDecimal1;
		}
		SimpleDateFormat simpleDateFormat = new SimpleDateFormat("MMM yyyy", Locale.ENGLISH);
		DateTime date1 = paramProjectDBUtil.Properties.getDateProperty("project.submission.date");
		int i = paramProjectDBUtil.Properties.getIntProperty("project.constructionduration");
		if (i <= 0)
		{
		  i = 1;
		}
		GregorianCalendar gregorianCalendar = new GregorianCalendar();
		gregorianCalendar.Time = date1;
		gregorianCalendar.set(5, 1);
		gregorianCalendar.set(11, 0);
		gregorianCalendar.set(12, 0);
		gregorianCalendar.set(13, 0);
		gregorianCalendar.set(14, 0);
		date1 = gregorianCalendar.Time;
		gregorianCalendar.add(2, i);
		DateTime date2 = gregorianCalendar.Time;
		bool @bool = !paramProjectDBUtil.hasOpenedSession() ? 1 : 0;
		Session session = paramProjectDBUtil.currentSession();
		Query query = session.createQuery("from ExchangeRateTable o where o.projectId = :prjId and (o.fromCurrency = :fromCurrency and o.toCurrency = :toCurrency and o.rateDate >= :startDate and o.rateDate <= :endDate) order by o.rateDate asc");
		query.setString("fromCurrency", paramString);
		query.setString("toCurrency", currency.Code);
		query.setDate("startDate", date1);
		query.setDate("endDate", date2);
		query.setLong("prjId", paramProjectDBUtil.ProjectUrlId.Value);
		query.Cacheable = true;
		System.Collections.IEnumerator iterator = query.list().GetEnumerator();
		decimal bigDecimal2 = BigDecimalMath.ONE;
		sbyte b;
		for (b = 0; iterator.MoveNext(); b++)
		{
		  ExchangeRateTable exchangeRateTable = (ExchangeRateTable)iterator.Current;
		  if (!b)
		  {
			bigDecimal2 = exchangeRateTable.Rate;
		  }
		  if (paramDate == null)
		  {
			bigDecimal1 = exchangeRateTable.Rate;
			break;
		  }
		  string str1 = simpleDateFormat.format(paramDate);
		  string str2 = simpleDateFormat.format(exchangeRateTable.RateDate);
		  if (str1.Equals(str2))
		  {
			bigDecimal1 = exchangeRateTable.Rate;
			break;
		  }
		}
		if (@bool)
		{
		  paramProjectDBUtil.closeSession();
		}
		if (bigDecimal1 == null)
		{
		  bigDecimal1 = bigDecimal2;
		}
		s_exchangeRateCache[str] = bigDecimal1;
		return bigDecimal1;
	  }

	  public static decimal findExchangeRate(ProjectDBUtil paramProjectDBUtil, string paramString1, string paramString2, DateTime paramDate)
	  {
		if (paramProjectDBUtil == null || StringUtils.isNullOrBlank(paramString1) || StringUtils.isNullOrBlank(paramString2) || paramString1.Equals(paramString2))
		{
		  return BigDecimalMath.ONE;
		}
		string str = constructKey(paramProjectDBUtil, paramString1, paramString2, paramDate);
		decimal bigDecimal1 = (decimal)s_exchangeRateCache[str];
		if (bigDecimal1 != null)
		{
		  return bigDecimal1;
		}
		bool @bool = !paramProjectDBUtil.hasOpenedSession() ? 1 : 0;
		SimpleDateFormat simpleDateFormat = new SimpleDateFormat("MMM yyyy", Locale.ENGLISH);
		DateTime date1 = paramProjectDBUtil.Properties.getDateProperty("project.submission.date");
		int i = paramProjectDBUtil.Properties.getIntProperty("project.constructionduration");
		if (i <= 0)
		{
		  i = 1;
		}
		GregorianCalendar gregorianCalendar = new GregorianCalendar();
		if (date1 == null)
		{
		  date1 = gregorianCalendar.Time;
		}
		gregorianCalendar.Time = date1;
		gregorianCalendar.set(5, 1);
		gregorianCalendar.set(11, 0);
		gregorianCalendar.set(12, 0);
		gregorianCalendar.set(13, 0);
		gregorianCalendar.set(14, 0);
		date1 = gregorianCalendar.Time;
		gregorianCalendar.add(2, i);
		DateTime date2 = gregorianCalendar.Time;
		Session session = paramProjectDBUtil.currentSession();
		Query query = session.createQuery("from ExchangeRateTable o where o.projectId = :prjId and (o.fromCurrency = :fromCurrency and o.toCurrency = :toCurrency and o.rateDate >= :startDate and o.rateDate <= :endDate) order by o.rateDate asc");
		query.setString("fromCurrency", paramString2);
		query.setString("toCurrency", paramString1);
		query.setDate("startDate", date1);
		query.setDate("endDate", date2);
		query.setLong("prjId", paramProjectDBUtil.ProjectUrlId.Value);
		query.Cacheable = true;
		System.Collections.IEnumerator iterator = query.list().GetEnumerator();
		decimal bigDecimal2 = BigDecimalMath.ONE;
		sbyte b;
		for (b = 0; iterator.MoveNext(); b++)
		{
		  ExchangeRateTable exchangeRateTable = (ExchangeRateTable)iterator.Current;
		  if (!b)
		  {
			bigDecimal2 = exchangeRateTable.Rate;
		  }
		  if (paramDate == null)
		  {
			bigDecimal1 = exchangeRateTable.Rate;
			break;
		  }
		  string str1 = simpleDateFormat.format(paramDate);
		  string str2 = simpleDateFormat.format(exchangeRateTable.RateDate);
		  if (str1.Equals(str2))
		  {
			bigDecimal1 = exchangeRateTable.Rate;
			break;
		  }
		}
		if (@bool)
		{
		  paramProjectDBUtil.closeSession();
		}
		if (bigDecimal1 == null)
		{
		  bigDecimal1 = bigDecimal2;
		}
		s_exchangeRateCache[str] = bigDecimal1;
		return bigDecimal1;
	  }

	  public static decimal findRawMaterialRate(ProjectDBUtil paramProjectDBUtil, string paramString, DateTime paramDate)
	  {
		if (paramProjectDBUtil == null || StringUtils.isNullOrBlank(paramString))
		{
		  return BigDecimalMath.ZERO;
		}
		bool @bool = !paramProjectDBUtil.hasOpenedSession() ? 1 : 0;
		SimpleDateFormat simpleDateFormat = new SimpleDateFormat("MMM yyyy", Locale.ENGLISH);
		DateTime date1 = paramProjectDBUtil.Properties.getDateProperty("project.submission.date");
		int i = paramProjectDBUtil.Properties.getIntProperty("project.constructionduration");
		if (i <= 0)
		{
		  i = 1;
		}
		GregorianCalendar gregorianCalendar = new GregorianCalendar();
		gregorianCalendar.Time = date1;
		gregorianCalendar.set(5, 1);
		gregorianCalendar.set(11, 0);
		gregorianCalendar.set(12, 0);
		gregorianCalendar.set(13, 0);
		gregorianCalendar.set(14, 0);
		date1 = gregorianCalendar.Time;
		gregorianCalendar.add(2, i);
		DateTime date2 = gregorianCalendar.Time;
		Session session = paramProjectDBUtil.currentSession();
		Query query = session.createQuery("from RawMaterialTable o where o.projectId = " + paramProjectDBUtil.ProjectUrlId + " and (o.code = :code and o.rateDate >= :startDate and o.rateDate <= :endDate) order by o.rateDate asc");
		query.setString("code", paramString);
		query.setDate("startDate", date1);
		query.setDate("endDate", date2);
		query.Cacheable = true;
		System.Collections.IEnumerator iterator = query.list().GetEnumerator();
		decimal bigDecimal1 = BigDecimalMath.ZERO;
		decimal bigDecimal2 = null;
		sbyte b;
		for (b = 0; iterator.MoveNext(); b++)
		{
		  RawMaterialTable rawMaterialTable = (RawMaterialTable)iterator.Current;
		  if (!b)
		  {
			bigDecimal1 = rawMaterialTable.Rate;
		  }
		  if (paramDate == null)
		  {
			bigDecimal2 = rawMaterialTable.Rate;
			break;
		  }
		  string str1 = simpleDateFormat.format(paramDate);
		  string str2 = simpleDateFormat.format(rawMaterialTable.RateDate);
		  if (str1.Equals(str2))
		  {
			bigDecimal2 = rawMaterialTable.Rate;
			break;
		  }
		}
		if (@bool)
		{
		  paramProjectDBUtil.closeSession();
		}
		if (bigDecimal2 == null)
		{
		  bigDecimal2 = bigDecimal1;
		}
		return bigDecimal2;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\ExchangeRateUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}