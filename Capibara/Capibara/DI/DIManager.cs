using Autofac;
using Capibara.Helpers;
using Capibara.Service;
using Capibara.ViewModel;
using GalaSoft.MvvmLight.Views;
using Naylah.Kernel.Events;
using System;
using System.Collections.Generic;
using System.Text;
using XLabs.Ioc;
using XLabs.Ioc.Autofac;

namespace Capibara.DI
{
    public class DIManager
    {
        public static ContainerBuilder Builder { get; set; }

        public static IContainer Container { get; set; }

        public static void InitializeContainer()
        {
            Builder = new ContainerBuilder();

              Builder.RegisterType<MainViewModel>().AsSelf().SingleInstance();
            Builder.RegisterType<DialogHelper>().As<IDialogService>().SingleInstance();
            Builder.RegisterType<CapivaraService>().As<ICapivaraService>().SingleInstance();

            //  Builder.RegisterType<WatsonService>().As<IWatsonService>().SingleInstance();

        }

        public static void BuildContainer()
        {
            Container = Builder.Build();

            Resolver.SetResolver(new AutofacResolver(Container));

            DomainEvent.Container = new CoreEventsContainer();
        }
    }
}
