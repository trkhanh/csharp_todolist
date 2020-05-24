namespace ToDoList.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// Class that allows implementing serialization and deserialization of objects of type T
    /// </summary>
    /// <typeparam name="T">Type derived from BaseObjectModel</typeparam>
    public class DataTranslator<T> where T : BaseObjectModel
    {
        /// <summary>
        /// String representation of the path to the folder in which the xml files are kept
        /// </summary>
        private static readonly string Path = @"..\..\Data\";

        /// <summary>
        /// Serializes the data from a viewmodel to an *.xml file
        /// </summary>
        /// <param name="list">Collection of objects to be serialized</param>
        public static void Serialize(ObservableCollection<T> list)
        {
            XmlSerializer seri = new XmlSerializer(typeof(ObservableCollection<T>));

            using (TextWriter writer = new StreamWriter(Path + typeof(T).ToString() + ".xml"))
            {
                seri.Serialize(writer, list);
            }
        }

        /// <summary>
        /// Deserializes an *.xml file and turns it into a collection of elements
        /// </summary>
        /// <returns>A collection of objects of type T</returns>
        public static ObservableCollection<T> Deserialize()
        {
            ObservableCollection<T> result = new ObservableCollection<T>();
            XmlSerializer deseri = new XmlSerializer(typeof(ObservableCollection<T>));

            if (!File.Exists(Path + typeof(T).ToString() + ".xml"))
            {
                Serialize(new ObservableCollection<T>());
            }

            using (TextReader reader = new StreamReader(Path + typeof(T).ToString() + ".xml"))
            {
                result = deseri.Deserialize(reader) as ObservableCollection<T>;
            }

            return result;
        }
    }
}
