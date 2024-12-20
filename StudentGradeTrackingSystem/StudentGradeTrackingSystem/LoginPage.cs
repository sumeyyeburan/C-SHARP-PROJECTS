using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradeTrackingSystem
{
    internal class LoginPage
    {
        StudentManager studentManager = StudentManager.Instance;
        public bool Start()
        {
            Console.WriteLine("\n***** Giriş Yap *****\n");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Öğrenci numarası");
            string studentNumber = Console.ReadLine();

            Console.WriteLine("Şifre");
            string studentPassword = Console.ReadLine();

            bool result=studentManager.Login(studentNumber, studentPassword);

            Console.ResetColor();

            return result;
        }

        public void Operation()
        {
            while(true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine();
                Console.WriteLine("1.Not Güncelleme");
                Console.WriteLine("2.Notları Görüntüleme");
                Console.WriteLine("3.Ortalama Hesaplama");
                Console.WriteLine("4.Çıkış");

                Console.Write("\nİşleminiz: ");
                string operation=Console.ReadLine();

                bool opCheck=int.TryParse(operation, out int _opertaion);

                if(opCheck)
                {
                    switch (_opertaion)
                    {
                        case 1:
                            studentManager.UpdateGrade();
                            break;
                        case 2:
                            studentManager.DisplayGrades();
                            break;
                        case 3:
                            studentManager.CalculateAverage();
                            break;
                        case 4:
                            Console.ForegroundColor=ConsoleColor.DarkYellow;
                            Console.WriteLine("\nBaşarılı bir şekilde çıkış yapıldı.");
                            return;
                        default:
                            Console.ForegroundColor=ConsoleColor.DarkRed;
                            Console.WriteLine("Geçersiz işlem.");
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.DarkRed;
                    Console.WriteLine("\nİşleminiz integer türünden olmalıdır.");
                }

            }
        }
    }
}
