using System.Globalization;
using System.Windows.Data;

namespace JanusShopApp.Helpers;

public class InverseBooleanToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType,
        object parameter, CultureInfo culture)
    {
        var boolValue = value != null && (bool)value;
        return !boolValue ? Visibility.Visible : Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType,
        object parameter, CultureInfo culture)
    {
        return null;
    }
}