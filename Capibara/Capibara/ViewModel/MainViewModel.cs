
using Capibara.Helpers;
using Capibara.Model;
using Capibara.Service;
using Capibara.ViewModel.Base;
using GalaSoft.MvvmLight.Command;
using Plugin.BLE;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capibara.ViewModel
{
    public class MainViewModel : AppViewModelBase
    {
        public ICapivaraService capivaraService { get; set; }
        public MainViewModel(ICapivaraService _capivaraService)
        {
            capivaraService = _capivaraService;            
        }   
        public RelayCommand SpeechCommand => new RelayCommand(async() =>
        {
            try
            {

                var ble = CrossBluetoothLE.Current;
                var adapter = CrossBluetoothLE.Current.Adapter;

                if (ble.State == Plugin.BLE.Abstractions.Contracts.BluetoothState.On)
                {
                    ResultText = await App.Resolve<ISpeechToTextHelper>().StartVoiceInput();
                    Conversa = await capivaraService.SendTextToService(ResultText);
                    capivaraService.Context = Conversa;
                    ResultText = Conversa.ConStrResposta;

                    
                }
                else
                {
                   await DialogService.ShowMessage("Ative o Bluetooth", "Bluetooth");
                }


            }
            catch (Exception ex)
            {
               await ShowToast(ex.Message);
            }
        });


        private Conversa _conversa;

        public Conversa Conversa
        {
            get { return _conversa; }
            set {Set(ref _conversa , value); }
        }


        private string _input;

        public string Input
        {
            get { return _input; }
            set {Set(ref _input , value); }
        }


        private string _resultText;

        public string ResultText
        {
            get { return _resultText; }
            set {Set(ref _resultText , value); }
        }

    }
}
