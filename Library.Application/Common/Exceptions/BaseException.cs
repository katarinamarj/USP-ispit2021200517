namespace Library.Application.Common.Exceptions;
using System;

    public class BaseException : Exception
    {
        public BaseException(string message) : base(message)
        {
        }

        public BaseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

