using Capibara.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Capibara.Views
{
    public class MainPage : ContentPageDataBase<MainViewModel>
    {
        public int MyProperty { get; set; }
        public override void OnCreate()
        {
            Title = "Capibara";



            var speak = new Button
            {
                Text = "pressione para falar"
            };
            speak.SetBinding(Button.CommandProperty, CreateBinding(x => x.SpeechCommand));

            var lbResult = new Label {
                FontSize = Device.GetNamedSize(NamedSize.Large,typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            lbResult.SetBinding(Label.TextProperty, CreateBinding(x => x.ResultText));

            Content = new StackLayout
            {
                Padding = 16,
                Children =
                {
                  lbResult,
                    speak,
                  
                }
            };
        }
    }
}