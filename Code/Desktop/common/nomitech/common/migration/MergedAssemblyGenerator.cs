using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Desktop.common.nomitech.common.migration
{
	using ParamItemInputTable = nomitech.common.db.local.ParamItemInputTable;
	using ParamItemOutputTable = nomitech.common.db.local.ParamItemOutputTable;
	using ParamItemTable = nomitech.common.db.local.ParamItemTable;
	using BlankResourceInitializer = nomitech.common.expr.boqitem.BlankResourceInitializer;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	using StringUtils = nomitech.common.util.StringUtils;
	using Session = org.hibernate.Session;

	public class MergedAssemblyGenerator
	{
	  private static MergedAssemblyGenerator s_instance = null;

	  private ParamTreeNode o_rootNode = null;

	  private IDictionary<string, IList<string>> o_descToAccessRightsMap = null;

	  private bool b_hasCostBooks = false;

	  private IDictionary<string, string> o_costBooksMap = new Hashtable();

	  private string o_missingStr = null;

	  private MergedAssemblyGenerator()
	  {
		this.o_costBooksMap["ASM"] = "Assemblies Rel. 2.0 (BCCD)";
		this.o_costBooksMap["CVL"] = "Civil Composite Assemblies";
		this.o_costBooksMap["COM"] = "Commercial Composite Assemblies";
		this.o_costBooksMap["CON"] = "Concrete & Masonry Assemblies";
		this.o_costBooksMap["ELE"] = "Electrical Assemblies";
		this.o_costBooksMap["FAC"] = "Facilities Construction Composite Assemblies";
		this.o_costBooksMap["GRN"] = "Green Building Assemblies";
		this.o_costBooksMap["HVY"] = "Heavy Construction Assemblies";
		this.o_costBooksMap["INT"] = "Interior Assemblies";
		this.o_costBooksMap["ALL"] = "Master Union Composite Assemblies";
		this.o_costBooksMap["MEC"] = "Mechanical Assemblies";
		this.o_costBooksMap["PLU"] = "Plumbing Assemblies";
		this.o_costBooksMap["SIT"] = "Sitework/Landscape Assemblies";
		this.o_costBooksMap["SF"] = "Square Foot Assemblies";
	  }

	  private IList<ParamItemInputTable> createInputList(Session paramSession, IList<ParamItemTable> paramList)
	  {
		sbyte b = 1;
		int i = 1;
		string str = "Param";
		this.b_hasCostBooks = false;
		this.o_missingStr = null;
		List<object> arrayList1 = new List<object>();
		List<object> arrayList2 = new List<object>();
		List<object> arrayList3 = new List<object>();
		foreach (ParamItemTable paramItemTable in paramList)
		{
		  paramItemTable = (ParamItemTable)paramSession.load(typeof(ParamItemTable), paramItemTable.Id);
		  string str1 = paramItemTable.Title.ToUpper();
		  str1 = StringUtils.replaceAll(str1, " ", "");
		  str1 = StringUtils.replaceAll(str1, ",", "");
		  str1 = StringUtils.replaceAll(str1, "\"", "''");
		  System.Collections.IList list = (System.Collections.IList)this.o_descToAccessRightsMap[str1];
		  if (list == null)
		  {
			list = new List<object>();
			this.o_descToAccessRightsMap[str1] = list;
		  }
		  if (!list.Contains(paramItemTable.AccessRights))
		  {
			list.Add(paramItemTable.AccessRights);
		  }
		  arrayList3.Add(StringUtils.replaceAll(paramItemTable.Title, "\"", "''"));
		  foreach (ParamItemInputTable paramItemInputTable1 in paramItemTable.InputSet)
		  {
			if (paramItemInputTable1.SortOrder.Value > i)
			{
			  i = paramItemInputTable1.SortOrder.Value;
			}
			if (arrayList2.Contains(paramItemInputTable1.Name))
			{
			  continue;
			}
			arrayList2.Add(paramItemInputTable1.Name);
			ParamItemInputTable paramItemInputTable2 = (ParamItemInputTable)paramItemInputTable1.clone();
			arrayList1.Add(paramItemInputTable2);
		  }
		}
		i++;
		this.o_rootNode = new ParamTreeNode(this, "", "");
		constructTreeFromDescs(this.o_rootNode, arrayList3);
		StringBuilder stringBuffer = new StringBuilder();
		stringBuffer.Append("SUBSTITUTE(SUBSTITUTE(CONCATENATE(");
		System.Collections.IEnumerator enumeration = this.o_rootNode.preorderEnumeration();
		bool @bool = true;
		while (enumeration.MoveNext())
		{
		  ParamTreeNode paramTreeNode1 = (ParamTreeNode)enumeration.Current;
		  ParamTreeNode paramTreeNode2 = (ParamTreeNode)paramTreeNode1.Parent;
		  if (paramTreeNode1.Leaf)
		  {
			continue;
		  }
		  if (!@bool)
		  {
			stringBuffer.Append(",");
		  }
		  else
		  {
			@bool = false;
		  }
		  if (paramTreeNode1.ChildCount > 1)
		  {
			StringBuilder stringBuffer1 = new StringBuilder();
			string str1 = "";
			for (sbyte b1 = 0; b1 < paramTreeNode1.ChildCount; b1++)
			{
			  ParamTreeNode paramTreeNode = (ParamTreeNode)paramTreeNode1.getChildAt(b1);
			  if (b1 != 0)
			  {
				stringBuffer1.Append("\n");
				str1 = paramTreeNode.UserObject.ToString();
			  }
			  stringBuffer1.Append(paramTreeNode.UserObject.ToString());
			}
			paramTreeNode1.ParamName = str + b;
			ParamItemInputTable paramItemInputTable1 = new ParamItemInputTable();
			paramItemInputTable1.Name = paramTreeNode1.ParamName;
			paramItemInputTable1.DataType = "datatype.list";
			paramItemInputTable1.DefaultValue = "";
			if (paramTreeNode1.Level == 0)
			{
			  paramItemInputTable1.DependencyStatement = "";
			}
			else
			{
			  string str2 = ((ParamTreeNode)paramTreeNode1.Parent).ParamName;
			  string str3 = str2 + "=\"" + paramTreeNode1.UserObject.ToString().ToUpper() + "\"";
			  str3 = "AND(ARG_SHOWING(\"" + str2 + "\")," + str3 + ")";
			  paramItemInputTable1.DependencyStatement = str3;
			}
			paramItemInputTable1.ValidationStatement = "";
			paramItemInputTable1.Description = "";
			paramItemInputTable1.Grouping = "A. Specification";
			paramItemInputTable1.SelectionList = stringBuffer1.ToString().ToUpper();
			paramItemInputTable1.SortOrder = Convert.ToInt32(i);
			paramItemInputTable1.Pblk = false;
			paramItemInputTable1.Hidden = false;
			arrayList1.Add(paramItemInputTable1);
			stringBuffer.Append("\n   IF(ARG_SHOWING(\"" + paramItemInputTable1.Name + "\")," + paramItemInputTable1.Name + ",\"\")");
			b++;
			i++;
			continue;
		  }
		  if (paramTreeNode1.ChildCount == 1)
		  {
			ParamItemInputTable paramItemInputTable1 = new ParamItemInputTable();
			paramItemInputTable1.Name = str + b;
			paramItemInputTable1.DataType = "datatype.calcvalue";
			if (paramTreeNode1.Level == 0)
			{
			  paramItemInputTable1.DependencyStatement = "";
			}
			else
			{
			  string str1 = ((ParamTreeNode)paramTreeNode1.Parent).ParamName;
			  string str2 = str1 + "=\"" + paramTreeNode1.UserObject.ToString().ToUpper() + "\"";
			  str2 = "AND(ARG_SHOWING(\"" + str1 + "\")," + str2 + ")";
			  paramItemInputTable1.DependencyStatement = str2;
			}
			paramItemInputTable1.ValidationStatement = "T(\"" + paramTreeNode1.getChildAt(0).ToString().ToUpper() + "\")";
			paramItemInputTable1.Description = "";
			paramItemInputTable1.Grouping = "A. Specification";
			paramItemInputTable1.SelectionList = "";
			paramItemInputTable1.SortOrder = Convert.ToInt32(i);
			paramItemInputTable1.Pblk = false;
			paramItemInputTable1.Hidden = false;
			arrayList1.Add(paramItemInputTable1);
			stringBuffer.Append("\n   IF(ARG_SHOWING(\"" + paramItemInputTable1.Name + "\")," + paramItemInputTable1.Name + ",\"\")");
			b++;
			i++;
		  }
		}
		stringBuffer.Append("\n),\" \",\"\"),\",\",\"\")");
		ParamItemInputTable paramItemInputTable = new ParamItemInputTable();
		paramItemInputTable.Name = "Result";
		paramItemInputTable.DataType = "datatype.calcvalue";
		paramItemInputTable.DefaultValue = "";
		paramItemInputTable.DependencyStatement = "";
		paramItemInputTable.ValidationStatement = stringBuffer.ToString();
		paramItemInputTable.Description = "";
		paramItemInputTable.Grouping = "A. Specification";
		paramItemInputTable.SelectionList = "";
		paramItemInputTable.SortOrder = Convert.ToInt32(i++);
		b++;
		paramItemInputTable.Pblk = false;
		paramItemInputTable.Hidden = true;
		arrayList1.Add(paramItemInputTable);
		this.o_missingStr = this.o_rootNode.UserObject.ToString();
		this.o_missingStr = StringUtils.replaceAll(this.o_missingStr, " ", "");
		this.o_missingStr = StringUtils.replaceAll(this.o_missingStr, ",", "");
		this.o_missingStr = StringUtils.replaceAll(this.o_missingStr, "\"", "''");
		System.Collections.IEnumerator iterator = this.o_descToAccessRightsMap.Keys.GetEnumerator();
		List<object> arrayList4 = new List<object>();
		while (iterator.MoveNext())
		{
		  string str1 = (string)iterator.Current;
		  System.Collections.IList list = (System.Collections.IList)this.o_descToAccessRightsMap[str1];
		  if (list.Count > 1)
		  {
			str1 = str1.Substring(this.o_missingStr.Length);
			ParamItemInputTable paramItemInputTable1 = constructCostBookByAccessRights(str1, list, i++, b++);
			arrayList4.Add(paramItemInputTable1);
			arrayList1.Add(paramItemInputTable1);
		  }
		}
		if (arrayList4.Count != 0)
		{
		  this.b_hasCostBooks = true;
		  StringBuilder stringBuffer1 = new StringBuilder();
		  sbyte b1 = 0;
		  foreach (ParamItemInputTable paramItemInputTable1 in arrayList4)
		  {
			stringBuffer1.Append("IF(ARG_SHOWING(\"" + paramItemInputTable1.Name + "\")," + paramItemInputTable1.Name + ",");
			b1++;
		  }
		  stringBuffer1.Append("\"ALL\"");
		  for (sbyte b2 = 0; b2 < b1; b2++)
		  {
			stringBuffer1.Append(")");
		  }
		  paramItemInputTable = new ParamItemInputTable();
		  paramItemInputTable.Name = "CostBook";
		  paramItemInputTable.DataType = "datatype.calcvalue";
		  paramItemInputTable.DefaultValue = "";
		  paramItemInputTable.DependencyStatement = "";
		  paramItemInputTable.ValidationStatement = stringBuffer1.ToString();
		  paramItemInputTable.Description = "";
		  paramItemInputTable.Grouping = "A. Specification";
		  paramItemInputTable.SelectionList = "";
		  paramItemInputTable.SortOrder = Convert.ToInt32(i++);
		  paramItemInputTable.Pblk = false;
		  paramItemInputTable.Hidden = true;
		  arrayList1.Add(paramItemInputTable);
		  StringBuilder stringBuffer2 = new StringBuilder();
		  iterator = this.o_costBooksMap.Values.GetEnumerator();
		  b1 = 0;
		  while (iterator.MoveNext())
		  {
			string str1 = (string)iterator.Current;
			foreach (string str2 in this.o_costBooksMap.Keys)
			{
			  if (((string)this.o_costBooksMap[str2]).Equals(str1))
			  {
				stringBuffer2.Append("IF(CostBook=\"" + str1 + "\",\"" + str2 + "\",\n");
				b1++;
			  }
			}
		  }
		  if (b1 > 0)
		  {
			stringBuffer2.Append("\"ALL\"");
			for (sbyte b3 = 0; b3 < b1; b3++)
			{
			  stringBuffer2.Append(")");
			}
		  }
		  paramItemInputTable = new ParamItemInputTable();
		  paramItemInputTable.Name = "CostBookAlias";
		  paramItemInputTable.DataType = "datatype.calcvalue";
		  paramItemInputTable.DefaultValue = "";
		  paramItemInputTable.DependencyStatement = "";
		  paramItemInputTable.ValidationStatement = stringBuffer2.ToString();
		  paramItemInputTable.Description = "";
		  paramItemInputTable.Grouping = "A. Specification";
		  paramItemInputTable.SelectionList = "";
		  paramItemInputTable.SortOrder = Convert.ToInt32(i++);
		  paramItemInputTable.Pblk = false;
		  paramItemInputTable.Hidden = true;
		  arrayList1.Add(paramItemInputTable);
		}
		return resortGroupsInList(arrayList1);
	  }

	  private IList<ParamItemInputTable> resortGroupsInList(IList<ParamItemInputTable> paramList)
	  {
		bool @bool = false;
		foreach (ParamItemInputTable paramItemInputTable in paramList)
		{
		  if (!paramItemInputTable.Grouping.Equals("A. Specification") && paramItemInputTable.Grouping.StartsWith("A.", StringComparison.Ordinal))
		  {
			@bool = true;
		  }
		}
		if (!@bool)
		{
		  return paramList;
		}
		foreach (ParamItemInputTable paramItemInputTable in paramList)
		{
		  if (paramItemInputTable.Grouping.Equals("A. Specification"))
		  {
			continue;
		  }
		  if (paramItemInputTable.Grouping.StartsWith("A.", StringComparison.Ordinal))
		  {
			paramItemInputTable.Grouping = StringUtils.replaceAll(paramItemInputTable.Grouping, "A.", "B.");
			continue;
		  }
		  if (paramItemInputTable.Grouping.StartsWith("B.", StringComparison.Ordinal))
		  {
			paramItemInputTable.Grouping = StringUtils.replaceAll(paramItemInputTable.Grouping, "B.", "C.");
			continue;
		  }
		  if (paramItemInputTable.Grouping.StartsWith("C.", StringComparison.Ordinal))
		  {
			paramItemInputTable.Grouping = StringUtils.replaceAll(paramItemInputTable.Grouping, "C.", "D.");
			continue;
		  }
		  if (paramItemInputTable.Grouping.StartsWith("D.", StringComparison.Ordinal))
		  {
			paramItemInputTable.Grouping = StringUtils.replaceAll(paramItemInputTable.Grouping, "D.", "E.");
		  }
		}
		return paramList;
	  }

	  private ParamItemInputTable constructCostBookByAccessRights(string paramString, IList<string> paramList, int paramInt1, int paramInt2)
	  {
		StringBuilder stringBuffer = new StringBuilder();
		foreach (string str1 in paramList)
		{
		  string[] arrayOfString = str1.Split(",", true);
		  foreach (string str2 in arrayOfString)
		  {
			stringBuffer.Append((string)this.o_costBooksMap[str2] + "\n");
		  }
		}
		string str = stringBuffer.ToString();
		str = str.Substring(0, str.LastIndexOf("\n", StringComparison.Ordinal));
		ParamItemInputTable paramItemInputTable = new ParamItemInputTable();
		paramItemInputTable.Name = "CostBook" + paramInt2;
		paramItemInputTable.DataType = "datatype.list";
		paramItemInputTable.DefaultValue = "";
		paramItemInputTable.DependencyStatement = "Result=\"" + paramString + "\"";
		paramItemInputTable.ValidationStatement = "";
		paramItemInputTable.Description = "Choose a Cost Book to check different rates";
		paramItemInputTable.Grouping = "A. Specification";
		paramItemInputTable.SelectionList = str;
		paramItemInputTable.SortOrder = Convert.ToInt32(paramInt1);
		paramItemInputTable.Pblk = false;
		paramItemInputTable.Hidden = false;
		return paramItemInputTable;
	  }

	  private void constructTreeFromDescs(ParamTreeNode paramParamTreeNode, IList<string> paramList)
	  {
		foreach (string str in paramList)
		{
		  ParamTreeNode paramTreeNode = paramParamTreeNode;
		  string[] arrayOfString = str.ToUpper().Split(", ", true);
		  foreach (string str1 in arrayOfString)
		  {
			ParamTreeNode paramTreeNode1 = getChildOfName(paramTreeNode, str1);
			if (paramTreeNode1 != null)
			{
			  paramTreeNode = paramTreeNode1;
			}
			else
			{
			  paramTreeNode1 = new ParamTreeNode(this, str1);
			  paramTreeNode.add(paramTreeNode1);
			  paramTreeNode1.Parent = paramTreeNode;
			  paramTreeNode = paramTreeNode1;
			}
		  }
		}
		mergeOneChild(paramParamTreeNode);
	  }

	  private string printNode(ParamTreeNode paramParamTreeNode)
	  {
		TreeNode[] arrayOfTreeNode = paramParamTreeNode.Path;
		StringBuilder stringBuffer = new StringBuilder();
		foreach (TreeNode treeNode in arrayOfTreeNode)
		{
		  stringBuffer.Append(treeNode + ", ");
		}
		return stringBuffer.ToString();
	  }

	  private void mergeOneChild(ParamTreeNode paramParamTreeNode)
	  {
		if (paramParamTreeNode.ChildCount == 1)
		{
		  ParamTreeNode paramTreeNode = (ParamTreeNode)paramParamTreeNode.getChildAt(0);
		  System.Collections.IEnumerator enumeration1 = paramTreeNode.children();
		  List<object> arrayList1 = new List<object>();
		  while (enumeration1.MoveNext())
		  {
			arrayList1.Add((ParamTreeNode)enumeration1.Current);
		  }
		  if (StringUtils.isNullOrBlank(paramParamTreeNode.UserObject.ToString()))
		  {
			paramParamTreeNode.UserObject = paramTreeNode.UserObject;
		  }
		  else
		  {
			paramParamTreeNode.UserObject = paramParamTreeNode.UserObject + ", " + paramTreeNode.UserObject;
		  }
		  paramParamTreeNode.remove(paramTreeNode);
		  foreach (ParamTreeNode paramTreeNode1 in arrayList1)
		  {
			paramParamTreeNode.add(paramTreeNode1);
			paramTreeNode1.Parent = paramParamTreeNode;
		  }
		  if (paramParamTreeNode.ChildCount == 1)
		  {
			mergeOneChild(paramParamTreeNode);
			return;
		  }
		}
		System.Collections.IEnumerator enumeration = paramParamTreeNode.children();
		List<object> arrayList = new List<object>();
		while (enumeration.MoveNext())
		{
		  arrayList.Add((ParamTreeNode)enumeration.Current);
		}
		foreach (ParamTreeNode paramTreeNode in arrayList)
		{
		  mergeOneChild(paramTreeNode);
		}
	  }

	  private ParamTreeNode getChildOfName(ParamTreeNode paramParamTreeNode, string paramString)
	  {
		System.Collections.IEnumerator enumeration = paramParamTreeNode.children();
		while (enumeration.MoveNext())
		{
		  ParamTreeNode paramTreeNode = (ParamTreeNode)enumeration.Current;
		  if (paramTreeNode.UserObject.ToString().Equals(paramString))
		  {
			return paramTreeNode;
		  }
		}
		return null;
	  }

	  private IList<ParamItemOutputTable> createOutputList(Session paramSession, IList<ParamItemTable> paramList)
	  {
		List<object> arrayList1 = new List<object>();
		Hashtable hashMap = new Hashtable();
		List<object> arrayList2 = new List<object>();
		foreach (ParamItemTable paramItemTable in paramList)
		{
		  paramItemTable = (ParamItemTable)paramSession.load(typeof(ParamItemTable), paramItemTable.Id);
		  string str = StringUtils.replaceAll(paramItemTable.Title.ToUpper(), " ", "");
		  str = StringUtils.replaceAll(str, ",", "");
		  str = StringUtils.replaceAll(str, "\"", "''");
		  foreach (ParamItemOutputTable paramItemOutputTable in paramItemTable.OutputSet)
		  {
			OutputData outputData = (OutputData)hashMap[paramItemOutputTable.ResourceIds];
			if (outputData == null)
			{
			  outputData = new OutputData(this, (ParamItemOutputTable)paramItemOutputTable.clone());
			  hashMap[paramItemOutputTable.ResourceIds] = outputData;
			}
			if (outputData.isDescContained(str))
			{
			  outputData = new OutputData(this, (ParamItemOutputTable)paramItemOutputTable.clone());
			  arrayList2.Add(outputData);
			}
			outputData.DescsList.Add(str);
			outputData.QtyList.Add(paramItemOutputTable.QuantityEquation);
			outputData.AccessRightsList.Add(paramItemTable.AccessRights);
		  }
		}
		List<object> arrayList3 = new List<object>();
		arrayList3.AddRange(hashMap.Values);
		arrayList3.AddRange(arrayList2);
		OutputData[] arrayOfOutputData = (OutputData[])arrayList3.ToArray(typeof(OutputData));
		Arrays.sort(arrayOfOutputData);
		sbyte b = 1;
		foreach (OutputData outputData in arrayOfOutputData)
		{
		  ParamItemOutputTable paramItemOutputTable = outputData.OutputTable;
		  paramItemOutputTable.QuantityEquation = constructQuantityEquation(outputData);
		  paramItemOutputTable.GenerationCondition = constructGenerationCondition(outputData);
		  paramItemOutputTable.SortOrder = Convert.ToInt32(b++);
		  arrayList1.Add(paramItemOutputTable);
		}
		return arrayList1;
	  }

	  private string constructGenerationCondition(OutputData paramOutputData)
	  {
		int i = paramOutputData.DescsList.Count;
		StringBuilder stringBuffer = new StringBuilder();
		sbyte b;
		for (b = 0; b < i; b++)
		{
		  string str = (string)paramOutputData.DescsList[b];
		  str = str.Substring(this.o_missingStr.Length);
		  if (!this.b_hasCostBooks)
		  {
			stringBuffer.Append("IF(Result=\"" + str + "\",TRUE(),\n");
		  }
		  else
		  {
			string str1 = (string)paramOutputData.AccessRightsList[b];
			string str2 = "AND(Result=\"" + str + "\",ISERR(FIND(T(costBookAlias),\"" + str1 + "\"))=FALSE())";
			stringBuffer.Append("IF(" + str2 + ",TRUE(),\n");
		  }
		}
		stringBuffer.Append("FALSE()");
		for (b = 0; b < i; b++)
		{
		  stringBuffer.Append(")");
		}
		return stringBuffer.ToString();
	  }

	  private string constructQuantityEquation(OutputData paramOutputData)
	  {
		int i = paramOutputData.DescsList.Count;
		StringBuilder stringBuffer = new StringBuilder();
		sbyte b;
		for (b = 0; b < i; b++)
		{
		  string str1 = (string)paramOutputData.DescsList[b];
		  string str2 = (string)paramOutputData.QtyList[b];
		  str1 = str1.Substring(this.o_missingStr.Length);
		  if (!this.b_hasCostBooks)
		  {
			stringBuffer.Append("IF(Result=\"" + str1 + "\"," + str2 + ",\n");
		  }
		  else
		  {
			string str3 = (string)paramOutputData.AccessRightsList[b];
			string str4 = "AND(Result=\"" + str1 + "\",ISERR(FIND(T(costBookAlias),\"" + str3 + "\"))=FALSE())";
			stringBuffer.Append("IF(" + str4 + "," + str2 + ",\n");
		  }
		}
		stringBuffer.Append("0");
		for (b = 0; b < i; b++)
		{
		  stringBuffer.Append(")");
		}
		return stringBuffer.ToString();
	  }

	  public virtual void mergeToOne(Session paramSession, IList<ParamItemTable> paramList, string paramString)
	  {
		this.o_descToAccessRightsMap = new Hashtable();
		System.Collections.IList list1 = createInputList(paramSession, paramList);
		System.Collections.IList list2 = createOutputList(paramSession, paramList);
		ParamItemTable paramItemTable1 = (ParamItemTable)paramList[0];
		ParamItemTable paramItemTable2 = BlankResourceInitializer.createBlankParamItem(paramItemTable1);
		if (!StringUtils.isNullOrBlank(this.o_rootNode.UserObject.ToString()))
		{
		  paramItemTable2.Title = StringUtils.makeShortTitle(this.o_rootNode.UserObject.ToString());
		}
		else
		{
		  if (paramString.IndexOf(" - ", StringComparison.Ordinal) != -1)
		  {
			paramString = paramString.Substring(paramString.IndexOf(" -", StringComparison.Ordinal) + 2);
		  }
		  paramItemTable2.Title = paramString.ToUpper();
		}
		paramItemTable2.Description = this.o_rootNode.UserObject.ToString();
		paramItemTable2.SampleRate = BigDecimalMath.ZERO;
		paramItemTable2.CostModel = true;
		paramItemTable2.EditorId = paramItemTable1.EditorId;
		paramItemTable2.AccessRights = "ALL,NODOC";
		paramItemTable2.Keywords = paramItemTable1.Keywords;
		paramItemTable2.Notes = "ALL,NODOC";
		paramItemTable2.LastUpdate = paramItemTable1.LastUpdate;
		paramItemTable2.CreateDate = paramItemTable1.LastUpdate;
		paramItemTable2.CreateUserId = paramItemTable1.CreateUserId;
		paramItemTable2.InputSet = new HashSet<object>();
		paramItemTable2.OutputSet = new HashSet<object>();
		long? long = (long?)paramSession.save(paramItemTable2);
		paramItemTable2 = (ParamItemTable)paramSession.load(typeof(ParamItemTable), long);
		foreach (ParamItemInputTable paramItemInputTable in list1)
		{
		  long = (long?)paramSession.save(paramItemInputTable);
		  paramItemInputTable = (ParamItemInputTable)paramSession.load(typeof(ParamItemInputTable), long);
		  paramItemTable2.InputSet.Add(paramItemInputTable);
		  paramItemInputTable.ParamItemTable = paramItemTable2;
		  paramSession.update(paramItemInputTable);
		}
		foreach (ParamItemOutputTable paramItemOutputTable in list2)
		{
		  long = (long?)paramSession.save(paramItemOutputTable);
		  paramItemOutputTable = (ParamItemOutputTable)paramSession.load(typeof(ParamItemOutputTable), long);
		  paramItemTable2.OutputSet.Add(paramItemOutputTable);
		  paramItemOutputTable.ParamItemTable = paramItemTable2;
		  paramSession.update(paramItemOutputTable);
		}
	  }

	  public static MergedAssemblyGenerator Instance
	  {
		  get
		  {
			if (s_instance == null)
			{
			  s_instance = new MergedAssemblyGenerator();
			}
			return s_instance;
		  }
	  }

	  private class OutputData : object, IComparable<OutputData>
	  {
		  private readonly MergedAssemblyGenerator outerInstance;

		internal ParamItemOutputTable outputTable;

		internal IList<string> qtyList = new List<object>();

		internal IList<string> accessRightsList = new List<object>();

		internal IList<string> descsList = new List<object>();

		public OutputData(MergedAssemblyGenerator outerInstance, ParamItemOutputTable param1ParamItemOutputTable)
		{
			this.outerInstance = outerInstance;
			this.outputTable = param1ParamItemOutputTable;
		}

		public virtual ParamItemOutputTable OutputTable
		{
			get
			{
				return this.outputTable;
			}
		}

		public virtual IList<string> QtyList
		{
			get
			{
				return this.qtyList;
			}
		}

		public virtual IList<string> AccessRightsList
		{
			get
			{
				return this.accessRightsList;
			}
		}

		public virtual IList<string> DescsList
		{
			get
			{
				return this.descsList;
			}
		}

		public virtual bool isDescContained(string param1String)
		{
			return this.descsList.Contains(param1String);
		}

		public virtual int CompareTo(OutputData param1OutputData)
		{
			return this.outputTable.Title.CompareTo(param1OutputData.outputTable.Title);
		}
	  }

	  private class ParamTreeNode : DefaultMutableTreeNode
	  {
		  private readonly MergedAssemblyGenerator outerInstance;

		internal string paramName;

		public ParamTreeNode(MergedAssemblyGenerator outerInstance, string param1String) : base(param1String)
		{
			this.outerInstance = outerInstance;
		}

		public ParamTreeNode(MergedAssemblyGenerator outerInstance, string param1String1, string param1String2) : base(param1String2)
		{
			this.outerInstance = outerInstance;
		  this.paramName = param1String1;
		}

		public virtual string ParamName
		{
			set
			{
				this.paramName = value;
			}
			get
			{
				return this.paramName;
			}
		}

	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\MergedAssemblyGenerator.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}