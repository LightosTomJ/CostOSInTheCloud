using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.ui
{
	using ListExComboBox = com.jidesoft.combobox.ListExComboBox;

	public class UIListExComboBox : ListExComboBox
	{
	  private Timer o_timer;

	  private Component component;

	  public UIListExComboBox(ComboBoxModel paramComboBoxModel, Type paramClass) : base(paramComboBoxModel, paramClass)
	  {
		initUI();
	  }

	  public UIListExComboBox()
	  {
		  initUI();
	  }

	  public UIListExComboBox(ComboBoxModel paramComboBoxModel) : base(paramComboBoxModel)
	  {
		initUI();
	  }

	  public UIListExComboBox(object[] paramArrayOfObject, Type paramClass) : base(paramArrayOfObject, paramClass)
	  {
		initUI();
	  }

	  public UIListExComboBox(object[] paramArrayOfObject) : base(paramArrayOfObject)
	  {
		initUI();
	  }

	  public UIListExComboBox<T1>(List<T1> paramVector, Type paramClass) : base(paramVector, paramClass)
	  {
		initUI();
	  }

	  public UIListExComboBox<T1>(List<T1> paramVector) : base(paramVector)
	  {
		initUI();
	  }

	  public virtual Component ComponentToLock
	  {
		  set
		  {
			  this.component = value;
		  }
	  }

	  private void initUI()
	  {
		this.o_timer = new Timer(200, new ActionListenerAnonymousInnerClass(this));
		this.o_timer.Repeats = false;
		addPopupMenuListener(new PopupMenuListenerAnonymousInnerClass(this));
	  }

	  private class ActionListenerAnonymousInnerClass : ActionListener
	  {
		  private readonly UIListExComboBox outerInstance;

		  public ActionListenerAnonymousInnerClass(UIListExComboBox outerInstance) : base(outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public void actionPerformed(ActionEvent param1ActionEvent)
		  {
			if (outerInstance.component != null)
			{
			  outerInstance.component.Enabled = true;
			}
			if (outerInstance.Showing)
			{
			  outerInstance.fireActionEvent();
			}
		  }
	  }

	  private class PopupMenuListenerAnonymousInnerClass : PopupMenuListener
	  {
		  private readonly UIListExComboBox outerInstance;

		  public PopupMenuListenerAnonymousInnerClass(UIListExComboBox outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public void popupMenuWillBecomeVisible(PopupMenuEvent param1PopupMenuEvent)
		  {
		  }

		  public void popupMenuWillBecomeInvisible(PopupMenuEvent param1PopupMenuEvent)
		  {
			if (outerInstance.component != null)
			{
			  outerInstance.component.Enabled = false;
			}
			outerInstance.o_timer.start();
		  }

		  public void popupMenuCanceled(PopupMenuEvent param1PopupMenuEvent)
		  {
		  }
	  }

	  public virtual void setSelectedItem(object paramObject, bool paramBoolean)
	  {
		  base.setSelectedItem(paramObject, false);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\ui\UIListExComboBox.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}