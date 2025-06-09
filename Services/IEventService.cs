using EventEaseApp.Data;

namespace EventEaseApp.Services
{
    public interface IEventService
    {
        Task<List<Event>> GetTasksAsync();
    }
}
