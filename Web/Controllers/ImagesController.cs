using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ReadContents _readContents;

        public ImagesController(ReadContents readContents)
        {
            _readContents = readContents;
        }

        [HttpGet]
        [Route("{bookSlug}/{noteSlug}/{imageName}")]
        public async Task<IActionResult> ImageAsync(string bookSlug, string noteSlug, string imageName)
        {
            new FileExtensionContentTypeProvider().TryGetContentType(imageName, out string contentType);
            contentType ??= "application/octet-stream";

            var content = await _readContents.GetMediaContentAsync(bookSlug, noteSlug, imageName).ConfigureAwait(false);
            return File(content.ToArray(), contentType);
        }
    }
}