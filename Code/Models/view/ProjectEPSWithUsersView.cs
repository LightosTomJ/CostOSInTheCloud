using System;

namespace Models.view
{

	[Serializable]
	public class ProjectEPSWithUsersView
	{

		private string epsLevel1Code;
		private string epsLevel2Code;
		private string epsLevel3Code;
		private string epsLevel4Code;
		private string epsLevel5Code;
		private string epsLevel6Code;
		private string epsLevel7Code;
		private string epsLevel8Code;
		private string epsLevel9Code;

		private string epsLevel1Title;
		private string epsLevel2Title;
		private string epsLevel3Title;
		private string epsLevel4Title;
		private string epsLevel5Title;
		private string epsLevel6Title;
		private string epsLevel7Title;
		private string epsLevel8Title;
		private string epsLevel9Title;


		private long? defaultProjectId;
		private string defaultProjectCode;
		private string defaultProjectTitle;
		private string defaultProjectDescription;
		private string defaultProjectCreatorId;
		private DateTime defaultProjectCreateDate;
		private string defaultProjectEditorId;
		private DateTime defaultProjectLastUpdate;
		private string defaultProjectStatus;
		private string defaultProjectCurrency;
		private decimal defaultProjectTotalCost;
		private decimal defaultProjectOfferedPrice;

		private string defaultProjectGeoLocation;
		private string defaultProjectLocation;
		private string defaultProjectCountry;
		private string defaultProjectState;
		private string defaultProjectClient;

		private string userId;
		private string userName;
		private string userEmail;
		private bool? userXchange;
		private bool? userEsclte;
		private bool? userProps;

		private bool? userTakeoff;
		private bool? userEstimator;
		private bool? userAdmin;
		private bool? userSQuote;
		private bool? userRQuote;
		private bool? userRSRC;

		private bool? userAQuote;
		private bool? userWbs;
		private bool? userAditms;
		private bool? userRditms;
		private bool? userEditms;

