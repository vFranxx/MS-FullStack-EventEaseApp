namespace EventEaseApp.Data
{
    public class Attendance
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
