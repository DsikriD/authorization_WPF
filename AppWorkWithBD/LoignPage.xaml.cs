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
    /// Логика взаимодействия для LoignPage.xaml
    /// </summary>
    public partial class LoignPage : Page
    {
        public LoignPage()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (Use_BD.Avtorization(txtB_login.Text, txtB_password.Password) == true)
                NavigationService.Navigate(new basicWindow());
            else
                MessageBox.Show("Неверный логин или пароль");
        }

        private void lblReg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegWindow());
        }
    }
}
