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
using System.Windows.Shapes;

namespace car_sale
{
    /// <summary>
    /// Логика взаимодействия для ChangeCar.xaml
    /// </summary>
    public partial class ChangeCar : Window
    {
        public Orders orders;
        public int _id;
        public ChangeCar(int id)
        {
            InitializeComponent();
            _id = id;
            FillData(id);
            string[] dilers = TakeInfo();
            foreach (string s in dilers)
                Diler_Combo.Items.Add(s);
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
        public void FillData(int id)
        {
            StreamReader database = new StreamReader(@"cars_data.txt");
            string line = database.ReadLine();
            while (line != null) // перебираем все строчки файла
            {
                string[] splitLine = line.Split(';');
                if (id == int.Parse(splitLine[0]))
                {
                    Car_TextBox.Text = splitLine[1];
                    Mileage_TextBox.Text = splitLine[2];
                    Diler_Combo.SelectedItem = splitLine[3];
                    Price_TextBox.Text = splitLine[4];
                    break;
                }
                line = database.ReadLine(); // читаем след строку
            }
            database.Close();
        }
        public void ChangeData(int id)
        {
            StreamReader database = new StreamReader(@"cars_data.txt");
            string line = database.ReadLine();
            while (line != null) // перебираем все строчки файла
            {
                string[] splitLine = line.Split(';');
                if (id == int.Parse(splitLine[0]))
                {
                    string _line = $"{id};{Car_TextBox.Text};{Mileage_TextBox.Text};{Diler_Combo.Text};{Price_TextBox.Text}";
                    List<string> quotelist = File.ReadAllLines(@"cars_data.txt").ToList();
                    quotelist.RemoveAt(id);
                    quotelist.Insert(id, _line);
                    database.Close();
                    File.WriteAllLines(@"cars_data.txt", quotelist.ToArray());
                    break;
                }
                line = database.ReadLine(); // читаем след строку
            }
            database.Close();
        }
        public void DeleteData(int id)
        {
            List<string> quotelist = File.ReadAllLines(@"cars_data.txt").ToList();
            quotelist.RemoveAt(id);
            File.WriteAllLines(@"cars_data.txt", quotelist.ToArray());

            StreamReader database = new StreamReader(@"cars_data.txt");
            string line = database.ReadLine();
            for (int i = 0; i < quotelist.Count; i++)
            {
                string[] splitLine = line.Split(';');
                string _line = $"{i};{splitLine[1]};{splitLine[2]};{splitLine[3]};{splitLine[4]}";
                quotelist.RemoveAt(i);
                quotelist.Insert(i, _line);
                line = database.ReadLine();
            }
            database.Close();
            File.WriteAllLines(@"cars_data.txt", quotelist.ToArray());
        }

        private void ChangeCar_Button_Click(object sender, RoutedEventArgs e)
        {
            ChangeData(_id);
            this.Close();

        }

        private void DeleteCar_Button_Click(object sender, RoutedEventArgs e)
        {
            DeleteData(_id);
            this.Close();
        }
    }
}
