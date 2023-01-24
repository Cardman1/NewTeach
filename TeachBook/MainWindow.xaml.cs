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
            var page = e.Content;
            if (MainFrame.CanGoBack && page is MenuPage)
            {
                MainFrame.RemoveBackEntry();
            }
            if (App.inter == 1)
            {
                UsersLabel.Content = App.CurrentUser.Login.ToString();
                PasswordLabel.Content = App.CurrentUser.Password.ToString();
            }
        }
        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            { MainFrame.GoBack(); }
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            {
                if (!MainFrame.CanGoBack)

                { BackButton.Visibility = Visibility.Collapsed; }

                else

                { BackButton.Visibility = Visibility.Visible; }

            }
        }
    }
}
