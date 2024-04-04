namespace CardDeckStorage.Shared;

/// <summary>
/// This is component for result pattern
/// </summary>
/// <param name="Code"></param>
/// <param name="Description"></param>
public sealed record Error(string Code, string? Description = null)
{
    public static readonly Error None = new(string.Empty);

    public static implicit operator Result(Error error) => Result.Failure(error);
}
