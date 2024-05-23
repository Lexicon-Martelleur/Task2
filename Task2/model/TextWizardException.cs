using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.model;

/// <summary>
/// A custom exception class used by <see cref="TextWizardService"/>. 
/// </summary>
internal class TextWizardException : Exception
{
    internal TextWizardException() { }

    internal TextWizardException(string msg) : base(msg) { }

    internal TextWizardException(
        string msg,
        Exception innerException
    ) : base(msg, innerException) { }
}
