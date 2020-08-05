
namespace IADocumentClassifier.Cors.Exceptions
{
    using System;
    public class BusinessException : Exception
    {
        public BusinessException()
        {

        }

        public BusinessException(string MessageCodes, string ErrorDescription, string message) : base(message)
        {

        }

    }
}
