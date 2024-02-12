
using System.Windows;
using PL.Engineer;
using PL.Task;

namespace PL;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void btnEngineers_Click(object sender, RoutedEventArgs e)
    {
        new EngineerListWindow().Show();
    }
    private void btnTasks_Click(object sender, RoutedEventArgs e)
    {
        new TaskListWindow().Show();
    }
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
