using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Windows;
using Google.Apis.Upload;

namespace GoogleDriveAPILibrary
{
    public class GoogleDriveRepo
    {
        public static string[] scopes = { DriveService.Scope.Drive };

        #region Create google drive service

        //create Drive API service.
        public static DriveService GetService(string id, string secret)
        {
            UserCredential credential;

            //get Credentials from client_secret.json file 
            var clientId = id;
            var clientSecret = secret;


            //Note: creating a filepath we can save the token recieved in the filepaths file by using  new FileDataStore(FilePath, true),
            //but by not sending the filepath the  your token will be stored locally on the AppData directory, so that next time you wont be prompted for consent.We are using ths method

            //String FilePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "DriveServiceCredentials.json");


            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        new ClientSecrets
                        {
                            ClientId = clientId,
                            ClientSecret = clientSecret
                        },
                        scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore("MyAppsToken")).Result;

            //create Drive API service.
            DriveService service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "VeeraaIMS",
            });
            return service;
        }
        #endregion

        #region upload files to google drive
        public static bool UploadFile(DriveService _service, string _uploadFile)
        {
            if (System.IO.File.Exists(_uploadFile))
            {
                Google.Apis.Drive.v3.Data.File body = new Google.Apis.Drive.v3.Data.File();
                body.Name = System.IO.Path.GetFileName(_uploadFile);
                body.MimeType = MimeMapping.GetMimeMapping(_uploadFile);
                // note: convert to bytes if direct reading of database backup file does not work
                //byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
                //using (var stream = new System.IO.MemoryStream(byteArray))
                using (var stream = new System.IO.FileStream(_uploadFile, System.IO.FileMode.Open))
                {
                    try
                    {
                        //TODO: Create a logging mechanism and insert the error message (exception) in it

                        FilesResource.CreateMediaUpload request = _service.Files.Create(body, stream, body.MimeType);
                        request.SupportsAllDrives = true;
                        //note: below code can be used to show upload progression bar
                        // You can bind event handler with progress changed event and response recieved(completed event)
                        //request.ProgressChanged += Request_ProgressChanged;
                        //request.ResponseReceived += Request_ResponseReceived;
                        var result = request.Upload();

                        if (result.Status == UploadStatus.Completed)
                            return true;

                        if (result.Status != UploadStatus.Completed || request == null || request.ResponseBody == null) //check status, now it's throwing here sometimes
                            return false;

                        //if (request == null)
                        //    throw new Exception("Error! Sending The Request");

                        //if (request.ResponseBody == null)
                        //    throw new Exception("Error! Response body is null");

                        //var fileUploaded = request.ResponseBody;
                        //Npte:  A link for downloading a file in the browser if we use WebContentLink
                        //return fileUploaded.WebContentLink;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message, "Error While Uploading The Database Backup To GoogleDrive");
                        return false;
                    }
                }
            }
            else
            {
                //MessageBox.Show("The file does not exist.");
                return false;
            }
        }
        #endregion

        #region get files list from google drive
        //get all files from Google Drive.
        public static List<GoogleDriveFiles> GetDriveFiles(DriveService _service)
        {

            // define parameters of request.
            FilesResource.ListRequest FileListRequest = _service.Files.List();

            //listRequest.PageSize = 10;
            //listRequest.PageToken = 10;
            FileListRequest.Fields = "nextPageToken, files(id, name, size, version, createdTime)";

            //get file list.
            IList<Google.Apis.Drive.v3.Data.File> files = FileListRequest.Execute().Files;
            List<GoogleDriveFiles> FileList = new List<GoogleDriveFiles>();

            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    GoogleDriveFiles File = new GoogleDriveFiles
                    {
                        Id = file.Id,
                        Name = file.Name,
                        Size = file.Size,
                        Version = file.Version,
                        CreatedTime = file.CreatedTime
                    };
                    FileList.Add(File);
                }
            }
            return FileList;
        }
        #endregion

    }
}
