using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CA20211018_02
{
    class Program
    {
        static List<Chinchilla> csincsillak = new List<Chinchilla>();
        static void Main(string[] args)
        {
            //using (var sr = new StreamReader(@"..\..\Res\chi.txt", Encoding.UTF8))
            //{
            //    while (!sr.EndOfStream) csincsillak.Add(new Chinchilla(sr.ReadLine()));
            //}

            var sr = new StreamReader(@"..\..\Res\chi.txt",Encoding.UTF8);           
            while (!sr.EndOfStream)
            {
                csincsillak.Add(new Chinchilla(sr.ReadLine()));
            }
            Console.WriteLine($"2.feladat: \nÖsszesen {csincsillak.Count} db Chinchilla van");
            int db = 0;
            bool van = false; 
            foreach (var x in csincsillak)
            {
                if (x.Simi == true)
                {
                    db++;
                }
            }
            Console.WriteLine("{0:0.00}% szereti a simit", (float)db / csincsillak.Count * 100);

            var oscs = csincsillak.Where(x => x.Kor > 8 && x.Suly < 360).FirstOrDefault();
            Console.WriteLine($"4.feladat:\n{(oscs is null ? "nincs ilyen csincsilla" : $"{oscs.Nev} {Math.Floor(oscs.Kor)} éves és {oscs.Suly}")}");

            var rend = csincsillak.OrderByDescending(x => x.Suly).ToList();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("{0,-12} {1} g",rend[i].Nev, rend[i].Suly);
            }
            csincsillak
                .GroupBy(x => x.Szul.Year)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Key}: {x.Count()}"));
            Console.ReadKey();
        }
    }
}
