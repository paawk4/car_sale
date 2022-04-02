using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace car_sale
{
    /// <summary>
    /// Логика взаимодействия для OrderList.xaml
    /// </summary>
    public partial class OrderList : Page
    {
        public Orders orders;
        public class Order
        {
            public int id { get; set; }
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

        private void LoadOrder()
        {
            StreamReader database = new StreamReader(@"orders_data.txt");
            string line;
            line = database.ReadLine(); // читаем строчку из файла
            while (line != null)
            {
                string[] splitLine = line.Split(';');
                Order dataOrder = new Order()
                {
                    id = int.Parse(splitLine[0]),
                    fio = splitLine[1],
                    pas = splitLine[2],
                    address = splitLine[3],
                    diler = splitLine[4],
                    car = splitLine[5],
                    cost = splitLine[6]
                };
                listOrders.Items.Add(dataOrder);
                line = database.ReadLine();
            }
            database.Close();
        }

        private void CreateOrder_Button_Click(object sender, RoutedEventArgs e)
        {
            orders.OpenPage(Orders.pages.createOrder);
        }

        private void listOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int id = Convert.ToInt32(listOrders.SelectedIndex);
            ChangeOrder change = new ChangeOrder(id);
            change.ShowDialog();
            orders.OpenPage(Orders.pages.orderList);
        }
    }
}
