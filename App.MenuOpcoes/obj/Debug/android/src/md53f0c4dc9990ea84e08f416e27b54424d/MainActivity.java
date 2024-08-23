package md53f0c4dc9990ea84e08f416e27b54424d;


public class MainActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_btnBusca_Click:(Landroid/view/View;)V:__export__\n" +
			"n_button_Click:(Landroid/view/View;)V:__export__\n" +
			"n_btnServicos_Click:(Landroid/view/View;)V:__export__\n" +
			"n_btnSaudeClicked_Click:(Landroid/view/View;)V:__export__\n" +
			"n_btnComprasClicked_Click:(Landroid/view/View;)V:__export__\n" +
			"n_btnOuvidoriaClicked_Click:(Landroid/view/View;)V:__export__\n" +
			"n_btnFonesClicked_Click:(Landroid/view/View;)V:__export__\n" +
			"n_btnFavoritosClicked_Click:(Landroid/view/View;)V:__export__\n" +
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_dispatchTouchEvent:(Landroid/view/MotionEvent;)Z:GetDispatchTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_dispatchKeyEvent:(Landroid/view/KeyEvent;)Z:GetDispatchKeyEvent_Landroid_view_KeyEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("AppEspiaSo.MainActivity, AppEspiaSo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MainActivity.class, __md_methods);
	}


	public MainActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MainActivity.class)
			mono.android.TypeManager.Activate ("AppEspiaSo.MainActivity, AppEspiaSo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void btnBuscaClicked (android.view.View p0)
	{
		n_btnBusca_Click (p0);
	}

	private native void n_btnBusca_Click (android.view.View p0);


	public void btnLazerClicked (android.view.View p0)
	{
		n_button_Click (p0);
	}

	private native void n_button_Click (android.view.View p0);


	public void btnServicosClicked (android.view.View p0)
	{
		n_btnServicos_Click (p0);
	}

	private native void n_btnServicos_Click (android.view.View p0);


	public void btnSaudeClicked (android.view.View p0)
	{
		n_btnSaudeClicked_Click (p0);
	}

	private native void n_btnSaudeClicked_Click (android.view.View p0);


	public void btnComprasClicked (android.view.View p0)
	{
		n_btnComprasClicked_Click (p0);
	}

	private native void n_btnComprasClicked_Click (android.view.View p0);


	public void btnOuvidoriaClicked (android.view.View p0)
	{
		n_btnOuvidoriaClicked_Click (p0);
	}

	private native void n_btnOuvidoriaClicked_Click (android.view.View p0);


	public void btnFonesClicked (android.view.View p0)
	{
		n_btnFonesClicked_Click (p0);
	}

	private native void n_btnFonesClicked_Click (android.view.View p0);


	public void btnFavoritosClicked (android.view.View p0)
	{
		n_btnFavoritosClicked_Click (p0);
	}

	private native void n_btnFavoritosClicked_Click (android.view.View p0);


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public boolean dispatchTouchEvent (android.view.MotionEvent p0)
	{
		return n_dispatchTouchEvent (p0);
	}

	private native boolean n_dispatchTouchEvent (android.view.MotionEvent p0);


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
