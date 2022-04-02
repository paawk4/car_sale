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
            StreamWriter database = new StreamWriter(@"dilers_data.txt", append: true);
            database.Close();
            StreamWriter database1 = new StreamWriter(@"database.txt");
            database1.WriteLine("admin;admin");
            database1.Close();
            StreamWriter database2 = new StreamWriter(@"cars_data.txt", append: true);
            database2.Close();
            StreamWriter database3 = new StreamWriter(@"orders_data.txt", append: true);
            database3.Close();
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
