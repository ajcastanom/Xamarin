package md5068bdeccc63c92934640e909879101b7;


public class Planet
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.os.Parcelable
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_InititalizeCreator:()Lmd501009ef43ffce7a1ac4e9731f3e19080/PlanetCreator;:__export__\n" +
			"n_describeContents:()I:GetDescribeContentsHandler:Android.OS.IParcelableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_writeToParcel:(Landroid/os/Parcel;I)V:GetWriteToParcel_Landroid_os_Parcel_IHandler:Android.OS.IParcelableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Tables.android.Models.Planet, Tables.android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Planet.class, __md_methods);
	}


	public Planet () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Planet.class)
			mono.android.TypeManager.Activate ("Tables.android.Models.Planet, Tables.android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public Planet (java.lang.String p0, java.lang.String p1) throws java.lang.Throwable
	{
		super ();
		if (getClass () == Planet.class)
			mono.android.TypeManager.Activate ("Tables.android.Models.Planet, Tables.android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}

	public Planet (java.lang.String p0, java.lang.String p1, java.lang.String p2) throws java.lang.Throwable
	{
		super ();
		if (getClass () == Planet.class)
			mono.android.TypeManager.Activate ("Tables.android.Models.Planet, Tables.android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public static md501009ef43ffce7a1ac4e9731f3e19080.PlanetCreator CREATOR = InititalizeCreator ();

	public static md501009ef43ffce7a1ac4e9731f3e19080.PlanetCreator InititalizeCreator ()
	{
		return n_InititalizeCreator ();
	}

	private static native md501009ef43ffce7a1ac4e9731f3e19080.PlanetCreator n_InititalizeCreator ();


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
