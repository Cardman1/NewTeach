using System;
using System.Collections.Generic;
using System.IO;
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
using Word = Microsoft.Office.Interop.Word;

namespace TeachBook.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        Core bc = new Core();
        int indeficate = 0;
        public ProfilePage()
        {
            InitializeComponent();
            int s = App.students.IdStudent;
            ProfileGrid.ItemsSource = bc.contex.Journals.Where(x => x.IdStudent == s).ToList();
            FIO.Content = $"{App.students.FiestName} {App.students.LastName} {App.students.PatronomicName}";
        }
        private void RedactButton_Click(object sender, RoutedEventArgs e)
        {
            Button selectedButton = (Button)sender;
            GridReadOt.Visibility = Visibility.Visible;
            
            if (ReadOtchenka.Text != "" && indeficate == 1)
            {
                if(Convert.ToInt32(ReadOtchenka.Text)<=5 && Convert.ToInt32(ReadOtchenka.Text) >= 2)
                {
                    Journals item = selectedButton.DataContext as Journals;
                    History historyAdd = new History()
                    {
                        IdStatus = 2,
                        IdStudent = App.students.IdStudent,
                        IdTeacher = Convert.ToInt32(App.CurrentUser.Login),
                        DateEvent = DateTime.Now
                    };
                    bc.contex.History.Add(historyAdd);
                    item.Evaluation = Convert.ToInt32(ReadOtchenka.Text);
                    if (bc.contex.SaveChanges()>0) 
                    {
                        MessageBox.Show("Оценка отредактирована","Уведомление",MessageBoxButton.OK);
                        ProfileGrid.ItemsSource = null;
                        int s = App.students.IdStudent;
                        ProfileGrid.ItemsSource = bc.contex.Journals.Where(x => x.IdStudent == s).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Оценка не отредактирована", "Уведомление", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Не верная оценка", "Уведомление", MessageBoxButton.OK);
                }
                
            }
        }

        private void LostFocusText(object sender, RoutedEventArgs e)
        {
            indeficate = 1;
        }

        private void DiplomClick(object sender, RoutedEventArgs e)
        {
            Word.Application application = new Word.Application();
            string file = $"{Directory.GetCurrentDirectory()}\\Docs\\Диплом.doc";
            if (File.Exists(file))
            {
                Word.Document doc = application.Documents.Open(file);
                doc.Activate();
                doc.Bookmarks["FIO"].Range.Text = App.students.FiestName + " " + App.students.LastName + " " + App.students.PatronomicName;
                doc.Bookmarks["Proffesion"].Range.Text = App.students.Professions.NameProfession;
                application.Visible = true;
                doc.SaveAs2($"{Directory.GetCurrentDirectory()}\\docs\\Диплом_1.doc");

            }
        }
    }
}
