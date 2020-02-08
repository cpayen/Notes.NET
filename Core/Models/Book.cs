using Core.Models.Base;
using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class Book : ITrackable, IDisplayable
    {
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }

        public IEnumerable<Note> Notes { get; set; }
    }
}
