namespace ToDoList.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Data;
    using System.Windows.Input;
    using ToDoList.Commands;
    using ToDoList.Models;

    /// <summary>
    /// Base ViewModel to address the common functionality of all Items
    /// <para>AddNewItem - for adding Items</para>
    /// <para>DeleteItem - for deleting Items</para>
    /// <para>SaveItem - for saving Items to xml file</para>
    /// <para>Filter - for searching within the Item collection</para>
    /// </summary>
    /// <typeparam name="T">Any successor of BaseObjectModel</typeparam>
    public class BaseViewModel<T> : IFilterable where T : BaseObjectModel, new()
    {
        /// <summary>
        /// A dynamic data collection that provides notifications when items get added, removed, 
        /// or when the whole list is refreshed.
        /// </summary>
        protected ObservableCollection<T> itemPool;

        /// <summary>
        /// Initializes a new instance of the <see cref="{T}" /> class.
        /// <para>A basic constructor for any view model</para>
        /// </summary>
        public BaseViewModel()
        {
            this.AddNewItem = new RelayCommand(this.HandleAddNewItem);
            this.DeleteItem = new RelayCommand(this.HandleDeleteItem);
            this.SaveItem = new RelayCommand(this.HandleSaveItem);
        }

        /// <summary>
        /// Gets or sets an enumeration of all items read from a database
        /// </summary>
        public IEnumerable<T> Items
        {
            get
            {
                return this.itemPool;
            }

            set
            {
                if (this.itemPool == null)
                {
                    this.itemPool = new ObservableCollection<T>();
                }

                this.itemPool.Clear();

                foreach (var item in value)
                {
                    this.itemPool.Add(item);
                }
            }
        }

        /// <summary>
        /// Gets or sets a command to add a new item to the itemPool
        /// </summary>
        public ICommand AddNewItem { get; set; }

        /// <summary>
        /// Gets or sets a command to delete a selected item from the itemPool
        /// </summary>
        public ICommand DeleteItem { get; set; }

        /// <summary>
        /// Gets or sets a command to save all the items currently in the itemPool
        /// </summary>
        public ICommand SaveItem { get; set; }

        /* Methods */

        /// <summary>
        /// Search for string within the titles and descriptions of the collection of items
        /// </summary>
        /// <param name="query">The string that is sought within the collection of items</param>
        public virtual void Filter(string query)
        {
            var itemView = CollectionViewSource.GetDefaultView(this.itemPool);

            if (query == string.Empty)
            {
                itemView.Filter = null;
            }
            else
            {
                var queryToLower = query.ToLower();

                itemView.Filter = (item) =>
                    {
                        var currentItem = item as T;

                        if (currentItem == null)
                        {
                            return false;
                        }

                        foreach (var tag in currentItem.Tags)
                        {
                            if (tag.ToLower().Contains(queryToLower))
                            {
                                return true;
                            }
                        }

                        return currentItem.Title.ToLower().Contains(queryToLower) ||
                               currentItem.Description.ToLower().Contains(queryToLower);
                    };
            }
        }

        /// <summary>
        /// Serialize the collection of Items into xml file
        /// </summary>
        private void HandleSaveItem(object obj)
        {
            DataTranslator<T>.Serialize(this.itemPool);
        }

        /// <summary>
        /// Delete selected item from the collection
        /// </summary>
        /// <param name="obj">Item to be deleted from the collection</param>
        private void HandleDeleteItem(object obj)
        {
            var view = CollectionViewSource.GetDefaultView(this.itemPool);
            var selected = view.CurrentItem as T;
            this.itemPool.Remove(selected);
        }

        /// <summary>
        /// Add new item to the itemPool
        /// </summary>
        /// <param name="obj">Item to be added to the itemPool</param>
        private void HandleAddNewItem(object obj)
        {
            this.itemPool.Add(new T());
        }
    }
}
