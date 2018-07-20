using System;
using System.Globalization;
using Xamarin.Forms;

namespace XFCustomControl.Converters
{
    public class StringToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var strValue = value != null ? value.ToString() : string.Empty;
            return !string.IsNullOrEmpty(strValue) && strValue.ToLower() != "none";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
