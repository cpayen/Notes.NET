using System;

namespace Web.DTO
{
    public class NoteDTO
    {
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string HtmlContent { get; set; }
    }
}
