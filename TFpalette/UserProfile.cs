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
    public class UserProfile : Android.Support.V4.App.Fragment
    {
        private Button btn_logout;
        private Button btn_list;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.Profile, container, false);
            btn_logout = v.FindViewById<Button>(Resource.Id.btn_logout);
            btn_list = v.FindViewById<Button>(Resource.Id.btn_favlist);
            btn_logout.Click+=BtnLogoutOnClick;
            btn_list.Click+= BtnListOnClick;
            return v;
        }

        private void BtnListOnClick(object sender, EventArgs e)
        {
            Intent intent = new Intent(Application.Context, typeof(List));
            base.StartActivity(intent);
        }

        private void BtnLogoutOnClick(object sender, EventArgs e)
        {
            Intent intent = new Intent(Application.Context, typeof(Login));
            base.StartActivity(intent);
        }
    }
}