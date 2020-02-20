using System;

namespace Models.local.Interfaces
{
	public interface IProjectusertemplate
	{
		long Templateid { get; set; }
		string Name { get; set; }
		bool? Xchange { get; set; }
		bool? Esclte { get; set; }
		bool? Props { get; set; }
		bool? Takeoff { get; set; }
		bool? Rsrc { get; set; }
		bool? Estim { get; set; }
		bool? Admn { get; set; }
		bool? Squote { get; set; }
		bool? Rquote { get; set; }
		bool? Aquote { get; set; }
		bool? Wbs { get; set; }
		bool? Aditms { get; set; }
		bool? Rmitms { get; set; }
		bool? Editms { get; set; }
		bool? Vaitms { get; set; }
		bool? Varsusr { get; set; }
		bool? Varsadmin { get; set; }
		bool? Varsviewer { get; set; }
		string Createuser { get; set; }
		DateTime? Createdate { get; set; }
		string Editorid { get; set; }
		DateTime? Lastupdate { get; set; }
		
		Projectusertemplate Clone();
	}
}
