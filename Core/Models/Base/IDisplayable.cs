namespace Core.Models.Base
{
    interface IDisplayable
    {
        string Title { get; set; }
        string Slug { get; set; }
        string Description { get; set; }
    }
}
