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
    /// Логика взаимодействия для WindowChange.xaml
    /// </summary>
    public partial class WindowChange : Window
    {
        public WindowChange()
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
            int idproduct = int.Parse(tblId1.Text);
            var product = ClassDB2.entity.Product2.Find(idproduct);
            product.Name2 = tbName.Text;
            product.Quantity2 = intQuantity;
            product.IdCategory2 = cbCategory.SelectedIndex + 1;
            product.Image2 = tbPhoto.Text;
            ClassDB2.entity.SaveChanges();
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
