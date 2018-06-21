using System;
using Xamarin.Forms;

namespace XFCustomControl
{
	public partial class MainPage : ContentPage
	{
        public MainPage()
        {
            InitializeComponent();
        }

        private void ImageEntry_RightImageClicked(object sender, EventArgs e)
        {
            SearchEntry.Text = string.Empty;
        }
    }
}
