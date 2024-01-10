
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BO;
using DalApi;

namespace PL.Engineer
{
    /// <summary>
    /// Interaction logic for EngineerListWindow.xaml
    /// </summary>
    public partial class EngineerListWindow : Window
    {
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();
        public EngineerListWindow()
        {
            InitializeComponent();
            var temp = (from engineer in s_bl.Engineer.ReadAll()
                        select new EngineerInList { Name = engineer.Name, Email = engineer.Email }).ToList();
            EngineerList = temp == null ? new() : new(temp);
        }

        public ObservableCollection<BO.EngineerInList> EngineerList
        {
            get { return (ObservableCollection<BO.EngineerInList>)GetValue(EngineerListProperty); }
            set { SetValue(EngineerListProperty, value); }
        }

        public static readonly DependencyProperty EngineerListProperty =
            DependencyProperty.Register("EngineerList", typeof(ObservableCollection<BO.EngineerInList>), typeof(EngineerListWindow), new PropertyMetadata(null));

        private void cbEngineerSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var temp = EngineerList == BO.EngineerLevelEnum.None ?
            s_bl?.Engineer.ReadAll() :
            s_bl?.Engineer.ReadAll(item => item.InEngineer == Engineer);
            EngineerInList = temp == null ? new() : new(temp);
        }

        //private void cbSemesterSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var temp = Semester == BO.SemesterNames.None ?
        //    s_bl?.Course.ReadAll() :
        //    s_bl?.Course.ReadAll(item => item.InSemester == Semester);
        //    CourseList = temp == null ? new() : new(temp);
        //}
    }
}


