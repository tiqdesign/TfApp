using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;

namespace TFpalette
{
    [Activity(Label = "Login",ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize | Android.Content.PM.ConfigChanges.Orientation)]
    public class Login : AppCompatActivity
    {
        private Button loginButton, registerButton;
        private EditText textUser, textPassword;
        string values1, values2;
        string userName, userName2, passWord, passWord2;
        ISharedPreferencesEditor editor;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.login);

            //Shared Preferences
            ISharedPreferences shared = Application.Context.GetSharedPreferences("USER_DATA", FileCreationMode.Private);
            
            values1 = shared.GetString("username", null);
            values2 = shared.GetString("password", null);

            editor = shared.Edit();
            editor.PutString("username", values1);

            userName = shared.GetString("user1", "user");
            passWord = shared.GetString("password1", "12345");
            userName2 = shared.GetString("user2", "pinkpanther");
            passWord2 = shared.GetString("password2", "1234");
            registerButton = FindViewById<Button>(Resource.Id.btn_register);
            loginButton = FindViewById<Button>(Resource.Id.btn_login);
            textUser = FindViewById<EditText>(Resource.Id.txt_user);
            textPassword = FindViewById<EditText>(Resource.Id.txt_password);

            loginButton.Click += Login_Button;
            registerButton.Click += Register_Button;

        }
        private void Login_Button(object sender, System.EventArgs e)
        {
            if (textUser.Text.Equals(userName) && textPassword.Text.Equals(passWord) || textUser.Text.Equals(userName2) && textPassword.Text.Equals(passWord2) || textUser.Text.Equals(values1) && textPassword.Text.Equals(values2))
            {
                var mapIntent = new Intent(this, typeof(MainActivity));
                StartActivity(mapIntent);
            }
            else
            {
                Toast.MakeText(this, "Username or password wrong", ToastLength.Long).Show();
            }
        }
        private void Register_Button(object sender, System.EventArgs e)
        {
            StartActivity(typeof(Register));
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var inflater = MenuInflater;
            inflater.Inflate(Resource.Menu.about,menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem menuItem)
        {
            int id = menuItem.ItemId;
            if (id==Resource.Id.action_about)
            {
                Intent intent = new Intent(Application.Context, typeof(About));
                base.StartActivity(intent);
            }
            return true;
        }
       
    }
}
    
