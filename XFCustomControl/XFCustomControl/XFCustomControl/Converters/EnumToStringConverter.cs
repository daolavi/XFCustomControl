using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace XFCustomControl.Converters
{
    public class EnumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Enum)) return string.Empty;

            DescriptionAttribute attribute = value.GetType()
             .GetField(value.ToString())
             .GetCustomAttributes(typeof(DescriptionAttribute), false)
             .SingleOrDefault() as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
