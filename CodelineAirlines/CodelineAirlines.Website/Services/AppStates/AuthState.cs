namespace CodelineAirlines.Website.Services.AppStates
{
    public class AuthState
    {
        public bool IsLoggedIn { get; private set; } = false;
        public event Action? OnChange;

        public void SetLoginState(bool isLoggedIn)
        {
            IsLoggedIn = isLoggedIn;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
