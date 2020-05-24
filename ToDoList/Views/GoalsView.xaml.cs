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
    /// Interaction logic for GoalsView.xaml
    /// </summary>
    public partial class GoalsView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoalsView"/> class
        /// </summary>
        public GoalsView()
        {
            this.InitializeComponent();
        }

        private void TextBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            var filterText = this.TextBoxSearch.Text;

            if (filterText != null)
            {
                (this.DataContext as GoalViewModel).Filter(filterText);
            }
        }
    }
}
