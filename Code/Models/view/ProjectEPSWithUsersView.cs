using System;

namespace Models.view
{
    [Serializable]
    public class ProjectEPSWithUsersView
    {
        public string epsLevel1Code { get; set; }
        public string epsLevel2Code { get; set; }
        public string epsLevel3Code { get; set; }
        public string epsLevel4Code { get; set; }
        public string epsLevel5Code { get; set; }
        public string epsLevel6Code { get; set; }
        public string epsLevel7Code { get; set; }
        public string epsLevel8Code { get; set; }
        public string epsLevel9Code { get; set; }

        public string epsLevel1Title { get; set; }
        public string epsLevel2Title { get; set; }
        public string epsLevel3Title { get; set; }
        public string epsLevel4Title { get; set; }
        public string epsLevel5Title { get; set; }
        public string epsLevel6Title { get; set; }
        public string epsLevel7Title { get; set; }
        public string epsLevel8Title { get; set; }
        public string epsLevel9Title { get; set; }


        public long? defaultProjectId { get; set; }
        public string defaultProjectCode { get; set; }
        public string defaultProjectTitle { get; set; }
        public string defaultProjectDescription { get; set; }
        public string defaultProjectCreatorId { get; set; }
        public DateTime defaultProjectCreateDate { get; set; }
        public string defaultProjectEditorId { get; set; }
        public DateTime defaultProjectLastUpdate { get; set; }
        public string defaultProjectStatus { get; set; }
        public string defaultProjectCurrency { get; set; }
        public decimal defaultProjectTotalCost { get; set; }
        public decimal defaultProjectOfferedPrice { get; set; }

        public string defaultProjectGeoLocation { get; set; }
        public string defaultProjectLocation { get; set; }
        public string defaultProjectCountry { get; set; }
        public string defaultProjectState { get; set; }
        public string defaultProjectClient { get; set; }

        public string userId { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
        public bool? userXchange { get; set; }
        public bool? userEsclte { get; set; }
        public bool? userProps { get; set; }

        public bool? userTakeoff { get; set; }
        public bool? userEstimator { get; set; }
        public bool? userAdmin { get; set; }
        public bool? userSQuote { get; set; }
        public bool? userRQuote { get; set; }
        public bool? userRSRC { get; set; }

        public bool? userAQuote { get; set; }
        public bool? userWbs { get; set; }
        public bool? userAditms { get; set; }
        public bool? userRditms { get; set; }
        public bool? userEditms { get; set; }

        public bool? userVaitms { get; set; }
        public bool? userVarSusr { get; set; }
        public bool? userVarsAdmin { get; set; }

        public ProjectEPSWithUsersView()
        { }
    }
}