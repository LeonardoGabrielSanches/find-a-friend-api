using FindAFriend.Domain.Exceptions;

namespace FindAFriend.UseCases.CreateInstitution.Exceptions;

public class InstitutionAlreadyRegisteredException()
    : DomainException("Institution with the same email has already been registered.");