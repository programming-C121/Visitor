namespace Example.Visitors;

public class SemanticResult
{
    public Type Type { get; }
    public string? Error { get; }

    public bool IsSuccess => Error == null;

    private SemanticResult(Type type, string? error = null)
    {
        Type = type;
        Error = error;
    }

    public static SemanticResult Success(Type type) => new SemanticResult(type);
    public static SemanticResult Failure(string error) => new SemanticResult(typeof(void), error);
}