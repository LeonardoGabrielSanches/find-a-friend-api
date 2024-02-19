using Refit;

namespace FindAFriend.Infra.CrossCutting.UploadFile;

public interface IUploadFileApi
{
    [Multipart]
    [Post("/upload?key={apiKey}")]
    Task<UploadFileApiResponse> Upload(string apiKey, [AliasAs("image")] StreamPart stream);
}