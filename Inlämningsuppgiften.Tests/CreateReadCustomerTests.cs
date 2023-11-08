using Inlämningsuppgiften.Services;
using Inlämningsuppgiften.Interfaces;
using Inlämningsuppgiften.Models;
using System.Net;

namespace Inlämningsuppgiften.Tests
{
    public class CreateReadCustomerTests
    {
        [Fact]

        // Testet testar ifall vi vi kan skapa kunden och lägga till "hen" i listan 
        public async Task CreateCustomerAsync_ShouldCreateCustomerToList_ReturnTrue()  
        {
            // steg 1 (förbereder testets olika förutsättningar
            ICustomerService customerService = new CustomerService();              
            var customer = new Customer         
            {                                               
                Förnamn = "Milan",
                Efternamn = "Hussein",
                EpostAdress = "vemletarduefter@gmail.com",
                Telefonnummer = "0762393215",
                Address = new Address
                {
                    GatuNamn = "Fasanstigen",
                    GatuNummer = "10",
                    PostKod = "19732",
                    Stad = "Stocktown"
                }
            };


            // steg 2 utförandet (act) av testet genom att anropa AddCustomerAsync 
            await customerService.AddCustomerAsync(customer);        


            // steg 3 (Assert) verifierar ifall utfallet av testet blev som jag hade tänkt
            var returnedCustomer = customerService.GetOneCustomer(customer.EpostAdress); 

            Assert.NotNull(returnedCustomer);                                     
            Assert.Equal(customer.Förnamn, returnedCustomer.Förnamn);            
            Assert.Equal(customer.EpostAdress, returnedCustomer.EpostAdress);                  
            Assert.Equal(customer.Telefonnummer, returnedCustomer.Telefonnummer);      
            Assert.Equal(customer.Address?.FullAddress, returnedCustomer.Address?.FullAddress); 
        }
    }
}