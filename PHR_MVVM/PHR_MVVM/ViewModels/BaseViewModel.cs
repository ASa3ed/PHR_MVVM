using AutoMapper;
using Prism;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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


    }
}
