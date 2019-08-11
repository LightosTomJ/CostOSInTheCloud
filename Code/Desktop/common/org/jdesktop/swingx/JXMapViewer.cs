using System;
using System.Collections.Generic;

namespace Desktop.common.org.jdesktop.swingx
{
	using GeoPosition = org.jdesktop.swingx.mapviewer.GeoPosition;
	using Tile = org.jdesktop.swingx.mapviewer.Tile;
	using TileFactory = org.jdesktop.swingx.mapviewer.TileFactory;
	using TileFactoryInfo = org.jdesktop.swingx.mapviewer.TileFactoryInfo;
	using EmptyTileFactory = org.jdesktop.swingx.mapviewer.empty.EmptyTileFactory;
	using AbstractPainter = org.jdesktop.swingx.painter.AbstractPainter;
	using Painter = org.jdesktop.swingx.painter.Painter;

	public class JXMapViewer : JXPanel, DesignMode
	{
		private bool InstanceFieldsInitialized = false;

		private void InitializeInstanceFields()
		{
			tileLoadListener = new TileLoadListener(this, null);
		}

	  private readonly bool isNegativeYAllowed = true;

	  private int zoom = 1;

	  private Point2D center = new Point2D.Double(0.0D, 0.0D);

	  private bool drawTileBorders = false;

	  private TileFactory factory = new EmptyTileFactory();

	  private GeoPosition addressLocation;

	  private bool panEnabled = true;

	  private bool zoomEnabled = true;

	  private bool recenterOnClickEnabled = true;

	  private Painter overlay;

	  private bool designTime;

	  private float zoomScale = 1.0F;

	  private Image loadingImage;

	  private bool restrictOutsidePanning = false;

	  private bool horizontalWrapped = true;

	  private TileLoadListener tileLoadListener;

	  public JXMapViewer()
	  {
		  if (!InstanceFieldsInitialized)
		  {
			  InitializeInstanceFields();
			  InstanceFieldsInitialized = true;
		  }
		PanMouseInputListener panMouseInputListener = new PanMouseInputListener(this, null);
		RecenterOnClickEnabled = false;
		addMouseListener(panMouseInputListener);
		addMouseMotionListener(panMouseInputListener);
		addMouseWheelListener(new ZoomMouseWheelListener(this, null));
		addKeyListener(new PanKeyListener(this, null));
		try
		{
		  URL uRL = this.GetType().getResource("mapviewer/resources/loading.png");
		  LoadingImage = ImageIO.read(uRL);
		}
		catch (Exception)
		{
		  Console.WriteLine("could not load 'loading.png'");
		  BufferedImage bufferedImage = new BufferedImage(16, 16, 2);
		  Graphics2D graphics2D = bufferedImage.createGraphics();
		  graphics2D.Color = Color.black;
		  graphics2D.fillRect(0, 0, 16, 16);
		  graphics2D.dispose();
		  LoadingImage = bufferedImage;
		}
		BackgroundPainter = new AbstractPainterAnonymousInnerClass(this);
	  }

	  private class AbstractPainterAnonymousInnerClass : AbstractPainter<JXPanel>
	  {
		  private readonly JXMapViewer outerInstance;

		  public AbstractPainterAnonymousInnerClass(JXMapViewer outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal void doPaint(Graphics2D param1Graphics2D, JXPanel param1JXPanel, int param1Int1, int param1Int2)
		  {
			  outerInstance.doPaintComponent(param1Graphics2D);
		  }
	  }

	  private void doPaintComponent(Graphics paramGraphics)
	  {
		if (!DesignTime)
		{
		  int i = Zoom;
		  Rectangle rectangle = ViewportBounds;
		  drawMapTiles(paramGraphics, i, rectangle);
		  drawOverlays(i, paramGraphics, rectangle);
		}
		paintBorder(paramGraphics);
	  }

	  public virtual bool DesignTime
	  {
		  set
		  {
			  this.designTime = value;
		  }
		  get
		  {
			  return this.designTime;
		  }
	  }


	  private static void p(string paramString)
	  {
		  Console.WriteLine(paramString);
	  }

