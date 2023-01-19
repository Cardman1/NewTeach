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
using System.Security.Cryptography;

namespace TeachBook.View.Pages
{
    
    public partial class AuntificationPage : Page
    {
        List<Users> usersArray;
        Core bc = new Core();
        public AuntificationPage()
        {
            usersArray = bc.contex.Users.ToList();
            InitializeComponent();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Users loginArray = bc.contex.Users.Where(x => x.Login == LoginText.Text && x.Password == Password.Text).FirstOrDefault();
                if (loginArray == null)
                {
                    MessageBox.Show("Такой пользователь отсутствует!",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }
                else
                {
                    App.CurrentUser = loginArray;
                    switch (loginArray.IdRole)
                    {
                        case 1:
                            MessageBox.Show("Вы не имеете право!",
                            "Уведомление",
                            MessageBoxButton.OK);
                            break;
                        case 2:
                            this.NavigationService.Navigate(new MenuPage());
                            App.inter = 1;
                            break;
                        case 3:
                            this.NavigationService.Navigate(new MenuPage());
                            App.inter = 1;
                            break;

                    }
                }
            }
            catch
            {

            }
        }

        private void SavePassword(object sender, RoutedEventArgs e)
        {
            
        }

        private void RegPassword(object sender, RoutedEventArgs e)
        {

        }
    }
}
