using Core.Models.Base;
using System;

namespace Core.Models
{
    public class Note : ITrackable, IDisplayable
    {
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }

        public string Content { get; set; }

        //public Book Book { get; set; }
    }
}
