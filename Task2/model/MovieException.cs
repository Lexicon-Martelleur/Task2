using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.model;

internal class MovieException : Exception
{
    internal MovieException() { }

    internal MovieException(string msg) : base(msg) { }

    internal MovieException(
        string msg,
        Exception innerException
    ) : base(msg, innerException) { }
}
