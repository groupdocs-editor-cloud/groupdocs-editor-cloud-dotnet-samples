using System;
using GroupDocs.Editor.Cloud.Examples.CSharp.EditOperations;

namespace GroupDocs.Editor.Cloud.Examples.CSharp
{
	public class RunExamples
	{
		public static void Main(string[] args)
		{
            //// ***********************************************************
            ////          GroupDocs.Editor Cloud API Examples
            //// ***********************************************************

            //TODO: Get your AppSID and AppKey at https://dashboard.groupdocs.cloud (free registration is required).
            Common.MyAppSid = "XXXXX-XXXXX-XXXXX";
            Common.MyAppKey = "XXXXXXXXXX";
            Common.MyStorage = "First Storage";

            // Uploading sample test files from local disk to cloud storage
            Common.UploadSampleTestFiles();


            #region Get all supported file types
            GetSupportedFileTypes.Run();
            #endregion

            #region Get info for the selected document
            GetDocumentInformation.Run();
            #endregion

            #region Edit word processing document
            EditWordProcessingDocument.Run();
            #endregion

            #region Edit spreadsheet document
            EditSpreadsheetDocument.Run();
            #endregion

            #region Edit presentation document
            EditPresentationDocument.Run();
            #endregion

            #region Edit DSV (Delimiter-separated values) document
            EditDsvDocument.Run();
            #endregion

            #region Edit text document
            EditTextDocument.Run();
            #endregion

            Console.WriteLine("Completed!");
            Console.ReadKey();
        }
	}
}