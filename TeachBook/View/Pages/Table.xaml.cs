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
        List<Students> arrayStudunt ;
        public Registration()
        {
            InitializeComponent();
            arrayStudunt = bc.contex.Students.ToList();
            DataStudent.ItemsSource = bc.contex.Students.ToList();
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

            foreach (var item in arrayStudunt)

            {

                worksheet.Cells[1][rowIndex] = item.FiestName;

                worksheet.Cells[2][rowIndex] = item.LastName;

                worksheet.Cells[3][rowIndex] = item.PatronomicName;

                worksheet.Cells[4][rowIndex] = item.YearAdd.Year;

                rowIndex++;

            }


        }
    }
}
