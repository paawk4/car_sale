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
    /// Логика взаимодействия для CarList.xaml
    /// </summary>
    public partial class CarList : Page
    {
        public Cars cars;
        public CarList(Cars _cars)
        {
            InitializeComponent();
            cars = _cars;
        }
    }
}
