using System;

namespace Core.Models.Base
{
    interface ITrackable
    {
        string Author { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
