﻿using CloudStorageDomain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStorageDomain.Storage
{
	public interface IStorageService
	{
		string Upload(IFormFile file, Users user);
	}
}
