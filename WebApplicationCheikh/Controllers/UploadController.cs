using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using ApplicationCheikh.Api.Enums;
using Microsoft.AspNetCore.Mvc.Formatters;
using ApplicationCheikh.Api.Builders;
using ApplicationCheikh.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using ApplicationCheikh.Api.Requests;

namespace ApplicationCheikh.Api.Controllers
{
    [ApiController]
    [Route("Upload")]
    public class UploadController : Controller
    {
        private readonly IWebHostEnvironment _env;
        IImageViewModelBuilder _imageViewModelBuilder;
        IMediaViewModelBuilder _mediaViewModelBuilder;

        const string images = "images";
        const string videos = "videos";
        const string sounds = "sounds";

        public UploadController(IWebHostEnvironment env, IMediaViewModelBuilder mediaViewModelBuilder , IImageViewModelBuilder imageViewModelBuilder)
        {
            _env = env;
            _mediaViewModelBuilder = mediaViewModelBuilder;
            _imageViewModelBuilder = imageViewModelBuilder;
        }

        [RequestSizeLimit(524288000)]
        [Consumes("multipart/form-data")]
        [HttpPost("/upload")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "ajout temoignage")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> UploadDocument([FromForm] UploadRequest request)
        {

            if (request.File == null)
                return Ok("création sans l'ajout du fichier");

            if (request.File == null || request.File.Length == 0)
                return BadRequest("Fichier non fourni.");

            if (!Enum.TryParse<MediasType>(request.Type, true, out var mediaType))
                return BadRequest("Type invalide. Utilise IMAGE, VIDEO, SOUND.");

            var fName = Path.GetFileName(request.File.FileName);


            // URL d'accès si exposée


            string folder = mediaType switch
            {
                MediasType.IMAGE => images,
                MediasType.VIDEO => videos,
                MediasType.SOUND => sounds,
                _ => images
            };

            var fileUrl = $"{Request.Scheme}://{Request.Host}/{folder}/{fName}";

            if (folder == images)
                _imageViewModelBuilder.AddImage(new Image { Title = fName, Url = fileUrl });

            else
                _mediaViewModelBuilder.AddMedia(new Media { Title = fName, Type = 2, Url = fileUrl });



            // Dossier de destination
            var uploadsFolder = Path.Combine(_env.WebRootPath, folder);

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            // Nom de fichier sécurisé
            var fileName = Path.GetFileName(request.File.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            // Sauvegarde du fichier
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.File.CopyToAsync(stream);
            }


            return Ok(new { url = fileUrl });
        }
    }
}
