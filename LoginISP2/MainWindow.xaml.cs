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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClassFrame.FrameMenu = frmMenu;
            ClassFrame.FrameMenu.Content = new FrameMenu();
        }

        private void btnButton_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.FrameMenu.Content = new FrameMenu();
        }
    }
}
