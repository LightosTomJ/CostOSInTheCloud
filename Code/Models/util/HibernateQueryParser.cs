using System;
using System.Collections.Generic;
using System.Text;

namespace Models.util
{

	using DatabaseTableDefinition = nomitech.common.data.definition.DatabaseTableDefinition;
	using GroupTableDefinition = nomitech.common.data.definition.GroupTableDefinition;
	using ResourceTableDefinition = nomitech.common.data.definition.ResourceTableDefinition;
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using StringUtils = nomitech.common.util.StringUtils;

	using Term = org.apache.lucene.index.Term;
	using BooleanClause = org.apache.lucene.search.BooleanClause;
	using BooleanQuery = org.apache.lucene.search.BooleanQuery;
	using PhraseQuery = org.apache.lucene.search.PhraseQuery;
	using PrefixQuery = org.apache.lucene.search.PrefixQuery;
	using Query = org.apache.lucene.search.Query;
	using TermQuery = org.apache.lucene.search.TermQuery;
	using Criteria = org.hibernate.Criteria;
	using Session = org.hibernate.Session;
	using Criterion = org.hibernate.criterion.Criterion;
	using MatchMode = org.hibernate.criterion.MatchMode;
	using Restrictions = org.hibernate.criterion.Restrictions;

	public class HibernateQueryParser
	{

