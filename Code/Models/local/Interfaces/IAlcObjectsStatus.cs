using System;

namespace Models.local.Interfaces
{
	public interface IAlcObjectsStatus
	{
		string ObjId { get; set; }
		Guid Version { get; set; }
		
		AlcObjectsStatus Clone();
	}
}
