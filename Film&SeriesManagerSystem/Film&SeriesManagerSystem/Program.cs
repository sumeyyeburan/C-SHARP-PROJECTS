
using Film_SeriesManagerSystem;
using System;

FilmManager filmManager=new FilmManager();
SeriesManager seriesManager=new SeriesManager();

Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.WriteLine("\nFilm ve Dizi Yönetim Sistemine Hoşgeldiniz!");

while (true)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\n1. Film İşlemleri");
    Console.WriteLine("2. Dizi İşlemleri");
    Console.WriteLine("0. Çıkış");
    Console.Write("\nİşleminiz: ");
    string YourChoice=Console.ReadLine();

    bool right = int.TryParse(YourChoice, out int yourChoice);
    if (right)
    {
        switch (yourChoice)
        {
            case 0:
                Console.ForegroundColor= ConsoleColor.DarkGreen;
                Console.WriteLine("\nSistemden çıkış yapılıyor...");
                return;
            case 1:
                while (true)
                {
                    Console.ForegroundColor=ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("\n1.Film Ekleme");
                    Console.WriteLine("2.Film Silme");
                    Console.WriteLine("3.Filmleri Listeleme");
                    Console.WriteLine("4.Çıkış");

                    Console.Write("\nYapmak istediğiniz işlem nedir? ");
                    string choiceFilm = Console.ReadLine();

                    // choiceFilm değişkeni int e çevrilir.Dönüşüm başarılı olursa choiceFilm değeri resultFilm değerime atanır ve acceptFilm true olur.Başarılı olmazsa resultFilm değişkenine 0 atanır ve acceptFilm false olur.String değer girilince hata fırlatmak yerine kontrolü sağlar.
                    bool acceptFilm = int.TryParse(choiceFilm, out int resultFilm);

                    if (acceptFilm)
                    {
                        switch (resultFilm)
                        {
                            case 1:
                                Console.ForegroundColor=ConsoleColor.White;
                                Console.WriteLine("\nEklemek istediğiniz filmin ID bilgisini,ismini,kategorisini ve imdb puanını giriniz");

                                Console.Write("\nID: ");
                                string FilmID = Console.ReadLine();
                                bool filmIDCheck = int.TryParse(FilmID, out int filmID);

                                Console.Write("İsmi: ");
                                string filmName = Console.ReadLine();

                                Console.Write("Kategorisi: ");
                                string category = Console.ReadLine();

                                Console.Write("IMDB puanı: ");
                                string PointIMDB = Console.ReadLine();
                                bool PointIMDBCheck = float.TryParse(PointIMDB, out float pointIMDB);

                                if (filmIDCheck && PointIMDBCheck)
                                {
                                    if (filmID >= 0 && pointIMDB > 0 && pointIMDB < 5)
                                    {
                                        filmManager.AddFilm(filmID, filmName, category, pointIMDB);
                                    }
                                    else
                                    {
                                        if (filmID < 0)
                                        {
                                            Console.ForegroundColor=ConsoleColor.DarkRed;
                                            Console.WriteLine("\nID bilgisi 0'dan küçük olamaz!");
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine("\nIMDB puanı 0 ve 5 aralığında olmalıdır!");
                                        }
                                    }
                                }
                                else
                                {
                                    if (filmIDCheck)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("\nIMDB Puanı float olmalıdır!");
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("\nID bilgisi integer olmalıdır!");
                                    }
                                }
                                break;

                            case 2:
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("\nSilmek istediğiniz filmin ID bilgisini giriniz: ");
                                string DeletedID = Console.ReadLine();
                                bool deletedIDCheck = int.TryParse(DeletedID, out int deletedID);

                                if (deletedIDCheck)
                                {
                                    if (deletedID >= 0)
                                    {
                                        filmManager.DeleteFilm(deletedID);
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("\nID bilgisi 0'dan küçük olamaz!");
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("\nID bilgisi integer olmalıdır!");
                                }
                                break;

                            case 3:
                                filmManager.DisplayFilm();
                                break;

                            case 4:
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.WriteLine("\nFilm menüsünden çıkış yapıldı.\n");
                                break;

                            default:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\nGeçersiz sayı girdiniz,tekrar deneyiniz!");
                                break;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nInteger dışında bir sayı girdiniz,tekrar deneyiniz!");
                        Console.WriteLine("\n************************************************************");
                        continue;
                    }

                    if (resultFilm == 4)
                    {
                        break;
                    }
                }
                break;
            case 2:
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("\n1.Dizi Ekleme");
                    Console.WriteLine("2.Dizi Silme");
                    Console.WriteLine("3.Dizileri Listeleme");
                    Console.WriteLine("4.Çıkış");

                    Console.Write("\nYapmak istediğiniz işlem nedir? ");
                    string choiceSeries = Console.ReadLine();

                    bool acceptSeries = int.TryParse(choiceSeries, out int resultSeries);

                    if (acceptSeries)
                    {
                        switch (resultSeries)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\nEklemek istediğiniz dizinin ID bilgisini,ismini,kategorisini ve imdb puanını giriniz");

                                Console.Write("\nID: ");
                                string seriesID = Console.ReadLine();

                                bool seriesIDCheck = int.TryParse(seriesID, out int SeriesID);

                                Console.Write("İsmi: ");
                                string SeriesName = Console.ReadLine();

                                Console.Write("Kategorisi: ");
                                string SeriesCategory = Console.ReadLine();

                                Console.Write("IMDB Puanı: ");
                                string seriesIMDB = Console.ReadLine();

                                bool seriesIMDBCheck = float.TryParse(seriesIMDB, out float SeriesIMDB);

                                if (seriesIDCheck && seriesIMDBCheck)
                                {
                                    if (SeriesID >= 0 && SeriesIMDB > 0 && SeriesIMDB < 5)
                                    {
                                        seriesManager.AddSeries(SeriesID, SeriesName, SeriesCategory, SeriesIMDB);
                                    }
                                    else
                                    {
                                        if (SeriesID < 0)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine("\nID bilgisi 0'dan küçük olamaz!");
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine("\nIMDB Puanı 0 ve 5 aralığında olmalıdır!");
                                        }
                                    }
                                }
                                else
                                {
                                    if (seriesIDCheck)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("\nIMDB Puanı float olmalıdır!");
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("\nID bilgisi integer olmalıdır!");
                                    }
                                }
                                break;

                            case 2:
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("Silmek istediğiniz dizinin ID bilgisini giriniz: ");
                                string DeletedID = Console.ReadLine();

                                bool deletedIDCheck = int.TryParse(DeletedID, out int deletedID);

                                if (deletedIDCheck)
                                {
                                    if (deletedID >= 0)
                                    {
                                        seriesManager.DeleteSeries(deletedID);
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("\nID bilgisi 0'dan küçük olamaz!");
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("\nID bilgisi integer olmalıdır!");
                                }
                                break;

                            case 3:
                                seriesManager.DisplaySeries();
                                break;

                            case 4:
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.WriteLine("\nDizi menüsünden çıkış yapıldı.\n");
                                break;

                            default:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\nGeçersiz sayı girdiniz,tekrar deneyiniz!\n");
                                break;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInteger dışında bir sayı girdiniz,tekrar deneyiniz!");
                        Console.WriteLine("\n************************************************************");
                        continue;
                    }

                    if (resultSeries == 4)
                    {
                        break;
                    }
                }
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nGeçersiz sayı girdiniz,tekrar deneyiniz.");
                break;
        }

    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nGirilen değer integer olmalı!");
    }
    Console.ResetColor();
}