using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;

namespace XFCustomControl.Controls
{
    public class BindableRadioGroup : StackLayout
    {
        #region ItemsSource
        public static BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource),
                                                                typeof(IEnumerable<string>),
                                                                typeof(BindableRadioGroup),
                                                                default(IEnumerable),
                                                                propertyChanged: OnItemsSourceChanged);

        public IEnumerable<string> ItemsSource
        {
            get => (IEnumerable<string>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var bindableRadioGroup = bindable as BindableRadioGroup;
            var itemSources = newValue as IEnumerable<string>;

            bindableRadioGroup.RadioButtons.Clear();
            bindableRadioGroup.Children.Clear();
            if (itemSources != null)
            {
                var listItem = itemSources.ToList();
                var leng = listItem.Count;
                for (int i = 0; i < leng; i++)
                {
                    var item = listItem[i];

                    var rad = new RadioButton
                    {
                        Index = i,
                        Text = item.ToString(),
                        Checked = i == 0,
                        LayoutDirection = bindableRadioGroup.LayoutDirection,
                        HeightRequest = bindableRadioGroup.RadioButtonHeightRequest,
                    };
                    rad.CheckedChanged += bindableRadioGroup.OnCheckedChanged;

                    bindableRadioGroup.RadioButtons.Add(rad);
                    bindableRadioGroup.Children.Add(rad);

                    if (bindableRadioGroup.SeparatorVisibility)
                    {
                        if (i < leng - 1)
                        {
                            var boxView = new BoxView
                            {
                                Color = bindableRadioGroup.SeparatorColor,
                                HeightRequest = 1
                            };
                            bindableRadioGroup.Children.Add(boxView);
                        }
                    }
                }
            }
        }

        private void OnCheckedChanged(object sender, bool e)
        {
            if (e == false)
                return;

            var selectedRad = sender as RadioButton;

            foreach (var rad in RadioButtons)
            {
                if (!selectedRad.Index.Equals(rad.Index))
                {
                    rad.Checked = false;
                }
                else
                {
                    SelectedIndex = rad.Index;
                    if (CheckedChanged != null)
                    {
                        CheckedChanged.Invoke(sender, rad.Index);
                    }
                }
            }
        }

        public event EventHandler<int> CheckedChanged;
        #endregion

        #region SelectedIndex
        public static BindableProperty SelectedIndexProperty = BindableProperty.Create(nameof(SelectedIndex), typeof(int), typeof(BindableRadioGroup), default(int), BindingMode.TwoWay, propertyChanged: OnSelectedIndexChanged);

        public int SelectedIndex
        {
            get => (int)GetValue(SelectedIndexProperty);
            set => SetValue(SelectedIndexProperty, value);
        }

        private static void OnSelectedIndexChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var value = (int)newValue;
            if (value == -1)
                return;

            var bindableRadioGroup = bindable as BindableRadioGroup;

            foreach (var rad in bindableRadioGroup.RadioButtons)
            {
                if (rad.Index == bindableRadioGroup.SelectedIndex)
                {
                    rad.Checked = true;
                }
            }
        }
        #endregion

        #region SeparatorVisibility
        public static BindableProperty SeparatorVisibilityProperty = BindableProperty.Create(nameof(SeparatorVisibility),
                                                                        typeof(bool),
                                                                        typeof(BindableRadioGroup),
                                                                        default(bool));

        public bool SeparatorVisibility
        {
            get => (bool)GetValue(SeparatorVisibilityProperty);
            set => SetValue(SeparatorVisibilityProperty, value);
        }
        #endregion

        #region SeparatorColor
        public static BindableProperty SeparatorColorProperty = BindableProperty.Create(nameof(SeparatorColor),
                                                                        typeof(Color),
                                                                        typeof(BindableRadioGroup),
                                                                        Color.Gray);

        public Color SeparatorColor
        {
            get => (Color)GetValue(SeparatorColorProperty);
            set => SetValue(SeparatorColorProperty, value);
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

        #region LayoytDirection
        public static BindableProperty RadioButtonHeightRequestProperty = BindableProperty.Create(nameof(RadioButtonHeightRequest),
                                                                        typeof(double),
                                                                        typeof(BindableRadioGroup),
                                                                        (double)50);

        public double RadioButtonHeightRequest
        {
            get => (double)GetValue(RadioButtonHeightRequestProperty);
            set => SetValue(RadioButtonHeightRequestProperty, value);
        }
        #endregion

        private List<RadioButton> RadioButtons;

        public BindableRadioGroup()
        {
            RadioButtons = new List<RadioButton>();
        }
    }
}
