using System.Text.Json.Serialization;

namespace FindAFriend.Infra.CrossCutting.UploadFile;

public class UploadFileApiResponse
{
    [JsonPropertyName("data")]
    public Data Data { get; init; }
}

public class Data
{
    [JsonPropertyName("url")]
    public string Url { get; init; }
}