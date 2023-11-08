using Inlämningsuppgiften.Models;

namespace Inlämningsuppgiften.Interfaces
{
    public interface ICustomer
    {
        string? Förnamn { get; set; } // Gränssnittet ICustomer har egenskaper för kundinformation
                                      // inklusive förnamn, efternamn, e-postadress och en adress (IAddress) som vi vill ha från kunden. 
        string? Efternamn { get; set; }
        string? Telefonnummer { get; set; }
        string? EpostAdress { get; set; }
        IAddress? Address { get; set; }
        
        string? FullständigtNamn { get; } // Denna kod returnerar fullständiga namnet på kunden. 

    }
}