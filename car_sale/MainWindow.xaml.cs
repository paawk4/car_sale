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
using System.IO;

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
            StreamWriter database = new StreamWriter(@"database.txt");
            database.Close();
            StreamWriter database1 = new StreamWriter(@"cars_data.txt");
            database1.Close();
            StreamWriter database2 = new StreamWriter(@"dilers_data.txt");
            database2.Close();
            StreamWriter database3 = new StreamWriter(@"orders_data.txt");
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
            else if(pages == pages.regin)
            {
                frame.Navigate(new regin(this));
            }
            else if(pages == pages.maininterface)
            {
                frame.Navigate(new MainInterface(this));
            }
        }

    }
}
