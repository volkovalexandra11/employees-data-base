using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MySql.Data.MySqlClient;

namespace WpfApplication1
{
    public partial class Test
    {
        private EmployeeContext db = new EmployeeContext();
        private static string __hack = typeof(SqlProviderServices).ToString();
        public Test()
        {
            InitializeComponent();
            
            // const string connStr = "server=localhost;user=root;database=employees;password=NSt17082001;";
            // var conn = new MySqlConnection(connStr);
            // conn.Open();
            // var query = "SELECT surname, name, second_name FROM employees";
            // var command = new MySqlCommand(query, conn);
            // var reader = command.ExecuteReader();
            // while (reader.Read())
            // {
            //     //Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2]);
            //     var emp = new Employee(reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
            //     employees.Add(emp);
            // }
            // conn.Close();

            employees = db.Employees.ToList();
            
            var empData = new ObservableCollection<Employee>(employees);
            Dg1.DataContext = empData;
        }
        
        
        readonly List<Employee> employees = new List<Employee>();

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var addingWindow = new AddingEmployeeWindow();
            addingWindow.Show();
            Close();
        }

        private void ButtonDel_OnClick(object sender, RoutedEventArgs e)
        {
            if (Dg1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Выберите сотрудника для удаления", "Ничего не выбрано", MessageBoxButton.OK);
            }

            if (Dg1.SelectedCells.Count > 3)
            {
                MessageBox.Show("Можно удалять только одного сотрудника за раз", "Больше одного", MessageBoxButton.OK);
            }

            var surn = Dg1.SelectedCells[0].Item.ToString();
            var name = Dg1.SelectedCells[1].Item.ToString();
            var secN = Dg1.SelectedCells[2].Item.ToString();
            
            // const string connectionString = "server=localhost;user=root;database=employee;password=NSt17082001;";
            // var connection = new MySqlConnection(connectionString);
            // const string query = "delete from employee where idStudentInfo=\'" + this.IdTextBox.Text + "';"; 
            // var command = new MySqlCommand(query, connection);
            // command.ExecuteNonQuery();
            // connection.Close();
        }
    }
}