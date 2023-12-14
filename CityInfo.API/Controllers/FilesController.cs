using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _extensionContentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider extensionContentTypeProvider)
        {
            _extensionContentTypeProvider = extensionContentTypeProvider;
        }

        [HttpGet("{fileId}")]
        public ActionResult GetFile(int fileId)
        {
            var pathToFile = "1 Academic certificates.pdf";

            if (!System.IO.File.Exists(pathToFile))
            {
                return NotFound(new { Message = "File could not found, Please try again later." });
            }

            if (!_extensionContentTypeProvider.TryGetContentType(pathToFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = System.IO.File.ReadAllBytes(pathToFile);
            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }
    }
}