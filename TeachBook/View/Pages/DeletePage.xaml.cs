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
        }

        private void DeleteStudent(object sender, RoutedEventArgs e)
        {
            Students delStudents = bc.contex.Students.Where(x => x.FiestName == FirstNameTB.Text && x.LastName == LastNameTB.Text && x.PatronomicName == PatronomicTB.Text).FirstOrDefault();
            bc.contex.Students.Remove(delStudents);
            if (bc.contex.SaveChanges() > 0)
            {
                MessageBox.Show("Студент удален", "удаление из базу данных", MessageBoxButton.OK, MessageBoxImage.Question);
            }
            else
            {
                MessageBox.Show("Студент не удален", "удаление из базу данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
