using FindAFriend.Infra.Common.UploadFile;

using Firebase.Storage;

using Microsoft.Extensions.Configuration;

namespace FindAFriend.Infra.CrossCutting.UploadFile.Firebase;

public class UploadFileFirebaseService(IConfiguration configuration) : IUploadFileService
{
    private readonly FirebaseStorageReference _storage = new FirebaseStorage(configuration["Firebase:StorageBucket"]!)
        .Child("pets");

    public async Task<UploadFileResponse> Upload(UploadFileRequest request)
    {
        var fileStream = new MemoryStream(request.File);

        var downloadUrl = await _storage
            .Child(request.FileName)
            .PutAsync(fileStream);

        return string.IsNullOrEmpty(downloadUrl)
            ? new UploadFileResponse(false, string.Empty)
            : new UploadFileResponse(true, downloadUrl);
    }
}