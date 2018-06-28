using Prism;
using Prism.Autofac;
using Prism.Ioc;
using XFCustomControl.ViewModels;
using XFCustomControl.Views;
using Xamarin.Forms;

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
            await NavigationService.NavigateAsync("NavigationPage/DemoControlView");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<DemoControlView, DemoControlViewModel>();
            containerRegistry.RegisterForNavigation<DemoControl2View, DemoControl2ViewModel>();
        }
    }
}
