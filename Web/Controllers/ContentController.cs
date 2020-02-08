﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.Services;
using Markdig;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<Book>> BooksAsync()
        {
            return await _readContents.GetBooksAsync();
        }

        [HttpGet]
        [Route("{bookSlug}")]
        public async Task<Book> BookAsync(string bookSlug)
        {
            return await _readContents.GetBookAsync(bookSlug);
        }

        [HttpGet]
        [Route("{bookSlug}/{noteSlug}")]
        public async Task<NoteDTO> NoteAsync(string bookSlug, string noteSlug)
        {
            var note = await _readContents.GetNoteAsync(bookSlug, noteSlug);
            return new NoteDTO
            {
                Author = note.Author,
                CreatedAt = note.CreatedAt,
                UpdatedAt = note.UpdatedAt,
                Title = note.Title,
                Slug = note.Slug,
                Description = note.Description,
                HtmlContent = Markdown.ToHtml(note.Content)
            };
        }
    }
}