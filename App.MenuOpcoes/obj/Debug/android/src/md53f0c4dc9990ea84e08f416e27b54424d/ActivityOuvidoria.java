package md53f0c4dc9990ea84e08f416e27b54424d;


public class ActivityOuvidoria
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_btnHomeClicked_Click:(Landroid/view/View;)V:__export__\n" +
			"n_TelOuvidoriaClicked_Click:(Landroid/view/View;)V:__export__\n" +
			"n_TelOuvidoria2Clicked_Click:(Landroid/view/View;)V:__export__\n" +
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_dispatchKeyEvent:(Landroid/view/KeyEvent;)Z:GetDispatchKeyEvent_Landroid_view_KeyEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("AppEspiaSo.ActivityOuvidoria, AppEspiaSo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ActivityOuvidoria.class, __md_methods);
	}


	public ActivityOuvidoria () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ActivityOuvidoria.class)
			mono.android.TypeManager.Activate ("AppEspiaSo.ActivityOuvidoria, AppEspiaSo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void btnHomeClicked (android.view.View p0)
	{
		n_btnHomeClicked_Click (p0);
	}

	private native void n_btnHomeClicked_Click (android.view.View p0);


	public void TelOuvidoriaClicked (android.view.View p0)
	{
		n_TelOuvidoriaClicked_Click (p0);
	}

	private native void n_TelOuvidoriaClicked_Click (android.view.View p0);


	public void TelOuvidoria2Clicked (android.view.View p0)
	{
		n_TelOuvidoria2Clicked_Click (p0);
	}

	private native void n_TelOuvidoria2Clicked_Click (android.view.View p0);


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public boolean dispatchKeyEvent (android.view.KeyEvent p0)
	{
		return n_dispatchKeyEvent (p0);
	}

	private native boolean n_dispatchKeyEvent (android.view.KeyEvent p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
