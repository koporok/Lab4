
using DocuSign.eSign.Model;
using University.Library;


namespace University
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GroupNumber { get; set; }
        private int age;

        public int Age
        {
            get { return age; }  
            set { age = value; } 
        }


        public void DisplayInfo()
        {
            Console.WriteLine($"Студент {Name}, группа {GroupNumber}, возраст {Age} лет.");
        }

        public static string GetNameById(Student[] students, int id)
        {
            foreach (Student student in students)
            {
                if (student.Id == id)
                {
                    return student.Name;
                }
            }
            return "Студент не найден";
        }


    }

    namespace Library
    {
        public class Reader
        {
            private string fullName;

            public string FullName
            {
                get { return fullName; }
                set { fullName = value; }
            }

            public int LibraryCardNumber { get; set; }
            public string Faculty { get; set; }
            private DateTime dateOfBirth;
            public DateTime DateOfBirth
            {
                get { return dateOfBirth; }
                set { dateOfBirth = value; }
            }
            public string PhoneNumber { get; set; }

            public void takeBook(int count)
            {
                Console.WriteLine($"{FullName} взял {count} книги.");
            }

            public void takeBook(params string[] bookTitles)
            {
                Console.Write($"{FullName} взял книги: ");
                foreach (string title in bookTitles)
                {
                    Console.Write($"{title}, ");
                }
                Console.WriteLine();
            }

            public void returnBook(int count)
            {
                Console.WriteLine($"{FullName} вернул {count} книги.");
            }

            public void returnBook(params string[] bookTitles)
            {
                Console.Write($"{FullName} вернул книги: ");
                foreach (string title in bookTitles)
                {
                    Console.Write($"{title}, ");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            University.Student[] students = new University.Student[3];
            students[0] = new University.Student { Id = 1, Name = "Титов И.Г.", GroupNumber = "21Ит17", Age = 20 };
            students[1] = new University.Student { Id = 2, Name = "Прокопенко А.А.", GroupNumber = "21ИТ17", Age = 18 };
            students[2] = new University.Student { Id = 3, Name = "Цыка А.А.", GroupNumber = "21ИТ17", Age = 19 };

            Library.Reader[] readers = new Library.Reader[3];
            readers[0] = new Library.Reader { FullName = Student.GetNameById(students, 1), LibraryCardNumber = 1, Faculty = "ИТ", DateOfBirth = new DateTime(2000, 1, 1), PhoneNumber = "89087665486н25" };
            readers[1] = new Library.Reader { FullName = Student.GetNameById(students, 2), LibraryCardNumber = 2, Faculty = "Медицина", DateOfBirth = new DateTime(1999, 2, 2), PhoneNumber = "+86045г3683" };
            readers[2] = new Library.Reader { FullName = Student.GetNameById(students, 3), LibraryCardNumber = 3, Faculty = "Химия", DateOfBirth = new DateTime(1998, 3, 3), PhoneNumber = "89047153436" };


            foreach (var student in students)
            {
                student.DisplayInfo();
            }
            foreach (var reader in readers)
            {
                reader.takeBook(2);
                reader.takeBook(reader.Faculty);

                reader.returnBook(1);
                reader.returnBook(reader.Faculty);
            }


        }
    }
}
