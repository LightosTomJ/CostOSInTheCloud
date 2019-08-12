using System.Collections.Generic;

namespace Model.local
{

	using BaseEntity = Desktop.common.nomitech.common.@base.BaseEntity;
	//#RXP_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="PROJECTUSER"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	public class ProjectUserTable : BaseEntity
	{

		public static readonly string[] FIELDS = new string[] {"id", "userId", "name", "email", "editExchange", "editEscalate", "editProps", "editTakeoff", "editResource", "estimator", "administrator", "sendQuotes", "submitQuotes", "awardQuotes", "wbs", "addItems", "removeItems", "editItems", "viewAllItems", "variablesUser", "variablesAdmin", "variablesViewer"};

		private long? id;
		private string userId;
		private string name;
		private string email;
		// Add on access:
		private bool? editExchange;
		private bool? editEscalate;
		private bool? editProps;
		private bool? editTakeoff;
		private bool? editResource;
		private bool? estimator;
		private bool? administrator;
		private bool? sendQuotes;
		private bool? submitQuotes;
		private bool? awardQuotes;
		private bool? wbs;
		private bool? addItems;
		private bool? removeItems;
		private bool? editItems;
		private bool? viewAllItems;
		private bool? variablesUser;
		private bool? variablesAdmin;
		private bool? variablesViewer;

		private ProjectInfoTable projectInfoTable;
		private ISet<ProjectAccessRuleTable> accessRules;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="PUID" </summary>
		/// <returns> Long </returns>
		public virtual long? Id
		{
			get
			{
				return id;
			}
			set
			{
				this.id = value;
			}
		}

		public virtual object clone()
		{
			ProjectUserTable obj = new ProjectUserTable();
			obj.Id = Id;
			obj.UserId = UserId;
			obj.Name = Name;
			obj.Email = Email;
			obj.EditExchange = EditExchange;
			obj.EditEscalate = EditEscalate;
			obj.EditProps = EditProps;
			obj.EditTakeoff = EditTakeoff;
			obj.EditResource = EditResource;
			obj.Estimator = Estimator;
			obj.Administrator = Administrator;
			obj.SubmitQuotes = SubmitQuotes;
			obj.SendQuotes = SendQuotes;
			obj.AwardQuotes = AwardQuotes;
			obj.Wbs = Wbs;
			obj.AddItems = AddItems;
			obj.EditItems = EditItems;
			obj.RemoveItems = RemoveItems;
			obj.ViewAllItems = ViewAllItems;
			obj.VariablesUser = VariablesUser;
			obj.VariablesAdmin = VariablesAdmin;
			obj.VariablesViewer = VariablesViewer;

			return obj;
		}

		public virtual ProjectUserTable Data
		{
			set
			{
				// setId(value.getId());
				UserId = value.UserId;
				Name = value.Name;
				Email = value.Email;
				EditExchange = value.EditExchange;
				EditEscalate = value.EditEscalate;
				EditProps = value.EditProps;
				EditTakeoff = value.EditTakeoff;
				EditResource = value.EditResource;
				Estimator = value.Estimator;
				Administrator = value.Administrator;
				SubmitQuotes = value.SubmitQuotes;
				SendQuotes = value.SendQuotes;
				AwardQuotes = value.AwardQuotes;
				Wbs = value.Wbs;
				AddItems = value.AddItems;
				EditItems = value.EditItems;
				RemoveItems = value.RemoveItems;
				ViewAllItems = value.ViewAllItems;
				VariablesUser = value.VariablesUser;
				VariablesAdmin = value.VariablesAdmin;
				VariablesViewer = value.VariablesViewer;
			}
		}

		public virtual ProjectUserTable copyWithProject()
		{
			ProjectUserTable userTable = (ProjectUserTable)clone();

			if (ProjectInfoTable != null)
			{
				userTable.ProjectInfoTable = (ProjectInfoTable)ProjectInfoTable.Clone();
			}

			return userTable;
		}

		public virtual ProjectUserTable copyWithAccessRoles()
		{
			ProjectUserTable userTable = (ProjectUserTable)copyWithProject();

			userTable.AccessRules = new HashSet<ProjectAccessRuleTable>();
			if (AccessRules != null)
			{
				foreach (ProjectAccessRuleTable ruleTable in AccessRules)
				{
					ruleTable = (ProjectAccessRuleTable) ruleTable.clone();
					userTable.AccessRules.Add(ruleTable);
				}
			}

			return userTable;
		}

		/// <summary>
		/// @hibernate.property column="USERID" type="costos_string" index="IDX_USERID" </summary>
		/// <returns> code </returns>
		public virtual string UserId
		{
			get
			{
				return userId;
			}
			set
			{
				this.userId = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="UNAME" type="costos_string" </summary>
		/// <returns> code </returns>
		public virtual string Name
		{
			get
			{
				return name;
			}
			set
			{
				this.name = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EMAIL" type="costos_string" </summary>
		/// <returns> code </returns>
		public virtual string Email
		{
			get
			{
				return email;
			}
			set
			{
				this.email = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="XCHANGE" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? EditExchange
		{
			get
			{
				return editExchange;
			}
			set
			{
				this.editExchange = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="ESCLTE" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? EditEscalate
		{
			get
			{
				return editEscalate;
			}
			set
			{
				this.editEscalate = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="PROPS" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? EditProps
		{
			get
			{
				return editProps;
			}
			set
			{
				this.editProps = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="TAKEOFF" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? EditTakeoff
		{
			get
			{
				return editTakeoff;
			}
			set
			{
				this.editTakeoff = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RSRC" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? EditResource
		{
			get
			{
				return editResource;
			}
			set
			{
				this.editResource = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="ESTIM" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? Estimator
		{
			get
			{
				return estimator;
			}
			set
			{
				this.estimator = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="ADMN" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? Administrator
		{
			get
			{
				return administrator;
			}
			set
			{
				this.administrator = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="SQUOTE" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? SendQuotes
		{
			get
			{
				return sendQuotes;
			}
			set
			{
				this.sendQuotes = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RQUOTE" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? SubmitQuotes
		{
			get
			{
				return submitQuotes;
			}
			set
			{
				this.submitQuotes = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="AQUOTE" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? AwardQuotes
		{
			get
			{
				return awardQuotes;
			}
			set
			{
				this.awardQuotes = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="WBS" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? Wbs
		{
			get
			{
				return wbs;
			}
			set
			{
				this.wbs = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="ADITMS" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? AddItems
		{
			get
			{
				return addItems;
			}
			set
			{
				this.addItems = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RMITMS" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? RemoveItems
		{
			get
			{
				return removeItems;
			}
			set
			{
				this.removeItems = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EDITMS" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? EditItems
		{
			get
			{
				return editItems;
			}
			set
			{
				this.editItems = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="VAITMS" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? ViewAllItems
		{
			get
			{
				return viewAllItems;
			}
			set
			{
				this.viewAllItems = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="VARSUSR" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? VariablesUser
		{
			get
			{
				return variablesUser;
			}
			set
			{
				this.variablesUser = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="VARSADMIN" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? VariablesAdmin
		{
			get
			{
				return variablesAdmin;
			}
			set
			{
				this.variablesAdmin = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="VARSVIEWER" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? VariablesViewer
		{
			get
			{
				return variablesViewer;
			}
			set
			{
				this.variablesViewer = value;
			}
		}

		/// <summary>
		/// @hibernate.many-to-one
		///  column="PROJECTINFOID"
		///  cascade="none" </summary>
		/// <returns> ProjectInfoTable </returns>
		public virtual ProjectInfoTable ProjectInfoTable
		{
			get
			{
				return projectInfoTable;
			}
			set
			{
				this.projectInfoTable = value;
			}
		}

		/// <summary>
		/// @hibernate.set
		///  inverse="false"
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="PUID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.ProjectAccessRuleTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<ProjectAccessRuleTable> AccessRules
		{
			get
			{
				return accessRules;
			}
			set
			{
				this.accessRules = value;
			}
		}
	}

}