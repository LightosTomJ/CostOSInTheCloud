using System;

namespace Models.local.Interfaces
{
	public interface IGekcode
	{
		long Gekcodeid { get; set; }
		DateTime? Lastupdate { get; set; }
		string Description { get; set; }
		string Groupcode { get; set; }
		string Title { get; set; }
		string Notes { get; set; }
		string Editorid { get; set; }
		decimal? Ufact { get; set; }
		string Unit { get; set; }
		
		Gekcode Clone();
	}
}
