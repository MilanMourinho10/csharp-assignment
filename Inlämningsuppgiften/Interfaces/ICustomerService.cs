namespace Inlämningsuppgiften.Interfaces
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(ICustomer customer);// ICustomerService definierar metoder för att lägga till,
                                                  // hämta, och ta bort kunder.
        IEnumerable<ICustomer> GetAllCustomers();
        ICustomer GetOneCustomer(string email);
        void RemoveCustomer(string email);
    }
}