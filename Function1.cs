using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace azure_event
{
    public class Bookings
    {
        private readonly ILogger<Bookings> _logger;

        public Bookings(ILogger<Bookings> logger)
        {
            _logger = logger;
        }

        [Function("Bookings")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            var bookings = new[]
                        {
                new Booking(
                    "Tech Future Expo",
                    "June 1, 2029 — 10:00 AM",
                    "Silicon Valley, San Jose, CA",
                    "Technology",
                    "Active",
                    80
                ),
                new Booking(
                    "AI World Summit",
                    "July 15, 2029 — 9:00 AM",
                    "Boston Convention Center, Boston, MA",
                    "Artificial Intelligence",
                    "Active",
                    120
                ),
                new Booking(
                    "Green Energy Conference",
                    "August 20, 2029 — 11:00 AM",
                    "Austin Energy Center, Austin, TX",
                    "Environment",
                    "Cancelled",
                    50
                )
            };

            return new OkObjectResult(bookings);
        }
    }
}

public class Booking
{
    public string Name { get; set; }
    public string DateTime { get; set; }
    public string Location { get; set; }
    public string Category { get; set; }
    public string Status { get; set; }
    public int Attendees { get; set; }

    public Booking(string name, string dateTime, string location, string category, string status, int attendees)
    {
        Name = name;
        DateTime = dateTime;
        Location = location;
        Category = category;
        Status = status;
        Attendees = attendees;
    }
}
