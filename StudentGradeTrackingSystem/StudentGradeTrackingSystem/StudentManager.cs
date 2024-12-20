using System;
using System.Collections.Generic;
using System.Linq;  //firstordefault bu kütüphaneye ait 
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentGradeTrackingSystem
{
    internal class StudentManager
    {

        private static StudentManager _instance;
        public static StudentManager Instance => _instance ??= new StudentManager();
        private StudentManager() { }

        public Student CurrentStudent { get; private set; }

        List<Student> students = new List<Student>();
        public bool Login(string number, string password)
        {
            bool check = false;
            bool numberCheck = int.TryParse(number, out int _ID);

            if(numberCheck)
            {
                // FirstOrDefault => Koleksiyon veya liste üzerinde çalışır. Bu fonksiyon, belirli bir koşulu sağlayan ilk elemanı döndürür. Eğer koleksiyon içinde böyle bir eleman yoksa, varsayılan değeri döndürür(null).
                var student = students.FirstOrDefault(s => s.ID == _ID);

                if (student != null)
                {
                    if(student.Password==password)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nBaşarılı bir şekilde giriş yaptınız.");
                        check = true;

                        CurrentStudent=student;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nŞifrenizi yanlış girdiniz.");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nÖğrenci numarasına ait öğrenci bulunamamaktadır.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nÖğrenci numarası integer olmalıdır.");
            }

            Console.ResetColor();

            return check;
        }

        public void UpdateGrade()
        {
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine("\n---- Notlarınız ----\n");

            Console.WriteLine($"1- Vize: {CurrentStudent.Midterm}");
            Console.WriteLine($"2- Final: {CurrentStudent.Final}");

            Console.ForegroundColor=ConsoleColor.White;
            Console.WriteLine("\nDeğiştirmek istediğiniz notun numarasını giriniz \nEğer iki notu da değiştirmek istiyorsanız 0 giriniz.");
            string op = Console.ReadLine();

            bool CheckNote = int.TryParse(op, out int _op);

            if(CheckNote)
            {
                if (_op == 1)
                {
                    Console.ForegroundColor=ConsoleColor.Blue;
                    Console.Write("\nGüncel vize notunuzu giriniz: ");
                    string midtermNote= Console.ReadLine();

                    bool CheckMid=int.TryParse(midtermNote,out int _midtermNote);

                    if (CheckMid)
                    {
                        if(_midtermNote>=0 && _midtermNote <= 100)
                        {
                            CurrentStudent.Midterm = _midtermNote;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nVize notunuz başarılı bir şekilde güncellenmiştir.");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\nNotunuz 0 ve 100 aralığında olmalıdor.");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nNotunuz integer türünden olmalıdır.");
                    }
                }

                else if (_op == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\nGüncel final notunuzu giriniz: ");
                    string finalNote = Console.ReadLine();

                    bool CheckFinal = int.TryParse(finalNote, out int _finalNote);

                    if (CheckFinal)
                    {
                        if (_finalNote >= 0 && _finalNote <= 100)
                        {
                            CurrentStudent.Final = _finalNote;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nFinal notunuz başarılı bir şekilde güncellenmiştir.");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\nNotunuz 0 ve 100 aralığında olmalıdor.");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nNotunuz integer türünden olmalıdır.");
                    }
                }

                else if (_op == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\nGüncel vize notunuzu giriniz: ");

                    string midtermNote2 = Console.ReadLine();
                    bool CheckMid2 = int.TryParse(midtermNote2, out int _midtermNote2);

                    Console.Write("Güncel final notunuzu giriniz: ");

                    string finalNote2 = Console.ReadLine();
                    bool CheckFinal2 = int.TryParse(finalNote2, out int _finalNote2);

                    if (CheckMid2 && CheckFinal2)
                    {
                        if (_midtermNote2 >= 0 && _midtermNote2 <= 100 && _finalNote2 >= 0 && _finalNote2 <= 100)
                        {
                            CurrentStudent.Midterm = _midtermNote2;
                            CurrentStudent.Final = _finalNote2;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nVize ve Final Notunuz başarılı bir şekilde güncellenmiştir.");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\nNotunuz 0 ve 100 aralığında olmalıdır.");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nNotunuz integer türünden olmalıdır.");
                    }
                }

                else
                {
                    Console.ForegroundColor= ConsoleColor.DarkRed;
                    Console.WriteLine("\nGeçersiz  değer giriniz.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nGirdiğiniz değer integer olmalıdır.");
            }

            Console.ResetColor();
        }

        public void DisplayGrades()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n---- Notlarınız ----\n");

            Console.WriteLine($"1- Vize: {CurrentStudent.Midterm}");
            Console.WriteLine($"2- Final: {CurrentStudent.Final}");

            Console.ResetColor();
        }

        public void CalculateAverage()
        {
            float average = 0;

            average = (CurrentStudent.Midterm * 0.4f) + (CurrentStudent.Final * 0.6f);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\nNot Ortalamanız: {average}");

            Console.ResetColor();
        }

        public void Register(string StudentNumber,string StudentName,string StudentLastName,string Password)
        {
            bool CheckNo = int.TryParse(StudentNumber, out int _StudentNumber);

            if(CheckNo)
            {
                var newStudent = new Student
                {
                    ID = _StudentNumber,
                    Name = StudentName,
                    LastName = StudentLastName,
                    Password = Password,
                    Midterm = 0, // Varsayılan değer
                    Final = 0    // Varsayılan değer
                };

                // Öğrenciyi listeye ekle
                students.Add(newStudent);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nÖğrenci başarıyla listeye eklendi!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nöğrenci numarası integer türünden olmalıdır.");
            }

            Console.ResetColor();
        }
    }
}
