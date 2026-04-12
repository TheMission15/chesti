using System.Security.Cryptography.X509Certificates;

namespace Chesti.Core.Result
{
    internal class StringXResult<T>
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public T Value { get; set; }
        public StringXResult(bool result,  string message, T value)
        {
            Result = result; Message = message; Value = value;
        }
    }
}
