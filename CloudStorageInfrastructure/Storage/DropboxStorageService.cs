using CloudStorageDomain.Entities;
using CloudStorageDomain.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStorageInfrastructure.Storage
{
	public  class DropboxStorageService : IStorageService
	{
		//not implemented
		public string Upload(IFormFile file, Users user)
		{
			return "notImplemented";
		}
	}
}
