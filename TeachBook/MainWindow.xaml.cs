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
using TeachBook.View.Pages;

namespace TeachBook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Core bc = new Core();
        public MainWindow()
        {
            InitializeComponent();
            
            MainFrame.Navigate(new View.Pages.AuntificationPage());
        }
        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (App.inter == 1)
            {
                UsersLabel.Content = App.CurrentUser.Login.ToString();
                PasswordLabel.Content = App.CurrentUser.Password.ToString();
            }
        }
        private void BackClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
