using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaderboardWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/NewUser")]
    public class NewUserController : Controller
    {
        [HttpGet]
        public string NewUser([FromQuery] [Bind("Username", "SecurityCode")] User userInput )
        {
            var dbConnection = new DBConnection();
            var newUser = dbConnection.UploadNewUser(userInput);

            return "Name: " + userInput.Username + " - SecurityID: " + userInput.SecurityCode + " - UniqueID: " + newUser;
        }

        [HttpGet("{id}")]
        public string NewUser(string isForm, [FromQuery] [Bind("Username", "SecurityCode")] User userInput )
        {
            var dbConnection = new DBConnection();
            var newUser = dbConnection.UploadNewUser(userInput);

            return "Name: " + userInput.Username + "<br>SecurityID: " + userInput.SecurityCode + "<br>UniqueID: " + newUser;
        }
    }
}