using System.Globalization;
using System.Windows.Data;

namespace JanusShopApp.Helpers;

public class NullOrEmptyStringImageConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (string.IsNullOrEmpty(value as string))
            return DependencyProperty.UnsetValue;
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // According to https://msdn.microsoft.com/en-us/library/system.windows.data.ivalueconverter.convertback(v=vs.110).aspx#Anchor_1
        // (kudos Scott Chamberlain), if you do not support a conversion 
        // back you should return a Binding.DoNothing or a 
        // DependencyProperty.UnsetValue
        return Binding.DoNothing;
        // Original code:
        // throw new NotImplementedException();
    }
}