using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TabLayout = Android.Support.Design.Widget.TabLayout;
using Xamarin.Forms;
using Android.Support.Design.Widget;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;
using Android.Graphics.Drawables;
using XFCustomControl.Controls;
using XFCustomControl.Droid.Renderers;

[assembly: ExportRenderer(typeof(TabView), typeof(TabViewRenderer))]
namespace XFCustomControl.Droid.Renderers
{
    public class TabViewRenderer : ViewRenderer<TabView, TabLayout>
    {
        public TabViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TabView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var tabLayout = (TabLayout)LayoutInflater.From(Context).Inflate(Resource.Layout.Tabbar, null, false);
                foreach (var tab in e.NewElement.Tabs)
                {
                    tabLayout.AddTab(tabLayout.NewTab().SetText(tab.Text));
                }

                LinearLayout linearLayout = (LinearLayout)tabLayout.GetChildAt(0);
                linearLayout.ShowDividers = ShowDividers.Middle;
                GradientDrawable drawable = new GradientDrawable();
                drawable.SetColor(Resource.Color.dark_line_color);
                drawable.SetSize(1, 1);
                linearLayout.DividerPadding = 10;
                linearLayout.SetDividerDrawable(drawable);

                tabLayout.TabSelected += TabLayout_TabSelected;
                tabLayout.GetTabAt(e.NewElement.SelectedIndex).Select();

                SetNativeControl(tabLayout);
            }

            Element.TabChanged += Element_TabChanged;
        }

        private void Element_TabChanged(object sender, Tab e)
        {
            var tab = Control.GetTabAt(e.Index);
            tab.SetText(e.Text);
        }

        private void TabLayout_TabSelected(object sender, TabLayout.TabSelectedEventArgs e)
        {
            Element.OnTabSelectionChanged(e.Tab.Position);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            switch (e.PropertyName)
            {
                case nameof(Element.SelectedIndex):
                    var tab = Control.GetTabAt(Element.SelectedIndex);
                    tab.Select();
                    break;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Element.TabChanged -= Element_TabChanged;
            }

            base.Dispose(disposing);
        }
    }
}