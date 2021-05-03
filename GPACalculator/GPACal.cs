using System;
using System.Collections.Generic;

namespace GPACalculator
{
    public class GPACal
    {

        public static void CourseList(IEnumerable<Course> myList)
        {
            Menu.PromptUser($"The Data inputted are: ");
            Menu.PromptUser($"{"Course Code", -15} | {"Units", 5} | {"Score", 5}");
            foreach (var data in myList)
            {
                Menu.PromptUser($"{data.courseCode.ToUpper(), -15} {data.numberOfUnits, 5} {data.courseScore, 7}");
            }
        }

        public static void Calculator(IEnumerable<Course> myData)
        {
            double unitsTimesGradePoint = 0d; int sumUnits = 0; decimal gpa = 0M;
            Grades myGrade; int myGradePoint;

            Menu.PromptUser($"The Data inputted are: ");
            Menu.PromptUser($"{"Course Code", -15} | {"Units", 5} | {"Score", 5} | {"Grade", 5}");
            foreach (var value in myData)
            {
            
                if (value.courseScore >= 70 && value.courseScore < 100)
                {
                    myGrade = Grades.A;
                    myGradePoint = (int) Grades.A;
                }
                else if (value.courseScore >= 60 && value.courseScore < 70)
                {
                    myGrade = Grades.B;
                    myGradePoint = (int) Grades.B;
                }
                else if (value.courseScore >= 50 && value.courseScore < 60)
                {
                    myGrade = Grades.C;
                    myGradePoint = (int) Grades.C;
                }
                else if (value.courseScore >= 40 && value.courseScore < 50)
                {
                    myGrade = Grades.D;
                    myGradePoint = (int) Grades.D;
                }
                else
                {
                    myGrade = Grades.F;
                    myGradePoint = (int) Grades.F;
                }

                unitsTimesGradePoint += myGradePoint * value.numberOfUnits;
                sumUnits += value.numberOfUnits;
                Menu.PromptUser($"{value.courseCode.ToUpper(), -15} {value.numberOfUnits, 5} {value.courseScore, 7} {myGrade, 7}");
            }
            gpa = Convert.ToDecimal(unitsTimesGradePoint)  / sumUnits;
            Menu.PromptUser($"GPA is: {gpa}");

            Console.ReadKey();
            Console.Clear();
            // appDb.RemoveAllCourses();
            
        }
    }
}