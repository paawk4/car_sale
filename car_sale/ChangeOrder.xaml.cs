using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace car_sale
{
    /// <summary>
    /// Логика взаимодействия для ChangeOrder.xaml
    /// </summary>
    public partial class ChangeOrder : Window
    {
        public int _id;
        public ChangeOrder(int id)
        {
            InitializeComponent();
            _id = id;
            string[] dilers = TakeInfoDilers();
            string[] cars = TakeInfoCars();
            foreach (string s in dilers)
            {
                Diler_Combo.Items.Add(s);
            }

            foreach (string s in cars)
            {
                Car_Combo.Items.Add(s);
            }

            FillData(_id);

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
        public void FillData(int id)
        {
            StreamReader database = new StreamReader(@"orders_data.txt");
            string line = database.ReadLine();
            while (line != null) // перебираем все строчки файла
            {
                string[] splitLine = line.Split(';');
                if (id == int.Parse(splitLine[0]))
                {
                    Fio_TextBox.Text = splitLine[1];
                    Pas_TextBox.Text = splitLine[2];
                    Address_TextBox.Text = splitLine[3];
                    Diler_Combo.SelectedItem = splitLine[4];
                    Car_Combo.SelectedItem = splitLine[5];
                    Cost_TextBox.Text = splitLine[6];
                    break;
                }
                line = database.ReadLine(); // читаем след строку
            }
            database.Close();
        }
        public void ChangeData(int id)
        {
            StreamReader database = new StreamReader(@"orders_data.txt");
            string line = database.ReadLine();
            while (line != null) // перебираем все строчки файла
            {
                string[] splitLine = line.Split(';');
                if (id == int.Parse(splitLine[0]))
                {
                    string _line = $"{id};{Fio_TextBox.Text};{Pas_TextBox.Text};{Address_TextBox.Text};{Diler_Combo.Text};{Car_Combo.Text};{Cost_TextBox.Text}";
                    List<string> quotelist = File.ReadAllLines(@"orders_data.txt").ToList();
                    quotelist.RemoveAt(id);
                    quotelist.Insert(id, _line);
                    database.Close();
                    File.WriteAllLines(@"orders_data.txt", quotelist.ToArray());
                    break;
                }
                line = database.ReadLine(); // читаем след строку
            }
            database.Close();
        }
        public void DeleteData(int id)
        {
            List<string> quotelist = File.ReadAllLines(@"orders_data.txt").ToList();
            quotelist.RemoveAt(id);
            File.WriteAllLines(@"orders_data.txt", quotelist.ToArray());

            StreamReader database = new StreamReader(@"orders_data.txt");
            string line = database.ReadLine();
            for (int i = 0; i < quotelist.Count; i++)
            {
                string[] splitLine = line.Split(';');
                string _line = $"{i};{splitLine[1]};{splitLine[2]};{splitLine[3]};{splitLine[4]};{splitLine[5]};{splitLine[6]}";
                quotelist.RemoveAt(i);
                quotelist.Insert(i, _line);
                line = database.ReadLine();
            }
            database.Close();
            File.WriteAllLines(@"orders_data.txt", quotelist.ToArray());
        }

        private void SaveOrder_Button_Click(object sender, RoutedEventArgs e)
        {
            ChangeData(_id);
            Close();
        }

        private void DeleteOrder_Button_Click(object sender, RoutedEventArgs e)
        {
            DeleteData(_id);
            Close();
        }
    }
}
