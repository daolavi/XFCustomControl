using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                                                                       defaultValue: default(Page),
                                                                       defaultBindingMode: BindingMode.OneWay);

        public Page Page
        {
            get => (Page)GetValue(PageProperty);
            set => SetValue(PageProperty, value);
        }


        public static readonly BindableProperty HasBackButtonProperty = BindableProperty.Create(nameof(HasBackButton),
                                                                            typeof(bool),
                                                                            typeof(CustomToolbar),
                                                                            defaultValue: true,
                                                                            defaultBindingMode: BindingMode.OneWay,
                                                                            propertyChanged: (bindable, oldVal, newval) =>
                                                                            {
                                                                                var customToolbar = (CustomToolbar)bindable;
                                                                                var value = (bool)newval;
                                                                                customToolbar.ButtonBack.IsVisible = value;
                                                                            });

        public bool HasBackButton
        {
            get => (bool)GetValue(HasBackButtonProperty);
            set => SetValue(HasBackButtonProperty, value);
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title),
                                                                            typeof(string),
                                                                            typeof(CustomToolbar),
                                                                            defaultValue: string.Empty,
                                                                            defaultBindingMode: BindingMode.OneWay);

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty SubtitleProperty = BindableProperty.Create(nameof(Subtitle),
                                                                            typeof(string),
                                                                            typeof(CustomToolbar),
                                                                            defaultValue: string.Empty,
                                                                            defaultBindingMode: BindingMode.OneWay,
                                                                            propertyChanged: (bindable, oldVal, newval) =>
                                                                            {
                                                                                var customToolbar = (CustomToolbar)bindable;
                                                                                var value = (string)newval;
                                                                                customToolbar.LabelSubtitle.IsVisible = !string.IsNullOrEmpty(value);
                                                                                customToolbar.TitleLayout.Padding = !string.IsNullOrEmpty(value) ?
                                                                                                                        new Thickness(15, 0, 15, 8) :
                                                                                                                        new Thickness(15, 0, 15, 0);
                                                                            });

        public string Subtitle
        {
            get => (string)GetValue(SubtitleProperty);
            set => SetValue(SubtitleProperty, value);
        }

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor),
                                                                            typeof(Color),
                                                                            typeof(CustomToolbar),
                                                                            defaultValue: Color.White,
                                                                            defaultBindingMode: BindingMode.OneWay);

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public ObservableCollection<View> ToolbarItems { get; set; }

        public CustomToolbar ()
		{
			InitializeComponent ();
            ButtonBack.BindingContext = this;
            LabelTitle.BindingContext = this;
            LabelSubtitle.BindingContext = this;

            ToolbarItems = new ObservableCollection<View>();
            ToolbarItems.CollectionChanged += ToolbarItems_CollectionChanged;
        }

        private void ToolbarItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var view = e.NewItems[0] as View;
            LayoutToolbarItem.Children.Add(view);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (Page != null && Page.Navigation.NavigationStack.Count > 1)
            {
                Page.Navigation.PopAsync();
            }
        }
    }
};