using Core.Data;
using Core.Exceptions;
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
            var book = 
                await _uow.ReadContentRepository.GetBookAsync(slug).ConfigureAwait(false) ?? 
                throw new NotFoundException(nameof(Book), slug);

            return book;
        }

        public async Task<Note> GetNoteAsync(string bookSlug, string noteSlug)
        {
            var note = 
                await _uow.ReadContentRepository.GetNoteAsync(bookSlug, noteSlug).ConfigureAwait(false) ?? 
                throw new NotFoundException(nameof(Note), noteSlug);

            return note;
        }

        public async Task<byte[]> GetMediaContentAsync(string bookSlug, string noteSlug, string mediaName)
        {
            var media = await _uow.ReadContentRepository.GetMediaContentAsync(bookSlug, noteSlug, mediaName).ConfigureAwait(false) ??
                throw new NotFoundException("Media", mediaName);

            return media;
        }
    }
}
