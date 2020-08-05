
namespace IADocumentClassifier.Cors.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    public class MessageHandlercs
    {
        public static class MessageCodes
        {
            public static string REQUIRED_PROPERTY
            {
                get { return "1001"; }
            }

            public static string PROPERTY_NO_VALID
            {
                get { return "1002"; }
            }

            public static string STATE_NO_VALID
            {
                get { return "1003"; }
            }
        }

        public static string GetErrorDescription(string messageCode)
        {
            return MessageResource.ResourceManager.GetString(messageCode);
        }

        public static string GetErrorDescription(string messageCode, params object[] parameters)
        {
            return string.Format(CultureInfo.CurrentCulture, MessageResource.ResourceManager.GetString(messageCode), parameters);
        }
    }
}
