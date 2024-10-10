using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Runtime.ExceptionServices;

namespace Laba__5
{
    
    internal class Program
    {
        class FitnessProgram
        {
            public string Name
            {
                set { if (String.IsNullOrEmpty(value)) Name = value; }
                get { return Name; }
            }
            public string ExercisePlan { get; set; }
            private int CaloriesBurned;
            private int TotalExcesises;
            private int DailyTargetCalories;
            public string FitnessLevel;
            private bool Warning;
            public void CompleteExercise(int calories)
            {
                CaloriesBurned += calories;
                if (CaloriesBurned > 2000)
                {
                    FitnessLevel = "Спортсмен";
                }
                else if (CaloriesBurned > 1000)
                {
                    FitnessLevel = "Активный";
                }
                else FitnessLevel = "Новичек";
                if (CaloriesBurned < DailyTargetCalories) Warning = true;
                else Warning = false;
                TotalExcesises++;
            }
            public void ChangeExerisePlan(string NewPlan)
            {
                ExercisePlan += NewPlan;
            }
            public void SetDailyTargetCalories(int target)
            {
                DailyTargetCalories = target;
            }
            public string Motivate()
            {
                Random rnd = new Random();
                string filePath = "C:\\Users\\kdrt\\source\\repos\\Laba №5\\Laba №5\\data.txt";
                string[] motivates = File.ReadAllLines(filePath);
                string motivate = motivates[rnd.Next(motivates.Length)];
                return motivate;
            }
        }
        static void Main(string[] args)
        {
            bool create = false;
            FitnessProgram fitness_program = new FitnessProgram();
            while (true)
            {
                Console.Write("1. Задать имя и план тренировок\r\n2. Установить целевую норму калорий\r\n3. Задать новый план тренировок\r\n4. Поменять план тренировок\r\n5. Выполнить упражнение\r\n6. Вывести текущую информацию об уровне физической подготовки пользователя\r\n7. Вывести мотивационное сообщение\r\n");
                int x = Convert.ToInt32(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        if (create)
                        {
                            Console.WriteLine("Имя изменить нельзя");
                            break;
                        }
                        create = true;
                        Console.WriteLine("Введите имя");
                        string name = Console.ReadLine();
                        fitness_program.Name = name;
                        Console.WriteLine("Введите план тренировок");
                        string ExercisePlan = Console.ReadLine();
                        fitness_program.ChangeExerisePlan(ExercisePlan);
                        break;
                    case 2:
                        Console.WriteLine("Введите целевую норму колорий");
                        int target = Convert.ToInt32(Console.ReadLine());
                        fitness_program.SetDailyTargetCalories(target);
                        break;
                    case 3:
                        Console.WriteLine("Введите план тренировок");
                        ExercisePlan = Console.ReadLine();
                        fitness_program.ExercisePlan = ExercisePlan;
                        break;
                    case 4:
                        //Console.Write("Выберете:\n1. Добавить информацию в план\n2. Удалить информацию о тренировках");
                        //int y = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите план");
                        string str = Console.ReadLine();
                        fitness_program.ChangeExerisePlan(str);
                        break;
                    case 5:
                        Console.WriteLine("Введите кол-во сожженных во время упражнения");
                        int colories = Convert.ToInt32(Console.ReadLine());
                        fitness_program.CompleteExercise(colories);
                        break;
                    case 6:
                        Console.WriteLine(fitness_program.FitnessLevel);
                        break;
                    case 7:
                        Console.WriteLine(fitness_program.Motivate());
                        break;
                }
            }
        }
    }
}
