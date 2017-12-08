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
        public string NewUser([FromQuery] [Bind("Username", "SecurityCode")] User userInput)
        {
            var dbConnection = new DBConnection();
            var newUser = dbConnection.UploadNewUser(userInput);

            return
                "Welcome! here is your user info. Keep it safe, there will be no way to get it back if you forget it (yet)." +
                " - Username: " + userInput.Username +
                " - Sequrity Code: " + userInput.SecurityCode +
                " - UserID: " + dbConnection.UploadNewUser(userInput);
        }
    }
}