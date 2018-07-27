using MWX.XamForms.Popup;
using System;
using Xamarin.Forms;
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
            new PopupPageInitializer(this) { CustomPopup};
        }

        private void BtnShowPopup_Clicked(object sender, EventArgs e)
        {
            CustomPopup.Show();
        }

        private void BtnAddBox_Clicked(object sender, EventArgs e)
        {
            var box = new BoxView()
            {
                WidthRequest = 40,
                HeightRequest = 40,
                BackgroundColor = Color.Yellow
            };
            Container.Children.Add(box);
        }
    }
}