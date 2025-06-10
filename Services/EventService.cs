using Blazored.LocalStorage;
using EventEaseApp.Data;
using System.Threading.Tasks;

namespace EventEaseApp.Services
{
    public class EventService : IEventService
    {
        private readonly ILocalStorageService _localStorage;
        private List<Event> events = new();

        public EventService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        private List<Event> GetDefaultEvents() => new List<Event>
        {
            new Event { Id = 1, Title = "Default 1", Date = DateTime.Today.AddDays(1), Location = "Default location 1", Description = "Default description 1" },
            new Event { Id = 2, Title = "Default 2", Date = DateTime.Today.AddDays(2), Location = "Default location 2", Description = "Default description 2" }
        };

        public async Task LoadAsync()
        {
            var loadedEvents = await _localStorage.GetItemAsync<List<Event>>("events");
            if (loadedEvents == null)
            {
                events = GetDefaultEvents();
                await SaveAsync();
            }
            else 
            {
                events = loadedEvents ?? GetDefaultEvents();
            }
        }

        private async Task SaveAsync()
        {
            await _localStorage.SetItemAsync("events", events);
        }

        public Task<List<Event>> GetTasksAsync()
        {
            return Task.FromResult(events);
        }

        public Task<Event> GetEventByIdAsync(int id)
        {
            var eventItem = events.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(eventItem);
        }

        public async Task AddEventAsync(Event newEvent)
        {
            if (newEvent == null)
                throw new ArgumentNullException(nameof(newEvent));

            newEvent.Id = events.Count > 0 ? events.Max(e => e.Id) + 1 : 1;
            events.Add(newEvent);
            await SaveAsync();
        }
    }
}
