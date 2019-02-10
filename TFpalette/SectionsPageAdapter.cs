using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;
using String = Java.Lang.String;

namespace TFpalette
{
    class SectionsPageAdapter : FragmentPagerAdapter
    {
        private List<Fragment> FragmentList = new List<Fragment>();
        private List<String> TitleList = new List<String>();

        public void AddFragment(Fragment fr, String title)
        {
            FragmentList.Add(fr);
            TitleList.Add(title);
        }

        public SectionsPageAdapter(FragmentManager fm) : base(fm) { }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return TitleList[position];
        }

        public override int Count => FragmentList.Count;

        public override Fragment GetItem(int position)
        {
            return FragmentList[position];
        }
    }
}