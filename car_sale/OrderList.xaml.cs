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
    /// Логика взаимодействия для OrderList.xaml
    /// </summary>
    public partial class OrderList : Page
    {
        public Orders orders;
        public StreamReader database = new StreamReader(@"orders_data.txt");
        public class Order
        {
            public string fio { get; set; }
            public string pas { get; set; }
            public string address { get; set; }
            public string diler { get; set; }
            public string car { get; set; }
            public string cost { get; set; }
        }
        public OrderList(Orders _orders)
        {
            InitializeComponent();
            orders = _orders;
            LoadOrder();
        }
        void LoadOrder()
        {
            String line;
            line = database.ReadLine(); // читаем строчку из файла
            while(line != null)
            {
                string[] splitLine = line.Split(';');
                Order dataOrder = new Order()
                {
                    fio = splitLine[0],
                    pas = splitLine[1],
                    address = splitLine[2],
                    diler = splitLine[3],
                    car = splitLine[4],
                    cost = splitLine[5]
                };
                listOrders.Items.Add(dataOrder);
                line = database.ReadLine();
            }
        }

        private void CreateOrder_Button_Click(object sender, RoutedEventArgs e)
        {
            database.Close();
            orders.OpenPage(Orders.pages.createOrder);
        }

        private void listOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var change = new ChangeOrder();
            change.Show();
        }
    }
}
