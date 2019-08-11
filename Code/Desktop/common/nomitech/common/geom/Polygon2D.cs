using System;

namespace Desktop.common.nomitech.common.geom
{
	using Crossings = Desktop.common.sun.awt.geom.Crossings;

	public class Polygon2D : Shape
	{
	  public int npoints;

	  public double[] xpoints;

	  public double[] ypoints;

	  protected internal Rectangle bounds;

	  protected internal Rectangle2D.Double bounds2d;

	  public Polygon2D()
	  {
		this.xpoints = new double[4];
		this.ypoints = new double[4];
	  }

	  public Polygon2D(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, int paramInt)
	  {
		if (paramInt > paramArrayOfDouble1.Length || paramInt > paramArrayOfDouble2.Length)
		{
		  throw new System.IndexOutOfRangeException("npoints > xpoints.length || npoints > ypoints.length");
		}
		this.npoints = paramInt;
		this.xpoints = new double[paramInt];
		this.ypoints = new double[paramInt];
		Array.Copy(paramArrayOfDouble1, 0, this.xpoints, 0, paramInt);
		Array.Copy(paramArrayOfDouble2, 0, this.ypoints, 0, paramInt);
	  }

	  public Polygon2D(Point2D[] paramArrayOfPoint2D)
	  {
		this.npoints = paramArrayOfPoint2D.Length;
		this.xpoints = new double[this.npoints];
		this.ypoints = new double[this.npoints];
		for (sbyte b = 0; b < this.npoints; b++)
		{
		  this.xpoints[b] = paramArrayOfPoint2D[b].X;
		  this.ypoints[b] = paramArrayOfPoint2D[b].Y;
		}
	  }

	  public virtual void reset()
	  {
		this.npoints = 0;
		this.bounds = null;
	  }

	  public virtual void invalidate()
	  {
		  this.bounds = null;
	  }

	  public virtual void translate(int paramInt1, int paramInt2)
	  {
		for (sbyte b = 0; b < this.npoints; b++)
		{
		  this.xpoints[b] = this.xpoints[b] + paramInt1;
		  this.ypoints[b] = this.ypoints[b] + paramInt2;
		}
		if (this.bounds != null)
		{
		  this.bounds.translate(paramInt1, paramInt2);
		}
	  }

	  internal virtual void calculateBounds(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, int paramInt)
	  {
		double d1 = double.MaxValue;
		double d2 = double.MaxValue;
		double d3 = double.Epsilon;
		double d4 = double.Epsilon;
		for (sbyte b = 0; b < paramInt; b++)
		{
		  double d5 = paramArrayOfDouble1[b];
		  d1 = Math.Min(d1, d5);
		  d3 = Math.Max(d3, d5);
		  double d6 = paramArrayOfDouble2[b];
		  d2 = Math.Min(d2, d6);
		  d4 = Math.Max(d4, d6);
		}
		this.bounds2d = new Rectangle2D.Double(d1, d2, d3 - d1, d4 - d2);
		this.bounds = new Rectangle((int)Math.Floor(d1), (int)Math.Floor(d2), (int)Math.Ceiling(d3 - d1), (int)Math.Ceiling(d4 - d2));
	  }

	  internal virtual void updateBounds(double paramDouble1, double paramDouble2)
	  {
		if ((int)paramDouble1 < this.bounds.x)
		{
		  this.bounds.width += this.bounds.x - (int)paramDouble1;
		  this.bounds.x = (int)paramDouble1;
		}
		else
		{
		  this.bounds.width = Math.Max(this.bounds.width, (int)Math.Ceiling(paramDouble1) - this.bounds.x);
		}
		if ((int)paramDouble2 < this.bounds.y)
		{
		  this.bounds.height += this.bounds.y - (int)paramDouble2;
		  this.bounds.y = (int)paramDouble2;
		}
		else
		{
		  this.bounds.height = Math.Max(this.bounds.height, (int)Math.Ceiling(paramDouble2) - this.bounds.y);
		}
	  }

	  public virtual void addPoint(double paramDouble1, double paramDouble2)
	  {
		if (this.npoints == this.xpoints.Length)
		{
		  double[] arrayOfDouble = new double[this.npoints * 2];
		  Array.Copy(this.xpoints, 0, arrayOfDouble, 0, this.npoints);
		  this.xpoints = arrayOfDouble;
		  arrayOfDouble = new double[this.npoints * 2];
		  Array.Copy(this.ypoints, 0, arrayOfDouble, 0, this.npoints);
		  this.ypoints = arrayOfDouble;
		}
		this.xpoints[this.npoints] = paramDouble1;
		this.ypoints[this.npoints] = paramDouble2;
		this.npoints++;
		if (this.bounds != null)
		{
		  updateBounds(paramDouble1, paramDouble2);
		}
	  }

