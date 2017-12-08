using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LeaderboardWebApi
{
    public class DBConnection
    {
        private string connectionString =
                @"Server=tcp:getacademy.database.windows.net,1433;Initial Catalog=Leaderboards;Persist Security Info=False;User ID=User;Password=Pasword123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            ;

        public string UploadNewUser(User newUser)
        {
            var query =
                "INSERT INTO [Users] ([UserName], [SecurityCode]) output INSERTED.UniqueId VALUES (@UserName, @SecurityCode)";
            var connection = new SqlConnection(connectionString);
            var writeCommand = new SqlCommand(query, connection);
            writeCommand.Parameters.AddWithValue("@UserName", newUser.Username);
            writeCommand.Parameters.AddWithValue("@SecurityCode", newUser.SecurityCode);

            connection.Open();
            var id = writeCommand.ExecuteScalar();
            return id.ToString();
        }

        public string UploadNewScore(Highscore newScore)
        {
            var query =
                "INSERT INTO [HighscoreEntry] ([UniqueId], [HighscoreName], [Highscore]) VALUES (@UniqueId, @HighscoreName, @Highscore)";
            var connection = new SqlConnection(connectionString);
            var writeCommand = new SqlCommand(query, connection);
            writeCommand.Parameters.AddWithValue("@UniqueId", newScore.UniqueId);
            writeCommand.Parameters.AddWithValue("@HighscoreName", newScore.Name);
            writeCommand.Parameters.AddWithValue("@Highscore", newScore.Score);

            try
            {
                connection.Open();
                writeCommand.ExecuteNonQuery();
                return "The upload was a sucsess!";
            }
            catch
            {
                return "Something went wrong!";
            }
        }

        public List<Highscore> GetScores(long uniqueId)
        {
            var query =
                "SELECT [UniqueId], [HighscoreName], [Highscore], [Timestamp] FROM [HighscoreEntry] WHERE UniqueId = @UniqueId";
            var connection = new SqlConnection(connectionString);
            var readCommand = new SqlCommand(query, connection);
            readCommand.Parameters.AddWithValue("@UniqueId", uniqueId);

            connection.Open();
            var reader = readCommand.ExecuteReader();

            var highscoreList = new List<Highscore>();
            while (reader.Read())
            {
                highscoreList.Add(new Highscore
                {
                    UniqueId = (long) reader[0],
                    Name = reader[1].ToString(),
                    Score = (long) reader[2],
                    TimeStamp = reader[3].ToString()
                });
            }
            return highscoreList.OrderByDescending(entry => entry.Score).ToList();
        }
    }
}