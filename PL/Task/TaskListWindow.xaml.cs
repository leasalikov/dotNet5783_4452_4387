using BO;
using PL.Engineer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PL.Task;

/// <summary>
/// Interaction logic for TaskListWindow.xaml
/// </summary>
public partial class TaskListWindow : Window
{
    static readonly BlApi.IBl s_bl = BlApi.Factory.Get();
    public BO.Status Status { get; set; } = BO.Status.All;
    //The constructor initializes the window components and populates TaskList with data from the business logic layer.
    public TaskListWindow()
    {
        InitializeComponent();
        try
        {
            TaskList = TaskToList(s_bl?.Task.ReadAll()!);
        }
        catch
        { }
    }
    //Defines a property named TaskList, used to get and set the value of the TaskList dependency property.
    public IEnumerable<BO.TaskInList> TaskList
    {
        get { return (IEnumerable<BO.TaskInList>)GetValue(TaskListProperty); }
        set { SetValue(TaskListProperty, value); }
    }
    //Defines a dependency property named TaskList, used to bind a collection of TaskInList objects to a TaskListWindow.
    public static readonly DependencyProperty TaskListProperty =
        DependencyProperty.Register("TaskList", typeof(IEnumerable<BO.TaskInList>), typeof(TaskListWindow), new PropertyMetadata(null));
    //Converts a collection of tasks to displayable format for UI.
    private IEnumerable<BO.TaskInList> TaskToList(IEnumerable<BO.Task> tasks)
    {
        return (from BO.Task task in tasks
                select new TaskInList { ID = task.ID, Nickname = task.Nickname, Description = task.Description, Status = task.TaskStatus }).ToList();
    }
    //The function filters the tasks by status
    private void cbTaskSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        TaskList = TaskToList(s_bl?.Task.ReadAll(Status));
    }
    //The function showes the TaskWindow window
    private void btnAddTask_Click(object sender, RoutedEventArgs e)
    {
        new TaskWindow().ShowDialog();
        TaskList = TaskToList(s_bl?.Task.ReadAll()!);
    }
    // The function updates the task according to data user choise
    private void UpdateTask(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        BO.TaskInList? TaskInList = (sender as ListView)?.SelectedItem as BO.TaskInList;
        new TaskWindow(TaskInList.ID).ShowDialog();
        TaskList = TaskToList(s_bl?.Task.ReadAll()!);
    }
}
