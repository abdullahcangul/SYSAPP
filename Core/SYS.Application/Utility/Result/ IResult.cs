using System;
using System.Collections.Generic;
using System.Text;

namespace SYS.Application.Utility.Result;

public interface IResult
{
    bool Succes { get; }

    string Message { get; }
}