using System;
using System.Collections.Generic;

namespace Models.report
{

	using JRDataSource = net.sf.jasperreports.engine.JRDataSource;
	using JRException = net.sf.jasperreports.engine.JRException;
	using JRField = net.sf.jasperreports.engine.JRField;
	using JRRuntimeException = net.sf.jasperreports.engine.JRRuntimeException;

	using PropertyUtils = org.apache.commons.beanutils.PropertyUtils;
	using Type = org.hibernate.type.Type;

	public abstract class ProjectDataSource : JRDataSource
	{
		private readonly bool useFieldDescription;
		private readonly IDictionary<string, FieldReader> fieldReaders;
		protected internal readonly ProjectQueryExecuter queryExecuter;
		private object currentReturnValue;
		public const string CURRENT_BEAN_MAPPING = "_THIS";

		internal interface PropertyNameProvider
		{
		string getPropertyName(JRField field);
		}

		protected internal static readonly PropertyNameProvider FIELD_NAME_PROPERTY_NAME_PROVIDER = new PropertyNameProviderAnonymousInnerClass();

		private class PropertyNameProviderAnonymousInnerClass : PropertyNameProvider
		{
			public string getPropertyName(JRField field)
			{
				return field.Name;
			}
		}

		protected internal static readonly PropertyNameProvider FIELD_DESCRIPTION_PROPERTY_NAME_PROVIDER = new PropertyNameProviderAnonymousInnerClass2();

		private class PropertyNameProviderAnonymousInnerClass2 : PropertyNameProvider
		{
			public string getPropertyName(JRField field)
			{
				if (field.Description == null)
				{
					return field.Name;
				}
				return field.Description;
			}
		}

		/// <summary>
		/// Creates a Hibernate data source.
		/// </summary>
		/// <param name="queryExecuter"> the query executer </param>
		/// <param name="useFieldDescription"> whether to use field descriptions for fields to results mapping </param>
		/// <param name="useIndexOnSingleReturn"> whether to use indexed addressing even when the query has only one return column </param>
		protected internal ProjectDataSource(ProjectQueryExecuter queryExecuter, bool useFieldDescription, bool useIndexOnSingleReturn)
		{
			this.useFieldDescription = useFieldDescription;

			this.queryExecuter = queryExecuter;

			fieldReaders = assignReaders(useIndexOnSingleReturn);
		}

		/// <summary>
		/// Assigns field readers to report fields.
		/// </summary>
		/// <param name="useIndexOnSingleReturn">  whether to use indexed addressing even when the query has only one return column </param>
		/// <returns> a report field name to field reader mapping </returns>
		/// <seealso cref= FieldReader </seealso>
		protected internal virtual IDictionary<string, FieldReader> assignReaders(bool useIndexOnSingleReturn)
		{
			IDictionary<string, FieldReader> readers = new Dictionary<string, FieldReader>();

			JRField[] fields = queryExecuter.Dataset.Fields;
			Type[] returnTypes = queryExecuter.ReturnTypes;
			string[] aliases = queryExecuter.ReturnAliases;

			IDictionary<string, int> aliasesMap = new Dictionary<string, int>();
			if (aliases != null)
			{
				for (int i = 0; i < aliases.Length; i++)
				{
					aliasesMap[aliases[i]] = Convert.ToInt32(i);
				}
			}

			if (returnTypes.Length == 1)
			{
				if (returnTypes[0].EntityType || returnTypes[0].ComponentType)
				{
					for (int i = 0; i < fields.Length; i++)
					{
						JRField field = fields[i];
						readers[field.Name] = getFieldReaderSingleReturn(aliasesMap, field, useIndexOnSingleReturn);
					}
				}
				else
				{
					if (fields.Length > 1)
					{
						throw new JRRuntimeException("The HQL query returns only one non-entity and non-component result but there are more than one fields.");
					}

					if (fields.Length == 1)
					{
						JRField field = fields[0];
						if (useIndexOnSingleReturn)
						{
							readers[field.Name] = new IndexFieldReader(0);
						}
						else
						{
							readers[field.Name] = new IdentityFieldReader();
						}
					}
				}
			}
			else
			{
				for (int i = 0; i < fields.Length; i++)
				{
					JRField field = fields[i];
					readers[field.Name] = getFieldReader(returnTypes, aliasesMap, field);
				}
			}

			return readers;
		}

		protected internal virtual FieldReader getFieldReaderSingleReturn(IDictionary<string, int> aliasesMap, JRField field, bool useIndex)
		{
			FieldReader reader;

			string fieldMapping = getFieldMapping(field);
			if (aliasesMap.ContainsKey(fieldMapping))
			{
				if (useIndex)
				{
					reader = new IndexFieldReader(0);
				}
				else
				{
					reader = new IdentityFieldReader();
				}
			}
			else
			{
				int firstNestedIdx = fieldMapping.IndexOf(PropertyUtils.NESTED_DELIM);

				if (firstNestedIdx >= 0 && aliasesMap.ContainsKey(fieldMapping.Substring(0, firstNestedIdx)))
				{
					fieldMapping = fieldMapping.Substring(firstNestedIdx + 1);
				}

				if (useIndex)
				{
					reader = new IndexPropertyFieldReader(0, fieldMapping);
				}
				else
				{
					reader = new PropertyFieldReader(fieldMapping);
				}
			}

			return reader;
		}

