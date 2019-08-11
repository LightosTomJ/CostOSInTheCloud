using System;
using System.Threading;

namespace Desktop.common.nomitech.common.ui
{
	using RaisedHeaderBorder = Desktop.common.nomitech.common.ui.borders.RaisedHeaderBorder;

	public class UILabelPanel : JPanel
	{
	  protected internal JLabel titleLabel;

	  protected internal JLabel eastLabel;

	  protected internal GradientPanel gradientPanel;

	  protected internal bool selected = false;

	  protected internal bool hasEastTextComponent = false;

	  protected internal JPanel o_eastPanel = null;

	  protected internal JPanel o_topPanel = new JPanelAnonymousInnerClass(new BorderLayout());

	  private class JPanelAnonymousInnerClass : JPanel
	  {
		  public JPanelAnonymousInnerClass(BorderLayout BorderLayout) : base(BorderLayout)
		  {
		  }

		  public bool Visible
		  {
			  set
			  {
				base.Visible = value;
				if (value)
				{
				  Console.WriteLine("CALLED VISILBE............");
				  Thread.dumpStack();
				}
			  }
		  }
	  }

	  protected internal JPanel headerPanel;

	  private JComponent o_curEastComponent = null;

	  private static Color headerColor = new Color(250, 250, 250);

	  public UILabelPanel(string paramString) : this(null, paramString, null)
	  {
	  }

	  public virtual JPanel HeaderPanel
	  {
		  get
		  {
			  return this.headerPanel;
		  }
	  }

	  public UILabelPanel(Icon paramIcon, string paramString) : this(paramIcon, paramString, null)
	  {
	  }

	  public UILabelPanel(Icon paramIcon, string paramString, JComponent paramJComponent) : base(new BorderLayout())
	  {
		this.titleLabel = new JLabel(paramString, paramIcon, 10);
		this.eastLabel = new JLabel("", 4);
		this.titleLabel.Font = new Font("SansSerif", 1, 11);
		this.eastLabel.Font = new Font("SansSerif", 1, 11);
		this.eastLabel.Foreground = Color.BLACK;
		JPanel jPanel = buildHeader(this.titleLabel);
		this.o_topPanel.Border = BorderFactory.createEmptyBorder();
		this.o_topPanel.add(jPanel, "North");
		add(this.o_topPanel, "North");
		if (paramJComponent != null)
		{
		  Content = paramJComponent;
		}
		Selected = true;
		updateHeader();
	  }

	  public virtual Icon FrameIcon
	  {
		  get
		  {
			  return this.titleLabel.Icon;
		  }
		  set
		  {
			Icon icon = FrameIcon;
			this.titleLabel.Icon = value;
			firePropertyChange("frameIcon", icon, value);
		  }
	  }

	  protected internal virtual JPanel TopPanel
	  {
		  get
		  {
			  return this.o_topPanel;
		  }
	  }


	  public virtual string Title
	  {
		  get
		  {
			  return this.titleLabel.Text;
		  }
		  set
		  {
			string str = Title;
			this.titleLabel.Text = value;
			firePropertyChange("title", str, value);
		  }
	  }

	  public virtual string EastText
	  {
		  get
		  {
			  return this.eastLabel.Text;
		  }
		  set
		  {
			string str = EastText;
			this.eastLabel.Text = value;
			firePropertyChange("eastText", str, value);
		  }
	  }


	  public virtual Icon Icon
	  {
		  set
		  {
			  this.titleLabel.Icon = value;
		  }
	  }


	  public virtual Component Content
	  {
		  get
		  {
			  return hasContent() ? getComponent(1) : null;
		  }
		  set
		  {
			Component component = Content;
			if (hasContent())
			{
			  remove(component);
			}
			add(value, "Center");
			firePropertyChange("content", component, value);
		  }
	  }


	  public virtual bool Selected
	  {
		  get
		  {
			  return this.selected;
		  }
		  set
		  {
			bool @bool = Selected;
			this.selected = value;
			updateHeader();
			firePropertyChange("selected", @bool, value);
		  }
	  }


	  protected internal virtual JPanel buildHeader(JLabel paramJLabel)
	  {
		this.o_eastPanel = new JPanel(new BorderLayout());
		this.gradientPanel = createGradientPanel();
		paramJLabel.Opaque = false;
		this.eastLabel.Opaque = false;
		this.o_eastPanel.Opaque = false;
		this.o_eastPanel.add(this.eastLabel, "East");
		this.hasEastTextComponent = true;
		this.gradientPanel.add(paramJLabel, "West");
		this.gradientPanel.add(this.o_eastPanel, "East");
		this.gradientPanel.Border = BorderFactory.createEmptyBorder(3, 4, 3, 1);
		this.headerPanel = new JPanel(new BorderLayout());
		this.headerPanel.add(this.gradientPanel, "Center");
		this.headerPanel.Border = new RaisedHeaderBorder();
		this.headerPanel.Opaque = false;
		this.gradientPanel.setComponentZOrder(paramJLabel, 1);
		this.gradientPanel.setComponentZOrder(this.o_eastPanel, 0);
		return this.headerPanel;
	  }

	  public virtual Border Border
	  {
		  set
		  {
			  base.Border = value;
		  }
	  }

	  public virtual bool PaintGradient
	  {
		  set
		  {
			  this.gradientPanel.PaintGradient = value;
		  }
	  }

	  protected internal virtual GradientPanel createGradientPanel()
	  {
		  return new GradientPanel(new BorderLayout(), HeaderBackground);
	  }

	  public virtual JComponent EastComponent
	  {
		  set
		  {
			  setEastComponent(value, BorderFactory.createEmptyBorder(0, 4, 0, 1));
		  }
	  }

	  public virtual void setEastComponent(JComponent paramJComponent, Border paramBorder)
	  {
		if (this.hasEastTextComponent)
		{
		  this.o_eastPanel.remove(this.eastLabel);
		  this.gradientPanel.remove(this.o_eastPanel);
		  this.hasEastTextComponent = false;
		}
		if (this.o_curEastComponent != null)
		{
		  this.gradientPanel.remove(this.o_curEastComponent);
		}
		if (paramJComponent != null)
		{
		  this.gradientPanel.Border = paramBorder;
		  this.gradientPanel.add(paramJComponent, "East");
		  this.gradientPanel.setComponentZOrder(paramJComponent, 0);
		  this.gradientPanel.updateUI();
		  this.o_curEastComponent = paramJComponent;
		}
		else
		{
		  this.o_curEastComponent = null;
		}
	  }

	  private void updateHeader()
	  {
		this.gradientPanel.Background = HeaderBackground;
		this.gradientPanel.Opaque = Selected;
		this.titleLabel.Foreground = getTextForeground(Selected);
		this.headerPanel.repaint();
	  }

	  public virtual void updateUI()
	  {
		base.updateUI();
		if (this.titleLabel != null)
		{
		  updateHeader();
		}
	  }

	  protected internal virtual bool hasContent()
	  {
		  return (ComponentCount > 1);
	  }

	  protected internal virtual Color getTextForeground(bool paramBoolean)
	  {
		  return new Color(15, 15, 95);
	  }

	  public static Color HeaderColor
	  {
		  set
		  {
			  headerColor = value;
		  }
	  }

	  protected internal virtual Color HeaderBackground
	  {
		  get
		  {
			  return headerColor;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\ui\UILabelPanel.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}