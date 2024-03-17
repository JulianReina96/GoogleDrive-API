using CloudStorageDomain.Entities;
using CloudStorageDomain.Storage;
using FileTypeChecker.Extensions;
using FileTypeChecker.Types;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace CloudStorage.Application.UsesCases.Users.UploadProfilePhoto
{
	public class UploadProfilePhotoUseCase : IUploadProfilePhotoUseCase
	{
		private readonly IStorageService _storageService;
        public UploadProfilePhotoUseCase(IStorageService storageService)
        {
			_storageService = storageService;
            
        }
        public void Execute(IFormFile file)
		{
			try
			{
				var streamFile = file.OpenReadStream();

				var isImage = (streamFile.Is<PortableNetworkGraphic>() || streamFile.Is<JointPhotographicExpertsGroup>());

				if (!isImage)
					throw new Exception("The File is not an image");

				var user = GetFromDataBase(); // simulação banco

				_storageService.Upload(file, user);

			}
			catch(Exception ex)
			{
				//alterar retorno p/ lançar exceção
			
			}

		}

		private CloudStorageDomain.Entities.Users GetFromDataBase()
		{
			return new CloudStorageDomain.Entities.Users
			{
				Id = 1,
				Name = "Julian",
				Email = "julianreinadev@gmail.com",
				AcessToken= "ya29.a0Ad52N38yyonqtGkedG-PU29FyZgV7w2oTmZNdetFdWhd35naH0_Almz93u2NFXI8jNkh-Jj-hMvJQZ1503cKeoIJOtj1ClcFQ1I-1tXRtdOP77g3wvb2Rtz4VDzvZqTIlkIUxh2sdDuzjG595CaqhXQH4XwbaFqdJn0raCgYKAWQSARMSFQHGX2MiGEVsIw7Em2bAB8lsw6HR5A0171",
				RefreshToken = "1//04GDoJFXdaShzCgYIARAAGAQSNwF-L9IrEX05I1Vf0dmfWEzOU104CYGNe8dZIvYlThvdfEkng5SmKUehtWmBIqTWKB9jCTKhkyQ"
				//acess and refresh obtido por api simulada(https://developers.google.com/oauthplayground/) liberada no cloud.google

			};
		}
	}
}
