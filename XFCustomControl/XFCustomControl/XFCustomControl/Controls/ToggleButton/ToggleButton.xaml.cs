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

        public ToggleButton ()
		{
			InitializeComponent ();
            State = ToggleButtonState.Off;
            ImageOff.BindingContext = this;
            ImageOn.BindingContext = this;
            ImageOff.IsVisible = true;
            ImageOn.IsVisible = false;
        }

        public enum ToggleButtonState
        {
            Off,
            On,
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            State = State == ToggleButtonState.Off ? ToggleButtonState.On : ToggleButtonState.Off;
        }
    }
}