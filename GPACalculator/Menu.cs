using System;

namespace GPACalculator
{
    public class Menu
    {
        // a property/variable that represents the current stage the user is in.
        private int currentStage;

        public Menu()
        {
            
        }
        public Menu(int initialStage)
        {
            this.currentStage = initialStage;
        }

        public static void PromptUser(string prompt)
        {
            Console.WriteLine(prompt);
        }

        public int GetCurrentStatge()
        {
            return this.currentStage;
        }

        public void SetCurrentStage(int stage)
        {
            this.currentStage = stage;
        }
    }
}