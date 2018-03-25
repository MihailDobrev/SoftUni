namespace Logger
{
    using Contracts;
    using System;
    public interface IError:ILevelable
    {
        DateTime DateTime { get; }
        string Message { get; }

    }
}