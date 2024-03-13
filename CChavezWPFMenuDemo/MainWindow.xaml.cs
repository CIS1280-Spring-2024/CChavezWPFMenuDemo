using Microsoft.Win32;
using System.ComponentModel.Design;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;

namespace CChavezWPFMenuDemo
{

    //4.1.	WPF has many pre-defined commands.See https://msdn.microsoft.com/en-us/library/system.windows.input.applicationcommands(v=vs.110).aspx for a list of them
    //4.2.	Commands require an Execute and CanExecute method.The CanExecute method determines whether or not the command is enabled.A typical use case would be to check if all required fields are filled out by a user before enabling a command.When called, a CanExecute property is passed in with the CanExecuteRoutedEventArgs parameter. Setting CanExecute to true or false will enable or disable the command. We want our command to execute no matter what, so we will just set this equal to true. If you wanted to make this dependent on some logic, you could write code to figure out whether or not to enable the command:

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("The New command was invoked");
        }

        // I left this inplace becasue the program was not recognizing the class in the namespace
        public static readonly RoutedUICommand Exit = new RoutedUICommand // Exit commannd Alt+F4 implemetation
        (
            "Exit",
            "Exit",
            typeof(MainWindow),
            new InputGestureCollection()
            {
                new KeyGesture(Key.F4, ModifierKeys.Alt)
            }

        );
        private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                MessageBox.Show("You opened a file: " + openFileDialog.FileName);
                txbEditor.Text = File.WriteAllText(openFileDialog.FileName);
            }
        }
        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                MessageBox.Show("You opened a file: " + openFileDialog.FileName);
                txbEditor.Text = File.ReadAllText(openFileDialog.FileName);
            }

        }

    }
}