using Capibara.Views;
using Naylah.Kernel.Events;
using Naylah.Xamarin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Capibara
{
    public class App : BootStrapper
    {
        public static new App Current { get; set; }

        public static string ResultTextToSpeech;
        public App()
        {
            Current = this;
            NavigationServiceFactory(new NavigationPage(new MainPage()));
        }

        public static T Resolve<T>()
        {
            try
            {
                return DomainEvent.Container.GetService<T>();
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
