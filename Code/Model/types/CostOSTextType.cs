namespace Model.types
{
	using TextType = org.hibernate.type.TextType;

	public class CostOSTextType : TextType
	{
		public CostOSTextType() : base()
		{
		}

		public virtual string Name
		{
			get
			{
				return "costos_text";
			}
		}

		public override string[] RegistrationKeys
		{
			get
			{
				// lets use delegation and register ourselves under all of StringType's keys
				return new string[]{"costos_text"}; // StringUtils.concat(super.getRegistrationKeys(),new String[]{"costos_text"});
				//return Arrays.asList(super.getRegistrationKeys(),new String[]{"costos_text"}).toArray(new String[]{});
			}
		}
	}


}