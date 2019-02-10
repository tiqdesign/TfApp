using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Vision;
using Android.Gms.Vision.Texts;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TFpalette
{
    [Activity(Label = "GetTextActivity")]
    public class GetTextActivity : Activity
    {
        private Button btn_get;
        private Button btn_getText;
        private Button btn_copy;
        private ImageView img;
        private Bitmap bitmap1;
        private EditText txt_text;
        private TextRecognizer txtRecognizer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
           base.OnCreate(savedInstanceState);
           SetContentView(Resource.Layout.getPassText);
            img = FindViewById<ImageView>(Resource.Id.img_text);
            if (Intent.GetStringExtra("url")==null)
            {
              
            }
            else
            {
                string url1=Intent.GetStringExtra("url");
                bitmap1= GetImageBitmapFromUrl(url1);
                img.SetImageBitmap(bitmap1);
            }
            btn_get = FindViewById<Button>(Resource.Id.btn_galery);
            btn_getText = FindViewById<Button>(Resource.Id.btn_text);
            img = FindViewById<ImageView>(Resource.Id.img_text);
            txt_text = FindViewById<EditText>(Resource.Id.text);
            btn_get.Click+=BtnGetOnClick;
            btn_getText.Click+=BtnGetTextOnClick;
        }

        private void BtnGetTextOnClick(object sender, EventArgs e)
        {
            txtRecognizer = new TextRecognizer.Builder(ApplicationContext).Build();
            if (!txtRecognizer.IsOperational)
            {
                txt_text.Text = "Error";
            }
            else
            {
                Frame fr = new Frame.Builder().SetBitmap(bitmap1).Build();
                SparseArray items = txtRecognizer.Detect(fr);
                StringBuilder stBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    stBuilder.Append(item.Value);
                    stBuilder.Append("\n");
                }

                txt_text.Text = stBuilder.ToString();
            }
        }

        private void BtnGetOnClick(object sender, EventArgs e)
        {
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);
            this.StartActivityForResult(Intent.CreateChooser(intent, "Select a Photo"), 0);
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Ok)
            {
                //gelen fotou bitmap1 e kaydet
                Stream st = ContentResolver.OpenInputStream(data.Data);
                bitmap1 = BitmapFactory.DecodeStream(st);
                img.SetImageBitmap(bitmap1);
            }
        }

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
    }
}