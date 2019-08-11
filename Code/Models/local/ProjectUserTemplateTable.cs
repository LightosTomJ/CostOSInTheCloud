using System;

namespace Models.local
{

	using BaseEntity = nomitech.common.@base.BaseEntity;
	//#RXP_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="PROJECTUSERTEMPLATE"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	public class ProjectUserTemplateTable : BaseEntity
	{

		public static readonly string[] FIELDS = new string[] {"id", "name", "editExchange", "editEscalate", "editProps", "editTakeoff", "editResource", "estimator", "administrator", "sendQuotes", "submitQuotes", "awardQuotes", "wbs", "addItems", "removeItems", "editItems", "viewAllItems", "variablesUser", "variablesAdmin", "variablesViewer", "createUserId", "createUserDate", "editorId", "lastUpdate"};

		private long? id;
		private string name;

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

		private string createUserId;

		private DateTime createUserDate;

		private string editorId;

		private DateTime lastUpdate;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="TEMPLATEID" </summary>
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

		/// <summary>
		/// @hibernate.property column="NAME" type="costos_string" </summary>
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
		/// @hibernate.property column="CREATEUSER" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string CreateUserId
		{
			get
			{
				return createUserId;
			}
			set
			{
				this.createUserId = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CREATEDATE" type="timestamp" </summary>
		/// <returns> description </returns>
		public virtual DateTime CreateUserDate
		{
			get
			{
				return createUserDate;
			}
			set
			{
				this.createUserDate = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="EDITORID" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string EditorId
		{
			get
			{
				return editorId;
			}
			set
			{
				this.editorId = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="LASTUPDATE" type="timestamp" </summary>
		/// <returns> description </returns>
		public virtual DateTime LastUpdate
		{
			get
			{
				return lastUpdate;
			}
			set
			{
				this.lastUpdate = value;
			}
		}


		public virtual object clone()
		{
			ProjectUserTemplateTable obj = new ProjectUserTemplateTable();
			obj.Id = Id;
			obj.Data = this;
			return obj;
		}

		public virtual ProjectUserTemplateTable Data
		{
			set
			{
				Name = value.Name;
    
				CreateUserId = value.CreateUserId;
				CreateUserDate = value.CreateUserDate;
				EditorId = value.EditorId;
				LastUpdate = value.LastUpdate;
    
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

		public override string ToString()
		{
			return Name + " [" + EditorId + "]";
		}

	}

}