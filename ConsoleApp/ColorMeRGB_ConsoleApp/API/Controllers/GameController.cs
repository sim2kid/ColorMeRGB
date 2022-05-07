﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        // GET: api/<GameController>
        [HttpGet]
        [Route("get-all/{id}")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GameController>/5
        [HttpGet]
        [Route("get-by-id/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/<GameController>/5
        [HttpGet]
        [Route("get-by-user-id/{userId}")]
        public string Get(string userName)
        {
            return "value";
        }

        // POST api/<GameController>
        [HttpPost]
        [Route("insert-records")]
        public void Post([FromBody] string value)
        {
        }

        // DELETE api/<GameController>/5
        [HttpDelete]
        [Route("delete-by-id/{id}")]
        public void Delete(int id)
        {
        }
    }
}