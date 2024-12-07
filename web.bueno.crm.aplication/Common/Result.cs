using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.bueno.crm.aplication.Common
{
    public class Result
    {
    }

    public interface IResult
    {
        bool HasSucceeded { get; }
    }

    public interface IResult<T> : IResult
    {
        T Value { get; }
    }

    public class SuccessResult : IResult
    {

        public SuccessResult()
        {

            HasSucceeded = true;

        }

        public bool HasSucceeded { get; private set; }
    }

    public class SuccessResult<T> : IResult<T>
    {

        public T Value { get; }

        public bool HasSucceeded { get; }

        public SuccessResult() => HasSucceeded = true;

        public SuccessResult(T value) : this() => Value = value;

    }

    public class FailureResult : IResult
    {
        public bool HasSucceeded { get; private set; }
    }

    public class FailureResult<T> : IResult where T : class
    {

        public bool HasSucceeded { get; private set; }

        public Dictionary<string, string> Value { get; set; }

        public FailureResult()
        {
            HasSucceeded = false;
        }

        public FailureResult(string errores)
        {
            Value = new Dictionary<string, string>();
            Value.Add("Error", errores);
        }

        public FailureResult(Dictionary<string, string> errors)
        {
            Value = errors;
        }

    }

    public class DetailError
    {
        public string ErrorCode { get; }
        public string Message { get; }

        public DetailError(string errorCode, string message)
        {
            ErrorCode = errorCode;
            Message = message;
        }

    }

}
