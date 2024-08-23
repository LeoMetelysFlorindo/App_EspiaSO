package md53f0c4dc9990ea84e08f416e27b54424d;


public class ActivityConhecaaALEAM
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_btnHomeClicked_Click:(Landroid/view/View;)V:__export__\n" +
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("AppEspiaSo.ActivityConhecaaALEAM, AppEspiaSo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ActivityConhecaaALEAM.class, __md_methods);
	}


	public ActivityConhecaaALEAM () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ActivityConhecaaALEAM.class)
			mono.android.TypeManager.Activate ("AppEspiaSo.ActivityConhecaaALEAM, AppEspiaSo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void btnHomeClicked (android.view.View p0)
	{
		n_btnHomeClicked_Click (p0);
	}

	private native void n_btnHomeClicked_Click (android.view.View p0);


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
