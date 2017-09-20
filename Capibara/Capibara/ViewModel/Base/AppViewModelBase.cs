using Acr.UserDialogs;
using GalaSoft.MvvmLight;
using Naylah.Xamarin.Services.NavigationService;
using Plugin.BLE;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Capibara.ViewModel.Base
{
    public class AppViewModelBase : ViewModelBase, INavigable
    {
        public INavigationService NavigationService { get { return App.Current.NavigationService; } }

        public AppViewModelBase()
        {
            var ble = CrossBluetoothLE.Current;
            ble.StateChanged += (s, e) =>
            {                
                Debug.WriteLine($"The bluetooth state changed to {e.NewState}");
            };

            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        private async void Current_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (!e.IsConnected)
               await ShowToast("Verifique sua conexão");
        }

        public GalaSoft.MvvmLight.Views.IDialogService DialogService
        {
            get
            {
                return GetService<GalaSoft.MvvmLight.Views.IDialogService>();
            }
        }

        public T GetService<T>()
        {
            return App.Resolve<T>();
        }

        private IConnectivity _internet;

        public IConnectivity Internet
        {
            get
            {
                _internet = CrossConnectivity.Current;
                return _internet;
            }
            set { Set(ref _internet, value); }
        }


        private bool isLoading;

        public bool IsLoading
        {
            get { return isLoading; }
            private set { Set(ref isLoading, value); }
        }

        private string _loadingMessage;

        public string LoadingMessage
        {
            get { return _loadingMessage; }
            set { Set(ref _loadingMessage, value); }
        }

        public event EventHandler<bool> LoadingChanged;

        public void SetIsLoading(bool isLoading = true, string message = "")
        {
            LoadingMessage = message;

            if (IsLoading != isLoading)
            {
                IsLoading = isLoading;
            }
            RaiseLoadingChanged(IsLoading);
        }

        public void RaiseLoadingChanged(bool loading)
        {
            LoadingChanged?.Invoke(this, loading);
        }

        public async Task ShowProgressDialog(string message)
        {
            UserDialogs.Instance.ShowLoading(message);
        }

        public async Task HideProgressDialog()
        {
            UserDialogs.Instance.HideLoading();
        }

        public async Task ShowToast(string message)
        {
            UserDialogs.Instance.Toast(message);
        }
        public virtual async Task OnNavigatedFromAsync()
        {

        }

        public virtual async Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {

        }

        public virtual async Task OnNavigatingToAsync(object parameter, NavigationMode mode)
        {

        }
    }
}
