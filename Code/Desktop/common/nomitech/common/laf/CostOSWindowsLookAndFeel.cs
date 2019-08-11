using System;

namespace Desktop.common.nomitech.common.laf
{
	using ColorUtils = com.jidesoft.utils.ColorUtils;
	using Office2003LookAndFeel = org.fife.plaf.Office2003.Office2003LookAndFeel;

	public class CostOSWindowsLookAndFeel : Office2003LookAndFeel
	{
	  public static Color ribbonBackground = new Color(1, 115, 199);

	  public static Color ribbonBorderColor = new Color(212, 212, 212);

	  public static Color ribbonTaksAreaBackground = new Color(241, 241, 241);

	  public static Color ribbonRollOverBackground = new Color(42, 138, 212);

	  public static Color ribbonTaskTitleTextForegroundColor = Color.white;

	  public static Color ribbonRollOverForeground = ribbonTaskTitleTextForegroundColor;

	  public static Color ribbonTaskTitleTextSelectedForegroundColor = ribbonBackground;

	  public static Color ribbonCommandButtonForegroundColor = new Color(68, 68, 68);

	  public static Color ribbonCommandButtonDisabledForegroundColor = Color.gray;

	  public static Color applicationButtonSelectedColor = new Color(42, 138, 212);

	  public static Color applicationButtonColor = ribbonBackground;

	  public static Color ribbonAppMenuButtonForegroundColor = Color.white;

	  public static Color ribbonAppMenuButtonSeperatorColor = new Color(42, 141, 212);

	  public static Color ribbonAppMenuButtonDisabledForegroundColor = Color.gray;

	  public static Color ribbonAppMenuButtonRolloverColor = ribbonRollOverBackground;

	  public static Color ribbonAppMenuButtonRolloverDarkerColor = ribbonRollOverBackground;

	  public static Color ribbonAppMenuSecondaryPanelBackground = Color.white;

	  public static Color ribbonButtonSelectionColor = new Color(205, 205, 205);

	  public static Color ribbonButtonSelectionDarkerColor = new Color(197, 197, 197);

	  public static Color ribbonButtonSeperatorColor = ribbonButtonSelectionDarkerColor.darker();

	  public static Color statusBarBackgroundColor = ribbonTaksAreaBackground;

	  public static Color statusBarForegroundColor = ribbonBackground.darker();

	  public static Color statusBarMemoryFillColor = ribbonButtonSelectionDarkerColor;

	  public static Color codeSelectBackgroundColor = ribbonBackground;

	  public static Color codeSelectForegroundColor = Color.white;

	  public static Color textForegroundColor = Color.black;

	  public static Color textSelectedForegroundColor = new Color(0, 155, 201);

	  public static Color selectionColor = new Color(177, 214, 240);

	  public static Color selectionForegroundColor = Color.white;

	  public static Color selectionDarkerColor = new Color(167, 204, 230);

	  public static Color collapsedButtonColor = new Color(240, 240, 240);

	  public static Color collapsedButtonColorPressed = new Color(230, 230, 230);

	  public static readonly Color applicationBackground = new Color(255, 255, 255);

	  public static readonly Color applicationBorderColor = new Color(170, 170, 170);

	  public static Color tableSelectBackground = new Color(42, 141, 212);

	  public static Color tableSelectForeground = Color.white;

	  public static Color gradientBegin = new Color(255, 255, 255);

	  public static Color gradientEnd = new Color(250, 250, 250);

	  private static string themeName = "blue";

	  public static string ThemeName
	  {
		  get
		  {
			  return themeName;
		  }
	  }

