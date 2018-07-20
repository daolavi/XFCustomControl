using System;
using System.Globalization;
using Xamarin.Forms;

namespace XFCustomControl.Converters
{
    public class NumberToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? string.Empty : value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = value as string;
            if (string.IsNullOrEmpty(str))
            {
                if (Nullable.GetUnderlyingType(targetType) != null)
                {
                    return null;
                }
                else
                {
                    return 0;
                }                
            }
            else
            {
                if (targetType == typeof(int) || targetType == typeof(int?))
                {
                    int intValue;
                    if (int.TryParse(str, out intValue)) return intValue;
                    else return 0;
                }
                else if (targetType == typeof(decimal) || targetType == typeof(decimal?))
                {
                    decimal decValue;
                    if (decimal.TryParse(str, out decValue)) return decValue;
                    else return 0;
                }

                return 0;
            }            
        }
    }
}
