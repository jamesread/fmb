using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb
{
    class HttpException : Exception
    {
        public const int INTERNAL_SERVER_ERROR = 500;
        public const int ACCESS_FORBIDDEN = 403;
        public const int OBJECT_NOT_FOUND = 404; 

        public int httpStatusCode;

        public HttpException(int httpStatusCode)
            : this(httpStatusCode, string.Empty)
        {
            this.httpStatusCode = httpStatusCode;
        }

        public HttpException(int httpStatusCode, string message)
            : base(message)
        {
            this.httpStatusCode = httpStatusCode;
        }

        public string GetMessage()
        {
            if (string.IsNullOrEmpty(this.Message))
            {
                return this.GetHttpMessage();
            }

            return this.Message;
        }

        internal string GetHttpMessage()
        {
            switch (this.httpStatusCode)
            {
                case 500:
                    return "Internal Server Error";
                case 403:  
                    return "Access forbidden";
                case 404:
                    return "Object Not Found";
                default:
                    return "Unknown";
            }
        }
    }
}
