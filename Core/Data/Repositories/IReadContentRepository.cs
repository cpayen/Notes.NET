using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Data.Repositories
{
    public interface IReadContentRepository
    {
        Task<ICollection<Book>> GetAllBooksAsync();
        Task<Book> GetBookAsync(string slug);
        Task<Note> GetNoteAsync(string bookSlug, string noteSlug);
    }
}
