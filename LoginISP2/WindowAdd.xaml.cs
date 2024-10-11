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

namespace LoginISP2
{
    /// <summary>
    /// Логика взаимодействия для WindowAdd.xaml
    /// </summary>
    public partial class WindowAdd : Window
    {
        public WindowAdd()
        {
            InitializeComponent();
            int flag = 0;
            foreach (var i in ClassDB2.entity.Category2) // i - элемент из базы
            {
                foreach (var j in cbCategory.Items) // j - элемент из комбобокса
                {
                    if (j.Equals(i.CategoryName2))
                    {
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    cbCategory.Items.Add(i.CategoryName2);
                }
                flag = 0;
            }
            cbCategory.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int intQuantity = int.Parse(tbQuantity.Text);
            Product2 product = new Product2 { Name2 = tbName.Text, IdCategory2 = cbCategory.SelectedIndex + 1, Quantity2 = intQuantity, Image2 = tbPhoto.Text };
            ClassDB2.entity.Product2.Add(product);
            ClassDB2.entity.SaveChanges();
            tbName.Text = null;
            tbQuantity = null;
            tbPhoto = null;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
