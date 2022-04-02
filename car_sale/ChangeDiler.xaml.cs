using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace car_sale
{
    /// <summary>
    /// Логика взаимодействия для ChangeDiler.xaml
    /// </summary>
    public partial class ChangeDiler : Window
    {
        public int _id;
        public ChangeDiler(int id)
        {
            InitializeComponent();
            _id = id;
            FillData(id);
        }

        public void FillData(int id)
        {
            StreamReader database = new StreamReader(@"dilers_data.txt");
            string line = database.ReadLine();
            while (line != null) // перебираем все строчки файла
            {
                string[] splitLine = line.Split(';');
                if (id == int.Parse(splitLine[0]))
                {
                    Diler_TextBox.Text = splitLine[1];
                    Address_TextBox.Text = splitLine[2];
                    PhoneNumber_TextBox.Text = splitLine[3];
                    break;
                }
                line = database.ReadLine(); // читаем след строку
            }
            database.Close();
        }
        public void ChangeData(int id)
        {
            StreamReader database = new StreamReader(@"dilers_data.txt");
            string line = database.ReadLine();
            while (line != null) // перебираем все строчки файла
            {
                string[] splitLine = line.Split(';');
                if (id == int.Parse(splitLine[0]))
                {
                    string _line = $"{id};{Diler_TextBox.Text};{Address_TextBox.Text};{PhoneNumber_TextBox.Text}";
                    List<string> quotelist = File.ReadAllLines(@"dilers_data.txt").ToList();
                    quotelist.RemoveAt(id);
                    quotelist.Insert(id, _line);
                    database.Close();
                    File.WriteAllLines(@"dilers_data.txt", quotelist.ToArray());
                    break;
                }
                line = database.ReadLine(); // читаем след строку
            }
            database.Close();
        }
        public void DeleteData(int id)
        {
            List<string> quotelist = File.ReadAllLines(@"dilers_data.txt").ToList();
            quotelist.RemoveAt(id);
            File.WriteAllLines(@"dilers_data.txt", quotelist.ToArray());

            StreamReader database = new StreamReader(@"dilers_data.txt");
            string line = database.ReadLine();
            for (int i = 0; i < quotelist.Count; i++)
            {
                string[] splitLine = line.Split(';');
                string _line = $"{i};{splitLine[1]};{splitLine[2]};{splitLine[3]}";
                quotelist.RemoveAt(i);
                quotelist.Insert(i, _line);
                line = database.ReadLine();
            }
            database.Close();
            File.WriteAllLines(@"dilers_data.txt", quotelist.ToArray());
        }

        private void ChangeDiler_Button_Click(object sender, RoutedEventArgs e)
        {
            ChangeData(_id);
            Close();
        }

        private void DeleteDiler_Button_Click(object sender, RoutedEventArgs e)
        {
            DeleteData(_id);
            Close();
        }
    }
}
