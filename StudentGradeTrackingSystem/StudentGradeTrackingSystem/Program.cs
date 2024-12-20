
using StudentGradeTrackingSystem;
using System.Runtime.InteropServices;

LoginPage loginPage=new LoginPage();
RegisterPage registerPage=new RegisterPage();

Console.ForegroundColor=ConsoleColor.DarkBlue;
Console.WriteLine("\n===== Öğrenci Takip Sistemine Hoşgeldiniz =====");

while (true)
{
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("\n1.Giriş Yap");
    Console.WriteLine("2.Kayıt Ol");
    Console.WriteLine("3.Çıkış");

    Console.Write("\nSeçiminiz: ");
    string _choice = Console.ReadLine();

    bool checkChoice = int.TryParse(_choice, out int choice);

    if (choice == 3)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("\nSistemden çıkış yapıldı.");
        break;
        Console.ResetColor();
    }

    if (checkChoice)
    {
        if (choice == 1)
        {
            bool Check = loginPage.Start();

            if (Check)
            {
                loginPage.Operation();
            }
        }
        else if (choice == 2)
        {
            registerPage.Start();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nGeçersiz seçim yaptınız.");
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nSeçimiz integer olmalı.");
    }

    Console.ResetColor();
}