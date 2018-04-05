package md58940e7530d091633a9ba3631f35d6a6a;


public class MainActivity_MyViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("RecycleViewScrolling.MainActivity+MyViewHolder, RecycleViewScrolling, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MainActivity_MyViewHolder.class, __md_methods);
	}


	public MainActivity_MyViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == MainActivity_MyViewHolder.class)
			mono.android.TypeManager.Activate ("RecycleViewScrolling.MainActivity+MyViewHolder, RecycleViewScrolling, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

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
