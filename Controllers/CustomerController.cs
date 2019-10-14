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
        public IActionResult Read(int Id){
            var res = this.customers.Find( custId  => custId.Id == Id );
            if( res != null)
                return Ok(res);
            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult GetAll(){
            return Ok(this.customers);
        }

        [HttpPost]
        [Consumes("application/xml")]
        [Produces("application/xml", "application/json")]
        public IActionResult Create(Customer newObject){
            if(ModelState.IsValid){
                this.customers.Add(newObject);
                return Created("someuri", newObject);
            }else{
                return ValidationProblem();
            }
        }

        [HttpPut("{id}")]
        public string Update([FromRoute] int Id, [FromBody] Customer changedObject){
            return "Modified";
        }

        [HttpDelete("{id}")]
        public string Delete(int Id) {
            return "Thing No More";
        }
    }
}