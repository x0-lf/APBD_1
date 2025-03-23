namespace APBD_1;

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message)
    {
        
    }

    public OverfillException(string message, Exception innerException) : base(message, innerException)
    {
        
    }
}