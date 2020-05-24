namespace ToDoList.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Data;
    using ToDoList.Models;

    /// <summary>
    /// Provides a way to convert a collection of 'tags' (strings) to a single string and vice versa
    /// </summary>
    public struct TagToText : IValueConverter
    {
        /// <summary>
        /// Convert the collection of 'tags' (strings) from the source to a string consisting of all of them
        /// </summary>
        /// <returns>A string representation of all the tags</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            StringBuilder result = new StringBuilder();

            foreach (var tag in value as ObservableCollection<string>)
            {
                result.AppendFormat("#{0} ", tag);
            }

            return result.ToString().Trim();
        }

        /// <summary>
        /// Convert a string from the source to a collection of 'tags' (strings)
        /// </summary>
        /// <returns>A collection of strings representing all the tags</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string[] split = (value as string).Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
            return new ObservableCollection<string>(split.AsEnumerable<string>());
        }
    }
}
