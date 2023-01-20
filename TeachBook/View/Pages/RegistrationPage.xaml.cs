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
using TeachBook.Model;

namespace TeachBook.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        Core bc = new Core();
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void CreatUsersCliact(object sender, RoutedEventArgs e)
        {
            int i = 2;
            if(PasswordTB != null && LoginTB != null && APasswordTB.Text != null)
            {
                if (APasswordTB.Text == PasswordTB.Text)
                {
                    if (CheckAdmin.IsChecked == true) i = 3;
                    try
                    {
                        Users newUsers = new Users()
                        {
                            Login = LoginTB.Text,
                            Password = PasswordTB.Text,
                            IdRole = i
                        };
                        bc.contex.Users.Add(newUsers);
                        bc.contex.SaveChanges();
                        MessageBox.Show("Создание произошло успешно", "Уведомление", MessageBoxButton.OK);
                    }
                    catch
                    {
                        MessageBox.Show("Критический сбой в программе", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Введите ВСЕ данные");
                }
            }
        }
    }
}
