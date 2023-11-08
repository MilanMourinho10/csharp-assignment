using Inlämningsuppgiften.Interfaces;
using Inlämningsuppgiften.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsuppgiften.Services;

public class CustomerService : ICustomerService
{
    private List<ICustomer> _customers = new List<ICustomer>(); // En privat lista för att lagra en samling av kunder som registreras.
    private static readonly string filePath = @"C:\kod\customer.json"; // En privat statiskt läsbar fält för sökvägen där kunddata kommer att lagras i JSON-format.


    public async Task AddCustomerAsync(ICustomer customer) // En metod för att asynkront lägga till en kund i listan och spara den i en JSON-fil.
    {
        _customers.Add(customer);  // Lägg till kunden i listan. Gör kundinformationen om till ett JSON-format.
                                   // Använder SaveToFileAsync-funktionen i FileService för att spara kundinformationen som en fil.
        var json = JsonConvert.SerializeObject(customer);
        await FileService.SaveToFileAsync(JsonConvert.SerializeObject(json));
    }

    // // En metod för att hämta alla kunder till min kundlista.
    public IEnumerable<ICustomer> GetAllCustomers()
    {
        return _customers;
    }

    // En metod för att hämta en specifik kund med hjälp av en e-postadress från listan.
    public ICustomer GetOneCustomer(string email)
    {
        return _customers.FirstOrDefault(x => x.EpostAdress == email)!;
    }


    public void RemoveCustomer(string email)
    {
        var customer = GetOneCustomer(email);
        _customers.Remove(customer);

    }

}





   