	  protected internal virtual void drawMapTiles(Graphics paramGraphics, int paramInt, Rectangle paramRectangle)
	  {
		int i = TileFactory.getTileSize(paramInt);
		Dimension dimension = TileFactory.getMapSize(paramInt);
		int j = paramRectangle.width / i + 2;
		int k = paramRectangle.height / i + 2;
		TileFactoryInfo tileFactoryInfo = TileFactory.Info;
		int m = (int)Math.Floor(paramRectangle.X / tileFactoryInfo.getTileSize(0));
		int n = (int)Math.Floor(paramRectangle.Y / tileFactoryInfo.getTileSize(0));
		for (int i1 = 0; i1 <= j; i1++)
		{
		  for (int i2 = 0; i2 <= k; i2++)
		  {
			int i3 = i1 + m;
			int i4 = i2 + n;
			if (paramGraphics.ClipBounds.intersects(new Rectangle(i3 * i - paramRectangle.x, i4 * i - paramRectangle.y, i, i)))
			{
			  Tile tile = TileFactory.getTile(i3, i4, paramInt);
			  if (!tile.Loaded)
			  {
				tile.addUniquePropertyChangeListener("loaded", this.tileLoadListener);
			  }
			  int i5 = i3 * TileFactory.getTileSize(paramInt) - paramRectangle.x;
			  int i6 = i4 * TileFactory.getTileSize(paramInt) - paramRectangle.y;
			  if (isTileOnMap(i3, i4, dimension))
			  {
				if (Opaque)
				{
				  paramGraphics.Color = Background;
				  paramGraphics.fillRect(i5, i6, i, i);
				}
			  }
			  else if (tile.Loaded)
			  {
				paramGraphics.drawImage(tile.Image, i5, i6, null);
			  }
			  else
			  {
				int i7 = (TileFactory.getTileSize(paramInt) - LoadingImage.getWidth(null)) / 2;
				int i8 = (TileFactory.getTileSize(paramInt) - LoadingImage.getHeight(null)) / 2;
				paramGraphics.Color = Color.GRAY;
				paramGraphics.fillRect(i5, i6, i, i);
				paramGraphics.drawImage(LoadingImage, i5 + i7, i6 + i8, null);
			  }
			  if (DrawTileBorders)
			  {
				paramGraphics.Color = Color.black;
				paramGraphics.drawRect(i5, i6, i, i);
				paramGraphics.drawRect(i5 + i / 2 - 5, i6 + i / 2 - 5, 10, 10);
				paramGraphics.Color = Color.white;
				paramGraphics.drawRect(i5 + 1, i6 + 1, i, i);
				string str = i3 + ", " + i4 + ", " + Zoom;
				paramGraphics.Color = Color.BLACK;
				paramGraphics.drawString(str, i5 + 10, i6 + 30);
				paramGraphics.drawString(str, i5 + 10 + 2, i6 + 30 + 2);
				paramGraphics.Color = Color.WHITE;
				paramGraphics.drawString(str, i5 + 10 + 1, i6 + 30 + 1);
			  }
			}
		  }
		}
	  }

	  private void drawOverlays(int paramInt, Graphics paramGraphics, Rectangle paramRectangle)
	  {
		if (this.overlay != null)
		{
		  this.overlay.paint((Graphics2D)paramGraphics, this, Width, Height);
		}
	  }

	  private bool isTileOnMap(int paramInt1, int paramInt2, Dimension paramDimension)
	  {
		  return (paramInt2 >= paramDimension.Height);
	  }

	  public virtual Painter OverlayPainter
	  {
		  set
		  {
			Painter painter = OverlayPainter;
			this.overlay = value;
			firePropertyChange("mapOverlay", painter, OverlayPainter);
			repaint();
		  }
		  get
		  {
			  return this.overlay;
		  }
	  }


	  public virtual Rectangle ViewportBounds
	  {
		  get
		  {
			  return calculateViewportBounds(Center);
		  }
	  }

	  private Rectangle calculateViewportBounds(Point2D paramPoint2D)
	  {
		Insets insets = Insets;
		int i = Width - insets.left - insets.right;
		int j = Height - insets.top - insets.bottom;
		double d1 = paramPoint2D.X - (i / 2);
		double d2 = paramPoint2D.Y - (j / 2);
		return new Rectangle((int)d1, (int)d2, i, j);
	  }

	  public virtual bool RecenterOnClickEnabled
	  {
		  set
		  {
			bool @bool = RecenterOnClickEnabled;
			this.recenterOnClickEnabled = value;
			firePropertyChange("recenterOnClickEnabled", @bool, RecenterOnClickEnabled);
		  }
		  get
		  {
			  return this.recenterOnClickEnabled;
		  }
	  }


