using MWX.XamForms.Popup;
using System;
using Xamarin.Forms.Xaml;
using XFCustomControl.Controls;

namespace XFCustomControl.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DemoControl3View : ContentPageBase
    {
        public DemoControl3View()
        {
            InitializeComponent();
            new PopupPageInitializer(this) { CustomPopup, CustomAlert };
        }

        private void BtnShowPopup_Clicked(object sender, EventArgs e)
        {
            CustomPopup.Show();
        }

        private void BtnDisplayAlert_Clicked(object sender, EventArgs e)
        {
            CustomAlert.Show();
        }
    }
}