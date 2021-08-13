using System;
namespace BetaLixT.Submissions.Common.Exceptions
{
    public class EntityCheckFailedException : Exception
    {
        public readonly int Code;
        public EntityCheckFailedException(int code, string Message) : base(Message)
        {
            this.Code = code;
        }
    }
}
