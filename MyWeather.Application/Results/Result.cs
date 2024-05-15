namespace MyWeather.Application.Results;

public class Result
{
    public bool IsSuccess { get; }
    public Error? Error { get; }
    public bool IsFailure => !IsSuccess;

    protected Result(bool isSuccess, Error? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }
    public static implicit operator Result(Error error) => new Result(false, error);


    public static Result<T> Failure<T>(Error error) 
        => error;
    public static Result Failure(Error error) 
        => error;
    public static Result<T> Success<T>(T value) 
        => value;
    public static Result Success() 
        => new Result(true, default);

    public static Result Combine(params Result[] results)
    {
        foreach (var result in results)
        {
            if (result.IsFailure)
                return result;
        }

        return Success();
    }

}

public class Result<T> : Result
{
    private T? _value;
    public T Value
    {
        get
        {
            if (IsFailure)
                throw new InvalidOperationException();
            return _value!;
        }
    }
    public Result(T value) : base(true, default)
    {
        _value = value;
    }
    public Result(Error error) : base(false, error)
    {
        _value = default;
    }
    public static implicit operator Result<T>(Error error) => new Result<T>(error);
    public static implicit operator Result<T>(T value) => new Result<T>(value);
}

public static class ResultExtensions
{
    public static async Task<Result> OnSuccess<T>(this Result<T> result, Func<T, Task<Result>> func)
        => result.IsSuccess ? await func(result.Value) : result;

    public static async Task<Result> OnSuccess(this Result result, Func<Task<Result>> func)
        => result.IsSuccess ? await func() : result;
    public static async Task<Result> OnSuccess(this Result result, Func<Task> asyncAction)
    {
        if (result.IsFailure) return result;
        await asyncAction();
        return Result.Success();
    }
    public static async Task<Result<T>> OnSuccess<T>(this Result result, Func<Task<Result<T>>> func)
        => result.IsSuccess ? await func() : Result.Failure<T>(result.Error!);
    
    public static Result OnSuccess(this Result result, Func<Result> func)
        => result.IsSuccess ? func() : result;
    
    public static Result OnSuccess<T>(this Result<T> result, Func<T,Result> func)
        => result.IsSuccess ? func(result.Value) : result;
    
    public static Result OnSuccess(this Result result, Action action)
    {
        if (result.IsFailure)
            return result;
        
        action();
        return Result.Success();
    }
    public static Result<U> OnSuccess<T, U>(this Result<T> result, Func<T, Result<U>> func)
        => result.IsSuccess ? func(result.Value) : Result.Failure<U>(result.Error!);
    public static async Task<Result<U>> OnSuccess<T, U>(this Result<T> result, Func<T, Task<Result<U>>> func)
        => result.IsSuccess ? await func(result.Value) : Result.Failure<U>(result.Error!);
    
    public static Result OnSuccess<T>(this Result<T> result, Action<T> action)
    {
        if (result.IsFailure)
            return result;
        
        action(result.Value);
        return Result.Success();
    }
    public static Result<T> OnSuccess<T>(this Result result, Func<Result<T>> func)
        => result.IsSuccess ? func() : Result.Failure<T>(result.Error!);
    
    public static Result<T> OnSuccess<T>(this Result<T> result, Func<T, Result<T>> func)
        => result.IsSuccess ? func(result.Value) : Result.Failure<T>(result.Error!);
    public static Result OnFailure(this Result result, Action action)
    {
        if (result.IsFailure)
            action();
        return result;
    }
    public static Result OnBoth(this Result result, Action<Result> action)
    {
        action(result);
        return result;
    }

    public static T OnBoth<T>(this Result result, Func<Result, T> func) => func(result);
}