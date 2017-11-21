using Lab9.BusinessLayer.Models;
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
using System.ComponentModel;

namespace Lab9.Dialogs
{
    /// <summary>
    /// Interaction logic for EditStudent.xaml
    /// </summary>
    public partial class EditStudent : Window
    {
        public EditStudent(StudentViewModel student)
        {
            InitializeComponent();
            student.FullName = "Student " + new Random().Next();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.DialogResult = true;
            base.OnClosing(e);
        }
    }
}
