using System;
using System.IO;
using System.Collections.Generic;

using System.Linq; // vaja, et massiivi listiks muuta
using System.Text;
using System.Threading.Tasks;

namespace TaskList
{
    class Task
    {
        public static int Count = 0;

        public string description;

        public Task(string _description)
        {
            description = _description;

            Count++;
                
        }

       
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\DEMO\taskList.txt";  // @ on oluline; muidu ei saa \\ kasutada
            List<string> lines = File.ReadAllLines(filePath).ToList();
            List<Task> taskList = new List<Task>();


            /*  kontrollimiseks ainult
             *  foreach (string line in lines)
              {
                  Console.WriteLine($"{lines}");
              } */


            foreach (string line in lines)
            {
                // CREATE A TASK OBJECT AT EACH LINE THAT WE RED FROM THE FILE
                Task newTask = new Task(line);
                taskList.Add(newTask);
                // add the object to the taskList
            }

            int i = 1;

            foreach(Task task in taskList)
            {
                Console.WriteLine($"Task {i} on your TO-DO list is to {task.description}");
                i++; //kui i asemel panna j, siis algab ilusti 1st numbrid
            }

            // get a task from user 
            Console.WriteLine("Add a new task: ");
            //save the task to the userTaskInputVariable
            string userTaskInput = Console.ReadLine();
            // create a new Task class object with userTaskInput as a parameter
            Task userTask = new Task(userTaskInput);
            // save the userTask to the taskList
            taskList.Add(userTask);

            Console.WriteLine("\n Updatede task list: ");
            foreach(Task task in taskList)
            {
                Console.WriteLine($"Task {i} on your TO-DO list is to {task.description}");
                i++;
            }

            List<string> outputToWriteToFile = new List<string>();

            foreach(Task task in taskList)
            {
                outputToWriteToFile.Add($"{task.description}");
            }

            Console.WriteLine("Writing to a file...");
            //Write to outputToWriteToFile
            File.WriteAllLines(filePath, outputToWriteToFile);
            Console.WriteLine("Your task has been added");





            Console.ReadLine();
        }
    }
}
