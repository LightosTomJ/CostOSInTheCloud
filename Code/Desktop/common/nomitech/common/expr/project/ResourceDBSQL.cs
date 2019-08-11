using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.expr.project
{
	using BaseEntity = nomitech.common.@base.BaseEntity;
	using HqlParameterWithValue = nomitech.common.db.util.HqlParameterWithValue;
	using HqlResultValue = nomitech.common.db.util.HqlResultValue;
	using BlankResourceInitializer = nomitech.common.expr.boqitem.BlankResourceInitializer;
	using StringUtils = nomitech.common.util.StringUtils;
	using Expr = org.boris.expr.Expr;
	using ExprArray = org.boris.expr.ExprArray;
	using ExprBoolean = org.boris.expr.ExprBoolean;
	using ExprDouble = org.boris.expr.ExprDouble;
	using ExprException = org.boris.expr.ExprException;
	using ExprInteger = org.boris.expr.ExprInteger;
	using ExprString = org.boris.expr.ExprString;
	using ExprVariable = org.boris.expr.ExprVariable;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;
	using ExcelDate = org.boris.expr.util.ExcelDate;
	using Query = org.hibernate.Query;
	using SQLQuery = org.hibernate.SQLQuery;
	using Session = org.hibernate.Session;
	using SessionImplementor = org.hibernate.engine.SessionImplementor;
	using ClassMetadata = org.hibernate.metadata.ClassMetadata;

	public class ResourceDBSQL : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertMinArgCount(paramArrayOfExpr, 1);
		for (sbyte b = 0; b < paramArrayOfExpr.Length; b++)
		{
		  if (paramArrayOfExpr[b] is org.boris.expr.ExprEvaluatable)
		  {
			paramArrayOfExpr[b] = evalArg(paramIEvaluationContext, paramArrayOfExpr[b]);
		  }
		}
		if (!(paramArrayOfExpr[0] is ExprString))
		{
		  throw new ExprException("Input " + paramArrayOfExpr[0].ToString() + " is not a String.");
		}
		string str = ((ExprString)paramArrayOfExpr[0]).str;
		bool bool1;
		for (bool1 = true; bool1 < paramArrayOfExpr.Length; bool1++)
		{
		  if (paramArrayOfExpr[bool1] is ExprVariable)
		  {
			paramArrayOfExpr[bool1] = paramIEvaluationContext.evaluateVariable((ExprVariable)paramArrayOfExpr[bool1]);
		  }
		  if (!(paramArrayOfExpr[bool1] is ExprString) && !(paramArrayOfExpr[bool1] is org.boris.expr.ExprNumber) && !(paramArrayOfExpr[bool1] is ExprBoolean))
		  {
			throw new ExprException("Invalid Parameter Value: " + paramArrayOfExpr[bool1]);
		  }
		}
		bool1 = true;
		Session session = null;
		bool bool2 = true;
		if (paramIEvaluationContext is ExprAbstractEvaluationContext)
		{
		  session = ((ExprAbstractEvaluationContext)paramIEvaluationContext).MasterDatabaseSession;
		  if (session == null)
		  {
			bool1 = DatabaseDBUtil.hasOpenedSession();
			session = DatabaseDBUtil.currentSession();
			bool2 = DatabaseDBUtil.LocalCommunication;
		  }
		}
		string[] arrayOfString = null;
		int i = 0;
		try
		{
		  SQLQuery sQLQuery = null;
		  System.Collections.IList list = Collections.EMPTY_LIST;
		  if (bool2)
		  {
			Query query;
			sQLQuery = session.createSQLQuery(str);
			sQLQuery.Cacheable = true;
			for (sbyte b2 = 1; b2 < paramArrayOfExpr.Length; b2++)
			{
			  if (paramArrayOfExpr[b2] is ExprString)
			  {
				query = sQLQuery.setString(b2 - true, ((ExprString)paramArrayOfExpr[b2]).str);
			  }
			  else if (paramArrayOfExpr[b2] is ExprDouble)
			  {
				query = query.setDouble(b2 - true, ((ExprDouble)paramArrayOfExpr[b2]).doubleValue());
			  }
			  else if (paramArrayOfExpr[b2] is ExprInteger)
			  {
				query = query.setInteger(b2 - true, ((ExprInteger)paramArrayOfExpr[b2]).intValue());
			  }
			  else if (paramArrayOfExpr[b2] is ExprBoolean)
			  {
				query = query.setBoolean(b2 - true, ((ExprBoolean)paramArrayOfExpr[b2]).booleanValue());
			  }
			}
			list = query.list();
			if (list.Count != 0)
			{
			  object @object = list[0];
			  if (@object is BaseEntity)
			  {
				ClassMetadata classMetadata = ((SessionImplementor)session).Factory.getClassMetadata(@object.GetType());
				arrayOfString = classMetadata.PropertyNames;
				if (arrayOfString == null)
				{
				  throw new Exception("Invalid class name: " + @object.GetType());
				}
				i = arrayOfString.Length;
			  }
			  else if (@object is object[])
			  {
				i = (object[])@object.length;
			  }
			  else
			  {
				i = 1;
			  }
			}
		  }
		  else
		  {
			List<object> arrayList = new List<object>();
			for (sbyte b2 = 1; b2 < paramArrayOfExpr.Length; b2++)
			{
			  if (paramArrayOfExpr[b2] is ExprString)
			  {
				arrayList.Add(new HqlParameterWithValue(b2 - true, ((ExprString)paramArrayOfExpr[b2]).str));
			  }
			  else if (paramArrayOfExpr[b2] is ExprDouble)
			  {
				arrayList.Add(new HqlParameterWithValue(b2 - true, Convert.ToDouble(((ExprDouble)paramArrayOfExpr[b2]).doubleValue())));
			  }
			  else if (paramArrayOfExpr[b2] is ExprInteger)
			  {
				arrayList.Add(new HqlParameterWithValue(b2 - true, new long?(((ExprInteger)paramArrayOfExpr[b2]).intValue())));
			  }
			  else if (paramArrayOfExpr[b2] is ExprBoolean)
			  {
				arrayList.Add(new HqlParameterWithValue(b2 - true, "" + ((ExprBoolean)paramArrayOfExpr[b2]).booleanValue()));
			  }
			}
			throw new System.ArgumentException("not implemented as a web service");
		  }
		  ExprArray exprArray = new ExprArray(list.Count, i);
		  sbyte b1 = 0;
		  foreach (object @object in list)
		  {
			if (@object is HqlResultValue[])
			{
			  HqlResultValue[] arrayOfHqlResultValue = (HqlResultValue[])@object;
			  for (sbyte b2 = 0; b2 < arrayOfHqlResultValue.Length; b2++)
			  {
				setArrayValue(exprArray, arrayOfHqlResultValue[b2], b1, b2);
			  }
			}
			else if (@object is object[])
			{
			  object[] arrayOfObject = (object[])@object;
			  for (sbyte b2 = 0; b2 < arrayOfObject.Length; b2++)
			  {
				setArrayValue(exprArray, arrayOfObject[b2], b1, b2);
			  }
			}
			else if (@object is BaseEntity)
			{
			  sbyte b2 = 0;
			  foreach (string str1 in arrayOfString)
			  {
				object object1 = BlankResourceInitializer.getFieldValue((BaseEntity)@object, str1);
				setArrayValue(exprArray, object1, b1, b2++);
			  }
			}
			else if (i == 1)
			{
			  setArrayValue(exprArray, @object, b1, 0);
			}
			else
			{
			  if (!bool1)
			  {
				DatabaseDBUtil.closeSession();
			  }
			  throw new ExprException("Not a persistent class: " + @object.GetType().Name);
			}
			b1++;
		  }
		  if (!bool1)
		  {
			DatabaseDBUtil.closeSession();
		  }
		  return exprArray;
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  if (!bool1)
		  {
			DatabaseDBUtil.closeSession();
		  }
		  throw new ExprException(exception.Message);
		}
	  }

	  private void setArrayValue(ExprArray paramExprArray, object paramObject, int paramInt1, int paramInt2)
	  {
		if (paramObject == null)
		{
		  paramExprArray.set(paramInt1, paramInt2, new ExprString("-"));
		}
		else if (paramObject is HqlResultValue)
		{
		  HqlResultValue hqlResultValue = (HqlResultValue)paramObject;
		  if (!string.ReferenceEquals(hqlResultValue.StringValue, null))
		  {
			paramExprArray.set(paramInt1, paramInt2, new ExprString(hqlResultValue.StringValue));
		  }
		  else if (hqlResultValue.DecimalValue != null)
		  {
			paramExprArray.set(paramInt1, paramInt2, new ExprDouble(hqlResultValue.DecimalValue.doubleValue()));
		  }
		  else if (hqlResultValue.LongValue != null)
		  {
			paramExprArray.set(paramInt1, paramInt2, new ExprInteger(hqlResultValue.LongValue.Value));
		  }
		  else if (hqlResultValue.BooleanValue != null)
		  {
			paramExprArray.set(paramInt1, paramInt2, new ExprBoolean(hqlResultValue.BooleanValue.Value));
		  }
		  else if (hqlResultValue.DateValue != null)
		  {
			paramExprArray.set(paramInt1, paramInt2, new ExprDouble(ExcelDate.toExcelDate(hqlResultValue.DateValue.Ticks)));
		  }
		}
		else if (paramObject is decimal)
		{
		  paramExprArray.set(paramInt1, paramInt2, new ExprDouble(((decimal)paramObject).doubleValue()));
		}
		else if (paramObject is string)
		{
		  paramExprArray.set(paramInt1, paramInt2, new ExprString(paramObject.ToString()));
		}
		else if (paramObject is bool?)
		{
		  paramExprArray.set(paramInt1, paramInt2, new ExprBoolean(((bool?)paramObject).Value));
		}
		else if (paramObject is long?)
		{
		  paramExprArray.set(paramInt1, paramInt2, new ExprInteger(((long?)paramObject).Value));
		}
		else if (paramObject is int?)
		{
		  paramExprArray.set(paramInt1, paramInt2, new ExprInteger(((int?)paramObject).Value));
		}
		else if (paramObject is double?)
		{
		  paramExprArray.set(paramInt1, paramInt2, new ExprDouble(((double?)paramObject).Value));
		}
		else if (paramObject is Number)
		{
		  paramExprArray.set(paramInt1, paramInt2, new ExprDouble(((Number)paramObject).doubleValue()));
		}
		else if (paramObject is Date)
		{
		  paramExprArray.set(paramInt1, paramInt2, new ExprDouble(ExcelDate.toExcelDate(((Date)paramObject).Time)));
		}
		else if (paramObject is Clob)
		{
		  Clob clob = (Clob)paramObject;
		  paramExprArray.set(paramInt1, paramInt2, new ExprString(StringUtils.clobToString((Clob)paramObject)));
		}
		else
		{
		  paramExprArray.set(paramInt1, paramInt2, new ExprString(paramObject.ToString()));
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\project\ResourceDBSQL.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}