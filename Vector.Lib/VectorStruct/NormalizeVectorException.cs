using System.Runtime.Serialization;

namespace Vector.Lib;

[Serializable]
public class NormalizeVectorException : Exception
{
    public NormalizeVectorException()
    {
    }

    public NormalizeVectorException(string message) : base(message)
    {
    }

    public NormalizeVectorException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected NormalizeVectorException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}