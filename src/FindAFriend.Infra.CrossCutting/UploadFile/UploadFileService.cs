using FindAFriend.Infra.Common.UploadFile;

using Microsoft.Extensions.Configuration;

namespace FindAFriend.Infra.CrossCutting.UploadFile;

public class UploadFileService(IUploadFileApi uploadFileApi, IConfiguration configuration) : IUploadFileService
{
    public async Task<UploadFileResponse> Upload(UploadFileRequest request)
    {
        // var stream = new MemoryStream();
        // stream.Write(request.File, 0, request.File.Length);

        var response = await uploadFileApi.Upload(configuration["Integrations:ImgBB:ApiKey"]!, request.File);

        return new UploadFileResponse(true, response.Data.Url);
    }
}