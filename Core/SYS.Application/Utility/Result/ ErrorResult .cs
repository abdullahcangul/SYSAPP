using System;
using System.Collections.Generic;
using System.Text;

namespace SYS.Application.Utility.Result;

public class ErrorResult : Result
{
    public ErrorResult(string message) : base(false, message)
    {
    }

    public ErrorResult(bool success) : base(success)
    {
    }
}