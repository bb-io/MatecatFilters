using Apps.MatecatFilters.Api;
using Apps.MatecatFilters.Dtos;
using Apps.MatecatFilters.Invocables;
using Apps.MatecatFilters.Models;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Files;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using RestSharp;
using System.IO;
using System.Net.Mime;
using System.Text;

namespace Apps.MatecatFilters.Actions;

[ActionList]
public class Actions(InvocationContext invocationContext, IFileManagementClient fileManagementClient)
    : FiltersInvocable(invocationContext, fileManagementClient)
{
    [Action("Convert to XLIFF", Description = "Extract translatable text as an XLIFF file")]
    public async Task<XliffFileModel> ConvertToXliff([ActionParameter] XliffRequest input)
    {
        var stream = await FileManagementClient.DownloadAsync(input.File);
        var bytes = await stream.GetByteData();

        var request = new FiltersRequest("/api/v2/original2xliff", Method.Post, Creds).WithFormData(new
        {
            sourceLocale = input.SourceLocale,
            targetLocale = input.TargetLocale,
        }, isMultipartFormData: true).WithFile(bytes, input.File.Name, "document");

        var response = await Client.ExecuteWithErrorHandling<XliffDto>(request);

        if (!response.IsSuccess) throw new Exception(response.ErrorMessage);

        var file = await FileManagementClient.UploadAsync(StringToStream(response.Xliff), "application/x-xliff+xml", response.Filename);

        return new XliffFileModel
        {
            XliffFile = file
        };
    }

    [Action("Convert XLIFF to original", Description = "Convert a translated XLIFF to a translated file")]
    public async Task<FileResponse> ConvertToOriginal([ActionParameter] XliffFileModel input)
    {
        var stream = await FileManagementClient.DownloadAsync(input.XliffFile);
        var bytes = await stream.GetByteData();

        var request = new FiltersRequest("/api/v2/xliff2original", Method.Post, Creds).WithFile(bytes, input.XliffFile.Name, "xliff");

        var response = await Client.ExecuteWithErrorHandling<DocumentDto>(request);

        if (!response.IsSuccess) throw new Exception(response.ErrorMessage);

        string mimeType = MimeTypes.GetMimeType(response.Filename);

        var base64EncodedBytes = Convert.FromBase64String(response.DocumentContent);
        var decoded = Encoding.UTF8.GetString(base64EncodedBytes);

        var file = await FileManagementClient.UploadAsync(new MemoryStream(base64EncodedBytes), mimeType, response.Filename);

        return new FileResponse
        {
            File = file
        };
    }

    private Stream StringToStream(string s)
    {
        var responseStream = new MemoryStream();
        var writer = new StreamWriter(responseStream);
        writer.Write(s);
        writer.Flush();
        responseStream.Position = 0;
        return responseStream;
    }
}