using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TFpalette
{
    public class GetText : Android.Support.V4.App.Fragment
    {
        private Button btn_openUrl;
        private Button btn_passUrl;
        private Button btn_galery;
        private EditText txt_url;
       

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View v = inflater.Inflate(Resource.Layout.GetTextMain, container, false);
            
            btn_openUrl = v.FindViewById<Button>(Resource.Id.btn_openUrl);
            btn_passUrl = v.FindViewById<Button>(Resource.Id.btn_getUrl);
            txt_url = v.FindViewById<EditText>(Resource.Id.txt_url);
            btn_galery = v.FindViewById<Button>(Resource.Id.btn_openGalery);
            btn_openUrl.Click+= BtnOpenUrlOnClick;
            btn_passUrl.Click+=BtnPassUrlOnClick;
            btn_galery.Click+= BtnGaleryOnClick;
            return v;
        }

        private void BtnPassUrlOnClick(object sender, EventArgs e)
        {
            Intent intent = new Intent(Application.Context, typeof(GetTextActivity));
            intent.PutExtra("url", txt_url.Text);
            base.StartActivity(intent);
        }

        private void BtnGaleryOnClick(object sender, EventArgs e)
        {
            Intent intent = new Intent(Application.Context, typeof(GetTextActivity));
            base.StartActivity(intent);

        }

        private void BtnOpenUrlOnClick(object sender, EventArgs e)
        {
            btn_passUrl.Visibility = ViewStates.Visible;
            txt_url.Visibility = ViewStates.Visible;
        }
    }
}