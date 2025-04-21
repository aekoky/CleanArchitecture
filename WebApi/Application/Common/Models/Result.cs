namespace CleanArchitecture.Application.Common.Models;

public class ResultError
{
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"{nameof(Code)}: {Code}; {nameof(Description)}: {Description};";
    }
}
public class Result
{
    internal Result(bool succeeded, IEnumerable<ResultError> errors)
    {
        Succeeded = succeeded;
        Errors = [.. errors];
    }

    internal Result(bool succeeded, params ResultError[] errors)
    {
        Succeeded = succeeded;
        Errors = [.. errors];
    }

    public bool Succeeded { get; init; }

    public List<ResultError> Errors { get; init; }

    public static Result Success()
    {
        return new Result(true, Enumerable.Empty<ResultError>());
    }

    public static Result Failure(IEnumerable<ResultError> errors)
    {
        return new Result(false, errors);
    }

    public static Result Failure(params ResultError[] errors)
    {
        return new Result(false, errors);
    }

    public override string ToString()
    {
        return $"{nameof(Succeeded)}: {Succeeded}; {nameof(Errors)}: {Errors?.Select(e => e?.ToString())}";
    }
}
