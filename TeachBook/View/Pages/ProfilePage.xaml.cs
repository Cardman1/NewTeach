﻿using System;
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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        Core bc = new Core();
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
            if (ReadOtchenka.Text != null)
            {
                if(Convert.ToInt32(ReadOtchenka.Text)<=5 && Convert.ToInt32(ReadOtchenka.Text) >= 2)
                {
                    Journals item = selectedButton.DataContext as Journals;
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
    }
}
