using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFCustomControl.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomToolbar : ContentView
	{
        public static readonly BindableProperty PageProperty = BindableProperty.Create(nameof(Page),
                                                                       typeof(Page),
                                                                       typeof(CustomToolbar),
                                                                       defaultBindingMode: BindingMode.OneWay,
                                                                       propertyChanged: (bindable, oldVal, newVal) =>
                                                                       {
                                                                           var customToolbar = (CustomToolbar)bindable;
                                                                           customToolbar.ButtonBack.IsVisible = customToolbar.Page.Navigation.NavigationStack.Count <= 1 ? false : true;
                                                                           customToolbar.Page.Appearing += (sender, e)=> 
                                                                           {
                                                                               var page = sender as Page;
                                                                           };
                                                                       });

        public Page Page
        {
            get => (Page)GetValue(PageProperty);
            set => SetValue(PageProperty, value);
        }

        public CustomToolbar ()
		{
			InitializeComponent ();
        }
        
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Console.WriteLine("Page.Navigation.NavigationStack.Count " + Page.Navigation.NavigationStack.Count);
            if (Page != null && Page.Navigation.NavigationStack.Count >= 2)
            {
                Page.Navigation.PopAsync();
                Navigation.RemovePage(Page);
            }
        }
    }
};