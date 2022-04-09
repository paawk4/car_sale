using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace car_sale
{
    /// <summary>
    /// Логика взаимодействия для regin.xaml
    /// </summary>
    public partial class regin : Page
    {
        public MainWindow mainWindow;
        public regin(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        public void registration(string login, string password)
        {
            StreamWriter database = new StreamWriter(@"database.txt", append: true);
            database.WriteLineAsync($"{login};{password}");
            database.Close();
        }

        private void regin_button_Click(object sender, RoutedEventArgs e)
        {
            if (login_textbox.Text.Length > 0) // проверяем логин
            {
                string[] dataLogin = login_textbox.Text.Split('@'); // делим строку на две части
                if (dataLogin.Length == 2) // проверяем если у нас две части
                {
                    string[] data2Login = dataLogin[1].Split('.'); // делим вторую часть ещё на две части
                    if (data2Login.Length == 2) { }
                    else
                    {
                        MessageBox.Show("Укажите логин в форме х@x.x");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Укажите логин в форме х@x.x");
                    return;
                }

                if (password_textbox.Password.Length > 0) // проверяем пароль
                {
                    if (password_textbox.Password.Length >= 6)
                    {
                        bool en = true; // английская раскладка

                        for (int i = 0; i < password_textbox.Password.Length; i++) // перебираем символы
                        {
                            if (password_textbox.Password[i] >= 'А' && password_textbox.Password[i] <= 'Я')
                            {
                                en = false;
                            } // если русская раскладк
                        }
                        if (!en)
                        {
                            MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                        }
                    }
                    else
                    {
                        MessageBox.Show("пароль слишком короткий, минимум 6 символов");
                    }

                    if (rep_password_textbox.Password.Length > 0) // проверяем второй пароль
                    {
                        if (password_textbox.Password == rep_password_textbox.Password) // проверка на совпадение паролей
                        {
                            registration(login_textbox.Text, password_textbox.Password);
                            MessageBox.Show("Пользователь зарегистрирован");
                            NavigationService.GoBack();
                        }
                        else
                        {
                            MessageBox.Show("Пароли не совподают");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Повторите пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Укажите пароль");
                }
            }
            else
            {
                MessageBox.Show("Укажите логин");
            }
        }

        private void cancel_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
