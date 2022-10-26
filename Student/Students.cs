namespace Student
{
    public class Students
    {
        public int mark;
        public string fullName = "";
        public bool submittedOnTime;
        public Students(string fullName, int mark, bool submittedOnTime)
        {
            this.fullName = fullName;
            this.mark = mark;
            this.submittedOnTime = submittedOnTime;
        }

        public string GetDataInString()
        {
            return fullName + " - mark: " + mark + "\n";
        }
        public static double AvrgMark(Students[] students, int len)
        {
            if (len == 0)
            {
                return 0;
            }
            double sum = 0;
            int i;
            for (i = 0; i < len; i++)
            {
                sum += students[i].mark;
            }
            return sum / i;
        }
    }
}