	  public static void loadBlueTheme()
	  {
		themeName = "blue";
		ribbonBackground = new Color(1, 115, 199);
		ribbonBorderColor = new Color(212, 212, 212);
		ribbonTaksAreaBackground = new Color(241, 241, 241);
		ribbonRollOverBackground = new Color(42, 138, 212);
		ribbonTaskTitleTextForegroundColor = Color.white;
		ribbonRollOverForeground = ribbonTaskTitleTextForegroundColor;
		ribbonTaskTitleTextSelectedForegroundColor = ribbonBackground;
		ribbonCommandButtonForegroundColor = new Color(68, 68, 68);
		ribbonCommandButtonDisabledForegroundColor = Color.gray;
		applicationButtonSelectedColor = new Color(42, 138, 212);
		applicationButtonColor = ribbonBackground;
		ribbonButtonSelectionColor = new Color(205, 205, 205);
		ribbonButtonSelectionDarkerColor = new Color(197, 197, 197);
		ribbonButtonSeperatorColor = ribbonButtonSelectionDarkerColor.darker();
		ribbonAppMenuButtonForegroundColor = Color.white;
		ribbonAppMenuButtonSeperatorColor = new Color(42, 141, 212);
		ribbonAppMenuButtonDisabledForegroundColor = Color.gray;
		ribbonAppMenuButtonRolloverColor = ribbonRollOverBackground;
		ribbonAppMenuButtonRolloverDarkerColor = ribbonRollOverBackground;
		ribbonAppMenuSecondaryPanelBackground = Color.white;
		statusBarBackgroundColor = ribbonTaksAreaBackground;
		statusBarForegroundColor = ribbonBackground.darker();
		statusBarMemoryFillColor = ribbonButtonSelectionDarkerColor;
		codeSelectBackgroundColor = ribbonBackground;
		codeSelectForegroundColor = Color.white;
	  }

	  public static void loadGreenTheme()
	  {
		themeName = "green";
		ribbonBackground = new Color(35, 116, 71);
		ribbonBorderColor = new Color(212, 212, 212);
		ribbonTaksAreaBackground = new Color(241, 241, 241);
		ribbonRollOverBackground = new Color(159, 212, 183);
		ribbonTaskTitleTextForegroundColor = Color.white;
		ribbonRollOverForeground = ribbonTaskTitleTextForegroundColor;
		ribbonTaskTitleTextSelectedForegroundColor = ribbonBackground;
		ribbonCommandButtonForegroundColor = new Color(68, 68, 68);
		ribbonCommandButtonDisabledForegroundColor = Color.gray;
		applicationButtonSelectedColor = ribbonRollOverBackground;
		applicationButtonColor = ribbonBackground;
		ribbonButtonSelectionColor = new Color(205, 205, 205);
		ribbonButtonSelectionDarkerColor = new Color(197, 197, 197);
		ribbonButtonSeperatorColor = ribbonButtonSelectionDarkerColor.darker();
		ribbonAppMenuButtonForegroundColor = Color.white;
		ribbonAppMenuButtonSeperatorColor = new Color(42, 212, 141);
		ribbonAppMenuButtonDisabledForegroundColor = Color.gray;
		ribbonAppMenuButtonRolloverColor = ribbonRollOverBackground;
		ribbonAppMenuButtonRolloverDarkerColor = ribbonRollOverBackground;
		ribbonAppMenuSecondaryPanelBackground = Color.white;
		statusBarBackgroundColor = ribbonTaksAreaBackground;
		statusBarForegroundColor = ribbonBackground.darker();
		statusBarMemoryFillColor = ribbonButtonSelectionDarkerColor;
		codeSelectBackgroundColor = ribbonBackground;
		codeSelectForegroundColor = Color.white;
		tableSelectBackground = new Color(198, 198, 198);
		selectionColor = tableSelectBackground;
		selectionDarkerColor = tableSelectBackground.darker();
	  }

	  public static void loadWhiteTheme()
	  {
		themeName = "white";
		ribbonBackground = new Color(255, 255, 255);
		ribbonBorderColor = new Color(170, 170, 170);
		ribbonTaksAreaBackground = new Color(254, 254, 254);
		ribbonRollOverBackground = ribbonBackground;
		ribbonTaskTitleTextForegroundColor = textForegroundColor;
		ribbonCommandButtonForegroundColor = new Color(68, 68, 68);
		ribbonCommandButtonDisabledForegroundColor = Color.gray;
		ribbonTaskTitleTextSelectedForegroundColor = textSelectedForegroundColor;
		ribbonRollOverForeground = ribbonTaskTitleTextSelectedForegroundColor;
		ribbonButtonSelectionColor = selectionColor;
		ribbonButtonSelectionDarkerColor = selectionDarkerColor;
		applicationButtonSelectedColor = new Color(0, 104, 187);
		applicationButtonColor = new Color(0, 114, 197);
		ribbonAppMenuButtonForegroundColor = Color.white;
		ribbonAppMenuButtonSeperatorColor = new Color(42, 141, 212);
		ribbonAppMenuButtonDisabledForegroundColor = Color.gray;
		ribbonAppMenuButtonRolloverColor = new Color(42, 138, 212);
		ribbonAppMenuButtonRolloverDarkerColor = ribbonAppMenuButtonRolloverColor;
		ribbonAppMenuSecondaryPanelBackground = Color.white;
		statusBarBackgroundColor = applicationButtonColor;
		statusBarForegroundColor = Color.white;
		statusBarMemoryFillColor = Color.gray;
		ribbonButtonSeperatorColor = ribbonButtonSelectionDarkerColor.darker();
		codeSelectBackgroundColor = selectionDarkerColor;
		codeSelectForegroundColor = Color.black;
	  }

