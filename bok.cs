using System;
using System.Collections.Generic;

public class Bok
{
    public int Id { get; set; }
    public string Titel { get; set; }
    public string Författare { get; set; }
    public string Genre { get; set; }
    public int År { get; set; }
    public string Isbn { get; set; }
    public List<int> Recensioner { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}, Titel: {Titel}, Författare: {Författare}, Genre: {Genre}, År: {År}, ISBN: {Isbn}, Genomsnittligt Betyg: {GenomsnittligtBetyg()}";
    }

    public double GenomsnittligtBetyg() => Recensioner.Any() ? Recensioner.Average() : 0.0;
}
