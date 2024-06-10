namespace AR.AspNetCore.Logics.CustomExceptions;

public class UnauthorizedException(string message) : Exception(message)
{
}