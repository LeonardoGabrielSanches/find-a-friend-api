namespace FindAFriend.Infra.Common.UploadFile;

public interface IUploadFile
{
    Task<bool> Upload(UploadFileRequest request);
}