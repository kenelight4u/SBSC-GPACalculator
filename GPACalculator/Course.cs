namespace GPACalculator
{
    public class Course
    {
        public string courseCode { get; private set; }  

        public double courseScore { get; private set; }

        public int numberOfUnits { get; private set; }

        public Course(string code, double score, int numberOfUnits)
        {
            this.courseCode = code;

            this.courseScore = score;

            this.numberOfUnits = numberOfUnits;
        }
    }
}