using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPIStarter.Models;

namespace WebAPIStarter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {

        private List<Customer> customers;
        public CustomerController(){
            this.customers = new List<Customer>{
                new Customer() { Id = 1, FirstName = "Gil", LastName = "Hdz", Email = "mah.mail@man.com" },
                new Customer() { Id = 2, FirstName = "Gil2", LastName = "Hdz", Email = "mah.mail@man.com" },
                new Customer() { Id = 3, FirstName = "Gil3", LastName = "Hdz", Email = "mah.mail@man.com" }
            };
        }

        [HttpGet("{Id}")]
        public Customer Read(int Id){
            return this.customers.Find( custId  => custId.Id == Id );
        }

        [HttpGet]
        public IEnumerable<Customer> GetAll(){
            return this.customers;
        }

        [HttpPost]
        public string Create(Customer newObject){
            return "Mama mia";
        }

        [HttpPut]
        public string Update(int Id, Customer changedObject){
            return "Modified";
        }

        [HttpDelete]
        public string Delete(int Id) {
            return "Thing No More";
        }
    }
}