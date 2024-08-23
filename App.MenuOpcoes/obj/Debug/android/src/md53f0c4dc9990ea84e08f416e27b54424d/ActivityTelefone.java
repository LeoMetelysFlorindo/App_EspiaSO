package md53f0c4dc9990ea84e08f416e27b54424d;


public class ActivityTelefone
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_btnHomeClicked_Click:(Landroid/view/View;)V:__export__\n" +
			"n_btnPoliciaClicked_Click:(Landroid/view/View;)V:__export__\n" +
			"n_btnDireitoClicked_Click:(Landroid/view/View;)V:__export__\n" +
			"n_btndenunciaClicked_Click:(Landroid/view/View;)V:__export__\n" +
			"n_btnCivilClicked_Click:(Landroid/view/View;)V:__export__\n" +
			"n_btnSamuClicked_Click:(Landroid/view/View;)V:__export__\n" +
			"n_btnBombeiroClicked_Click:(Landroid/view/View;)V:__export__\n" +
			"n_btnTransitoClicked_Click:(Landroid/view/View;)V:__export__\n" +
			"n_btnDefesaCivilClicked_Click:(Landroid/view/View;)V:__export__\n" +
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("AppEspiaSo.ActivityTelefone, AppEspiaSo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ActivityTelefone.class, __md_methods);
	}


	public ActivityTelefone () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ActivityTelefone.class)
			mono.android.TypeManager.Activate ("AppEspiaSo.ActivityTelefone, AppEspiaSo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void btnHomeClicked (android.view.View p0)
	{
		n_btnHomeClicked_Click (p0);
	}

	private native void n_btnHomeClicked_Click (android.view.View p0);


	public void btnPoliciaClicked (android.view.View p0)
	{
		n_btnPoliciaClicked_Click (p0);
	}

	private native void n_btnPoliciaClicked_Click (android.view.View p0);


	public void btnDireitoClicked (android.view.View p0)
	{
		n_btnDireitoClicked_Click (p0);
	}

	private native void n_btnDireitoClicked_Click (android.view.View p0);


	public void btndenunciaClicked (android.view.View p0)
	{
		n_btndenunciaClicked_Click (p0);
	}

	private native void n_btndenunciaClicked_Click (android.view.View p0);


	public void btnCivilClicked (android.view.View p0)
	{
		n_btnCivilClicked_Click (p0);
	}

	private native void n_btnCivilClicked_Click (android.view.View p0);


	public void btnSamuClicked (android.view.View p0)
	{
		n_btnSamuClicked_Click (p0);
	}

	private native void n_btnSamuClicked_Click (android.view.View p0);


	public void btnBombeiroClicked (android.view.View p0)
	{
		n_btnBombeiroClicked_Click (p0);
	}

	private native void n_btnBombeiroClicked_Click (android.view.View p0);


	public void btnTransitoClicked (android.view.View p0)
	{
		n_btnTransitoClicked_Click (p0);
	}

	private native void n_btnTransitoClicked_Click (android.view.View p0);


	public void btnDefesaCivilClicked (android.view.View p0)
	{
		n_btnDefesaCivilClicked_Click (p0);
	}

	private native void n_btnDefesaCivilClicked_Click (android.view.View p0);


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
