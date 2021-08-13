using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BetaLixT.Submissions.Common.Entities.Unstructured
{
    public interface IExportSchema
    {
        public delegate Task<ICollection<Submission>> GetChunkDelegate(int iteration, int chunkSize);

        Task Export(Stream outputStream, FormSchema formSchema, GetChunkDelegate getChunkDelegate, int chunkSize = 1000);
        bool ValidateConfiguration();
    }
}
