using Core.Data.Repositories;

namespace Core.Data
{
    public interface IUnitOfWork
    {
        IReadContentRepository ReadContentRepository { get; }
        //Task SaveAsync();
    }
}
