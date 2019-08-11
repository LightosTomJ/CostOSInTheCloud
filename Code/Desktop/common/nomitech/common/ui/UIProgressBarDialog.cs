using System;
using System.Threading;

namespace Desktop.common.nomitech.common.ui
{

	public class UIProgressBarDialog : JDialog, PropertyChangeListener, UIProgress
	{
		private bool InstanceFieldsInitialized = false;

		private void InitializeInstanceFields()
		{
			o_cancelAddActionLinstener = new CancelAddActionLinstener(this);
		}

	  private const int WIDTH = 380;

	  private const int HEIGHT = 130;

	  private const int MAX_TIMES_TO_INVOKE = 200;

	  private JPanel o_mainPanel = new JPanel(new BorderLayout());

	  private JProgressBar o_progressBar = null;

	  private JLabel o_descriptionLabel = null;

	  private int o_totalTimes = 0;

	  private int o_currentTimes = 0;

	  private int o_timeToInvoke = 0;

	  private CancelAddActionLinstener o_cancelAddActionLinstener;

	  private JButton cancelButton;

	  protected internal Component previousFocus;

	  private Timer t;

	  public UIProgressBarDialog(JFrame paramJFrame, string paramString, int paramInt) : base(paramJFrame, paramString, false)
	  {
		  if (!InstanceFieldsInitialized)
		  {
			  InitializeInstanceFields();
			  InstanceFieldsInitialized = true;
		  }
		setSize(380, 130);
		Modal = true;
		init(paramInt);
		Resizable = false;
		if (paramJFrame != null)
		{
		  this.previousFocus = paramJFrame.MostRecentFocusOwner;
		}
	  }

	  public UIProgressBarDialog(JDialog paramJDialog, string paramString, int paramInt) : base(paramJDialog, paramString, false)
	  {
		  if (!InstanceFieldsInitialized)
		  {
			  InitializeInstanceFields();
			  InstanceFieldsInitialized = true;
		  }
		setSize(380, 130);
		Modal = true;
		init(paramInt);
		Resizable = false;
		if (paramJDialog != null)
		{
		  this.previousFocus = paramJDialog.MostRecentFocusOwner;
		}
	  }

	  private void init(int paramInt)
	  {
		this.o_totalTimes = paramInt;
		if (this.o_totalTimes > 200)
		{
		  this.o_timeToInvoke = this.o_totalTimes / 200;
		}
		else
		{
		  this.o_timeToInvoke = 1;
		}
		if (this.o_timeToInvoke <= 0)
		{
		  this.o_timeToInvoke = 1;
		}
		loadUI();
		ContentPane.add(this.o_mainPanel);
		if (Parent != null)
		{
		  centerDialog(Parent, this);
		}
		toFront();
		DefaultCloseOperation = 0;
	  }

	  private void centerDialog(Component paramComponent, JDialog paramJDialog)
	  {
		Rectangle rectangle = paramComponent.Bounds;
		int i = paramJDialog.Width;
		int j = paramJDialog.Height;
		int k = (paramComponent.Width - paramJDialog.Width) / 2;
		int m = (paramComponent.Height - paramJDialog.Height) / 2;
		paramJDialog.setLocation(paramComponent.X + k, paramComponent.Y + m);
	  }

	  private void loadUI()
	  {
		JPanel jPanel = new JPanel();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.text.DecimalFormat decimalFormat = (java.text.DecimalFormat)java.text.DecimalFormat.getInstance(java.util.Locale.ENGLISH).clone();
		DecimalFormat decimalFormat = (DecimalFormat)DecimalFormat.getInstance(Locale.ENGLISH).clone();
		decimalFormat.applyPattern("0");
		this.o_progressBar = new JProgressBar(0, this.o_totalTimes);
		this.o_progressBar.StringPainted = true;
		this.o_descriptionLabel = new JLabel();
		this.o_progressBar.addChangeListener(new ChangeListenerAnonymousInnerClass(this, decimalFormat));
		jPanel.Border = BorderFactory.createEmptyBorder(10, 0, 0, 0);
		jPanel.Layout = new BoxLayout(jPanel, 1);
		jPanel.add(this.o_descriptionLabel);
		jPanel.add(Box.createVerticalStrut(5));
		jPanel.add(this.o_progressBar);
		jPanel.add(Box.createVerticalStrut(5));
		this.o_mainPanel.Border = BorderFactory.createEmptyBorder(8, 8, 8, 8);
		this.o_mainPanel.add(jPanel, "Center");
	  }

	  private class ChangeListenerAnonymousInnerClass : ChangeListener
	  {
		  private readonly UIProgressBarDialog outerInstance;

