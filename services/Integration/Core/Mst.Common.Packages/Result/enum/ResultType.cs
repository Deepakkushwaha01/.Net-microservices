namespace Mst.Common.Packages.Results;

public enum ResultType : short
{
    InternalError,
    Ok,
    NotFound,
    Forbidden,
    Conflicted,
    Invalid,
    Unauthorized
}