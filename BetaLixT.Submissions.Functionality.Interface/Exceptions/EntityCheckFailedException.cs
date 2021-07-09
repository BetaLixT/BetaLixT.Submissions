using System;
namespace BetaLixT.Submissions.Functionality.Interface.Exceptions
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
