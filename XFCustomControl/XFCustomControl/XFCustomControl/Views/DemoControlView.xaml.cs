using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XFCustomControl.Models;

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
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            //comment out if you want to keep selections
            ListView lst = (ListView)sender;
            lst.SelectedItem = null;
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
    }
}