		  private DecimalFormat decimalFormat;

		  public ChangeListenerAnonymousInnerClass(UIProgressBarDialog outerInstance, DecimalFormat decimalFormat)
		  {
			  this.outerInstance = outerInstance;
			  this.decimalFormat = decimalFormat;
		  }

		  public void stateChanged(ChangeEvent param1ChangeEvent)
		  {
			double d = outerInstance.o_progressBar.PercentComplete;
			if (d > 1.0D)
			{
			  d = 1.0D;
			}
			outerInstance.o_progressBar.String = decimalFormat.format(d * 100.0D) + "%";
		  }
	  }

	  public virtual void showCancelButton()
	  {
		  showCancelButton(this.o_cancelAddActionLinstener);
	  }

	  public virtual void showCancelButton(ActionListener paramActionListener)
	  {
		this.cancelButton = new JButton("Cancel");
		this.cancelButton.ActionCommand = "Cancel";
		JPanel jPanel = new JPanel(new FlowLayout(2));
		jPanel.add(this.cancelButton);
		this.o_mainPanel.add(jPanel, "South");
		if (paramActionListener != null)
		{
		  this.cancelButton.addActionListener(paramActionListener);
		}
	  }

	  public virtual bool canCancel()
	  {
		  return !(this.cancelButton == null || !this.cancelButton.Showing);
	  }

	  public virtual bool Canceled
	  {
		  get
		  {
			  return this.o_cancelAddActionLinstener.Canceled;
		  }
		  set
		  {
			  this.o_cancelAddActionLinstener.Canceled = value;
		  }
	  }


	  public virtual bool Indeterminate
	  {
		  set
		  {
			if (SwingUtilities.EventDispatchThread)
			{
			  this.o_progressBar.Indeterminate = value;
			  if (value)
			  {
				this.o_progressBar.String = "Please wait...";
			  }
			}
			else
			{
			  try
			  {
				SwingUtilities.invokeAndWait(new SetIndeterminate(this, value));
			  }
			  catch (InterruptedException interruptedException)
			  {
				Console.WriteLine(interruptedException.ToString());
				Console.Write(interruptedException.StackTrace);
			  }
			  catch (InvocationTargetException invocationTargetException)
			  {
				Console.WriteLine(invocationTargetException.ToString());
				Console.Write(invocationTargetException.StackTrace);
			  }
			}
		  }
		  get
		  {
			  return this.o_progressBar.Indeterminate;
		  }
	  }

	  public virtual int TotalTimes
	  {
		  set
		  {
			if (SwingUtilities.EventDispatchThread)
			{
			  this.o_totalTimes = value;
			  if (this.o_totalTimes > 200)
			  {
				this.o_timeToInvoke = this.o_totalTimes / 200;
			  }
			  else
			  {
				this.o_timeToInvoke = 1;
			  }
			  if (this.o_timeToInvoke <= 0)
			  {
				this.o_timeToInvoke = 1;
			  }
			  this.o_progressBar.Minimum = 0;
			  this.o_progressBar.Maximum = value;
			}
			else
			{
			  try
			  {
				SwingUtilities.invokeAndWait(new SetTotalTimes(this, value));
			  }
			  catch (InterruptedException interruptedException)
			  {
				Console.WriteLine(interruptedException.ToString());
				Console.Write(interruptedException.StackTrace);
			  }
			  catch (InvocationTargetException invocationTargetException)
			  {
				Console.WriteLine(invocationTargetException.ToString());
				Console.Write(invocationTargetException.StackTrace);
			  }
			}
		  }
		  get
		  {
			  return this.o_totalTimes;
		  }
	  }


	  public virtual void forceTotalTimes(int paramInt)
	  {
		if (SwingUtilities.EventDispatchThread)
		{
		  this.o_totalTimes = paramInt;
		  this.o_timeToInvoke = 1;
		  this.o_progressBar.Minimum = 0;
		  this.o_progressBar.Maximum = paramInt;
		}
		else
		{
		  try
		  {
			SwingUtilities.invokeAndWait(new ForceTotalTimes(this, paramInt));
		  }
		  catch (InterruptedException interruptedException)
		  {
			Console.WriteLine(interruptedException.ToString());
			Console.Write(interruptedException.StackTrace);
		  }
		  catch (InvocationTargetException invocationTargetException)
		  {
			Console.WriteLine(invocationTargetException.ToString());
			Console.Write(invocationTargetException.StackTrace);
		  }
		}
	  }

