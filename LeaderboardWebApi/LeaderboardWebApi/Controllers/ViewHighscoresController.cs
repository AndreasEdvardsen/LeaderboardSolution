using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LeaderboardWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/ViewHighscores")]
    public class ViewHighscoresController : Controller
    {
        [HttpGet]
        public HighscoreCollection ViewHighscores([FromQuery] long id)
        {
            var dbConnection = new DBConnection();
            var highscores = dbConnection.GetScores(id);

            return new HighscoreCollection
            {
                Highscores = highscores
            };
        }
    }
}