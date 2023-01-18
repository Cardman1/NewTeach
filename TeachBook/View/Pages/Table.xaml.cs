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
using Excel = Microsoft.Office.Interop.Excel;

namespace TeachBook.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        Core bc = new Core();
        List<Students> arrayStudunt;
        public Registration()
        {
            var groupMass = new List<Groups>
            {
                new Groups
                {
                    IdGroup = 0,
                    NameGroup = "Все"
                }
            };
            groupMass.AddRange(bc.contex.Groups.ToList()) ;
            InitializeComponent();
            arrayStudunt = bc.contex.Students.ToList();
            DataStudent.ItemsSource = bc.contex.Students.ToList();
            
            ComboGroup.ItemsSource = groupMass.ToList();
            ComboGroup.DisplayMemberPath = "NameGroup";
            ComboGroup.SelectedValuePath = "IdGroup";
            ComboGroup.SelectedValue = 0;
            
        }

        private void ComboChange(object sender, SelectionChangedEventArgs e)
        {
            arrayStudunt = bc.contex.Students.ToList();
            int i = Convert.ToInt32(ComboGroup.SelectedValue);
            if (i == 0) DataStudent.ItemsSource = bc.contex.Students.ToList();else 
            DataStudent.ItemsSource = bc.contex.Students.Where(x => x.IdGroup == i).ToList();
        }
        
        private void ExcelEnter(object sender, RoutedEventArgs e)
        {
            Excel.Application application = new Excel.Application();
            application.Visible = true;
            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            application.SheetsInNewWorkbook = 1;
            Excel.Worksheet worksheet = workbook.ActiveSheet;
            worksheet.Name = "Отчёт";
            int rowIndex = 2;  //номер строки для вывода данных из массива
            worksheet.Cells[1][1] = "ФИО";
            worksheet.Cells[2][1] = "Год добавления";
            worksheet.Cells[3][1] = "Группа";
            worksheet.Cells[4][1] = "Форма обучения";
            int i = Convert.ToInt32(ComboGroup.SelectedValue);
            if (i != 0)arrayStudunt = bc.contex.Students.Where(x => x.IdGroup == i).ToList();
            foreach (var item in arrayStudunt)
            {
                worksheet.Cells[1][rowIndex] = item.FiestName + " " + item.LastName + " " + item.PatronomicName;

                worksheet.Cells[2][rowIndex] = item.YearAdd.Year;

                worksheet.Cells[3][rowIndex] = item.Groups.NameGroup;

                worksheet.Cells[4][rowIndex] = item.FormTime.Name;

                rowIndex++;
            }


        }
    }
}
