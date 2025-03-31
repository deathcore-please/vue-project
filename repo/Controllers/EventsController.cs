using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CameKmsStarter.Controllers
{
    [ApiController] //API Controller Class
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly string _connectionString = @"Data Source=C:\Users\HP\Desktop\Everything Else\Python Projects\vue-project\repo\Database\events.db";  //path to events.db for later use

        [HttpGet]
        public IActionResult GetEvents() //returns "sorted", a list of sorted events with corresponding attributes
        {
            var events = new List<EventDto>();    //variable class storing attributes such as eventid, datetime, etc

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
                            events.Add(ev);   //adds values to each eventdto in the list
                        }
                    }

                    foreach (var ev in events)
                    {
                        ev.Location = BuildLocationPath(ev.AreaId, connection);  //makes the location string using the areaid attribute
                    }
                }

                var sorted = events.OrderByDescending(e => e.DateTime).ToList();
                return Ok(sorted);  //returns sorted NOT events
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private string BuildLocationPath(int areaId, SqliteConnection connection) //returns a string (location attribute as mentioned in problem statement)
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

    public class EventDto   //data transfer object (whatever that means) gets stored in a list to send to the frontend as json
    {
        public int EventId { get; set; }
        public DateTime DateTime { get; set; }
        public int AreaId { get; set; }
        public string FobCode { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
    }
}
