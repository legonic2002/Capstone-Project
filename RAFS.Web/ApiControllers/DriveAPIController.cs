using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using RAFS.Core.Services.IService;
using Google.Apis.Drive.v3;
using Google.Apis.Upload;
using AutoMapper;
using RAFS.Core.Repositories.Generics;
using Microsoft.Extensions.Options;
using RAFS.Common.Models;

namespace RAFS.Core.Services.Service
{
    public class DriveAPIController
    {

        private readonly GoogleCredentialSettings _settings;
        

        public DriveAPIController(IOptions<GoogleCredentialSettings> settings)
        {
            _settings = settings.Value;
            
        }

        
        public DriveService GetDriveService()
        {
            // Create GoogleCredential using GoogleCredentialSettings
            var credential = GoogleCredential.FromJson(
                $@"{{
                 ""type"": ""{_settings.Type}"",
                ""project_id"": ""{_settings.ProjectId}"",
                ""private_key_id"": ""{_settings.PrivateKeyId}"",
                ""private_key"": ""{_settings.PrivateKey}"",
                ""client_email"": ""{_settings.ClientEmail}"",
                ""client_id"": ""{_settings.ClientId}"",
                ""auth_uri"": ""{_settings.AuthUri}"",
                ""token_uri"": ""{_settings.TokenUri}"",
                ""auth_provider_x509_cert_url"": ""{_settings.AuthProviderX509CertUrl}"",
                ""client_x509_cert_url"": ""{_settings.ClientX509CertUrl}"",
                ""universe_domain"": ""{_settings.UniverseDomain}""
            }}")
                .CreateScoped(DriveService.ScopeConstants.Drive);

            return new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential
            });
        }
        public async Task<string> CreateDriveFile(string uploadFileName)
        {
            var service = GetDriveService();

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = "rafsimg.png",
                Parents = new List<string>() { "18xYMMo-1FPVvMMTZ3ggZTAm7PKOJGzpb" }
            };
            string uploadedFileId;
            // Create a new file on Google Drive
            await using (var fsSource = new FileStream(uploadFileName, FileMode.Open, FileAccess.Read))
            {
                // Create a new file, with metadata and stream.
                var request = service.Files.Create(fileMetadata, fsSource, "");
                request.Fields = "*";
                var results = await request.UploadAsync(CancellationToken.None);

                if (results.Status == UploadStatus.Failed)
                {
                    Console.WriteLine($"Error uploading file: {results.Exception.Message}");
                }

                // the file id of the new file we created
                uploadedFileId = request.ResponseBody?.Id;

            }


            var updatedFile = await service.Files.Get(uploadedFileId).ExecuteAsync();

            return "https://lh3.googleusercontent.com/d/" + updatedFile.Id + "=s0?authuser=0";
        }
        static string GetId(string link)
        {
            string[] tokens = link.Split('/', '?');
            string[] id = tokens[4].Split('=');
            return id[1];
        }
        static string GetId2(string link)
        {
            string[] tokens = link.Split('/');
            string[] id = tokens[4].Split('=');
            return id[0];
        }
        public async Task<bool> DeleteDriveFile(string id)
        {
            if (id.Contains("https://drive.google.com"))
            {
                id = GetId(id);
            }
            else if (id.Contains("https://lh3.googleusercontent.com"))
            {
                id = GetId2(id);
            }
            try
            {
                var service = GetDriveService();

                Google.Apis.Drive.v3.Data.File file = new Google.Apis.Drive.v3.Data.File();
                file.Trashed = true;

                FilesResource.UpdateRequest request = service.Files.Update(file, id);
                request.Fields = "id";
                await request.ExecuteAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateDriveFile(string id, string uploadFileName)
        {
            if (id.Contains("https://drive.google.com"))
            {
                id = GetId(id);
            }
            else if (id.Contains("https://lh3.googleusercontent.com"))
            {
                id = GetId2(id);
            }
            try
            {
                string input = uploadFileName;
                string last3Characters = input.Substring(input.Length - 3).ToLower();

                var service = GetDriveService();

                var updateFileBody = new Google.Apis.Drive.v3.Data.File()
                {

                };
                // Then upload the file again with a new name and new data.
                await using (var uploadStream = new FileStream(uploadFileName, FileMode.Open, FileAccess.Read))
                {
                    var updateRequest = service.Files.Update(updateFileBody, id, uploadStream, (last3Characters.ToLower().Equals("png")) ? "image/png" : "image/jpg"); ;

                    // Update the file id, with new metadata and stream.
                    var result = await updateRequest.UploadAsync(CancellationToken.None);

                    if (result.Status == UploadStatus.Failed)
                    {
                        Console.WriteLine($"Error uploading file: {result.Exception.Message}");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
