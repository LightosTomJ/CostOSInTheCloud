namespace Models.view.data
{
	using DataObjectDescriptor = nomitech.common.data.descriptor.DataObjectDescriptor;
	using UILanguage = nomitech.common.ui.UILanguage;

	public class GroupCodeNamesView
	{
		public static readonly DataObjectDescriptor[] SQLFIELDS = new DataObjectDescriptor[]
		{
			new DataObjectDescriptor("groupSeperator","groupSeperator",UILanguage.get("tab.projectdefaults.contractorname"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("titleSeperator","titleSeperator", UILanguage.get("tab.projectdefaults.contractorlogo"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("wbs1ShowID","wbs1ShowID", UILanguage.get("tab.localdatabase.groupshowid"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("wbs1DivisionId","wbs1DivisionId", UILanguage.get("tab.localdatabase.groupdivshowid"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("wbs1Seperator","wbs1Seperator", UILanguage.get("tab.localdatabase.groupseparator"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("wbs1TitleSeperator","wbs1TitleSeperator", UILanguage.get("tab.localdatabase.grouptitleseparator"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("wbs2Code","wbs2Code", UILanguage.get("tab.localdatabase.groupshowid"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("wbs2division","wbs2division", UILanguage.get("tab.localdatabase.groupdivshowid"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("wbs2Seperator","wbs2Seperator",UILanguage.get("tab.localdatabase.groupseparator"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("wbs2Seperator","wbs2Seperator",UILanguage.get("tab.localdatabase.grouptitleseparator"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode1Id","groupCode1Id", UILanguage.get("tab.localdatabase.groupshowid"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode1Division","groupCode1Division", UILanguage.get("tab.localdatabase.groupdivshowid"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode1Seperator","groupCode1Seperator", UILanguage.get("tab.localdatabase.groupseparator"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode1TitleSeperator","groupCode1TitleSeperator", UILanguage.get("tab.localdatabase.grouptitleseparator"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode2Id","groupCode2Id",UILanguage.get("tab.localdatabase.groupshowid"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode2Division","groupCode2Division", UILanguage.get("tab.localdatabase.groupdivshowid"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode2Seperator","groupCode2Seperator",UILanguage.get("tab.localdatabase.groupseparator"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode2TitleSeperator","groupCode2TitleSeperator", UILanguage.get("tab.localdatabase.grouptitleseparator"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode3Id","groupCode3Id",UILanguage.get("tab.localdatabase.groupshowid"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode3Division","groupCode3Division",UILanguage.get("tab.localdatabase.groupdivshowid"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode3Seperator","groupCode3Seperator", UILanguage.get("tab.localdatabase.groupseparator"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode3TitleSeperator","groupCode3TitleSeperator", UILanguage.get("tab.localdatabase.grouptitleseparator"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode4Id","groupCode4Id", UILanguage.get("tab.localdatabase.groupshowid"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode4Division","groupCode4Division", UILanguage.get("tab.localdatabase.groupdivshowid"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode4Seperator","groupCode4Seperator", UILanguage.get("tab.localdatabase.groupseparator"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode4TitleSeperator","groupCode4TitleSeperator", UILanguage.get("tab.localdatabase.grouptitleseparator"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode5Id","groupCode5Id", UILanguage.get("tab.localdatabase.groupshowid"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode5Division","groupCode5Division", UILanguage.get("tab.localdatabase.groupdivshowid"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode5Seperator","groupCode5Seperator", UILanguage.get("tab.localdatabase.groupseparator"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode5TitleSeperator","groupCode5TitleSeperator", UILanguage.get("tab.localdatabase.grouptitleseparator"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode6Id","groupCode6Id", UILanguage.get("tab.localdatabase.groupshowid"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode6Division","groupCode6Division", UILanguage.get("tab.localdatabase.groupdivshowid"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode6Seperator","groupCode6Seperator", UILanguage.get("tab.localdatabase.groupseparator"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode6TitleSeperator","groupCode6TitleSeperator", UILanguage.get("tab.localdatabase.groupseparator"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode7Id","groupCode7Id", UILanguage.get("tab.localdatabase.groupshowid"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode7DivisionId","groupCode7DivisionId", UILanguage.get("tab.localdatabase.groupdivshowid"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode7Seperator","groupCode7Seperator", UILanguage.get("tab.localdatabase.groupseparator"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode7TitleSeperator","groupCode7TitleSeperator", UILanguage.get("tab.localdatabase.grouptitleseparator"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode8Id","groupCode8Id", UILanguage.get("tab.localdatabase.groupshowid"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode8DivisionId","groupCode8DivisionId", UILanguage.get("tab.localdatabase.groupdivshowid"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode8DivisionSeperator","groupCode8DivisionSeperator", UILanguage.get("tab.localdatabase.groupseparator"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode8TitleSeperator","groupCode8TitleSeperator", UILanguage.get("tab.localdatabase.grouptitleseparator"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode9Id","groupCode9Id", UILanguage.get("tab.localdatabase.groupshowid"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode9Division","groupCode9Division", UILanguage.get("tab.localdatabase.groupdivshowid"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode9seperator","groupCode9seperator", UILanguage.get("tab.localdatabase.groupseparator"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode9titleSeperator","groupCode9titleSeperator", UILanguage.get("tab.localdatabase.grouptitleseparator"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("wbs1Name","wbs1Name", UILanguage.get("tab.grouping.wbs1CodeName"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("wbs2Name","wbs2Name",UILanguage.get("tab.grouping.wbs2CodeName"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode1DisplayName","groupCode1DisplayName", UILanguage.get("tab.grouping.groupCode1Name"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode2DisplayName","groupCode2DisplayName", UILanguage.get("tab.grouping.groupCode2Name"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode3DisplayName","groupCode3DisplayName", UILanguage.get("tab.grouping.groupCode3Name"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode4DisplayName","groupCode4DisplayName", UILanguage.get("tab.grouping.groupCode4Name"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode5DisplayName","groupCode5DisplayName", UILanguage.get("tab.grouping.groupCode5Name"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode6DisplayName","groupCode6DisplayName",UILanguage.get("tab.grouping.groupCode6Name"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode7DisplayName","groupCode7DisplayName", UILanguage.get("tab.grouping.groupCode7Name"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode8DisplayName","groupCode8DisplayName", UILanguage.get("tab.grouping.groupCode8Name"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode9DisplayName","groupCode9DisplayName", UILanguage.get("tab.grouping.groupCode9Name"), DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode1Style","groupCode1Style", UILanguage.get("tab.localdatabase.codestyle") + "for groupcode 1", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode2Style","groupCode2Style", UILanguage.get("tab.localdatabase.codestyle") + "for groupcode 2", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode3Style","groupCode3Style", UILanguage.get("tab.localdatabase.codestyle") + "for groupcode 3", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode4Style","groupCode4Style", UILanguage.get("tab.localdatabase.codestyle") + "for groupcode 4", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode5Style","groupCode5Style", UILanguage.get("tab.localdatabase.codestyle") + "for groupcode 5", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode6Style","groupCode6Style", UILanguage.get("tab.localdatabase.codestyle") + "for groupcode 6", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode7Style","groupCode7Style", UILanguage.get("tab.localdatabase.codestyle") + "for groupcode 7", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode8Style","groupCode8Style", UILanguage.get("tab.localdatabase.codestyle") + "for groupcode 8", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("groupCode9Style","groupCode9Style", UILanguage.get("tab.localdatabase.codestyle") + "for groupcode 9", DataObjectDescriptor.TEXT_TYPE)
		};

		private string groupSeperator;
		private string titleSeperator;

		private string wbs1ShowID;
		private string wbs1DivisionId;
		private string wbs1Seperator;
		private string wbs1TitleSeperator;

		private string wbs2Code;
		private string wbs2division;
		private string wbs2Seperator;
		private string wbs2TitleSeperator;

		private string groupCode1Id;
		private string groupCode1Division;
		private string groupCode1Seperator;
		private string groupCode1TitleSeperator;

		private string groupCode2Id;
		private string groupCode2Division;
		private string groupCode2Seperator;
		private string groupCode2TitleSeperator;

		private string groupCode3Id;
		private string groupCode3Division;
		private string groupCode3Seperator;
		private string groupCode3TitleSeperator;

		private string groupCode4Id;
		private string groupCode4Division;
		private string groupCode4Seperator;
		private string groupCode4TitleSeperator;

		private string groupCode5Id;
		private string groupCode5Division;
		private string groupCode5Seperator;
		private string groupCode5TitleSeperator;

		private string groupCode6Id;
		private string groupCode6Division;
		private string groupCode6Seperator;
		private string groupCode6TitleSeperator;

		private string groupCode7Id;
		private string groupCode7DivisionId;
		private string groupCode7Seperator;
		private string groupCode7TitleSeperator;

		private string groupCode8Id;
		private string groupCode8DivisionId;
		private string groupCode8DivisionSeperator;
		private string groupCode8TitleSeperator;

		private string groupCode9Id;
		private string groupCode9Division;
		private string groupCode9seperator;
		private string groupCode9titleSeperator;

		private string wbs1Name;
		private string wbs2Name;

		private string groupCode1DisplayName;
		private string groupCode2DisplayName;
		private string groupCode3DisplayName;
		private string groupCode4DisplayName;
		private string groupCode5DisplayName;
		private string groupCode6DisplayName;
		private string groupCode7DisplayName;

		private string groupCode8DisplayName;
		private string groupCode9DisplayName;

		private string groupCode1Style;
		private string groupCode2Style;
		private string groupCode3Style;
		private string groupCode4Style;
		private string groupCode5Style;
		private string groupCode6Style;
		private string groupCode7Style;
		private string groupCode8Style;
		private string groupCode9Style;

		public virtual string GroupSeperator
		{
			get
			{
				return groupSeperator;
			}
			set
			{
				this.groupSeperator = value;
			}
		}
		public virtual string TitleSeperator
		{
			get
			{
				return titleSeperator;
			}
			set
			{
				this.titleSeperator = value;
			}
		}
		public virtual string Wbs1ShowID
		{
			get
			{
				return wbs1ShowID;
			}
			set
			{
				this.wbs1ShowID = value;
			}
		}
		public virtual string Wbs1DivisionId
		{
			get
			{
				return wbs1DivisionId;
			}
			set
			{
				this.wbs1DivisionId = value;
			}
		}
		public virtual string Wbs1Seperator
		{
			get
			{
				return wbs1Seperator;
			}
			set
			{
				this.wbs1Seperator = value;
			}
		}
		public virtual string Wbs1TitleSeperator
		{
			get
			{
				return wbs1TitleSeperator;
			}
			set
			{
				this.wbs1TitleSeperator = value;
			}
		}
		public virtual string Wbs2Code
		{
			get
			{
				return wbs2Code;
			}
			set
			{
				this.wbs2Code = value;
			}
		}
		public virtual string Wbs2division
		{
			get
			{
				return wbs2division;
			}
			set
			{
				this.wbs2division = value;
			}
		}
		public virtual string Wbs2Seperator
		{
			get
			{
				return wbs2Seperator;
			}
			set
			{
				this.wbs2Seperator = value;
			}
		}
		public virtual string Wbs2TitleSeperator
		{
			get
			{
				return wbs2TitleSeperator;
			}
			set
			{
				this.wbs2TitleSeperator = value;
			}
		}
		public virtual string GroupCode1Id
		{
			get
			{
				return groupCode1Id;
			}
			set
			{
				this.groupCode1Id = value;
			}
		}
		public virtual string GroupCode1Division
		{
			get
			{
				return groupCode1Division;
			}
			set
			{
				this.groupCode1Division = value;
			}
		}
		public virtual string GroupCode1Seperator
		{
			get
			{
				return groupCode1Seperator;
			}
			set
			{
				this.groupCode1Seperator = value;
			}
		}
		public virtual string GroupCode1TitleSeperator
		{
			get
			{
				return groupCode1TitleSeperator;
			}
			set
			{
				this.groupCode1TitleSeperator = value;
			}
		}
		public virtual string GroupCode2Id
		{
			get
			{
				return groupCode2Id;
			}
			set
			{
				this.groupCode2Id = value;
			}
		}
		public virtual string GroupCode2Division
		{
			get
			{
				return groupCode2Division;
			}
			set
			{
				this.groupCode2Division = value;
			}
		}
		public virtual string GroupCode2Seperator
		{
			get
			{
				return groupCode2Seperator;
			}
			set
			{
				this.groupCode2Seperator = value;
			}
		}
		public virtual string GroupCode2TitleSeperator
		{
			get
			{
				return groupCode2TitleSeperator;
			}
			set
			{
				this.groupCode2TitleSeperator = value;
			}
		}
		public virtual string GroupCode3Id
		{
			get
			{
				return groupCode3Id;
			}
			set
			{
				this.groupCode3Id = value;
			}
		}
		public virtual string GroupCode3Division
		{
			get
			{
				return groupCode3Division;
			}
			set
			{
				this.groupCode3Division = value;
			}
		}
		public virtual string GroupCode3Seperator
		{
			get
			{
				return groupCode3Seperator;
			}
			set
			{
				this.groupCode3Seperator = value;
			}
		}
		public virtual string GroupCode3TitleSeperator
		{
			get
			{
				return groupCode3TitleSeperator;
			}
			set
			{
				this.groupCode3TitleSeperator = value;
			}
		}
		public virtual string GroupCode4Id
		{
			get
			{
				return groupCode4Id;
			}
			set
			{
				this.groupCode4Id = value;
			}
		}
		public virtual string GroupCode4Division
		{
			get
			{
				return groupCode4Division;
			}
			set
			{
				this.groupCode4Division = value;
			}
		}
		public virtual string GroupCode4Seperator
		{
			get
			{
				return groupCode4Seperator;
			}
			set
			{
				this.groupCode4Seperator = value;
			}
		}
		public virtual string GroupCode4TitleSeperator
		{
			get
			{
				return groupCode4TitleSeperator;
			}
			set
			{
				this.groupCode4TitleSeperator = value;
			}
		}
		public virtual string GroupCode5Id
		{
			get
			{
				return groupCode5Id;
			}
			set
			{
				this.groupCode5Id = value;
			}
		}
		public virtual string GroupCode5division
		{
			get
			{
				return groupCode5Division;
			}
		}
		public virtual string GroupCode5Division
		{
			set
			{
				this.groupCode5Division = value;
			}
			get
			{
				return groupCode5Division;
			}
		}
		public virtual string GroupCode5Seperator
		{
			get
			{
				return groupCode5Seperator;
			}
			set
			{
				this.groupCode5Seperator = value;
			}
		}
		public virtual string GroupCode5TitleSeperator
		{
			get
			{
				return groupCode5TitleSeperator;
			}
			set
			{
				this.groupCode5TitleSeperator = value;
			}
		}
		public virtual string GroupCode6Id
		{
			get
			{
				return groupCode6Id;
			}
			set
			{
				this.groupCode6Id = value;
			}
		}
		public virtual string GroupCode6Division
		{
			get
			{
				return groupCode6Division;
			}
			set
			{
				this.groupCode6Division = value;
			}
		}
		public virtual string GroupCode6Seperator
		{
			get
			{
				return groupCode6Seperator;
			}
			set
			{
				this.groupCode6Seperator = value;
			}
		}
		public virtual string GroupCode6TitleSeperator
		{
			get
			{
				return groupCode6TitleSeperator;
			}
			set
			{
				this.groupCode6TitleSeperator = value;
			}
		}
		public virtual string GroupCode7Id
		{
			get
			{
				return groupCode7Id;
			}
			set
			{
				this.groupCode7Id = value;
			}
		}
		public virtual string GroupCode7DivisionId
		{
			get
			{
				return groupCode7DivisionId;
			}
			set
			{
				this.groupCode7DivisionId = value;
			}
		}
		public virtual string GroupCode7Seperator
		{
			get
			{
				return groupCode7Seperator;
			}
			set
			{
				this.groupCode7Seperator = value;
			}
		}
		public virtual string GroupCode7TitleSeperator
		{
			get
			{
				return groupCode7TitleSeperator;
			}
			set
			{
				this.groupCode7TitleSeperator = value;
			}
		}
		public virtual string GroupCode8Id
		{
			get
			{
				return groupCode8Id;
			}
			set
			{
				this.groupCode8Id = value;
			}
		}
		public virtual string GroupCode8DivisionId
		{
			get
			{
				return groupCode8DivisionId;
			}
			set
			{
				this.groupCode8DivisionId = value;
			}
		}
		public virtual string GroupCode8DivisionSeperator
		{
			get
			{
				return groupCode8DivisionSeperator;
			}
			set
			{
				this.groupCode8DivisionSeperator = value;
			}
		}

		public virtual string GroupCode8TitleSeperator
		{
			get
			{
				return groupCode8TitleSeperator;
			}
			set
			{
				this.groupCode8TitleSeperator = value;
			}
		}
		public virtual string GroupCode9Id
		{
			get
			{
				return groupCode9Id;
			}
			set
			{
				this.groupCode9Id = value;
			}
		}
		public virtual string GroupCode9Division
		{
			get
			{
				return groupCode9Division;
			}
			set
			{
				this.groupCode9Division = value;
			}
		}
		public virtual string GroupCode9seperator
		{
			get
			{
				return groupCode9seperator;
			}
			set
			{
				this.groupCode9seperator = value;
			}
		}
		public virtual string GroupCode9titleSeperator
		{
			get
			{
				return groupCode9titleSeperator;
			}
			set
			{
				this.groupCode9titleSeperator = value;
			}
		}
		public virtual string Wbs1Name
		{
			get
			{
				return wbs1Name;
			}
			set
			{
				this.wbs1Name = value;
			}
		}
		public virtual string Wbs2Name
		{
			get
			{
				return wbs2Name;
			}
			set
			{
				this.wbs2Name = value;
			}
		}
		public virtual string GroupCode1DisplayName
		{
			get
			{
				return groupCode1DisplayName;
			}
			set
			{
				this.groupCode1DisplayName = value;
			}
		}
		public virtual string GroupCode2DisplayName
		{
			get
			{
				return groupCode2DisplayName;
			}
			set
			{
				this.groupCode2DisplayName = value;
			}
		}
		public virtual string GroupCode3DisplayName
		{
			get
			{
				return groupCode3DisplayName;
			}
			set
			{
				this.groupCode3DisplayName = value;
			}
		}
		public virtual string GroupCode4DisplayName
		{
			get
			{
				return groupCode4DisplayName;
			}
			set
			{
				this.groupCode4DisplayName = value;
			}
		}
		public virtual string GroupCode5DisplayName
		{
			get
			{
				return groupCode5DisplayName;
			}
			set
			{
				this.groupCode5DisplayName = value;
			}
		}
		public virtual string GroupCode6DisplayName
		{
			get
			{
				return groupCode6DisplayName;
			}
			set
			{
				this.groupCode6DisplayName = value;
			}
		}
		public virtual string GroupCode7DisplayName
		{
			get
			{
				return groupCode7DisplayName;
			}
			set
			{
				this.groupCode7DisplayName = value;
			}
		}
		public virtual string GroupCode8DisplayName
		{
			get
			{
				return groupCode8DisplayName;
			}
			set
			{
				this.groupCode8DisplayName = value;
			}
		}
		public virtual string GroupCode9DisplayName
		{
			get
			{
				return groupCode9DisplayName;
			}
			set
			{
				this.groupCode9DisplayName = value;
			}
		}
		public virtual string GroupCode1Style
		{
			get
			{
				return groupCode1Style;
			}
			set
			{
				this.groupCode1Style = value;
			}
		}
		public virtual string GroupCode2Style
		{
			get
			{
				return groupCode2Style;
			}
			set
			{
				this.groupCode2Style = value;
			}
		}
		public virtual string GroupCode3Style
		{
			get
			{
				return groupCode3Style;
			}
			set
			{
				this.groupCode3Style = value;
			}
		}
		public virtual string GroupCode4Style
		{
			get
			{
				return groupCode4Style;
			}
			set
			{
				this.groupCode4Style = value;
			}
		}
		public virtual string GroupCode5Style
		{
			get
			{
				return groupCode5Style;
			}
			set
			{
				this.groupCode5Style = value;
			}
		}
		public virtual string GroupCode6Style
		{
			get
			{
				return groupCode6Style;
			}
			set
			{
				this.groupCode6Style = value;
			}
		}
		public virtual string GroupCode7Style
		{
			get
			{
				return groupCode7Style;
			}
			set
			{
				this.groupCode7Style = value;
			}
		}
		public virtual string GroupCode8Style
		{
			get
			{
				return groupCode8Style;
			}
			set
			{
				this.groupCode8Style = value;
			}
		}
		public virtual string GroupCode9Style
		{
			get
			{
				return groupCode9Style;
			}
			set
			{
				this.groupCode9Style = value;
			}
		}
		public static DataObjectDescriptor[] Sqlfields
		{
			get
			{
				return SQLFIELDS;
			}
		}


	}
}