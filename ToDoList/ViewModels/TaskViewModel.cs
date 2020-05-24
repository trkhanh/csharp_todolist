namespace ToDoList.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using ToDoList.Commands;
    using ToDoList.Models;

    /// <summary>
    /// View model for all objects of type ToDoList.Models.Task
    /// </summary>
    public class TaskViewModel : BaseViewModel<Task>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskViewModel"/> class
        /// </summary>
        public TaskViewModel()
            : base()
        {
            this.SortItems = new RelayCommand(this.HandleSortItems);
            this.itemPool = DataTranslator<Task>.Deserialize();
        }

        /// <summary>
        /// Gets or sets a command for sorting all tasks by their priority
        /// </summary>
        public ICommand SortItems { get; set; }

        /// <summary>
        /// Method for handling sorting of all the tasks
        /// </summary>
        private void HandleSortItems(object obj)
        {
            ObservableCollection<Task> sorted = new ObservableCollection<Task>();
            sorted = new ObservableCollection<Task>(this.itemPool.OrderByDescending(task => task.Priority));
            this.Items = sorted;
        }
    }
}