	  public virtual void incrementProgress(string paramString, int paramInt)
	  {
		if (!VisibleAndShowing)
		{
		  this.o_currentTimes += paramInt;
		  return;
		}
		if (SwingUtilities.EventDispatchThread)
		{
		  if (!string.ReferenceEquals(paramString, null))
		  {
			this.o_descriptionLabel.Text = paramString;
			this.o_progressBar.String = paramString;
		  }
		  this.o_progressBar.Value = this.o_currentTimes;
		}
		else
		{
		  this.o_currentTimes += paramInt;
		  checkAndInvokeLater(new IncrementProgress(this, paramString, paramInt));
		}
	  }

	  private void checkAndInvokeLater(ThreadStart paramRunnable)
	  {
		if (!Showing)
		{
		  return;
		}
		if (this.o_currentTimes % this.o_timeToInvoke == 0)
		{
		  SwingUtilities.invokeLater(paramRunnable);
		}
	  }

	  public virtual void incrementProgress(int paramInt)
	  {
		if (!VisibleAndShowing)
		{
		  this.o_currentTimes += paramInt;
		  return;
		}
		if (SwingUtilities.EventDispatchThread)
		{
		  this.o_progressBar.Value = this.o_currentTimes;
		}
		else
		{
		  this.o_currentTimes += paramInt;
		  checkAndInvokeLater(new IncrementProgress(this, paramInt));
		}
	  }

	  public virtual int Progress
	  {
		  set
		  {
			if (!VisibleAndShowing)
			{
			  this.o_currentTimes = value;
			  return;
			}
			if (SwingUtilities.EventDispatchThread)
			{
			  this.o_progressBar.Value = this.o_currentTimes;
			}
			else
			{
			  this.o_currentTimes = value;
			  checkAndInvokeLater(new SetProgress(this, this.o_descriptionLabel.Text, value));
			}
		  }
	  }

	  public virtual string Progress
	  {
		  set
		  {
			if (SwingUtilities.EventDispatchThread)
			{
			  this.o_descriptionLabel.Text = value;
			}
			else
			{
			  SwingUtilities.invokeLater(new SetProgress(this, value, this.o_currentTimes));
			}
		  }
	  }

	  private bool VisibleAndShowing
	  {
		  get
		  {
			  return (Visible && Showing);
		  }
	  }

	  public virtual void setProgress(string paramString, int paramInt)
	  {
		if (!VisibleAndShowing)
		{
		  this.o_currentTimes = paramInt;
		  return;
		}
		if (SwingUtilities.EventDispatchThread)
		{
		  this.o_descriptionLabel.Text = paramString;
		  this.o_progressBar.Value = this.o_currentTimes;
		}
		else
		{
		  this.o_currentTimes = paramInt;
		  SwingUtilities.invokeLater(new SetProgress(this, paramString, this.o_currentTimes));
		}
	  }

	  public virtual string Title
	  {
		  set
		  {
			if (SwingUtilities.EventDispatchThread)
			{
			  base.Title = value;
			}
			else
			{
			  SwingUtilities.invokeLater(new SetTitle(this, value));
			}
		  }
	  }

	  public virtual void close()
	  {
		  Visible = false;
	  }

	  public virtual void propertyChange(PropertyChangeEvent paramPropertyChangeEvent)
	  {
	  }

	  public virtual void superSetVisible(bool paramBoolean)
	  {
		base.Visible = paramBoolean;
		if (!paramBoolean && this.previousFocus != null && this.previousFocus.Visible)
		{
		  this.t = new Timer(500, new ActionListenerAnonymousInnerClass(this));
		  this.t.Repeats = false;
		  this.t.start();
		}
	  }

	  private class ActionListenerAnonymousInnerClass : ActionListener
	  {
		  private readonly UIProgressBarDialog outerInstance;

		  public ActionListenerAnonymousInnerClass(UIProgressBarDialog outerInstance) : base(outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public void actionPerformed(ActionEvent param1ActionEvent)
		  {
			outerInstance.t.stop();
			SwingUtilities.invokeLater(() =>
			{
			  outerInstance.previousFocus.requestFocus();
			});
		  }
	  }

//JAVA TO C# CONVERTER WARNING: 'final' parameters are ignored unless the option to convert to C# 7.2 'in' parameters is selected:
//ORIGINAL LINE: public void setVisibleLater(final boolean visible)
	  public virtual bool VisibleLater
	  {
		  set
		  {
			  SwingUtilities.invokeLater(() =>
			  {
			  UIProgressBarDialog.this.superSetVisible(value);
			  });
		  }
	  }

//JAVA TO C# CONVERTER WARNING: 'final' parameters are ignored unless the option to convert to C# 7.2 'in' parameters is selected:
//ORIGINAL LINE: public void setVisible(final boolean visible)
	  public virtual bool Visible
	  {
		  set
		  {
			if (SwingUtilities.EventDispatchThread)
			{
			  base.Visible = paramBoolean;
			}
			else
			{
			  try
			  {
				SwingUtilities.invokeAndWait(() =>
				{
				  UIProgressBarDialog.this.superSetVisible(value);
				});
			  }
			  catch (InterruptedException interruptedException)
			  {
				Console.WriteLine(interruptedException.ToString());
				Console.Write(interruptedException.StackTrace);
			  }
			  catch (InvocationTargetException invocationTargetException)
			  {
				Console.WriteLine(invocationTargetException.ToString());
				Console.Write(invocationTargetException.StackTrace);
			  }
			}
		  }
	  }

