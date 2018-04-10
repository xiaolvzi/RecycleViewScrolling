using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using System.Collections.Generic;
using Android.Content;
using static RecycleViewScrolling.MainActivity.MyItemAdapter;

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

            List<string> l1 = new List<string>();

            l1.Add("A"); l1.Add("B"); l1.Add("C"); l1.Add("D"); l1.Add("E"); l1.Add("F"); l1.Add("A"); l1.Add("B"); l1.Add("C"); l1.Add("D"); l1.Add("E"); l1.Add("F");
            
            mrv = FindViewById<RecyclerView>(Resource.Id.rv);
            MyItemAdapter adapter = new MyItemAdapter(l1, this);
            mrv.SetAdapter(adapter);
            
            mrv.SetLayoutManager(new LinearLayoutManager(this));
        }

 
        //------------------------------------------------------Item_Item-----------------------------------------------------------
        public class MyItemViewHolder : RecyclerView.ViewHolder,View.IOnClickListener
        {
            IMyViewHolderClicks mListener;
           public TextView tv1,tv2;
           public RelativeLayout ll_container;
            public MyItemViewHolder(View itemView, IMyViewHolderClicks listener) : base(itemView)
            {
                mListener = listener;
                tv1 = itemView.FindViewById<TextView>(Resource.Id.item_item_tv1);
                tv2 = itemView.FindViewById<TextView>(Resource.Id.item_item_tv2);
                ll_container = itemView.FindViewById<RelativeLayout>(Resource.Id.ll_container);
                tv1.SetOnClickListener(this);
                tv2.SetOnClickListener(this);
                ll_container.SetOnClickListener(this);
            }

            public void OnClick(View v)
            {
                switch (v.Id) {
                    case Resource.Id.item_item_tv1:
                        mListener.onTv1Click();
                        break;
                    case Resource.Id.item_item_tv2:
                        mListener.onTv2Click();
                        break;
                    case Resource.Id.ll_container:
                        mListener.onItemClick(ll_container);
                        break;
                }


            }
        }
        public class MyItemAdapter : RecyclerView.Adapter, IMyViewHolderClicks
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
                myItemViewHolder.tv1.Text=mList[position];
                myItemViewHolder.tv2.Text = "tv2";

                myItemViewHolder.ll_container.Tag = position;
            }

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_item_layout, null);
                return new MyItemViewHolder(view,this);
            }


            public void onItemClick(View view)
            {
                Toast.MakeText(mContext, view.Tag+"", ToastLength.Short).Show();
            }

            public void onTv1Click()
            {
                Toast.MakeText(mContext, "tv1", ToastLength.Short).Show();
            }

            public void onTv2Click()
            {
                Toast.MakeText(mContext, "tv2", ToastLength.Short).Show();
            }
        }

        public interface IMyViewHolderClicks
        {
            //itemView click event 
             void onItemClick(View view);
            //tv1 click event
             void onTv1Click();
            //tv2 click event
            void onTv2Click();
        }
    }
    
}

