using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace car_sale
{
    /// <summary>
    /// Логика взаимодействия для CarList.xaml
    /// </summary>
    public partial class CarList : Page
    {
        public Cars cars;
        public CarList(Cars _cars)
        {
            InitializeComponent();
            cars = _cars;
            LoadCar();
        }
        public class Car
        {
            public string id { get; set; }
            public string car { get; set; }
            public string mileage { get; set; }
            public string diler { get; set; }
            public string price { get; set; }
        }

        private void LoadCar()
        {
            StreamReader database = new StreamReader(@"cars_data.txt");
            string line;
            line = database.ReadLine();
            while (line != null)
            {
                string[] splitLine = line.Split(';');
                Car Data = new Car()
                {
                    id = splitLine[0],
                    car = splitLine[1],
                    mileage = splitLine[2],
                    diler = splitLine[3],
                    price = splitLine[4]
                };
                listCars.Items.Add(Data);
                line = database.ReadLine();
            }
            database.Close();
        }

        private void ListCars_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int id = Convert.ToInt32(listCars.SelectedIndex);
            ChangeCar change = new ChangeCar(id);
            change.ShowDialog();
            cars.OpenPage(Cars.pages.carList);
        }

        private void CreateCar_Button_Click(object sender, RoutedEventArgs e)
        {
            cars.OpenPage(Cars.pages.createCar);
        }
    }
}
