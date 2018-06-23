using System.Collections.Generic;
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
    }
}