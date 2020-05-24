namespace ToDoList
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;
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
    using ToDoList.Models;
    using ToDoList.ViewModels;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // tried to implement serialization on all objects on closing the window, but was not able
            // TODO Implement writing the info in the xml files
            // Can't figure out how to pass the itemPool here, so it can be serialized
            // var temp = new MeetingViewModel();
            // DataTranslator<MeetingViewModel>.Serialize(temp.Items);
            // MessageBox.Show("Wow");
        }
    }
}
