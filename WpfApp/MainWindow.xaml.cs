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

        private void studentListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EducationTypeComboBox.IsEnabled = false;
            int slctdInd = studentListComboBox.SelectedIndex;
            if (slctdInd <= budgetLen)
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
            //slctdInd = slctdInd <= budgetLen ? slctdInd : slctdInd - budgetLen;
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
                StudentsLabel.Content = budgetStudents[budgetLen].GetDataInString();
                
                budgetLen++;
            }
            else
            {
                paidStudents[paidLen] = new PaidStudents(name, mark, onTime);
                paidLen++;
            }
            studentListComboBox.Items.Clear();
            for (int i = 0; i < budgetLen+paidLen; i++)
            {
                if(i<budgetLen)
                {
                    studentListComboBox.Items.Add(budgetStudents[i].GetDataInString());
                }
                else
                {
                    studentListComboBox.Items.Add(paidStudents[i-budgetLen].GetDataInString());
                }
                    
            }
        }
    }
}
