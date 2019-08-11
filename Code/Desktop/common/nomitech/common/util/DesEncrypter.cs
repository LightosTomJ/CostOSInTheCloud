using System.IO;

namespace Desktop.common.nomitech.common.util
{

	public class DesEncrypter
	{
	  internal Cipher ecipher;

	  internal Cipher dcipher;

	  internal sbyte[] buf = new sbyte[1024];

	  internal DesEncrypter(SecretKey paramSecretKey)
	  {
		sbyte[] arrayOfByte = new sbyte[] {-114, 18, 57, -100, 7, 114, 111, 90};
		IvParameterSpec ivParameterSpec = new IvParameterSpec(arrayOfByte);
		try
		{
		  this.dcipher = (this.ecipher = Cipher.getInstance("DES/CBC/PKCS5Padding")).getInstance("DES/CBC/PKCS5Padding");
		  this.ecipher.init(1, paramSecretKey, ivParameterSpec);
		  this.dcipher.init(2, paramSecretKey, ivParameterSpec);
		}
		catch (InvalidAlgorithmParameterException)
		{

		}
		catch (NoSuchPaddingException)
		{

		}
		catch (NoSuchAlgorithmException)
		{

		}
		catch (InvalidKeyException)
		{
		}
	  }

	  public virtual void encrypt(Stream paramInputStream, Stream paramOutputStream)
	  {
		try
		{
		  paramOutputStream = new CipherOutputStream(paramOutputStream, this.ecipher);
		  int i = 0;
		  while ((i = paramInputStream.Read(this.buf, 0, this.buf.Length)) >= 0)
		  {
			paramOutputStream.Write(this.buf, 0, i);
		  }
		  paramOutputStream.Close();
		}
		catch (IOException)
		{
		}
	  }

	  public virtual void decrypt(Stream paramInputStream, Stream paramOutputStream)
	  {
		try
		{
		  paramInputStream = new CipherInputStream(paramInputStream, this.dcipher);
		  int i = 0;
		  while ((i = paramInputStream.Read(this.buf, 0, this.buf.Length)) >= 0)
		  {
			paramOutputStream.Write(this.buf, 0, i);
		  }
		  paramOutputStream.Close();
		}
		catch (IOException)
		{
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\DesEncrypter.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}