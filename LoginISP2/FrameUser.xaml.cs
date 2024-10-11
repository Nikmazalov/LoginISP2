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
    /// Логика взаимодействия для FrameUser.xaml
    /// </summary>
    public partial class FrameUser : ContentControl
    {
        public FrameUser()
        {
            InitializeComponent();
            lvListView.ItemsSource = ClassDB2.entity.Product2.ToList();
            cbComboBox.Items.Clear();
            cbComboBox.Items.Add("Все");
            int flag = 0;
            foreach (var i in ClassDB2.entity.Category2) // i - элемент из базы
            {
                foreach (var j in cbComboBox.Items) // j - элемент из комбобокса
                {
                    if (j.Equals(i.CategoryName2))
                    {
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    cbComboBox.Items.Add(i.CategoryName2);
                }
                flag = 0;
            }
            cbComboBox.SelectedIndex = 0;
        }

        //Фильтрация
        private void cbComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbComboBox.SelectedValue is "Все")
            {
                lvListView.ItemsSource = ClassDB2.entity.Product2.ToList();
            }
            else
            {
                lvListView.ItemsSource = ClassDB2.entity.Product2.Where(i => i.IdCategory2 == cbComboBox.SelectedIndex).ToList();
            }
        }

        private bool ProductFilter(object item)
        {
            if (string.IsNullOrEmpty(txbFilter.Text))
            {
                return true;
            }
            else
                return ((item as Product2).Name2.IndexOf(txbFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txbFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvListView.ItemsSource);
            view.Filter = ProductFilter;
            CollectionViewSource.GetDefaultView(lvListView.ItemsSource).Refresh();
        }

        private void IdProduct_Click(object sender, RoutedEventArgs e)
        {
            if (cbComboBox.SelectedValue is "Все")
            {
                lvListView.ItemsSource = ClassDB2.entity.Product2.OrderBy(Product => Product.IdProduct2).ToList();
            }
            else
            {
                lvListView.ItemsSource = ClassDB2.entity.Product2.OrderBy(Product => Product.IdProduct2).Where(i => i.IdCategory2 == cbComboBox.SelectedIndex).ToList();
            }
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvListView.ItemsSource);
            view.Filter = ProductFilter;
            CollectionViewSource.GetDefaultView(lvListView.ItemsSource).Refresh();
        }

        private void Name_Click(object sender, RoutedEventArgs e)
        {
            if (cbComboBox.SelectedValue is "Все")
            {
                lvListView.ItemsSource = ClassDB2.entity.Product2.OrderBy(Product => Product.Name2).ToList();
            }
            else
            {
                lvListView.ItemsSource = ClassDB2.entity.Product2.OrderBy(Product => Product.Name2).Where(i => i.IdCategory2 == cbComboBox.SelectedIndex).ToList();
            }
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvListView.ItemsSource);
            view.Filter = ProductFilter;
            CollectionViewSource.GetDefaultView(lvListView.ItemsSource).Refresh();
        }

        private void Quantity_Click(object sender, RoutedEventArgs e)
        {
            if (cbComboBox.SelectedValue is "Все")
            {
                lvListView.ItemsSource = ClassDB2.entity.Product2.OrderBy(Product => Product.Quantity2).ToList();
            }
            else
            {
                lvListView.ItemsSource = ClassDB2.entity.Product2.OrderBy(Product => Product.Quantity2).Where(i => i.IdCategory2 == cbComboBox.SelectedIndex).ToList();
            }
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvListView.ItemsSource);
            view.Filter = ProductFilter;
            CollectionViewSource.GetDefaultView(lvListView.ItemsSource).Refresh();
        }

        private void Category_Click(object sender, RoutedEventArgs e)
        {
            if (cbComboBox.SelectedValue is "Все")
            {
                lvListView.ItemsSource = ClassDB2.entity.Product2.OrderBy(Product => Product.IdCategory2).ToList();
            }
            else
            {
                lvListView.ItemsSource = ClassDB2.entity.Product2.OrderBy(Product => Product.IdProduct2).Where(i => i.IdCategory2 == cbComboBox.SelectedIndex).ToList();
            }
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvListView.ItemsSource);
            view.Filter = ProductFilter;
            CollectionViewSource.GetDefaultView(lvListView.ItemsSource).Refresh();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Product2 product = button?.DataContext as Product2;
            if (product != null)
            {
                ClassDB2.entity.Product2.Remove(product);
                ClassDB2.entity.SaveChanges();
                lvListView.ItemsSource = ClassDB2.entity.Product2.ToList();
            }

        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd windowAdd = new WindowAdd();
            windowAdd.Show();
        }

        private void btnUpDate_Click(object sender, RoutedEventArgs e)
        {
            lvListView.ItemsSource = ClassDB2.entity.Product2.ToList();
            cbComboBox.SelectedIndex = 0;
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            
            Button button = sender as Button;
            Product2 product = button?.DataContext as Product2;

            string strcategory = product.IdCategory2.ToString();
            int intcategory = int.Parse(strcategory) - 1;

            WindowChange windowChange = new WindowChange();
            windowChange.tbName.Text = product.Name2;
            windowChange.cbCategory.SelectedIndex = intcategory;
            windowChange.tbQuantity.Text = product.Quantity2.ToString();
            windowChange.tbPhoto.Text = product.Image2.ToString();
            windowChange.tblId1.Text = product.IdProduct2.ToString();
            windowChange.Show();
        }
    }
}
