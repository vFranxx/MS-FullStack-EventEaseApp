using EventEaseApp.Data;

namespace EventEaseApp.Services
{
    public class EventService : IEventService
    {
        public Task<List<Event>> GetTasksAsync() 
        {
            var events = new List<Event>() 
            {
                new Event { Title = "Default 1", Date = DateTime.Today.AddDays(new Random().Next(1,15)), Location = "Default location 1" },
                new Event { Title = "Default 2", Date = DateTime.Today.AddDays(new Random().Next(1,15)), Location = "Default location 2" }
            };

            return Task.FromResult(events);
        }
    }
}
