using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CameKmsStarter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly string _connectionString = @"Data Source=C:\Users\HP\Desktop\Everything Else\Python Projects\vue-project\repo\Database\events.db";

        [HttpGet]
        public IActionResult GetEvents()
        {
            var events = new List<EventDto>();

            try
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    var cmd = connection.CreateCommand();
                    cmd.CommandText = @"SELECT EventId, DateTime, AreaId, FobCode, Type FROM Event";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var ev = new EventDto
                            {
                                EventId = reader.GetInt32(0),
                                DateTime = DateTime.Parse(reader.GetString(1)),
                                AreaId = reader.GetInt32(2),
                                FobCode = reader.GetString(3),
                                Type = reader.GetString(4)
                            };
                            events.Add(ev);
                        }
                    }

                    foreach (var ev in events)
                    {
                        ev.Location = BuildLocationPath(ev.AreaId, connection);
                    }
                }

                var sorted = events.OrderByDescending(e => e.DateTime).ToList();
                return Ok(sorted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private string BuildLocationPath(int areaId, SqliteConnection connection)
        {
            var path = new List<string>();
            int? currentId = areaId;

            while (currentId != null)
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT Name, ParentAreaId FROM Area WHERE AreaId = $id";
                cmd.Parameters.AddWithValue("$id", currentId.Value);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        path.Insert(0, reader.GetString(0));
                        currentId = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1);
                    }
                    else break;
                }
            }

            return string.Join(" > ", path);
        }
    }

    public class EventDto
    {
        public int EventId { get; set; }
        public DateTime DateTime { get; set; }
        public int AreaId { get; set; }
        public string FobCode { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
    }
}
