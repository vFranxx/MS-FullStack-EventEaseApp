using EventEaseApp.Data;

namespace EventEaseApp.Services
{
    public class EventService : IEventService
    {
        private readonly List<Event> events = new List<Event>() 
            {
                new Event { Id = 1, Title = "Default 1", Date = DateTime.Today.AddDays(new Random().Next(1,15)), Location = "Default location 1", Description = "Default description 1" },
                new Event { Id = 2, Title = "Default 2", Date = DateTime.Today.AddDays(new Random().Next(1,15)), Location = "Default location 2", Description = "Default description 2" }
            };

        public Task<List<Event>> GetTasksAsync() 
        {
            return Task.FromResult(events);
        }

        public Task<Event> GetEventByIdAsync(int id) 
        {
            var eventItem = events.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(eventItem);
        }

        public Task AddEventAsync(Event newEvent) 
        {
            if (newEvent == null)
            { 
                throw new ArgumentNullException(nameof(newEvent));
            }

            newEvent.Id = events.Max(e => e.Id) + 1; // Simple ID generation
            events.Add(newEvent);

            return Task.CompletedTask;
        }
    }
}
