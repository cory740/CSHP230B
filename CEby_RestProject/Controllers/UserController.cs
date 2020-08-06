using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEby_RestProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CEby_RestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<Users> users = new List<Users>();
        // GET: api/Users
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return users;
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return null;
        }

        // POST: api/Users
        [HttpPost]
        public void Post([FromBody] Users value)
        {
            users.Add(value);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Users value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
