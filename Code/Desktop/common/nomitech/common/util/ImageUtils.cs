using System;
using System.IO;

namespace Desktop.common.nomitech.common.util
{
	using Document = org.icepdf.core.pobjects.Document;

	public class ImageUtils
	{
	  public const int IMAGE_JPEG = 0;

	  public const int IMAGE_PNG = 1;

	  public const int IMAGE_PDF = 2;

	  public const int IMAGE_GIF = 3;

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.awt.image.BufferedImage resizeImage(String paramString, int paramInt1, int paramInt2, int paramInt3) throws java.io.IOException
	  public static BufferedImage resizeImage(string paramString, int paramInt1, int paramInt2, int paramInt3)
	  {
		  return resizeImage(ImageIO.read(new File(paramString)), paramInt1, paramInt2, paramInt3);
	  }

	  public static BufferedImage resizeImage(Image paramImage, int paramInt1, int paramInt2, int paramInt3)
	  {
		Dimension dimension = new Dimension(paramInt2, paramInt3);
		int i = paramImage.getWidth(null);
		int j = paramImage.getHeight(null);
		float f = i / j;
		if (i > paramInt2 || j > paramInt3)
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
		return createBufferedImage(paramImage, paramInt1, i, j);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static boolean saveImage(java.awt.image.BufferedImage paramBufferedImage, String paramString, int paramInt) throws java.io.IOException
	  public static bool saveImage(BufferedImage paramBufferedImage, string paramString, int paramInt)
	  {
		string str = "jpg";
		if (paramInt == 1)
		{
		  str = "png";
		}
		else if (paramInt == 3)
		{
		  str = "gif";
		}
		return ImageIO.write(paramBufferedImage, str, new File(paramString));
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void saveCompressedImage(java.awt.image.BufferedImage paramBufferedImage, String paramString, int paramInt) throws java.io.IOException
	  public static void saveCompressedImage(BufferedImage paramBufferedImage, string paramString, int paramInt)
	  {
		if (paramInt == 1)
		{
		  throw new System.NotSupportedException("PNG compression not implemented");
		}
		ImageWriter imageWriter = null;
		System.Collections.IEnumerator iterator = ImageIO.getImageWritersByFormatName("jpg");
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
		imageWriter = (ImageWriter)iterator.next();
		ImageOutputStream imageOutputStream = ImageIO.createImageOutputStream(new File(paramString));
		imageWriter.Output = imageOutputStream;
		JPEGImageWriteParam jPEGImageWriteParam = new JPEGImageWriteParam(Locale.Default);
		jPEGImageWriteParam.CompressionMode = 2;
		jPEGImageWriteParam.CompressionQuality = 0.7F;
		imageWriter.write(null, new IIOImage(paramBufferedImage, null, null), jPEGImageWriteParam);
		imageOutputStream.flush();
		imageWriter.dispose();
		imageOutputStream.close();
	  }

	  public static BufferedImage createBufferedImage(Image paramImage, int paramInt1, int paramInt2, int paramInt3)
	  {
		if ((paramInt1 == 1 || paramInt1 == 3) && hasAlpha(paramImage))
		{
		  paramInt1 = 2;
		}
		else
		{
		  paramInt1 = 1;
		}
		BufferedImage bufferedImage = new BufferedImage(paramInt2, paramInt3, paramInt1);
		Graphics2D graphics2D = bufferedImage.createGraphics();
		graphics2D.drawImage(paramImage, 0, 0, paramInt2, paramInt3, null);
		graphics2D.dispose();
		return bufferedImage;
	  }

	  public static bool hasAlpha(Image paramImage)
	  {
		try
		{
		  PixelGrabber pixelGrabber = new PixelGrabber(paramImage, 0, 0, 1, 1, false);
		  pixelGrabber.grabPixels();
		  return pixelGrabber.ColorModel.hasAlpha();
		}
		catch (InterruptedException)
		{
		  return false;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.awt.Image loadImageFromPDF(String paramString, int paramInt) throws Exception
	  public static Image loadImageFromPDF(string paramString, int paramInt)
	  {
		Document document = new Document();
		if (!Directory.Exists(paramString) || File.Exists(paramString))
		{
		  document.Url = new URL(paramString);
		}
		else
		{
		  document.File = paramString;
		}
		float f1 = 1.0F;
		float f2 = 0.0F;
		Image image = document.getPageImage(paramInt, 2, 5, f2, f1);
		document.dispose();
		return image;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.awt.Image loadImageOrPDF(String paramString) throws Exception
	  public static Image loadImageOrPDF(string paramString)
	  {
		  return paramString.ToLower().EndsWith("pdf", StringComparison.Ordinal) ? loadImageFromPDF(paramString, 0) : (new ImageIcon(paramString)).Image;
	  }

	  public static void savePDFAsJPG(string paramString1, string paramString2)
	  {
		try
		{
		  Image image = loadImageFromPDF(paramString1, 0);
		  saveCompressedImage(createBufferedImage(image, 0, image.getWidth(null), image.getHeight(null)), paramString2, 0);
		}
		catch (Exception exception)
		{
		  Console.WriteLine("Error for pdf file: " + paramString1 + " " + exception.Message);
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
	  }

	  public static Image createTransparentImage(Image paramImage, float paramFloat)
	  {
		BufferedImage bufferedImage1 = createBufferedImage(paramImage, 1, paramImage.getWidth(null), paramImage.getHeight(null));
		BufferedImage bufferedImage2 = new BufferedImage(bufferedImage1.Width, bufferedImage1.Height, 3);
		Graphics2D graphics2D = bufferedImage2.createGraphics();
		graphics2D.Composite = AlphaComposite.getInstance(3, paramFloat);
		graphics2D.drawImage(bufferedImage1, null, 0, 0);
		graphics2D.dispose();
		return bufferedImage2;
	  }

	  public static ImageIcon convertToGrayScale(Image paramImage)
	  {
		BufferedImage bufferedImage = createBufferedImage(paramImage, 1, paramImage.getWidth(null), paramImage.getHeight(null));
		return new ImageIcon(convertToGrayscale(bufferedImage));
	  }

	  public static Icon convertToGrayScale(ImageIcon paramImageIcon)
	  {
		Image image = paramImageIcon.Image;
		BufferedImage bufferedImage = createBufferedImage(image, 1, image.getWidth(null), image.getHeight(null));
		return new ImageIcon(convertToGrayscale(bufferedImage));
	  }

	  public static BufferedImage convertToGrayscale(BufferedImage paramBufferedImage)
	  {
		ColorConvertOp colorConvertOp = new ColorConvertOp(ColorSpace.getInstance(1003), null);
		return colorConvertOp.filter(paramBufferedImage, null);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.awt.image.BufferedImage resizeImage(String paramString, int paramInt1, int paramInt2) throws java.io.IOException
	  public static BufferedImage resizeImage(string paramString, int paramInt1, int paramInt2)
	  {
		BufferedImage bufferedImage = null;
		if (paramString.ToLower().EndsWith(".png", StringComparison.Ordinal))
		{
		  bufferedImage = resizeImage(ImageIO.read(new File(paramString)), 1, paramInt1, paramInt2);
		}
		else if (paramString.ToLower().EndsWith(".gif", StringComparison.Ordinal))
		{
		  bufferedImage = resizeImage(ImageIO.read(new File(paramString)), 3, paramInt1, paramInt2);
		}
		else
		{
		  bufferedImage = resizeImage(ImageIO.read(new File(paramString)), 0, paramInt1, paramInt2);
		}
		return bufferedImage;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void resizeImageAndSave(java.awt.image.BufferedImage paramBufferedImage, int paramInt1, String paramString, int paramInt2, int paramInt3) throws java.io.IOException
	  public static void resizeImageAndSave(BufferedImage paramBufferedImage, int paramInt1, string paramString, int paramInt2, int paramInt3)
	  {
		paramBufferedImage = resizeImage(paramBufferedImage, paramInt1, paramInt2, paramInt3);
		saveImage(paramBufferedImage, paramString, 1);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void resizeImageAndSave(String paramString1, String paramString2, int paramInt1, int paramInt2) throws java.io.IOException
	  public static void resizeImageAndSave(string paramString1, string paramString2, int paramInt1, int paramInt2)
	  {
		BufferedImage bufferedImage = resizeImage(paramString1, paramInt1, paramInt2);
		sbyte b = 0;
		if (paramString1.ToLower().EndsWith(".png", StringComparison.Ordinal))
		{
		  b = 1;
		}
		else if (paramString1.ToLower().EndsWith(".gif", StringComparison.Ordinal))
		{
		  b = 3;
		}
		else
		{
		  b = 0;
		}
		saveImage(bufferedImage, paramString2, 1);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static byte[] convertToByteArray(String paramString) throws Exception
	  public static sbyte[] convertToByteArray(string paramString)
	  {
		File file = new File(paramString);
		FileStream fileInputStream = new FileStream(file, FileMode.Open, FileAccess.Read);
		MemoryStream byteArrayOutputStream = new MemoryStream();
		sbyte[] arrayOfByte1 = new sbyte[1024];
		int i;
		while ((i = fileInputStream.Read(arrayOfByte1, 0, arrayOfByte1.Length)) != -1)
		{
		  byteArrayOutputStream.Write(arrayOfByte1, 0, i);
		}
		sbyte[] arrayOfByte2 = byteArrayOutputStream.toByteArray();
		fileInputStream.Close();
		return arrayOfByte2;
	  }

	  public static sbyte[] imageToBase64(ImageIcon paramImageIcon, int paramInt)
	  {
		try
		{
		  string str = "jpg";
		  if (paramInt == 1)
		  {
			str = "png";
		  }
		  else if (paramInt == 3)
		  {
			str = "gif";
		  }
		  BufferedImage bufferedImage = (BufferedImage)paramImageIcon.Image;
		  MemoryStream byteArrayOutputStream = new MemoryStream();
		  ImageIO.write(bufferedImage, str, byteArrayOutputStream);
		  sbyte[] arrayOfByte = byteArrayOutputStream.toByteArray();
		  return Base64.encode(arrayOfByte);
		}
		catch (IOException)
		{
		  return null;
		}
	  }

	  public static ImageIcon base64ToImage(sbyte[] paramArrayOfByte)
	  {
		sbyte[] arrayOfByte = Base64.decode(paramArrayOfByte);
		return new ImageIcon(arrayOfByte);
	  }

	  public static BufferedImage toBufferedImage(Image paramImage)
	  {
		int i = paramImage.getWidth(null);
		int j = paramImage.getHeight(null);
		BufferedImage bufferedImage = new BufferedImage(i, j, 1);
		Graphics graphics = bufferedImage.Graphics;
		graphics.drawImage(paramImage, 0, 0, null);
		graphics.dispose();
		return bufferedImage;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.awt.image.BufferedImage imageFromBytes(int paramInt, byte[] paramArrayOfByte) throws Exception
	  public static BufferedImage imageFromBytes(int paramInt, sbyte[] paramArrayOfByte)
	  {
		string str = "jpg";
		if (paramInt == 1)
		{
		  str = "png";
		}
		else if (paramInt == 3)
		{
		  str = "gif";
		}
		MemoryStream byteArrayInputStream1 = new MemoryStream(paramArrayOfByte);
		System.Collections.IEnumerator iterator = ImageIO.getImageReadersByFormatName(str);
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
		ImageReader imageReader = (ImageReader)iterator.next();
		MemoryStream byteArrayInputStream2 = byteArrayInputStream1;
		ImageInputStream imageInputStream = ImageIO.createImageInputStream(byteArrayInputStream2);
		imageReader.setInput(imageInputStream, true);
		ImageReadParam imageReadParam = imageReader.DefaultReadParam;
		BufferedImage bufferedImage = imageReader.read(0, imageReadParam);
		return createBufferedImage(bufferedImage, paramInt, bufferedImage.getWidth(null), bufferedImage.getHeight(null));
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\ImageUtils.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}