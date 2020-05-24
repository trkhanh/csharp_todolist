namespace ToDoList.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Data;
    using System.Windows.Input;
    using ToDoList.Commands;
    using ToDoList.Models;

    /// <summary>
    /// View model for all objects of type ToDoList.Models.Goal
    /// </summary>
    public class GoalViewModel : BaseViewModel<Goal>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoalViewModel"/> class
        /// </summary>
        public GoalViewModel()
            : base()
        {
            this.SortItems = new RelayCommand(this.HandleSortItems);
            this.AddNewSubtask = new RelayCommand(this.HandleAddNewSubtask);
            this.DeleteSubtask = new RelayCommand(this.HandleDeleteSubtask);
            this.itemPool = DataTranslator<Goal>.Deserialize();
        }

        /// <summary>
        /// Gets or sets a command to add new subtask to selected goal
        /// </summary>
        public ICommand AddNewSubtask { get; set; }

        /// <summary>
        /// Gets or sets a command to delete selected subtask from selected goal
        /// </summary>
        public ICommand DeleteSubtask { get; set; }

        /// <summary>
        /// Gets or sets a command for sorting all goals by their deadline
        /// </summary>
        public ICommand SortItems { get; set; }

        /// <summary>
        /// Looks for a certain sequence of characters in the titles, descriptions, or tags of all goals and subtasks
        /// </summary>
        /// <param name="query">The sequence of characters that are being sought</param>
        public override void Filter(string query)
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
                        var currentItem = item as Goal;

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

                        foreach (var subtask in currentItem.Subtasks)
                        {
                            if (subtask.Title.ToLower().Contains(queryToLower) ||
                                subtask.Description.ToLower().Contains(queryToLower))
                            {
                                return true;
                            }

                            foreach (var tag in subtask.Tags)
                            {
                                if (tag.ToLower().Contains(queryToLower))
                                {
                                    return true;
                                }
                            }
                        }

                        return currentItem.Title.ToLower().Contains(queryToLower) ||
                               currentItem.Description.ToLower().Contains(queryToLower);
                    };
            }
        }

        /// <summary>
        /// Method for handling adding of a new subtask to selected goal
        /// </summary>
        private void HandleAddNewSubtask(object obj)
        {
            var view = CollectionViewSource.GetDefaultView(this.itemPool);
            int index = this.itemPool.IndexOf(view.CurrentItem as Goal);
            this.itemPool[index].AddSubtask(new Goal(string.Empty, string.Empty, itemPool[index].EventDate));
        }

        /// <summary>
        /// Method for handling deleting of a subtask from selected goal
        /// </summary>
        private void HandleDeleteSubtask(object obj)
        {
            var view = CollectionViewSource.GetDefaultView(this.itemPool);
            int index = this.itemPool.IndexOf(view.CurrentItem as Goal);
            var subview = CollectionViewSource.GetDefaultView(this.itemPool[index].Subtasks);
            var selected = subview.CurrentItem as Goal;
            this.itemPool[index].RemoveSubtask(selected);
        }

        /// <summary>
        /// Method for handling sorting of all the goals
        /// </summary>
        private void HandleSortItems(object obj)
        {
            ObservableCollection<Goal> sorted = new ObservableCollection<Goal>();
            sorted = new ObservableCollection<Goal>(this.itemPool.OrderBy(goal => goal.EventDate)
                                                                 .ThenByDescending(goal => goal.Priority));
            this.Items = sorted;
        }
    }
}