	  public virtual object[] ComponentDefaults
	  {
		  get
		  {
			Color color1 = new Color(232, 7, 35);
			Color color2 = ThemeName.Equals("blue") ? new Color(42, 138, 212) : (ThemeName.Equals("green") ? new Color(159, 212, 183) : selectionColor);
			Color color3 = ThemeName.Equals("blue") ? (new Color(42, 138, 212)).darker() : (ThemeName.Equals("green") ? (new Color(159, 212, 183)).darker() : selectionDarkerColor);
			Color color4 = selectionColor;
			Color color5 = selectionDarkerColor;
			string str1 = (ThemeName.Equals("blue") || ThemeName.Equals("green")) ? "_white.png" : ".png";
			string str2 = ".png";
			return new object[] {"InternalFrame.closeIcon", createIcon("close" + str1), "InternalFrame.closeDownIcon", createIconWithBackground("close_white.png", color1.darker()), "InternalFrame.closeOverIcon", createIconWithBackground("close_white.png", color1), "InternalFrame.maximizeIcon", createIcon("maximize" + str1), "InternalFrame.maximizeDownIcon", createIconWithBackground("maximize" + str1, color3), "InternalFrame.maximizeOverIcon", createIconWithBackground("maximize" + str1, color2), "InternalFrame.minimizeIcon", createIcon("restore" + str1), "InternalFrame.minimizeDownIcon", createIconWithBackground("restore" + str1, color3), "InternalFrame.minimizeOverIcon", createIconWithBackground("restore" + str1, color2), "InternalFrame.iconifyIcon", createIcon("minimize" + str1), "InternalFrame.iconifyDownIcon", createIconWithBackground("minimize" + str1, color3), "InternalFrame.iconifyOverIcon", createIconWithBackground("minimize" + str1, color2), "InternalFrame.helpIcon", createIcon("help" + str1), "InternalFrame.helpDownIcon", createIconWithBackground("help" + str1, color3), "InternalFrame.helpOverIcon", createIconWithBackground("help" + str1, color2), "InternalBackstageFrame.closeIcon", createIcon("close" + str2), "InternalBackstageFrame.closeDownIcon", createIconWithBackground("close_white.png", color1.darker()), "InternalBackstageFrame.closeOverIcon", createIconWithBackground("close_white.png", color1), "InternalBackstageFrame.maximizeIcon", createIcon("maximize" + str2), "InternalBackstageFrame.maximizeDownIcon", createIconWithBackground("maximize" + str2, color5), "InternalBackstageFrame.maximizeOverIcon", createIconWithBackground("maximize" + str2, color4), "InternalBackstageFrame.minimizeIcon", createIcon("restore" + str2), "InternalBackstageFrame.minimizeDownIcon", createIconWithBackground("restore" + str2, color5), "InternalBackstageFrame.minimizeOverIcon", createIconWithBackground("restore" + str2, color4), "InternalBackstageFrame.iconifyIcon", createIcon("minimize" + str2), "InternalBackstageFrame.iconifyDownIcon", createIconWithBackground("minimize" + str2, color5), "InternalBackstageFrame.iconifyOverIcon", createIconWithBackground("minimize" + str2, color4), "InternalBackstageFrame.helpIcon", createIcon("help" + str2), "InternalBackstageFrame.helpDownIcon", createIconWithBackground("help" + str2, color5), "InternalBackstageFrame.helpOverIcon", createIconWithBackground("help" + str2, color4), "Table.gridColor", themeName.Equals("blue") ? new ColorUIResource(new Color(208, 229, 215)) : new ColorUIResource(new Color(208, 215, 229)), "Ribbon.artIcon", createIcon(themeName.Equals("blue") ? "ribbon_art_blue.png" : (themeName.Equals("green") ? "ribbon_art_green.png" : "ribbon_art.png")), "Ribbon.artBackstageIcon", createIcon("ribbon_art.png"), "Ribbon.border", new BorderUIResource.EmptyBorderUIResource(3, 1, 2, 1), "RibbonBand.border", new BorderUIResource.EmptyBorderUIResource(2, 4, 2, 5), "ToggleTabButton.border", new BorderUIResource.EmptyBorderUIResource(0, 14, 0, 14), "ControlPanel.border", new BorderUIResource.EmptyBorderUIResource(0, 0, 0, 0), "Icon.floating", Convert.ToBoolean(false), "Panel.background", applicationBackground};
		  }
	  }

