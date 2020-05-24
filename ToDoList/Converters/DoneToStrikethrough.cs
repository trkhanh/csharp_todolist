namespace ToDoList.Converters
{
    using System;
    using System.Windows.Data;
    using ToDoList.Models;

    /// <summary>
    /// Handles conversion of boolean values to TextDecorations value - Strikethrough
    /// </summary>
    public class DoneToStrikethrough : IValueConverter
    {
        /// <summary>
        /// Convert boolean values to TextDecorations value - Strikethrough
        /// </summary>
        /// <returns>A string determining whether some text should be stricken through or not</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
            {
                return "Strikethrough";
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
