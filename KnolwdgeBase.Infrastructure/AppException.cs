using System;

namespace KnolwdgeBase.Infrastructure
{
    public class AppException : EException
    {

        public AppException()
            : base()
        {
        }

        public AppException(string message)
            : base(message)
        {
        }

        public AppException(string message, SeverityType severity)
            : base(message, severity)
        {
        }

        public AppException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public AppException(int errorCode, string message)
            : base(errorCode, message)
        {
        }

        public AppException(int errorCode, string message, SeverityType severity)
            : base(errorCode, message, severity)
        {
        }

        public AppException(int errorCode, string message, Exception inner)
            : base(errorCode, message, inner)
        {
        }

        public AppException(int errorCode, string message, SeverityType severity, Exception inner)
            : base(errorCode, message, severity, inner)
        {
        }

        public const int NOROWS_AFFECTED = -10;

        public const int BLL_UNKNOWNPARAMETER = 100;
        public const int BLL_INVALIDPARAMETER = 101;

        public const int DAL_DUPLICATEENTRY = 2;
        public const int DAL_MANDATORYFIELDMISSING = 3;
        public const int DAL_SERVERTIMEOUT = 4;
        public const int DAL_RECORDUSED = 5;
        public const int DAL_MISSINGDATA = 6;
        public const int DAL_NOTALLOWED = 7;
        public const int DAL_WRONGDATA = 8;
        public const int DAL_DEADLOCK = 9;
        public const int DAL_NOLOCKHELD = 10;
        public const int DAL_DUPLICATENO = 11;

    }
}
