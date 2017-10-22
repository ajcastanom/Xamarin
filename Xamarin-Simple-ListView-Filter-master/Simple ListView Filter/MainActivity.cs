using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections;

namespace Simple_ListView_Filter
{
    [Activity(Label = "Simple ListViewFilter", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        private SearchView _sv;
        private ListView _lv;
        private ArrayList techpreneurs;
        private ArrayAdapter _adapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //INITIALIZE VIEWS
            _lv = FindViewById<ListView>(Resource.Id.lv);
            _sv = FindViewById<SearchView>(Resource.Id.sv);

            //ADA DATA
            addData();

            //ADAPTER
            _adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, techpreneurs);
            _lv.Adapter = _adapter;

            _sv.QueryTextChange += _sv_QueryTextChange;
            _lv.ItemClick += _lv_ItemClick;

        }

        void _lv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this,_adapter.GetItem(e.Position).ToString(),ToastLength.Short).Show();
        }

        void _sv_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
                //FILTER OR SEARCH
            _adapter.Filter.InvokeFilter(e.NewText);
        }

        private void addData()
        {
            techpreneurs = new ArrayList();
            techpreneurs.Add("John Doe");
            techpreneurs.Add("Bill Gates");
            techpreneurs.Add("Steve Jobs");
            techpreneurs.Add("Ben Silbermann");
            techpreneurs.Add("Kevin Systrom");
            techpreneurs.Add("Brian Chesky");
            techpreneurs.Add("Mark Zuckerbag");
            techpreneurs.Add("Jack Dorsey");
            techpreneurs.Add("Elon Musk");
            techpreneurs.Add("Larry Page");
            techpreneurs.Add("Sergey Brin");
        }



    }
}

