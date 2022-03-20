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

namespace car_sale
{
    /// <summary>
    /// Логика взаимодействия для OrderList.xaml
    /// </summary>
    public partial class OrderList : Page
    {
        public Orders orders;
        public OrderList(Orders _orders)
        {
            InitializeComponent();
            orders = _orders;
        }

        private void CreateOrder_Button_Click(object sender, RoutedEventArgs e)
        {
            orders.OpenPage(Orders.pages.createOrder);
        }
    }
}
