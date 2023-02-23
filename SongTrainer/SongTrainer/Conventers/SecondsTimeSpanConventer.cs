using System;
using System.Globalization;
using System.Windows.Data;

namespace SongTrainer.Conventers
{
    [ValueConversion(typeof(double), typeof(TimeSpan))]
    internal class SecondsTimeSpanConventer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double time = (double)value;
            return TimeSpan.FromSeconds(time).ToString(@"mm\:ss");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}