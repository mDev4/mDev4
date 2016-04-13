package md58b3f7bc9a40e61a5e3696d404350dc37;


public class StudentModel
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Shared.Database.Models.StudentModel, KVS_android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", StudentModel.class, __md_methods);
	}


	public StudentModel () throws java.lang.Throwable
	{
		super ();
		if (getClass () == StudentModel.class)
			mono.android.TypeManager.Activate ("Shared.Database.Models.StudentModel, KVS_android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public StudentModel (java.lang.String p0, java.lang.String p1) throws java.lang.Throwable
	{
		super ();
		if (getClass () == StudentModel.class)
			mono.android.TypeManager.Activate ("Shared.Database.Models.StudentModel, KVS_android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}

	java.util.ArrayList refList;
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
