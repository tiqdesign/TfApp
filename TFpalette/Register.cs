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
    [Activity(Label = "Register")]
    class Register : Activity
    {
        EditText textUser, textPassword;
        Button registerButton;
        string username;
        string password;
        ISharedPreferences shared;
        ISharedPreferencesEditor editor;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.register);
            
            shared = Application.Context.GetSharedPreferences("USER_DATA", FileCreationMode.Private);
            editor = shared.Edit();
            textUser = FindViewById<EditText>(Resource.Id.txt_user);
            textPassword = FindViewById<EditText>(Resource.Id.txt_password);
            registerButton = FindViewById<Button>(Resource.Id.btn_register);
            registerButton.Click += Register_Button;

        }
        private void Register_Button(object sender, EventArgs e)
        {
            username = textUser.Text;
            password = textPassword.Text;
            if (username=="" || password=="")
            {
                Toast.MakeText(this,"Please enter valid username and password", ToastLength.Long).Show();
            }
            else
            {
                editor.PutString("username", username);
                
                editor.PutString("password", password);
                editor.Apply();
                Toast.MakeText(this, "Registration succesful!", ToastLength.Long).Show();

                var mapIntent = new Intent(this, typeof(Login));
                StartActivity(mapIntent);
            }
            
            
        }
    }
}
