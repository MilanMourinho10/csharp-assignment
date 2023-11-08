using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inlämningsuppgiften.Interfaces;

namespace Inlämningsuppgiften.Models;

public class Customer : ICustomer
{

    public string? Förnamn { get; set; } // ICustomer och har egenskaper för kundinformation inklusive förnamn, efternamn,
                                         // e-postadress och adress. FullständigtNamn returnerar kundens hela namn.
    public string? Efternamn { get; set; }
    public string? Telefonnummer { get; set; }
    public string? EpostAdress { get; set; } 
    public IAddress? Address { get; set; }


    public string? FullständigtNamn => $"{Förnamn} {Efternamn}";
}





