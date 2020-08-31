using AutoMapper;
using CustomActions.Common.Cache;
using CustomActions.Common.Translation.Resx;
using PHR_MVVM.Abstractions;
using PHR_MVVM.CustomComponents.Popups;
using Prism;
using Prism.Mvvm;
using Prism.Navigation;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PHR_MVVM.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware, IDestructible, IActiveAware
    {
        protected IMapper Mapper { get; set; }
        protected INavigationService NavigationService { get; set; }

        public BaseViewModel(IMapper mapper, INavigationService navigationService)
        {
            Mapper = mapper;
            NavigationService = navigationService;
        }


        private bool isActive;
        public bool IsActive
        {
            get => isActive;
            set => base.SetProperty(ref isActive, value, (Action)(async () =>
            {
                if (value)
                {
                    await OnAppearing();
                }
                else
                {
                    await OnDisappearing();
                }
            }));
        }

        private bool isBusy;
        public bool IsBusy { get => isBusy; set => SetProperty(ref isBusy, value); }

        private bool rtl;
        public bool Rtl { get => rtl; set => SetProperty(ref rtl, value); }


        public event EventHandler IsActiveChanged;

        public virtual void Destroy()
        {
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }


        public virtual Task OnAppearing()
        {
            return Task.FromResult(0);
        }

        public virtual Task OnDisappearing()
        {
            return Task.FromResult(0);
        }

        public void ShowLoader(string message = "")
        {
            IsBusy = true;
        }

        public void HideLoader(string message = "")

        {
            IsBusy = false;
        }

        public async Task<bool> RequestPermission<T>() where T : Permissions.BasePermission, new()
        {
            var result = await Permissions.RequestAsync<T>();
            bool granted = result == Xamarin.Essentials.PermissionStatus.Granted;
            if (!granted)
            {
                bool requested = Preferences.ContainsKey(ApplicationProperties.RequestedPermission + typeof(T).Name);

                if (requested)
                    if (Device.RuntimePlatform == Device.iOS)
                        await PopupNavigation.Instance.PushAsync(new PopupDialog()
                        {

                            PopupDialogTitle = Resource.Info,

                            MsgBody = Resource.EnableFromSettingsRequest,

                            ActionButtonText = Resource.Yes,

                            CancelButtonText = Resource.Cancel,

                            CancelButtonCommand = new BaseCommandHandler(async () =>
                            {
                                var popup = PopupNavigation.Instance.PopupStack.LastOrDefault();

                                await popup.FindByName<Grid>("grid").TranslateTo(0, 800, 250);

                                await PopupNavigation.Instance.PopAsync(true);


                            }),

                            ActionButtonCommand = new BaseCommandHandler(async () =>
                            {
                                await Xamarin.Essentials.Launcher.OpenAsync("app-settings:");
                                var popup = PopupNavigation.Instance.PopupStack.LastOrDefault();

                                await popup.FindByName<Grid>("grid").TranslateTo(0, 800, 250);

                                await PopupNavigation.Instance.PopAsync(true);



                            }),

                        }, false);
                    else
                        await PopupNavigation.Instance.PushAsync(new PopupDialog()
                        {
                            PopupHeight = 300,

                            PopupDialogTitle = Resource.Info,

                            MsgBody = Resource.AllowOrGoToSettings,

                            ActionButtonText = Resource.Settings,

                            CancelButtonText = Resource.Cancel,

                            CancelButtonCommand = new Command(async () =>
                            {
                                var popup = PopupNavigation.Instance.PopupStack.LastOrDefault();

                                await popup.FindByName<Grid>("grid").TranslateTo(0, 800, 250);

                                await PopupNavigation.Instance.PopAsync(true);


                            }),

                            ActionButtonCommand = new Command(async () =>
                            {
                                await Xamarin.Essentials.Launcher.OpenAsync("app-settings:");
                                var popup = PopupNavigation.Instance.PopupStack.LastOrDefault();

                                await popup.FindByName<Grid>("grid").TranslateTo(0, 800, 250);

                                await PopupNavigation.Instance.PopAsync(true);

                            }),

                        }, false);
                else
                    Preferences.Set(ApplicationProperties.RequestedPermission + typeof(T).Name, true);
            }

            return granted;
        }
    }
}
