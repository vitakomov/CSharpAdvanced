using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Employee> empoyees = new ObservableCollection<Employee>();
        ObservableCollection<Department> departments = new ObservableCollection<Department>();
        public MainWindow()
        {
            InitializeComponent();
            FillList();
        }
        void FillList()
        {
            empoyees.Add(new Employee() { Id = 1, Name = "Vasya", Age = 22, Salary = 3000 });
            empoyees.Add(new Employee() { Id = 2, Name = "Petya", Age = 25, Salary = 6000 });
            empoyees.Add(new Employee() { Id = 3, Name = "Kolya", Age = 23, Salary = 8000 });
            lbEmployee.ItemsSource = empoyees;
            departments.Add(new Department() { Id = 1, Name = "It", Size = 3});
            departments.Add(new Department() { Id = 2, Name = "Design", Size = 5});
            departments.Add(new Department() { Id = 3, Name = "Logistic", Size = 4});
            lbDepartment.ItemsSource = departments;
        }
        private void lbEmployee_Selected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(e.Source.ToString());
        }
        private void lbEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(e.AddedItems[0].ToString());
        }
        private void lbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(e.AddedItems[0].ToString());
        }
        private void Button_Click_Employee(object sender, RoutedEventArgs e)
        {
            empoyees.Add(new Employee() { Id = empoyees.Count + 1, Name = tbName.Text, Age = int.Parse(tbAge.Text), Salary = int.Parse(tbSalary.Text) });
        }
        private void Button_Click_Department(object sender, RoutedEventArgs e)
        {
            departments.Add(new Department() { Id = departments.Count + 1, Name = tbName.Text, Size = int.Parse(tbSize.Text) });
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public override string ToString()
        {
            return $"{Id}\t{Name}\t{Age}\t{Salary}";
        }

    }
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public override string ToString()
        {
            return $"{Id}\t{Name}\t{Size}";
        }
    }
}
