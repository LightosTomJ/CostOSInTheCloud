//using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface IProjectuser
	{
		long Puid { get; set; }
		string Userid { get; set; }
		string Uname { get; set; }
		string Email { get; set; }
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
		long? Projectinfoid { get; set; }
		BaseClass.Projectinfo Projectinfo { get; set; }
		//ICollection<Projectaccess> Projectaccess { get; set; }
		
		Projectuser Clone();
	}
}
