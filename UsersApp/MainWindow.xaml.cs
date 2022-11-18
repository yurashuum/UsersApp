using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;


namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ApplicationContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();

            DoubleAnimation BtnAnimation = new DoubleAnimation();

            BtnAnimation.From = 0;
            BtnAnimation.To = 500;
            BtnAnimation.Duration = TimeSpan.FromSeconds(2);
            RegButt.BeginAnimation(Button.WidthProperty, BtnAnimation);
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = PassBox.Password.Trim();
            string pass_2 = PassBox2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Слишком короткий логин"; 
                textBoxLogin.Background = Brushes.DeepPink;
            }
            else if(pass.Length < 5)
            {
                PassBox.ToolTip = "Простой пароль";
                PassBox.Background = Brushes.DeepPink;
            }
            else if (pass != pass_2)
            {
                PassBox2.ToolTip = "Разные пароли";
                PassBox2.Background = Brushes.DeepPink;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains(".")) 
            {
                textBoxLogin.ToolTip = "Не корректно введён email";
                textBoxLogin.Background = Brushes.DeepPink;
            }

            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                PassBox.ToolTip = "";
                PassBox.Background = Brushes.Transparent;
                PassBox2.ToolTip = "";
                PassBox2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Успешная регистрация");
          

                User user = new User(login, pass, email);
                ///добавляем данные в БД
                db.Users.Add(user);
                db.SaveChanges();
                AuthWindow authWindow = new AuthWindow(); /// создаем объект окна входа
                authWindow.Show(); // открывает окно входа
                Hide();

            }


        }

        
        private void Button_input_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow(); /// создаем объект окна входа
            authWindow.Show(); // открывает окно входа
            Hide(); ///Убирает текущие окно
        }

        private void RegButt_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

            RegButt.Background = Brushes.LightSeaGreen;
        }

        private void RegButt_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
          /*  RegButt.Background = ???*/ ///чтобы цвет кнопки становился прежним 
            
        }
    }
}
