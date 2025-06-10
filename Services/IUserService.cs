using EventEaseApp.Data;

namespace EventEaseApp.Services
{
    public interface IUserService
    {
        Task<bool> Register(User newUser);
        bool Login(string email, string password);
        void Logout();
        event Action OnChange;
        User? CurrentUser { get; }  
        bool IsAuthenticated { get; }
    }
}
