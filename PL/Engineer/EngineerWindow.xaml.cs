using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BO;
using DalApi;
using DO;
using PL.Engineer;

namespace PL.Engineer;

/// <summary>
/// Interaction logic for EngineerWindow.xaml
/// </summary>
public partial class EngineerWindow : Window
{
    static readonly BlApi.IBl s_bl = BlApi.Factory.Get();

    public EngineerWindow(int Id = 0)
    {
        InitializeComponent();
        CurrentEngineer = Id == 0 ? s_bl?.Engineer.Read(Id) : null;
    //    if (Id == 0)
    //    {
    //        CurrentEngineer = new BO.Engineer
    //        {
    //        };
    //    }
    //    else
    //        CurrentEngineer = s_bl?.Engineer.Read(Id);
    }
    public BO.Engineer CurrentEngineer
    {
        get { return (BO.Engineer)GetValue(CurrentEngineerProperty); }
        set { SetValue(CurrentEngineerProperty, value); }
    }

    public static readonly DependencyProperty CurrentEngineerProperty =
        DependencyProperty.Register("CurrentEngineer", typeof(BO.Engineer), typeof(EngineerWindow), new PropertyMetadata(null));

    private void btnAddUpdate_Click(object sender, SelectionChangedEventArgs e)
    {
        string content = (sender as Button)!.Content.ToString()!;
        try
        {
            if (content == "Add")
                s_bl.Engineer.Create(CurrentEngineer);
            else
                s_bl.Engineer.Update(CurrentEngineer);

        }
        catch (Exception ex) { }

    }
}
