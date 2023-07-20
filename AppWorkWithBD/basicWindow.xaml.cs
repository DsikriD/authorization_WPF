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

namespace AppWorkWithBD
{
    /// <summary>
    /// Логика взаимодействия для basicWindow.xaml
    /// </summary>
    public partial class basicWindow : Page
    {
        public basicWindow()
        {
            InitializeComponent();
            lbl_name.Content = Use_BD.USER_NAME;
            ComnoBox_Load_Product();
            ListBox_Load_Order();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Use_BD.USER_NAME = default;
            NavigationService.Navigate(new LoignPage());
        }

        private void RightB_Click(object sender, RoutedEventArgs e)
        {
            txbAmount.Text = Convert.ToString(Convert.ToInt32(txbAmount.Text)+1);
        }

        private void LeftB_Click(object sender, RoutedEventArgs e)
        {
            if(Convert.ToInt32(txbAmount.Text)>1)
            txbAmount.Text = Convert.ToString(Convert.ToInt32(txbAmount.Text) - 1);
        }

        public void ComnoBox_Load_Product(){
            Use_BD.Get_Product();
            
            foreach(var a in Products.ListProducts)
            {
                CmbProd.Items.Add(a.id+" "+" Product:"+a.name+" Price:"+ a.price);
            }

           Products.ListProducts.Clear();
        }

        public void ListBox_Load_Order() {
            ListOrder.Items.Clear();
        Use_BD.Get_Order();
            foreach (var a in Orders.ListOrder) {
                ListOrder.Items.Add($"N:{a.id}  Name:{(Convert.ToString(a.name_product).Trim())}  Amount:{a.amount}");
            }
            Orders.ClearList();
        }

        private void DoOrder_Click(object sender, RoutedEventArgs e)
        {
            if (CmbProd.SelectedIndex == -1)
                MessageBox.Show("Выберите товар");
            else {
                Use_BD.Make_Order(Convert.ToInt32(Convert.ToString(CmbProd.SelectedValue).Substring(0, 1)),Convert.ToInt32(txbAmount.Text));
                ListBox_Load_Order();
            }

        }
    }
}
