using Lab9.BusinessLayer.Interfaces;
using Lab9.BusinessLayer.Models;
using Lab9.BusinessLayer.Services;
using Lab9.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<GroupViewModel> groups;
        IGroupService groupService;

        public MainWindow()
        {
            InitializeComponent();
            groupService = new GroupService("TestDbConnection");
            groups = groupService.GetAll();
            cBoxGroup.DataContext = groups;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var student = new StudentViewModel();
            student.DateOfBirth = new DateTime(1990, 01, 01);
            var dialog = new EditStudent(student);
            var result = dialog.ShowDialog();
            if (result == true)
            {
                var group = (GroupViewModel)cBoxGroup.SelectedItem;
                group.Students.Add(student);
                groupService.AddStudentToGroup(group.GroupId, student);
                dialog.Close();
            }
        }
    }
}
