using Android.Content;
using Android.Widget;
using XFCustomControl.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(XFCustomControl.Controls.RadioButton), typeof(RadioButtonRenderer))]
namespace XFCustomControl.Droid.Renderers
{
    public class RadioButtonRenderer : ViewRenderer<Controls.RadioButton, Android.Widget.RadioButton>
    {
        public RadioButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Controls.RadioButton> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                e.OldElement.PropertyChanged += ElementOnPropertyChanged;
            }

            if (Control == null)
            {
                var radButton = new RadioButton(Context);

                radButton.CheckedChange += radButton_CheckedChange;

                SetNativeControl(radButton);
            }

            Control.Text = e.NewElement.Text;
            Control.Checked = e.NewElement.Checked;
            Control.LayoutDirection = e.NewElement.LayoutDirection == Controls.LayoutDirection.LTR ? Android.Views.LayoutDirection.Ltr : Android.Views.LayoutDirection.Rtl;
            Control.SetHeight((int)e.NewElement.HeightRequest);
            Element.PropertyChanged += ElementOnPropertyChanged;
        }

        void radButton_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            Element.Checked = e.IsChecked;
        }

        void ElementOnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Checked":
                    Control.Checked = Element.Checked;
                    break;
                case "Text":
                    Control.Text = Element.Text;
                    break;
            }
        }
    }
}