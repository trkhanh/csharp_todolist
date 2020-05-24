namespace ToDoList.ViewModels
{
    /// <summary>
    /// Ensures that the class will allow filtering through a collection of objects
    /// </summary>
    public interface IFilterable
    {
        /// <summary>
        /// Looks for a certain sequence of characters in the list of entities
        /// </summary>
        /// <param name="query">The sequence of characters that are being sought</param>
        void Filter(string query);
    }
}
