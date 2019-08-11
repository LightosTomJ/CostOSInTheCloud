namespace Desktop.common.nomitech.common.laf
{
	using HighlightFactory = org.officelaf.util.HighlightFactory;
	using AbstractCommandButton = org.pushingpixels.flamingo.api.common.AbstractCommandButton;
	using CommandButtonDisplayState = org.pushingpixels.flamingo.api.common.CommandButtonDisplayState;
	using JCommandButton = org.pushingpixels.flamingo.api.common.JCommandButton;
	using JCommandButtonStrip = org.pushingpixels.flamingo.api.common.JCommandButtonStrip;
	using ActionButtonModel = org.pushingpixels.flamingo.api.common.model.ActionButtonModel;
	using PopupButtonModel = org.pushingpixels.flamingo.api.common.model.PopupButtonModel;

	public class CostOSCommandButtonPainter
	{
	  public static Color NORMAL_BORDER_COLOR = CostOSWindowsLookAndFeel.ribbonBorderColor;

	  public static Color TEXT_COLOR = CostOSWindowsLookAndFeel.ribbonCommandButtonForegroundColor;

	  public static Color DISABLED_TEXT_COLOR = CostOSWindowsLookAndFeel.ribbonCommandButtonDisabledForegroundColor;

	  private AbstractCommandButton commandButton;

	  private bool isRollover = false;

	  private bool isPressed = false;

	  private bool isSelected = false;

	  private bool isPopupRollover = false;

	  private bool isActionEnabled = false;

	  private bool isPopupEnabled = false;

	  private bool isPopupOnly = false;

	  private bool isInStrip = false;

	  private bool isFirstInStrip = false;

	  private bool isLastInStrip = false;

	  private bool isStripVertical = false;

	  private bool ignorePressed = false;

	  private BufferedImage highlightImage;

	  internal object oldAa;

	  internal Composite oldComposite;

	  protected internal static readonly Color selectionColor = CostOSWindowsLookAndFeel.ribbonButtonSelectionColor;

	  protected internal static readonly Color selectionDarkerColor = CostOSWindowsLookAndFeel.ribbonButtonSelectionDarkerColor;

	  protected internal static readonly Color highlightColor = CostOSWindowsLookAndFeel.ribbonRollOverBackground;

	  protected internal static readonly Color cornerColor = Color.red;

	  protected internal static readonly Color backgroundColor = CostOSWindowsLookAndFeel.ribbonTaksAreaBackground;

	  protected internal static readonly Color taskColor = CostOSWindowsLookAndFeel.ribbonTaksAreaBackground;

	  protected internal static readonly Color borderColor = CostOSWindowsLookAndFeel.ribbonBorderColor;

	  protected internal static readonly Color backgroundPressedColor = backgroundColor.darker();

	  protected internal static readonly Color borderPressedColor = borderColor.darker();

	  protected internal static readonly Color highlightPressedColor = highlightColor.darker();

	  public CostOSCommandButtonPainter(AbstractCommandButton paramAbstractCommandButton) : this(paramAbstractCommandButton, false)
	  {
	  }

	  public CostOSCommandButtonPainter(AbstractCommandButton paramAbstractCommandButton, bool paramBoolean)
	  {
		this.commandButton = paramAbstractCommandButton;
		this.ignorePressed = paramBoolean;
	  }

	  protected internal virtual void updateState()
	  {
		ActionButtonModel actionButtonModel = this.commandButton.ActionModel;
		PopupButtonModel popupButtonModel = null;
		if (this.commandButton is JCommandButton)
		{
		  JCommandButton jCommandButton = (JCommandButton)this.commandButton;
		  popupButtonModel = jCommandButton.PopupModel;
		  this.isPopupOnly = (jCommandButton.CommandButtonKind == JCommandButton.CommandButtonKind.POPUP_ONLY);
		}
		this.isActionEnabled = (actionButtonModel != null && actionButtonModel.Enabled);
		this.isPopupEnabled = (popupButtonModel != null && popupButtonModel.Enabled);
		this.isPressed = ((!this.ignorePressed && actionButtonModel != null && actionButtonModel.Pressed) || (popupButtonModel != null && popupButtonModel.Pressed));
		this.isSelected = ((actionButtonModel != null && actionButtonModel.Selected) || (popupButtonModel != null && popupButtonModel.Selected));
		this.isRollover = ((actionButtonModel != null && actionButtonModel.Rollover) || (popupButtonModel != null && (popupButtonModel.Rollover || popupButtonModel.PopupShowing)));
		this.isPopupRollover = (popupButtonModel != null && popupButtonModel.Rollover);
		if (this.commandButton.Parent is JCommandButtonStrip)
		{
		  JCommandButtonStrip jCommandButtonStrip = (JCommandButtonStrip)this.commandButton.Parent;
		  this.isInStrip = true;
		  this.isFirstInStrip = jCommandButtonStrip.isFirst(this.commandButton);
		  this.isLastInStrip = jCommandButtonStrip.isLast(this.commandButton);
		  this.isStripVertical = (jCommandButtonStrip.Orientation == JCommandButtonStrip.StripOrientation.VERTICAL);
		}
	  }

	  public virtual void paintBackground(Graphics paramGraphics, Rectangle paramRectangle)
	  {
		Graphics2D graphics2D = (Graphics2D)paramGraphics.create();
		int i = paramRectangle.x;
		int j = paramRectangle.y;
		int k = paramRectangle.width;
		int m = paramRectangle.height;
		updateState();
		if (this.isPressed || this.isSelected)
		{
		  if (this.commandButton is CostOSRibbonApplicationMenuPopupPanel.JCommandAppMenuButton)
		  {
			graphics2D.Color = CostOSWindowsLookAndFeel.ribbonAppMenuButtonRolloverDarkerColor;
		  }
		  else if (this.commandButton is CostOSRibbonApplicationMenuPopupPanel.JCommandFooterButton)
		  {
			graphics2D.Color = CostOSWindowsLookAndFeel.applicationButtonSelectedColor;
		  }
		  else
		  {
			graphics2D.Color = selectionDarkerColor;
		  }
		  graphics2D.fillRect(i + 1, j + 1, k - 2, m - 2);
		}
		else
		{
		  if (this.commandButton is CostOSRibbonApplicationMenuPopupPanel.JCommandAppMenuButton)
		  {
			graphics2D.Color = CostOSWindowsLookAndFeel.ribbonAppMenuButtonRolloverColor;
		  }
		  else if (this.commandButton is CostOSRibbonApplicationMenuPopupPanel.JCommandFooterButton)
		  {
			graphics2D.Color = CostOSWindowsLookAndFeel.applicationButtonColor;
		  }
		  else
		  {
			graphics2D.Color = selectionColor;
		  }
		  graphics2D.fillRect(i + 1, j + 1, k - 2, m - 2);
		}
		graphics2D.dispose();
	  }

	  protected internal virtual void paintNormalBackground(Graphics2D paramGraphics2D, int paramInt1, int paramInt2, int paramInt3, int paramInt4)
	  {
		int i = paramInt1 + paramInt3 - 1;
		int j = paramInt2 + paramInt4 - 1;
		int k = (this.isInStrip && !this.isStripVertical && !this.isFirstInStrip) ? paramInt1 : (paramInt1 + 1);
		int m = paramInt2;
		int n = (this.isInStrip && !this.isLastInStrip && !this.isStripVertical) ? i : (i - 1);
		int i1 = (this.isInStrip && !this.isLastInStrip && this.isStripVertical) ? j : (j - 1);
		paramGraphics2D.Paint = new LinearGradientPaint(k, m, k, i1, new float[] {0.0F, 0.4F, 0.41F, 1.0F}, new Color[] {new Color(14081759), new Color(14410468), new Color(13818331), new Color(14738919)});
		paramGraphics2D.fillRect(k, m, n - k + 1, i1 - m + 1);
		setAlpha(paramGraphics2D, 0.3F);
		paramGraphics2D.Color = Color.WHITE;
		k = paramInt1 + 1;
		m = (this.isInStrip && this.isStripVertical && !this.isFirstInStrip) ? paramInt2 : (paramInt2 + 1);
		n = i - 1;
		i1 = m;
		paramGraphics2D.drawLine(k, m, n, i1);
		if (!this.isInStrip || !this.isStripVertical || (this.isLastInStrip && this.isStripVertical))
		{
		  k = paramInt1 + 1;
		  m = j - 1;
		  n = i - 1;
		  i1 = m;
		  paramGraphics2D.drawLine(k, m, n, i1);
		}
		k = (this.isInStrip && !this.isStripVertical && !this.isFirstInStrip) ? paramInt1 : (paramInt1 + 1);
		m = paramInt2 + 1;
		n = k;
		i1 = j - 1;
		paramGraphics2D.drawLine(k, m, n, i1);
		if (!this.isInStrip || this.isStripVertical || (this.isLastInStrip && !this.isStripVertical))
		{
		  k = i - 1;
		  m = paramInt2 + 1;
		  n = k;
		  i1 = j - 1;
		  paramGraphics2D.drawLine(k, m, n, i1);
		}
		resetAlpha(paramGraphics2D);
		paramGraphics2D.Color = NORMAL_BORDER_COLOR;
		if (!this.isInStrip || !this.isStripVertical || (this.isFirstInStrip && this.isStripVertical))
		{
		  k = (!this.isInStrip || this.isFirstInStrip) ? (paramInt1 + 1) : paramInt1;
		  m = paramInt2;
		  n = (!this.isInStrip || this.isLastInStrip || (this.isFirstInStrip && this.isStripVertical)) ? (i - 1) : i;
		  i1 = m;
		  paramGraphics2D.drawLine(k, m, n, i1);
		}
		k = (!this.isInStrip || this.isFirstInStrip) ? (paramInt1 + 1) : paramInt1;
		m = j;
		n = (!this.isInStrip || this.isLastInStrip || (this.isFirstInStrip && this.isStripVertical)) ? (i - 1) : i;
		i1 = m;
		paramGraphics2D.drawLine(k, m, n, i1);
		if (!this.isInStrip || this.isStripVertical || (this.isFirstInStrip && !this.isStripVertical))
		{
		  k = paramInt1;
		  m = (!this.isInStrip || this.isFirstInStrip) ? (paramInt2 + 1) : paramInt2;
		  n = paramInt1;
		  i1 = (!this.isInStrip || this.isFirstInStrip || (this.isLastInStrip && this.isStripVertical)) ? (j - 1) : j;
		  paramGraphics2D.drawLine(k, m, n, i1);
		}
		k = i;
		m = (!this.isInStrip || (this.isLastInStrip && !this.isStripVertical) || (this.isFirstInStrip && this.isStripVertical)) ? (paramInt2 + 1) : paramInt2;
		n = i;
		i1 = (!this.isInStrip || this.isLastInStrip) ? (j - 1) : j;
		if (!this.isLastInStrip && !this.isStripVertical)
		{
		  setAlpha(paramGraphics2D, 0.3F);
		}
		paramGraphics2D.drawLine(k, m, n, i1);
		if (!this.isLastInStrip && !this.isStripVertical)
		{
		  resetAlpha(paramGraphics2D);
		}
		setAlpha(paramGraphics2D, 0.5F);
		if (!this.isInStrip || this.isFirstInStrip)
		{
		  paramGraphics2D.drawLine(paramInt1 + 1, paramInt2 + 1, paramInt1 + 1, paramInt2 + 1);
		}
		if (!this.isInStrip || (this.isFirstInStrip && this.isStripVertical) || (this.isLastInStrip && !this.isStripVertical))
		{
		  paramGraphics2D.drawLine(i - 1, paramInt2 + 1, i - 1, paramInt2 + 1);
		}
		if (!this.isInStrip || this.isLastInStrip)
		{
		  paramGraphics2D.drawLine(i - 1, j - 1, i - 1, j - 1);
		}
		if (!this.isInStrip || (this.isFirstInStrip && !this.isStripVertical) || (this.isLastInStrip && this.isStripVertical))
		{
		  paramGraphics2D.drawLine(paramInt1 + 1, j - 1, paramInt1 + 1, j - 1);
		}
		resetAlpha(paramGraphics2D);
	  }

	  protected internal virtual void paintSelectedBackground(Graphics2D paramGraphics2D, int paramInt1, int paramInt2, int paramInt3, int paramInt4)
	  {
		CommandButtonDisplayState commandButtonDisplayState = this.commandButton.DisplayState;
		if (commandButtonDisplayState == CommandButtonDisplayState.BIG)
		{
		  if (!Split)
		  {
			paintBigSelectedBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4);
		  }
		  else
		  {
			Rectangle rectangle1 = new Rectangle((this.commandButton.UI.LayoutInfo).actionClickArea);
			Rectangle rectangle2 = new Rectangle((this.commandButton.UI.LayoutInfo).popupClickArea);
			paramGraphics2D.Clip = rectangle1;
			paintBigSelectedBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4);
			paramGraphics2D.Clip = rectangle2;
			if (this.isRollover && !this.isPopupRollover)
			{
			  paintBigRolloverBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4, true, this.isPopupEnabled);
			}
			else if (this.isPopupRollover)
			{
			  paintBigRolloverBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4, false, this.isPopupEnabled);
			}
			else
			{
			  paintBigSelectedBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4);
			}
		  }
		}
		else
		{
		  if (this.isInStrip)
		  {
			paintNormalBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4);
		  }
		  if (!Split)
		  {
			paintSmallSelectedBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4);
		  }
		  else
		  {
			Rectangle rectangle1 = new Rectangle((this.commandButton.UI.LayoutInfo).actionClickArea);
			Rectangle rectangle2 = new Rectangle((this.commandButton.UI.LayoutInfo).popupClickArea);
			paramGraphics2D.Clip = rectangle1;
			paintSmallSelectedBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4);
			paramGraphics2D.Clip = rectangle2;
			if (this.isRollover && !this.isPopupRollover)
			{
			  paintSmallRolloverBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4, true, this.isPopupEnabled);
			}
			else if (this.isPopupRollover)
			{
			  paintSmallRolloverBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4, false, this.isPopupEnabled);
			}
			else
			{
			  paintSmallSelectedBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4);
			}
		  }
		}
	  }

	  private void paintSmallSelectedBackground(Graphics2D paramGraphics2D, int paramInt1, int paramInt2, int paramInt3, int paramInt4)
	  {
		int i1;
		int n;
		int m;
		int k;
		float[] arrayOfFloat;
		int i = paramInt1 + paramInt3 - 1;
		int j = paramInt2 + paramInt4 - 1;
		if (!this.isInStrip)
		{
		  k = paramInt1 + 2;
		  m = i - 2;
		  n = paramInt2 + 4;
		  i1 = j - 2;
		  arrayOfFloat = new float[] {0.0F, 0.499F, 0.5F, 1.0F};
		}
		else
		{
		  k = this.isFirstInStrip ? (paramInt1 + 1) : paramInt1;
		  m = i - 1;
		  n = paramInt2 + 1;
		  i1 = j - 1;
		  new[4][0] float = 0.0F;
		  new[4][1] float = 0.35F;
		  new[4][2] float = 0.351F;
		  new[4][3] float = 1.0F;
		  new[4][0] float = 0.0F;
		  new[4][1] float = 0.3F;
		  new[4][2] float = 0.31F;
		  new[4][3] float = 1.0F;
		  arrayOfFloat = this.isRollover ? new float[4] : new float[4];
		}
		int i2 = m - k + 1;
		int i3 = i1 - n + 1;
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][0] = new Color(16165481);
		RectangularArrays.RectangularColorArray(4, 0) = new Color(16165481);
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][1] = new Color(15964500);
		RectangularArrays.RectangularColorArray(4, 1) = new Color(15964500);
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][2] = new Color(15761962);
		RectangularArrays.RectangularColorArray(4, 2) = new Color(15761962);
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][3] = new Color(16029212);
		RectangularArrays.RectangularColorArray(4, 3) = new Color(16029212);
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][0] = new Color(16636593);
		RectangularArrays.RectangularColorArray(4, 0) = new Color(16636593);
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][1] = new Color(16499584);
		RectangularArrays.RectangularColorArray(4, 1) = new Color(16499584);
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][2] = new Color(16362312);
		RectangularArrays.RectangularColorArray(4, 2) = new Color(16362312);
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][3] = new Color(16638612);
		RectangularArrays.RectangularColorArray(4, 3) = new Color(16638612);
		Color[] arrayOfColor1 = this.isRollover ? new Color[4] : new Color[4];
		paramGraphics2D.Paint = new LinearGradientPaint(k, n, k, i1, arrayOfFloat, arrayOfColor1);
		paramGraphics2D.fillRect(k, n, i2, i3);
		if (!this.isInStrip)
		{
		  paramGraphics2D.drawImage(HighlightImage, paramInt1, paramInt2 + 2, null);
		}
		if (!this.isInStrip)
		{
		  paramGraphics2D.Color = new Color(10388053);
		  paramGraphics2D.drawLine(paramInt1, paramInt2 + 1, paramInt1, j - 1);
		  if (!this.isRollover)
		  {
			paramGraphics2D.Color = new Color(10980966);
		  }
		  paramGraphics2D.drawLine(paramInt1 + 1, paramInt2, i - 1, paramInt2);
		  paramGraphics2D.drawLine(i, paramInt2 + 1, i, j - 1);
		}
		if (!this.isInStrip)
		{
		  if (!this.isRollover)
		  {
			paramGraphics2D.Paint = new LinearGradientPaint((paramInt1 + 1), j, (i - 1), j, new float[] {0.0F, 0.5F, 1.0F}, new Color[] {new Color(158, 130, 85, 127), new Color(197, 137, 37, 94), new Color(158, 130, 85, 127)});
		  }
		  else
		  {
			paramGraphics2D.Color = new Color(13944237);
		  }
		  paramGraphics2D.drawLine(paramInt1 + 1, j, i - 1, j);
		}
		{new Color[0], new Color[0], new Color[0]} = new Color(12422214);
		{new Color[1], new Color[1], new Color[1]} = new Color(14591063);
		{new Color[2], new Color[2], new Color[2]} = new Color(15837797);
		{new Color[0], new Color[0], new Color[0]} = new Color(13350041);
		{new Color[1], new Color[1], new Color[1]} = new Color(15389106);
		{new Color[2], new Color[2], new Color[2]} = new Color(16309175);
		Color[] arrayOfColor2 = this.isRollover ? new Color[3] : new Color[3];
		{new Color[0], new Color[0], new Color[0]} = new Color(10388053);
		{new Color[1], new Color[1], new Color[1]} = new Color(13671509);
		{new Color[2], new Color[2], new Color[2]} = new Color(15183455);
		{new Color[0], new Color[0], new Color[0]} = new Color(11704952);
		{new Color[1], new Color[1], new Color[1]} = new Color(14863538);
		{new Color[2], new Color[2], new Color[2]} = new Color(15717296);
		Color[] arrayOfColor3 = this.isRollover ? new Color[3] : new Color[3];
		int i4;
		for (i4 = 0; i4 < arrayOfColor2.Length; i4++)
		{
		  if (!this.isInStrip)
		  {
			int i5 = paramInt2 + 1 + i4;
			paramGraphics2D.Color = arrayOfColor3[i4];
			paramGraphics2D.drawLine(paramInt1 + 1, i5, i - 1, i5);
			paramGraphics2D.Color = arrayOfColor2[i4];
			paramGraphics2D.drawLine(paramInt1 + 2, i5, i - 2, i5);
		  }
		  else
		  {
			if (i4 == 2)
			{
			  break;
			}
			int i5 = paramInt2 + i4;
			int i6 = this.isFirstInStrip ? (paramInt1 + 1) : paramInt1;
			paramGraphics2D.Color = arrayOfColor2[i4];
			paramGraphics2D.drawLine(i6, i5, i - 1, i5);
		  }
		}
		if (!this.isInStrip)
		{
		  {new Color[0], new Color[0], new Color[0]} = new Color(16756026);
		  {new Color[1], new Color[1], new Color[1]} = new Color(16762228);
		  {new Color[2], new Color[2], new Color[2]} = new Color(16757576);
		  {new Color[0], new Color[0], new Color[0]} = new Color(16498499);
		  {new Color[1], new Color[1], new Color[1]} = new Color(16573100);
		  {new Color[2], new Color[2], new Color[2]} = new Color(16500057);
		  Color[] arrayOfColor = this.isRollover ? new Color[3] : new Color[3];
		  paramGraphics2D.Paint = new LinearGradientPaint((paramInt1 + 1), (j - 1), (i - 1), (j - 1), new float[] {0.0F, 0.5F, 1.0F}, arrayOfColor);
		  paramGraphics2D.drawLine(paramInt1 + 1, j - 1, i - 1, j - 1);
		}
		if (!this.isInStrip)
		{
		  if (!this.isRollover)
		  {
			paramGraphics2D.Paint = new LinearGradientPaint((paramInt1 + 1), (paramInt2 + 4), (paramInt1 + 1), (j - 1), new float[] {0.0F, 0.499F, 0.5F, 0.75F, 1.0F}, new Color[] {new Color(16044198), new Color(15839834), new Color(15839834), new Color(16170335), new Color(16564292)});
		  }
		  else
		  {
			paramGraphics2D.Paint = new LinearGradientPaint((paramInt1 + 1), (paramInt2 + 4), (paramInt1 + 1), (j - 1), new float[] {0.0F, 0.499F, 0.5F, 1.0F}, new Color[] {new Color(15972710), new Color(16437639), new Color(16436091), new Color(16690744)});
		  }
		  paramGraphics2D.drawLine(paramInt1 + 1, paramInt2 + 4, paramInt1 + 1, j - 1);
		  paramGraphics2D.drawLine(i - 1, paramInt2 + 4, i - 1, j - 1);
		}
		if (!this.isInStrip)
		{
		  if (!this.isRollover)
		  {
			paramGraphics2D.Color = new Color(15118674);
			paramGraphics2D.drawLine(paramInt1 + 1, j - 2, paramInt1 + 1, j - 2);
			paramGraphics2D.drawLine(i - 1, j - 2, i - 1, j - 2);
		  }
		  paramGraphics2D.Color = new Color(13149032);
		  paramGraphics2D.drawLine(paramInt1 + 1, j - 1, paramInt1 + 1, j - 1);
		  paramGraphics2D.drawLine(i - 1, j - 1, i - 1, j - 1);
		}
		if (!this.isRollover && !this.isInStrip)
		{
		  i4 = (int)(paramInt3 * 0.08D) - 2;
		  paramGraphics2D.Color = new Color(251, 197, 89, 153);
		  paramGraphics2D.drawLine(paramInt1 + 2, j - 2, paramInt1 + 2 + i4, j - 2);
		  paramGraphics2D.drawLine(i - 2, j - 2, i - 2 - i4, j - 2);
		}
	  }

	  private void paintBigSelectedBackground(Graphics2D paramGraphics2D, int paramInt1, int paramInt2, int paramInt3, int paramInt4)
	  {
		int i = paramInt1 + paramInt3 - 1;
		int j = paramInt2 + paramInt4 - 1;
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][0] = new Color(16366209);
		RectangularArrays.RectangularColorArray(4, 0) = new Color(16366209);
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][1] = new Color(14912334);
		RectangularArrays.RectangularColorArray(4, 1) = new Color(14912334);
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][2] = new Color(14578988);
		RectangularArrays.RectangularColorArray(4, 2) = new Color(14578988);
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][3] = new Color(16039003);
		RectangularArrays.RectangularColorArray(4, 3) = new Color(16039003);
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][0] = new Color(16768441);
		RectangularArrays.RectangularColorArray(4, 0) = new Color(16768441);
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][1] = new Color(16427099);
		RectangularArrays.RectangularColorArray(4, 1) = new Color(16427099);
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][2] = new Color(16289065);
		RectangularArrays.RectangularColorArray(4, 2) = new Color(16289065);
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][3] = new Color(16639129);
		RectangularArrays.RectangularColorArray(4, 3) = new Color(16639129);
		Color[] arrayOfColor1 = this.isRollover ? new Color[4] : new Color[4];
		paramGraphics2D.Paint = new LinearGradientPaint((paramInt1 + 1), (paramInt2 + 1), (paramInt1 + 1), (j - 1), new float[] {0.0F, 0.39F, 0.391F, 1.0F}, arrayOfColor1);
		paramGraphics2D.fillRect(paramInt1 + 1, paramInt2 + 1, paramInt3 - 2, paramInt4 - 2);
		paramGraphics2D.drawImage(HighlightImage, paramInt1, paramInt2 + 2, null);
		{new Color[0], new Color[0]} = new Color(9339237);
		{new Color[1], new Color[1]} = new Color(11641737);
		{new Color[0], new Color[0]} = new Color(9339237);
		{new Color[1], new Color[1]} = new Color(13025458);
		Color[] arrayOfColor2 = this.isRollover ? new Color[2] : new Color[2];
		paramGraphics2D.Paint = new LinearGradientPaint(paramInt1, paramInt2, paramInt1, (j - 2), new float[] {0.67F, 1.0F}, arrayOfColor2);
		paramGraphics2D.drawLine(paramInt1, paramInt2 + 1, paramInt1, j - 2);
		paramGraphics2D.drawLine(i, paramInt2 + 1, i, j - 2);
		paramGraphics2D.drawLine(paramInt1 + 1, paramInt2, i - 1, paramInt2);
		if (this.isRollover)
		{
		  paramGraphics2D.Color = new Color(13944237);
		  paramGraphics2D.drawLine(paramInt1 + 1, j, i - 1, j);
		}
		{new Color[0], new Color[0], new Color[0]} = new Color(11044958);
		{new Color[1], new Color[1], new Color[1]} = new Color(13736805);
		{new Color[2], new Color[2], new Color[2]} = new Color(15313515);
		{new Color[0], new Color[0], new Color[0]} = new Color(11967096);
		{new Color[1], new Color[1], new Color[1]} = new Color(14530697);
		{new Color[2], new Color[2], new Color[2]} = new Color(16107930);
		Color[] arrayOfColor3 = this.isRollover ? new Color[3] : new Color[3];
		for (int k = 0; k < arrayOfColor3.Length; k++)
		{
		  int n = paramInt2 + 1 + k;
		  paramGraphics2D.Color = arrayOfColor3[k];
		  paramGraphics2D.drawLine(paramInt1 + 1, n, i - 1, n);
		}
		new[3][0] float = 0.0F;
		new[3][1] float = 0.5F;
		new[3][2] float = 1.0F;
		new[2][0] float = 0.0F;
		new[2][1] float = 1.0F;
		float[] arrayOfFloat = this.isRollover ? new float[3] : new float[2];
		{new Color[0], new Color[0], new Color[0]} = new Color(239, 161, 49, 204);
		{new Color[1], new Color[1], new Color[1]} = new Color(16707795);
		{new Color[2], new Color[2], new Color[2]} = new Color(16768881);
		{new Color[0], new Color[0]} = new Color(242, 173, 65, 204);
		{new Color[1], new Color[1]} = new Color(16764717);
		Color[] arrayOfColor4 = this.isRollover ? new Color[3] : new Color[2];
		paramGraphics2D.Paint = new LinearGradientPaint((paramInt1 + 1), (paramInt2 + 1), (paramInt1 + 1), (j - 1), arrayOfFloat, arrayOfColor4);
		paramGraphics2D.drawLine(paramInt1 + 1, paramInt2 + 1, paramInt1 + 1, j - 1);
		paramGraphics2D.drawLine(i - 1, paramInt2 + 1, i - 1, j - 1);
		int m = this.isRollover ? (j - 1) : j;
		paramGraphics2D.Paint = new LinearGradientPaint((paramInt1 + 1), j, (i - 1), j, new float[] {0.0F, 0.5F, 1.0F}, new Color[] {new Color(16764716), new Color(16771488), new Color(16764717)});
		paramGraphics2D.drawLine(paramInt1 + 1, m, i - 1, m);
		paramGraphics2D.Color = this.isRollover ? new Color(9931117) : new Color(11904913);
		paramGraphics2D.drawLine(paramInt1 + 1, paramInt2 + 1, paramInt1 + 1, paramInt2 + 1);
		paramGraphics2D.drawLine(i - 1, paramInt2 + 1, i - 1, paramInt2 + 1);
		paramGraphics2D.Color = this.isRollover ? new Color(13418149) : new Color(255, 220, 101, 92);
		paramGraphics2D.drawLine(paramInt1, j - 1, paramInt1, j - 1);
		paramGraphics2D.drawLine(i, j - 1, i, j - 1);
		if (this.isRollover)
		{
		  paramGraphics2D.Color = new Color(14795377);
		  paramGraphics2D.drawLine(paramInt1 + 1, j - 1, paramInt1 + 1, j - 1);
		  paramGraphics2D.drawLine(i - 1, j - 1, i - 1, j - 1);
		}
		else
		{
		  paramGraphics2D.Color = new Color(16635741);
		  paramGraphics2D.drawLine(paramInt1 + 2, j - 1, paramInt1 + 2, j - 1);
		  paramGraphics2D.drawLine(i - 2, j - 1, i - 2, j - 1);
		}
	  }

	  protected internal virtual void paintPressedBackground(Graphics2D paramGraphics2D, int paramInt1, int paramInt2, int paramInt3, int paramInt4)
	  {
		Rectangle rectangle1 = new Rectangle((this.commandButton.UI.LayoutInfo).actionClickArea);
		Rectangle rectangle2 = new Rectangle((this.commandButton.UI.LayoutInfo).popupClickArea);
		if (this.commandButton.DisplayState == CommandButtonDisplayState.BIG)
		{
		  if (!Split)
		  {
			paintBigPressedBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4);
		  }
		  else
		  {
			rectangle1.height += 2;
			rectangle2.y += 2;
			rectangle2.height -= 2;
			paramGraphics2D.Clip = rectangle1;
			if (this.isPopupRollover)
			{
			  paintBigRolloverBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4, true, this.isActionEnabled);
			}
			else
			{
			  paintBigPressedBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4);
			  paramGraphics2D.Color = new Color(-1711276033, true);
			  paramGraphics2D.drawLine(paramInt1 + 1, rectangle1.height - 1, paramInt1 + paramInt3 - 2, rectangle1.height - 1);
			}
			paramGraphics2D.Clip = rectangle2;
			if (this.isPopupRollover)
			{
			  paintBigPressedBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4);
			}
			else
			{
			  paintBigRolloverBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4, true, this.isPopupEnabled);
			}
		  }
		}
		else
		{
		  if (this.isInStrip)
		  {
			paintNormalBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4);
		  }
		  if (!Split)
		  {
			paintSmallPressedBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4);
		  }
		  else
		  {
			paramGraphics2D.Clip = rectangle1;
			if (this.isPopupRollover)
			{
			  paintSmallRolloverBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4, true, this.isActionEnabled);
			}
			else
			{
			  paintSmallPressedBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4);
			}
			paramGraphics2D.Clip = rectangle2;
			if (this.isPopupRollover)
			{
			  paintSmallPressedBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4);
			}
			else
			{
			  paintSmallRolloverBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4, true, this.isPopupEnabled);
			}
		  }
		}
	  }

	  private void paintSmallPressedBackground(Graphics2D paramGraphics2D, int paramInt1, int paramInt2, int paramInt3, int paramInt4)
	  {
		int i = paramInt1 + paramInt3 - 1;
		int j = paramInt2 + paramInt4 - 1;
		int k = (this.isInStrip && !this.isFirstInStrip) ? paramInt1 : (paramInt1 + 1);
		int m = i - 1;
		int n = m - k + 1;
		if (!this.isInStrip)
		{
		  paramGraphics2D.Paint = new LinearGradientPaint(k, (paramInt2 + 1), k, (j - 1), new float[] {0.0F, 0.6F, 0.61F, 1.0F}, new Color[] {new Color(16033648), new Color(15236672), new Color(14570762), new Color(16092479)});
		}
		else
		{
		  paramGraphics2D.Paint = new LinearGradientPaint(k, (paramInt2 + 1), k, (j - 1), new float[] {0.2F, 0.4F, 0.41F, 1.0F}, new Color[] {new Color(16560493), new Color(16751139), new Color(16747781), new Color(16761936)});
		}
		paramGraphics2D.fillRect(k, paramInt2 + 1, n, paramInt4 - 2);
		if (!this.isInStrip)
		{
		  paramGraphics2D.drawImage(HighlightImage, paramInt1, paramInt2 + 2, null);
		}
		paramGraphics2D.Paint = new Color(8087109);
		if (!this.isInStrip)
		{
		  paramGraphics2D.drawLine(paramInt1 + 1, paramInt2, i - 1, paramInt2);
		  paramGraphics2D.drawLine(paramInt1, paramInt2 + 1, paramInt1, j - 1);
		  paramGraphics2D.drawLine(i, paramInt2 + 1, i, j - 1);
		}
		else
		{
		  int i2 = this.isFirstInStrip ? (paramInt1 + 2) : paramInt1;
		  int i3 = this.isLastInStrip ? (i - 2) : (i - 1);
		  paramGraphics2D.drawLine(i2, paramInt2, i3, paramInt2);
		  paramGraphics2D.drawLine(i2, j, i3, j);
		}
		int[] arrayOfInt = new int[] {153, 84, 22, 13};
		int i1;
		for (i1 = 0; i1 < arrayOfInt.Length; i1++)
		{
		  int i2 = paramInt2 + 1 + i1;
		  int i3 = this.isFirstInStrip ? (paramInt1 + 1) : paramInt1;
		  paramGraphics2D.Color = new Color(139, 118, 84, arrayOfInt[i1]);
		  paramGraphics2D.drawLine(i3, i2, i - 1, i2);
		}
		if (!this.isInStrip)
		{
		  i1 = (int)(paramInt3 * 0.08D);
		  paramGraphics2D.Color = new Color(253, 173, 3, 92);
		  paramGraphics2D.drawLine(paramInt1, j - 1, paramInt1 + i1, j - 1);
		  paramGraphics2D.drawLine(i, j - 1, i - i1, j - 1);
		  paramGraphics2D.Paint = new LinearGradientPaint((paramInt1 + 1), (paramInt2 + 1), (paramInt1 + 1), j, new float[] {0.0F, 1.0F}, new Color[] {new Color(253, 173, 3, 25), new Color(253, 173, 3)});
		  paramGraphics2D.drawLine(paramInt1 + 1, paramInt2 + 1, paramInt1 + 1, j);
		  paramGraphics2D.drawLine(i - 1, paramInt2 + 1, i - 1, j);
		  paramGraphics2D.drawLine(paramInt1 + 1, j, i - 1, j);
		}
		else
		{
		  paramGraphics2D.Color = new Color(253, 173, 3);
		  i1 = this.isFirstInStrip ? (paramInt1 + 1) : paramInt1;
		  paramGraphics2D.drawLine(i1, j - 1, i - 1, j - 1);
		}
		if (!this.isInStrip)
		{
		  paramGraphics2D.Color = new Color(9137997);
		  paramGraphics2D.drawLine(paramInt1 + 1, paramInt2 + 1, paramInt1 + 1, paramInt2 + 1);
		  paramGraphics2D.drawLine(i - 1, paramInt2 + 1, i - 1, paramInt2 + 1);
		}
	  }

	  private void paintBigPressedBackground(Graphics2D paramGraphics2D, int paramInt1, int paramInt2, int paramInt3, int paramInt4)
	  {
		int i = paramInt1 + paramInt3 - 1;
		int j = paramInt2 + paramInt4 - 1;
		paramGraphics2D.Paint = new LinearGradientPaint((paramInt1 + 1), (paramInt2 + 1), (paramInt1 + 1), (j - 1), new float[] {0.0F, 0.409F, 0.41F, 1.0F}, new Color[] {new Color(16693100), new Color(16556128), new Color(16484924), new Color(16694112)});
		paramGraphics2D.fillRect(paramInt1 + 1, paramInt2 + 1, paramInt3 - 2, paramInt4 - 2);
		paramGraphics2D.drawImage(HighlightImage, paramInt1, paramInt2 + 2, null);
		paramGraphics2D.Paint = new LinearGradientPaint(paramInt1, paramInt2, paramInt1, (j - 2), new float[] {0.5F, 1.0F}, new Color[] {new Color(9139796), new Color(12892584)});
		paramGraphics2D.drawLine(paramInt1 + 1, paramInt2, i - 1, paramInt2);
		paramGraphics2D.drawLine(paramInt1, paramInt2 + 1, paramInt1, j - 2);
		paramGraphics2D.drawLine(i, paramInt2 + 1, i, j - 2);
		int[] arrayOfInt = new int[] {153, 84, 43, 22, 13};
		for (int k = 0; k < arrayOfInt.Length; k++)
		{
		  int m = paramInt2 + 1 + k;
		  paramGraphics2D.Color = new Color(139, 118, 84, arrayOfInt[k]);
		  paramGraphics2D.drawLine(paramInt1 + 1, m, i - 1, m);
		}
		paramGraphics2D.Paint = new LinearGradientPaint(paramInt1, paramInt2, paramInt1, (j - 2), new float[] {0.5F, 1.0F}, new Color[] {new Color(139, 118, 84, 20), new Color(196, 185, 168, 20)});
		paramGraphics2D.drawLine(paramInt1 + 2, paramInt2 + 1, paramInt1 + 2, j - 1);
		paramGraphics2D.drawLine(i - 2, paramInt2 + 1, i - 2, j - 1);
		paramGraphics2D.Paint = new LinearGradientPaint((paramInt1 + 1), (paramInt2 + 1), (paramInt1 + 1), j, new float[] {0.0F, 1.0F}, new Color[] {new Color(253, 173, 17, 25), new Color(253, 173, 17)});
		paramGraphics2D.drawLine(paramInt1 + 1, paramInt2 + 1, paramInt1 + 1, j);
		paramGraphics2D.drawLine(i - 1, paramInt2 + 1, i - 1, j);
		paramGraphics2D.drawLine(paramInt1 + 1, j, i - 1, j);
		paramGraphics2D.drawLine(paramInt1 + 2, j - 1, paramInt1 + 2, j - 1);
		paramGraphics2D.drawLine(i - 2, j - 1, i - 2, j - 1);
		paramGraphics2D.Color = new Color(253, 173, 17, 127);
		paramGraphics2D.drawLine(paramInt1, j - 1, paramInt1, j - 1);
		paramGraphics2D.drawLine(i, j - 1, i, j - 1);
		paramGraphics2D.Color = new Color(11310708);
		paramGraphics2D.drawLine(paramInt1 + 1, paramInt2 + 1, paramInt1 + 1, paramInt2 + 1);
		paramGraphics2D.drawLine(i - 1, paramInt2 + 1, i - 1, paramInt2 + 1);
	  }

	  protected internal virtual void paintRolloverBackground(Graphics2D paramGraphics2D, int paramInt1, int paramInt2, int paramInt3, int paramInt4)
	  {
		Rectangle rectangle1 = new Rectangle((this.commandButton.UI.LayoutInfo).actionClickArea);
		Rectangle rectangle2 = new Rectangle((this.commandButton.UI.LayoutInfo).popupClickArea);
		if (CommandButtonDisplayState.BIG == this.commandButton.DisplayState)
		{
		  if (!Split)
		  {
			paintBigRolloverBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4, false, (this.isActionEnabled || (this.isPopupOnly && this.isPopupEnabled)));
		  }
		  else
		  {
			if (this.isPopupRollover)
			{
			  rectangle1.height += 2;
			  rectangle2.y += 2;
			  rectangle2.height -= 2;
			}
			paramGraphics2D.Clip = rectangle1;
			paintBigRolloverBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4, this.isPopupRollover, this.isActionEnabled);
			paramGraphics2D.Clip = rectangle2;
			paintBigRolloverBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4, !this.isPopupRollover, this.isPopupEnabled);
		  }
		}
		else
		{
		  if (this.isInStrip)
		  {
			paintNormalBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4);
		  }
		  if (!Split)
		  {
			paintSmallRolloverBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4, false, (this.isActionEnabled || (this.isPopupOnly && this.isPopupEnabled)));
		  }
		  else
		  {
			paramGraphics2D.Clip = rectangle1;
			paintSmallRolloverBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4, this.isPopupRollover, this.isActionEnabled);
			paramGraphics2D.Clip = rectangle2;
			paintSmallRolloverBackground(paramGraphics2D, paramInt1, paramInt2, paramInt3, paramInt4, !this.isPopupRollover, this.isPopupEnabled);
		  }
		}
	  }

	  protected internal virtual void paintBigRolloverBackground(Graphics2D paramGraphics2D, int paramInt1, int paramInt2, int paramInt3, int paramInt4, bool paramBoolean1, bool paramBoolean2)
	  {
		Graphics2D graphics2D = paramGraphics2D;
		object @object = null;
		int i = paramInt1 + paramInt3 - 1;
		int j = paramInt2 + paramInt4 - 1;
		graphics2D.Color = selectionColor;
		graphics2D.fillRect(paramInt1 + 1, paramInt2 + 1, paramInt3 - 2, paramInt4 - 2);
	  }

	  protected internal virtual void paintSmallRolloverBackground(Graphics2D paramGraphics2D, int paramInt1, int paramInt2, int paramInt3, int paramInt4, bool paramBoolean1, bool paramBoolean2)
	  {
		Graphics2D graphics2D = paramGraphics2D;
		BufferedImage bufferedImage = null;
		if (!paramBoolean2)
		{
		  bufferedImage = paramGraphics2D.DeviceConfiguration.createCompatibleImage(paramInt3, paramInt4, 3);
		  graphics2D = bufferedImage.createGraphics();
		  graphics2D.Clip = paramGraphics2D.Clip;
		}
		int i = paramInt1 + paramInt3 - 1;
		int j = paramInt2 + paramInt4 - 1;
		int k = (this.isInStrip && !this.isFirstInStrip) ? paramInt1 : (paramInt1 + 1);
		int m = i - 1;
		int n = paramInt2 + 1;
		int i1 = j - 1;
		int i2 = m - k + 1;
		int i3 = i1 - n + 1;
		graphics2D.Paint = new LinearGradientPaint(k, n, k, i1, RolloverColors.BG_FRACTIONS_SMALL, RolloverColors.BG);
		graphics2D.fillRect(k, n, i2, i3);
		Shape shape = graphics2D.Clip;
		graphics2D.setClip(k, n, i2, i3);
		graphics2D.drawImage(HighlightImage, paramInt1, paramInt2 + 2, null);
		graphics2D.Clip = shape;
		if (paramBoolean1 && paramBoolean2)
		{
		  graphics2D.Paint = new Color(-1711276033, true);
		  graphics2D.fillRect(k, n, i2, i3);
		}
		if (!this.isInStrip)
		{
		  graphics2D.Paint = new LinearGradientPaint(paramInt1, paramInt2, paramInt1, j, RolloverColors.BORDER_FRACTIONS, RolloverColors.BORDER_SMALL);
		  graphics2D.drawLine(paramInt1 + 1, paramInt2, i - 1, paramInt2);
		  graphics2D.drawLine(i, paramInt2 + 1, i, j - 1);
		  graphics2D.drawLine(paramInt1 + 1, j, i - 1, j);
		  graphics2D.drawLine(paramInt1, paramInt2 + 1, paramInt1, j - 1);
		}
		graphics2D.Paint = new LinearGradientPaint((paramInt1 + 1), (paramInt2 + 1), (paramInt1 + 1), (j - 1), RolloverColors.HIGHLIGHT1_FRACTIONS, RolloverColors.HIGHLIGHT1);
		graphics2D.drawLine(k, n, m, n);
		graphics2D.drawLine(k, n + 1, k, i1 - 1);
		graphics2D.drawLine(m, n + 1, m, i1 - 1);
		graphics2D.Paint = new LinearGradientPaint((paramInt1 + 2), (j - 1), (i - 2), (j - 1), RolloverColors.HIGHLIGHT2_FRACTIONS, RolloverColors.HIGHLIGHT2);
		graphics2D.drawLine(k, i1, m, i1);
		if (this.isInStrip)
		{
		  setAlpha(graphics2D, 0.5F);
		  graphics2D.Color = NORMAL_BORDER_COLOR;
		  if (this.isFirstInStrip)
		  {
			graphics2D.drawLine(k, n, k, n);
			graphics2D.drawLine(k, i1, k, i1);
		  }
		  if (this.isLastInStrip)
		  {
			graphics2D.drawLine(m, n, m, n);
			graphics2D.drawLine(m, i1, m, i1);
		  }
		  resetAlpha(graphics2D);
		}
		else
		{
		  graphics2D.Color = RolloverColors.CORNER1;
		  graphics2D.drawLine(paramInt1 + 1, paramInt2 + 1, paramInt1 + 1, paramInt2 + 1);
		  graphics2D.drawLine(i - 1, paramInt2 + 1, i - 1, paramInt2 + 1);
		  graphics2D.Color = RolloverColors.CORNER2;
		  graphics2D.drawLine(paramInt1 + 1, j - 1, paramInt1 + 1, j - 1);
		  graphics2D.drawLine(i - 1, j - 1, i - 1, j - 1);
		}
		if (!paramBoolean2)
		{
		  graphics2D.dispose();
		  ColorSpace colorSpace = ColorSpace.getInstance(1003);
		  ColorConvertOp colorConvertOp = new ColorConvertOp(colorSpace, null);
		  paramGraphics2D.drawImage(bufferedImage, colorConvertOp, paramInt1, paramInt2);
		}
	  }

	  protected internal virtual bool Split
	  {
		  get
		  {
			JCommandButton.CommandButtonKind commandButtonKind = (this.commandButton is JCommandButton) ? ((JCommandButton)this.commandButton).CommandButtonKind : JCommandButton.CommandButtonKind.ACTION_ONLY;
			return (commandButtonKind.hasAction() && commandButtonKind.hasPopup());
		  }
	  }

	  protected internal virtual BufferedImage HighlightImage
	  {
		  get
		  {
			if (this.highlightImage == null || this.highlightImage.Width != this.commandButton.Width)
			{
			  this.highlightImage = HighlightFactory.createHighlight(this.commandButton.Width, (int)(this.commandButton.Height * 1.5D));
			}
			return this.highlightImage;
		  }
	  }

	  public virtual void paintCollapsedBandButtonBackground(Graphics paramGraphics, Rectangle paramRectangle)
	  {
		Graphics2D graphics2D = (Graphics2D)paramGraphics.create();
		int i = paramRectangle.x;
		int j = paramRectangle.y;
		int k = paramRectangle.width;
		int m = paramRectangle.height;
		updateState();
		if (this.isPressed || this.isSelected)
		{
		  graphics2D.Color = CostOSWindowsLookAndFeel.collapsedButtonColorPressed;
		  graphics2D.fillRect(i + 1, j + 1, k - 2, m - 2);
		}
		else
		{
		  graphics2D.Color = CostOSWindowsLookAndFeel.collapsedButtonColor;
		  graphics2D.fillRect(i + 1, j + 1, k - 2, m - 2);
		}
		graphics2D.dispose();
	  }

	  protected internal virtual void paintPressedCollapsedBandButtonBackground(Graphics2D paramGraphics2D, int paramInt1, int paramInt2, int paramInt3, int paramInt4)
	  {
		object @object = paramGraphics2D.getRenderingHint(RenderingHints.KEY_ANTIALIASING);
		paramGraphics2D.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
		int i = paramInt1 + paramInt3 - 1;
		int j = paramInt2 + paramInt4 - 1;
		Color[] arrayOfColor = new Color[]
		{
			new Color(15987699),
			new Color(13159892),
			new Color(12173513),
			new Color(15527148)
		};
		paramGraphics2D.Paint = new LinearGradientPaint((paramInt1 + 1), (paramInt2 + 1), (paramInt1 + 1), (j - 1), new float[] {0.0F, 0.17F, 0.171F, 1.0F}, arrayOfColor);
		paramGraphics2D.fillRect(paramInt1 + 1, paramInt2 + 1, paramInt3 - 2, paramInt4 - 2);
		Composite composite = paramGraphics2D.Composite;
		paramGraphics2D.Composite = AlphaComposite.getInstance(3, 0.2F);
		paramGraphics2D.Color = new Color(11184810);
		paramGraphics2D.fillRect(paramInt1 + 1, paramInt2 + 1, paramInt3 - 2, paramInt4 - 2);
		paramGraphics2D.Composite = composite;
		paramGraphics2D.Color = CollapsedBandColors.border1_pressed_140;
		paramGraphics2D.drawLine(paramInt1 + 1, paramInt2 + 1, i - 1, paramInt2 + 1);
		paramGraphics2D.Color = CollapsedBandColors.border1_pressed_90;
		paramGraphics2D.drawLine(paramInt1 + 1, paramInt2 + 1, paramInt1 + 1, j - 1);
		paramGraphics2D.drawLine(paramInt1 + 1, paramInt2 + 2, i - 1, paramInt2 + 2);
		paramGraphics2D.Color = CollapsedBandColors.border1_pressed_45;
		paramGraphics2D.drawLine(paramInt1 + 2, paramInt2 + 1, paramInt1 + 2, j - 1);
		paramGraphics2D.drawLine(paramInt1 + 1, paramInt2 + 3, i - 1, paramInt2 + 3);
		paramGraphics2D.Color = CollapsedBandColors.highlight1_pressed;
		paramGraphics2D.drawLine(i - 1, paramInt2 + 1, i - 1, j - 1);
		paramGraphics2D.drawLine(paramInt1 + 1, j - 1, i - 1, j - 1);
		paramGraphics2D.Color = CollapsedBandColors.highlight2_pressed;
		paramGraphics2D.drawLine(i - 2, paramInt2 + 1, i - 2, j - 1);
		paramGraphics2D.drawLine(paramInt1 + 1, j - 2, i - 1, j - 2);
		Paint paint = paramGraphics2D.Paint;
		paramGraphics2D.Paint = new LinearGradientPaint(paramInt1, paramInt2, paramInt1, j, new float[] {0.0F, 0.95F, 1.0F}, new Color[] {CollapsedBandColors.border1_pressed, CollapsedBandColors.border2_pressed, CollapsedBandColors.border3_pressed});
		drawRoundedRect(paramGraphics2D, paramInt1, paramInt2, i, j);
		paramGraphics2D.Paint = paint;
		paramGraphics2D.setRenderingHint(RenderingHints.KEY_ANTIALIASING, @object);
	  }

	  protected internal virtual void paintNormalCollapsedBandButtonBackground(Graphics2D paramGraphics2D, int paramInt1, int paramInt2, int paramInt3, int paramInt4)
	  {
		object @object = paramGraphics2D.getRenderingHint(RenderingHints.KEY_ANTIALIASING);
		paramGraphics2D.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
		int i = paramInt1 + paramInt3 - 1;
		int j = paramInt2 + paramInt4 - 1;
		Color color1 = this.isRollover ? CollapsedBandColors.border1_over : CollapsedBandColors.border1;
		Color color2 = this.isRollover ? CollapsedBandColors.border1_over : CollapsedBandColors.border1;
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][0] = new Color(16777215);
		RectangularArrays.RectangularColorArray(4, 0) = new Color(16777215);
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][1] = new Color(13685977);
		RectangularArrays.RectangularColorArray(4, 1) = new Color(13685977);
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][2] = new Color(12634063);
		RectangularArrays.RectangularColorArray(4, 2) = new Color(12634063);
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][3] = new Color(15790320);
		RectangularArrays.RectangularColorArray(4, 3) = new Color(15790320);
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][0] = new Color(15987699);
		RectangularArrays.RectangularColorArray(4, 0) = new Color(15987699);
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][1] = new Color(13159892);
		RectangularArrays.RectangularColorArray(4, 1) = new Color(13159892);
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][2] = new Color(12173513);
		RectangularArrays.RectangularColorArray(4, 2) = new Color(12173513);
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: new Color[4][3] = new Color(15527148);
		RectangularArrays.RectangularColorArray(4, 3) = new Color(15527148);
		Color[] arrayOfColor = this.isRollover ? new Color[4] : new Color[4];
		paramGraphics2D.Paint = new LinearGradientPaint((paramInt1 + 1), (paramInt2 + 1), (paramInt1 + 1), (j - 1), new float[] {0.0F, 0.16F, 0.161F, 1.0F}, arrayOfColor);
		paramGraphics2D.fillRect(paramInt1 + 1, paramInt2 + 1, paramInt3 - 2, paramInt4 - 2);
		Paint paint = paramGraphics2D.Paint;
		paramGraphics2D.Paint = new LinearGradientPaint(paramInt1, paramInt2, paramInt1, j, new float[] {0.0F, 1.0F}, new Color[] {color1, color2});
		drawRoundedRect(paramGraphics2D, paramInt1, paramInt2, i, j);
		paramGraphics2D.Paint = paint;
		paramGraphics2D.Color = CollapsedBandColors.highlight1;
		paramGraphics2D.drawLine(paramInt1 + 2, paramInt2 + 1, i - 2, paramInt2 + 1);
		paramGraphics2D.drawLine(paramInt1 + 1, paramInt2 + 2, paramInt1 + 1, j - 2);
		if (!this.isRollover)
		{
		  paramGraphics2D.Color = CollapsedBandColors.highlight2;
		}
		paramGraphics2D.drawLine(i - 1, paramInt2 + 2, i - 1, j - 2);
		paramGraphics2D.drawLine(paramInt1 + 2, j - 1, i - 2, j - 1);
		paramGraphics2D.setRenderingHint(RenderingHints.KEY_ANTIALIASING, @object);
	  }

	  protected internal virtual void drawRoundedRect(Graphics2D paramGraphics2D, int paramInt1, int paramInt2, int paramInt3, int paramInt4)
	  {
		paramGraphics2D.drawLine(paramInt1 + 2, paramInt2, paramInt3 - 2, paramInt2);
		paramGraphics2D.drawLine(paramInt1, paramInt2 + 2, paramInt1, paramInt4 - 2);
		paramGraphics2D.drawLine(paramInt1 + 2, paramInt4, paramInt3 - 2, paramInt4);
		paramGraphics2D.drawLine(paramInt3, paramInt2 + 2, paramInt3, paramInt4 - 2);
		paramGraphics2D.drawLine(paramInt1, paramInt2 + 2, paramInt1 + 2, paramInt2);
		paramGraphics2D.drawLine(paramInt3 - 2, paramInt2, paramInt3, paramInt2 + 2);
		paramGraphics2D.drawLine(paramInt3, paramInt4 - 2, paramInt3 - 2, paramInt4);
		paramGraphics2D.drawLine(paramInt1, paramInt4 - 2, paramInt1 + 2, paramInt4);
	  }

	  protected internal virtual void enableAA(Graphics2D paramGraphics2D)
	  {
		this.oldAa = paramGraphics2D.getRenderingHint(RenderingHints.KEY_ANTIALIASING);
		paramGraphics2D.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
	  }

	  protected internal virtual void resetAA(Graphics2D paramGraphics2D)
	  {
		  paramGraphics2D.setRenderingHint(RenderingHints.KEY_ANTIALIASING, this.oldAa);
	  }

	  protected internal virtual void setAlpha(Graphics2D paramGraphics2D, float paramFloat)
	  {
		this.oldComposite = paramGraphics2D.Composite;
		paramGraphics2D.Composite = AlphaComposite.getInstance(3, paramFloat);
	  }

	  protected internal virtual void resetAlpha(Graphics2D paramGraphics2D)
	  {
		  paramGraphics2D.Composite = this.oldComposite;
	  }

	  internal class RolloverColors
	  {
		protected internal static readonly Color[] BG = new Color[] {CostOSCommandButtonPainter.backgroundColor, CostOSCommandButtonPainter.backgroundColor, CostOSCommandButtonPainter.backgroundColor, CostOSCommandButtonPainter.backgroundColor};

		protected internal static readonly Color[] BORDER_BIG = new Color[] {CostOSCommandButtonPainter.borderColor, CostOSCommandButtonPainter.borderColor, CostOSCommandButtonPainter.borderColor};

		protected internal static readonly Color[] BORDER_SMALL = new Color[] {CostOSCommandButtonPainter.borderColor, CostOSCommandButtonPainter.borderColor, CostOSCommandButtonPainter.borderColor};

		protected internal static readonly Color[] HIGHLIGHT1 = new Color[] {CostOSCommandButtonPainter.highlightColor, CostOSCommandButtonPainter.highlightColor};

		protected internal static readonly Color[] HIGHLIGHT2 = new Color[] {CostOSCommandButtonPainter.highlightColor, CostOSCommandButtonPainter.highlightColor, CostOSCommandButtonPainter.highlightColor};

		protected internal static readonly Color[] HIGHLIGHT3 = new Color[] {CostOSCommandButtonPainter.highlightColor, CostOSCommandButtonPainter.highlightColor};

		protected internal static readonly Color[] HIGHLIGHT4 = new Color[] {CostOSCommandButtonPainter.highlightColor, CostOSCommandButtonPainter.highlightColor, CostOSCommandButtonPainter.highlightColor, CostOSCommandButtonPainter.highlightColor};

		protected internal static readonly Color CORNER1 = CostOSCommandButtonPainter.cornerColor;

		protected internal static readonly Color CORNER2 = CostOSCommandButtonPainter.cornerColor;

		protected internal static readonly float[] BG_FRACTIONS_BIG = new float[] {0.0F, 0.375F, 0.376F, 1.0F};

		protected internal static readonly float[] BG_FRACTIONS_SMALL = new float[] {0.0F, 0.49F, 0.5F, 1.0F};

		protected internal static readonly float[] BORDER_FRACTIONS = new float[] {0.0F, 0.5F, 1.0F};

		protected internal static readonly float[] HIGHLIGHT1_FRACTIONS = new float[] {0.0F, 1.0F};

		protected internal static readonly float[] HIGHLIGHT2_FRACTIONS = new float[] {0.0F, 0.5F, 1.0F};

		protected internal static readonly float[] HIGHLIGHT3_FRACTIONS = new float[] {0.5F, 1.0F};

		protected internal static readonly float[] HIGHLIGHT4_FRACTIONS = new float[] {0.0F, 0.45F, 0.55F, 1.0F};
	  }

	  internal class CollapsedBandColors
	  {
		protected internal static readonly Color border1 = CostOSCommandButtonPainter.borderColor;

		protected internal static readonly Color border2 = CostOSCommandButtonPainter.borderColor;

		protected internal static readonly Color border1_over = CostOSCommandButtonPainter.borderColor;

		protected internal static readonly Color border2_over = CostOSCommandButtonPainter.borderColor;

		protected internal static readonly Color border1_pressed = CostOSCommandButtonPainter.borderPressedColor;

		protected internal static readonly Color border2_pressed = CostOSCommandButtonPainter.borderPressedColor;

		protected internal static readonly Color border3_pressed = CostOSCommandButtonPainter.borderPressedColor;

		protected internal static readonly Color border1_pressed_140 = new Color(border1_pressed.Red, border1_pressed.Green, border1_pressed.Blue, 140);

		protected internal static readonly Color border1_pressed_90 = new Color(border1_pressed.Red, border1_pressed.Green, border1_pressed.Blue, 90);

		protected internal static readonly Color border1_pressed_45 = new Color(border1_pressed.Red, border1_pressed.Green, border1_pressed.Blue, 45);

		protected internal static readonly Color highlight1 = CostOSCommandButtonPainter.highlightColor;

		protected internal static readonly Color highlight2 = CostOSCommandButtonPainter.highlightColor;

		protected internal static readonly Color highlight1_pressed = CostOSCommandButtonPainter.highlightPressedColor;

		protected internal static readonly Color highlight2_pressed = CostOSCommandButtonPainter.highlightPressedColor;

		protected internal static readonly Color background = CostOSCommandButtonPainter.backgroundColor;

		protected internal static readonly Color background_pressed = CostOSCommandButtonPainter.backgroundPressedColor;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\laf\CostOSCommandButtonPainter.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}