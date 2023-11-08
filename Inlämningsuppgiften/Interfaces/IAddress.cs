namespace Inlämningsuppgiften.Interfaces
{
    public interface IAddress
    {
        string? Stad { get; set; }   //Gränssnittet IAddress definierar egenskaper för adressinformation,
                                     // stad, postnummer, gatunamn och nummer som jag vill ha från kunden
        string? PostKod { get; set; }
        string? GatuNamn { get; set; }
        string GatuNummer { get; set; }
        string? FullAddress { get; }
    }
}