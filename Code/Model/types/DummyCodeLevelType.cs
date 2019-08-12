namespace Model.types
{
	using CustomType = org.hibernate.type.CustomType;

	public class DummyCodeLevelType : CustomType
	{

		public DummyCodeLevelType(string @string, int i, string key) : base(new NotNullTextType(),new string[]{key})
		{
		}

		public DummyCodeLevelType(object @object, object object2, int i, string key) : base(new NotNullTextType(),new string[]{key})
		{
		}

	}

}