using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using System.Collections.Generic;
using Android.Content;

namespace RecycleViewScrolling
{
    [Activity(Label = "RecycleViewScrolling", MainLauncher = true)]
    public class MainActivity : Activity
    {
        RecyclerView mrv;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            List<List<string>> mList = new List<List<string>>();

            List<string> l1 = new List<string>();
            List<string> l2 = new List<string>();
            List<string> l3 = new List<string>();
            List<string> l4 = new List<string>();
            List<string> l5 = new List<string>();

            l1.Add("A"); l1.Add("B"); l1.Add("C"); l1.Add("D"); l1.Add("E"); l1.Add("F"); l1.Add("A"); l1.Add("B"); l1.Add("C"); l1.Add("D"); l1.Add("E"); l1.Add("F");
            l2.Add("A"); l2.Add("B"); l2.Add("C"); l2.Add("D"); l2.Add("E"); l2.Add("F"); l2.Add("A"); l2.Add("B"); l2.Add("C"); l2.Add("D"); l2.Add("E"); l2.Add("F");
            l3.Add("A"); l3.Add("B"); l3.Add("C"); l3.Add("D"); l3.Add("E"); l3.Add("F"); l3.Add("A"); l3.Add("B"); l3.Add("C"); l3.Add("D"); l3.Add("E"); l3.Add("F");
            l4.Add("A"); l4.Add("B"); l4.Add("C"); l4.Add("D"); l4.Add("E"); l4.Add("F"); l4.Add("A"); l4.Add("B"); l4.Add("C"); l4.Add("D"); l4.Add("E"); l4.Add("F");
            l5.Add("A"); l5.Add("B"); l5.Add("C"); l5.Add("D"); l5.Add("E"); l5.Add("F"); l5.Add("A"); l5.Add("B"); l5.Add("C"); l5.Add("D"); l5.Add("E"); l5.Add("F");

            mList.Add(l1); mList.Add(l2); mList.Add(l3); mList.Add(l4); mList.Add(l5);

            mrv = FindViewById<RecyclerView>(Resource.Id.rv);
            mrv.SetAdapter(new MyAdapter(mList,this));
            mrv.SetLayoutManager(new LinearLayoutManager(this));
        }

        //------------------------------------------------------Item-----------------------------------------------------------
       public class MyViewHolder : RecyclerView.ViewHolder
        {
            public RecyclerView rv;
            public MyViewHolder(View itemView) : base(itemView)
            {
                rv = itemView.FindViewById<RecyclerView>(Resource.Id.item_rv);
            }
        }
      public  class MyAdapter : RecyclerView.Adapter
        {
            List<List<string>> mList;
            Context mContext;
            public MyAdapter(List<List<string>> list,Context context) {
                this.mList = list;
                this.mContext = context;
            }
            public override int ItemCount {
                get {
                    return mList.Count;
                }
            }

            public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                MyViewHolder myViewHolder = holder as MyViewHolder;
                LinearLayoutManager linearLayoutManager = new LinearLayoutManager(mContext);
                linearLayoutManager.Orientation = LinearLayoutManager.Horizontal;
                myViewHolder.rv.SetLayoutManager(linearLayoutManager);
                myViewHolder.rv.SetAdapter(new MyItemAdapter(mList[position],mContext));
            }

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                return new MyViewHolder(LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_layout, null));
            }
        }

        //------------------------------------------------------Item_Item-----------------------------------------------------------
        public class MyItemViewHolder : RecyclerView.ViewHolder
        {
            public TextView tv;
            public MyItemViewHolder(View itemView) : base(itemView)
            {
                tv = itemView.FindViewById<TextView>(Resource.Id.item_item_tv);
            }
        }
        public class MyItemAdapter : RecyclerView.Adapter
        {
            List<string> mList;
            Context mContext;
            public MyItemAdapter(List<string> list, Context context)
            {
                this.mList = list;
                this.mContext = context;
            }
            public override int ItemCount
            {
                get
                {
                    return mList.Count;
                }
            }

            public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                MyItemViewHolder myItemViewHolder = holder as MyItemViewHolder;
                myItemViewHolder.tv.Text=mList[position];


            }

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                return new MyItemViewHolder(LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_item_layout, null));
            }
        }
    }
    
}

