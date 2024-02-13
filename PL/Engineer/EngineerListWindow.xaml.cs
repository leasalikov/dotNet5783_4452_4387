
using BO;
using PL.Task;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PL.Engineer;

/// <summary>
/// Interaction logic for EngineerListWindow.xaml
/// </summary>
public partial class EngineerListWindow : Window
{
    public BO.EngineerLevelEnum EngineerLevelEnum { get; set; } = BO.EngineerLevelEnum.None;
    static readonly BlApi.IBl s_bl = BlApi.Factory.Get();
    //The constructor initializes the window components and populates EngineerList with data from the business logic layer.
    public EngineerListWindow()
    {
        InitializeComponent();
        //DataContext = this;
        EngineerList = EngineerToList(s_bl?.Engineer.ReadAll()!);
    }
    //Used to get and set the value of the EngineerList dependency property.
    public IEnumerable<BO.EngineerInList> EngineerList
    {
        get { return (IEnumerable<BO.EngineerInList>)GetValue(EngineerListProperty); }
        set { SetValue(EngineerListProperty, value); }
    }
    //Defines a dependency property named EngineerList, used to bind a collection of EngineerInList objects to a EngineerListWindow.

    public static readonly DependencyProperty EngineerListProperty =
            DependencyProperty.Register("EngineerList", typeof(IEnumerable<BO.EngineerInList>), typeof(EngineerListWindow), new PropertyMetadata(null));
    //Converts a collection of Engineers to displayable format for UI.
    private IEnumerable<BO.EngineerInList> EngineerToList(IEnumerable<BO.Engineer> engineers)
    {
        return (from BO.Engineer engineer in engineers
                select new EngineerInList { ID = engineer.ID, Name = engineer.Name, Email = engineer.Email }).ToList();
    }
    //The function filters the Engineers by Engineers Level
    private void cbEngineerSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        EngineerList = EngineerToList(s_bl?.Engineer.ReadAll(EngineerLevelEnum));
    }
    //The function showes the EngineerWindow window
    private void btnAddEngineer_Click(object sender, RoutedEventArgs e)
    {
        new EngineerWindow().ShowDialog();
        EngineerList = EngineerToList(s_bl?.Engineer.ReadAll()!);
    }
    // The function updates the Engineer according to data user choise
    private void UpdateEngineer(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        BO.EngineerInList? EngineerInList = (sender as ListView)?.SelectedItem as BO.EngineerInList;
        new EngineerWindow(EngineerInList.ID).ShowDialog();
        EngineerList = EngineerToList(s_bl?.Engineer.ReadAll()!);
    }
}

