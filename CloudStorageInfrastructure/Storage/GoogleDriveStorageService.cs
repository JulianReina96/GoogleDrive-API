using CloudStorageDomain.Entities;
using CloudStorageDomain.Storage;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStorageInfrastructure.Storage
{
	public class GoogleDriveStorageService : IStorageService
	{

		private readonly GoogleAuthorizationCodeFlow _authorization;

        public GoogleDriveStorageService(GoogleAuthorizationCodeFlow authorization)
        {
			_authorization = authorization;
        }
        public string Upload(IFormFile file, Users user)
		{

			var credential = new UserCredential(_authorization, user.Email, new TokenResponse
			{
				AccessToken = user.AcessToken,
				RefreshToken = user.RefreshToken

			});
			var service = new DriveService(new Google.Apis.Services.BaseClientService.Initializer
			{
				ApplicationName = "DriveProject",
				HttpClientInitializer = credential
			});
			var driveFile = new Google.Apis.Drive.v3.Data.File
			{
				Name = file.Name,
				MimeType = file.ContentType,
				//Parents usado para definir qual pasta vai salvar o arquivo(usa o id da pasta) 


			};

			var command = service.Files.Create(driveFile, file.OpenReadStream(), file.ContentType);			
			
			command.Fields = "id";

			var response = command.Upload();// Upload do service do google
			if (response.Status is not Google.Apis.Upload.UploadStatus.Completed or Google.Apis.Upload.UploadStatus.NotStarted)
				throw response.Exception;

			return command.ResponseBody.Id;
		
		}
	}
}
