using System.Collections.Generic;
using System.Linq;

namespace GPACalculator
{
    // <summary>
    // An mock of singleton design pattern
    // </summary>
    public class Db
    {
        private List<Course> CourseTable;

        public Db()
        {
            this.CourseTable = new List<Course>();
        }

        public static Db Initialize()
        {
            return new Db();
        }

        public void AddCourse(Course c)
        {
            this.CourseTable.Add(c);
        }

        // <summary>
        // removeCourse("svy101") when the courseCode in db is SVY101
        // </summary>
        // <param name="courseCode"> code of coure to remove</param>
        public void RemoveCourse(string courseCode)
        {
            Course c = this.CourseTable.FirstOrDefault(c => c.courseCode.ToLower() == courseCode.ToLower());
            this.CourseTable.Remove(c);
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return this.CourseTable;
        }

        public void RemoveAllCourses()
        {
            this.CourseTable.Clear();
        }

        // <summary>
        // in the works
        // </summary>
        // <param name="c"></param>
        public void UpdateCourse(Course c)
        {

        }
    }
}