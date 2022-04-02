using System.Windows.Controls;

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
