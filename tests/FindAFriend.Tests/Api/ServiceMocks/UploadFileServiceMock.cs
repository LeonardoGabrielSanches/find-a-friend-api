using FindAFriend.Infra.Common.UploadFile;

namespace FindAFriend.Test.Api.ServiceMocks;

public class UploadFileServiceMock : IUploadFileService
{
    public async Task<UploadFileResponse> Upload(UploadFileRequest request)
        => await Task.FromResult(new UploadFileResponse(true, "url"));
}