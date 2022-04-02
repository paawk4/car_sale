using System.Windows.Controls;

namespace car_sale
{
    /// <summary>
    /// Логика взаимодействия для dilers.xaml
    /// </summary>
    public partial class dilers : Page
    {
        public MainInterface mainInterface;
        public dilers(MainInterface _mainInterface)
        {
            InitializeComponent();
            mainInterface = _mainInterface;
            OpenPage(pages.dilerlist);
        }

        public enum pages
        {
            dilerlist,
            creatediler
        }

        public void OpenPage(pages pages)
        {
            if (pages == pages.dilerlist)
            {
                DilerFrame.Navigate(new DilerList(this));
            }
            else if (pages == pages.creatediler)
            {
                DilerFrame.Navigate(new CreateDiler(this));
            }
        }
    }
}