	  public virtual JProgressBar ProgressBar
	  {
		  get
		  {
			  return this.o_progressBar;
		  }
	  }

	  public virtual string getLangText(string paramString)
	  {
		  return paramString;
	  }


	  private class ForceTotalTimes : ThreadStart
	  {
		  private readonly UIProgressBarDialog outerInstance;

		internal int total;

		public ForceTotalTimes(UIProgressBarDialog outerInstance, int param1Int)
		{
			this.outerInstance = outerInstance;
			this.total = param1Int;
		}

		public virtual void run()
		{
			outerInstance.forceTotalTimes(this.total);
		}
	  }

	  private class SetTotalTimes : ThreadStart
	  {
		  private readonly UIProgressBarDialog outerInstance;

		internal int total;

		public SetTotalTimes(UIProgressBarDialog outerInstance, int param1Int)
		{
			this.outerInstance = outerInstance;
			this.total = param1Int;
		}

		public virtual void run()
		{
			outerInstance.TotalTimes = this.total;
		}
	  }

	  private class SetIndeterminate : ThreadStart
	  {
		  private readonly UIProgressBarDialog outerInstance;

		internal bool inderterminate;

		public SetIndeterminate(UIProgressBarDialog outerInstance, bool param1Boolean)
		{
			this.outerInstance = outerInstance;
			this.inderterminate = param1Boolean;
		}

		public virtual void run()
		{
			outerInstance.Indeterminate = this.inderterminate;
		}
	  }

	  private class SetTitle : ThreadStart
	  {
		  private readonly UIProgressBarDialog outerInstance;

		internal string title;

		public SetTitle(UIProgressBarDialog outerInstance, string param1String)
		{
			this.outerInstance = outerInstance;
			this.title = param1String;
		}

		public virtual void run()
		{
			outerInstance.Title = this.title;
		}
	  }

	  private class SetProgress : ThreadStart
	  {
		  private readonly UIProgressBarDialog outerInstance;

		internal string notes;

		internal int times;

		public SetProgress(UIProgressBarDialog outerInstance, string param1String, int param1Int)
		{
			this.outerInstance = outerInstance;
		  this.notes = param1String;
		  this.times = param1Int;
		}

		public virtual void run()
		{
			outerInstance.setProgress(this.notes, this.times);
		}
	  }

	  private class IncrementProgress : ThreadStart
	  {
		  private readonly UIProgressBarDialog outerInstance;

		internal string notes;

		internal int times;

		public IncrementProgress(UIProgressBarDialog outerInstance, string param1String, int param1Int)
		{
			this.outerInstance = outerInstance;
		  this.notes = param1String;
		  this.times = param1Int;
		}

		public IncrementProgress(UIProgressBarDialog outerInstance, int param1Int)
		{
			this.outerInstance = outerInstance;
		  this.notes = null;
		  this.times = param1Int;
		}

		public virtual void run()
		{
		  if (!string.ReferenceEquals(this.notes, null))
		  {
			outerInstance.incrementProgress(this.notes, this.times);
		  }
		  else
		  {
			outerInstance.incrementProgress(this.times);
		  }
		}
	  }

	  public class CancelAddActionLinstener : ActionListener
	  {
		  private readonly UIProgressBarDialog outerInstance;

		  public CancelAddActionLinstener(UIProgressBarDialog outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		internal bool canceled;

		public virtual void actionPerformed(ActionEvent param1ActionEvent)
		{
		  if (param1ActionEvent.ActionCommand.Equals("Cancel"))
		  {
			this.canceled = true;
			outerInstance.Indeterminate = true;
			outerInstance.Progress = "Canceling...";
		  }
		}

		public virtual bool Canceled
		{
			get
			{
				return this.canceled;
			}
			set
			{
				this.canceled = value;
			}
		}

	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\ui\UIProgressBarDialog.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}