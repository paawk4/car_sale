using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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
            StreamWriter debug = new StreamWriter(@"debug.txt", append: true);
            bool isAuthorized = false;
            if (login_textbox.Text.Length > 0) // проверяем введён ли логин     
            {
                if (password_textbox.Password.Length > 0) // проверяем введён ли пароль         
                {
                    string line;
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
                            debug.WriteLine("Пользователь авторизовался");
                            Debug.WriteLine("Пользователь авторизовался");
                            Trace.WriteLine("Пользователь авторизовался");
                            isAuthorized = true;
                            mainWindow.OpenPage(MainWindow.pages.maininterface);
                            debug.Close();
                            break; // если найдено совпадение -> вывод из цикла
                        }
                        line = database.ReadLine(); // читаем след строку
                    }

                    if (isAuthorized == false)
                    {
                        MessageBox.Show("Введен неправильный логин или пароль");
                        debug.WriteLine("Введен неправильный логин или пароль");
                        Debug.WriteLine("Введен неправильный логин или пароль");
                        Trace.WriteLine("Введен неправильный логин или пароль");
                        debug.Close();
                        database.Close();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Введите пароль");
                    debug.WriteLine("Не введен пароль");
                    Debug.WriteLine("Не введен пароль");
                    Trace.WriteLine("Не введен пароль");
                    debug.Close();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Введите логин");
                debug.WriteLine("Не введен логин");
                Debug.WriteLine("Не введен логин");
                Trace.WriteLine("Не введен логин");
                debug.Close();
                return;
            }
            debug.Close();
            database.Close();
        }

        private void regin_button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.regin);
        }
    }
}
