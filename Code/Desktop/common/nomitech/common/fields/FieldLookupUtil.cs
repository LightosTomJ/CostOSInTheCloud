using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Desktop.common.nomitech.common.fields
{
	using AssemblyConsumableTable = Models.local.AssemblyConsumableTable;
	using FieldCustomizationTable = Models.local.FieldCustomizationTable;
	using ProjectInfoTable = Models.local.ProjectInfoTable;
	using BoqItemTable = Models.proj.BoqItemTable;
	using BoqItemDefaultFormulas = Desktop.common.nomitech.common.expr.boqitem.BoqItemDefaultFormulas;
	using StringUtils = Desktop.common.nomitech.common.util.StringUtils;
	using Session = Desktop.common.org.hibernate.Session;

	public class FieldLookupUtil
	{
	  private static FieldLookupUtil s_instance;

	  private IDictionary<FieldCustomizationKey, FieldCustomizationTable> fieldsMap = new ConcurrentDictionary();

	  private FieldLookupUtil()
	  {
		  reloadFromDatabase();
	  }

	  private FieldLookupUtil(Session paramSession)
	  {
		  reloadFromSession(paramSession);
	  }

	  private void initializeFieldsMap()
	  {
		this.fieldsMap.Clear();
		string[] arrayOfString = BoqItemTable.VIEWABLE_FIELDS;
		foreach (string str in arrayOfString)
		{
		  FieldCustomizationTable fieldCustomizationTable = createFieldCustomization(str, null, "boqitem", BoqItemDefaultFormulas.Instance.getDefaultFormulaForField(str));
		  this.fieldsMap[new FieldCustomizationKey(this, str, "boqitem")] = fieldCustomizationTable;
		}
		arrayOfString = AssemblyConsumableTable.FIELDS;
		foreach (string str in arrayOfString)
		{
		  FieldCustomizationTable fieldCustomizationTable = createFieldCustomization(str, null, "equipment", null);
		  this.fieldsMap[new FieldCustomizationKey(this, str, "equipment")] = fieldCustomizationTable;
		  fieldCustomizationTable = createFieldCustomization(str, null, "labor", null);
		  this.fieldsMap[new FieldCustomizationKey(this, str, "labor")] = fieldCustomizationTable;
		  fieldCustomizationTable = createFieldCustomization(str, null, "subcontractor", null);
		  this.fieldsMap[new FieldCustomizationKey(this, str, "subcontractor")] = fieldCustomizationTable;
		  fieldCustomizationTable = createFieldCustomization(str, null, "material", null);
		  this.fieldsMap[new FieldCustomizationKey(this, str, "material")] = fieldCustomizationTable;
		  fieldCustomizationTable = createFieldCustomization(str, null, "consumable", null);
		  this.fieldsMap[new FieldCustomizationKey(this, str, "consumable")] = fieldCustomizationTable;
		  fieldCustomizationTable = createFieldCustomization(str, null, "assembly", null);
		  this.fieldsMap[new FieldCustomizationKey(this, str, "assembly")] = fieldCustomizationTable;
		}
		arrayOfString = ProjectInfoTable.CUSTOM_EPS_FIELDS;
		foreach (string str in arrayOfString)
		{
		  FieldCustomizationTable fieldCustomizationTable = createFieldCustomization(str, null, "projectinfo", null);
		  this.fieldsMap[new FieldCustomizationKey(this, str, "projectinfo")] = fieldCustomizationTable;
		}
	  }

	  private FieldCustomizationTable createFieldCustomization(string paramString1, string paramString2, string paramString3, string paramString4)
	  {
		FieldCustomizationTable fieldCustomizationTable = new FieldCustomizationTable();
		fieldCustomizationTable.Name = paramString1;
		fieldCustomizationTable.DisplayName = paramString2;
		fieldCustomizationTable.ResourceType = paramString3;
		fieldCustomizationTable.Formula = paramString4;
		fieldCustomizationTable.SelectionList = false;
		fieldCustomizationTable.SelectionValues = "";
		fieldCustomizationTable.DefSelection = null;
		return fieldCustomizationTable;
	  }

	  public virtual void reloadFromSession(Session paramSession)
	  {
		initializeFieldsMap();
		foreach (FieldCustomizationTable fieldCustomizationTable in paramSession.createQuery("from FieldCustomizationTable").list())
		{
		  this.fieldsMap[new FieldCustomizationKey(this, fieldCustomizationTable.Name, fieldCustomizationTable.ResourceType)] = (FieldCustomizationTable)fieldCustomizationTable.clone();
		}
	  }

	  public virtual void reloadFromDatabase()
	  {
		initializeFieldsMap();
		bool @bool = !DatabaseDBUtil.hasOpenedSession() ? 1 : 0;
		Session session = DatabaseDBUtil.currentSession();
		foreach (FieldCustomizationTable fieldCustomizationTable in session.createQuery("from FieldCustomizationTable").list())
		{
		  this.fieldsMap[new FieldCustomizationKey(this, fieldCustomizationTable.Name, fieldCustomizationTable.ResourceType)] = (FieldCustomizationTable)fieldCustomizationTable.clone();
		}
		if (@bool)
		{
		  DatabaseDBUtil.closeSession();
		}
	  }

	  public virtual IDictionary<FieldCustomizationKey, FieldCustomizationTable> FieldsMap
	  {
		  get
		  {
			  return this.fieldsMap;
		  }
	  }

	  public virtual IList<FieldCustomizationTable> getCustomSelectionListFields(string paramString)
	  {
		List<object> arrayList = new List<object>();
		foreach (FieldCustomizationKey fieldCustomizationKey in this.fieldsMap.Keys)
		{
		  FieldCustomizationTable fieldCustomizationTable = (FieldCustomizationTable)this.fieldsMap[fieldCustomizationKey];
		  if (string.ReferenceEquals(fieldCustomizationTable.ResourceType, null))
		  {
			fieldCustomizationTable.ResourceType = "boqitem";
		  }
		  if (fieldCustomizationTable.ResourceType.Equals(paramString) && fieldCustomizationTable.Name.StartsWith("custom", StringComparison.Ordinal) && fieldCustomizationTable.SelectionList != null && fieldCustomizationTable.SelectionList.Equals(true))
		  {
			arrayList.Add(fieldCustomizationTable);
		  }
		}
		return arrayList;
	  }

	  public virtual string formulaForField(string paramString1, string paramString2)
	  {
		FieldCustomizationTable fieldCustomizationTable = customizationForField(paramString1, paramString2);
		return (fieldCustomizationTable == null || StringUtils.isNullOrBlank(fieldCustomizationTable.Formula)) ? null : fieldCustomizationTable.Formula;
	  }

	  public virtual FieldCustomizationTable customizationForField(string paramString1, string paramString2)
	  {
		  return (FieldCustomizationTable)this.fieldsMap[new FieldCustomizationKey(this, paramString1, paramString2)];
	  }

	  public virtual void storeToDatabase(IList<FieldCustomizationTable> paramList)
	  {
		Session session = DatabaseDBUtil.currentSession();
		session.beginTransaction();
		foreach (FieldCustomizationTable fieldCustomizationTable in paramList)
		{
		  storeToDatabase(fieldCustomizationTable);
		}
		session.Transaction.commit();
		DatabaseDBUtil.closeSession();
	  }

	  public virtual void storeToDatabase(FieldCustomizationTable paramFieldCustomizationTable)
	  {
		bool @bool = !DatabaseDBUtil.hasOpenedSession() ? 1 : 0;
		Session session = DatabaseDBUtil.currentSession();
		if (@bool)
		{
		  session.beginTransaction();
		}
		System.Collections.IEnumerator iterator = session.createQuery("from FieldCustomizationTable o where o.name = '" + paramFieldCustomizationTable.Name + "' and o.resourceType = '" + paramFieldCustomizationTable.ResourceType + "'").list().GetEnumerator();
		FieldCustomizationTable fieldCustomizationTable = paramFieldCustomizationTable;
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
		Console.WriteLine("FOUND: " + iterator.hasNext());
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
		if (iterator.hasNext())
		{
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
		  fieldCustomizationTable = (FieldCustomizationTable)iterator.next();
		  fieldCustomizationTable.Data = paramFieldCustomizationTable;
		  session.update(fieldCustomizationTable);
		}
		else
		{
		  long? long = (long?)session.save(fieldCustomizationTable);
		  fieldCustomizationTable.Id = long;
		}
		Console.WriteLine("SAVED " + fieldCustomizationTable.DisplayName);
		this.fieldsMap[new FieldCustomizationKey(this, fieldCustomizationTable)] = (FieldCustomizationTable)fieldCustomizationTable.clone();
		if (@bool)
		{
		  session.Transaction.commit();
		}
		if (@bool)
		{
		  DatabaseDBUtil.closeSession();
		}
	  }

	  public static FieldLookupUtil Instance
	  {
		  get
		  {
			if (s_instance == null)
			{
			  s_instance = new FieldLookupUtil();
			}
			return s_instance;
		  }
	  }

	  public static FieldLookupUtil getInstance(Session paramSession)
	  {
		if (s_instance == null)
		{
		  s_instance = new FieldLookupUtil(paramSession);
		}
		return s_instance;
	  }

	  public virtual IList<FieldCustomizationTable> AllFieldsList
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			arrayList.AddRange(this.fieldsMap.Values);
			return arrayList;
		  }
	  }

	  public virtual IList<FieldCustomizationTable> BoqItemFieldsList
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			foreach (FieldCustomizationTable fieldCustomizationTable in this.fieldsMap.Values)
			{
			  if (fieldCustomizationTable.ResourceType.Equals("boqitem"))
			  {
				arrayList.Add(fieldCustomizationTable);
			  }
			}
			return arrayList;
		  }
	  }

	  public virtual IList<FieldCustomizationTable> ProjectInfoFieldsList
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			foreach (FieldCustomizationTable fieldCustomizationTable in this.fieldsMap.Values)
			{
			  if (fieldCustomizationTable.ResourceType.Equals("projectinfo"))
			  {
				arrayList.Add(fieldCustomizationTable);
			  }
			}
			return arrayList;
		  }
	  }

	  public virtual void resetAll()
	  {
		bool @bool = !DatabaseDBUtil.hasOpenedSession() ? 1 : 0;
		Session session = DatabaseDBUtil.currentSession();
		if (@bool)
		{
		  session.beginTransaction();
		}
		System.Collections.IEnumerator iterator = session.createQuery("from FieldCustomizationTable").list().GetEnumerator();
		List<object> arrayList = new List<object>();
		while (iterator.MoveNext())
		{
		  arrayList.Add(iterator.Current);
		}
		iterator = arrayList.GetEnumerator();
		while (iterator.MoveNext())
		{
		  session.delete(iterator.Current);
		}
		if (@bool)
		{
		  session.Transaction.commit();
		}
		if (@bool)
		{
		  DatabaseDBUtil.closeSession();
		}
		initializeFieldsMap();
	  }

	  private class FieldCustomizationKey
	  {
		  private readonly FieldLookupUtil outerInstance;

		internal string field;

		internal string resourceType;

		internal string hashKey;

		public FieldCustomizationKey(FieldLookupUtil outerInstance, string param1String1, string param1String2)
		{
			this.outerInstance = outerInstance;
		  this.field = param1String1;
		  this.resourceType = param1String2;
		  this.hashKey = param1String2 + param1String1;
		}

		public FieldCustomizationKey(FieldLookupUtil outerInstance, FieldCustomizationTable param1FieldCustomizationTable) : this(outerInstance, param1FieldCustomizationTable.Name, param1FieldCustomizationTable.ResourceType)
		{
			this.outerInstance = outerInstance;
		}

		public override int GetHashCode()
		{
			return this.hashKey.GetHashCode();
		}

		public override bool Equals(object param1Object)
		{
			return (param1Object is FieldCustomizationKey) ? ((((FieldCustomizationKey)param1Object).field.Equals(this.field) && ((FieldCustomizationKey)param1Object).resourceType.Equals(this.resourceType))) : false;
		}

		public override string ToString()
		{
			return this.hashKey;
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\fields\FieldLookupUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}