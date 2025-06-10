using Blazored.LocalStorage;
using EventEaseApp.Data;

namespace EventEaseApp.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly ILocalStorageService _localStorage;
        private List<Attendance> _attendances = new();

        public AttendanceService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            _ = LoadAsync();
        }

        private async Task LoadAsync()
        {
            _attendances = await _localStorage.GetItemAsync<List<Attendance>>("attendances") ?? new List<Attendance>();
        }

        private async Task SaveAsync()
        {
            await _localStorage.SetItemAsync("attendances", _attendances);
        }

        public async Task MarkAttendance(int eventId, int userId)
        {
            if (!_attendances.Any(a => a.EventId == eventId && a.UserId == userId))
            {
                _attendances.Add(new Attendance
                {
                    Id = _attendances.Count > 0 ? _attendances.Max(a => a.Id) + 1 : 1,
                    EventId = eventId,
                    UserId = userId,
                    Timestamp = DateTime.UtcNow
                });
                await SaveAsync();
            }
        }

        public List<Attendance> GetAttendancesForEvent(int eventId)
            => _attendances.Where(a => a.EventId == eventId).ToList();
    }
}
