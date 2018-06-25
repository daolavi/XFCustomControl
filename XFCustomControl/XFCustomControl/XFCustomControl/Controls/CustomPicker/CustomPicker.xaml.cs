using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFCustomControl.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomPicker : ContentView
	{
        public static BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource),
                                                                typeof(IList),
                                                                typeof(CustomPicker),
                                                                defaultValue: default(IList));

        public IList ItemsSource
        {
            get => (IList)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public static BindableProperty ItemDisplayBindingProperty = BindableProperty.Create(nameof(ItemDisplayBinding),
                                                                typeof(string),
                                                                typeof(CustomPicker),
                                                                defaultValue: default(string),
                                                                propertyChanged: (bindable, oldVal, newval) =>
                                                                {
                                                                    var customPicker = (CustomPicker)bindable;
                                                                    customPicker.PickerList.ItemDisplayBinding = new Binding((string)newval);
                                                                });
        public string ItemDisplayBinding
        {
            get => (string)GetValue(ItemDisplayBindingProperty);
            set => SetValue(ItemDisplayBindingProperty, value);
        }

        public static BindableProperty TitleProperty = BindableProperty.Create(nameof(Title),
                                                                typeof(string),
                                                                typeof(CustomPicker),
                                                                defaultValue: default(string));
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static BindableProperty SelectedItemProperty = BindableProperty.Create(nameof(SelectedItem),
                                                                typeof(object),
                                                                typeof(CustomPicker),
                                                                defaultValue: default(object),
                                                                defaultBindingMode: BindingMode.TwoWay,
                                                                propertyChanged: (bindable, oldVal, newval) =>
                                                                {
                                                                    var customPicker = (CustomPicker)bindable;
                                                                    if (newval == null)
                                                                    {
                                                                        customPicker.PickerLabel.Text = customPicker.Placeholder;
                                                                    }
                                                                    else
                                                                    {
                                                                        var propertyname = customPicker.LabelDisplay;
                                                                        if (!string.IsNullOrEmpty(propertyname))
                                                                        {
                                                                            var displayName = newval.GetType().GetProperty(propertyname).GetValue(newval).ToString();
                                                                            customPicker.PickerLabel.Text = displayName;
                                                                        }
                                                                        else
                                                                        {
                                                                            customPicker.PickerLabel.Text = newval.ToString();
                                                                        }
                                                                    }
                                                                });

        public object SelectedItem
        {
            get => (object)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public static BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder),
                                                                typeof(string),
                                                                typeof(CustomPicker),
                                                                defaultValue: default(string));
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public static BindableProperty LabelDisplayProperty = BindableProperty.Create(nameof(LabelDisplay),
                                                                typeof(string),
                                                                typeof(CustomPicker),
                                                                defaultValue: default(string));
        public string LabelDisplay
        {
            get => (string)GetValue(LabelDisplayProperty);
            set => SetValue(LabelDisplayProperty, value);
        }

        public static BindableProperty AccentColorProperty = BindableProperty.Create(nameof(AccentColor),
                                                             typeof(Color),
                                                             typeof(ImageEntry),
                                                             defaultValue: Color.Accent);

        public Color AccentColor
        {
            get => (Color)GetValue(AccentColorProperty);
            set => SetValue(AccentColorProperty, value);
        }

        public static BindableProperty DefaultColorProperty = BindableProperty.Create(nameof(DefaultColor),
                                                             typeof(Color),
                                                             typeof(ImageEntry),
                                                             defaultValue: Color.Gray);

        public Color DefaultColor
        {
            get => (Color)GetValue(DefaultColorProperty);
            set => SetValue(DefaultColorProperty, value);
        }

        public static BindableProperty LabelFontSizeProperty = BindableProperty.Create(nameof(LabelFontSize),
                                                             typeof(double),
                                                             typeof(ImageEntry),
                                                             defaultValue: Font.Default.FontSize);
        public double LabelFontSize
        {
            get => (double)GetValue(LabelFontSizeProperty);
            set => SetValue(LabelFontSizeProperty, value);
        }

        public static BindableProperty LabelTextColorProperty = BindableProperty.Create(nameof(LabelTextColor),
                                                             typeof(Color),
                                                             typeof(ImageEntry),
                                                             defaultValue: Color.Black);

        public Color LabelTextColor
        {
            get => (Color)GetValue(LabelTextColorProperty);
            set => SetValue(LabelTextColorProperty, value);
        }

        public CustomPicker ()
		{
			InitializeComponent ();
            PickerList.BindingContext = this;
            PickerLabel.BindingContext = this;
            BottomBorder.BindingContext = this;
        }

        private void Label_TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            PickerList.Focus();
        }

        private void Image_TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            PickerList.Focus();
        }

        private void PickerList_Focused(object sender, FocusEventArgs e)
        {
            BottomBorder.HeightRequest = 1.5;
            BottomBorder.BackgroundColor = AccentColor;
        }

        private void PickerList_Unfocused(object sender, FocusEventArgs e)
        {
            BottomBorder.HeightRequest = 1;
            BottomBorder.BackgroundColor = DefaultColor;
        }
    }
}