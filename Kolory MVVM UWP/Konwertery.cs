using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace Kolory_MVVM_UWP
{
    public class ByteToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (double)(byte)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (byte)(double)value;
        }
    }
    //public class ColorToSolidColorBrushConverter : IValueConverter
    //{
    //    private SolidColorBrush brush = new SolidColorBrush();
    //    public object Convert(object value, Type targetType, object parameter, string language)
    //    {
    //        Color kolor = (Color)value;
    //        brush.Color = kolor;
    //        return brush;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, string language)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
