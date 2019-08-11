using System;
using System.IO;

namespace Desktop.common.nomitech.common.util
{

	public class ObjectCloner
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static Object deepCopy(Object paramObject) throws Exception
	  public static object deepCopy(object paramObject)
	  {
		objectOutputStream = null;
		objectInputStream = null;
		try
		{
		  MemoryStream byteArrayOutputStream = new MemoryStream();
		  objectOutputStream = new ObjectOutputStream(byteArrayOutputStream);
		  objectOutputStream.writeObject(paramObject);
		  objectOutputStream.flush();
		  MemoryStream byteArrayInputStream = new MemoryStream(byteArrayOutputStream.toByteArray());
		  objectInputStream = new ObjectInputStream(byteArrayInputStream);
		  return objectInputStream.readObject();
		}
		catch (Exception exception)
		{
		  Console.WriteLine("Exception in ObjectCloner = " + exception);
		  throw exception;
		}
		finally
		{
		  objectOutputStream.close();
		  objectInputStream.close();
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\ObjectCloner.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}