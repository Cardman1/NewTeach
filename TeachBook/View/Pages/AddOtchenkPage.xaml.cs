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
    /// Логика взаимодействия для AddOtchenkPage.xaml
    /// </summary>
    public partial class AddOtchenkPage : Page
    {
        Core bc = new Core();
        List<TeacherHasSubjects> hasSubjects = new List<TeacherHasSubjects>();
        public AddOtchenkPage()
        {
            InitializeComponent();
            GroupCB.ItemsSource = bc.contex.Groups.ToList();
            GroupCB.DisplayMemberPath = "NameGroup";
            GroupCB.SelectedValuePath = "IdGroup";
        }

        private void GroupCB_DropDownClosed(object sender, EventArgs e)
        {

            int i = Convert.ToInt32(GroupCB.SelectedValue);
            StudentCB.ItemsSource = bc.contex.Students.Where(x => x.IdGroup == i).ToList();
            StudentCB.DisplayMemberPath = "FiestName";
            StudentCB.SelectedValuePath = "IdStudent";
            StudentCB.Visibility = Visibility.Visible;
        }

        private void StudentCBDropDownClose(object sender, EventArgs e)
        {
            SubjectCB.ItemsSource = bc.contex.Subjects.ToList();
            SubjectCB.DisplayMemberPath = "NameSubject";
            SubjectCB.SelectedValuePath = "IdSubject";
            SubjectCB.Visibility = Visibility.Visible;
        }

        private void SubjectCBDropDownClose(object sender, EventArgs e)
        {
            OtchenkaTB.Visibility = Visibility.Visible;
            AddButton.Visibility = Visibility.Visible;
        }

        private void AddOtchenku(object sender, RoutedEventArgs e)
        {
            int idTeach = Convert.ToInt32(App.CurrentUser.Login);
            int i = Convert.ToInt32(StudentCB.SelectedValue);
            int s = Convert.ToInt32(SubjectCB.SelectedValue);
            int g = Convert.ToInt32(GroupCB.SelectedValue);
            int o = Convert.ToInt32(OtchenkaTB.Text);
            TeacherHasSubjects intefication = new TeacherHasSubjects()
            {
                IdSubject = s
            };
            if (o <= 5 && o >= 2)
            {
                hasSubjects = bc.contex.TeacherHasSubjects.Where(x => x.IdTeacher == idTeach && x.IdSubject == s).ToList();
                if (hasSubjects.Count()>0)
                {
                    Journals journalsAdd = new Journals()
                    {
                        IdStudent = i,
                        IdGroup = g,
                        Evaluation = o,
                        IdSubject = s
                    };
                    History historyAdd = new History()
                    {
                        IdStatus = 1,
                        IdStudent = i,
                        IdTeacher = idTeach,
                        DateEvent = DateTime.Now
                    };
                    bc.contex.History.Add(historyAdd);
                    bc.contex.Journals.Add(journalsAdd);
                    if (bc.contex.SaveChanges() > 0)
                    {
                        MessageBox.Show("Добавление оценки произошло успешно", "Уведомление", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Вы не ведёте этот предмет","Уведомление",MessageBoxButton.OK);
                }
            }
        }
    }
}
