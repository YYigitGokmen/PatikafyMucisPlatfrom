using PatikafyMusicPlatform;
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<patikafy> patikafy = new List<patikafy>();


        patikafy.Add(new patikafy() { nameandSurname = "Ajda Pekkan", musicType = "Pop", releaseDate = 1968, albumSales = 20 });
        patikafy.Add(new patikafy() { nameandSurname = "Sezen Aksu", musicType = "Türk Halk Müziği / Pop", releaseDate = 1971, albumSales = 10 });
        patikafy.Add(new patikafy() { nameandSurname = "Funda Arar", musicType = "Pop", releaseDate = 1999, albumSales = 3 });
        patikafy.Add(new patikafy() { nameandSurname = "Sertab Erener", musicType = "Pop", releaseDate = 1994, albumSales = 5 });
        patikafy.Add(new patikafy() { nameandSurname = "Sıla", musicType = "Pop", releaseDate = 2009, albumSales = 3 });
        patikafy.Add(new patikafy() { nameandSurname = "Serdar Ortaç", musicType = "Pop", releaseDate = 1994, albumSales = 10 });
        patikafy.Add(new patikafy() { nameandSurname = "Tarkan", musicType = "Pop", releaseDate = 1992, albumSales = 40 });
        patikafy.Add(new patikafy() { nameandSurname = "Hande Yener", musicType = "Pop", releaseDate = 1992, albumSales = 7 });
        patikafy.Add(new patikafy() { nameandSurname = "Hadise", musicType = "Pop", releaseDate = 2005, albumSales = 5 });
        patikafy.Add(new patikafy() { nameandSurname = "Gülben Ergen", musicType = "Türk Halk Müziği / Pop", releaseDate = 1997, albumSales = 10 });
        patikafy.Add(new patikafy() { nameandSurname = "Neşet Ertaş", musicType = "Türk Halk Müziği / Türk sanat Müziği", releaseDate = 1960, albumSales = 2 });


        var namesStartingWithS = patikafy.Where(p => p.nameandSurname.Length > 0 && p.nameandSurname[0] == 'S').ToList();

        //Adı 'S' ile başlayan şarkıcılar
        Console.WriteLine("Names starting with 'S':");
        foreach (var p in namesStartingWithS)
        {
            Console.WriteLine(p.nameandSurname);
        }

        Console.WriteLine("---------------------------------------------");


        var albumsWithMoreThan10MillionSales = patikafy
                         .Where(p => p.albumSales > 10)
                         .ToList();

        //Albüm satışları 10 milyon'un üzerinde olan şarkıcılar
        Console.WriteLine("Albums with sales more than 10 million:");
        foreach (var p in albumsWithMoreThan10MillionSales)
        {
            Console.WriteLine($"{p.nameandSurname} - {p.albumSales} million");
        }

        Console.WriteLine("---------------------------------------------");

        //2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar. ( Çıkış yıllarına göre gruplayarak, alfabetik bir sıra ile yazdırınız.


        var singersGroupedByYear = patikafy
           .Where(p => p.releaseDate < 2000 && p.musicType.Contains("Pop"))
           .OrderBy(p => p.nameandSurname)
           .GroupBy(p => p.releaseDate)
           .OrderBy(g => g.Key);

        Console.WriteLine("Singers who debuted before 2000 and made pop music, grouped by release year:");


        foreach (var group in singersGroupedByYear)
        {
            Console.WriteLine($"Year: {group.Key}");
            foreach (var p in group)
            {
                Console.WriteLine($"- {p.nameandSurname}");
            }

            Console.WriteLine("---------------------------------------------");
            //En çok albüm satan şarkıcı
            var singerWithMostAlbumSales = patikafy.OrderByDescending(p => p.albumSales).FirstOrDefault();

            if (singerWithMostAlbumSales != null)
            {
                Console.WriteLine($"The singer with the most album sales is {singerWithMostAlbumSales.nameandSurname} with {singerWithMostAlbumSales.albumSales} million albums sold.");
            }


            Console.WriteLine("---------------------------------------------");

            var singerWithNewestDebut = patikafy.OrderByDescending(p => p.releaseDate).FirstOrDefault();

            if(singerWithNewestDebut != null) 
                         { Console.WriteLine($"The singer with newest debut is : {singerWithNewestDebut.nameandSurname}"); }


            Console.WriteLine("---------------------------------------------");

            var singerWithOldestDebut = patikafy.OrderBy(p => p.releaseDate).FirstOrDefault();

            if (singerWithOldestDebut != null)
            { Console.WriteLine($"The singer with oldest debut is : {singerWithOldestDebut.nameandSurname}"); }
            //En yeni çıkış yapan şarkıcı ve en eski çıkış yapan şarkıcı



        }

    }

}