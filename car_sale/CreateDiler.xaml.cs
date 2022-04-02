using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace car_sale
{
    /// <summary>
    /// Логика взаимодействия для CreateDiler.xaml
    /// </summary>
    public partial class CreateDiler : Page
    {
        public dilers dilers;
        public CreateDiler(dilers _dilers)
        {
            InitializeComponent();
            dilers = _dilers;
        }
        public void Creation(int id, string diler, string address, string phone)
        {
            StreamWriter database = new StreamWriter(@"dilers_data.txt", append: true);
            database.WriteLineAsync($"{id};{diler};{address};{phone}");
            database.Close();
        }
        private void CreateDiler_Button_Click(object sender, RoutedEventArgs e)
        {
            StreamReader database = new StreamReader(@"dilers_data.txt");
            int id = 0;
            string line;
            line = database.ReadLine();
            while (line != null)
            {
                if (line != null)
                {
                    string[] splitLine = line.Split(';');
                    id = int.Parse(splitLine[0]) + 1;
                }
                line = database.ReadLine();
            }
            database.Close();

            string diler = Diler_TextBox.Text;
            string address = Address_TextBox.Text;
            string phone = PhoneNumber_TextBox.Text;
            if (diler != "" & address != "" & phone != "")
            {
                Creation(id, diler, address, phone);
                dilers.OpenPage(dilers.pages.dilerlist);
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
    }
}
