using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStorage.Application.UsesCases.Users.UploadProfilePhoto
{
	public interface IUploadProfilePhotoUseCase
	{
		public void Execute(IFormFile file);
	}
}
