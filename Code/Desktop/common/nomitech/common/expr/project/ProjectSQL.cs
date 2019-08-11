using System;
using System.Numerics;

namespace Desktop.common.nomitech.common.expr.project
{
	using BaseEntity = nomitech.common.@base.BaseEntity;
	using DummyExprArray = nomitech.common.expr.arrays.DummyExprArray;
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
	using Session = org.hibernate.Session;
	using SessionImplementor = org.hibernate.engine.SessionImplementor;
	using ClassMetadata = org.hibernate.metadata.ClassMetadata;

	public class ProjectSQL : AbstractFunction
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
		bool @bool;
		for (@bool = true; @bool < paramArrayOfExpr.Length; @bool++)
		{
		  if (paramArrayOfExpr[@bool] is ExprVariable)
		  {
			paramArrayOfExpr[@bool] = paramIEvaluationContext.evaluateVariable((ExprVariable)paramArrayOfExpr[@bool]);
		  }
		  if (!(paramArrayOfExpr[@bool] is ExprString) && !(paramArrayOfExpr[@bool] is org.boris.expr.ExprNumber) && !(paramArrayOfExpr[@bool] is ExprBoolean))
		  {
			throw new ExprException("Invalid Parameter Value: " + paramArrayOfExpr[@bool]);
		  }
		}
		@bool = true;
		Session session = null;
		ProjectDBUtil projectDBUtil = null;
		if (paramIEvaluationContext is ExprAbstractEvaluationContext)
		{
		  session = ((ExprAbstractEvaluationContext)paramIEvaluationContext).ProjectDatabaseSession;
		  if (session == null)
		  {
			projectDBUtil = ProjectDBUtil.currentProjectDBUtil();
			if (projectDBUtil == null)
			{
			  return new DummyExprArray();
			}
			@bool = projectDBUtil.hasOpenedSession();
			session = projectDBUtil.currentSession();
		  }
		}
		string[] arrayOfString = null;
		try
		{
		  Query query = session.createSQLQuery(str);
		  query.Cacheable = true;
		  for (sbyte b1 = 1; b1 < paramArrayOfExpr.Length; b1++)
		  {
			if (paramArrayOfExpr[b1] is ExprString)
			{
			  query = query.setString(b1 - true, ((ExprString)paramArrayOfExpr[b1]).str);
			}
			else if (paramArrayOfExpr[b1] is ExprDouble)
			{
			  query = query.setDouble(b1 - true, ((ExprDouble)paramArrayOfExpr[b1]).doubleValue());
			}
			else if (paramArrayOfExpr[b1] is ExprInteger)
			{
			  query = query.setInteger(b1 - true, ((ExprInteger)paramArrayOfExpr[b1]).intValue());
			}
			else if (paramArrayOfExpr[b1] is ExprBoolean)
			{
			  query = query.setBoolean(b1 - true, ((ExprBoolean)paramArrayOfExpr[b1]).booleanValue());
			}
		  }
		  System.Collections.IList list = query.list();
		  int i = 0;
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
		  ExprArray exprArray = new ExprArray(list.Count, i);
		  sbyte b2 = 0;
		  foreach (object @object in list)
		  {
			if (@object is object[])
			{
			  object[] arrayOfObject = (object[])@object;
			  for (sbyte b3 = 0; b3 < arrayOfObject.Length; b3++)
			  {
				setArrayValue(exprArray, arrayOfObject[b3], b2, b3);
			  }
			}
			else if (@object is BaseEntity)
			{
			  sbyte b3 = 0;
			  foreach (string str1 in arrayOfString)
			  {
				object object1 = BlankResourceInitializer.getFieldValue((BaseEntity)@object, str1);
				setArrayValue(exprArray, object1, b2, b3++);
			  }
			}
			else if (i == 1)
			{
			  setArrayValue(exprArray, @object, b2, 0);
			}
			else
			{
			  if (!@bool)
			  {
				projectDBUtil.closeSession();
			  }
			  throw new ExprException("Not a persistent class: " + @object.GetType().Name);
			}
			b2++;
		  }
		  if (projectDBUtil != null && !@bool)
		  {
			projectDBUtil.closeSession();
		  }
		  return exprArray;
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  if (!@bool)
		  {
			projectDBUtil.closeSession();
		  }
		  throw new ExprException(exception.Message);
		}
	  }

	  private void setArrayValue(ExprArray paramExprArray, object paramObject, int paramInt1, int paramInt2)
	  {
		if (paramObject == null)
		{
		  paramExprArray.set(paramInt1, paramInt2, new ExprString(""));
		}
		else if (paramObject is decimal)
		{
		  paramExprArray.set(paramInt1, paramInt2, new ExprDouble(((decimal)paramObject).doubleValue()));
		}
		else if (paramObject is BigInteger)
		{
		  paramExprArray.set(paramInt1, paramInt2, new ExprInteger(((BigInteger)paramObject).intValue()));
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
		else if (paramObject is Number)
		{
		  paramExprArray.set(paramInt1, paramInt2, new ExprDouble(((Number)paramObject).doubleValue()));
		}
		else if (paramObject is Date)
		{
		  paramExprArray.set(paramInt1, paramInt2, new ExprDouble(ExcelDate.toExcelDate(((Date)paramObject).Time)));
		}
		else if (paramObject is Number)
		{
		  paramExprArray.set(paramInt1, paramInt2, new ExprDouble(((Number)paramObject).doubleValue()));
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


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\project\ProjectSQL.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}