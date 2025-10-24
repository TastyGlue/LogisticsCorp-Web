using System.Diagnostics.CodeAnalysis;

namespace LogisticsCorp.Shared.Models;

public class CustomResult<T> : CustomResult
{
    public T? Value { get; set; }

    [MemberNotNullWhen(true, nameof(Value))]
    public new bool Succeeded => base.Succeeded;

    public CustomResult(T value) : base(null)
    {
        Value = value;
    }

    public CustomResult(ErrorResult error) : base(error)
    {
        Value = default;
    }
}

public class CustomResult
{
    [MemberNotNullWhen(false, nameof(Error))]
    public bool Succeeded => Error is null;

    public ErrorResult? Error { get; set; }

    public CustomResult(ErrorResult? error = null)
    {
        Error = error;
    }
}
