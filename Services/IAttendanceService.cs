using EventEaseApp.Data;

namespace EventEaseApp.Services
{
    public interface IAttendanceService
    {
        Task MarkAttendance(int eventId, int userId);
        List<Attendance> GetAttendancesForEvent(int eventId);
    }
}
