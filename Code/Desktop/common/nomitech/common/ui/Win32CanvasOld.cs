using System;
using System.Collections.Generic;
using System.Threading;

namespace Desktop.common.nomitech.common.ui
{
	using Native = com.sun.jna.Native;
	using Pointer = com.sun.jna.Pointer;
	using User32 = com.sun.jna.examples.win32.User32;
	using W32API = com.sun.jna.examples.win32.W32API;
	using WINAPI_test = poc.WINAPI_test;
	using WinForms = uiinterop.winforms.WinForms;

	public class Win32CanvasOld : Canvas
	{
		private bool InstanceFieldsInitialized = false;

		private void InitializeInstanceFields()
		{
			resizeAdapter = new ResizeAdapter(this, null);
		}

	  private bool inited = false;

	  private W32API.HWND hwndOld;

	  private long externalHandle;

	  private Win32SetSizeCallback sizeCallback;

	  private Win32DisplayableCallback displayCallback;

	  private ResizeAdapter resizeAdapter;

	  public Win32CanvasOld(Win32SetSizeCallback paramWin32SetSizeCallback)
	  {
		  if (!InstanceFieldsInitialized)
		  {
			  InitializeInstanceFields();
			  InstanceFieldsInitialized = true;
		  }
		Background = Color.white;
		this.sizeCallback = paramWin32SetSizeCallback;
	  }

	  public Win32CanvasOld(Win32SetSizeCallback paramWin32SetSizeCallback, Win32DisplayableCallback paramWin32DisplayableCallback)
	  {
		  if (!InstanceFieldsInitialized)
		  {
			  InitializeInstanceFields();
			  InstanceFieldsInitialized = true;
		  }
		this.sizeCallback = paramWin32SetSizeCallback;
		this.displayCallback = paramWin32DisplayableCallback;
	  }

	  public Win32CanvasOld(Win32SetSizeCallback paramWin32SetSizeCallback, long paramLong)
	  {
		  if (!InstanceFieldsInitialized)
		  {
			  InitializeInstanceFields();
			  InstanceFieldsInitialized = true;
		  }
		this.externalHandle = paramLong;
		this.sizeCallback = paramWin32SetSizeCallback;
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

	  public virtual void setToParent()
	  {
		this.hwndOld = WINAPI_test.INSTANCE.SetParent(getExternalHandle(), ThisHandle);
		int i = User32.INSTANCE.GetWindowLong(getExternalHandle(), -16);
		i |= 0x50000000;
		User32.INSTANCE.SetWindowLong(getExternalHandle(), -16, i);
		WinForms.registerForeignWindow(ThisHandle);
	  }

	  private void removeFromParent()
	  {
		int i = User32.INSTANCE.GetWindowLong(getExternalHandle(), -16);
		i &= unchecked((int)0xAFFFFFFF);
		User32.INSTANCE.SetWindowLong(getExternalHandle(), -16, i);
		WINAPI_test.INSTANCE.SetParent(getExternalHandle(), this.hwndOld);
		WinForms.unregisterForeignWindow(ThisHandle);
	  }

	  private void processComponentResized()
	  {
		if (this.inited)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.awt.Dimension d = getSize();
		  Dimension d = Size;
		  WinForms.invokeLater(() =>
		  {
		  if (Win32CanvasOld.this.sizeCallback != null)
		  {
			Win32CanvasOld.this.sizeCallback.setSize(this.val$d.width, this.val$d.height);
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

	  public virtual void addNotify()
	  {
		base.addNotify();
		installExternalWindow();
	  }

	  public virtual void removeNotify()
	  {
		uninstallExternalWindow();
		base.removeNotify();
		setSize(1, 1);
	  }

	  public virtual void installExternalWindow()
	  {
		try
		{
		  WinForms.invokeAndWait(() =>
		  {
		  if (Win32CanvasOld.this.inited)
		  {
			return;
		  }
		  if (Win32CanvasOld.this.displayCallback == null)
		  {
			Win32CanvasOld.this.setToParent();
		  }
		  else
		  {
			Win32CanvasOld.this.displayCallback.displayed();
		  }
		  });
		}
		catch (InterruptedException interruptedException)
		{
		  Console.WriteLine(interruptedException.ToString());
		  Console.Write(interruptedException.StackTrace);
		}
		if (!this.inited)
		{
		  this.inited = true;
		  addComponentListener(this.resizeAdapter);
		}
	  }

	  public virtual ThreadStart removeFirst(IList<ThreadStart> paramList)
	  {
		if (paramList.Count == 0)
		{
		  return null;
		}
		ThreadStart runnable = (ThreadStart)paramList[0];
		paramList.RemoveAt(0);
		return runnable;
	  }

	  public virtual ThreadStart addLast(IList<ThreadStart> paramList, ThreadStart paramRunnable)
	  {
		if (paramList.Count == 0)
		{
		  return null;
		}
		paramList.Add(paramRunnable);
		return paramRunnable;
	  }

	  public virtual void uninstallExternalWindow()
	  {
		try
		{
		  WinForms.invokeAndWait(() =>
		  {
		  if (Win32CanvasOld.this.displayCallback == null)
		  {
			Win32CanvasOld.this.removeFromParent();
		  }
		  else
		  {
			Win32CanvasOld.this.displayCallback.hidden();
		  }
		  });
		}
		catch (InterruptedException interruptedException)
		{
		  Console.WriteLine(interruptedException.ToString());
		  Console.Write(interruptedException.StackTrace);
		}
		if (this.inited)
		{
		  removeComponentListener(this.resizeAdapter);
		  this.hwndOld = null;
		  this.inited = false;
		}
	  }

	  public virtual void paint(Graphics paramGraphics)
	  {
		Toolkit.DefaultToolkit.sync();
		if (!this.inited)
		{
		  base.paint(paramGraphics);
		}
	  }

	  private class ResizeAdapter : ComponentAdapter
	  {
		  private readonly Win32CanvasOld outerInstance;

		internal ResizeAdapter(Win32CanvasOld outerInstance)
		{
			this.outerInstance = outerInstance;
		}

		public virtual void componentResized(ComponentEvent param1ComponentEvent)
		{
			outerInstance.processComponentResized();
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\ui\Win32CanvasOld.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}