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
using Student;
using PaidStudent;
using StudentsOfBudgetForm;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PaidStudents[] paidStudents = new PaidStudents[20];
        int paidLen = 0, budgetLen = 0;
        BudgetStudents[] budgetStudents = new BudgetStudents[20];
        public MainWindow()
        {
            InitializeComponent();

            

        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            editButton.IsEnabled = false;
            addButton.IsEnabled = true;
            studentListComboBox.IsEnabled = true;
            EducationTypeComboBox.IsEnabled = true;
            string name = NameTextBox.Text;
            int educationType = EducationTypeComboBox.SelectedIndex;
            int mark = Convert.ToInt32(MarkTextBox.Text);
            bool onTime = onTimeCheckBox.IsChecked == true;
            if (educationType == 1)
            {
                budgetStudents[studentListComboBox.SelectedIndex] = new BudgetStudents(name, mark, onTime);
            }
            else
            {
                paidStudents[studentListComboBox.SelectedIndex - budgetLen] = new PaidStudents(name, mark, onTime);
            }
            RefillComboBox();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            int educationType = EducationTypeComboBox.SelectedIndex;
            int mark = Convert.ToInt32(MarkTextBox.Text);
            bool onTime = onTimeCheckBox.IsChecked == true;
            if(educationType == 1)
            {
                budgetStudents[budgetLen] = new BudgetStudents(name, mark, onTime);
                budgetLen++;
            }
            else
            {
                paidStudents[paidLen] = new PaidStudents(name, mark, onTime);
                paidLen++;
            }
            RefillComboBox();
        }

        private void chooseStudentButton_Click(object sender, RoutedEventArgs e)
        {
            editButton.IsEnabled = true;
            addButton.IsEnabled = false;
            studentListComboBox.IsEnabled = false;
            EducationTypeComboBox.IsEnabled = false;
            int slctdInd = studentListComboBox.SelectedIndex;
            if (slctdInd < budgetLen)
            {
                NameTextBox.Text = budgetStudents[slctdInd].fullName;
                EducationTypeComboBox.SelectedIndex = 1;
                MarkTextBox.Text = budgetStudents[slctdInd].mark.ToString();
            }
            else
            {
                slctdInd -= budgetLen;
                NameTextBox.Text = paidStudents[slctdInd].fullName;
                EducationTypeComboBox.SelectedIndex = 0;
                MarkTextBox.Text = paidStudents[slctdInd].mark.ToString();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            paidSubmitOnTimeLabel.Content = PaidStudents.SubmitedOnTimeString(paidStudents, paidLen);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            avgSchoolarshipLabel.Content = $"Average scolarship - {BudgetStudents.AvrgScholarship(budgetStudents, budgetLen)}";
        }

        private void avgMarkButton_Click(object sender, RoutedEventArgs e)
        {
            double part1 = Students.AvrgMark(budgetStudents, budgetLen);
            double part2 = Students.AvrgMark(paidStudents, paidLen);
            double final=0;
            if (part1 == 0|| part2 == 0)
            {
                final = part1 + part2;
            }
            else
            {
                final = (part1 + part2) / 2;
            }
            avgMarkLabel.Content = $"Average mark - {final}";
        }

        private void deleteStudentButton_Click(object sender, RoutedEventArgs e)
        {
            int slctdInd = studentListComboBox.SelectedIndex;
            if (slctdInd < budgetLen)
            {
                for(int i = slctdInd; i < budgetLen-1; i++)
                {
                    budgetStudents[i] = budgetStudents[i+1];
                }
                budgetLen--;
            }
            else
            {
                for (int i = slctdInd-budgetLen; i < paidLen - 1; i++)
                {
                    paidStudents[i] = paidStudents[i + 1];
                }
                paidLen--;
            }
            RefillComboBox();
        }

        private void RefillComboBox()
        {
            studentListComboBox.Items.Clear();
            for (int i = 0; i < budgetLen + paidLen; i++)
            {
                if (i < budgetLen)
                {
                    studentListComboBox.Items.Add(budgetStudents[i].GetDataInString());
                }
                else
                {
                    studentListComboBox.Items.Add(paidStudents[i - budgetLen].GetDataInString());
                }

            }
        }
    }
}
