using GroupDocs.Editor.Cloud.Sdk.Api;
using System;

namespace GroupDocs.Editor.Cloud.Examples.CSharp
{
    /// <summary>
    /// This example demonstrates how to obtain all supported file types.
    /// </summary>
    public class GetSupportedFileTypes
    {
		public static void Run()
		{
            var apiInstance = new InfoApi(Common.GetConfig());

			try
			{
				// Get supported file formats
				var response = apiInstance.GetSupportedFileFormats();

				foreach (var entry in response.Formats)
				{
					Console.WriteLine($"{entry.FileFormat}: {string.Join(",", entry.Extension)}");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling InfoApi: " + e.Message);
			}
		}
	}
}