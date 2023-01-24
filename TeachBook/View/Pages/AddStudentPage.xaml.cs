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
    /// Логика взаимодействия для AddStudentPage.xaml
    /// </summary>
    public partial class AddStudentPage : Page
    {
        Core bc = new Core();
        List<YearAdd> arrayYears = new List<YearAdd>();
        public AddStudentPage()
        {
            InitializeComponent();
            GenereteList();
            ComboBoxAdd();
        }
        public void ComboBoxAdd()
        {
            var groupMass = new List<Groups>
            {
                new Groups
                {
                    IdGroup = 0,
                    NameGroup = "Выбрать группу"
                }
            };
            groupMass.AddRange(bc.contex.Groups.ToList());
            GroupCB.ItemsSource = groupMass.ToList();
            GroupCB.DisplayMemberPath = "NameGroup";
            GroupCB.SelectedValuePath = "IdGroup";
            GroupCB.SelectedValue = 0;
            var professionMass = new List<Professions>
            {
                new Professions
                {
                    IdProfession = 0,
                    NameProfession = "Выбрать специальность"
                }
            };
            professionMass.AddRange(bc.contex.Professions.ToList());
            ProfessionCB.ItemsSource = professionMass.ToList();
            ProfessionCB.DisplayMemberPath = "NameProfession";
            ProfessionCB.SelectedValuePath = "IdProfession";
            ProfessionCB.SelectedValue = 0;
            var formTimeMass = new List<FormTime>
            {
                new FormTime
                {
                    Id = 0,
                    Name = "Выбрать форму обучения"
                }
            };
            formTimeMass.AddRange(bc.contex.FormTime.ToList());
            FormaCB.ItemsSource = formTimeMass.ToList();
            FormaCB.DisplayMemberPath = "Name";
            FormaCB.SelectedValuePath = "Id";
            FormaCB.SelectedValue = 0;
        }
        /// <summary>
        /// добавление годов в CB
        /// </summary>
        public void GenereteList()
        {
            List<string> yearList = new List<string>();
            for (int i = 0; i<10; i++)
            {
                yearList.Add(Convert.ToString(DateTime.Now.Year-i));
            }
            YearsCB.ItemsSource = yearList;
            YearsCB.SelectedItem = $"{DateTime.Now.Year}";
        }

        private void AddStudent(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32(ProfessionCB.SelectedValue);
            if (i == 0) MessageBox.Show("Выберите группу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); else
            {
                int y = Convert.ToInt32(ProfessionCB.SelectedValue);
                if (y == 0) MessageBox.Show("Выберите специальность", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); else
                {
                    int l = Convert.ToInt32(FormaCB.SelectedValue);
                    if (l == 0) MessageBox.Show("Выберите форму обучения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); else
                    {
                        if (FirstTB.Text == null || LastTB == null || PatronicTB == null) MessageBox.Show("Введите ФИО", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); else
                        {
                            YearAdd addYearMass = new YearAdd()
                            {
                                Year = Convert.ToInt32(YearsCB.SelectedItem)
                            };
                            bc.contex.YearAdd.Add(addYearMass);
                            bc.contex.SaveChanges();
                            i = Convert.ToInt32(YearsCB.SelectedValue);
                            YearAdd yearAdd = bc.contex.YearAdd.Where(x => x.Year == i).FirstOrDefault();
                            Students addStudentMass = new Students()
                            {
                                FiestName = FirstTB.Text,
                                LastName = LastTB.Text,
                                PatronomicName = PatronicTB.Text,
                                IdProfession = Convert.ToInt32(ProfessionCB.SelectedValue),
                                IdFormTime = Convert.ToInt32(FormaCB.SelectedValue),
                                IdGroup = Convert.ToInt32(ProfessionCB.SelectedValue),
                                IdYearAdd = yearAdd.idYear
                            };
                            bc.contex.Students.Add(addStudentMass);
                            if (bc.contex.SaveChanges() > 0)
                            {
                                MessageBox.Show("Студент добавлен", "Добавление в базу данных", MessageBoxButton.OK, MessageBoxImage.Question);
                            }
                            else
                            {
                                MessageBox.Show("Студент не был добавлен", "Добавление в базу данных", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        };
                    }
                }
            }
        }
    }
}
