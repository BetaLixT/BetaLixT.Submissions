using System;

namespace BetaLixT.Submissions.Common.Exceptions
{
    public class EntityMissingException : Exception
    {
        public readonly int Code;
        public EntityMissingException(int code, string Message) : base(Message)
        {
            this.Code = code;
        }
    }
}
