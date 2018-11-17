using Android.App;
using Android.Widget;
using Android.OS;
using System;
using CompoundViewExampleXamarin.Views;

namespace CompoundViewExampleXamarin
{
    [Activity(Label = "CompoundViewExampleXamarin", MainLauncher = true)]
    public class MainActivity : Activity
    {
        #region Views
        Button BtnAddError => FindViewById<Button>(Resource.Id.btnAddError);
        Button BtnClearError => FindViewById<Button>(Resource.Id.btnClearError);
        MyEditText MyEditText => FindViewById<MyEditText>(Resource.Id.testMyEditText);
        #endregion

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            BtnAddError.Click += (sender, e) => MyEditText.Error = "New error";
            BtnClearError.Click += (sender, e) => MyEditText.Error = "";
        }
    }
}

