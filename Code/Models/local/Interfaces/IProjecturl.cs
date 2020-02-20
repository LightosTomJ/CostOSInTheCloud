using System;
//using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface IProjecturl
	{
		long Projecturlid { get; set; }
		string Url { get; set; }
		string Dbusr { get; set; }
		string Dbpswd { get; set; }
		string Dbhost { get; set; }
		string Dbport { get; set; }
		string Dbprefix { get; set; }
		bool? Dbsingle { get; set; }
		string Dbname { get; set; }
		int? Dbsrv { get; set; }
		string Dbsrvname { get; set; }
		int? Qsent { get; set; }
		int? Qrecv { get; set; }
		bool? Defrev { get; set; }
		string Editorid { get; set; }
		string Type { get; set; }
		string Name { get; set; }
		string Rvson { get; set; }
		string Creuserid { get; set; }
		DateTime? Createdate { get; set; }
		DateTime? Lastupdate { get; set; }
		int? Underreview { get; set; }
		int? Pending { get; set; }
		int? Approved { get; set; }
		int? Completed { get; set; }
		decimal? Esttotal { get; set; }
		decimal? Quotedtotal { get; set; }
		decimal? Markuptotal { get; set; }
		bool? Mustrecalc { get; set; }
		bool? Frozen { get; set; }
		long? Benchmarkid { get; set; }
		string Description { get; set; }
		long? Projectinfoid { get; set; }
		long? Projectdbmsid { get; set; }
		BaseClass.Prjdbms Projectdbms { get; set; }
		BaseClass.Projectinfo Projectinfo { get; set; }
		//ICollection<Prjprop> Prjprop { get; set; }
		
		Projecturl Clone();
	}
}
