using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film_SeriesManagerSystem
{
    internal class FilmManager
    {
        private List<Film> films = new List<Film>();

        //ekleme
        public void AddFilm(int filmID,string filmName,string filmCategory,float filmPointIMDB)
        {
            if (films.Any(m => m.ID == filmID))
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\nBu ID bilgisine ait film bulunmaktadır.Farklı bir ID bilgisi giriniz: ");
                return;
            }

            films.Add(new Film
            {
                ID = filmID,
                Name = filmName,
                Category = filmCategory,
                PointIMDB = filmPointIMDB
            });

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nFilm listeye başarılı bir şekilde eklendi!");

            Console.ResetColor();
        }

        //silme
        public void DeleteFilm(int deletedID)
        {
            int removedID=films.RemoveAll(m=>m.ID == deletedID);

            if (removedID > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"\nID bilgisi {deletedID} olan filminiz listeden silinmiştir.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nGirilen ID bilgisine ait film bulunamamıştır.");
            }

            Console.ResetColor();
        }

        //listeleme
        public void DisplayFilm()
        {
            if(films.Count== 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nListede film bulunamamaktadır.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n----- Film Listesi -----\n");
                
                foreach(var film in films)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"ID: {film.ID} \nİsmi: {film.Name} \nKategorisi: {film.Category} \nIMDB Puanı: {film.PointIMDB.ToString("0.0")} ");

                    Console.ForegroundColor= ConsoleColor.Yellow;
                    Console.WriteLine("==============================================");
                }
            }

            Console.ResetColor();
        }
    }
}
