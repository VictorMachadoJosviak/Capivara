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
using Autofac;
using Capibara.Helpers;
using Capibara.Droid.Service;

namespace Capibara.Droid.DI
{
    public class DependencyRegisterExtension
    {
        public static void Register(ContainerBuilder containerBuilder)
        {
           containerBuilder.RegisterType<SpeechToTexService>().As<ISpeechToTextHelper>().SingleInstance();
            

        }
    }
}