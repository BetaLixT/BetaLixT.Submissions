using System;

namespace BetaLixT.Submissions.Common.Exceptions
{
    public class EntityForbiddenException : Exception
    {
        public readonly int Code;
        public EntityForbiddenException(int code, string Message) : base(Message)
        {
            this.Code = code;
        }
    }
}
