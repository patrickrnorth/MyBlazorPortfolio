using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System.Linq;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageUploadController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UploadedImage uploadedImage)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest(ModelState);
                }

                if (UploadedImage.OldImagePath != String.Empty)
                {
                    if (uploadedImage.OldImagePath != "uploads/placeholder.jpg")
                    {
                        string oldUPloadedImageFileName = uploadedImage.OldImagePath.Split('/').Last();
                        System.IO.File.Delete($"{_webHostEnvironment.ContentRootPath}\\wwwroot\\uploads\\{oldUPloadedImageFileName}");
                    }
                }

                string guid = Guid.NewGuid().ToString();
                string imageFileName = guid + uploadedImage.NewImageFileExtension;

                string fullImageFileSystemPath = $"{_webHostEnvironment.ContentRootPath}\\wwwroot\\uploads\\{imageFileName}";

                FileStream fileStream = System.IO.File.Create(fullImageFileSystem);

                byte[] imageContentAsByteArray = Convert.FromBase64String(uploadedImage.NewImageBase64Content);
                await FileStream.writeasync(imageContentAsByteArray, 0,imageContentAsByteArray.Length);
                fileStream.Close();

                string relativeFilePathWithoutTradingSlashes = $"uploads/{imageFileName}";
                return Created("Create", relativeFilePathWithoutTradingSlashes);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Something went wrong on our side. Please contact the administrator. Error message: {e.Message}");
                
            }
        }
    }
}