	  private ImageIcon createIconWithBackground(string paramString, Color paramColor)
	  {
		ImageIcon imageIcon = createIcon(paramString);
		BufferedImage bufferedImage = new BufferedImage(imageIcon.IconWidth, imageIcon.IconHeight, 1);
		Graphics2D graphics2D = bufferedImage.createGraphics();
		graphics2D.Color = paramColor;
		graphics2D.fillRect(0, 0, bufferedImage.Width, bufferedImage.Height);
		graphics2D.drawImage(imageIcon.Image, 0, 0, null);
		graphics2D.dispose();
		return new ImageIcon(bufferedImage);
	  }

	  private ImageIcon createIcon(string paramString)
	  {
		  return new ImageIcon(typeof(org.officelaf.OfficeLookAndFeelHelper).getResource("images/" + paramString));
	  }

	  public static Font getSystemFont(int paramInt, float paramFloat)
	  {
		  return new Font("Dialog", paramInt, (int)paramFloat);
	  }

	  public virtual bool SupportsWindowDecorations
	  {
		  get
		  {
			  return true;
		  }
	  }

	  public virtual string Description
	  {
		  get
		  {
			  return "The CostOS Office 2013 Look and Feel";
		  }
	  }

	  public virtual string ID
	  {
		  get
		  {
			  return "CostOSLookFeel";
		  }
	  }

	  public virtual string Name
	  {
		  get
		  {
			  return "CostOS Look And Feel";
		  }
	  }

	  protected internal virtual void initClassDefaults(UIDefaults paramUIDefaults)
	  {
		base.initClassDefaults(paramUIDefaults);
		object[] arrayOfObject = new object[] {"PanelUI", "org.officelaf.OfficePanelUI", "RootPaneUI", "Desktop.common.nomitech.common.laf.CostOSRootPaneUI", "CommandButtonUI", "Desktop.common.nomitech.common.laf.CostOSCommandButtonUI", "CostOSApplicationMenuCommandButtonPanelUI", "Desktop.common.nomitech.common.laf.CostOSApplicationMenuCommandButtonPanelUI", "CommandToggleButtonUI", "Desktop.common.nomitech.common.laf.CostOSCommandToggleButtonUI", "CommandMenuButtonUI", "Desktop.common.nomitech.common.laf.CostOSCommandMenuButtonUI", "CommandButtonPanelUI", "Desktop.common.nomitech.common.laf.CostOSCommandButtonPanelUI", "RibbonUI", "Desktop.common.nomitech.common.laf.CostOSRibbonUI", "RibbonBandUI", "Desktop.common.nomitech.common.laf.CostOSRibbonBandUI", "BandControlPanelUI", "org.officelaf.ribbon.OfficeBandControlPanelUI", "RibbonTaskToggleButtonUI", "Desktop.common.nomitech.common.laf.CostOSRibbonTaskToggleButtonUI", "RibbonApplicationMenuButtonUI", "Desktop.common.nomitech.common.laf.CostOSRibbonApplicationMenuButtonUI"};
		paramUIDefaults.putDefaults(arrayOfObject);
	  }

