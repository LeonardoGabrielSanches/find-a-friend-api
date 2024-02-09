namespace FindAFriend.Infra.Common.UploadFile;

public interface IUploadFile
{
    Task<UploadFileResponse> Upload(UploadFileRequest request);
}