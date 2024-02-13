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
    //Defines a property named CurrentEngineer, which is bound to the CurrentEngineerProperty dependency property.
    public BO.Engineer CurrentEngineer
    {
        get { return (BO.Engineer)GetValue(EngineerProperty); }
        set { SetValue(EngineerProperty, value); }
    }
    //Defines a dependency property named CurrentEngineer for data binding in EngineerWindow, specifying its type as BO.Engineer.

    public static readonly DependencyProperty EngineerProperty =
        DependencyProperty.Register("CurrentEngineer", typeof(BO.Engineer), typeof(EngineerWindow), new PropertyMetadata(null));
    //The constructor initializes window components and either creates a new Engineer object with default values or attempts to retrieve Engineer details from the business logic layer based on the provided ID.

    public EngineerWindow(int Id = 0)
    {
        InitializeComponent();
        if (Id == 0)
        {
            CurrentEngineer = new BO.Engineer
            {
                ID = 0,
                Name = "",
                Email = "",
                EngineerLevel = 0,
            };
        }
        else
        {
            CurrentEngineer = s_bl?.Engineer.Read(Id);
        }
    }
    // The function adds or updates a Engineer in the business logic layer. Any error is caught and ignored
    private void btnAddUpdate_Click(object sender, RoutedEventArgs e)
    {
        string content = (sender as Button)!.Content.ToString()!;
        try
        {
            if (content == "Add")
            {
                int id = s_bl.Engineer.Create(CurrentEngineer);
                MessageBox.Show($"Engineer with id={id} was successfully added!");
            }
            else
            {
                s_bl.Engineer.Update(CurrentEngineer);
                MessageBox.Show($"Engineer with id={CurrentEngineer.ID} was successfully updated!");
            }
            this.Close();

        }
        catch (Exception ex) { }

    }
}
