using System;
using System.Collections.Generic;
using System.Text;

namespace SYS.Application.Utility.Result;


public class Result : IResult
{
    public Result(bool success, string message) : this(success)
    {
        Message = message;
    }

    public Result(bool success)
    {
        Succes = success;
    }

    public bool Succes { get; }

    public string Message { get; }
}