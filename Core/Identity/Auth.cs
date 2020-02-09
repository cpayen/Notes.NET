namespace Core.Identity
{
    public class Auth
    {
        #region Props

        public const string AnonymousUserLogin = "Anonymous";

        private readonly ICurrentUser _currentUser;

        #endregion

        #region Ctor

        public Auth(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        #endregion

        #region Public ICurrentUser informations

        public bool IsAuthenticated
        {
            get => _currentUser.IsAuthenticated;
        }
        public string Login
        {
            get => _currentUser.Login ?? AnonymousUserLogin;
        }
        public string FirstName
        {
            get => _currentUser.FirstName;
        }
        public string LastName
        {
            get => _currentUser.LastName;
        }
        public string Email
        {
            get => _currentUser.Email;
        }

        public string FullName
        {
            get =>
                !string.IsNullOrEmpty(_currentUser.FirstName) && !string.IsNullOrEmpty(_currentUser.LastName) ?
                $"{_currentUser.FirstName} {_currentUser.LastName}" :
                _currentUser.Login;
        }

        #endregion
    }
}
