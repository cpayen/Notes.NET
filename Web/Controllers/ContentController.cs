using Core.Models;
using Core.Services;
using Markdig;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.DTO;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : ControllerBase
    {
        private readonly ReadContents _readContents;

        public ContentController(ReadContents readContents)
        {
            _readContents = readContents;
        }

        [HttpGet]
        [Route("books")]
        public async Task<ActionResult<IEnumerable<Book>>> BooksAsync()
        {
            var books = await _readContents.GetBooksAsync().ConfigureAwait(false);
            return Ok(books);
        }

        [HttpGet]
        [Route("{bookSlug}")]
        public async Task<ActionResult<Book>> BookAsync(string bookSlug)
        {
            var book = await _readContents.GetBookAsync(bookSlug).ConfigureAwait(false);
            return Ok(book);
        }

        [HttpGet]
        [Route("{bookSlug}/{noteSlug}")]
        public async Task<ActionResult<NoteDTO>> NoteAsync(string bookSlug, string noteSlug)
        {
            var note = await _readContents.GetNoteAsync(bookSlug, noteSlug).ConfigureAwait(false);
            return Ok(new NoteDTO
            {
                Author = note.Author,
                CreatedAt = note.CreatedAt,
                UpdatedAt = note.UpdatedAt,
                Title = note.Title,
                Slug = note.Slug,
                Description = note.Description,
                HtmlContent = Markdown.ToHtml(note.Content)
            });
        }
    }
}