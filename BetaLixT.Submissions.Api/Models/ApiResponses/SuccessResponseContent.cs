

namespace BetaLixT.Submissions.Api.Models.ApiResponses
{
    public class SuccessResponseContent<T>
    {
        public string StatusMessage = ResponseContentStatusMessages.Success;
        public T ResultData { get; set; }
    }
}
