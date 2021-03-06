using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace car_sale
{
    /// <summary>
    /// Логика взаимодействия для DilerList.xaml
    /// </summary>
    public partial class DilerList : Page
    {
        public dilers dilers;
        public DilerList(dilers _dilers)
        {
            InitializeComponent();
            dilers = _dilers;
            try
            {
                StreamReader database = new StreamReader(@"dilers_data.txt");
            }
            catch
            {
                StreamWriter database = new StreamWriter(@"dilers_data.txt", append: true);
                database.Close();
            }
            LoadDiler();
        }
        public class Diler
        {
            public string id { get; set; }
            public string diler { get; set; }
            public string address { get; set; }
            public string phone { get; set; }
        }

        private void CreateDiler_Button_Click(object sender, RoutedEventArgs e)
        {
            dilers.OpenPage(dilers.pages.creatediler);
        }

        private void LoadDiler()
        {
            StreamReader database = new StreamReader(@"dilers_data.txt");
            string line;
            line = database.ReadLine(); // читаем строчку из файла
            while (line != null)
            {
                string[] splitLine = line.Split(';');
                Diler data = new Diler()
                {
                    id = splitLine[0],
                    diler = splitLine[1],
                    address = splitLine[2],
                    phone = splitLine[3]
                };
                listDilers.Items.Add(data);
                line = database.ReadLine();
            }
            database.Close();
        }

        private void listDilers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int id = Convert.ToInt32(listDilers.SelectedIndex);
            ChangeDiler change = new ChangeDiler(id);
            change.ShowDialog();
            dilers.OpenPage(dilers.pages.dilerlist);
        }
    }
}
