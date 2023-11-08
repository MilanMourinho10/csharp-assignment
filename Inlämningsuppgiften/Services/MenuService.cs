using Inlämningsuppgiften.Interfaces;
using Inlämningsuppgiften.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsuppgiften.Services;

public class MenuService
{
    private static readonly ICustomerService customerService = new CustomerService();

    public static void AddCustomerMenu()
    {
        ICustomer customer = new Customer();
        // i detta fält så ska en kund skapas och sker genom att fylla i dem efterfrågade egenskperna
        Console.Write("Förnamn: ");
        customer.Förnamn = Console.ReadLine();
        Console.Write("Efternamn: ");
        customer.Efternamn = Console.ReadLine();
        Console.Write("E-postadress: ");
        customer.EpostAdress = Console.ReadLine();

        // Skapar adress  information om kunden som matar in sina uppgifter
        customer.Address = new Address();
        Console.Write("Gatuadress: ");
        customer.Address.GatuNamn = Console.ReadLine();
        Console.Write("Gatunummer ");
        customer.Address.GatuNummer = Console.ReadLine();
        Console.Write("Postnummer: ");
        customer.Address.PostKod = Console.ReadLine();
        Console.Write("Stad/Ort: ");
        customer.Address.Stad = Console.ReadLine();
        // Lägger till kunden med hjälp av aynkron operation
        Task.Run(() => customerService.AddCustomerAsync(customer));
    }

    public static void ViewAllCustomersMenu()
    {   // Loopar alla kunder som sen skriver ut deras information
        foreach (var customer in customerService.GetAllCustomers())
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Namn: " + customer.FullständigtNamn);
            Console.WriteLine("Address: " + customer.Address?.FullAddress);
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Tryck valfri knapp för att återgå till meny");
        }
    }

    public static void ViewOneCustomerMenu()
    {
        // Funktionen i detta fält är att kunna hämta en kund genom deras E-postadress
        Console.Write("E-postadress: ");
        var email = Console.ReadLine();

        var customer = customerService.GetOneCustomer(email!);
        // skriver ut informationen om kunden 
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Namn: " + customer?.FullständigtNamn);
        Console.WriteLine("Address: " + customer?.Address?.FullAddress);
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Tryck valfri knapp för att återgå till meny");
    }

    public static void RemoveOneCustomerMenu()
    { // denna funktion kan ta bort en kund med hjälp av att mata in personens E-postadress
        Console.Write("Skriv E-postadress på kunden du vill ta bort: ");
        var email = Console.ReadLine();

        customerService.RemoveCustomer(email!);
    }
    public static void MainMenu()
    {    // visar först och främst huvudmenyn och låter användaren välja ett av ovanstående alternativ
        do
        {
            Console.Clear();
            Console.WriteLine("1. Skapa en ny kund");
            Console.WriteLine("2. Visa alla kunder");
            Console.WriteLine("3. Visa en kund");
            Console.WriteLine("4. Ta bort en kund");
            Console.WriteLine("0. Avsluta");
            Console.Write("Välj något av följande alternativ: ");
            var option = Console.ReadLine();

            Console.Clear();

            switch (option)
            {
                case "1":
                    AddCustomerMenu();
                    break;

                case "2":
                    ViewAllCustomersMenu();
                    break;

                case "3":
                    ViewOneCustomerMenu();
                    break;

                case "4":
                    RemoveOneCustomerMenu();
                    break;

                case "0":
                    Environment.Exit(0);
                    break;
            }

            Console.ReadKey();

        } while (true);
    }
    

}

