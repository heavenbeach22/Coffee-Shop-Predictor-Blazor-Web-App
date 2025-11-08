using demopro.Models;
namespace demopro.Services

{
    public class UserState
    {
        //holds current user state
        public BaseUser? CurrentUser { get;  set; }
        // Indicates if the user is logged in
        public bool IsLoggedIn => CurrentUser != null;
        // Indicates if the user is a premium user
        public bool IsPremiumUser => CurrentUser?.IsPremium == true;
        // DataManager is used to manage user data and visit history
        public DataManager DataManager { get; set; } = default!;
        //debug for notiing state changes
        public event Action? OnChange;
        //triggers the OnChange event to notify subscribers of state changes
        private void NotifyStateChange() => OnChange?.Invoke();
        // Login method to authenticate user and set CurrentUser
        public bool Login(string username, string password)
        {
            if (username == "zoe" && password == "123")
            {
                CurrentUser = new PremiumUser { Username = username };
                NotifyStateChange();
                return true;
            }
            else if (username == "guest" && password == "123")
            {
                CurrentUser = new BaseUser { Username = username };
                NotifyStateChange();
                return true;
            }

            return false;
        }
        //logout method to clear user data and visit history
        public async Task LogoutAsync()
        {
            try
            {
                if (DataManager == null)
                    throw new InvalidOperationException("DataManager was not set.");

                await DataManager.ClearVisitHistoryAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Logout failed: {ex.Message}");
            }
            
            CurrentUser = null;
            NotifyStateChange();
        }
        
    }
}
