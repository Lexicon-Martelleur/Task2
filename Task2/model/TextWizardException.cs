using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.model;

internal class TextWizardException : Exception
{
    internal TextWizardException() { }

    internal TextWizardException(string msg) : base(msg) { }

    internal TextWizardException(
        string msg,
        Exception innerException
    ) : base(msg, innerException) { }
}
