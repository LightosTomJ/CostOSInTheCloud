using System;

namespace Models.local.Interfaces
{
	public interface IExtracode1
	{
		long Groupcodeid { get; set; }
		DateTime? Lastupdate { get; set; }
		string Description { get; set; }
		string Groupcode { get; set; }
		string Title { get; set; }
		string Notes { get; set; }
		string Editorid { get; set; }
		decimal? Ufact { get; set; }
		string Unit { get; set; }
		
		Extracode1 Clone();
	}
}
