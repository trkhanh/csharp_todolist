namespace ToDoList.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Input;
    using ToDoList.Commands;
    using ToDoList.Models;

    /// <summary>
    /// View model for all objects of type ToDoList.Models.Meeting
    /// </summary>
    public class MeetingViewModel : BaseViewModel<Meeting>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeetingViewModel"/> class
        /// </summary>
        public MeetingViewModel()
            : base()
        {
            this.SortItems = new RelayCommand(this.Sort);
            this.itemPool = DataTranslator<Meeting>.Deserialize();
        }

        /// <summary>
        /// Gets or sets a command for sorting all meetings by the time of their happening
        /// </summary>
        public ICommand SortItems { get; set; }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            // Handle closing logic, set e.Cancel as needed
            // tried to set event on closing the window, but it's not working

            // MessageBox.Show("Exit The Project");
        }

        private void Sort(object obj)
        {
            ObservableCollection<Meeting> sorted = new ObservableCollection<Meeting>();
            sorted = new ObservableCollection<Meeting>(this.itemPool.OrderBy(meeting => meeting.EventDate)
                                                                    .ThenBy(meeting => meeting.StartTime));
            this.Items = sorted;
        }
    }
}
