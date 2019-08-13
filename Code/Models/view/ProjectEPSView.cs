using System;

namespace Models.view
{
    [Serializable]
    public class ProjectEPSView
    {
        public string epsLevel1Code {get; set;}
        public string epsLevel2Code {get; set;}
        public string epsLevel3Code {get; set;}
        public string epsLevel4Code {get; set;}
        public string epsLevel5Code {get; set;}
        public string epsLevel6Code {get; set;}
        public string epsLevel7Code {get; set;}
        public string epsLevel8Code {get; set;}
        public string epsLevel9Code {get; set;}

        public string epsLevel1Title {get; set;}
        public string epsLevel2Title {get; set;}
        public string epsLevel3Title {get; set;}
        public string epsLevel4Title {get; set;}
        public string epsLevel5Title {get; set;}
        public string epsLevel6Title {get; set;}
        public string epsLevel7Title {get; set;}
        public string epsLevel8Title {get; set;}
        public string epsLevel9Title {get; set;}

        public long? defaultProjectId {get; set;}
        public string defaultProjectCode {get; set;}
        public string defaultProjectTitle {get; set;}
        public string defaultProjectDescription {get; set;}
        public string defaultProjectCreatorId {get; set;}
        public DateTime defaultProjectCreateDate {get; set;}
        public string defaultProjectEditorId {get; set;}
        public DateTime defaultProjectLastUpdate {get; set;}
        public string defaultProjectStatus {get; set;}
        public string defaultProjectCurrency {get; set;}
        public string defaultProjectCurrencySymbol {get; set;}

        public decimal defaultProjectCustomCumDecimal1 {get; set;}
        public decimal defaultProjectCustomCumDecimal2 {get; set;}
        public decimal defaultProjectCustomCumDecimal3 {get; set;}
        public decimal defaultProjectCustomCumDecimal4 {get; set;}
        public decimal defaultProjectCustomCumDecimal5 {get; set;}
        public decimal defaultProjectCustomCumDecimal6 {get; set;}
        public decimal defaultProjectCustomCumDecimal7 {get; set;}
        public decimal defaultProjectCustomCumDecimal8 {get; set;}
        public decimal defaultProjectCustomCumDecimal9 {get; set;}
        public decimal defaultProjectCustomCumDecimal10 {get; set;}
        public decimal defaultProjectCustomCumDecimal11 {get; set;}
        public decimal defaultProjectCustomCumDecimal12 {get; set;}
        public decimal defaultProjectCustomCumDecimal13 {get; set;}
        public decimal defaultProjectCustomCumDecimal14 {get; set;}
        public decimal defaultProjectCustomCumDecimal15 {get; set;}
        public decimal defaultProjectCustomCumDecimal16 {get; set;}
        public decimal defaultProjectCustomCumDecimal17 {get; set;}
        public decimal defaultProjectCustomCumDecimal18 {get; set;}
        public decimal defaultProjectCustomCumDecimal19 {get; set;}
        public decimal defaultProjectCustomCumDecimal20 {get; set;}

        public decimal defaultProjectEquipmentTotalCost {get; set;}
        public decimal defaultProjectSubcontractorTotalCost {get; set;}
        public decimal defaultProjectLaborTotalCost {get; set;}
        public decimal defaultProjectMaterialTotalCost {get; set;}
        public decimal defaultProjectConsumableTotalCost {get; set;}
        public decimal defaultProjectLaborManhours {get; set;}
        public decimal defaultProjectEquipmentManhours {get; set;}

        public decimal defaultProjectTotalCost {get; set;}
        public decimal defaultProjectOfferedPrice {get; set;}

        public string defaultProjectGeoLocation {get; set;}
        public string defaultProjectLocation {get; set;}
        public string defaultProjectCountry {get; set;}
        public string defaultProjectState {get; set;}
        public string defaultProjectClient {get; set;}

        public ProjectEPSView()
        { }
    }
}