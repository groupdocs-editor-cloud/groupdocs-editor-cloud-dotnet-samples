using GroupDocs.Editor.Cloud.Sdk.Api;
using GroupDocs.Editor.Cloud.Sdk.Model;
using GroupDocs.Editor.Cloud.Sdk.Model.Requests;
using System;

namespace GroupDocs.Editor.Cloud.Examples.CSharp
{
    /// <summary>
    /// This example demonstrates how to get document info.
    /// </summary>
    public class GetDocumentInformation
    {
        public static void Run()
        {
            var apiInstance = new InfoApi(Common.GetConfig());

            try
            {
                var fileInfo = new FileInfo
                {
                    FilePath = "WordProcessing/password-protected.docx",
                    Password = "password",
                    StorageName = Common.MyStorage
                };

                var request = new GetInfoRequest(fileInfo);

                var response = apiInstance.GetInfo(request);
                Console.WriteLine("InfoResult.Pages.Count: " + response.PageCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling InfoApi: " + e.Message);
            }
        }
    }
}