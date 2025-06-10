using Blazored.LocalStorage;
using EventEaseApp.Data;
using System.Threading.Tasks;

namespace EventEaseApp.Services
{
    public class UserService : IUserService
    {
        private readonly ILocalStorageService _localStorage;
        public UserService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        private List<User> users = new();
        public User? CurrentUser { get; private set; }
        public bool IsAuthenticated => CurrentUser != null;

        public async Task<bool> Register(User newUser)
        {
            if (users.Any(u => u.Email == newUser.Email))
            {
                return false; // Email already exists
            }

            newUser.Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1; // Simple ID generation

            /*
             * That line is the same as
             * 
             *   if (users.Count > 0)
             *   {
             *       int maxId = users.Max(u => u.Id);
             *       newUser.Id = maxId + 1;
             *   }
             *   else
             *   {
             *       newUser.Id = 1;
             *   }
             *   
             */

            users.Add(newUser);

            // Save the updated users list to local storage
            await _localStorage.SetItemAsync("users", users);

            return true;
        }

        public async Task<bool> Login(string email, string password)
        {
            CurrentUser = users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (CurrentUser != null)
            {
                await _localStorage.SetItemAsync("currentUser", CurrentUser);
                NotifyStateChanged();
                return true; // Login successful
            }
            return false;
        }

        public event Action OnChange;

        public async Task Logout()
        {
            CurrentUser = null;
            await _localStorage.RemoveItemAsync("currentUser");
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

        public async Task InitializeAsync()
        {
            var storedUsers = await _localStorage.GetItemAsync<List<User>>("users");
            if (storedUsers != null)
                users = storedUsers;

            CurrentUser = await _localStorage.GetItemAsync<User>("currentUser");
            NotifyStateChanged();
        }
    }
}
