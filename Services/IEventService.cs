using EventEaseApp.Data;

namespace EventEaseApp.Services
{
    public interface IEventService
    {
        Task<List<Event>> GetTasksAsync();
        Task<Event> GetEventByIdAsync(int id);
        Task AddEventAsync(Event newEvent);
    }
}
