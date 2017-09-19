using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Droid;
using ImageCircle.Forms.Plugin.Droid;
using Acr.UserDialogs;
using Xamarin.Forms;
using Android.Content;
using System.Collections.Generic;
using Android.Speech;
using Plugin.CurrentActivity;
using System.Threading.Tasks;
using Capibara.Droid.Service;

namespace Capibara.Droid
{
    [Activity(Label = "Capibara", Icon = "@drawable/icon", 
        Theme = "@style/MainTheme", 
        MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        public const int REQ_CODE_SPEECH_INPUT = 100;
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
             => Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            CachedImageRenderer.Init();
            ImageCircleRenderer.Init();
            UserDialogs.Init(() => (Activity)Forms.Context);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            switch (requestCode)
            {
                case REQ_CODE_SPEECH_INPUT:
                    {
                        if (resultCode == Result.Ok)
                        {
                            var matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);
                            if (matches.Count != 0)
                            {
                                var textInput = matches[0];
                                if (textInput.Length > 500)
                                    textInput = textInput.Substring(0, 500);
                                SpeechToTexService.SpeechText = textInput;
                            }
                        }
                        SpeechToTexService.autoEvent.Set();
                        break;
                    }

            }
        }
    }
}

