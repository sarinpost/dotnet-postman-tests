using PrivilegeCustomer.Models;
using PrivilegeCustomer.Services;
using Microsoft.AspNetCore.Mvc;

namespace PrivilegeCustomer.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    public CustomerController()
    {
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Customer>> GetAll() =>
    CustomerService.GetAll();

    // POST action
    [Route("EarnPoint")]
    [HttpPost]
    public ActionResult<Customer> EarnPoint([FromBody] Customer req)
    {
        var customer = CustomerService.Get(req.Id);

        if (customer == null)
            return NotFound();

        CustomerService.AddPoint(req.Id, req.Point);

        return NoContent();
    }

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Customer> Get(int id)
    {
        var customer = CustomerService.Get(id);

        if (customer == null)
            return NotFound();

        return customer;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Customer customer)
    {
        CustomerService.Add(customer);
        return CreatedAtAction(nameof(Create), new { id = customer.Id }, customer);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Customer customer)
    {
        if (id != customer.Id)
            return BadRequest();

        var existingCustomer = CustomerService.Get(id);
        if (existingCustomer is null)
            return NotFound();

        CustomerService.Update(customer);

        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var customer = CustomerService.Get(id);

        if (customer is null)
            return NotFound();

        CustomerService.Delete(id);

        return NoContent();
    }
}