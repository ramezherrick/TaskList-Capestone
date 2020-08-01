using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Transactions;

namespace Capestone_TaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 0; int taskNumber = -1; int number; int choice = 0;

            List<Task> taskList = new List<Task>()
            {
                new Task ("ramez","work",DateTime.Parse("1/1/2007"),false),
                new Task ("andoni","work",DateTime.Parse("1/1/2008"),false),
                new Task ("steve","work",DateTime.Parse("1/1/2009"),false)
            };
            
            while (num != 5)
            {
                Console.WriteLine("Welcome to the Task Manager!");
                Console.WriteLine("1. List tasks");
                Console.WriteLine("2. Add task");
                Console.WriteLine("3. Delete task");
                Console.WriteLine("4. Mark task complete");
                Console.WriteLine("5. Quit");
                Console.WriteLine();

                number = ValidateInteger("Enter you choice 1 through 5: ", 5);

                if (1 <= number && number <= 5)
                {
                    if (number == 1)
                    {
                        while (true)
                        {
                            Console.WriteLine("1. ALL tasks");
                            Console.WriteLine("2. Individual person's task");
                            Console.WriteLine("3. Find tasks by due date");

                            choice = ValidateInteger ("Enter a number: ",3);

                            if (choice == 1)
                            {
                                PrintTaskList(taskList, taskList.Count);
                                break;
                            }
                            else if (choice == 2)
                            {
                                //1 Point: Allow the user to display tasks for only one team member
                                DisplayOneTask(taskList);
                                
                                break;
                            }

                            else if (choice == 3)
                            {
                                //1 Point: Allow the user to display tasks with a due date before a date they choose
            
                                Console.Write("Enter a date, to display tasks with a due date before a that date");
                                DateTime Date = DateTime.Parse(Console.ReadLine());

                                PrintTaskBeforeDate(taskList, Date);

                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid Entry - Please try again\n");
                            }
                        }
                    }
                    if (number == 2)
                    {
                        AddNewTask(taskList);
                    }
                    if (number == 3)
                    {
                        DeleteTask(taskList);
                    }
                    if (number == 4)
                    {
                        ChangeCompletionStatus(taskList);
                    }
                    else if (number == 5)
                    {
                        break;
                    }
                }
                else
                {
                    Console.Write("\nInvalid Entry - Please try again");               
                }

            }
        }

        public static string GetStringInput(string str)
        {
            Console.Write(str);
            string input = Console.ReadLine().ToLower();
            return input;
        }

        public static int ValidateInteger (string str, int listCount)
        {
            int taskNumber;

            while (!int.TryParse(GetStringInput(str), out taskNumber))
            {
                Console.WriteLine($"\nPlease enter a numerical value between {1} and {listCount}\n");
            }

            return taskNumber;
        }
        public static void PrintTaskList (List<Task> input, int listCount)
        {
            for (int i = 0; i < listCount; i++)
            {
                Console.Write($"Task {i + 1}");
                input[i].PrintTask();
            }
        }
        public static void DisplayOneTask (List<Task> input)
        {
            string name = GetStringInput("Enter name: ");

            foreach (Task task in input)
            {
                if (task.Name.Contains(name))
                {
                    task.PrintTask();
                }
            }
        }
        public static void PrintTaskBeforeDate (List<Task> input, DateTime Date)
        {
            foreach (Task task in input)
            {
                if (task.DueDate < Date)
                {
                    task.PrintTask();
                }
            }
        }
        public static void AddNewTask(List<Task> taskList)
        {
            string name = GetStringInput("Team Member Name: ");
            string description = GetStringInput("Task Description: ");
            Console.Write("Due Date: ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
            bool status = false;
            taskList.Add(new Task(name, description, date, status));
        }
        public static void DeleteTask (List<Task> taskList)
        {
            int taskNumber;
            while (true)
            {
                PrintTaskList(taskList, taskList.Count);

                taskNumber = ValidateInteger($"Which task would you like to delete? (Available tasks are {1} through {taskList.Count})", taskList.Count);

                if (taskNumber > taskList.Count || taskNumber < 1)
                {
                    Console.WriteLine($"Task:{taskNumber} does not exist");
                    continue;
                }

                else
                {
                    Console.WriteLine($"You chose This task: ");
                    taskList[taskNumber - 1].PrintTask();
                    Console.Write("Are you sure, you want to delete it (Y/N)?");
                    string delete = Console.ReadLine().ToLower();
                    if (delete == "y")
                    {
                        taskList.RemoveAt(taskNumber - 1);
                    }
                    break;
                }
            }
        }
        public static void ChangeCompletionStatus (List<Task> taskList)
        {
            int taskNumber;
            PrintTaskList(taskList, taskList.Count);
            while (true)
            {
                taskNumber = ValidateInteger($"Which task number would you like to change? (Available tasks are {1} through {taskList.Count})", taskList.Count);

                if (taskNumber > taskList.Count || taskNumber < 1)
                {
                    Console.WriteLine($"Task:{taskNumber} does not exist\n");
                    continue;
                }
                else
                {
                    Console.WriteLine($"\nThis is the task that you chose: task = {taskNumber}");
                    taskList[taskNumber - 1].PrintTask();

                    Console.Write("\nAre you sure you want to change the completion status (y/n)? ");
                    string input = Console.ReadLine().ToLower();

                    if (input == "y")
                    {
                        taskList[taskNumber - 1].ChangeCompletionStatus();
                    }
                    else if (input == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("\nInvalid entry - are you sure you want to change the completion status (y/n)? ");
                        input = Console.ReadLine();
                    }
                    break;
                }
            }
        }
    }
}

