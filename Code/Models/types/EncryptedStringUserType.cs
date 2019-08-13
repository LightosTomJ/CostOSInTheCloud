using System;

namespace Models.types
{
    public class EncryptedStringUserType
    {
        private const string KEY_ALGORITHM = "PBEWithMD5AndDES";
        private const string CIPHER_ALGORITHM = "PBEWithMD5AndDES/CBC/PKCS5Padding";
        //private static readonly sbyte[] SALT = "a#$sd#J%".Bytes;
        //private readonly PBEParameterSpec paramSpec = new PBEParameterSpec(SALT, 5);
        //private static SecretKey masterKey;
        //private static readonly int[] SQLTYPE = new int[] { TextType.INSTANCE.sqlType() };

        public EncryptedStringUserType()
        { }
    }
}