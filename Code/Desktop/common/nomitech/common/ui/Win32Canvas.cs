using System;

namespace Desktop.common.nomitech.common.ui
{
	using Native = com.sun.jna.Native;
	using Pointer = com.sun.jna.Pointer;
	using W32API = com.sun.jna.examples.win32.W32API;
	using AbstractHwndCanvas = uiinterop.AbstractHwndCanvas;
	using WinForms = uiinterop.winforms.WinForms;

	public class Win32Canvas : AbstractHwndCanvas
	{
		private bool InstanceFieldsInitialized = false;

		private void InitializeInstanceFields()
		{
			resizeAdapter = new ResizeAdapter(this, null);
		}

	  private bool inited = false;

	  private long externalHandle;

	  private Win32SetSizeCallback sizeCallback;

	  private Win32DisplayableCallback displayCallback;

	  private ResizeAdapter resizeAdapter;

	  public Win32Canvas(Win32SetSizeCallback paramWin32SetSizeCallback)
	  {
		  if (!InstanceFieldsInitialized)
		  {
			  InitializeInstanceFields();
			  InstanceFieldsInitialized = true;
		  }
		Background = Color.white;
		this.sizeCallback = paramWin32SetSizeCallback;
	  }

	  public Win32Canvas(Win32SetSizeCallback paramWin32SetSizeCallback, Win32DisplayableCallback paramWin32DisplayableCallback)
	  {
		  if (!InstanceFieldsInitialized)
		  {
			  InitializeInstanceFields();
			  InstanceFieldsInitialized = true;
		  }
		this.sizeCallback = paramWin32SetSizeCallback;
		this.displayCallback = paramWin32DisplayableCallback;
	  }

	  public Win32Canvas(Win32SetSizeCallback paramWin32SetSizeCallback, long paramLong)
	  {
		  if (!InstanceFieldsInitialized)
		  {
			  InitializeInstanceFields();
			  InstanceFieldsInitialized = true;
		  }
		this.externalHandle = paramLong;
		this.sizeCallback = paramWin32SetSizeCallback;
	  }

	  protected internal virtual W32API.HWND ChildHwnd
	  {
		  get
		  {
			if (this.childHwnd == null)
			{
			  this.childHwnd = getExternalHandle();
			}
			return this.childHwnd;
		  }
	  }

	  public virtual W32API.HWND getHandle(long paramLong)
	  {
		  return new W32API.HWND(Pointer.createConstant(paramLong));
	  }

	  public virtual W32API.HWND ThisHandle
	  {
		  get
		  {
			  return getHandle(Native.getComponentID(this));
		  }
	  }

	  public virtual W32API.HWND getExternalHandle()
	  {
		  return getHandle(this.externalHandle);
	  }

	  public virtual Win32DisplayableCallback DisplayCallback
	  {
		  set
		  {
			  this.displayCallback = value;
		  }
	  }

	  public virtual void setExternalHandle(long paramLong)
	  {
		  this.externalHandle = paramLong;
	  }

	  public virtual void addNotify()
	  {
		setSize(1, 1);
		base.addNotify();
		installExternalWindow();
	  }

	  public virtual void removeNotify()
	  {
		setSize(1, 1);
		base.removeNotify();
		uninstallExternalWindow();
		setSize(1, 1);
	  }

	  public virtual void installExternalWindow()
	  {
		try
		{
		  WinForms.invokeLater(() =>
		  {
		  if (Win32Canvas.this.inited)
		  {
			return;
		  }
		  if (Win32Canvas.this.displayCallback != null)
		  {
			Win32Canvas.this.displayCallback.displayed();
		  }
		  if (!Win32Canvas.this.inited)
		  {
			Win32Canvas.this.inited = true;
			Win32Canvas.this.addComponentListener(Win32Canvas.this.resizeAdapter);
		  }
		  });
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
	  }

	  public virtual void uninstallExternalWindow()
	  {
		try
		{
		  WinForms.invokeLater(() =>
		  {
		  if (Win32Canvas.this.displayCallback != null)
		  {
			Win32Canvas.this.displayCallback.hidden();
		  }
		  });
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		if (this.inited)
		{
		  removeComponentListener(this.resizeAdapter);
		  this.inited = false;
		}
	  }

	  private void processComponentResized()
	  {
		if (Initialized)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.awt.Dimension d = getSize();
		  Dimension d = Size;
		  WinForms.invokeLater(() =>
		  {
		  if (Win32Canvas.this.sizeCallback != null)
		  {
			Win32Canvas.this.sizeCallback.setSize(this.val$d.width, this.val$d.height);
		  }
		  });
		}
	  }

	  public virtual bool Initialized
	  {
		  get
		  {
			  return this.inited;
		  }
	  }

	  public virtual void paint(Graphics paramGraphics)
	  {
	  }

	  private class ResizeAdapter : ComponentAdapter
	  {
		  private readonly Win32Canvas outerInstance;

		internal ResizeAdapter(Win32Canvas outerInstance)
		{
			this.outerInstance = outerInstance;
		}

		public virtual void componentResized(ComponentEvent param1ComponentEvent)
		{
			outerInstance.processComponentResized();
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\ui\Win32Canvas.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}