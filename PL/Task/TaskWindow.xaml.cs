using BO;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PL.Task;

/// <summary>
/// Interaction logic for TaskWindow.xaml
/// </summary>
public partial class TaskWindow : Window
{
    static readonly BlApi.IBl s_bl = BlApi.Factory.Get();
    public TaskWindow(int Id = 0)
    {
        InitializeComponent();
        CurrentTask = Id == 0 ? s_bl?.Task.Read(Id) : null;
    }


    public BO.Task CurrentTask
    {
        get { return (BO.Task)GetValue(CurrentTaskProperty); }
        set { SetValue(CurrentTaskProperty, value); }
    }

    public static readonly DependencyProperty CurrentTaskProperty =
        DependencyProperty.Register("CurrentTask", typeof(BO.Task), typeof(TaskWindow), new PropertyMetadata(null));

    private void btnAddUpdate_Click(object sender, SelectionChangedEventArgs e)
    {
        int taskId = (int)GetValue(ConvertIdToContentKeyProperty);
        if ((int)GetValue(ConverIdToContentKeyProperty) == 0)
        {

        }
        s_bl.Task.Update(CurrentTask);
        s_bl.Task.Create(CurrentTask);
        Console.WriteLine("jkjkjkjkjlllll");
    }



}
