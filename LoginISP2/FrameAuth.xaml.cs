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

namespace LoginISP2
{
    /// <summary>
    /// Логика взаимодействия для FrameAuth.xaml
    /// </summary>
    public partial class FrameAuth : ContentControl
    {
        public FrameAuth()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = ClassDB2.entity.User2.Where(i => i.Login2 == txbLogin.Text && i.Password2 == psbPassword.Password).FirstOrDefault();

            if (user.IdRole2 == 1)
            {
                ClassFrame.FrameMenu.Content = new FrameAdmin();
            }

            else if (user.IdRole2 == 2)
            {
                ClassFrame.FrameMenu.Content = new FrameUser();
            }
            else
            {
                MessageBox.Show("Ошибка! Неправильно введен логин или пароль");
            }
        }
    }
}
