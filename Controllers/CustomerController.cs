using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPIStarter.Models;
using WebAPIStarter.Services.CustomerService;

namespace WebAPIStarter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        // private List<Customer> customers;
        private IService<Customer> CustomerService {get; set;}

        // public CustomerController()
        // {
        //     this.customers = new List<Customer>{
        //         // new Customer() { Id = 1, FirstName = "Gil", LastName = "Hdz", Email = "mah.mail@man.com" },
        //         // new Customer() { Id = 2, FirstName = "Gil2", LastName = "Hdz", Email = "mah.mail@man.com" },
        //         // new Customer() { Id = 3, FirstName = "Gil3", LastName = "Hdz", Email = "mah.mail@man.com" }
        //     };
        // }
        public CustomerController(IService<Customer> customerService = null){

            this.CustomerService = customerService ?? new InMemoryCustomerService();

        }

        [HttpGet("{Id}")]
        public IActionResult Read(int Id){
            // var res = this.customers.Find( custId  => custId.Id == Id );
            var res = this.CustomerService.GetOne(Id);
            if( res != null )
                return Ok(res);
            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult GetAll(){
            return Ok(this.CustomerService.GetAll());
        }

        [HttpPost]
        [Consumes("application/xml")]
        [Produces("application/xml", "application/json")]
        public IActionResult Create(Customer newObject){
            if(ModelState.IsValid){
                return Created("someuri", this.CustomerService.Add(newObject));
            }else{
                return ValidationProblem();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] Customer changedObject){
            if(ModelState.IsValid){
                this.CustomerService.Update(changedObject);
                return Created("someuri", changedObject);
            }else{
                return ValidationProblem();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int Id) {
            try{
                // this.customers.Remove(this.customers.Find( x => x.Id == Id ));
                var toDelete = this.CustomerService.GetOne(Id);
                if(toDelete != null){
                    this.CustomerService.Delete( toDelete );
                    return StatusCode(410);
                }else{
                    return NotFound();
                }
                
            }catch(Exception e){
                return StatusCode(501, e);
            }
        }
    }
}