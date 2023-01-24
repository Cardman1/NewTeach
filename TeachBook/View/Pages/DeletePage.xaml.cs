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
    /// Логика взаимодействия для DeletePage.xaml
    /// </summary>
    public partial class DeletePage : Page
    {
        Core bc = new Core();
        public DeletePage()
        {
            InitializeComponent();
            GridDelete.ItemsSource = bc.contex.Students.ToList();
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            Button selectedButton = (Button)sender;
            Students item = selectedButton.DataContext as Students;
            bc.contex.Students.Remove(item);
            if (bc.contex.SaveChanges() > 0)
            {
                MessageBox.Show("Студент удалён","Уведомление",MessageBoxButton.OK);
                GridDelete.ItemsSource = null;
                GridDelete.ItemsSource = bc.contex.Students.ToList();
            }
            else
            {
                MessageBox.Show("Студент не удалён", "Уведомление", MessageBoxButton.OK);
            }

        }
    }
}
