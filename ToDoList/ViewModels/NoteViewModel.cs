namespace ToDoList.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using ToDoList.Commands;
    using ToDoList.Models;

    /// <summary>
    /// View model for all objects of type ToDoList.Models.Note
    /// </summary>
    public class NoteViewModel : BaseViewModel<Note>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoteViewModel"/> class
        /// </summary>
        public NoteViewModel()
            : base()
        {
            this.SortItems = new RelayCommand(this.HandleSortItems);
            this.itemPool = DataTranslator<Note>.Deserialize();
        }

        /// <summary>
        /// Gets or sets a command for sorting all notes by their title
        /// </summary>
        public ICommand SortItems { get; set; }

        /// <summary>
        /// Method for handling sorting of all the notes
        /// </summary>
        private void HandleSortItems(object obj)
        {
            ObservableCollection<Note> sorted = new ObservableCollection<Note>();
            sorted = new ObservableCollection<Note>(this.itemPool.OrderBy(note => note.Title));
            this.Items = sorted;
        }
    }
}
