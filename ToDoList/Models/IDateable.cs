namespace ToDoList.Models
{
    using System;

    /// <summary>
    /// Makes sure an object has a DateTime property 'EventDate'
    /// </summary>
    public interface IDateable
    {
        /// <summary>
        /// Gets or sets the date of the event
        /// </summary>
        DateTime EventDate { get; set; }
    }
}
