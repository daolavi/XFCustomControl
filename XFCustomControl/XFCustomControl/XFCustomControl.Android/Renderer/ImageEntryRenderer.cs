using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFCustomControl.Controls;
using XFCustomControl.Droid.Renderer;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(ImageEntryRenderer))]
namespace XFCustomControl.Droid.Renderer
{
    public class ImageEntryRenderer : EntryRenderer
    {
        public ImageEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;

                var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
                layoutParams.SetMargins(0, 0, 0, 0);
                LayoutParameters = layoutParams;
                Control.LayoutParameters = layoutParams;
                Control.SetPadding(0, 0, 0, 0);
                SetPadding(0, 0, 0, 0);
            }
        }
    }
}