	  public virtual int ZoomNoRepaint
	  {
		  set
		  {
			if (value == this.zoom)
			{
			  return;
			}
			TileFactoryInfo tileFactoryInfo = TileFactory.Info;
			if (tileFactoryInfo != null && (value < tileFactoryInfo.MinimumZoomLevel || value > tileFactoryInfo.MaximumZoomLevel))
			{
			  return;
			}
			int i = this.zoom;
			Point2D point2D = Center;
			Dimension dimension = TileFactory.getMapSize(i);
			this.zoom = value;
		  }
	  }

	  public virtual int Zoom
	  {
		  set
		  {
			if (value == this.zoom)
			{
			  return;
			}
			TileFactoryInfo tileFactoryInfo = TileFactory.Info;
			if (tileFactoryInfo != null && (value < tileFactoryInfo.MinimumZoomLevel || value > tileFactoryInfo.MaximumZoomLevel))
			{
			  return;
			}
			int i = this.zoom;
			Point2D point2D = Center;
			Dimension dimension1 = TileFactory.getMapSize(i);
			this.zoom = value;
			firePropertyChange("zoom", i, value);
			Dimension dimension2 = TileFactory.getMapSize(value);
			Center = new Point2D.Double(point2D.X * dimension2.Width / dimension1.Width, point2D.Y * dimension2.Height / dimension1.Height);
			repaint();
		  }
		  get
		  {
			  return this.zoom;
		  }
	  }


	  public virtual GeoPosition AddressLocation
	  {
		  get
		  {
			  return this.addressLocation;
		  }
		  set
		  {
			GeoPosition geoPosition = AddressLocation;
			this.addressLocation = value;
			Center = TileFactory.geoToPixel(value, Zoom);
			firePropertyChange("addressLocation", geoPosition, AddressLocation);
			repaint();
		  }
	  }


	  public virtual void recenterToAddressLocation()
	  {
		Center = TileFactory.geoToPixel(AddressLocation, Zoom);
		repaint();
	  }

	  public virtual bool DrawTileBorders
	  {
		  get
		  {
			  return this.drawTileBorders;
		  }
		  set
		  {
			bool @bool = DrawTileBorders;
			this.drawTileBorders = value;
			firePropertyChange("drawTileBorders", @bool, DrawTileBorders);
			repaint();
		  }
	  }


	  public virtual bool PanEnabled
	  {
		  get
		  {
			  return this.panEnabled;
		  }
		  set
		  {
			bool @bool = PanEnabled;
			this.panEnabled = value;
			firePropertyChange("panEnabled", @bool, PanEnabled);
		  }
	  }


	  public virtual bool ZoomEnabled
	  {
		  get
		  {
			  return this.zoomEnabled;
		  }
		  set
		  {
			bool @bool = ZoomEnabled;
			this.zoomEnabled = value;
			firePropertyChange("zoomEnabled", @bool, ZoomEnabled);
		  }
	  }


	  public virtual GeoPosition CenterPosition
	  {
		  set
		  {
			GeoPosition geoPosition1 = CenterPosition;
			Center = TileFactory.geoToPixel(value, this.zoom);
			repaint();
			GeoPosition geoPosition2 = CenterPosition;
			firePropertyChange("centerPosition", geoPosition1, geoPosition2);
		  }
		  get
		  {
			  return TileFactory.pixelToGeo(Center, this.zoom);
		  }
	  }


	  public virtual TileFactory TileFactory
	  {
		  get
		  {
			  return this.factory;
		  }
		  set
		  {
			this.factory = value;
			Zoom = value.Info.DefaultZoomLevel;
		  }
	  }


	  public virtual Image LoadingImage
	  {
		  get
		  {
			  return this.loadingImage;
		  }
		  set
		  {
			  this.loadingImage = value;
		  }
	  }


