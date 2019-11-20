using System;
using System.IO;
using System.Text;
using GroupDocs.Editor.Cloud.Sdk.Api;
using GroupDocs.Editor.Cloud.Sdk.Model;
using GroupDocs.Editor.Cloud.Sdk.Model.Requests;
using FileInfo = GroupDocs.Editor.Cloud.Sdk.Model.FileInfo;

namespace GroupDocs.Editor.Cloud.Examples.CSharp.EditOperations
{
    /// <summary>
    /// This example demonstrates how to edit word processing document.
    /// </summary>
    public class EditWordProcessingDocument
    {
        public static void Run()
        {
            try
            {
                // Create necessary API instances
                var editApi = new EditApi(Common.GetConfig());
                var fileApi = new FileApi(Common.GetConfig());

                // The document already uploaded into the storage.
                // Load it into editable state
                var loadOptions = new WordProcessingLoadOptions
                {
                    FileInfo = new FileInfo
                    {
                        FilePath = "WordProcessing/password-protected.docx",
                        Password = "password"
                    },
                    OutputPath = "output"
                };

                var loadResult = editApi.Load(new LoadRequest(loadOptions));

                // Download html document
                var stream = fileApi.DownloadFile(new DownloadFileRequest(loadResult.HtmlPath));
                var htmlString = new StreamReader(stream, Encoding.UTF8).ReadToEnd();

                // Edit something...
                htmlString = htmlString.Replace("Sample test text", "Hello world");

                // Upload html back to storage
                fileApi.UploadFile(new UploadFileRequest(loadResult.HtmlPath,
                    new MemoryStream(Encoding.UTF8.GetBytes(htmlString))));

                // Save html back to docx
                var saveOptions = new WordProcessingSaveOptions
                {
                    FileInfo = loadOptions.FileInfo,
                    OutputPath = "output/edited.docx",
                    HtmlPath = loadResult.HtmlPath,
                    ResourcesPath = loadResult.ResourcesPath
                };

                var saveResult = editApi.Save(new SaveRequest(saveOptions));

                // Done.
                Console.WriteLine("Document edited: " + saveResult.Path);

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
