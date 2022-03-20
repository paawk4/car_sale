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
    /// Логика взаимодействия для Cars.xaml
    /// </summary>
    public partial class Cars : Page
    {
        public MainInterface mainInterface;
        public Cars(MainInterface _mainInterface)
        {
            InitializeComponent();
            mainInterface = _mainInterface;
            OpenPage(pages.carList);
        }
        public enum pages
        {
            createCar,
            carList
        }

        public void OpenPage(pages pages)
        {
            if (pages == pages.createCar)
            {
                Cars_Frame.Navigate(new CreateCar(this));
            }
            else if (pages == pages.carList)
            {
                Cars_Frame.Navigate(new CarList(this));
            }
        }
    }
}
