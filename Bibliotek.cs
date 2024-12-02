using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var bibliotek = new Bibliotek();

        // Läs data från JSON-fil
        bibliotek.LäsFrånFil();

        // Lägg till fördefinierad data om biblioteket är tomt
        if (!bibliotek.Böcker.Any() && !bibliotek.Författare.Any())
        {
            var författare1 = new Författare { Id = 1, Namn = "J.K. Rowling", Land = "Storbritannien" };
            var författare2 = new Författare { Id = 2, Namn = "George Orwell", Land = "Storbritannien" };
            bibliotek.LäggTillFörfattare(författare1);
            bibliotek.LäggTillFörfattare(författare2);

            var bok1 = new Bok
            {
                Id = 1,
                Titel = "Harry Potter och de vises sten",
                Författare = "J.K. Rowling",
                Genre = "Fantasy",
                År = 1997,
                Isbn = "9780747532699",
                Recensioner = new List<int> { 5, 5, 4, 5, 4 }
            };

            var bok2 = new Bok
            {
                Id = 2,
                Titel = "1984",
                Författare = "George Orwell",
                Genre = "Dystopi",
                År = 1949,
                Isbn = "9780451524935",
                Recensioner = new List<int> { 5, 4, 5, 5, 4 }
            };

            bibliotek.LäggTillBok(bok1);
            bibliotek.LäggTillBok(bok2);
        }

        // Kör huvudmenyn
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Välkommen till Bibliotekshanteringssystemet!");
            Console.WriteLine("1. Lägg till en ny bok");
            Console.WriteLine("2. Lägg till en ny författare");
            Console.WriteLine("3. Lista alla böcker");
            Console.WriteLine("4. Lista alla författare");
            Console.WriteLine("5. Sök böcker efter genre");
            Console.WriteLine("6. Sök böcker efter författare");
            Console.WriteLine("7. Sortera böcker efter publiceringsår");
            Console.WriteLine("8. Avsluta och spara");
            Console.Write("Välj ett alternativ (1-8): ");

            var val = Console.ReadLine();

            switch (val)
            {
                case "1":
                    LäggTillNyBok(bibliotek);
                    break;
                case "2":
                    LäggTillNyFörfattare(bibliotek);
                    break;
                case "3":
                    bibliotek.ListaBöcker();
                    Pausa();
                    break;
                case "4":
                    bibliotek.ListaFörfattare();
                    Pausa();
                    break;
                case "5":
                    SökBöckerEfterGenre(bibliotek);
                    break;
                case "6":
                    SökBöckerEfterFörfattare(bibliotek);
                    break;
                case "7":
                    bibliotek.SorteraBöckerEfterÅr();
                    Pausa();
                    break;
                case "8":
                    bibliotek.SkrivTillFil();
                    Console.WriteLine("Data sparad. Programmet avslutas.");
                    return;
                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    Pausa();
                    break;
            }
        }
    }

    static void LäggTillNyBok(Bibliotek bibliotek)
    {
        Console.Clear();
        Console.Write("Ange titel: ");
        string titel = Console.ReadLine();
        Console.Write("Ange författare: ");
        string författare = Console.ReadLine();
        Console.Write("Ange genre: ");
        string genre = Console.ReadLine();
        Console.Write("Ange publiceringsår: ");
        int år = int.Parse(Console.ReadLine());
        Console.Write("Ange ISBN: ");
        string isbn = Console.ReadLine();

        var nyBok = new Bok
        {
            Id = bibliotek.Böcker.Count + 1,
            Titel = titel,
            Författare = författare,
            Genre = genre,
            År = år,
            Isbn = isbn,
            Recensioner = new List<int>()
        };

        bibliotek.LäggTillBok(nyBok);
        Console.WriteLine("Bok tillagd!");
        Pausa();
    }

    static void LäggTillNyFörfattare(Bibliotek bibliotek)
    {
        Console.Clear();
        Console.Write("Ange namn: ");
        string namn = Console.ReadLine();
        Console.Write("Ange land: ");
        string land = Console.ReadLine();

        var nyFörfattare = new Författare
        {
            Id = bibliotek.Författare.Count + 1,
            Namn = namn,
            Land = land
        };

        bibliotek.LäggTillFörfattare(nyFörfattare);
        Console.WriteLine("Författare tillagd!");
        Pausa();
    }

    static void SökBöckerEfterGenre(Bibliotek bibliotek)
    {
        Console.Clear();
        Console.Write("Ange genre: ");
        string genre = Console.ReadLine();
        bibliotek.SökBöckerEfterGenre(genre);
        Pausa();
    }

    static void SökBöckerEfterFörfattare(Bibliotek bibliotek)
    {
        Console.Clear();
        Console.Write("Ange författarens namn: ");
        string författare = Console.ReadLine();
        bibliotek.SökBöckerEfterFörfattare(författare);
        Pausa();
    }

    static void Pausa()
    {
        Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
        Console.ReadKey();
    }
}
