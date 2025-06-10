using EventEaseApp.Data;

namespace EventEaseApp.Services
{
    public interface IUserService
    {
        Task<bool> Register(User newUser);
        Task<bool> Login(string email, string password);
        Task Logout();
        event Action OnChange;
        User? CurrentUser { get; }  
        bool IsAuthenticated { get; }
        Task InitializeAsync();
    }
}
