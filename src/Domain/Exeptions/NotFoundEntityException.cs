namespace Domain.Exceptions;

public class NotFoundEntityException : BaseException
{
    public NotFoundEntityException(List<string> messages) : base(messages)
    {
    }

    public NotFoundEntityException(string message) : base(message)
    {
    }

    public NotFoundEntityException() : base("موردی یافت نشد")
    {
    }
    public NotFoundEntityException(string name, object key)
    : base($"Entity \"{name}\" ({key}) was not found.")
    {
    }
}