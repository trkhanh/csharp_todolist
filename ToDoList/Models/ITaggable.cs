namespace ToDoList.Models
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// Makes sure an object has a collection of descriptive strings ('tags')
    /// </summary>
    public interface ITaggable
    {
        /// <summary>
        /// Gets or sets a collection of descriptive strings
        /// </summary>
        ObservableCollection<string> Tags { get; set; }
    }
}
