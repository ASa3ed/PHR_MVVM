using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PHR_MVVM
{
    public partial class App : PrismApplication
    {
        public App()
        {
            InitializeComponent();

            
        }

        protected async override void OnInitialized()
        {
           //Your initialization and navigation goes there
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
           
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //Add module registerations (inhirits from IModule)
        }
    }
}
