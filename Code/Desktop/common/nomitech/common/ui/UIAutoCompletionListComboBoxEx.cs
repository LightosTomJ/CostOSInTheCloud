using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.ui
{
	using AutoCompletion = com.jidesoft.swing.AutoCompletion;

	public class UIAutoCompletionListComboBoxEx : UIListExComboBox
	{
	  protected internal AutoCompletion _autoCompletion;

	  public UIAutoCompletionListComboBoxEx()
	  {
		  initComponents();
	  }

	  public UIAutoCompletionListComboBoxEx(ComboBoxModel paramComboBoxModel, Type paramClass) : base(paramComboBoxModel, paramClass)
	  {
		initComponents();
	  }

	  public UIAutoCompletionListComboBoxEx(ComboBoxModel paramComboBoxModel) : base(paramComboBoxModel)
	  {
		initComponents();
	  }

	  public UIAutoCompletionListComboBoxEx(object[] paramArrayOfObject, Type paramClass) : base(paramArrayOfObject, paramClass)
	  {
		initComponents();
	  }

	  public UIAutoCompletionListComboBoxEx(object[] paramArrayOfObject) : base(paramArrayOfObject)
	  {
		initComponents();
	  }

	  public UIAutoCompletionListComboBoxEx<T1>(List<T1> paramVector, Type paramClass) : base(paramVector, paramClass)
	  {
		initComponents();
	  }

	  public UIAutoCompletionListComboBoxEx<T1>(List<T1> paramVector) : base(paramVector)
	  {
		initComponents();
	  }

	  protected internal virtual void initComponents()
	  {
		Editable = true;
		this._autoCompletion = createAutoCompletion();
	  }

	  protected internal virtual AutoCompletion createAutoCompletion()
	  {
		  return (this._autoCompletion == null) ? new AutoCompletion(this) : this._autoCompletion;
	  }

	  public virtual bool Strict
	  {
		  get
		  {
			  return AutoCompletion.Strict;
		  }
		  set
		  {
			  AutoCompletion.Strict = value;
		  }
	  }


	  public virtual bool StrictCompletion
	  {
		  get
		  {
			  return AutoCompletion.StrictCompletion;
		  }
		  set
		  {
			  AutoCompletion.StrictCompletion = value;
		  }
	  }


	  public virtual AutoCompletion AutoCompletion
	  {
		  get
		  {
			  return this._autoCompletion;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\ui\UIAutoCompletionListComboBoxEx.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}