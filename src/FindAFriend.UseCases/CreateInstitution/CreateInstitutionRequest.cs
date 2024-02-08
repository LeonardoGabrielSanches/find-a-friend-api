namespace FindAFriend.UseCases.CreateInstitution;

public record CreateInstitutionRequest(
    string Name,
    string ResponsibleName,
    string Email,
    string ZipCode,
    string Address,
    string Phone,
    string Password,
    List<CreateInstitutionRequestFile> Files);

public record CreateInstitutionRequestFile(string Name, byte[] File);