using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEby_RestService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CEby_RestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static List<Users> users = new List<Users>();
        public static int currentId = 1001;
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = users.FirstOrDefault(t => t.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            return new OkObjectResult(user);
        }

        // POST api/<UsersController>
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

            return CreatedAtAction(nameof(Get), new { id = value.UserId }, value);
        }

        // PUT api/<UsersController>/5
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

        // DELETE api/<UsersController>/5
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
