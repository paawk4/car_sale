using System;
using System.Collections.Generic;
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
using System.IO;

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
        void LoadDiler()
        {
            StreamReader database = new StreamReader(@"dilers_data.txt");
            String line;
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
            var change = new ChangeDiler(id);
            change.ShowDialog();
            dilers.OpenPage(dilers.pages.dilerlist);
        }
    }
}
