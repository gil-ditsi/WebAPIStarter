using Microsoft.AspNetCore.Mvc;

namespace WebAPIStarter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController : ControllerBase
    {
        [HttpGet]
        public string WhateverIWant(){
            return "hi man!";
        }

        [HttpGet("{num}")]
        public string Get(int num){
            string mes = "HiMan";
            for (int i = 0; i < num; i++)
            {
                mes += "\nHi";
            }
            return mes;
        }
    }
}