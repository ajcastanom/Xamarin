package md52d70045b1870e0bd8d7bc8f4a55a3a71;


public class ContactDetailActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("AccenturePeople.android.Implementations.ContactDetailActivity, AccenturePeople.android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ContactDetailActivity.class, __md_methods);
	}


	public ContactDetailActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ContactDetailActivity.class)
			mono.android.TypeManager.Activate ("AccenturePeople.android.Implementations.ContactDetailActivity, AccenturePeople.android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


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