	  public virtual Point2D Center
	  {
		  get
		  {
			  return this.center;
		  }
		  set
		  {
			Point2D point2D = Center;
			if (RestrictOutsidePanning)
			{
			  Insets insets = Insets;
			  int i = Height - insets.top - insets.bottom;
			  int j = Width - insets.left - insets.right;
			  Rectangle rectangle = calculateViewportBounds(value);
			  if (rectangle.Y < 0.0D)
			  {
				double d = (i / 2);
				value = new Point2D.Double(value.X, d);
			  }
			  if (!HorizontalWrapped && rectangle.X < 0.0D)
			  {
				double d = (j / 2);
				value = new Point2D.Double(d, value.Y);
			  }
			  Dimension dimension = TileFactory.getMapSize(Zoom);
			  int k = (int)dimension.Height * TileFactory.getTileSize(Zoom);
			  if (rectangle.Y + rectangle.Height > k)
			  {
				double d = (k - i / 2);
				value = new Point2D.Double(value.X, d);
			  }
			  int m = (int)dimension.Width * TileFactory.getTileSize(Zoom);
			  if (!HorizontalWrapped && rectangle.X + rectangle.Width > m)
			  {
				double d = (m - j / 2);
				value = new Point2D.Double(d, value.Y);
			  }
			  if (k < rectangle.Height)
			  {
				double d = (k / 2);
				value = new Point2D.Double(value.X, d);
			  }
			  if (!HorizontalWrapped && m < rectangle.Width)
			  {
				double d = (m / 2);
				value = new Point2D.Double(d, value.Y);
			  }
			}
			point2D = new Point(5, 6);
			GeoPosition geoPosition = CenterPosition;
			this.center = value;
			firePropertyChange("center", point2D, this.center);
			firePropertyChange("centerPosition", geoPosition, CenterPosition);
			repaint();
		  }
	  }


	  public virtual void calculateZoomFrom(ISet<GeoPosition> paramSet)
	  {
		if (paramSet.Count < 2)
		{
		  return;
		}
		int i = Zoom;
		Rectangle2D rectangle2D = generateBoundingRect(paramSet, i);
		sbyte b = 0;
		while (!ViewportBounds.contains(rectangle2D))
		{
		  Point2D.Double double = new Point2D.Double(rectangle2D.X + rectangle2D.Width / 2.0D, rectangle2D.Y + rectangle2D.Height / 2.0D);
		  GeoPosition geoPosition = TileFactory.pixelToGeo(double, i);
		  CenterPosition = geoPosition;
		  if (++b > 30 || ViewportBounds.contains(rectangle2D) || ++i > 15)
		  {
			break;
		  }
		  Zoom = i;
		  rectangle2D = generateBoundingRect(paramSet, i);
		}
	  }

	  private Rectangle2D generateBoundingRect(ISet<GeoPosition> paramSet, int paramInt)
	  {
		Point2D point2D = TileFactory.geoToPixel((GeoPosition)paramSet.GetEnumerator().next(), paramInt);
		Rectangle2D.Double double = new Rectangle2D.Double(point2D.X, point2D.Y, 0.0D, 0.0D);
		foreach (GeoPosition geoPosition in paramSet)
		{
		  Point2D point2D1 = TileFactory.geoToPixel(geoPosition, paramInt);
		  double.add(point2D1);
		}
		return double;
	  }

	  public virtual bool RestrictOutsidePanning
	  {
		  get
		  {
			  return this.restrictOutsidePanning;
		  }
		  set
		  {
			  this.restrictOutsidePanning = value;
		  }
	  }


	  public virtual bool HorizontalWrapped
	  {
		  get
		  {
			  return this.horizontalWrapped;
		  }
		  set
		  {
			  this.horizontalWrapped = value;
		  }
	  }


	  public virtual Point2D convertGeoPositionToPoint(GeoPosition paramGeoPosition)
	  {
		Point2D point2D = TileFactory.geoToPixel(paramGeoPosition, Zoom);
		Rectangle rectangle = ViewportBounds;
		return new Point2D.Double(point2D.X - rectangle.X, point2D.Y - rectangle.Y);
	  }

	  public virtual GeoPosition convertPointToGeoPosition(Point2D paramPoint2D)
	  {
		Rectangle rectangle = ViewportBounds;
		Point2D.Double double = new Point2D.Double(paramPoint2D.X + rectangle.X, paramPoint2D.Y + rectangle.Y);
		return TileFactory.pixelToGeo(double, Zoom);
	  }

	  private sealed class TileLoadListener : PropertyChangeListener
	  {
		  private readonly JXMapViewer outerInstance;

		internal TileLoadListener(JXMapViewer outerInstance)
		{
			this.outerInstance = outerInstance;
		}

		public void propertyChange(PropertyChangeEvent param1PropertyChangeEvent)
		{
		  if ("loaded".Equals(param1PropertyChangeEvent.PropertyName) && true.Equals(param1PropertyChangeEvent.NewValue))
		  {
			Tile tile = (Tile)param1PropertyChangeEvent.Source;
			if (tile.Zoom == outerInstance.Zoom)
			{
			  outerInstance.repaint();
			}
		  }
		}
	  }

