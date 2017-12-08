using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaderboardWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/NewHighscore")]
    public class NewHighscoreController : Controller
    {
        [HttpGet]
        public string UploadNewScore([FromQuery] [Bind("UniqueId", "Name", "Score")] Highscore userInput)
        {
            var dbConnection = new DBConnection();
            var scoreUploadResult = dbConnection.UploadNewScore(userInput);

            return scoreUploadResult;
        }
    }
}