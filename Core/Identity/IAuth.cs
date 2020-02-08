namespace Core.Identity
{
    public interface IAuth
    {
        string Login { get; }
        bool IsAuthenticated { get; }
        string Email { get; }
        string FirstName { get; }
        string LastName { get; }
        string FullName { get; }
    }
}
