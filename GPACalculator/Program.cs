using System.Collections.Generic;
using System.Linq;
using System;

namespace GPACalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // a program that calculates gradePoint average 
            // Input -->a series of  course codes,a series of scores for each course code.
            // a gradePointCalculator that calculates the GradePoint of a course given its score
            // some sort of dashboard that prints grade points
            //a menu that prompts the users on what they want to do
            // i can probably use an enum to check my current stage
            Menu menu = new Menu();
            menu.SetCurrentStage(1);
            Db appDb = Db.Initialize();
            
            bool appIsRunning = true;
            // always perform this when the user is in top menu
            while (appIsRunning)
            {
                while (menu.GetCurrentStatge() == 1)
                {
                    Menu.PromptUser("What would you like to do Today? ");
                    Menu.PromptUser("1. Add Courses to DB: ");
                    Menu.PromptUser("2. Calculate Grade Point Averages of Courses in Db: ");
                    Menu.PromptUser("3. Exit");
                    string selectedMenuOption = Console.ReadLine();
                    switch (selectedMenuOption)
                    {
                        case "1":
                            menu.SetCurrentStage(2);
                            break;
                        case "2":
                            menu.SetCurrentStage(3);
                            break;
                        case "3":
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                    Console.Clear();
                }

                while (menu.GetCurrentStatge() == 2)
                {
                    // we want to tell the user to add a set of courses and their scores
                    // and then we want to store those courses in some sort of Database/ collection
                    // we need to know how many courses the user is entering a score for ..
                    // we can design a prompt that runs for each of the courses 

                    Menu.PromptUser($"Select an Option: ");
                    Menu.PromptUser($"Enter Number of Courses (enter a number): ");
                    Menu.PromptUser($"Back to Main Menu (b)");
                    string input = Console.ReadLine().ToLower();
                    int numberOfCourses;
                    if (input == "b")
                    {
                        menu.SetCurrentStage(1);
                    }
                    else if (Int32.TryParse(input, out numberOfCourses))
                    {
                        for (int i = 1; i <= numberOfCourses; i++)
                        {
                            Menu.PromptUser($"Enter a Course Code for Course {i}: ");
                            string courseCode = Console.ReadLine();

                            Menu.PromptUser($"Enter a Score for {courseCode}: ");
                            double score = Convert.ToDouble(Console.ReadLine());

                            Menu.PromptUser($"Enter a number of Units for {courseCode}: ");
                            int units = Convert.ToInt32(Console.ReadLine());

                            appDb.AddCourse(new Course(courseCode, score, units));
                        }
                        menu.SetCurrentStage(1);
                    }
                    Console.Clear();
                }

                while (menu.GetCurrentStatge() == 3)
                {
                    var myData = appDb.GetAllCourses();
                
                    if (!myData.Any()) // myData.Count() == 0
                    {
                        Menu.PromptUser($"No Course Added... ");
                        Menu.PromptUser($" ");
                        menu.SetCurrentStage(1);
                    }
                    else
                    {
                        GPACal.CourseList(myData);
                        
                        Menu.PromptUser($" ");
                        Menu.PromptUser($"Are your Data Correct? ");
                        Menu.PromptUser($"If correct, Enter 'Yes' to continue or 'Edit' to Edit or 'No' to start again:  ");
                        string yesOrNO = Console.ReadLine().ToLower();

                        while (yesOrNO != "yes" && yesOrNO != "no" && yesOrNO != "edit")
                        {
                            Menu.PromptUser($" ");
                            Menu.PromptUser($"Invalid option");
                            Menu.PromptUser($"Please, Are your Data Correct? ");
                            Menu.PromptUser("If correct, Enter 'Yes' to continue or 'Edit' to Edit or 'No' to start again :");
                            yesOrNO = Console.ReadLine();
                        }

                        if (yesOrNO == "yes")
                        {
                            GPACal.Calculator(myData);
                            menu.SetCurrentStage(1);   
                        }
                        else if (yesOrNO == "edit")
                        {
                            Menu.PromptUser($"Enter the Course Code you want to remove");
                            string removeCourseName = Console.ReadLine();
                            appDb.RemoveCourse(removeCourseName);
                            Menu.PromptUser($"{removeCourseName} removed ");
                            Menu.PromptUser($" ");
                            menu.SetCurrentStage(1);
                        }
                        else
                        {
                            Menu.PromptUser($"All Courses Cleared, Fill out the Form Again!!!");
                            appDb.RemoveAllCourses();
                            Menu.PromptUser($" ");
                            menu.SetCurrentStage(1);
                        }    
                    }
                }
            }
        }
    }
}
