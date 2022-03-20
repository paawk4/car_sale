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
    /// Логика взаимодействия для MainInterface.xaml
    /// </summary>
    public partial class MainInterface : Page
    {
        public MainWindow mainWindow;
        public MainInterface(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            OpenPage(pages.orders);
        }
        
        public enum pages
        {
            orders,
            dilers,
            cars
        }

        public void OpenPage(pages pages)
        {
            if (pages == pages.orders)
            {
                MainInterface_Frame.Navigate(new Orders(this));
            }
            else if (pages == pages.dilers)
            {
                MainInterface_Frame.Navigate(new dilers(this));
            }
            else if (pages == pages.cars)
            {
                MainInterface_Frame.Navigate(new Cars(this));
            }
        }

        private void orders_button_Click(object sender, RoutedEventArgs e)
        {
            OpenPage(pages.orders);
        }

        private void dilers_button_Click(object sender, RoutedEventArgs e)
        {
            OpenPage(pages.dilers);
        }

        private void cars_button_Click(object sender, RoutedEventArgs e)
        {
            OpenPage(pages.cars);
        }
    }
}
