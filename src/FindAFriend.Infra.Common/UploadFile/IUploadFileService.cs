namespace FindAFriend.Infra.Common.UploadFile;

public interface IUploadFileService
{
    Task<UploadFileResponse> Upload(UploadFileRequest request);
}