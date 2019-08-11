using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.expr.arrays
{
	using StringUtils = nomitech.common.util.StringUtils;
	using Expr = org.boris.expr.Expr;
	using ExprArray = org.boris.expr.ExprArray;
	using ExprDouble = org.boris.expr.ExprDouble;
	using ExprEvaluatable = org.boris.expr.ExprEvaluatable;
	using ExprException = org.boris.expr.ExprException;
	using ExprInteger = org.boris.expr.ExprInteger;
	using ExprNumber = org.boris.expr.ExprNumber;
	using ExprString = org.boris.expr.ExprString;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using NativeArray = org.mozilla.javascript.NativeArray;
	using NativeJavaObject = org.mozilla.javascript.NativeJavaObject;

	public class ExprArrayUtil
	{
	  public static object[][] toObjectArray(ExprArray paramExprArray)
	  {
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: object[][] arrayOfObject = new object[paramExprArray.rows()][paramExprArray.columns()];
		object[][] arrayOfObject = RectangularArrays.RectangularObjectArray(paramExprArray.rows(), paramExprArray.columns());
		for (sbyte b = 0; b < paramExprArray.rows(); b++)
		{
		  for (sbyte b1 = 0; b1 < paramExprArray.columns(); b1++)
		  {
			Expr expr = paramExprArray.get(b, b1);
			if (expr is org.boris.expr.ExprBoolean)
			{
			  arrayOfObject[b][b1] = Convert.ToDouble(((ExprNumber)expr).doubleValue());
			}
			else if (expr is ExprInteger)
			{
			  arrayOfObject[b][b1] = Convert.ToInt32(((ExprNumber)expr).intValue());
			}
			else if (expr is ExprNumber)
			{
			  arrayOfObject[b][b1] = Convert.ToDouble(((ExprNumber)expr).doubleValue());
			}
			else if (expr == null)
			{
			  arrayOfObject[b][b1] = "";
			}
			else
			{
			  arrayOfObject[b][b1] = expr.ToString();
			}
		  }
		}
		return arrayOfObject;
	  }

	  public static Expr toExprArray(NativeArray paramNativeArray)
	  {
		List<object> arrayList = new List<object>();
		int i = 1;
		bool @bool = false;
		foreach (object @object in paramNativeArray.Ids)
		{
		  int j = ((int?)@object).Value;
		  @object = paramNativeArray.get(j, null);
		  if (@object is NativeArray)
		  {
			@bool = true;
			List<object> arrayList1 = new List<object>();
			foreach (object object1 in ((NativeArray)@object).Ids)
			{
			  int k = ((int?)object1).Value;
			  object1 = ((NativeArray)@object).get(k, null);
			  arrayList1.Add(object1);
			}
			if (i == 1 && arrayList1.Count != 0)
			{
			  i = arrayList1.Count;
			}
			arrayList.Add(arrayList1);
		  }
		  else
		  {
			arrayList.Add(@object);
		  }
		}
		ExprArray exprArray = new ExprArray(arrayList.Count, i);
		if (!@bool)
		{
		  for (sbyte b = 0; b < arrayList.Count; b++)
		  {
			object @object = arrayList[b];
			ExprString exprString = null;
			if (@object is double?)
			{
			  exprString = new ExprDouble(((double?)@object).Value);
			}
			else if (@object is int?)
			{
			  ExprInteger exprInteger = new ExprInteger(((int?)@object).Value);
			}
			else if (StringUtils.isDecimal(@object.ToString()))
			{
			  exprString = new ExprDouble((Convert.ToDouble(@object.ToString())));
			}
			else if (@object is NativeJavaObject)
			{
			  object object1 = ((NativeJavaObject)@object).getDefaultValue(typeof(string));
			  if (StringUtils.isDecimal(object1.ToString()))
			  {
				exprString = new ExprDouble((Convert.ToDouble(object1.ToString())));
			  }
			  else
			  {
				ExprString exprString1 = new ExprString(object1.ToString());
			  }
			}
			else
			{
			  exprString = new ExprString(@object.ToString());
			}
			exprArray.set(b, exprString);
		  }
		}
		else
		{
		  for (sbyte b = 0; b < arrayList.Count; b++)
		  {
			System.Collections.IList list = (System.Collections.IList)arrayList[b];
			for (sbyte b1 = 0; b1 < list.Count; b1++)
			{
			  object @object = list[b1];
			  ExprString exprString = null;
			  if (@object is double?)
			  {
				exprString = new ExprDouble(((double?)@object).Value);
			  }
			  else if (@object is int?)
			  {
				ExprInteger exprInteger = new ExprInteger(((int?)@object).Value);
			  }
			  else if (StringUtils.isDecimal(@object.ToString()))
			  {
				exprString = new ExprDouble((Convert.ToDouble(@object.ToString())));
			  }
			  else if (@object is NativeJavaObject)
			  {
				object object1 = ((NativeJavaObject)@object).getDefaultValue(typeof(string));
				if (StringUtils.isDecimal(object1.ToString()))
				{
				  exprString = new ExprDouble((Convert.ToDouble(object1.ToString())));
				}
				else
				{
				  ExprString exprString1 = new ExprString(object1.ToString());
				}
			  }
			  else
			  {
				exprString = new ExprString(@object.ToString());
			  }
			  exprArray.set(b, b1, exprString);
			}
		  }
		}
		return exprArray;
	  }

	  public static Expr toExprArray(object[] paramArrayOfObject)
	  {
		List<object> arrayList = new List<object>();
		int i = 1;
		bool @bool = false;
		foreach (object @object in paramArrayOfObject)
		{
		  if (@object is object[])
		  {
			@bool = true;
			List<object> arrayList1 = new List<object>();
			foreach (object object1 in (object[])@object)
			{
			  arrayList1.Add(object1);
			}
			if (i == 1 && arrayList1.Count != 0)
			{
			  i = arrayList1.Count;
			}
			arrayList.Add(arrayList1);
		  }
		  else
		  {
			arrayList.Add(@object);
		  }
		}
		ExprArray exprArray = new ExprArray(arrayList.Count, i);
		if (!@bool)
		{
		  for (sbyte b = 0; b < arrayList.Count; b++)
		  {
			object @object = arrayList[b];
			ExprString exprString = null;
			if (@object is double?)
			{
			  exprString = new ExprDouble(((double?)@object).Value);
			}
			else if (@object is int?)
			{
			  ExprInteger exprInteger = new ExprInteger(((int?)@object).Value);
			}
			else if (StringUtils.isDecimal(@object.ToString()))
			{
			  exprString = new ExprDouble((Convert.ToDouble(@object.ToString())));
			}
			else
			{
			  exprString = new ExprString(@object.ToString());
			}
			exprArray.set(b, exprString);
		  }
		}
		else
		{
		  for (sbyte b = 0; b < arrayList.Count; b++)
		  {
			System.Collections.IList list = (System.Collections.IList)arrayList[b];
			for (sbyte b1 = 0; b1 < list.Count; b1++)
			{
			  object @object = list[b1];
			  ExprString exprString = null;
			  if (@object is double?)
			  {
				exprString = new ExprDouble(((double?)@object).Value);
			  }
			  else if (@object is int?)
			  {
				ExprInteger exprInteger = new ExprInteger(((int?)@object).Value);
			  }
			  else if (StringUtils.isDecimal(@object.ToString()))
			  {
				exprString = new ExprDouble((Convert.ToDouble(@object.ToString())));
			  }
			  else
			  {
				exprString = new ExprString(@object.ToString());
			  }
			  exprArray.set(b, b1, exprString);
			}
		  }
		}
		return exprArray;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static org.boris.expr.ExprArray toCalculatedEpxrArray(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.ExprArray paramExprArray) throws org.boris.expr.ExprException
	  public static ExprArray toCalculatedEpxrArray(IEvaluationContext paramIEvaluationContext, ExprArray paramExprArray)
	  {
		ExprArray exprArray = new ExprArray(paramExprArray.rows(), paramExprArray.columns());
		for (sbyte b = 0; b < paramExprArray.rows(); b++)
		{
		  for (sbyte b1 = 0; b1 < paramExprArray.columns(); b1++)
		  {
			Expr expr = paramExprArray.get(b, b1);
			if (expr is ExprEvaluatable)
			{
			  expr = ((ExprEvaluatable)expr).evaluate(paramIEvaluationContext);
			}
			exprArray.set(b, b1, expr);
		  }
		}
		return exprArray;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\arrays\ExprArrayUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}