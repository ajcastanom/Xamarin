package md5d655cebe5736f400ae29bade456d34a5;


public class Contact
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.os.Parcelable
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_InititalizeCreator:()Lmd52637ed11898709c567513ae89dd5579e/ContactCreator;:__export__\n" +
			"n_describeContents:()I:GetDescribeContentsHandler:Android.OS.IParcelableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_writeToParcel:(Landroid/os/Parcel;I)V:GetWriteToParcel_Landroid_os_Parcel_IHandler:Android.OS.IParcelableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("AccenturePeople.android.Models.Contact, AccenturePeople.android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Contact.class, __md_methods);
	}


	public Contact () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Contact.class)
			mono.android.TypeManager.Activate ("AccenturePeople.android.Models.Contact, AccenturePeople.android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public Contact (java.lang.String p0, java.lang.String p1) throws java.lang.Throwable
	{
		super ();
		if (getClass () == Contact.class)
			mono.android.TypeManager.Activate ("AccenturePeople.android.Models.Contact, AccenturePeople.android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}

	public Contact (long p0, java.lang.String p1, java.lang.String p2, java.lang.String p3, java.lang.String p4, java.lang.String p5, java.lang.String p6, java.lang.String p7, java.lang.String p8, java.lang.String p9) throws java.lang.Throwable
	{
		super ();
		if (getClass () == Contact.class)
			mono.android.TypeManager.Activate ("AccenturePeople.android.Models.Contact, AccenturePeople.android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.Int64, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2, p3, p4, p5, p6, p7, p8, p9 });
	}


	public static md52637ed11898709c567513ae89dd5579e.ContactCreator CREATOR = InititalizeCreator ();

	public static md52637ed11898709c567513ae89dd5579e.ContactCreator InititalizeCreator ()
	{
		return n_InititalizeCreator ();
	}

	private static native md52637ed11898709c567513ae89dd5579e.ContactCreator n_InititalizeCreator ();


	public int describeContents ()
	{
		return n_describeContents ();
	}

	private native int n_describeContents ();


	public void writeToParcel (android.os.Parcel p0, int p1)
	{
		n_writeToParcel (p0, p1);
	}

	private native void n_writeToParcel (android.os.Parcel p0, int p1);

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
