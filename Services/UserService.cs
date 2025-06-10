using EventEaseApp.Data;

namespace EventEaseApp.Services
{
    public class UserService : IUserService
    {
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
            return true;
        }

        public bool Login(string email, string password)
        {
            CurrentUser = users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (CurrentUser != null)
            {
                NotifyStateChanged();
                return true; // Login successful
            }
            return false;
        }

        public event Action OnChange;

        public void Logout()
        {
            CurrentUser = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
