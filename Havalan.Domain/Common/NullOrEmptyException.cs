namespace Havalan.Domain.Common;
public class NullOrEmptyException : Exception
{
    public NullOrEmptyException(string message) : base(message) 
    {
        
    }

    public static void CheckString(string Value, string NameofField)
    {
        if (string.IsNullOrWhiteSpace(Value))
            throw new NotImplementedException($"{NameofField} خالی است");
        if (string.IsNullOrEmpty(Value))
            throw new NotImplementedException($"{NameofField} خالی است");
    }
}