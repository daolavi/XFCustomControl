using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFCustomControl.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ToggleButton : ContentView
	{
        public static BindableProperty ImageSourceOffProperty = BindableProperty.Create(nameof(ImageSourceOff),
                                                                typeof(string),
                                                                typeof(ToggleButton),
                                                                defaultValue: string.Empty);
        public string ImageSourceOff
        {
            get => (string)GetValue(ImageSourceOffProperty);
            set => SetValue(ImageSourceOffProperty, value);
        }

        public static BindableProperty ImageSourceOnProperty = BindableProperty.Create(nameof(ImageSourceOn),
                                                                typeof(string),
                                                                typeof(ToggleButton),
                                                                defaultValue: string.Empty);
        public string ImageSourceOn
        {
            get => (string)GetValue(ImageSourceOnProperty);
            set => SetValue(ImageSourceOnProperty, value);
        }

        public static BindableProperty StateProperty = BindableProperty.Create(nameof(State),
                                                                typeof(ToggleButtonState),
                                                                typeof(ToggleButton),
                                                                defaultValue: ToggleButtonState.Off,
                                                                defaultBindingMode: BindingMode.TwoWay,
                                                                propertyChanged: (bindable, oldVal, newval) =>
                                                                {
                                                                    var toggleButton = (ToggleButton)bindable;
                                                                    var state = (ToggleButtonState)newval;
                                                                    if (state == ToggleButtonState.Off)
                                                                    {
                                                                        toggleButton.ImageOff.IsVisible = true;
                                                                        toggleButton.ImageOn.IsVisible = false;
                                                                    }
                                                                    else
                                                                    {
                                                                        toggleButton.ImageOff.IsVisible = false;
                                                                        toggleButton.ImageOn.IsVisible = true;
                                                                    }
                                                                });

        public ToggleButtonState State
        {
            get => (ToggleButtonState)GetValue(StateProperty);
            set => SetValue(StateProperty, value);
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text),
                                                                            typeof(string),
                                                                            typeof(ToggleButton),
                                                                            defaultValue: string.Empty,
                                                                            defaultBindingMode: BindingMode.OneWay,
                                                                            propertyChanged: (bindable, oldVal, newval) =>
                                                                            {
                                                                                var toggleButton = (ToggleButton)bindable;
                                                                                var value = (string)newval;
                                                                                toggleButton.Label.IsVisible = !string.IsNullOrEmpty(value);
                                                                            });

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor),
                                                                            typeof(Color),
                                                                            typeof(ToggleButton),
                                                                            defaultValue: Color.White,
                                                                            defaultBindingMode: BindingMode.OneWay);

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize),
                                                                            typeof(double),
                                                                            typeof(ToggleButton),
                                                                            defaultValue: Font.Default.FontSize,
                                                                            defaultBindingMode: BindingMode.OneWay);

        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public static readonly BindableProperty WidthImageRequestProperty = BindableProperty.Create(nameof(WidthImageRequest),
                                                                            typeof(double),
                                                                            typeof(ToggleButton),
                                                                            defaultValue: (double)16,
                                                                            defaultBindingMode: BindingMode.OneWay);

        public double WidthImageRequest
        {
            get => (double)GetValue(WidthImageRequestProperty);
            set => SetValue(WidthImageRequestProperty, value);
        }

        public static readonly BindableProperty HeightImageRequestProperty = BindableProperty.Create(nameof(HeightImageRequest),
                                                                            typeof(double),
                                                                            typeof(ToggleButton),
                                                                            defaultValue: (double)16,
                                                                            defaultBindingMode: BindingMode.OneWay);

        public double HeightImageRequest
        {
            get => (double)GetValue(HeightImageRequestProperty);
            set => SetValue(HeightImageRequestProperty, value);
        }

        public ToggleButton ()
		{
			InitializeComponent ();
            State = ToggleButtonState.Off;
            ImageOff.BindingContext = this;
            ImageOn.BindingContext = this;
            Label.BindingContext = this;
            ImageOff.IsVisible = true;
            ImageOn.IsVisible = false;
            Label.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            State = State == ToggleButtonState.Off ? ToggleButtonState.On : ToggleButtonState.Off;
        }

        public enum ToggleButtonState
        {
            Off,
            On,
        }
    }
}