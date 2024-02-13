
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
    public EngineerListWindow()
    {
        InitializeComponent();
        this.DataContext = this;
        EngineerList = EngineerToList(s_bl?.Engineer.ReadAll()!);
    }
    public IEnumerable<BO.EngineerInList> EngineerList
    {
        get { return (IEnumerable<BO.EngineerInList>)GetValue(EngineerListProperty); }
        set { SetValue(EngineerListProperty, value); }
    }

    public static readonly DependencyProperty EngineerListProperty =
            DependencyProperty.Register("EngineerList", typeof(IEnumerable<BO.EngineerInList>), typeof(EngineerListWindow), new PropertyMetadata(null));

    //private void cbEngineerSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //{
    //    var tempEngineerList = LevelEngineer == BO.EngineerLevelEnum.None ?
    //                EngineerToList(s_bl?.Engineer.ReadAll()) :
    //                EngineerToList(s_bl?.Engineer.ReadAll(LevelEngineer));
    //    EngineerList = tempEngineerList == null ? new() : new(tempEngineerList);
    //}

    private IEnumerable<BO.EngineerInList> EngineerToList(IEnumerable<BO.Engineer> engineers)
    {
        return (from BO.Engineer engineer in engineers
                select new EngineerInList { Name = engineer.Name, Email = engineer.Email }).ToList();
    }

    private void cbEngineerSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        EngineerList = EngineerToList(s_bl?.Engineer.ReadAll(EngineerLevelEnum));
    }
    private void btnAddEngineer_Click(object sender, RoutedEventArgs e)
    {
        new EngineerWindow().Show();
    }

}

