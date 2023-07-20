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
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Page
    {
        public RegWindow()
        {
            InitializeComponent();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            if (txbLogin.Text != "" && PasBox.Password != "")
            {
                if(Use_BD.Registration(txbLogin.Text, PasBox.Password)==true)
                    NavigationService.Navigate(new LoignPage());
            }
            else
                MessageBox.Show("Введите логин и пароль");

        }
    }
}
