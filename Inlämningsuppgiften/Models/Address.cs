using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Inlämningsuppgiften.Interfaces;

namespace Inlämningsuppgiften.Models
{
    public class Address : IAddress
    {
        public string? GatuNamn { get; set; } // Klassen "Address" implementerar gränssnittet IAddress med egenskaper för
                                              // gatuadress, postnummer, stad och en skrivskyddad egenskap för hela adressen. 
                                              //Detta är kundinformationen jag vill ha av kunder.
        public string? GatuNummer { get; set; } 

        public string? PostKod { get; set; }
        public string? Stad { get; set; }

        public string? FullAddress => $"{GatuNamn} {GatuNummer}, {PostKod} {Stad}";

    }
}
