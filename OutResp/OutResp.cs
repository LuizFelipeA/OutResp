using OutResp.Contracts;
using OutResp.Interfaces;

namespace OutResp;

/// <summary>
/// Partial class for Success complexes contracts
/// </summary>
public static partial class OutResp
{   
    public static ISuccessContract<T> Success<T>()
        => new SuccessContract<T>();

    public static ISuccessContract<T> Success<T>(T value)
        => new SuccessContract<T>().AddValue(value);
}

/// <summary>
/// Partial class for Failure complexes contracts
/// </summary>
public static partial class OutResp
{
    public static IFailureContract<T> Failure<T>()
        => new FailureContract<T>();

    public static IFailureContract<T> Failure<T>(T value)
        => new FailureContract<T>().AddValue(value);
}
/// <summary>
/// Partial class for simple contracts
/// </summary>
public static partial class OutResp
{
    public static IFailureSimpleContract Failure()
        => new FailureSimpleContract();
}
