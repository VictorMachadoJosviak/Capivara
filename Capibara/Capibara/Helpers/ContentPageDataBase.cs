using Capibara;
using Capibara.ViewModel.Base;
using Naylah.Xamarin.Controls.Pages;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Xamarin.Forms;

namespace Xamarin.Forms
{
    public abstract class ContentPageDataBase<T> : ContentPageBase where T : AppViewModelBase
    {
        public ContentPageDataBase(bool setIsLoading = true)
        {
            BindingContext = App.Resolve<T>();

            if (setIsLoading)
                Vm?.SetIsLoading(true);

            OnCreate();
        }

        public T Vm => (T)BindingContext;

       // public CCFStyleKit StyleKit { get { return App.Current.StyleKit; } }
        public static Binding CreateBinding(Expression<Func<T, object>> propertyGetter, BindingMode mode = BindingMode.Default, IValueConverter converter = null, object converterParameter = null, string stringFormat = null)
        {
            return Binding.Create(propertyGetter, mode, converter, converterParameter, stringFormat);
        }

        public abstract new void OnCreate();
    }
}
