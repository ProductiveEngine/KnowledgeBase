using System;
using System.Runtime.Serialization;

namespace KnolwdgeBase.Infrastructure
{    
    public class EException : ApplicationException
    {
        private int _ErrorCode;
        private EException.SeverityType _severity;
        public const int UNKNOWN = -1;
        public const int UNEXPECTED = 0;
        public const int ACCESSDENIED = 1;
        public const int DAL_UNSUPPORTED_DBMS = -2;
        public const int DAL_ILLEGALCONN = -3;
        public const int DAL_NOTRANSACTION = -4;
        public const int DAL_UNSUPPORTEDOUTPUTFIELD = -5;
        public const int DAL_NOPERMISSION = -6;
        public const int DAL_ILLEGALCONNTYPE = -7;
        public const int DAL_NULLCMDCONNECTION = -8;
        public const int EFR_EMPTYPARSERVALUES = -30;
        public const int EFR_PARSERVARIABLENOTEXISTS = -31;
        public const int EFR_WRONGNUMOFOPERANTS = -32;
        public const int EFR_WRONGPARSEEXPRESSION = -33;
        public const int EFR_UNBALANCEDPARENTHESIS = -34;
        public const int UIL_INVALIDFORMSTATE = -100;
        public const int SET_UPDATERROR = 1001;
        public const int AD_OBJECT_ALREADYEXISTS = -80;
        public const int AD_OBJECT_UNKNOWN = -81;
        public const int AD_OBJECT_INVALIDNAME = -82;
        public const int AD_WEAK_PASSWORD = -83;
        public const int AD_UNKNOWNUSER_BADPASSWORD = -84;
        public const int AD_PASSWORD_CONSTRAINTS_VIOLATION = -85;
        public const int WS_VALIDATION_ERROR = -150;

        public EException.SeverityType Severity
        {
            get
            {
                return this._severity;
            }
            set
            {
                if (this._severity == value)
                    return;
                this._severity = value;
            }
        }

        public int ErrorCode
        {
            get
            {
                return this._ErrorCode;
            }
            set
            {
                if (this._ErrorCode == value)
                    return;
                this._ErrorCode = value;
            }
        }

        public EException()
        {
            this._severity = EException.SeverityType.Unspecified;
        }

        public EException(int errorCode)
        {
            this._ErrorCode = errorCode;
        }

        public EException(string message)
          : base(message)
        {
            this._ErrorCode = -1;
            this._severity = EException.SeverityType.Unspecified;
        }

        public EException(string message, Exception inner)
          : base(message, inner)
        {
            this._ErrorCode = -1;
            this._severity = EException.SeverityType.Unspecified;
        }

        public EException(int errorCode, string message)
          : base(message)
        {
            this._ErrorCode = errorCode;
            this._severity = EException.SeverityType.Unspecified;
        }

        public EException(int errorCode, string message, Exception inner)
          : base(message, inner)
        {
            this._ErrorCode = errorCode;
            this._severity = EException.SeverityType.Unspecified;
        }

        public EException(string message, EException.SeverityType severity)
          : base(message)
        {
            this._severity = severity;
        }

        public EException(int errorCode, string message, EException.SeverityType severity)
          : base(message)
        {
            this._ErrorCode = errorCode;
            this._severity = severity;
        }

        public EException(int errorCode, string message, EException.SeverityType severity, Exception inner)
          : base(message, inner)
        {
            this._ErrorCode = errorCode;
            this._severity = severity;
        }

        protected EException(SerializationInfo info, StreamingContext context)
        {
            this._ErrorCode = info.GetInt32("ErrorCode");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ErrorCode", this._ErrorCode);
            base.GetObjectData(info, context);
        }

        public enum SeverityType
        {
            Unspecified,
            Info,
            Warning,
            Error,
        }
    }
}
