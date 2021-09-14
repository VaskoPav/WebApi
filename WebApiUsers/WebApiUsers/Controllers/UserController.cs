using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return StatusCode(StatusCodes.Status200OK, StaticDb.Users);
        }

        // GET api/user/2
        [HttpGet("{id}")]
        public ActionResult <string> Get(int id)
        {
            try
            {
                if (id < 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Try again");
                }
                if(id >= StaticDb.Users.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                return StatusCode(200, StaticDb.Users[id]);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        //http://localhost:34603/api/user/1/users/6
        
        [HttpGet("{id}/users/{userId}")]
        public ActionResult <string> Get(int id, int userId)
        {
            if (id > 3)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Try 1,2,3");
            }
            string text = $"Your dogs name is {StaticDb.Users[id]} and his id is {userId}";
            return StatusCode(200, text);
        }

        [HttpGet("Info")]
        public ActionResult GetPath()
        {
            var reguest = Request;
            return StatusCode(StatusCodes.Status200OK, "Its good");
        }

    }
}
