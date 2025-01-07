using Azure.Core;
using EcommerceAPI.Models.Domain;
using EcommerceAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        // POST To upload new image
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDTO image)
        {
            ValidateFileUpload(image);

            if (ModelState.IsValid)
            {
                // user repository to upload image
            }

            return BadRequest(ModelState);
        }


        private void ValidateFileUpload(ImageUploadRequestDTO image) 
        {
            int allowedLength = 10485760; // 10MB
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            // Validate file extension and size
            if (image.File == null)
            {
                ModelState.AddModelError("file", "File is required");
            }
            if (image.File.Length > allowedLength)
            {
                ModelState.AddModelError("file", "File size too large");
            }
            if (!allowedExtensions.Contains(Path.GetExtension(image.File.FileName).ToLower()))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }
        }
    }
}