		private bool? userVaitms;
		private bool? userVarSusr;
		private bool? userVarsAdmin;
		public virtual string EpsLevel1Code
		{
			get
			{
				return epsLevel1Code;
			}
			set
			{
				this.epsLevel1Code = value;
			}
		}
		public virtual string EpsLevel2Code
		{
			get
			{
				return epsLevel2Code;
			}
			set
			{
				this.epsLevel2Code = value;
			}
		}
		public virtual string EpsLevel3Code
		{
			get
			{
				return epsLevel3Code;
			}
			set
			{
				this.epsLevel3Code = value;
			}
		}
		public virtual string EpsLevel4Code
		{
			get
			{
				return epsLevel4Code;
			}
			set
			{
				this.epsLevel4Code = value;
			}
		}
		public virtual string EpsLevel5Code
		{
			get
			{
				return epsLevel5Code;
			}
			set
			{
				this.epsLevel5Code = value;
			}
		}
		public virtual string EpsLevel6Code
		{
			get
			{
				return epsLevel6Code;
			}
			set
			{
				this.epsLevel6Code = value;
			}
		}
		public virtual string EpsLevel7Code
		{
			get
			{
				return epsLevel7Code;
			}
			set
			{
				this.epsLevel7Code = value;
			}
		}
		public virtual string EpsLevel8Code
		{
			get
			{
				return epsLevel8Code;
			}
			set
			{
				this.epsLevel8Code = value;
			}
		}
		public virtual string EpsLevel9Code
		{
			get
			{
				return epsLevel9Code;
			}
			set
			{
				this.epsLevel9Code = value;
			}
		}
		public virtual string EpsLevel1Title
		{
			get
			{
				return epsLevel1Title;
			}
			set
			{
				this.epsLevel1Title = value;
			}
		}
		public virtual string EpsLevel2Title
		{
			get
			{
				return epsLevel2Title;
			}
			set
			{
				this.epsLevel2Title = value;
			}
		}
		public virtual string EpsLevel3Title
		{
			get
			{
				return epsLevel3Title;
			}
			set
			{
				this.epsLevel3Title = value;
			}
		}
		public virtual string EpsLevel4Title
		{
			get
			{
				return epsLevel4Title;
			}
			set
			{
				this.epsLevel4Title = value;
			}
		}
		public virtual string EpsLevel5Title
		{
			get
			{
				return epsLevel5Title;
			}
			set
			{
				this.epsLevel5Title = value;
			}
		}
		public virtual string EpsLevel6Title
		{
			get
			{
				return epsLevel6Title;
			}
			set
			{
				this.epsLevel6Title = value;
			}
		}
		public virtual string EpsLevel7Title
		{
			get
			{
				return epsLevel7Title;
			}
			set
			{
				this.epsLevel7Title = value;
			}
		}
		public virtual string EpsLevel8Title
		{
			get
			{
				return epsLevel8Title;
			}
			set
			{
				this.epsLevel8Title = value;
			}
		}
		public virtual string EpsLevel9Title
		{
			get
			{
				return epsLevel9Title;
			}
			set
			{
				this.epsLevel9Title = value;
			}
		}
		public virtual long? DefaultProjectId
		{
			get
			{
				return defaultProjectId;
			}
			set
			{
				this.defaultProjectId = value;
			}
		}
		public virtual string DefaultProjectCode
		{
			get
			{
				return defaultProjectCode;
			}
			set
			{
				this.defaultProjectCode = value;
			}
		}
		public virtual string DefaultProjectTitle
		{
			get
			{
				return defaultProjectTitle;
			}
			set
			{
				this.defaultProjectTitle = value;
			}
		}
		public virtual string DefaultProjectDescription
		{
			get
			{
				return defaultProjectDescription;
			}
			set
			{
				this.defaultProjectDescription = value;
			}
		}
		public virtual string DefaultProjectCreatorId
		{
			get
			{
				return defaultProjectCreatorId;
			}
			set
			{
				this.defaultProjectCreatorId = value;
			}
		}
		public virtual DateTime DefaultProjectCreateDate
		{
			get
			{
				return defaultProjectCreateDate;
			}
			set
			{
				this.defaultProjectCreateDate = value;
			}
		}
		public virtual string DefaultProjectEditorId
		{
			get
			{
				return defaultProjectEditorId;
			}
			set
			{
				this.defaultProjectEditorId = value;
			}
		}
		public virtual DateTime DefaultProjectLastUpdate
		{
			get
			{
				return defaultProjectLastUpdate;
			}
			set
			{
				this.defaultProjectLastUpdate = value;
			}
		}
		public virtual string DefaultProjectStatus
		{
			get
			{
				return defaultProjectStatus;
			}
			set
			{
				this.defaultProjectStatus = value;
			}
		}
		public virtual string DefaultProjectCurrency
		{
			get
			{
				return defaultProjectCurrency;
			}
			set
			{
				this.defaultProjectCurrency = value;
			}
		}
		public virtual decimal DefaultProjectTotalCost
		{
			get
			{
				return defaultProjectTotalCost;
			}
			set
			{
				this.defaultProjectTotalCost = value;
			}
		}
		public virtual decimal DefaultProjectOfferedPrice
		{
			get
			{
				return defaultProjectOfferedPrice;
			}
			set
			{
				this.defaultProjectOfferedPrice = value;
			}
		}
		public virtual string DefaultProjectLocation
		{
			get
			{
				return defaultProjectLocation;
			}
			set
			{
				this.defaultProjectLocation = value;
			}
		}
		public virtual string DefaultProjectGeoLocation
		{
			get
			{
				return defaultProjectGeoLocation;
			}
			set
			{
				this.defaultProjectGeoLocation = value;
			}
		}
		public virtual string DefaultProjectCountry
		{
			get
			{
				return defaultProjectCountry;
			}
			set
			{
				this.defaultProjectCountry = value;
			}
		}
		public virtual string DefaultProjectState
		{
			get
			{
				return defaultProjectState;
			}
			set
			{
				this.defaultProjectState = value;
			}
		}
		public virtual string DefaultProjectClient
		{
			get
			{
				return defaultProjectClient;
			}
			set
			{
				this.defaultProjectClient = value;
			}
		}
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
		public virtual string UserName
		{
			get
			{
				return userName;
			}
			set
			{
				this.userName = value;
			}
		}
		public virtual string UserEmail
		{
			get
			{
				return userEmail;
			}
			set
			{
				this.userEmail = value;
			}
		}
		public virtual bool? UserXchange
		{
			get
			{
				return userXchange;
			}
			set
			{
				this.userXchange = value;
			}
		}
		public virtual bool? UserEsclte
		{
			get
			{
				return userEsclte;
			}
			set
			{
				this.userEsclte = value;
			}
		}
		public virtual bool? UserProps
		{
			get
			{
				return userProps;
			}
			set
			{
				this.userProps = value;
			}
		}
		public virtual bool? UserTakeoff
		{
			get
			{
				return userTakeoff;
			}
			set
			{
				this.userTakeoff = value;
			}
		}
		public virtual bool? UserEstimator
		{
			get
			{
				return userEstimator;
			}
			set
			{
				this.userEstimator = value;
			}
		}
		public virtual bool? UserAdmin
		{
			get
			{
				return userAdmin;
			}
			set
			{
				this.userAdmin = value;
			}
		}
		public virtual bool? UserSQuote
		{
			get
			{
				return userSQuote;
			}
			set
			{
				this.userSQuote = value;
			}
		}
		public virtual bool? UserRQuote
		{
			get
			{
				return userRQuote;
			}
			set
			{
				this.userRQuote = value;
			}
		}
		public virtual bool? UserRSRC
		{
			get
			{
				return userRSRC;
			}
			set
			{
				this.userRSRC = value;
			}
		}
		public virtual bool? UserAQuote
		{
			get
			{
				return userAQuote;
			}
			set
			{
				this.userAQuote = value;
			}
		}
		public virtual bool? UserWbs
		{
			get
			{
				return userWbs;
			}
			set
			{
				this.userWbs = value;
			}
		}
		public virtual bool? UserAditms
		{
			get
			{
				return userAditms;
			}
			set
			{
				this.userAditms = value;
			}
		}
		public virtual bool? UserRditms
		{
			get
			{
				return userRditms;
			}
			set
			{
				this.userRditms = value;
			}
		}
		public virtual bool? UserEditms
		{
			get
			{
				return userEditms;
			}
			set
			{
				this.userEditms = value;
			}
		}
		public virtual bool? UserVaitms
		{
			get
			{
				return userVaitms;
			}
			set
			{
				this.userVaitms = value;
			}
		}
		public virtual bool? UserVarSusr
		{
			get
			{
				return userVarSusr;
			}
			set
			{
				this.userVarSusr = value;
			}
		}
		public virtual bool? UserVarsAdmin
		{
			get
			{
				return userVarsAdmin;
			}
			set
			{
				this.userVarsAdmin = value;
			}
		}


	}

}