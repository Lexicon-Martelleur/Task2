namespace Task2.model;

/// <summary>
/// A custom exception class used by <see cref="MovieService"/>. 
/// </summary>
internal class MovieException : Exception
{
    internal MovieException() { }

    internal MovieException(string msg) : base(msg) { }

    internal MovieException(
        string msg,
        Exception innerException
    ) : base(msg, innerException) { }
}
