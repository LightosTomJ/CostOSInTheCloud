using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class SupplierTable
    {
        /*
		public static final String[] FIELDS = new String[] {
			"title",
			"supplierId",
			"geoLocation",
			"contactPerson",
			"groupCode",
			"gekCode",
			"editorId",
			"performance",
			"phoneNumber",
			"mobileNumber",
			"faxNumber",
			"email",
			"url",		
			"address",
			"city",
			"stateProvince",
			"country",
			"notes",
			"description",
			"lastUpdate",
			"extraCode1",
			"extraCode2",
			"extraCode3",
			"extraCode4",
			"extraCode5",
			"extraCode6",
			"extraCode7",
		};
		 */
        public static readonly string[] VIEWABLE_FIELDS = new string[] { "supplierId", "itemCode", "title", "geoLocation", "contactPerson", "performance", "phoneNumber", "mobileNumber", "faxNumber", "email", "url", "address", "city", "stateProvince", "country", "notes", "description", "editorId", "lastUpdate", "createUserId", "createDate", "groupCode", "gekCode", "extraCode1", "extraCode2", "extraCode3", "extraCode4", "extraCode5", "extraCode6", "extraCode7" };

        public static readonly Type[] CLASSES = new Type[] { typeof(long), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(string), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };

        public long? supplierId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string contactPerson { get; set; }
        public string phoneNumber { get; set; }
        public string mobileNumber { get; set; }
        public string faxNumber { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string notes { get; set; }
        public string editorId { get; set; }
        public string stateProvince { get; set; }
        public string groupCode { get; set; }
        public string gekCode { get; set; }
        public string url { get; set; }
        public string performance { get; set; }
        public string country { get; set; }
        public DateTime lastUpdate { get; set; }
        public string createUserId { get; set; }
        public string geoLocation { get; set; }
        public DateTime createDate { get; set; }

        public string extraCode1 { get; set; }
        public string extraCode2 { get; set; }
        public string extraCode3 { get; set; }
        public string extraCode4 { get; set; }
        public string extraCode5 { get; set; }
        public string extraCode6 { get; set; }
        public string extraCode7 { get; set; }
        public string extraCode8 { get; set; }
        public string extraCode9 { get; set; }
        public string extraCode10 { get; set; }

        public string itemCode { get; set; }

        ////	@ContainedIn
        ////	@OneToOne(mappedBy="supplierTable")
        //public ISet<MaterialTable> materialSet = new HashSet<MaterialTable>(0);
        public List<MaterialTable> materialSet = new List<MaterialTable>();

        public SupplierTable()
        { }
    }
}