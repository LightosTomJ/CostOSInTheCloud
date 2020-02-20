
namespace Models.local.Interfaces
{
	public interface IParamreturn
	{
		long Paramreturnid { get; set; }
		string Reteq { get; set; }
		long? Paramitemid { get; set; }
		BaseClass.Paramitem Paramitem { get; set; }
		
		Paramreturn Clone();
	}
}
