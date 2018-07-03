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
                                                                typeof(CheckboxState),
                                                                typeof(Checkbox),
                                                                defaultValue: CheckboxState.Unchecked,
                                                                defaultBindingMode: BindingMode.TwoWay,
                                                                propertyChanged: (bindable, oldVal, newval) =>
                                                                {
                                                                    var checkBox = (Checkbox)bindable;
                                                                    var state = (CheckboxState)newval;
                                                                    if (state == CheckboxState.Unchecked)
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

        public CheckboxState State
        {
            get => (CheckboxState)GetValue(StateProperty);
            set => SetValue(StateProperty, value);
        }

        public Checkbox()
        {
            InitializeComponent();
            State = CheckboxState.Unchecked;
            ImageUnchecked.BindingContext = this;
            ImageChecked.BindingContext = this;
            ImageUnchecked.IsVisible = true;
            ImageChecked.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            State = State == CheckboxState.Unchecked ? CheckboxState.Checked : CheckboxState.Unchecked;
        }

        public enum CheckboxState
        {
            Unchecked,
            Checked,
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }
    }
}