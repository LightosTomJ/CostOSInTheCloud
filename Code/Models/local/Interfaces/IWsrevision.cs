//using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface IWsrevision
	{
		long Id { get; set; }
		string Title { get; set; }
		System.DateTime? Createdate { get; set; }
		System.DateTime? Lastupdate { get; set; }
		string Createuserid { get; set; }
		string Editorid { get; set; }
		string Description { get; set; }
		bool? Pblk { get; set; }
		long? Mappingid { get; set; }
		BaseClass.Wsdatamapping Mapping { get; set; }
		//ICollection<Wsfile> Wsfile { get; set; }
		
		Wsrevision Clone();
	}
}
