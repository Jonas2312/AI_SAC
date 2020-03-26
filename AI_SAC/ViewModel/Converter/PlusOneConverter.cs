using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AI_SAC.ViewModel.Converter
{
    public class PlusOneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int x = 0;
            if (!int.TryParse(value.ToString(), out x))
                return x;
            ++x;
            return (int)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int x = 0;
            if (!int.TryParse(value.ToString(), out x))
                return x;
            --x;
            return x.ToString();
        }
    }
}
