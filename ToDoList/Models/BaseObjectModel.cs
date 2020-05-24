namespace ToDoList.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Xml.Serialization;

    /// <summary>
    /// The basic class for ToDo list entities
    /// <para>Title - short description of entity</para>
    /// <para>Description - Description of the entity</para>
    /// <para>Tags - Multiple references describing the entity NotImplemented</para>
    /// </summary>
    public abstract class BaseObjectModel : INotifyPropertyChanged, ITaggable
    {
        /// <summary>
        /// A value indicating whether the to-do entity has been done or not
        /// </summary>
        private bool done;

        /// <summary>
        /// The entity's title
        /// </summary>
        private string title;

        /// <summary>
        /// A collection of descriptive labels for easy grouping of entities
        /// </summary>
        private ObservableCollection<string> tags;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseObjectModel"/> class
        /// <para>A Basic class for ToDo entities</para>
        /// </summary>
        public BaseObjectModel()
        {
            this.Title = "New Item";
            this.Description = "Description";
            this.Done = false;

            // this.Tags = new ObservableCollection<string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseObjectModel"/> class
        /// <para>A Basic class for ToDo entities</para>
        /// </summary>
        /// <param name="title">Title for the entity</param>
        /// <param name="description">Description for the entity</param>
        public BaseObjectModel(string title, string description)
        {
            this.Title = title;
            this.Description = description;
            this.Done = false;
        }

        /// <summary>
        /// Occurs when a property's value changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the entity's title
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.title = value;
                /* If property changes notify who is interested */
                this.OnPropertyChanged("Title");
            }
        }

        /// <summary>
        /// Gets or sets the entity's description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the to-do entity has been done or not
        /// </summary>
        public bool Done
        {
            get
            {
                return this.done;
            }

            set
            {
                this.done = value;

                /* If property changes notify who is interested */
                this.OnPropertyChanged("Done");
            }
        }

        /// <summary>
        /// Gets or sets a collection of labels for easy grouping of entities
        /// </summary>
        public ObservableCollection<string> Tags
        {
            get
            {
                if (this.tags == null)
                {
                    this.tags = new ObservableCollection<string>();
                }

                return this.tags;
            }

            set
            {
                this.tags.Clear();

                foreach (var tag in value)
                {
                    this.tags.Add(tag);
                }
            }
        }

        /// <summary>
        /// Returns all the information of this BaseObjectModel as a string
        /// </summary>
        /// <returns>A string representation of this object</returns>
        public override string ToString()
        {
            return string.Format(
                "[{0}]\n{1}\n{2}",
                this.Title,
                this.Description,
                string.Join("; ", this.Tags));
        }

        // Need this for XAML Two-Way Binding

        /// <summary>
        /// Notifies the PropertyChanged event that a property's value is changed
        /// </summary>
        /// <param name="propertyName">Name of the property as string</param>
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
