using BO;
using PL.Engineer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    public IEnumerable<BO.TaskInList> TaskList
    {
        get { return (IEnumerable<BO.TaskInList>)GetValue(TaskListProperty); }
        set { SetValue(TaskListProperty, value); }
    }

    public static readonly DependencyProperty TaskListProperty =
        DependencyProperty.Register("TaskList", typeof(IEnumerable<BO.TaskInList>), typeof(TaskListWindow), new PropertyMetadata(null));

    private IEnumerable<BO.TaskInList> TaskToList(IEnumerable<BO.Task> tasks)
    {
        return (from BO.Task task in tasks
                select new TaskInList { ID = task.ID, Nickname = task.Nickname, Description = task.Description, Status = task.TaskStatus }).ToList();
    }

    private void cbTaskSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        TaskList = TaskToList(s_bl?.Task.ReadAll(Status));
    }

    private void btnAddTask_Click(object sender, RoutedEventArgs e)
    {
        new TaskWindow().ShowDialog();
    }

    private void UpdateTask(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        BO.TaskInList? TaskInList = (sender as ListView)?.SelectedItem as BO.TaskInList;
        new TaskWindow(TaskInList.ID).ShowDialog();
    }
}
