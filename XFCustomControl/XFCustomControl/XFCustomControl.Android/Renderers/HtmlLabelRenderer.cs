using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Text;
using Android.Widget;
using XFCustomControl.Controls;
using XFCustomControll.Droid.Renderers;

[assembly: ExportRenderer(typeof(HtmlLabel), typeof(HtmlLabelRenderer))]
namespace XFCustomControll.Droid.Renderers
{
    public class HtmlLabelRenderer : LabelRenderer
    {
        public HtmlLabelRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var view = (HtmlLabel)Element;
            if (view == null)
                return;

            Control.SetText(Html.FromHtml(view.Text.ToString()), TextView.BufferType.Spannable);
        }
    }
}