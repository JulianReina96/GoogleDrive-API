using CloudStorage.Application.UsesCases.Users.UploadProfilePhoto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CloudStorage.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StorageController : ControllerBase
	{
		[HttpPost]
		public IActionResult UploadImage([FromServices] IUploadProfilePhotoUseCase useCase, 
			IFormFile file)
		{
			try
			{

				useCase.Execute(file);


				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

	}
}