	//	private DatabaseTableDefinition tableDefinition = null;
		private Query query;
		private Type tableClass = null;
		private Session session;
		private int dbmsType;
		//	private Map<BooleanClause,List<Restrictions>> clauseMap = new HashMap<BooleanClause,List<Restrictions>>();


//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public HibernateQueryParser(Class cls, org.hibernate.Session session,org.apache.lucene.search.Query query, int dbmsType) throws Exception
		public HibernateQueryParser(Type cls, Session session, Query query, int dbmsType)
		{
	//		this.tableDefinition = null;
			this.tableClass = cls;
			this.query = query;
			this.session = session;
			this.dbmsType = dbmsType;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private org.hibernate.Criteria parse() throws Exception
		private Criteria parse()
		{
			Criteria criteria = session.createCriteria(tableClass);
			Criterion criterion = null;
			Query q = query;

			if (q is TermQuery)
			{
				criterion = createTermCriterion((TermQuery) q);
			}
			else if (q is PrefixQuery)
			{
				criterion = createPrefixCriterion((PrefixQuery)q);
			}
			else if (q is BooleanQuery)
			{
				criterion = createBooleanCriterion((BooleanQuery) q);
			}
			else if (q is PhraseQuery)
			{
				criterion = createPhraseCriterion((PhraseQuery) q);
			}
			else
			{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
				Console.WriteLine("Inner Query : " + q.GetType().FullName);
			}

			if (criterion != null)
			{
				criteria.add(criterion);
			}

			return criteria;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private org.hibernate.criterion.Criterion createTermCriterion(org.apache.lucene.search.TermQuery termQuery) throws Exception
		private Criterion createTermCriterion(TermQuery termQuery)
		{
			Term term = termQuery.Term;
			string fieldName = term.field();
			Type clz = null;
	//		if ( tableDefinition != null ) {
	//			clz = tableDefinition.fieldNameToClass(fieldName);
	//			if ( clz == null )
	//				throw new Exception("Invalid field name: "+fieldName);
	//		}
	//		else {
				clz = typeof(string);
	//		}
			Criterion crit = null;
			//		System.out.println("TERM "+fieldName+" = "+term.text()+" + "+cls);

			if (clz.Equals(typeof(string)))
			{
				//crit = Restrictions.like(fieldName, "%"+term.text()+"%");	
				//			if ( fieldName.equals("title")  )
				//				crit = Restrictions.sqlRestriction("TITLE like '%"+term.text()+"%'");
				//			else
				//crit = Restrictions.ilike(fieldName, "%"+term.text()+"%");
				if (dbmsType != ProjectServerDBUtil.SQLSERVER_DBMS)
				{
					crit = Restrictions.ilike(fieldName, term.text(), MatchMode.ANYWHERE);
				}
				else
				{
					crit = Restrictions.like(fieldName, "%" + term.text() + "%");
				}
			}
			else if (clz.Equals(typeof(decimal)))
			{
				if (!StringUtils.isDecimal(term.text()))
				{
					return null;
				}
				crit = Restrictions.eq(fieldName, new BigDecimalFixed(term.text()));
			}
			else if (clz.Equals(typeof(Long)))
			{
				if (!StringUtils.isDecimal(term.text()))
				{
					return null;
				}
				crit = Restrictions.eq(fieldName, new long?(term.text()));
			}
			else if (clz.Equals(typeof(Boolean)))
			{
				if (!StringUtils.isBoolean(term.text().ToLower()))
				{
					return null;
				}
				crit = Restrictions.eq(fieldName, new bool?(term.text().ToLower()));
			}
			else
			{
				return null;
			}

			return crit;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private org.hibernate.criterion.Criterion createPrefixCriterion(org.apache.lucene.search.PrefixQuery termQuery) throws Exception
		private Criterion createPrefixCriterion(PrefixQuery termQuery)
		{
			Term term = termQuery.Prefix;
			string fieldName = term.field();
			Type cls = typeof(string); // tableDefinition.fieldNameToClass(fieldName);
			if (cls == null)
			{
				throw new Exception("Invalid field name: " + fieldName);
			}

			Criterion crit = null;
			//		System.out.println("PREFIX "+fieldName+" = "+term.text());
			//		System.out.println("PREFIX "+fieldName+" = "+term.text()+" + "+cls);

			if (cls.Equals(typeof(string)))
			{
				//			if ( fieldName.equals("title")  )
				//				crit = Restrictions.sqlRestriction("TITLE like '%"+term.text()+"%'");
				//			else
				crit = Restrictions.ilike(fieldName, "%" + term.text() + "%");
			}
			else if (cls.Equals(typeof(decimal)))
			{
				if (!StringUtils.isDecimal(term.text()))
				{
					return null;
				}
				crit = Restrictions.eq(fieldName, new BigDecimalFixed(term.text()));
			}
			else if (cls.Equals(typeof(Long)))
			{
				if (!StringUtils.isDecimal(term.text()))
				{
					return null;
				}
				crit = Restrictions.eq(fieldName, new long?(term.text()));
			}
			else if (cls.Equals(typeof(Boolean)))
			{
				if (!StringUtils.isBoolean(term.text().ToLower()))
				{
					return null;
				}
				crit = Restrictions.eq(fieldName, new bool?(term.text().ToLower()));
			}
			else
			{
				return null;
			}

			return crit;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private org.hibernate.criterion.Criterion createPhraseCriterion(org.apache.lucene.search.PhraseQuery phraseQuery) throws Exception
		private Criterion createPhraseCriterion(PhraseQuery phraseQuery)
		{
			Term[] terms = phraseQuery.Terms;
			//String field = null;
			Criterion prevCriterion = null;
			Criterion result = null;
			IDictionary<string, StringBuilder> fieldToQueryMap = new Dictionary<string, StringBuilder>();

			foreach (Term term in terms)
			{
				StringBuilder q = fieldToQueryMap[term.field()];

				if (q == null)
				{
					q = new StringBuilder();
					fieldToQueryMap[term.field()] = q;
				}

				if (q.Length != 0)
				{
					q.Append(" ");
				}
				q.Append(term.text());
				//			Criterion current = createTermCriterion(new TermQuery(term));
				//			
				//			if ( prevCriterion != null ) {
				//				prevCriterion = Restrictions.and(prevCriterion, current);
				//			}
				//			else {
				//				prevCriterion = current;
				//			}
			}

			foreach (string key in fieldToQueryMap.Keys)
			{
				string txt = fieldToQueryMap[key].ToString();
				Criterion current = createTermCriterion(new TermQuery(new Term(key, txt)));
				if (prevCriterion != null)
				{
					prevCriterion = Restrictions.and(prevCriterion, current);
				}
				else
				{
					prevCriterion = current;
				}
			}

			//		System.out.println("PHRASE IS: or "+phraseQuery.toString());		
			return prevCriterion;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private org.hibernate.criterion.Criterion createBooleanCriterion(org.apache.lucene.search.BooleanQuery bq) throws Exception
		private Criterion createBooleanCriterion(BooleanQuery bq)
		{
			BooleanClause[] clauses = bq.Clauses;

			Criterion prevCriterion = null;
			Criterion result = null;
			foreach (BooleanClause clause in clauses)
			{
				Query q = clause.Query;

				Criterion criterion = null;

				if (q is TermQuery)
				{
					criterion = createTermCriterion((TermQuery) q);
				}
				else if (q is PrefixQuery)
				{
					criterion = createPrefixCriterion((PrefixQuery)q);
				}
				else if (q is BooleanQuery)
				{
					criterion = createBooleanCriterion((BooleanQuery) q);
				}
				else if (q is PhraseQuery)
				{
					criterion = createPhraseCriterion((PhraseQuery) q);
				}
				else
				{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
					Console.WriteLine("Missed In-Inner Query : " + q.GetType().FullName);
					continue;
				}

				if (clause.Occur.Equals(BooleanClause.Occur.MUST_NOT))
				{
					criterion = Restrictions.not(criterion);
				}
				else if (prevCriterion != null)
				{
					if (clause.Occur.Equals(BooleanClause.Occur.MUST))
					{
						result = Restrictions.and(prevCriterion, criterion);
						criterion = result;
					}
					else if (clause.Occur.Equals(BooleanClause.Occur.SHOULD))
					{
						result = Restrictions.or(prevCriterion, criterion);
						criterion = result;
					}
				}

				//			System.out.println("MUST: " +clause.getOccur().equals(BooleanClause.Occur.MUST)); // AND
				//			System.out.println("SHOULD: " +clause.getOccur().equals(BooleanClause.Occur.SHOULD)); // OR
				//			System.out.println("MUST NOT: " +clause.getOccur().equals(BooleanClause.Occur.MUST_NOT)); // NOT

				prevCriterion = criterion;
			}

			if (result == null)
			{
				result = prevCriterion;
			}

			return result;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static org.hibernate.Criteria parseQuery(Class tableCls, org.hibernate.Session session, org.apache.lucene.search.Query query, int dbmsType) throws Exception
		public static Criteria parseQuery(Type tableCls, Session session, Query query, int dbmsType)
		{
			HibernateQueryParser parser = new HibernateQueryParser(tableCls,session,query, dbmsType);
			return parser.parse();
		}
	}

}