	  protected internal virtual object[] getColorSchemeBlueDefaults(UIDefaults paramUIDefaults)
	  {
		ColorUIResource colorUIResource1 = new ColorUIResource(applicationBackground);
		ColorUIResource colorUIResource2 = new ColorUIResource(applicationBackground);
		return new object[] {"OfficeLnF.name", "Office2013", "OfficeLnF.ComboBox.Arrow.Armed.Gradient1", new ColorUIResource(255, 244, 204), "OfficeLnF.ComboBox.Arrow.Armed.Gradient2", new ColorUIResource(255, 212, 151), "OfficeLnF.ComboBox.Arrow.Selected.Gradient1", new ColorUIResource(254, 145, 78), "OfficeLnF.ComboBox.Arrow.Selected.Gradient2", new ColorUIResource(255, 203, 135), "OfficeLnF.ComboBox.Arrow.Normal.Gradient1", new ColorUIResource(195, 218, 249), "OfficeLnF.ComboBox.Arrow.Normal.Gradient2", null, "Office2003LnF.CBMenuItemCheckBGColor", new ColorUIResource(255, 192, 111), "Office2003LnF.CBMenuItemCheckBGSelectedColor", new ColorUIResource(254, 128, 62), "OfficeLnF.HighlightBorderColor", new ColorUIResource(applicationBorderColor), "OfficeLnF.HighlightColor", new ColorUIResource(selectionColor), "Office2003LnF.ToolBarGripLightColor", new ColorUIResource(255, 255, 255), "Office2003LnF.ToolBarGripDarkColor", new ColorUIResource(applicationBorderColor), "Office2003LnF.MenuItemBeginGradientColor", new ColorUIResource(227, 239, 255), "Office2003LnF.MenuItemEndGradientColor", new ColorUIResource(135, 173, 228), "Office2003LnF.PanelGradientColor1", new ColorUIResource(158, 190, 245), "Office2003LnF.PanelGradientColor2", new ColorUIResource(195, 218, 249), "Office2003LnF.ToolBarBeginGradientColor", new ColorUIResource(applicationBackground), "Office2003LnF.ToolBarEndGradientColor", new ColorUIResource(applicationBackground), "Office2003LnF.ToolBarBottomBorderColor", new ColorUIResource(applicationBackground), "Office2003LnF.ToolBarBackgroundColor", new ColorUIResource(applicationBackground), "Office2003LnF.ToolBarButtonArmedBeginGradientColor", new ColorUIResource(selectionColor), "Office2003LnF.ToolBarButtonArmedEndGradientColor", new ColorUIResource(selectionColor), "Office2003LnF.ToolBarButtonSelectedBeginGradientColor", new ColorUIResource(selectionDarkerColor), "Office2003LnF.ToolBarButtonSelectedEndGradientColor", new ColorUIResource(selectionDarkerColor), "Office2003LnF.MenuBarItemArmedBeginGradientColor", new ColorUIResource(selectionDarkerColor), "Office2003LnF.MenuBarItemArmedEndGradientColor", new ColorUIResource(selectionDarkerColor), "Office2003LnF.MenuBarItemSelectedBeginGradientColor", new ColorUIResource(selectionDarkerColor), "Office2003LnF.MenuBarItemSelectedEndGradientColor", new ColorUIResource(selectionDarkerColor), "OfficeLnF.MenuBorderColor", new ColorUIResource(0, 45, 150), "UILabelPanel.gradientBegin", new ColorUIResource(gradientBegin), "UILabelPanel.gradientEnd", new ColorUIResource(gradientEnd), "UILabelPanel.noGradientFill", new ColorUIResource(applicationBackground), "MenuItem.background", new ColorUIResource(applicationBackground), "checkBoxMenuItemBackground", colorUIResource2, "OptionPane.background", colorUIResource2, "menuBackground", colorUIResource2, "menuBarBackground", colorUIResource1, "menuItemBackground", colorUIResource2, "radioButtonMenuItemBackground", colorUIResource2, "toolBarShadow", new ColorUIResource(applicationBorderColor), "toolBarHighlight", new ColorUIResource(applicationBorderColor), "separatorForeground", new ColorUIResource(textForegroundColor), "separatorBackground", colorUIResource2, "Table.selectionBackground", new ColorUIResource(tableSelectBackground), "Table.selectionForeground", new ColorUIResource(tableSelectForeground), "Tree.selectionBackground", new ColorUIResource(tableSelectBackground), "Tree.selectionForeground", new ColorUIResource(tableSelectForeground), "List.selectionBackground", new ColorUIResource(tableSelectBackground), "List.selectionForeground", new ColorUIResource(tableSelectForeground), "ComboBox.selectionBackground", new ColorUIResource(tableSelectBackground), "ComboBox.selectionForeground", new ColorUIResource(tableSelectForeground), "RadioButton.background", new ColorUIResource(applicationBackground), "RadioButton.border", new ColorUIResource(applicationBackground), "RadioButton.darkShadow", new ColorUIResource(applicationBackground), "ToolBar.border", BorderFactory.createEmptyBorder(), "Separator.background", applicationBorderColor, "Separator.shadow", colorUIResource2, "Office2003LnF.CBMenuItemCheckBGColor", selectionColor, "SidePane.selectedButtonBackground", selectionDarkerColor, "JideButton.selectedBackground", selectionDarkerColor, "Gripper.foreground", ribbonBackground, "OptionPane.bannerLt", new ColorUIResource(applicationBackground), "OptionPane.bannerDk", new ColorUIResource(applicationBackground), "CollapsiblePane.background", new ColorUIResource(ribbonBackground), "CollapsiblePanes.backgroundLt", new ColorUIResource(ribbonBackground), "CollapsiblePanes.backgroundDk", new ColorUIResource(ribbonBackground), "CollapsiblePane.emphasizedBackground", applicationButtonSelectedColor, "CollapsiblePaneTitlePane.backgroundLt.emphasized", new ColorUIResource(applicationButtonSelectedColor), "CollapsiblePaneTitlePane.backgroundDk.emphasized", new ColorUIResource(applicationButtonSelectedColor), "CollapsiblePane.emphasizedForeground", Color.white, "CollapsiblePaneTitlePane.foreground.emphasized", new ColorUIResource(Color.white), "CollapsiblePaneTitlePane.foreground.focus.emphasized", new ColorUIResource(Color.white.brighter()), "TextField.inactiveBackground", applicationBackground, "CheckBox.background", applicationBackground, "ComboBox.buttonBackground", applicationBackground, "control", applicationBackground, "JideTabbedPane.tabAreaBackground", new ColorUIResource(selectionDarkerColor), "JideTabbedPane.selectedTabBackground", new ColorUIResource(selectionDarkerColor), "JideTabbedPane.selectedTabBackgroundDk", ColorUtils.getDerivedColor(selectionDarkerColor, 0.6F), "JideTabbedPane.selectedTabBackgroundDk", ColorUtils.getDerivedColor(selectionDarkerColor, 0.4F), "selection.border", selectionColor, "selection.RolloverLt", ColorUtils.getDerivedColor(selectionColor, 0.6F), "selection.RolloverDk", ColorUtils.getDerivedColor(selectionColor, 0.4F), "selection.SelectedLt", ColorUtils.getDerivedColor(selectionDarkerColor, 0.6F), "selection.SelectedDk", ColorUtils.getDerivedColor(selectionDarkerColor, 0.4F), "selection.PressedLt", ColorUtils.getDerivedColor(selectionDarkerColor, 0.4F), "selection.PressedDk", ColorUtils.getDerivedColor(selectionDarkerColor, 0.6F)};
	  }

