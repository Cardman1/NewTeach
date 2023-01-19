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
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        Core bc = new Core();
        public MenuPage()
        {
            InitializeComponent();
        }

        private void AddStydent(object sender, RoutedEventArgs e)
        {

        }

        private void AllStudent(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Registration());
        }

        private void AddOtchenku(object sender, RoutedEventArgs e)
        {

        }

        private void Redact(object sender, RoutedEventArgs e)
        {

        }

        private void Delete(object sender, RoutedEventArgs e)
        {

        }
    }
}
