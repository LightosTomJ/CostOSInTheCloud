using System;
using System.Collections.Generic;

namespace Models.cache
{


	using BaseCache = Desktop.common.nomitech.common.@base.BaseCache;
	using GroupCode = Desktop.common.nomitech.common.@base.GroupCode;
	using ProjectInfoTable = Desktop.common.nomitech.common.db.local.ProjectInfoTable;
	using ProjectWBSTable = Desktop.common.nomitech.common.db.local.ProjectWBSTable;
	using CodeUtils = Desktop.common.nomitech.common.util.CodeUtils;

	using Session = org.hibernate.Session;

	public class WBSCache : BaseCache
	{
		public const string TABLE_NAME = "ProjectWBSTable";

		private IDictionary<string, GroupCode> hashMap = Collections.synchronizedMap(new Dictionary<string, GroupCode>());

		private string o_code;
		private string o_name;

		private string o_codingSystem = DOTTED_GC_STYLE;
		private ProjectDBUtil o_prjDbUtil;

		public WBSCache(ProjectDBUtil prjDBUtil)
		{
			o_prjDbUtil = prjDBUtil;
			initCache(prjDBUtil.Properties.getProperty("project.code"), prjDBUtil.Properties.getProperty("project.name"));
		}

		public WBSCache(ProjectDBUtil prjDBUtil, bool initCaches)
		{
			o_prjDbUtil = prjDBUtil;
			if (initCaches)
			{
				initCache(prjDBUtil.Properties.getProperty("project.code"), prjDBUtil.Properties.getProperty("project.name"));
			}
		}

		// Used in DoubleEntityCache
		public WBSCache(string code, string name)
		{
			initCache(code,name);
		}

		public virtual void initCache()
		{
			if (o_prjDbUtil != null)
			{
				initCache(o_prjDbUtil.Properties.getProperty("project.code"), o_prjDbUtil.Properties.getProperty("project.name"));
			}
		}

