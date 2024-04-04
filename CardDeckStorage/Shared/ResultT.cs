namespace CardDeckStorage.Shared;

/// <summary>
/// Generic version of result pattern
/// </summary>
/// <typeparam name="TValue"></typeparam>
public class Result<TValue> : Result
{
    private readonly TValue? _value;

    public Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error) =>
        _value = value;

    public TValue? Value => IsSuccess
        ? _value
        : default;

    public static implicit operator Result<TValue>(TValue value) => Create(value);

    public static implicit operator Result<TValue>(Error error) => CreateError<TValue>(error);
}
