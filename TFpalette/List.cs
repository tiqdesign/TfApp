using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TFpalette
{
    [Activity(Label = "List")]
    public class List : ListActivity
    {
        private static readonly string[] colors = new String[] { "Hex Code: #541879" , "Hex Code: #543279" , "Hex Code: #547679" , "Hex Code: #54479" , "Hex Code: #694189" , "Hex Code: #511879" , "Hex Code: #596879" };


        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

           
            ListAdapter = new ArrayAdapter<string>(ApplicationContext,Resource.Layout.userList,Resource.Id.textView1,colors);

            ListView.TextFilterEnabled = true;

        }
        
}
}