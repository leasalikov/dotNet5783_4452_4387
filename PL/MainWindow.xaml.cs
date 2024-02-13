
using System.CodeDom.Compiler;
using System.Windows;
using PL.Engineer;
using PL.Task;

namespace PL;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    //MainWindow constractor
    public MainWindow()
    {
        InitializeComponent();
    }
    //The function showes EngineerListWindow window
    private void btnEngineers_Click(object sender, RoutedEventArgs e)
    {
        new EngineerListWindow().Show();
    }
    //The function showes TaskListWindow window
    private void btnTasks_Click(object sender, RoutedEventArgs e)
    {
        new TaskListWindow().Show();
    }

    //The function prompts a confirmation message for initializing the database and executes the initialization if the user confirms, displaying a success message afterward.
    private void btnInitDB_Click(object sender, RoutedEventArgs e)
    {
        MessageBoxResult result = MessageBox.Show("Are you sure you want to initialize the DB?", "yes", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (result == MessageBoxResult.Yes)
        {
            DalTest.Initialization.Do();
            MessageBox.Show("The DB has been successfully initialized!", "massege");
        }
    }
}
