using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lesson_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        private ObservableCollection<Employee> Wor = new ObservableCollection<Employee>();
        private ObservableCollection<Depatment> Dep = new ObservableCollection<Depatment>();
        public MainWindow()
        {
            InitializeComponent();
            //FillList();
        }
        void FillList(object sender, RoutedEventArgs e)
        {
            Wor.Add(new Employee() { Id = 1, Name = "Тема", Age = 22, Salary = 3000 });
            Wor.Add(new Employee() { Id = 2, Name = "Миша", Age = 25, Salary = 6000 });
            Wor.Add(new Employee() { Id = 3, Name = "Ярик", Age = 23, Salary = 8000 });
            Worked.ItemsSource = Wor;

        }

        private void Worked_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            new Windowedd(Worked.SelectedItem as Employee).ShowDialog();
        }

        private void Workadd(object sender, RoutedEventArgs e)
        {
            Wor.Add(new Employee() { Id = 4, Name = "Sergey", Age = 26, Salary = 7000 });

        }

        private void WorkChange(object sender, RoutedEventArgs e)
        {
            if (Worked.SelectedItem != null)
                (Worked.SelectedItem as Employee).Salary = 10000;
        }

        private void DeleteWork(object sender, RoutedEventArgs e)
        {
            if (Worked.SelectedItem != null)
                Wor.Remove(Worked.SelectedItem as Employee);
        }



        void FillList1(object sender, RoutedEventArgs b)
        {
            Dep.Add(new Depatment() { NameDep = "Раб" });
            Dep.Add(new Depatment() { NameDep = "Погонщик" });
            Dep.Add(new Depatment() { NameDep = "Павтриарх" });
            Depatment.ItemsSource = Dep;
        }

        private void List_Selected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(e.Source.ToString());
        }

        

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(e.AddedItems[0].ToString());
        }


       
    }



}

public class Employee : INotifyPropertyChanged
{
    public int Id { get; set; }
    private double age;
    public double Age
    {
        get { return this.age; }
        set
        {
            if (this.age != value)
            {
                this.age = value;
                this.NotifyPropertyChanged("Age");
            }
        }
    }
    private string name;
    public string Name
    {
        get { return this.name; }
        set
        {
            if (this.name != value)
            {
                this.name = value;
                this.NotifyPropertyChanged("Name");
            }
        }
    }
  


    //public double Salary { get; set; }
    public override string ToString()
    {
        return $"{Id}\t{Name}\t{Age}\t{Salary}";
    }
    private double salary;
    public double Salary
    {
        get { return this.salary; }
        set
        {
            if (this.salary != value)
            {
                this.salary = value;
                this.NotifyPropertyChanged("Salary");
            }
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public void NotifyPropertyChanged(string propName)
    {
        if (this.PropertyChanged != null)
            this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
    }
}


public class Depatment
    {
        public string NameDep { get; set; }
        public override string ToString()
        {
            return $"{NameDep}\t";
        }
}




 