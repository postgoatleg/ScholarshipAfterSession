using Student;
namespace StudentsOfBudgetForm
{
    public class BudgetStudents : Students
    {
        public BudgetStudents(string fullName, int mark, bool submittedOnTime) : base(fullName, mark, submittedOnTime)
        {
        }

        private static int DefaultScholarship()
        {
            return 90;
        }

        public double ScholarshipSize()
        {
            if (submittedOnTime == true)
            {
                return mark switch
                {
                    < 5 => 0,
                    >= 8 => DefaultScholarship() * 1.5,
                    > 6 => DefaultScholarship() * 1.25,
                    _ => DefaultScholarship(),
                };
            }
            else
            {
                return 0;
            }
        }

        public static double AvrgScholarship(BudgetStudents[] budgetStudents, int len)
        {
            double sum = 0; 
            int i;
            for(i = 0; i < len; i++)
            {
                sum += budgetStudents[i].ScholarshipSize();
            }
            return sum/i;
        }
    }
}