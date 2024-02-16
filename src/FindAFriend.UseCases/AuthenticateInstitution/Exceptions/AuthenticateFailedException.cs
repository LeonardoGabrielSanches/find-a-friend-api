using FindAFriend.Domain.Exceptions;

namespace FindAFriend.UseCases.AuthenticateInstitution.Exceptions;

public class AuthenticateFailedException() : DomainException("Email/password incorrect.");