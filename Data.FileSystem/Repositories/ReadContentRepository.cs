using Core.Data.Repositories;
using Core.Models;
using Data.FileSystem.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Data.FileSystem.Repositories
{
    class ReadContentRepository : IReadContentRepository
    {
        private readonly DBSettings _settings;

        public ReadContentRepository(DBSettings settings)
        {
            _settings = settings;
        }

        public async Task<ICollection<Book>> GetAllBooksAsync()
        {
            var books = new List<Book>();
            var dirs = Directory.GetDirectories(_settings.Path);
            foreach (var dir in dirs)
            {
                var json = await FileHelper.ReadAllTextAsync(Path.Combine(dir, "data.json")).ConfigureAwait(false); 
                var book = JsonConvert.DeserializeObject<Book>(json);
                book.Slug = dir.Split(Path.DirectorySeparatorChar).Last();
                books.Add(book);
            }

            return books;
        }

        public async Task<Book> GetBookAsync(string slug)
        {
            var bookPath = Path.Combine(_settings.Path, slug);
            var bookJson = await FileHelper.ReadAllTextAsync(Path.Combine(bookPath, "data.json")).ConfigureAwait(false);
            var book = JsonConvert.DeserializeObject<Book>(bookJson);

            var notes = new List<Note>();
            book.Notes = notes;
            book.Slug = slug;

            var pageDirs = Directory.GetDirectories(bookPath);
            foreach (var pageDir in pageDirs)
            {
                var noteJson = await FileHelper.ReadAllTextAsync(Path.Combine(pageDir, "data.json")).ConfigureAwait(false);
                var note = JsonConvert.DeserializeObject<Note>(noteJson);
                note.Slug = pageDir.Split(Path.DirectorySeparatorChar).Last();
                notes.Add(note);
            }

            return book;
        }

        public async Task<Note> GetNoteAsync(string bookSlug, string noteSlug)
        {
            var notePath = Path.Combine(_settings.Path, bookSlug, noteSlug);
            var noteJson = await FileHelper.ReadAllTextAsync(Path.Combine(notePath, "data.json")).ConfigureAwait(false);
            var noteMarkdown = await FileHelper.ReadAllTextAsync(Path.Combine(notePath, "content.md")).ConfigureAwait(false);

            var note = JsonConvert.DeserializeObject<Note>(noteJson);
            note.Slug = noteSlug;
            note.Content = noteMarkdown;

            return note;
        }

        public async Task<byte[]> GetMediaContentAsync(string bookSlug, string noteSlug, string mediaName)
        {
            var fileContent = await FileHelper.GetFileStreamAsync(Path.Combine(_settings.Path, bookSlug, noteSlug, mediaName)).ConfigureAwait(false);
            return fileContent;
        }
    }
}
