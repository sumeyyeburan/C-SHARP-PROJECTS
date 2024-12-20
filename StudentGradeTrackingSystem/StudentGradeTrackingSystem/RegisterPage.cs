using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradeTrackingSystem
{
    internal class RegisterPage
    {

        StudentManager studentManager = StudentManager.Instance;
        public void Start()
        {
            Console.ForegroundColor= ConsoleColor.DarkYellow;
            Console.WriteLine("\n***** Kayıt Ol *****\n");

            Console.Write("Öğrenci numaranız: ");
            string no = Console.ReadLine();

            Console.Write("Adınız: ");
            string name = Console.ReadLine();

            Console.Write("Soyadınız: ");
            string lastName = Console.ReadLine();

            Console.Write("Şifreniz: ");
            string password = Console.ReadLine();

            studentManager.Register(no,name, lastName, password);

        }
    }
}
