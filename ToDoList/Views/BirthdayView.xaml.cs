namespace ToDoList.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using ToDoList.ViewModels;

    /// <summary>
    /// Interaction logic for BirthdayView.xaml
    /// </summary>
    public partial class BirthdayView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BirthdayView"/> class
        /// </summary>
        public BirthdayView()
        {
            this.InitializeComponent();
        }

        private void TextBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            var filterText = this.TextBoxSearch.Text;

            if (filterText != null)
            {
                (this.DataContext as BirthdayViewModel).Filter(filterText);
            }
        }

        private void ListBoxTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
