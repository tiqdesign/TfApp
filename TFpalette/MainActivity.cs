using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Widget;
using System;
using Android.Content;
using Android.Support.V4.App;
using Fragment = Android.App.Fragment;

namespace TFpalette
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        private SectionsPageAdapter mainSection;
        private ViewPager mainViewPager;
        private string user;
        ISharedPreferences shared;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            mainSection = new SectionsPageAdapter(SupportFragmentManager);
            mainViewPager = FindViewById<ViewPager>(Resource.Id.container);
            setViewPager(mainViewPager);

            TabLayout tbLayout = FindViewById<TabLayout>(Resource.Id.tabs);
            tbLayout.SetupWithViewPager(mainViewPager);

            shared = Application.Context.GetSharedPreferences("USER_DATA", FileCreationMode.Private);
            user = shared.GetString("username", null);

        }

        private void setViewPager(ViewPager vp)
        {
            SectionsPageAdapter adapter = new SectionsPageAdapter(SupportFragmentManager);
            adapter.AddFragment(new GetColor(),new Java.Lang.String("Get Color"));
            adapter.AddFragment(new GetText(), new Java.Lang.String("Get Text"));
            adapter.AddFragment(new UserProfile(), new Java.Lang.String("Profile"));
            vp.Adapter = adapter;
        }
    }
}