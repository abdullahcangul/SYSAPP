using System;
using System.Collections.Generic;
using System.Text;

namespace SYS.Application.Utility.Result;


public interface IDataResult<out T> : IResult
{
    T Data { get; }
}