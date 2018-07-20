using System;
using System.Globalization;
using Xamarin.Forms;

namespace XFCustomControl.Converters
{
    public class EqualsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return false;

            if (value.GetType() == typeof(string))
            {
                return value.ToString().Equals(parameter.ToString(), StringComparison.OrdinalIgnoreCase);
            } 
            else if (value.GetType().IsEnum)
            {
                return value.ToString().Equals(parameter.ToString(), StringComparison.OrdinalIgnoreCase);               
            }
            else if (value.GetType() == typeof(int))
            {
                return (int)value == System.Convert.ToInt32(parameter);
            }
            else if (value.GetType() == typeof(bool))
            {
                return (bool)value == System.Convert.ToBoolean(parameter);
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
