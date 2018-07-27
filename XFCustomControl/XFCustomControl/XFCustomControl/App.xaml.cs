using Prism;
using Prism.Autofac;
using Prism.Ioc;
using XFCustomControl.ViewModels;
using XFCustomControl.Views;
using Xamarin.Forms;
using XFCustomControl.Controls;

namespace XFCustomControl
{
	public partial class App : PrismApplication
    {
		public App ()
		{
			InitializeComponent();
		}

        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            await NavigationService.NavigateAsync("CustomNavigationPage/DemoControlView");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<CustomNavigationPage>();
            //containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<DemoControlView, DemoControlViewModel>();
            containerRegistry.RegisterForNavigation<DemoControl2View, DemoControl2ViewModel>();
            containerRegistry.RegisterForNavigation<DemoControl3View, DemoControl3ViewModel>();
        }
    }
}
