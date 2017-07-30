using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Vidly.Models;
using Vidly.Dtos;
using Vidly.App_Start;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
      private ApplicationDbContext _context;

      public CustomersController()
      {
          _context = new ApplicationDbContext();
      }

      // GET /api/customers
      public IHttpActionResult GetCustomers(string query = null)
      {
        var customersQuery = _context.Customers
          .Include(c => c.MembershipType);

        if (!String.IsNullOrWhiteSpace(query))
          customersQuery = customersQuery.Where(c => c.Name.Contains(query));

        var customerDtos = customersQuery
            .ToList()
            .Select(Mapper.Map<Customer, CustomerDto>);

        return Ok(customerDtos);
      }

      public IHttpActionResult GetCustomer(int id)
      {
          var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

          if (customer == null)
            return NotFound();

          return Ok(Mapper.Map<Customer, CustomerDto>(customer));
      }

      // POST /api/customer
      [HttpPost]
      public IHttpActionResult CreateCustomer(CustomerDto customerDto)
      {
        if (!ModelState.IsValid)
          return BadRequest();

        var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
        _context.Customers.Add(customer);
        _context.SaveChanges();

        customerDto.Id = customer.Id;

        return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
      }

      // PUT /api/customer/id
      [HttpPut]
      public void UpdateCustomer(int id, CustomerDto customerDto)
      {
        if (!ModelState.IsValid)
          throw new HttpResponseException(HttpStatusCode.BadRequest);

        var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

        if (customerInDb == null)
          throw new HttpResponseException(HttpStatusCode.NotFound);

        Mapper.Map(customerDto, customerInDb);

        _context.SaveChanges();
      }

      // DELETE /api/customer/id
      [HttpDelete]
      public void DeleteCustomer(int id)
      {
        var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

        if (customerInDb == null)
          throw new HttpResponseException(HttpStatusCode.NotFound);

        _context.Customers.Remove(customerInDb);
        _context.SaveChanges();
      }
    }
}
