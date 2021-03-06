﻿using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capibara.Helpers
{
    public class DialogHelper  : IDialogService
    {
        public async Task ShowError(Exception error, string title, string buttonText, Action afterHideCallback)
        {
            await App.Current.MainPage.DisplayAlert(
              title,
              error.Message,
              buttonText);

            if (afterHideCallback != null)
            {
                afterHideCallback();
            }
        }

        public async Task ShowError(string message, string title, string buttonText, Action afterHideCallback)
        {
            await App.Current.MainPage.DisplayAlert(title, message, buttonText);
            if (afterHideCallback != null)
            {
                afterHideCallback();
            }
        }

        public async Task ShowMessage(string message, string title)
        {
            await App.Current.MainPage.DisplayAlert(title, message, "ok");
        }

        public async Task ShowMessage(string message, string title,
            string buttonText, Action afterHideCallback)
        {
            await App.Current.MainPage.DisplayAlert(title, message, buttonText);
            if (afterHideCallback != null)
            {
                afterHideCallback();
            }
        }

        public async Task<bool> ShowMessage(string message, string title,
            string buttonConfirmText, string buttonCancelText, Action<bool> afterHideCallback)
        {
            var result = await App.Current.MainPage.DisplayAlert(
               title,
               message,
               buttonConfirmText,
               buttonCancelText);

            if (afterHideCallback != null)
            {
                afterHideCallback(result);
            }

            return result;
        }

        public async Task ShowMessageBox(string message, string title)
        {
            await App.Current.MainPage.DisplayAlert(title, message, "ok");
        }
    }
}
