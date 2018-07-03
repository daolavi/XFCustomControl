using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFCustomControl.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Checkbox : ContentView
	{
        public static BindableProperty ImageUncheckedSourceProperty = BindableProperty.Create(nameof(ImageUncheckedSource),
                                                                typeof(string),
                                                                typeof(Checkbox),
                                                                defaultValue: "ic_unchecked");
        public string ImageUncheckedSource
        {
            get => (string)GetValue(ImageUncheckedSourceProperty);
            set => SetValue(ImageUncheckedSourceProperty, value);
        }

        public static BindableProperty ImageCheckedSourceProperty = BindableProperty.Create(nameof(ImageCheckedSource),
                                                                typeof(string),
                                                                typeof(Checkbox),
                                                                defaultValue: "ic_checked");
        public string ImageCheckedSource
        {
            get => (string)GetValue(ImageCheckedSourceProperty);
            set => SetValue(ImageCheckedSourceProperty, value);
        }

        public static BindableProperty StateProperty = BindableProperty.Create(nameof(State),
                                                                typeof(bool),
                                                                typeof(Checkbox),
                                                                defaultValue: false,
                                                                defaultBindingMode: BindingMode.TwoWay,
                                                                propertyChanged: (bindable, oldVal, newval) =>
                                                                {
                                                                    var checkBox = (Checkbox)bindable;
                                                                    var state = (bool)newval;
                                                                    if (!state)
                                                                    {
                                                                        checkBox.ImageUnchecked.IsVisible = true;
                                                                        checkBox.ImageChecked.IsVisible = false;
                                                                    }
                                                                    else
                                                                    {
                                                                        checkBox.ImageUnchecked.IsVisible = false;
                                                                        checkBox.ImageChecked.IsVisible = true;
                                                                    }
                                                                });

        public bool State
        {
            get => (bool)GetValue(StateProperty);
            set => SetValue(StateProperty, value);
        }

        public Checkbox()
        {
            InitializeComponent();
            State = false;
            ImageUnchecked.BindingContext = this;
            ImageChecked.BindingContext = this;
            ImageUnchecked.IsVisible = true;
            ImageChecked.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            State = !State;
        }
    }
}