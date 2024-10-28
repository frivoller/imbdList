using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmListesi
{
    class Film
    {
        public string Isim { get; set; }
        public double ImdbPuani { get; set; }

        public Film(string isim, double imdbPuani)
        {
            Isim = isim;
            ImdbPuani = imdbPuani;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Film> filmListesi = new List<Film>();
            string devam;

            do
            {
                Console.Write("Film Adı: ");
                string isim = Console.ReadLine();

                Console.Write("IMDB Puanı: ");
                double imdbPuani;
                while (!double.TryParse(Console.ReadLine(), out imdbPuani))
                {
                    Console.WriteLine("Geçerli bir IMDB puanı giriniz.");
                }

                filmListesi.Add(new Film(isim, imdbPuani));

                Console.Write("Yeni bir film eklemek istiyor musunuz? (evet/hayır): ");
                devam = Console.ReadLine().ToLower();

            } while (devam == "evet");

            // Bütün filmleri listele
            Console.WriteLine("\nBütün Filmler:");
            foreach (var film in filmListesi)
            {
                Console.WriteLine($"Film: {film.Isim}, IMDB Puanı: {film.ImdbPuani}");
            }

            // IMDB puanı 4 ile 9 arasında olan filmleri listele
            Console.WriteLine("\nIMDB Puanı 4 ile 9 arasında olan Filmler:");
            var filtrelenmisFilmler = filmListesi.Where(f => f.ImdbPuani >= 4 && f.ImdbPuani <= 9);
            foreach (var film in filtrelenmisFilmler)
            {
                Console.WriteLine($"Film: {film.Isim}, IMDB Puanı: {film.ImdbPuani}");
            }

            // İsmi 'A' ile başlayan filmleri listele
            Console.WriteLine("\nİsmi 'A' ile Başlayan Filmler:");
            var aIleBaslayanFilmler = filmListesi.Where(f => f.Isim.StartsWith("A", StringComparison.OrdinalIgnoreCase));
            foreach (var film in aIleBaslayanFilmler)
            {
                Console.WriteLine($"Film: {film.Isim}, IMDB Puanı: {film.ImdbPuani}");
            }
        }
    }
}
