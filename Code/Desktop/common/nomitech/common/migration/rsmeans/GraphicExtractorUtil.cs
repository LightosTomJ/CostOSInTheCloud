using System;
using System.Text;
using System.IO;

namespace Desktop.common.nomitech.common.migration.rsmeans
{
	using StringUtils = nomitech.common.util.StringUtils;
	using Document = org.icepdf.core.pobjects.Document;
	using PageText = org.icepdf.core.pobjects.graphics.text.PageText;

	public class GraphicExtractorUtil
	{
	  public static string extractTextFromPDF(string paramString)
	  {
		string str1 = null;
		string str2 = StringUtils.replaceAll(paramString, ".PDF", ".HTML");
		File file = new File(str2);
		try
		{
		  if (!file.exists())
		  {
			Document document = new Document();
			document.File = paramString;
			PageText pageText = document.getPageText(0);
			if (pageText != null && pageText.PageLines != null)
			{
			  str1 = pageText.ToString();
			  StreamWriter fileWriter = new StreamWriter(file);
			  fileWriter.Write(str1);
			  fileWriter.Close();
			}
			document.dispose();
		  }
		  else
		  {
			StreamReader fileReader = new StreamReader(file);
			StringBuilder stringBuffer = new StringBuilder(1000);
			StreamReader bufferedReader = new StreamReader(fileReader);
			char[] arrayOfChar = new char[1024];
			int i = 0;
			while ((i = bufferedReader.Read(arrayOfChar, 0, arrayOfChar.Length)) != -1)
			{
			  string str = string.valueOf(arrayOfChar, 0, i);
			  stringBuffer.Append(str);
			  arrayOfChar = new char[1024];
			}
			bufferedReader.Close();
			str1 = stringBuffer.ToString();
		  }
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		return str1;
	  }

	  public static void extractImageFromPDF(string paramString1, string paramString2, string paramString3)
	  {
		try
		{
		  if (!Directory.Exists(paramString2) || File.Exists(paramString2))
		  {
			Directory.CreateDirectory(paramString2);
		  }
		  Document document = new Document();
		  document.File = paramString1;
		  System.Collections.IList list = document.getPageImages(0);
		  foreach (Image image in list)
		  {
			if (image != null)
			{
			  BufferedImage bufferedImage = (BufferedImage)image;
			  try
			  {
				File file = new File(paramString2 + File.separator + paramString3 + ".PNG");
				ImageIO.write(bufferedImage, "png", file);
			  }
			  catch (IOException iOException)
			  {
				Console.WriteLine(iOException.ToString());
				Console.Write(iOException.StackTrace);
			  }
			  image.flush();
			}
		  }
		  document.dispose();
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
	  }

	  public static string makeGraphicHTML(string paramString1, string paramString2)
	  {
		string str = "http://www.costdatabase.eu/rsmeans/as/graphics/" + paramString1 + ".PNG";
		int i = 0;
		int j = 0;
		char c1 = 'Ȯ';
		char c2 = 'Ǵ';
		char c3 = (char)(c1 / '\x0002' - '2');
		try
		{
		  BufferedImage bufferedImage = ImageIO.read(new URL(str));
		  Dimension dimension = new Dimension(c1, c2);
		  i = bufferedImage.getWidth(null);
		  j = bufferedImage.getHeight(null);
		  float f = i / j;
		  if ((char)i > c1 || (char)j > c2)
		  {
			if (dimension.width / dimension.height > f)
			{
			  dimension.width = (int)Math.Ceiling((dimension.height * f));
			}
			else
			{
			  dimension.height = (int)Math.Ceiling((dimension.width / f));
			}
			i = dimension.width;
			j = dimension.height;
		  }
		}
		catch (Exception)
		{
		  i = 0;
		  j = 0;
		}
		StringBuilder stringBuffer = new StringBuilder();
		if (i == 0 || (char)i > c3)
		{
		  stringBuffer.Append("<html>");
		  if (i != 0)
		  {
			stringBuffer.Append("<div>");
			stringBuffer.Append("<a href=\"http://www.costdatabase.eu/rsmeans/as/graphics/" + paramString1 + ".PDF\"><img src=\"" + str + "\" width=\"" + i + "\" height=\"" + j + "\"  border=\"0\"></a>");
			stringBuffer.Append("</div>");
		  }
		  if (!StringUtils.isNullOrBlank(paramString2))
		  {
			stringBuffer.Append("<div width=\"400px\">");
			stringBuffer.Append("<font color=\"black\" face=\"Arial\" size=\"2\">");
			stringBuffer.Append("<br/>");
			stringBuffer.Append(paramString2);
			stringBuffer.Append("</font>");
			stringBuffer.Append("</div>");
		  }
		  stringBuffer.Append("</html>");
		}
		else
		{
		  stringBuffer.Append("<html>");
		  stringBuffer.Append("<table border=0 width=\"558\">");
		  stringBuffer.Append("<tr><td>");
		  stringBuffer.Append("<a href=\"http://www.costdatabase.eu/rsmeans/as/graphics/" + paramString1 + ".PDF\"><img src=\"" + str + "\" width=\"" + i + "\" height=\"" + j + "\"  border=\"0\"></a>");
		  stringBuffer.Append("</td><td valign=\"top\">");
		  stringBuffer.Append("<font face=\"Arial\" size=\"2\">");
		  stringBuffer.Append(paramString2);
		  stringBuffer.Append("</font></td></tr></table>");
		  stringBuffer.Append("</html>");
		}
		return stringBuffer.ToString();
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\rsmeans\GraphicExtractorUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}