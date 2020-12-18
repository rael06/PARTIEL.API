using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace PARTIEL.RAEL.CALITRO.API.Core.CSV
{
    public class CSVOutputFormatter : TextOutputFormatter
    {
        public CSVOutputFormatter()
        {
            SupportedMediaTypes.Add("application/csv");
            SupportedEncodings.Add(Encoding.UTF8);
        }

        protected override bool CanWriteType(Type context) => true;

        public async override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var data = context.Object;
            var csv = new List<string>();
            if (data is IEnumerable<object> enumerable)
            {
                csv.Add(GenerateCSVHeader(enumerable.First()));
                foreach (var item in enumerable)
                {
                    csv.Add(GenerateCSVRow(item));
                }
            }
            else
            {
                csv.Add(GenerateCSVHeader(data));
                csv.Add(GenerateCSVRow(data));
            }

            var bytes = selectedEncoding.GetBytes(string.Join("\n", csv));
            await context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        }

        private string GenerateCSVHeader(object data)
        {
            var values = data.GetType().GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(CSVAttribute), true).Count() > 0)
                .OrderBy(x => ((CSVAttribute)x.GetCustomAttributes(typeof(CSVAttribute), true).First()).Order)
                .Select(x => x.Name.ToString());

            return string.Join(";", values);
        }

        private string GenerateCSVRow(object data)
        {
            var values = data.GetType().GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(CSVAttribute), true).Count() > 0)
                .OrderBy(x => ((CSVAttribute)x.GetCustomAttributes(typeof(CSVAttribute), true).First()).Order)
                .Select(x => x.GetValue(data)?.ToString());

            return string.Join(";", values);
        }
    }
}
