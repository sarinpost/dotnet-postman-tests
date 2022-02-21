using PrivilegeCustomer.Models;

namespace PrivilegeCustomer.Services;

public static class CustomerService
{
    static List<Customer> Customers { get; }
    static int nextId = 3;
    static CustomerService()
    {
        Customers = new List<Customer>
        {
            new Customer { Id = 1, FirstName = "Sarin", LastName ="Anuttranon", Point = 10 }
        };
    }

    public static List<Customer> GetAll() => Customers;
    public static Customer? Get(int id) => Customers.FirstOrDefault(p => p.Id == id);
    public static void Add(Customer customer)
    {
        customer.Id = nextId++;
        Customers.Add(customer);
    }

    public static void Delete(int id)
    {
        var customer = Get(id);
        if (customer is null)
            return;

        Customers.Remove(customer);
    }

    public static void Update(Customer customer)
    {
        var index = Customers.FindIndex(p => p.Id == customer.Id);
        if (index == -1)
            return;

        Customers[index] = customer;
    }

    public static void AddPoint(int id, int point)
    {
        var index = Customers.FindIndex(p => p.Id == id);
        if (index == -1)
            return;

        Customers[index].Point += point;
    }
}