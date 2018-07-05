using MWX.XamForms.Popup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            new PopupPageInitializer(this) { CustomPopup };
        }

        private void BtnShowPopup_Clicked(object sender, EventArgs e)
        {
            CustomPopup.Show();
        }
    }
}