	  private class PanKeyListener : KeyAdapter
	  {
		  private readonly JXMapViewer outerInstance;

		internal const int OFFSET = 10;

		internal PanKeyListener(JXMapViewer outerInstance)
		{
			this.outerInstance = outerInstance;
		}

		public virtual void keyPressed(KeyEvent param1KeyEvent)
		{
		  sbyte b1 = 0;
		  sbyte b2 = 0;
		  switch (param1KeyEvent.KeyCode)
		  {
			case 37:
			  b1 = -10;
			  break;
			case 39:
			  b1 = 10;
			  break;
			case 38:
			  b2 = -10;
			  break;
			case 40:
			  b2 = 10;
			  break;
		  }
		  if (b1 != 0 || b2 != 0)
		  {
			Rectangle rectangle = outerInstance.ViewportBounds;
			double d1 = rectangle.CenterX + b1;
			double d2 = rectangle.CenterY + b2;
			outerInstance.Center = new Point2D.Double(d1, d2);
			outerInstance.repaint();
		  }
		}
	  }

	  private class PanMouseInputListener : MouseInputListener
	  {
		  private readonly JXMapViewer outerInstance;

		internal Point prev;

		internal PanMouseInputListener(JXMapViewer outerInstance)
		{
			this.outerInstance = outerInstance;
		}

		public virtual void mousePressed(MouseEvent param1MouseEvent)
		{
		  if (outerInstance.RecenterOnClickEnabled && (SwingUtilities.isMiddleMouseButton(param1MouseEvent) || (SwingUtilities.isLeftMouseButton(param1MouseEvent) && param1MouseEvent.ClickCount == 2)))
		  {
			recenterMap(param1MouseEvent);
		  }
		  else
		  {
			this.prev = param1MouseEvent.Point;
		  }
		}

		internal virtual void recenterMap(MouseEvent param1MouseEvent)
		{
		  Rectangle rectangle = outerInstance.ViewportBounds;
		  double d1 = rectangle.X + param1MouseEvent.X;
		  double d2 = rectangle.Y + param1MouseEvent.Y;
		  outerInstance.Center = new Point2D.Double(d1, d2);
		  outerInstance.repaint();
		}

		public virtual void mouseDragged(MouseEvent param1MouseEvent)
		{
		  if (outerInstance.PanEnabled)
		  {
			Point point = param1MouseEvent.Point;
			double d1 = outerInstance.Center.X - (point.x - this.prev.x);
			double d2 = outerInstance.Center.Y - (point.y - this.prev.y);
			int i = (int)(outerInstance.TileFactory.getMapSize(outerInstance.Zoom).Height * outerInstance.TileFactory.getTileSize(outerInstance.Zoom));
			if (d2 > i)
			{
			  d2 = i;
			}
			this.prev = point;
			outerInstance.Center = new Point2D.Double(d1, d2);
			outerInstance.repaint();
			outerInstance.Cursor = Cursor.getPredefinedCursor(13);
		  }
		}

		public virtual void mouseReleased(MouseEvent param1MouseEvent)
		{
		  this.prev = null;
		  outerInstance.Cursor = Cursor.getPredefinedCursor(0);
		}

		public virtual void mouseMoved(MouseEvent param1MouseEvent)
		{
			SwingUtilities.invokeLater(() =>
			{
			JXMapViewer.PanMouseInputListener.this.this$0.requestFocusInWindow();
			});
		}

		public virtual void mouseClicked(MouseEvent param1MouseEvent)
		{
		}

		public virtual void mouseEntered(MouseEvent param1MouseEvent)
		{
		}

		public virtual void mouseExited(MouseEvent param1MouseEvent)
		{
		}
	  }

	  private class ZoomMouseWheelListener : MouseWheelListener
	  {
		  private readonly JXMapViewer outerInstance;

		internal ZoomMouseWheelListener(JXMapViewer outerInstance)
		{
			this.outerInstance = outerInstance;
		}

		public virtual void mouseWheelMoved(MouseWheelEvent param1MouseWheelEvent)
		{
		  if (outerInstance.ZoomEnabled)
		  {
			outerInstance.Zoom = outerInstance.Zoom + param1MouseWheelEvent.WheelRotation;
		  }
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\org\jdesktop\swingx\JXMapViewer.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}