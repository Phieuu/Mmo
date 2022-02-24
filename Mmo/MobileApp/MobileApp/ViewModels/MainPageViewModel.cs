﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MobileApp.Models;
using MobileApp.Services.Database;
using MobileApp.Views;
using Prism.Navigation;

namespace MobileApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IFirebaseDatabaseService _firebaseDatabaseService;

        public MainPageViewModel(INavigationService navigationService, IFirebaseDatabaseService firebaseDatabaseService)
            : base(navigationService)
        {
            _firebaseDatabaseService = firebaseDatabaseService;
            Title = "Main Page";
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await Task.Delay(TimeSpan.FromSeconds(2));
            try
            {
                //var insert = await _firebaseDatabaseService.AddItemAsync(new UpdateOle777K8MaModel(){IsUpdate = true});
                var data = await _firebaseDatabaseService.GetItemAsync<UpdateOle777K8MaModel>();
                if (data != null)
                    App.DataOle777K8Ma = data;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            if (App.DataOle777K8Ma.IsUpdate)
                await NavigationService.NavigateAsync(nameof(HomePage));
            else
                await NavigationService.NavigateAsync(nameof(Ole777ProPage));
        }
    }
}