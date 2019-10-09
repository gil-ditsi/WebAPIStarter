using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebAPIStarter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController : ControllerBase
    {
        public string appName { get; set; }

        public GreetingController(IConfiguration config){
            appName = config.GetValue<string>("applicationName");
        }

        [HttpGet]
        public string WhateverIWant(){
            return this.appName;
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