using System;
using System.Collections.Generic;
using System.IO;
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

namespace car_sale
{
    /// <summary>
    /// Логика взаимодействия для CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : Page
    {
        public Orders orders;
        public CreateOrder(Orders _orders)
        {
            InitializeComponent();
            orders = _orders;

            string[] dilers = TakeInfoDilers();
            string[] cars = TakeInfoCars();
            foreach (string s in dilers)
                Diler_Combo.Items.Add(s);
            foreach (string s in cars)
                Cars_Combo.Items.Add(s);
        }
        public string[] TakeInfoDilers()
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
        public string[] TakeInfoCars()
        {
            StreamReader database = new StreamReader(@"cars_data.txt");
            string[] cars = File.ReadAllLines(@"cars_data.txt").ToArray();
            string line;
            line = database.ReadLine();
            for (int i = 0; i < cars.Length; i++)
            {
                string[] splitLine = line.Split(';');
                cars[i] = splitLine[1];
                line = database.ReadLine();
            }
            database.Close();
            return cars;
        }
        public void Creation(int id, string fio, string pas, string address, string diler, string car, string cost)
        {
            StreamWriter database = new StreamWriter(@"orders_data.txt", append: true);
            database.WriteLineAsync($"{id};{fio};{pas};{address};{diler};{car};{cost}");
            database.Close();
        }

        private void CreateOrder_Button_Click(object sender, RoutedEventArgs e)
        {
            StreamReader database = new StreamReader(@"orders_data.txt");
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
            string fio = Fio_TextBox.Text;
            string pas = Pas_TextBox.Text;
            string address = Address_TextBox.Text;
            string diler = Diler_Combo.Text;
            string car = Cars_Combo.Text;
            string cost = Price_TextBox.Text;

            if (fio != "" & pas != "" & address != "" & diler != "" & car != "" & cost != "")
            {
                Creation(id, fio, pas, address, diler, car, cost);
                orders.OpenPage(Orders.pages.orderList);
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void Diler_Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StreamReader dataCars = new StreamReader(@"cars_data.txt");
            string line = dataCars.ReadLine();
            string[] cars = File.ReadAllLines(@"cars_data.txt").ToArray();
            string[] requiredСars = new string[cars.Length];
            string diler = Diler_Combo.SelectedItem.ToString();
            while (line != null)
            {
                for (int i = 0; i < cars.Length; i++)
                {
                    string[] splitLine = line.Split(';');
                    if (splitLine[3] == diler)
                    {
                        requiredСars[i] = splitLine[1];
                    }
                    line = dataCars.ReadLine();
                }
                Cars_Combo.Items.Clear();
                requiredСars = requiredСars.Where(x => x != null).ToArray();
            }
            foreach (string car in requiredСars)
                Cars_Combo.Items.Add(car);
            Price_TextBox.Text = null;
            
        }

        private void Cars_Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Cars_Combo.SelectedItem != null)
            {
                StreamReader dataCars = new StreamReader(@"cars_data.txt");
                string line = dataCars.ReadLine();
                while (line != null)
                {
                    string car = Cars_Combo.SelectedItem.ToString();
                    string[] splitLine = line.Split(';');
                    if (car == splitLine[1])
                    {
                        Price_TextBox.Text = splitLine[4];
                    }
                    line = dataCars.ReadLine();
                }
            }

        }
    }
}

