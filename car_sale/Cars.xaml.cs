using System.Windows.Controls;

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
