using System.IO;
using System.Windows;

namespace car_sale
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            OpenPage(pages.login);
        }

        public enum pages
        {
            login,
            regin,
            maininterface
        }

        public void OpenPage(pages pages)
        {
            if (pages == pages.login)
            {
                frame.Navigate(new login(this));
            }
            else if (pages == pages.regin)
            {
                frame.Navigate(new regin(this));
            }
            else if (pages == pages.maininterface)
            {
                frame.Navigate(new MainInterface(this));
            }
        }

    }
}
