using BO;
using System;
using System.Buffers.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace PL.Task;

/// <summary>
/// Interaction logic for TaskWindow.xaml
/// </summary>
public partial class TaskWindow : Window
{
    static readonly BlApi.IBl s_bl = BlApi.Factory.Get();

    //Defines a property named CurrentTask, which is bound to the TaskProperty dependency property.
    public BO.Task CurrentTask
    {
        get { return (BO.Task)GetValue(TaskProperty); }
        set { SetValue(TaskProperty, value); }
    }
    //Defines a dependency property named CurrentTask for data binding in TaskWindow, specifying its type as BO.Task.
    public static readonly DependencyProperty TaskProperty =
        DependencyProperty.Register("CurrentTask", typeof(BO.Task), typeof(TaskWindow), new PropertyMetadata(null));

    //The constructor initializes window components and either creates a new Task object with default values or attempts to retrieve task details from the business logic layer based on the provided ID.
    public TaskWindow(int Id = 0)
    {
        InitializeComponent();
        if(Id == 0)
        {
            CurrentTask = new BO.Task
            {
                ID = 0,
                Nickname = "",
                Description = "",
                Production = new(),
                TaskStatus = 0,
                TaskList = null,
                RelatedMilestone = null,
                EstimatedStartDate = new(),
                AcualStartNate = new(),
                EstimatedEndDate = new(),
                deadline = new(),
                AcualEndNate = new(),
                Product = "",
                Remaeks = "",
                EngineerIdName = new BO.TasksEngineer { ID = 0, Name = ""},
                Difficulty = 0
            };
        }
        else
        {
            CurrentTask = s_bl?.Task.Read(Id);
        }
    }
    // The function adds or updates a task in the business logic layer. Any error is caught and ignored
    private void btnAddUpdate_Click(object sender, RoutedEventArgs e)
    {
        string content = (sender as Button)!.Content.ToString()!;

        try
        {
            if (content == "Add")
            {
                int id = s_bl.Task.Create(CurrentTask);
                MessageBox.Show($"Task with id={id} was successfully added!");
            }
            else
            {
                s_bl.Task.Update(CurrentTask);
                MessageBox.Show($"Task with id={CurrentTask.ID} was successfully added!");
            }
        }
        catch (BlAlreadyExistsException ex)
        {
            MessageBox.Show(ex.Message);
        }
        catch (BlDoesNotExistException ex)
        {
            MessageBox.Show(ex.Message);
        }

        this.Close();
    }
}
