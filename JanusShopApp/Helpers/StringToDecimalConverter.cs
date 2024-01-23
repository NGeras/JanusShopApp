using System.Globalization;
using System.Windows.Data;

namespace JanusShopApp.Helpers;

public class StringToDecimalConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var priceString = (string)value;
        // Convert the original string price to decimal for rounding
        if (decimal.TryParse(priceString, CultureInfo.InvariantCulture, out decimal neto))
        {
            // Round to desired decimal places
            return $"{Math.Round(neto, 2)}€";
        }
        return "Puudub"; // Default value if parsing fails
    }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}