namespace Core.Identity
{
    public interface ICurrentUser
    {
        string Login { get; }
        bool IsAuthenticated { get; }
        string Email { get; }
        string FirstName { get; }
        string LastName { get; }
    }
}
