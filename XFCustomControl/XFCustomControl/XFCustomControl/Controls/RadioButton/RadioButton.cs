using System;
using Xamarin.Forms;

namespace XFCustomControl.Controls
{
    public class RadioButton : View
    {
        public int Index { get; set; }

        #region Checked
        public static readonly BindableProperty CheckedProperty = BindableProperty.Create(nameof(Checked), typeof(bool), typeof(RadioButton), false);

        public bool Checked
        {
            get => (bool)GetValue(CheckedProperty);

            set
            {
                SetValue(CheckedProperty, value);
                var eventHandler = CheckedChanged;
                if (eventHandler != null)
                {
                    eventHandler.Invoke(this, value);
                }
            }
        }

        public event EventHandler<bool> CheckedChanged;
        #endregion

        #region Text
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(RadioButton), string.Empty);

        public string Text
        {
            get => (string)GetValue(TextProperty);

            set => SetValue(TextProperty, value);
        }
        #endregion

        #region LayoytDirection
        public static BindableProperty LayoutDirectionProperty = BindableProperty.Create(nameof(LayoutDirection),
                                                                        typeof(LayoutDirection),
                                                                        typeof(BindableRadioGroup),
                                                                        LayoutDirection.LTR);

        public LayoutDirection LayoutDirection
        {
            get => (LayoutDirection)GetValue(LayoutDirectionProperty);
            set => SetValue(LayoutDirectionProperty, value);
        }
        #endregion
    }
}
