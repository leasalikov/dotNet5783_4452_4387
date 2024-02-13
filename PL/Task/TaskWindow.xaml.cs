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
                EngineerIdName = null,
                Difficulty = 0
            };
        }
        else
        {
            CurrentTask = Id == 0 ? s_bl?.Task.Read(Id) : null;
        }
    }
    //Defines a property named CurrentTask, which is bound to the CurrentTaskProperty dependency property.
    public BO.Task CurrentTask
    {
        get { return (BO.Task)GetValue(CurrentTaskProperty); }
        set { SetValue(CurrentTaskProperty, value); }
    }
    //Defines a dependency property named CurrentTask for data binding in TaskWindow, specifying its type as BO.Task.
    public static readonly DependencyProperty CurrentTaskProperty =
        DependencyProperty.Register("CurrentTask", typeof(BO.Task), typeof(TaskWindow), new PropertyMetadata(null));
    // The function adds or updates a task in the business logic layer. Any error is caught and ignored
    private void btnAddUpdate_Click(object sender, RoutedEventArgs e)
    {
        string content = (sender as Button)!.Content.ToString()!;

        try
        {
            if (content == "Add")
                s_bl.Task.Create(CurrentTask);
            else
                s_bl.Task.Update(CurrentTask);

        }
        catch (Exception ex) { }
    }
}
