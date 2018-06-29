using Android.Content;
using XFCustomControl.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ListView), typeof(ListViewRenderder))]
namespace XFCustomControl.Droid.Renderers
{
    public class ListViewRenderder : ListViewRenderer
    {
        public ListViewRenderder(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var listView = Control as Android.Widget.ListView;
                listView.NestedScrollingEnabled = true;
            }
        }
    }
}