using System;
using Xamarin.Forms;

namespace XFCustomControl
{
    public class ContentPageBase : ContentPage
    {
        protected override void OnParentSet()
        {
            base.OnParentSet();
            if (Parent == null)
            {
                if (BindingContext is IDisposable)
                {
                    (BindingContext as IDisposable).Dispose();
                }
            }
        }
    }
}
