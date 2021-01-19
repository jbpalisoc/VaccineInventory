using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace VaccineInventory.Converters
{
    class SexConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return true ? parameter : Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((bool)value) ? parameter : Binding.DoNothing;
        }
    }
}
