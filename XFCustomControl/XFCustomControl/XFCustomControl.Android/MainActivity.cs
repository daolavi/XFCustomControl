﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CarouselView.FormsPlugin.Android;
using XFCustomControl.Droid.Service;

namespace XFCustomControl.Droid
{
    [Activity(Label = "XFCustomControl", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            CustomAlert.CurrentActivity = this;
            global::Xamarin.Forms.Forms.Init(this, bundle);
            CarouselViewRenderer.Init();
            LoadApplication(new App());
        }
    }
}

