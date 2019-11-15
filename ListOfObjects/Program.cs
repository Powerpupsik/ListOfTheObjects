using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfObjects
{
    class Person
    {
        public static int Count = 0;

        public string firstName;
        public string lastName;
        public int age;

        public Person(string _firstName, string _lastName, int _age)
        {
            firstName = _firstName;
            lastName = _lastName;
            age = _age;

            Count++;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\DEMO\people.txt";
            List<string> listOfPeople = File.ReadAllLines(filePath).ToList();
            List<Person> listOfPersonObjects = new List<Person>();

            foreach(string line in listOfPeople)
            {
                string[] tempArray = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Person newPerson = new Person(tempArray[0], tempArray[1], int.Parse(tempArray[2]));

                listOfPersonObjects.Add(newPerson);
            }

            foreach(Person person in listOfPersonObjects)
            {
                Console.WriteLine($"{person.firstName} {person.lastName}, age {person.age}, is in your list ");
            }
            
            Console.ReadLine();
        }
    }
}
