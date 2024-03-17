using CloudStorage.Application.UsesCases.Users.UploadProfilePhoto;
using CloudStorageDomain.Storage;
using CloudStorageInfrastructure.Storage;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Drive.v3;
using Google.Apis.Util.Store;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUploadProfilePhotoUseCase, UploadProfilePhotoUseCase > ();

builder.Services.AddScoped<IStorageService>(options =>
{
	var clientId = builder.Configuration.GetValue<string>("CloudStorage:ClientId");
	var clientSecret = builder.Configuration.GetValue<string>("CloudStorage:ClientSecret");
	var scope = new List<string> { DriveService.Scope.Drive };
	IEnumerable<string> enumerableScope = scope;
	var apiCodeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
	{
		ClientSecrets = new ClientSecrets
		{
			ClientId = clientId,
			ClientSecret = clientSecret

		},
		Scopes = enumerableScope,
		DataStore = new FileDataStore("DriveProject")
	});
	return new GoogleDriveStorageService(apiCodeFlow);
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