	  public virtual Rectangle Bounds
	  {
		  get
		  {
			if (this.npoints == 0)
			{
			  return new Rectangle();
			}
			if (this.bounds == null)
			{
			  calculateBounds(this.xpoints, this.ypoints, this.npoints);
			}
			return this.bounds.Bounds;
		  }
	  }

	  public virtual Rectangle2D.Double Bounds2d
	  {
		  get
		  {
			calculateBounds(this.xpoints, this.ypoints, this.npoints);
			return this.bounds2d;
		  }
	  }

	  public virtual bool contains(Point paramPoint)
	  {
		  return contains(paramPoint.X, paramPoint.Y);
	  }

	  public virtual bool contains(int paramInt1, int paramInt2)
	  {
		  return contains(paramInt1, paramInt2);
	  }

	  public virtual Rectangle2D Bounds2D
	  {
		  get
		  {
			  return Bounds;
		  }
	  }

	  public virtual bool contains(double paramDouble1, double paramDouble2)
	  { // Byte code:
		//   0: aload_0
		//   1: getfield npoints : I
		//   4: iconst_2
		//   5: if_icmple -> 20
		//   8: aload_0
		//   9: invokevirtual getBounds : ()Ljava/awt/Rectangle;
		//   12: dload_1
		//   13: dload_3
		//   14: invokevirtual contains : (DD)Z
		//   17: ifne -> 22
		//   20: iconst_0
		//   21: ireturn
		//   22: iconst_0
		//   23: istore #5
		//   25: aload_0
		//   26: getfield xpoints : [D
		//   29: aload_0
		//   30: getfield npoints : I
		//   33: iconst_1
		//   34: isub
		//   35: daload
		//   36: dstore #6
		//   38: aload_0
		//   39: getfield ypoints : [D
		//   42: aload_0
		//   43: getfield npoints : I
		//   46: iconst_1
		//   47: isub
		//   48: daload
		//   49: dstore #8
		//   51: iconst_0
		//   52: istore #14
		//   54: iload #14
		//   56: aload_0
		//   57: getfield npoints : I
		//   60: if_icmpge -> 263
		//   63: aload_0
		//   64: getfield xpoints : [D
		//   67: iload #14
		//   69: daload
		//   70: dstore #10
		//   72: aload_0
		//   73: getfield ypoints : [D
		//   76: iload #14
		//   78: daload
		//   79: dstore #12
		//   81: dload #12
		//   83: dload #8
		//   85: dcmpl
		//   86: ifne -> 92
		//   89: goto -> 249
		//   92: dload #10
		//   94: dload #6
		//   96: dcmpg
		//   97: ifge -> 117
		//   100: dload_1
		//   101: dload #6
		//   103: dcmpl
		//   104: iflt -> 110
		//   107: goto -> 249
		//   110: dload #10
		//   112: dstore #15
		//   114: goto -> 131
		//   117: dload_1
		//   118: dload #10
		//   120: dcmpl
		//   121: iflt -> 127
		//   124: goto -> 249
		//   127: dload #6
		//   129: dstore #15
		//   131: dload #12
		//   133: dload #8
		//   135: dcmpg
		//   136: ifge -> 184
		//   139: dload_3
		//   140: dload #12
		//   142: dcmpg
		//   143: iflt -> 249
		//   146: dload_3
		//   147: dload #8
		//   149: dcmpl
		//   150: iflt -> 156
		//   153: goto -> 249
		//   156: dload_1
		//   157: dload #15
		//   159: dcmpg
		//   160: ifge -> 169
		//   163: iinc #5, 1
		//   166: goto -> 249
		//   169: dload_1
		//   170: dload #10
		//   172: dsub
		//   173: dstore #17
		//   175: dload_3
		//   176: dload #12
		//   178: dsub
		//   179: dstore #19
		//   181: goto -> 226
		//   184: dload_3
		//   185: dload #8
		//   187: dcmpg
		//   188: iflt -> 249
		//   191: dload_3
		//   192: dload #12
		//   194: dcmpl
		//   195: iflt -> 201
		//   198: goto -> 249
		//   201: dload_1
		//   202: dload #15
		//   204: dcmpg
		//   205: ifge -> 214
		//   208: iinc #5, 1
		//   211: goto -> 249
		//   214: dload_1
		//   215: dload #6
		//   217: dsub
		//   218: dstore #17
		//   220: dload_3
		//   221: dload #8
		//   223: dsub
		//   224: dstore #19
		//   226: dload #17
		//   228: dload #19
		//   230: dload #8
		//   232: dload #12
		//   234: dsub
		//   235: ddiv
		//   236: dload #6
		//   238: dload #10
		//   240: dsub
		//   241: dmul
		//   242: dcmpg
		//   243: ifge -> 249
		//   246: iinc #5, 1
		//   249: dload #10
		//   251: dstore #6
		//   253: dload #12
		//   255: dstore #8
		//   257: iinc #14, 1
		//   260: goto -> 54
		//   263: iload #5
		//   265: iconst_1
		//   266: iand
		//   267: ifeq -> 274
		//   270: iconst_1
		//   271: goto -> 275
		//   274: iconst_0
		//   275: ireturn }

	  private Crossings getCrossings(double paramDouble1, double paramDouble2, double paramDouble3, double paramDouble4)
	  {
		Crossings.EvenOdd evenOdd = new Crossings.EvenOdd(paramDouble1, paramDouble2, paramDouble3, paramDouble4);
		double d1 = this.xpoints[this.npoints - 1];
		double d2 = this.ypoints[this.npoints - 1];
		for (sbyte b = 0; b < this.npoints; b++)
		{
		  double d3 = this.xpoints[b];
		  double d4 = this.ypoints[b];
		  if (evenOdd.accumulateLine(d1, d2, d3, d4))
		  {
			return null;
		  }
		  d1 = d3;
		  d2 = d4;
		}
		return evenOdd;
	  }

	  public bool contains(Point2D paramPoint2D)
	  {
		  return contains(paramPoint2D.X, paramPoint2D.Y);
	  }

	  public bool intersects(double paramDouble1, double paramDouble2, double paramDouble3, double paramDouble4)
	  {
		if (this.npoints <= 0 || !Bounds.intersects(paramDouble1, paramDouble2, paramDouble3, paramDouble4))
		{
		  return false;
		}
		Crossings crossings = getCrossings(paramDouble1, paramDouble2, paramDouble1 + paramDouble3, paramDouble2 + paramDouble4);
		return (crossings == null || !crossings.Empty);
	  }

	  public bool intersects(Rectangle2D paramRectangle2D)
	  {
		  return intersects(paramRectangle2D.X, paramRectangle2D.Y, paramRectangle2D.Width, paramRectangle2D.Height);
	  }

	  public bool contains(double paramDouble1, double paramDouble2, double paramDouble3, double paramDouble4)
	  {
		if (this.npoints <= 0 || !Bounds.intersects(paramDouble1, paramDouble2, paramDouble3, paramDouble4))
		{
		  return false;
		}
		Crossings crossings = getCrossings(paramDouble1, paramDouble2, paramDouble1 + paramDouble3, paramDouble2 + paramDouble4);
		return (crossings != null && crossings.covers(paramDouble2, paramDouble2 + paramDouble4));
	  }

	  public bool contains(Rectangle2D paramRectangle2D)
	  {
		  return contains(paramRectangle2D.X, paramRectangle2D.Y, paramRectangle2D.Width, paramRectangle2D.Height);
	  }

	  public PathIterator getPathIterator(AffineTransform paramAffineTransform)
	  {
		  return new Polygon2DPathIterator(this, paramAffineTransform);
	  }

	  public PathIterator getPathIterator(AffineTransform paramAffineTransform, double paramDouble)
	  {
		  return getPathIterator(paramAffineTransform);
	  }

//JAVA TO C# CONVERTER TODO TASK: Local classes are not converted by Java to C# Converter:
//	  class Polygon2DPathIterator implements java.awt.geom.PathIterator
	//  {
	//	Polygon2D poly;
	//
	//	AffineTransform transform;
	//
	//	int index;
	//
	//	public Polygon2DPathIterator(Polygon2D param1Polygon2D1, AffineTransform param1AffineTransform)
	//	{
	//	  this.poly = param1Polygon2D1;
	//	  this.transform = param1AffineTransform;
	//	  if (param1Polygon2D1.npoints == 0)
	//		this.index = 1;
	//	}
	//
	//	public int getWindingRule()
	//	{
	//		return 0;
	//	}
	//
	//	public boolean isDone()
	//	{
	//		return (this.index > this.poly.npoints);
	//	}
	//
	//	public void next()
	//	{
	//		this.index++;
	//	}
	//
	//	public int currentSegment(float[] param1ArrayOfFloat)
	//	{
	//	  if (this.index >= this.poly.npoints)
	//		return 4;
	//	  param1ArrayOfFloat[0] = (float)this.poly.xpoints[this.index];
	//	  param1ArrayOfFloat[1] = (float)this.poly.ypoints[this.index];
	//	  if (this.transform != null)
	//		this.transform.transform(param1ArrayOfFloat, 0, param1ArrayOfFloat, 0, 1);
	//	  return (this.index == 0) ? 0 : 1;
	//	}
	//
	//	public int currentSegment(double[] param1ArrayOfDouble)
	//	{
	//	  if (this.index >= this.poly.npoints)
	//		return 4;
	//	  param1ArrayOfDouble[0] = this.poly.xpoints[this.index];
	//	  param1ArrayOfDouble[1] = this.poly.ypoints[this.index];
	//	  if (this.transform != null)
	//		this.transform.transform(param1ArrayOfDouble, 0, param1ArrayOfDouble, 0, 1);
	//	  return (this.index == 0) ? 0 : 1;
	//	}
	//  }
	  }


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\geom\Polygon2D.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
	}