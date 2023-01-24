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
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace TeachBook.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        Core bc = new Core();
        List<Students> arrayStudunt;
        List<Groups> outGroupMass;
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
            outGroupMass = groupMass;
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

        private void CheckApp(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{Convert.ToString(App.CurrentUser)}");
        }

        private void WordEnter(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32(ComboGroup.SelectedValue);
            if (i != 0) arrayStudunt = bc.contex.Students.Where(x => x.IdGroup == i).ToList();
            Word.Application application = new Word.Application();
            Word.Document wordDock = application.Documents.Add();
            Word.Paragraph titleParagraph = wordDock.Paragraphs.Add();
            Word.Range titleRange = titleParagraph.Range;
            titleRange.Text = "МИНИСТЕРСТВО ОБРАЗОВАНИЯ И МОЛОДЕЖНОЙ ПОЛИТИКИ СВЕРДЛОВСКОЙ ОБЛАСТИ";
            titleRange.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            titleRange.InsertParagraphAfter();
            titleRange= titleParagraph.Range;
            titleRange.Text = "ГОСУДАРСТВЕННОЕ АВТОНОМНОЕ ПРОФЕССИОНАЛЬНОЕ ОБРАЗОВАТЕЛЬНОЕ УЧРЕЖДЕНИЕ";
            titleRange.InsertParagraphAfter();
            titleRange = titleParagraph.Range;
            titleRange.Text = "СВЕРДЛОВСКОЙ ОБЛАСТИ";
            titleRange.InsertParagraphAfter();
            titleRange = titleParagraph.Range;
            titleRange.Text = "«ЕКАТЕРИНБУРГСКИЙ МОНТАЖНЫЙ КОЛЛЕДЖ»";
            titleRange.Bold = 1;
            titleRange.InsertParagraphAfter();
            titleRange = titleParagraph.Range;
            titleRange.Text = "ВЕДОМОСТЬ";
            titleRange.InsertParagraphAfter();
            titleRange = titleParagraph.Range;
            titleRange.Text = "итоговой аттестации";
            titleRange.InsertParagraphAfter();
            titleRange = titleParagraph.Range;
            Word.Paragraph tableParagraph = wordDock.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table titleTable = wordDock.Tables.Add(tableRange,1,2);
            Word.Range cellRange;
            cellRange = titleTable.Cell(1, 1).Range;
            cellRange.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            cellRange.Text = "«_____» _________ 20_____ Г.";
            cellRange = titleTable.Cell(1, 2).Range;
            cellRange.Text = "№_____________";
            cellRange.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
            titleRange.InsertParagraphAfter();
            titleRange.Bold = 0;
            titleRange = titleParagraph.Range;
            titleRange.Text = $"Группа №: {ComboGroup.Text}";
            titleRange.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            titleRange.InsertParagraphAfter();
            titleRange = titleParagraph.Range;
            titleRange.Text = $"Преподаватель: {App.CurrentUser.Login}";
            titleRange.InsertParagraphAfter();
            Word.Paragraph tableSParagraph = wordDock.Paragraphs.Add();
            Word.Range tableSRange = tableParagraph.Range;
            Word.Table titleSTable = wordDock.Tables.Add(tableSRange, arrayStudunt.Count+1, 3);
            Word.Range cellSRange;
            titleSTable.Borders.InsideLineStyle = titleSTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            cellSRange = titleSTable.Cell(1, 1).Range;
            cellSRange.Text = "№ п/п";
            cellSRange = titleSTable.Cell(1, 2).Range;
            cellSRange.Text = "ФИО";
            cellSRange = titleSTable.Cell(1, 3).Range;
            cellSRange.Text = "Атестация";
            int rowIndex = 2;
            foreach (var item in arrayStudunt)
            {
                cellSRange = titleSTable.Cell(rowIndex, 1).Range;

                cellSRange.Text = Convert.ToString(rowIndex-1);

                cellSRange = titleSTable.Cell(rowIndex, 2).Range;

                cellSRange.Text = item.FiestName + " " + item.LastName + " " + item.PatronomicName;

                cellSRange = titleSTable.Cell(rowIndex, 3).Range;

                cellSRange.Text = "";

                rowIndex++;
            }
            application.Visible = true;
            wordDock.SaveAs2($"{Directory.GetCurrentDirectory()}\\docs\\Test.docx");
            wordDock.SaveAs2($"{Directory.GetCurrentDirectory()}\\docs\\Test.pdf",Word.WdExportFormat.wdExportFormatPDF);
        }

        private void ProfileClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Students item = button.DataContext as Students;
            App.students = item;
            this.NavigationService.Navigate(new ProfilePage());
        }
    }
}
