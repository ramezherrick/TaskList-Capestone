using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace Capestone_TaskList
{
    class Task
    {
        //Fields 
        private string name;
        private string description;
        private DateTime dueDate;
        private bool status;

        //properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        //Constructor
        public Task() { }
        public Task(string Name, string Description, DateTime DueDate, bool Status)
        {
            name = Name;
            description= Description;
            dueDate = DueDate;
            status = Status;
        }
        public void PrintTask ()
        {
            int i;
            Console.WriteLine($"\tThe name: {name}");
            Console.WriteLine($"\tThe description: {description}");
            Console.WriteLine($"\tThe due date: {dueDate.ToShortDateString()}");
            Console.WriteLine($"\tCompleted? {status}");
            Console.WriteLine();
        }
        public void ChangeCompletionStatus()
        {
            status = true;
        }
    }
}
