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
    /// Логика взаимодействия для CreateDiler.xaml
    /// </summary>
    public partial class CreateDiler : Page
    {
        public dilers dilers;
        public CreateDiler(dilers _dilers)
        {
            InitializeComponent();
            dilers = _dilers;
        }
    }
}
