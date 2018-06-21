using System;
using Xamarin.Forms;

namespace XFCustomControl.Controls
{
    public class CustomImage : Image
    {
        public event EventHandler ImageClicked;

        public CustomImage()
        {
            var gesture = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1
            };
            gesture.Tapped += ImageOn_Clicked;
            GestureRecognizers.Add(gesture);
        }

        public virtual void ImageOn_Clicked(object sender, EventArgs e)
        {
            ImageClicked?.Invoke(sender, e);
        }
    }
}
