namespace FindAFriend.UseCases.CreateInstitution.Exceptions;

public class InstitutionAlreadyRegisteredException()
    : Exception("Institution with the same email has already been registered.");