	  protected internal virtual void initComponentDefaults2003(UIDefaults paramUIDefaults)
	  {
		System.setProperty("OfficeLnFs.theme", "silver");
		base.initComponentDefaults2003(paramUIDefaults);
	  }

	  protected internal virtual void initSystemColorDefaults2003(UIDefaults paramUIDefaults)
	  {
		base.initSystemColorDefaults2003(paramUIDefaults);
		System.setProperty("OfficeLnFs.theme", "silver");
		paramUIDefaults.putDefaults(ComponentDefaults);
		paramUIDefaults.putDefaults(getColorSchemeBlueDefaults(paramUIDefaults));
	  }

	  public virtual void loadDefaults(UIDefaults paramUIDefaults)
	  {
		if (paramUIDefaults == null)
		{
		  paramUIDefaults = UIManager.Defaults;
		}
		paramUIDefaults.putDefaults(ComponentDefaults);
		paramUIDefaults.putDefaults(getColorSchemeBlueDefaults(paramUIDefaults));
	  }

	  public static void listUIProperties(UIDefaults paramUIDefaults)
	  {
		if (paramUIDefaults == null)
		{
		  paramUIDefaults = UIManager.Defaults;
		}
		System.Collections.IEnumerator enumeration = paramUIDefaults.keys();
		while (enumeration.MoveNext())
		{
		  object @object = enumeration.Current;
		  if (@object.ToString().ToLower().IndexOf("collaps") != -1)
		  {
			Console.Write("{0,50} : {1}\n", new object[] {@object, UIManager.get(@object)});
		  }
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\laf\CostOSWindowsLookAndFeel.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}