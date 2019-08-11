using System.Collections.Generic;

namespace Desktop.common.nomitech.common.ui
{
	using JideButton = com.jidesoft.swing.JideButton;

	public class UISplitButton : JideButton
	{
	  private JPopupMenu dropDownMenu = null;

	  private System.Collections.IList actionListenerList = new List<object>();

	  public UISplitButton(string paramString) : base(paramString)
	  {
		loadUI();
	  }

	  public UISplitButton(string paramString, Icon paramIcon) : base(paramString + "      ", paramIcon)
	  {
		loadUI();
	  }

	  public UISplitButton(Icon paramIcon) : base("    ", paramIcon)
	  {
		loadUI();
	  }

	  private void loadUI()
	  {
		Font = new Font("SansSerif", 1, 11);
		Layout = new FlowLayout(0);
		addMouseListener(new SplitButtonMouseListener(this, null));
	  }

	  public virtual JPopupMenu Menu
	  {
		  set
		  {
			this.dropDownMenu = value;
			this.dropDownMenu.addFocusListener(new SplitButtonFocusAdapter(this, null));
		  }
		  get
		  {
			  return this.dropDownMenu;
		  }
	  }


	  public virtual void paint(Graphics paramGraphics)
	  {
		  base.paint(paramGraphics);
	  }

	  private void fireToListeners(MouseEvent paramMouseEvent)
	  {
		System.Collections.IEnumerator iterator = this.actionListenerList.GetEnumerator();
		ActionEvent actionEvent = new ActionEvent(paramMouseEvent.Source, paramMouseEvent.ID, ActionCommand);
		while (iterator.MoveNext())
		{
		  ActionListener actionListener = (ActionListener)iterator.Current;
		  actionListener.actionPerformed(actionEvent);
		}
	  }

	  public virtual void addActionListener(ActionListener paramActionListener)
	  {
		  this.actionListenerList.Add(paramActionListener);
	  }

	  public virtual void removeActionListener(ActionListener paramActionListener)
	  {
		  this.actionListenerList.Remove(paramActionListener);
	  }

	  private class SplitButtonFocusAdapter : FocusListener
	  {
		  private readonly UISplitButton outerInstance;

		internal SplitButtonFocusAdapter(UISplitButton outerInstance)
		{
			this.outerInstance = outerInstance;
		}

		public virtual void focusGained(FocusEvent param1FocusEvent)
		{
		}

		public virtual void focusLost(FocusEvent param1FocusEvent)
		{
			outerInstance.dropDownMenu.Visible = false;
		}
	  }

	  private class SplitButtonMouseListener : MouseAdapter
	  {
		  private readonly UISplitButton outerInstance;

		internal SplitButtonMouseListener(UISplitButton outerInstance)
		{
			this.outerInstance = outerInstance;
		}

		public virtual void mousePressed(MouseEvent param1MouseEvent)
		{
		}

		public virtual void mouseReleased(MouseEvent param1MouseEvent)
		{
		  if (!outerInstance.Enabled)
		  {
			return;
		  }
		  if (outerInstance.dropDownMenu == null)
		  {
			outerInstance.fireToListeners(param1MouseEvent);
			return;
		  }
		  if (outerInstance.actionListenerList.Count == 0)
		  {
			if (outerInstance.dropDownMenu.Width == 0)
			{
			  outerInstance.dropDownMenu.Visible = true;
			  outerInstance.dropDownMenu.Visible = false;
			}
			outerInstance.dropDownMenu.show(param1MouseEvent.Component, -(outerInstance.dropDownMenu.Width - outerInstance.Width), outerInstance.Height);
			return;
		  }
		  if (param1MouseEvent.X > outerInstance.Width - 17)
		  {
			outerInstance.dropDownMenu.show(param1MouseEvent.Component, 0, outerInstance.Height);
		  }
		  else
		  {
			outerInstance.dropDownMenu.Visible = false;
			outerInstance.fireToListeners(param1MouseEvent);
		  }
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\ui\UISplitButton.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}