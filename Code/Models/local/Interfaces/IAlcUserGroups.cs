using System;

namespace Models.local.Interfaces
{
	public interface IAlcUserGroups
	{
		Guid UserId { get; set; }
		Guid GroupId { get; set; }
		
		AlcUserGroups Clone();
	}
}
