//using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface IQueryresource
	{
		long Qresid { get; set; }
		int? Exectype { get; set; }
		int? Type { get; set; }
		string Title { get; set; }
		string Jsonurl { get; set; }
		string Restype { get; set; }
		string Ordfld { get; set; }
		bool? Ascdng { get; set; }
		bool? Sngsel { get; set; }
		string Tlteq { get; set; }
		string Dsceq { get; set; }
		string Ntseq { get; set; }
		string Loceq { get; set; }
		string Pdteq { get; set; }
		string Prdeq { get; set; }
		string Prfeq { get; set; }
		string Wb1eq { get; set; }
		string Wb2eq { get; set; }
		string Piceq { get; set; }
		string Gc1eq { get; set; }
		string Gc2eq { get; set; }
		string Gc3eq { get; set; }
		string Gc4eq { get; set; }
		string Gc5eq { get; set; }
		string Gc6eq { get; set; }
		string Gc7eq { get; set; }
		string Gc8eq { get; set; }
		string Gc9eq { get; set; }
		string Ct01eq { get; set; }
		string Ct02eq { get; set; }
		string Ct03eq { get; set; }
		string Ct04eq { get; set; }
		string Ct05eq { get; set; }
		string Ct06eq { get; set; }
		string Ct07eq { get; set; }
		string Ct08eq { get; set; }
		string Ct09eq { get; set; }
		string Ct10eq { get; set; }
		string Ct11eq { get; set; }
		string Ct12eq { get; set; }
		string Ct13eq { get; set; }
		string Ct14eq { get; set; }
		string Ct15eq { get; set; }
		string Ct16eq { get; set; }
		string Ct17eq { get; set; }
		string Ct18eq { get; set; }
		string Ct19eq { get; set; }
		string Ct20eq { get; set; }
		string Ct21eq { get; set; }
		string Ct22eq { get; set; }
		string Ct23eq { get; set; }
		string Ct24eq { get; set; }
		string Ct25eq { get; set; }
		string Cr01eq { get; set; }
		string Cr02eq { get; set; }
		string Cr03eq { get; set; }
		string Cr04eq { get; set; }
		string Cr05eq { get; set; }
		string Cr06eq { get; set; }
		string Cr07eq { get; set; }
		string Cr08eq { get; set; }
		string Cr09eq { get; set; }
		string Cr10eq { get; set; }
		string Cr11eq { get; set; }
		string Cr12eq { get; set; }
		string Cr13eq { get; set; }
		string Cr14eq { get; set; }
		string Cr15eq { get; set; }
		string Cr16eq { get; set; }
		string Cr17eq { get; set; }
		string Cr18eq { get; set; }
		string Cr19eq { get; set; }
		string Cr20eq { get; set; }
		string Cc01eq { get; set; }
		string Cc02eq { get; set; }
		string Cc03eq { get; set; }
		string Cc04eq { get; set; }
		string Cc05eq { get; set; }
		string Cc06eq { get; set; }
		string Cc07eq { get; set; }
		string Cc08eq { get; set; }
		string Cc09eq { get; set; }
		string Cc10eq { get; set; }
		string Cc11eq { get; set; }
		string Cc12eq { get; set; }
		string Cc13eq { get; set; }
		string Cc14eq { get; set; }
		string Cc15eq { get; set; }
		string Cc16eq { get; set; }
		string Cc17eq { get; set; }
		string Cc18eq { get; set; }
		string Cc19eq { get; set; }
		string Cc20eq { get; set; }
		long? Paramoutputid { get; set; }
		BaseClass.Paramoutput Paramoutput { get; set; }
		//ICollection<Queryrow> Queryrow { get; set; }
		
		Queryresource Clone();
	}
}