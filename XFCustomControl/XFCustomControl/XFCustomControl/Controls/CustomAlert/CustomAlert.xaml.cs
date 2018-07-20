using MWX.XamForms.Popup;
using Xamarin.Forms.Xaml;

namespace XFCustomControl.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomAlert : Popup
    {
        public CustomAlert()
        {
            InitializeComponent();
        }
    }
}