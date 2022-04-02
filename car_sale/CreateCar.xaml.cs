using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace car_sale
{
    /// <summary>
    /// Логика взаимодействия для CreateCar.xaml
    /// </summary>
    public partial class CreateCar : Page
    {
        public Cars cars;
        public CreateCar(Cars _cars)
        {
            InitializeComponent();
            cars = _cars;
            string[] dilers = TakeInfo();
            foreach (string s in dilers)
            {
                Diler_Combo.Items.Add(s);
            }
        }
        public string[] TakeInfo()
        {
            StreamReader database = new StreamReader(@"dilers_data.txt");
            string[] dilers = File.ReadAllLines(@"dilers_data.txt").ToArray();
            string line;
            line = database.ReadLine();
            for (int i = 0; i < dilers.Length; i++)
            {
                string[] splitLine = line.Split(';');
                dilers[i] = splitLine[1];
                line = database.ReadLine();
            }
            database.Close();
            return dilers;
        }
        public void Creation(int id, string car, string mileage, string diler, string price)
        {
            StreamWriter database = new StreamWriter(@"cars_data.txt", append: true);
            database.WriteLineAsync($"{id};{car};{mileage};{diler};{price}");
            database.Close();
        }
        private void CreateCar_Button_Click(object sender, RoutedEventArgs e)
        {
            StreamReader database = new StreamReader(@"cars_data.txt");
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

            string car = Car_TextBox.Text;
            string mileage = Mileage_TextBox.Text;
            string diler = Diler_Combo.Text;
            string price = Price_TextBox.Text;
            if (car != "" & mileage != "" & price != "")
            {
                Creation(id, car, mileage, diler, price);
                cars.OpenPage(Cars.pages.carList);
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
    }
}
