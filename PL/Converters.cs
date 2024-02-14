using System.Globalization;
using System.Windows.Data;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PL;

class ConvertIdToContent : IValueConverter
{
    //The Convert function converts a ID value to a string. If the ID is 0, it returns "Add"; otherwise, it returns "Update".
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (int)value == 0 ? "Add" : "Update";
    }
    //The ConvertBack function is not implemented and throws a NotImplementedException when called.
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

class ConvertIdToBool : IValueConverter
{
    //The Convert function converts a ID value to a bool. If the ID is 0, it returns 'true'; otherwise, it returns 'false'.
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (int)value == 0;
    }
    //The ConvertBack function is not implemented and throws a NotImplementedException when called.
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

