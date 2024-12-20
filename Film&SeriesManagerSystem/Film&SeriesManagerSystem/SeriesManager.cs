using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film_SeriesManagerSystem
{
    internal class SeriesManager
    {
        private List<Film> series = new List<Film>();

        // ekleme
        public void AddSeries(int seriesID,string seriesName,string seriesCategory,float seriesPointIMDB)
        {
            if (series.Any(m => m.ID == seriesID))
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\nBu ID bilgisine ait dizi bulunmaktadır.Farklı bir ID bilgisi giriniz: ");
                return;
            }
            else
            {
                series.Add(new Film
                {
                    ID= seriesID,
                    Name= seriesName,
                    Category= seriesCategory,
                    PointIMDB= seriesPointIMDB
                });

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nDizi listeye başarılı bir şekilde eklendi!");
            }

            Console.ResetColor();
        }

        // silme
        public void DeleteSeries(int deletedID)
        {
            int removedId=series.RemoveAll(m=>m.ID==deletedID);

            if(removedId>0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"\nId bilgisi {deletedID} olan diziniz listeden silinmiştir.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nGirilen ID bilgisine ait dizi bulunamamıştır.");
            }

            Console.ResetColor();
        }

        // listemele
        public void DisplaySeries()
        {
            if (series.Count == 0)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("\nListede dizi bulunamamaktadır.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n----- Dizi Listesi -----\n");

                foreach(var s in series)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"ID: {s.ID} \nİsmi: {s.Name} \nKategorisi: {s.Category} \nIMDB Puanı: {s.PointIMDB}");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("==============================================");

                    Console.ResetColor();
                }

            }
        }
    }
}
