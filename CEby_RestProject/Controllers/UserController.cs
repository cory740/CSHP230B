using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public static int currentId = 1001;
        // GET: api/Users
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return users;
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var user = users.FirstOrDefault(t => t.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            return new OkObjectResult(user);
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody] Users value)
        {
            if (value == null)
            {
                return new BadRequestResult();
            }

            value.UserId = currentId++;
            value.DateCreated = DateTime.Now;

            users.Add(value);

            //var result = new { Id = value.Id, Candy = true };

            return CreatedAtAction(nameof(Get),
                new { id = value.UserId }, value);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Users value)
        {
            var user = users.FirstOrDefault(t => t.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            user.UserId = id;
            user.Email = value.Email;
            user.Password = value.Password;

            return Ok(user);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usersRemoved = users.RemoveAll(t => t.UserId == id);

            if (usersRemoved == 0)
            {
                return NotFound(); //404
            }

            return Ok(usersRemoved); //200
        }
    }
}
