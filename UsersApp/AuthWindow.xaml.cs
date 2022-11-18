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
using System.Windows.Shapes;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = PassBox.Password.Trim();
          

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Слишком короткий логин";
                textBoxLogin.Background = Brushes.DeepPink;
            }
            else if (pass.Length < 5)
            {
                PassBox.ToolTip = "Простой пароль";
                PassBox.Background = Brushes.DeepPink;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                PassBox.ToolTip = "";
                PassBox.Background = Brushes.Transparent;

                User authUser = null;

                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(b => b.login == login && b.pass == pass).FirstOrDefault();
                }

                if (authUser != null)
                {
                    //MessageBox.Show("Считай вошёл");
                    UserPageWindow userPageWindow = new UserPageWindow();
                    userPageWindow.Show();
                    Hide();
                }
              

                else
                {
                    MessageBox.Show("Неправильный логин или пароль");
                }
            }
        }

        private void Button_Reg1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
