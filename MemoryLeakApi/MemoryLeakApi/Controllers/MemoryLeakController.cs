using Microsoft.AspNetCore.Mvc;

namespace MemoryLeakApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MemoryLeakController : ControllerBase
{
    private static Processor P = new();
    
    [HttpGet]
    [Route("memleak/{kb}")]
    public ActionResult<string> memleak(int kb)
    {
        int it = (kb * 1000) / 100;
        for (int i = 0; i < it; i++)
        {
            P.ProcessTransaction(new Customer(Guid.NewGuid().ToString()));
        }

        return "success:memleak";
    }
    
    class Customer
    {
        public Customer(string id)
        {
        }
    }
    
    class CustomerCache
    {
        private List<Customer> cache = new();

        public void AddCustomer(Customer c)
        {
            cache.Add(c);
        }
    }
    
    class Processor
    {
        private CustomerCache cache = new();

        public void ProcessTransaction(Customer customer)
        {
            cache.AddCustomer(customer);
        }
    }
}