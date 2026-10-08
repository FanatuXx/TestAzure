using System;
using System.Collections.Generic;
using System.Text;
using Tools.Results;

namespace Poudlard.Api.Domain.Errors
{
    internal static class SorcierErrors
    {
        internal static Error SorcierUnmodified => Error.Create("Sorcier.UnModified", "No sorcier modified");
        internal static Error SorcierException => Error.Create("Sorcier.Exception", "An exception was throw");
    }
}
