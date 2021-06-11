using System.Configuration;
using System.Windows;
using System.Windows.Media;
using MySql.Data.MySqlClient;

namespace WpfApplication1
{
    public partial class AddingEmployeeWindow : Window
    {
        public AddingEmployeeWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var surname = Surname.Text;
            var name = Name.Text;
            var secName = SecondName.Text;

            if (surname == "")
            {
                Surname.ToolTip = "Введите фамилию";
                Surname.Background = Brushes.Red;
            }
            
            else if (name == "")
            {
                Surname.ToolTip = "Введите имя";
                Surname.Background = Brushes.Red;
            }

            else
            {
                Surname.ToolTip = "";
                Surname.Background = Brushes.Transparent;
                
                Name.ToolTip = "";
                Name.Background = Brushes.Transparent;
                
                SecondName.ToolTip = "";
                SecondName.Background = Brushes.Transparent;
            }
            
            const string connStr = "server=localhost;user=root;database=employees;password=NSt17082001;";
            var conn = new MySqlConnection(connStr);
            conn.Open();
            var comm = conn.CreateCommand();
            comm.CommandText = "INSERT INTO employees (surname, name, second_name) VALUES(@surname, @name, @second_name)";
            comm.Parameters.AddWithValue("@surname", surname);
            comm.Parameters.AddWithValue("@name", name);
            comm.Parameters.AddWithValue("@second_name", secName);
            comm.ExecuteNonQuery();
            conn.Close();

            var startWindow = new Test();
            startWindow.Show();
            
            this.Close();
        }
    }
}