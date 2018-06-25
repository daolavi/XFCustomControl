using System;
using Xamarin.Forms;
using XFCustomControl.Controls;

namespace XFCustomControl.Views
{
	public partial class DemoControlView : ContentPageBase
    {
		public DemoControlView ()
		{
			InitializeComponent ();
        }

        private void SearchEntry_RightImageClicked(object sender, System.EventArgs e)
        {
            SearchEntry.Text = string.Empty;
        }

        private void SortSelector_OnChanged(object sender, Controls.SortSelector.SortType e)
        {
            SortType.Text = e.ToString();
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; 
            }
            DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            var list = (ListView)sender;
            list.SelectedItem = null;
        }

        public void OnMore(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
        }

        private void RadioGroup_CheckedChanged(object sender, int e)
        {
            Console.WriteLine("RadioGroup_CheckedChanged");
        }
    }
}