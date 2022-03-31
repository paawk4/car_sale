using System;
using System.Collections.Generic;
using System.IO;
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
using System.Diagnostics;

namespace car_sale
{
    /// <summary>
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Page
    {
        public MainWindow mainWindow;
        public login(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void login_button_Click(object sender, RoutedEventArgs e)
        {
            StreamReader database = new StreamReader(@"database.txt");
            bool isAuthorized = false;
            if (login_textbox.Text.Length > 0) // проверяем введён ли логин     
            {
                if (password_textbox.Password.Length > 0) // проверяем введён ли пароль         
                {
                    String line;
                    database = new StreamReader(@"database.txt");
                    line = database.ReadLine(); // читаем строчку из файла
                                                
                    while (line != null) // перебираем все строчки файла
                    {
                        string[] splitLine = line.Split(';');
                        string login = splitLine[0];
                        string pass = splitLine[1];

                        if (login == login_textbox.Text && pass == password_textbox.Password)
                        {
                            MessageBox.Show("Пользователь авторизовался");
                            Debug.WriteLine("Пользователь авторизовался");
                            Trace.WriteLine("Пользователь авторизовался");
                            isAuthorized = true;
                            mainWindow.OpenPage(MainWindow.pages.maininterface);
                            break; // если найдено совпадение -> вывод из цикла
                        }

                        line = database.ReadLine(); // читаем след строку
                    }

                    if (isAuthorized == false)
                    {
                        MessageBox.Show("Введен неправильный логин или пароль");
                        database.Close();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Введите пароль");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Введите логин");
                return;
            }

            database.Close();
        }

        private void regin_button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.regin);
        }
    }
}