		private void initCache(string code, string name)
		{
			o_code = code;
			o_name = name;
			try
			{
				if (o_prjDbUtil != null)
				{
					initializeCache();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}
		}

		public virtual string ProjectCode
		{
			get
			{
				return o_code;
			}
		}

		public virtual string ProjectName
		{
			get
			{
				return o_name;
			}
		}

		public virtual int Size
		{
			get
			{
				return hashMap.Count;
			}
		}

		public virtual GroupCode getGroupCode(string code)
		{
			return hashMap[code];
		}

		public virtual void remove(ProjectWBSTable gcTable)
		{
			//System.out.println("Removing "+gcTable);
			hashMap.Remove(gcTable.GroupCode);
		}

		public virtual void add(ProjectWBSTable gcTable)
		{
			//System.out.println("Adding "+gcTable);
			hashMap[gcTable.GroupCode] = (GroupCode)gcTable.clone();
		}

		public virtual void update(ProjectWBSTable gcTable)
		{
			//System.out.println("Updating "+gcTable);
			hashMap[gcTable.GroupCode] = (GroupCode)gcTable.clone();
		}

		public virtual void addOrUpdate(ProjectWBSTable obj)
		{
			if (hashMap[obj.GroupCode] == null)
			{
				add(obj);
			}
			else
			{
				update(obj);
			}
		}

		public virtual GroupCode[] SortedCodes
		{
			get
			{
				GroupCode[] groupCodes = hashMap.Values.toArray(new GroupCode[]{});
    
				string groupCodeStyle = CodingSystem;
    
				if (groupCodeStyle.Equals(DOTTED_GC_STYLE))
				{
					// we should short using a WBS Comparator
					Arrays.sort(groupCodes,new DottedGroupCodeComparator());
				}
				else
				{
					Arrays.sort(groupCodes);
				}
    
				return groupCodes;
			}
		}

		public virtual GroupCode[] getFullCodeTreePath(GroupCode[] groupCodes)
		{

			ISet<GroupCode> vector = new HashSet<GroupCode>();

			string codeSystem = CodingSystem;

			bool isAlphabetic = false;
			bool isRichardson = false;
			bool isNumeric5 = false;
			bool isNumeric6 = false;
			bool isDotted = false;

			foreach (GroupCode gc in groupCodes)
			{
				string code = gc.GroupCode;

				do
				{
					//				System.out.print("Parent of "+code+" = ");
					code = CodeUtils.getParentCodeOfCode(codeSystem, code);
					//				System.out.print(code+"\n");

					if (!string.ReferenceEquals(code, null))
					{
						GroupCode grp = getGroupCode(code);
						if (grp != null && !vector.Contains(grp))
						{
							vector.Add(grp);
						}
					}
				} while (!string.ReferenceEquals(code, null));

				vector.Add(gc);
				//			System.out.println("Reconstructing: GroupCode: "+gc);
			}

			GroupCode[] codes = vector.toArray(new GroupCode[]{});

			if (codeSystem.Equals(DOTTED_GC_STYLE))
			{
				// we should short using a WBS Comparator
				Arrays.sort(codes,new DottedGroupCodeComparator());
			}
			else
			{
				Arrays.sort(codes);
			}

			return codes;
		}

		public virtual TreeNode constructCodingTreeStructure()
		{
			GroupCode[] codes = SortedCodes;
			return constructCodingTreeStructure(codes,false);
		}

		public virtual TreeNode constructCodingTreeStructure(bool alwaysShowGroupPrefix)
		{
			GroupCode[] codes = SortedCodes;
			return constructCodingTreeStructure(codes,alwaysShowGroupPrefix);
		}

		public override int getLevelOfGroupCode(GroupCode groupCode)
		{
			int level = 0;

			string code = groupCode.GroupCode;

			do
			{
				code = CodeUtils.getParentCodeOfCode(DOTTED_GC_STYLE, code);
				if (!string.ReferenceEquals(code, null))
				{
					level = level + 1;
				}
			} while (!string.ReferenceEquals(code, null));

			return level;
		}

		public virtual TreeNode constructCodingTreeStructure(GroupCode[] codes, bool alwaysShowGroupPrefix)
		{
			if (codes == null)
			{
				codes = SortedCodes;
			}

			DefaultMutableTreeNode rootNode = new DefaultMutableTreeNode();

			Dictionary<string, DefaultMutableTreeNode> level1NodesMap = new Dictionary<string, DefaultMutableTreeNode>();
			Dictionary<string, DefaultMutableTreeNode> level2NodesMap = new Dictionary<string, DefaultMutableTreeNode>();
			Dictionary<string, DefaultMutableTreeNode> level3NodesMap = new Dictionary<string, DefaultMutableTreeNode>();
			Dictionary<string, DefaultMutableTreeNode> level4NodesMap = new Dictionary<string, DefaultMutableTreeNode>();
			Dictionary<string, DefaultMutableTreeNode> level5NodesMap = new Dictionary<string, DefaultMutableTreeNode>();
			Dictionary<string, DefaultMutableTreeNode> level6NodesMap = new Dictionary<string, DefaultMutableTreeNode>();
			Dictionary<string, DefaultMutableTreeNode> level7NodesMap = new Dictionary<string, DefaultMutableTreeNode>();
			Dictionary<string, DefaultMutableTreeNode> level8NodesMap = new Dictionary<string, DefaultMutableTreeNode>();
			Dictionary<string, DefaultMutableTreeNode> level9NodesMap = new Dictionary<string, DefaultMutableTreeNode>();

			int treeTableRowCount = 0;

			//System.out.println("--RECONSRUCTUING --");
			List<object> level1List = new List<object>(); // to keep correct indices
			// We must sort the vector by groupCode

			string groupCodeStyle = CodingSystem;

	//		boolean isAlphabetic = false;
			bool isRichardson = false;
			bool isNumeric5 = false;
			bool isNumeric6 = false;
			bool isDotted = false;

	//		if ( groupCodeStyle.equals(UIProperties.ALPHABETIC_GC_STYLE)) {
	//			isAlphabetic = true;
	//		}

			if (groupCodeStyle.Equals(RICHARDSON_GC_STYLE))
			{
				isRichardson = true;
			}

			if (groupCodeStyle.Equals(NUMERIC5_GC_STYLE))
			{
				isNumeric5 = true;
			}

			if (groupCodeStyle.Equals(NUMERIC6_GC_STYLE))
			{
				isNumeric6 = true;
			}

			if (groupCodeStyle.Equals(DOTTED_GC_STYLE))
			{
				isDotted = true;
			}

			foreach (GroupCode code in codes)
			{
				DefaultMutableTreeNode currentNode = new WBSTreeNode(this, code,alwaysShowGroupPrefix);

				string groupCode = code.GroupCode;

				bool isLevel1 = false;
				bool isLevel2 = false;
				bool isLevel3 = false;
				bool isLevel4 = false;
				bool isLevel5 = false;
				bool isLevel6 = false;
				bool isLevel7 = false;
				bool isLevel8 = false;
				bool isLevel9 = false;

				string level1 = null;
				string level2 = null;
				string level3 = null;
				string level4 = null;
				string level5 = null;
				string level6 = null;
				string level7 = null;
				string level8 = null;
				string level9 = null;

				// we put less than four due to sync errors :S
				if ((groupCode.Length < 4) && !isDotted)
				{
					// get level 1 groupCode node:
					if (groupCode.Length >= 1)
					{
						isLevel1 = true;
						level1 = "" + groupCode[0];
						level1NodesMap[level1] = currentNode;
					}
					if (groupCode.Length >= 2)
					{
						isLevel2 = true;
						level2 = "" + groupCode[0] + groupCode[1];
						level2NodesMap[level2] = currentNode;
					}
					if (groupCode.Length >= 3)
					{
						isLevel3 = true;
						level3 = "" + groupCode[0] + groupCode[1] + groupCode[2];
						level3NodesMap[level3] = currentNode;
					}
					if (groupCode.Length >= 4)
					{
						isLevel4 = true;
						level4 = "" + groupCode[0] + groupCode[1] + groupCode[2] + groupCode[3];
						level4NodesMap[level4] = currentNode;
					}
					if (groupCode.Length >= 5)
					{
						isLevel5 = true;
						level5 = "" + groupCode[0] + groupCode[1] + groupCode[2] + groupCode[3] + groupCode[4];
						level5NodesMap[level5] = currentNode;
					}
					if (groupCode.Length >= 6)
					{
						isLevel6 = true;
						level6 = "" + groupCode[0] + groupCode[1] + groupCode[2] + groupCode[3] + groupCode[4] + groupCode[5];
						level6NodesMap[level6] = currentNode;
					}
					if (groupCode.Length >= 7)
					{
						isLevel7 = true;
						level7 = "" + groupCode[0] + groupCode[1] + groupCode[2] + groupCode[3] + groupCode[4] + groupCode[5] + groupCode[6];
						level7NodesMap[level7] = currentNode;
					}
					if (groupCode.Length >= 8)
					{
						isLevel8 = true;
						level8 = "" + groupCode[0] + groupCode[1] + groupCode[2] + groupCode[3] + groupCode[4] + groupCode[5] + groupCode[6] + groupCode[7];
						level8NodesMap[level8] = currentNode;
					}
					if (groupCode.Length >= 9)
					{
						isLevel9 = true;
						level9 = "" + groupCode[0] + groupCode[1] + groupCode[2] + groupCode[3] + groupCode[4] + groupCode[5] + groupCode[6] + groupCode[7] + groupCode[8];
						level9NodesMap[level8] = currentNode;
					}
				}
				else if (isRichardson)
				{

					level1 = groupCode.Substring(0,3) + "000000000";
					level2 = groupCode.Substring(0,6) + "000000";
					level3 = groupCode;

					if (groupCode.EndsWith("000000000", StringComparison.Ordinal) && groupCode.Length == 12)
					{
						// only level1:
						isLevel1 = true;
						level1NodesMap[level1] = currentNode;
					}
					else if (groupCode.EndsWith("000000", StringComparison.Ordinal) && groupCode.Length == 12)
					{
						// only level 1,2
						isLevel2 = true;
						level2NodesMap[level2] = currentNode;
					}
					else if (groupCode.Length == 12)
					{
						isLevel3 = true;
						level3NodesMap[level3] = currentNode;
					}
				}
				else if (isNumeric5)
				{

					level1 = groupCode.Substring(0,2) + "000000";
					level2 = groupCode.Substring(0,4) + "0000";
					level3 = groupCode.Substring(0,6) + "00";
					level4 = groupCode;

					if (groupCode.EndsWith("000000", StringComparison.Ordinal) && groupCode.Length == 8)
					{
						// only level1:
						isLevel1 = true;
						level1NodesMap[groupCode] = currentNode;
					}
					else if (groupCode.EndsWith("0000", StringComparison.Ordinal) && groupCode.Length == 8)
					{
						// only level 1,2
						isLevel2 = true;
						level2NodesMap[groupCode] = currentNode;
					}
					else if (groupCode.EndsWith("00", StringComparison.Ordinal) && groupCode.Length == 8)
					{
						// only level 1,2
						isLevel3 = true;
						level3NodesMap[groupCode] = currentNode;
					}
					else if (groupCode.Length == 8)
					{
						// only level 1,2
						isLevel4 = true;
						level4NodesMap[groupCode] = currentNode;
					}
				}
				else if (isNumeric6)
				{

					level1 = groupCode.Substring(0,2) + "00000000";
					level2 = groupCode.Substring(0,4) + "000000";
					level3 = groupCode.Substring(0,6) + "0000";
					level4 = groupCode.Substring(0,8) + "00";
					level5 = groupCode;

					if (groupCode.EndsWith("00000000", StringComparison.Ordinal) && groupCode.Length == 10)
					{
						// only level1:
						isLevel1 = true;
						level1NodesMap[groupCode] = currentNode;
					}
					else if (groupCode.EndsWith("000000", StringComparison.Ordinal) && groupCode.Length == 10)
					{
						// only level 1,2
						isLevel2 = true;
						level2NodesMap[groupCode] = currentNode;
					}
					else if (groupCode.EndsWith("0000", StringComparison.Ordinal) && groupCode.Length == 10)
					{
						// only level 1,2
						isLevel3 = true;
						level3NodesMap[groupCode] = currentNode;
					}
					else if (groupCode.EndsWith("00", StringComparison.Ordinal) && groupCode.Length == 10)
					{
						// only level 1,2
						isLevel4 = true;
						level4NodesMap[groupCode] = currentNode;
					}
					else if (groupCode.Length == 10)
					{
						// only level 1,2
						isLevel5 = true;
						level5NodesMap[groupCode] = currentNode;
					}
				}
				else if (isDotted && groupCode.Length > 0)
				{
					string[] gcs = groupCode.Split("\\.",9);

					if (gcs.Length == 1)
					{
						isLevel1 = true;
						level1 = groupCode;
						level1NodesMap[groupCode] = currentNode;
					}
					else if (gcs.Length == 2)
					{
						isLevel2 = true;
						level1 = gcs[0];
						level2 = groupCode;
						level2NodesMap[groupCode] = currentNode;
					}
					else if (gcs.Length == 3)
					{
						isLevel3 = true;
						level1 = gcs[0];
						level2 = level1 + DOT + gcs[1];
						level3 = groupCode;
						level3NodesMap[groupCode] = currentNode;
					}
					else if (gcs.Length == 4)
					{
						isLevel4 = true;
						level1 = gcs[0];
						level2 = level1 + DOT + gcs[1];
						level3 = level2 + DOT + gcs[2];
						level4 = groupCode;
						level4NodesMap[groupCode] = currentNode;
					}
					else if (gcs.Length == 5)
					{
						isLevel5 = true;
						level1 = gcs[0];
						level2 = level1 + DOT + gcs[1];
						level3 = level2 + DOT + gcs[2];
						level4 = level3 + DOT + gcs[3];
						level5 = groupCode;
						level5NodesMap[groupCode] = currentNode;
					}
					else if (gcs.Length == 6)
					{
						isLevel6 = true;
						level1 = gcs[0];
						level2 = level1 + DOT + gcs[1];
						level3 = level2 + DOT + gcs[2];
						level4 = level3 + DOT + gcs[3];
						level5 = level4 + DOT + gcs[4];
						level6 = groupCode;
						level6NodesMap[groupCode] = currentNode;
					}
					else if (gcs.Length == 7)
					{
						isLevel7 = true;
						level1 = gcs[0];
						level2 = level1 + DOT + gcs[1];
						level3 = level2 + DOT + gcs[2];
						level4 = level3 + DOT + gcs[3];
						level5 = level4 + DOT + gcs[4];
						level6 = level5 + DOT + gcs[5];
						level7 = groupCode;
						level7NodesMap[groupCode] = currentNode;
					}
					else if (gcs.Length == 8)
					{
						isLevel8 = true;
						level1 = gcs[0];
						level2 = level1 + DOT + gcs[1];
						level3 = level2 + DOT + gcs[2];
						level4 = level3 + DOT + gcs[3];
						level5 = level4 + DOT + gcs[4];
						level6 = level5 + DOT + gcs[5];
						level7 = level6 + DOT + gcs[6];
						level8 = groupCode;
						level8NodesMap[groupCode] = currentNode;
					}
					else if (gcs.Length >= 9)
					{
						isLevel9 = true;
						level1 = gcs[0];
						level2 = level1 + DOT + gcs[1];
						level3 = level2 + DOT + gcs[2];
						level4 = level3 + DOT + gcs[3];
						level5 = level4 + DOT + gcs[4];
						level6 = level5 + DOT + gcs[5];
						level7 = level6 + DOT + gcs[6];
						level8 = level7 + DOT + gcs[7];
						level9 = groupCode;
						level9NodesMap[groupCode] = currentNode;
					}
				}
				else
				{
					level1 = groupCode.Substring(0,2) + "00";
					level2 = groupCode.Substring(0,3) + "0";
					level3 = groupCode;

					if (groupCode.EndsWith("00", StringComparison.Ordinal))
					{
						// only level1:
						isLevel1 = true;
						level1NodesMap[groupCode] = currentNode;
					}
					else if (groupCode.EndsWith("0", StringComparison.Ordinal))
					{
						// only level 1,2
						isLevel2 = true;
						level2NodesMap[groupCode] = currentNode;
					}
					else
					{
						isLevel3 = true;
						level3NodesMap[groupCode] = currentNode;
					}
				}


				if (isLevel9)
				{
					DefaultMutableTreeNode parentNode = level8NodesMap[level8];
					if (parentNode == null)
					{
						Console.WriteLine("CODE SYSTEM ERROR LEVEL: " + level8 + " NOT FOUND!");
					}
					else
					{
						parentNode.insert(currentNode, parentNode.ChildCount);
					}
				}
				else if (isLevel8)
				{
					DefaultMutableTreeNode parentNode = level7NodesMap[level7];
					if (parentNode == null)
					{
						Console.WriteLine("CODE SYSTEM ERROR LEVEL: " + level7 + " NOT FOUND!");
					}
					else
					{
						parentNode.insert(currentNode, parentNode.ChildCount);
					}
				}
				else if (isLevel7)
				{
					DefaultMutableTreeNode parentNode = level6NodesMap[level6];
					if (parentNode == null)
					{
						Console.WriteLine("CODE SYSTEM ERROR LEVEL: " + level6 + " NOT FOUND!");
					}
					else
					{
						parentNode.insert(currentNode, parentNode.ChildCount);
					}
				}
				else if (isLevel6)
				{
					DefaultMutableTreeNode parentNode = level5NodesMap[level5];
					if (parentNode == null)
					{
						Console.WriteLine("CODE SYSTEM ERROR LEVEL: " + level5 + " NOT FOUND!");
					}
					else
					{
						parentNode.insert(currentNode, parentNode.ChildCount);
					}
				}
				else if (isLevel5)
				{
					DefaultMutableTreeNode parentNode = level4NodesMap[level4];
					if (parentNode == null)
					{
						Console.WriteLine("CODE SYSTEM ERROR LEVEL: " + level4 + " NOT FOUND!");
					}
					else
					{
						parentNode.add(currentNode);
					}
				}
				else if (isLevel4)
				{
					DefaultMutableTreeNode parentNode = level3NodesMap[level3];
					if (parentNode == null)
					{
						Console.WriteLine("CODE SYSTEM ERROR LEVEL: " + level3 + " NOT FOUND!");
					}
					else
					{
						parentNode.add(currentNode);
					}
				}
				else if (isLevel3)
				{
					DefaultMutableTreeNode parentNode = level2NodesMap[level2];
					if (parentNode == null)
					{
						Console.WriteLine("CODE SYSTEM ERROR LEVEL: " + level2 + " NOT FOUND!");
					}
					else
					{
						parentNode.add(currentNode);
					}
				}
				else if (isLevel2)
				{
					DefaultMutableTreeNode parentNode = level1NodesMap[level1];
					if (parentNode == null)
					{
						Console.WriteLine("CODE SYSTEM ERROR LEVEL: " + level1 + " NOT FOUND!");
					}
					else
					{
						parentNode.add(currentNode);
					}
				}
				else if (isLevel1)
				{
					DefaultMutableTreeNode parentNode = rootNode;
					parentNode.add(currentNode);
				}
			}

			return rootNode;
		}

		public virtual DefaultMutableTreeNode findNodeByName(string nodeName)
		{
			DefaultMutableTreeNode rootNode = (DefaultMutableTreeNode)constructCodingTreeStructure();

			System.Collections.IEnumerator en = rootNode.postorderEnumeration();

			while (en.MoveNext())
			{
				DefaultMutableTreeNode currentNode = (DefaultMutableTreeNode)en.Current;

				GroupCode code = (GroupCode)currentNode.UserObject;

				if (code.ToString().Equals(nodeName))
				{
					return currentNode;
				}
			}


			return rootNode;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public synchronized void initializeCache() throws Exception
		public virtual void initializeCache()
		{
			lock (this)
			{
				bool hasOpenedSession = BaseDBUtil.hasOpenedSession();
				Session session = BaseDBUtil.currentSession();
        
				hashMap.Clear();
        
				//System.out.println("Seeking for: "+code);
        
				o_codingSystem = ProjectInfoTable.DOTTED_STYLE;
        
				IEnumerator<ProjectWBSTable> iter = session.createQuery("from ProjectWBSTable as o where o.projectId = " + BaseDBUtil.ProjectUrlId).list().GetEnumerator();
        
				while (iter.MoveNext())
				{
					ProjectWBSTable groupCodeTable = (ProjectWBSTable)iter.Current;
					//System.out.println("Adding: "+groupCodeTable);
					hashMap[groupCodeTable.GroupCode] = (GroupCode)groupCodeTable.clone();
				}
        
				/*
				Iterator<ProjectInfoTable> iter = session.createQuery("from ProjectInfoTable o where o.code = '"+o_code+"'").list().iterator();
		
				ProjectInfoTable prj = null;
		
				if ( isEnterprise && iter.hasNext() ) {
					prj = (ProjectInfoTable)session.load(ProjectInfoTable.class, iter.next().getProjectInfoId());
				}		
				else if ( iter.hasNext() ) {
					prj = iter.next();		
				}
		
				if ( prj != null ) {
					o_codingSystem = prj.getCodeStyle();
		
					Iterator iter1 = prj.getWbsSet().iterator();
		
					//System.out.println("Processing: "+prj);
					while ( iter1.hasNext() ) {
						ProjectWBSTable groupCodeTable = (ProjectWBSTable)iter1.next();
						//System.out.println("Adding: "+groupCodeTable);
						hashMap.put(groupCodeTable.getGroupCode(), (GroupCode)groupCodeTable.clone());
					}
				}*/
        
				if (hasOpenedSession == false)
				{
					BaseDBUtil.closeSession();
				}
			}
		}

		protected internal virtual ProjectDBUtil BaseDBUtil
		{
			get
			{
				return o_prjDbUtil; //DatabaseDBUtil.getCurrentDBUtil();
			}
		}

		public virtual string CodingSystem
		{
			get
			{
				return o_codingSystem;
			}
		}

		public class WBSTreeNode : DefaultMutableTreeNode
		{
			private readonly WBSCache outerInstance;


			internal GroupCode code;
			internal bool alwaysShowGroupPrefix;

			internal WBSTreeNode(WBSCache outerInstance, GroupCode code, bool alwaysShowGroupPrefix)
			{
				this.outerInstance = outerInstance;
				this.code = code;
				this.alwaysShowGroupPrefix = alwaysShowGroupPrefix;
				UserObject = code;
			}

			public virtual GroupCode GroupCode
			{
				get
				{
					return code;
				}
			}

			public override string ToString()
			{
				if (alwaysShowGroupPrefix)
				{
					return code.ToString();
				}
				else
				{
					return code.Title;
				}

	//			String separator = CodeUtils.getCodeToCodeSeparator("wbsCode");
	//			String titleSeparator = CodeUtils.getCodeToTitleSeparator("wbsCode");
	//			if ( !StringUtils.isNullOrBlank(titleSeparator) )				
	//				return StringUtils.replaceAll(code.getGroupCode(),".",separator)+" "+titleSeparator+" "+code.getTitle();
	//			return StringUtils.replaceAll(code.getGroupCode(),".",separator)+" "+code.getTitle();
			}
		}
	}

}