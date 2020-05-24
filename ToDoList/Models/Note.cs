namespace ToDoList.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Simple task containing a title and a description
    /// </summary>
    public class Note : BaseObjectModel
    {
        /// <summary>
        /// A collection of objects of type <see cref="Note"/>
        /// </summary>
        private ObservableCollection<Note> notes;

        // public string Description { get; set; } <- Note inherits this property from BaseObjectModel
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Note"/> class
        /// <para>Simple task containing a title and a description</para>
        /// </summary>
        public Note()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Note"/> class
        /// <para>Simple task containing a title and a description</para>
        /// </summary>
        /// <param name="title">The note's title</param>
        /// <param name="description">The note's description</param>
        public Note(string title, string description)
            : base(title, description)
        {
        }

        /// <summary>
        /// Method for adding an object of type <see cref="Note"/> to a collection
        /// </summary>
        /// <param name="note">Note that is to be added to the collection</param>
        public void AddNote(Note note)
        {
            if (!this.notes.Contains(note))
            {
                this.notes.Add(note);
            }
        }

        /// <summary>
        /// Method for removing an object of type <see cref="Note"/> from a collection
        /// </summary>
        /// <param name="note">Note that is to be removed from the collection</param>
        public void RemoveNote(Note note)
        {
            if (this.notes.Contains(note))
            {
                this.notes.Remove(note);
            }
        }

        /// <summary>
        /// Returns the description of this instance of <see cref="Note"/> as a string
        /// </summary>
        /// <returns>A string representation of this object</returns>
        public override string ToString()
        {
            return string.Format("{0}", this.Description);
        }
    }
}
