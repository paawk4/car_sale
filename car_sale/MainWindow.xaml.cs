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
            regin
        }
        
        public void OpenPage(pages pages)
        {
            if(pages == pages.login)
            {
                frame.Navigate(new login(this));
            }
            else if(pages == pages.regin)
            {
                frame.Navigate(new regin(this));
            }
        }

    }
}
