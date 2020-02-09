using Core.Data;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ReadContents
    {
        private readonly IUnitOfWork _uow;
        public ReadContents(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _uow.ReadContentRepository.GetAllBooksAsync().ConfigureAwait(false);
        }

        public async Task<Book> GetBookAsync(string slug)
        {
            return await _uow.ReadContentRepository.GetBookAsync(slug).ConfigureAwait(false);
        }

        public async Task<Note> GetNoteAsync(string bookSlug, string noteSlug)
        {
            return await _uow.ReadContentRepository.GetNoteAsync(bookSlug, noteSlug).ConfigureAwait(false);
        }
    }
}
