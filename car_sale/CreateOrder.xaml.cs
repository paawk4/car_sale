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
    /// Логика взаимодействия для CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : Page
    {
        public Orders orders;
        public StreamWriter database = new StreamWriter(@"orders_data.txt", append: true);
        public CreateOrder(Orders _orders)
        {
            InitializeComponent();
            orders = _orders;
        }

        public void Creation(string fio, string pas, string address, string diler, string car, double cost)
        {
            database.WriteLineAsync($"{fio};{pas};{address};{diler};{car};{cost}");
            database.Close();
        }

        private void CreateOrder_Button_Click(object sender, RoutedEventArgs e)
        {
            string fio = Fio_TextBox.Text;
            string pas = Pas_TextBox.Text;
            string address = Address_TextBox.Text;
            string diler = Diler_Combo.Text;
            string car = Car_Combo.Text;
            double cost = double.Parse(Cost_TextBox.Text);
            Creation(fio, pas, address, diler, car, cost);
            this.NavigationService.GoBack();
        }
    }
}
