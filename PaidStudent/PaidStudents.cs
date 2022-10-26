using Student;
namespace PaidStudent
{
    public class PaidStudents : Students
    {
        public PaidStudents(string fullName, int mark, bool submittedOnTime) : base(fullName, mark, submittedOnTime)
        {
        }

        public static string SubmitedOnTimeString(PaidStudents[] paidStudents, int len)
        {
            string sum = "";
            int i;
            for (i = 0; i < len; i++)
            {
                if(paidStudents[i].submittedOnTime)
                {
                    sum += $"{paidStudents[i].fullName} - {paidStudents[i].mark}\n";
                }
            }
            return sum;
        }
    }
}