using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetaLixT.Submissions.Common.Entities.Unstructured.ExportSchemas
{
    public class CsvExportSchema : IExportSchema
    {
        public IDictionary<int, string> PropertyMapping { get; set; }

        public async Task Export(Stream outputStream, FormSchema formSchema, IExportSchema.GetChunkDelegate getChunkDelegate, int chunkSize = 1000)
        {
            var writer = new StreamWriter(outputStream);
            var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            var headers = PropertyMapping;
            for(int i = 0; i < formSchema.Properties.Count; i++)
            {
                if (!headers.ContainsKey(i))
                {
                    csv.WriteField(formSchema.Properties.ElementAt(i).Title);
                }
                else
                {
                    csv.WriteField(headers[i]);
                }
            }
            csv.NextRecord();

            int iter = 0;
            var records = await getChunkDelegate(iter, chunkSize);
            // csv.WriteHeader()
            while (records != null && records.Count != 0)
            {
                iter++;

                foreach (var record in records)
                {
                    foreach (var field in record.Responses)
                    {
                        csv.WriteField(field);
                    }
                    csv.NextRecord();
                }

                records = await getChunkDelegate(iter, chunkSize);
            }
            writer.Flush();
        }

        public bool ValidateConfiguration()
        {
            return true;
        }
    }
}
