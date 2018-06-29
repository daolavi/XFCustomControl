using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFCustomControll.Droid.Renderers;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(CustomButtonRenderer))]
namespace XFCustomControll.Droid.Renderers
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        public CustomButtonRenderer(Context context) : base(context)
        {
        }
    }
}