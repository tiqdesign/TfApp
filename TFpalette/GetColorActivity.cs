using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Stream = System.IO.Stream;

namespace TFpalette
{
    [Activity(Label = "GetColorActivity")]
    public class GetColorActivity : Activity , View.IOnTouchListener
    {
        ClipboardManager cpManager;
        ClipData cpData;
        private ImageView img1;
        private TextView txt_hex;
        private TextView txt_rgb;
        private Bitmap bitmap1;
        private ImageButton btncopy;
        private ImageButton btn_add;
        private Button btnget;
        private Android.Graphics.Color c1;
        private LinearLayout colorpanel;
        private string renk1;
        private string username;
       



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.passGetColor);
            img1 = FindViewById<ImageView>(Resource.Id.ımageView1);


            if (Intent.GetStringExtra("url") == null)
            {
              
            }
            else
            {
                string url1 = Intent.GetStringExtra("url");
                bitmap1 = GetImageBitmapFromUrl(url1);
                img1.SetImageBitmap(bitmap1);
            }
            
            txt_hex = FindViewById<TextView>(Resource.Id.txt_hex);
            txt_rgb = FindViewById<TextView>(Resource.Id.txt_rgb);
            btncopy = FindViewById<ImageButton>(Resource.Id.btn_copy);
            btnget = FindViewById<Button>(Resource.Id.btn_get);
            btn_add = FindViewById<ImageButton>(Resource.Id.btn_add);
            colorpanel = FindViewById<LinearLayout>(Resource.Id.linearLayout4);

            btncopy.Click +=BtncopyOnClick;
            btn_add.Click+=BtnAddOnClick;
            btnget.Click += BtngetOnClick;
            cpManager = (ClipboardManager)GetSystemService(ClipboardService);

            img1.SetOnTouchListener(this);
            
        }

        private void BtnAddOnClick(object sender, EventArgs e)
        {
           
            Toast.MakeText(Application.Context,"Eklendi" , ToastLength.Short).Show();
        }

        public bool OnTouch(View v, MotionEvent e)
        {
            if (bitmap1 == null)
            {
                return true;
            }
            else
            {
                int x = (int)e.GetX();
                int y = (int)e.GetY();


           
                if (x < 0 || y < 0)
                {
                    return true;
                }
                else
                {
                    c1 = new Android.Graphics.Color(bitmap1.GetPixel(x, y));
                    renk1 = c1.R.ToString("X2") + c1.G.ToString("X2") + c1.B.ToString("X2");

                    txt_hex.Text = "Hex Code: #" + renk1;
                    txt_rgb.Text = "R: " + c1.R.ToString()
                                         + " G: " + c1.G.ToString() + " B: " + c1.B.ToString();

                    var a = Color.ParseColor("#" + renk1);
                    colorpanel.SetBackgroundColor(a);
                }
            }
            return true;
        }

        private void BtngetOnClick(object sender, EventArgs e)
        {
            
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);
            this.StartActivityForResult(Intent.CreateChooser(intent, "Select a Photo"), 0);
        }

        private void BtncopyOnClick(object sender, EventArgs e)
        {

            string text = txt_hex.Text;
            cpData = ClipData.NewPlainText("text", text);
            cpManager.PrimaryClip = cpData;
            Toast.MakeText(this, "Kopyalandı", ToastLength.Short).Show();
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            
            if (resultCode == Result.Ok)
            {
                //gelen fotou bitmap1 e kaydet
                Stream st = ContentResolver.OpenInputStream(data.Data);
                bitmap1 = BitmapFactory.DecodeStream(st);
                bitmap1 = Bitmap.CreateScaledBitmap(
                bitmap1, bitmap1.Width, bitmap1.Height, false);
                img1.SetImageBitmap(bitmap1);
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