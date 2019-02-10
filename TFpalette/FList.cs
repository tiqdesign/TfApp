using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;

namespace TFpalette
{
   public class FList
    {
        public string[] array2 = new string[10];

        public  int i = 0;
        

        public string[] liste = new string[10];
        
      

        public IEnumerable<string> ListRef
        {
            get
            {
                return liste;
            }
        }

       
    }

    

}