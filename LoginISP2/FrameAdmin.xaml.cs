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
    /// Логика взаимодействия для FrameAdmin.xaml
    /// </summary>
    public partial class FrameAdmin : ContentControl
    {
        public FrameAdmin()
        {
            InitializeComponent();
            List<Phone> phonesList = new List<Phone>
            {
                new Phone { Title="iPhone 6S", Company="Apple", Price=54990 },
                new Phone {Title="Lumia 950", Company="Microsoft", Price=39990 },
                new Phone {Title="Nexus 5X", Company="Google", Price=29990 } 
            };
            dgDataGrid.ItemsSource = phonesList; // Если база не обязательна, можно создать список
            //dgDataGrid.ItemsSource = ClassDB2.entity.Product2.ToList(); Если обязательна, подключаем базу, список не создаем 

        }  
    }

    public class Phone
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
    }
}