		protected internal virtual FieldReader getFieldReader(Type[] returnTypes, IDictionary<string, int> aliasesMap, JRField field)
		{
			FieldReader reader;

			string fieldMapping = getFieldMapping(field);
			int? fieldIdx = aliasesMap[fieldMapping];
			if (fieldIdx == null)
			{
				int firstNestedIdx = fieldMapping.IndexOf(PropertyUtils.NESTED_DELIM);

				if (firstNestedIdx < 0)
				{
					throw new JRRuntimeException("Unknown HQL return alias \"" + fieldMapping + "\".");
				}

				string fieldAlias = fieldMapping.Substring(0, firstNestedIdx);
				string fieldProperty = fieldMapping.Substring(firstNestedIdx + 1);

				fieldIdx = aliasesMap[fieldAlias];
				if (fieldIdx == null)
				{
					throw new JRRuntimeException("The HQL query does not have a \"" + fieldAlias + "\" alias.");
				}

				Type type = returnTypes[fieldIdx.Value];
				if (!type.EntityType && !type.ComponentType)
				{
					throw new JRRuntimeException("The HQL query does not have a \"" + fieldAlias + "\" alias.");
				}

				reader = new IndexPropertyFieldReader(fieldIdx.Value, fieldProperty);
			}
			else
			{
				reader = new IndexFieldReader(fieldIdx.Value);
			}

			return reader;
		}


		/// <summary>
		/// Sets the current row of the query result.
		/// </summary>
		/// <param name="currentReturnValue"> the current row value </param>
		protected internal virtual object CurrentRowValue
		{
			set
			{
				this.currentReturnValue = value;
			}
		}


//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public Object getFieldValue(net.sf.jasperreports.engine.JRField jrField) throws net.sf.jasperreports.engine.JRException
		public override object getFieldValue(JRField jrField)
		{
			FieldReader reader = fieldReaders[jrField.Name];
			if (reader == null)
			{
				throw new JRRuntimeException("No filed reader for " + jrField.Name);
			}
			return reader.getFieldValue(currentReturnValue);
		}


		protected internal virtual string getFieldMapping(JRField field)
		{
			return (useFieldDescription ? FIELD_DESCRIPTION_PROPERTY_NAME_PROVIDER : FIELD_NAME_PROPERTY_NAME_PROVIDER).getPropertyName(field);
		}

		protected internal static bool isCurrentBeanMapping(string propertyName)
		{
		return CURRENT_BEAN_MAPPING.Equals(propertyName);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected static Object getBeanProperty(Object bean, String propertyName) throws net.sf.jasperreports.engine.JRException
		protected internal static object getBeanProperty(object bean, string propertyName)
		{
			object value = null;

			if (isCurrentBeanMapping(propertyName))
			{
				value = bean;
			}
			else if (bean != null)
			{
				try
				{
					value = PropertyUtils.getProperty(bean, propertyName);
				}
				catch (java.lang.IllegalAccessException e)
				{
					throw new JRException("Error retrieving field value from bean : " + propertyName, e);
				}
				catch (java.lang.reflect.InvocationTargetException e)
				{
					throw new JRException("Error retrieving field value from bean : " + propertyName, e);
				}
				catch (java.lang.NoSuchMethodException e)
				{
					throw new JRException("Error retrieving field value from bean : " + propertyName, e);
				}
				catch (System.ArgumentException e)
				{
					//FIXME replace with NestedNullException when upgrading to BeanUtils 1.7
					if (!e.Message.StartsWith("Null property value for "))
					{
						throw e;
					}
				}
			}

			return value;
		}

		/// <summary>
		/// Interface used to get the value of a report field from a result row.
		/// </summary>
		protected internal interface FieldReader
		{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: Object getFieldValue(Object resultValue) throws net.sf.jasperreports.engine.JRException;
			object getFieldValue(object resultValue);
		}

		protected internal class IdentityFieldReader : FieldReader
		{
			public virtual object getFieldValue(object resultValue)
			{
				return resultValue;
			}
		}

		protected internal class IndexFieldReader : FieldReader
		{
			internal readonly int idx;

			protected internal IndexFieldReader(int idx)
			{
				this.idx = idx;
			}

			public virtual object getFieldValue(object resultValue)
			{
				return ((object[]) resultValue)[idx];
			}
		}

		protected internal class PropertyFieldReader : FieldReader
		{
			internal readonly string property;

			protected internal PropertyFieldReader(string property)
			{
				this.property = property;
			}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public Object getFieldValue(Object resultValue) throws net.sf.jasperreports.engine.JRException
			public virtual object getFieldValue(object resultValue)
			{
				return getBeanProperty(resultValue, property);
			}
		}

		protected internal class IndexPropertyFieldReader : FieldReader
		{
			internal readonly int idx;
			internal readonly string property;

			protected internal IndexPropertyFieldReader(int idx, string property)
			{
				this.idx = idx;
				this.property = property;
			}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public Object getFieldValue(Object resultValue) throws net.sf.jasperreports.engine.JRException
			public virtual object getFieldValue(object resultValue)
			{
				return getBeanProperty(((object[]) resultValue)[idx], property);
			}
		}
	}
}