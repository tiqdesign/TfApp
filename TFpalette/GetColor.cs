using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using System.IO;
using Android.Content;
using Android.Provider;
using Android.Widget;
using Java.IO;
using Newtonsoft.Json;
using Stream = System.IO.Stream;
using Uri = Android.Net.Uri;

namespace TFpalette
{
    public class GetColor : Android.Support.V4.App.Fragment
    {

        private Button btn_openUrl;
        private Button btn_passUrl;
        private Button btn_galery;
        private EditText txt_url;
       

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.GetColorMain, container, false);
            btn_openUrl = v.FindViewById<Button>(Resource.Id.btn_fromUrl);
            btn_passUrl = v.FindViewById<Button>(Resource.Id.btn_getUrl);
            txt_url = v.FindViewById<EditText>(Resource.Id.txt_url);
            btn_galery = v.FindViewById<Button>(Resource.Id.btn_fromGalery);
            btn_passUrl.Click+=BtnPassUrlOnClick;
            btn_galery.Click +=BtnGaleryOnClick;
            btn_openUrl.Click += BtnOpenUrlOnClick;
            return v;
            
        }
    
        private void BtnPassUrlOnClick(object sender, EventArgs e)
        {

            Intent intent = new Intent(Application.Context, typeof(GetColorActivity));
            intent.PutExtra("url", txt_url.Text);
            base.StartActivity(intent);
        }

        private void BtnGaleryOnClick(object sender, EventArgs e)
        {
            Intent intent = new Intent(Application.Context, typeof(GetColorActivity));
            base.StartActivity(intent);
            
        }
        
        private void BtnOpenUrlOnClick(object sender, EventArgs e)
        {
            btn_passUrl.Visibility = ViewStates.Visible;
            txt_url.Visibility = ViewStates.Visible;
        }
        
    }
}