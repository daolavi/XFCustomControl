using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace XFCustomControl.Behaviors
{
    public class NumOfDecimalPointsBehavior : Behavior<Entry> 
    {
        public static readonly BindableProperty NumOfDecimalPointsProperty = BindableProperty.Create(nameof(NumOfDecimalPoints),
                                                                                                   typeof(int),
                                                                                                   typeof(NumOfDecimalPointsBehavior),
                                                                                                   defaultValue: 0,
                                                                                                   defaultBindingMode: BindingMode.TwoWay);
        public int NumOfDecimalPoints
        {
            get => (int)GetValue(NumOfDecimalPointsProperty);
            set => SetValue(NumOfDecimalPointsProperty, value);
        }

        protected override void OnAttachedTo(Entry entry)
        {            
            base.OnAttachedTo(entry);
            entry.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            base.OnDetachingFrom(entry);
            entry.TextChanged -= OnEntryTextChanged;
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                if (NumOfDecimalPoints == 0)
                {
                    if (e.NewTextValue.EndsWith("."))
                    {
                        (sender as Entry).Text = e.NewTextValue.Remove(e.NewTextValue.Length - 1);
                    }
                }
                else
                {
                    var index = e.NewTextValue.IndexOf(".");
                    if (index >= 0 && e.NewTextValue.Length - (index + 1) > NumOfDecimalPoints)
                    {
                        (sender as Entry).Text = e.NewTextValue.Remove(e.NewTextValue.Length - 1);
                    }
                }
            }            
        }
    }
}
