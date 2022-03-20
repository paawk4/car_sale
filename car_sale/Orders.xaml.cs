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
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : Page
    {
        public MainInterface mainInterface;
        public Orders(MainInterface _mainInterface)
        {
            InitializeComponent();
            mainInterface = _mainInterface;
            OpenPage(pages.orderList);
        }

        public enum pages
        {
            orderList,
            createOrder
        }

        public void OpenPage(pages pages)
        {
            if (pages == pages.orderList)
            {
                OrdersFrame.Navigate(new OrderList(this));
            }
            else if (pages == pages.createOrder)
            {
                OrdersFrame.Navigate(new CreateOrder(this));
            }
        }
    }
}
