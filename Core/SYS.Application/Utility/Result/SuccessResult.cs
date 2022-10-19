using System;
using System.Collections.Generic;
using System.Text;

namespace SYS.Application.Utility.Result;


public class SuccessResult : Result
{
    public SuccessResult(string message) : base(true, message)
    {
    }

    public SuccessResult() : base(true)
    {
    }
}