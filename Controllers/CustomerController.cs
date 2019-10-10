using Microsoft.AspNetCore.Mvc;
using WebAPIStarter.Models;

namespace WebAPIStarter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public Customer Read(){
            var data = new Customer() {
                Id = 1,
                FirstName = "Gil",
                LastName = "Hdz",
                Email = "mah.mail@man.com"
            };
            return data;
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