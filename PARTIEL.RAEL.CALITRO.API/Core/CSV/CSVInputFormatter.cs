using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace PARTIEL.RAEL.CALITRO.API.Core.CSV
{
    public class CSVInputFormatter : TextInputFormatter
    {
        public CSVInputFormatter()
        {
            SupportedMediaTypes.Add("application/csv");
            SupportedEncodings.Add(Encoding.UTF8);
        }

        protected override bool CanReadType(Type context) => true;

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            var httpContext = context.HttpContext;
            var serviceProvider = httpContext.RequestServices;

            var logger = serviceProvider.GetRequiredService<ILogger<CSVInputFormatter>>();

            using var reader = new StreamReader(httpContext.Request.Body, encoding);
            string nameLine = null;

            try
            {
                var dtoData = (await ReadLineAsync("", reader, context, logger)).Split(";");
                var dtoName = FirstCharUppercase(dtoData[0]);
                var dtoAction = FirstCharUppercase(dtoData[1]);

                nameLine = await ReadLineAsync("", reader, context, logger);

                var split = nameLine.Split(";");

                Type dtoType = Type.GetType($"PARTIEL.RAEL.CALITRO.API.Models.{dtoName}Dto.{dtoName}{dtoAction}Dto");
                var dtoProperties = dtoType.GetProperties();
                var dtoInstance = Activator.CreateInstance(dtoType);

                for (int i = 0; i < dtoProperties.Length; i++)
                {
                    var value = split[i];
                    var type = dtoProperties[i].PropertyType;
                    var valueConverted = Convert.ChangeType(value, type);
                    dtoProperties[i].SetValue(dtoInstance, valueConverted);
                }

                logger.LogInformation("nameLine = {nameLine}", nameLine);

                return await InputFormatterResult.SuccessAsync(dtoInstance);
            }
            catch
            {
                logger.LogError("Read failed: nameLine = {nameLine}", nameLine);
                return await InputFormatterResult.FailureAsync();
            }
        }

        private static async Task<string> ReadLineAsync(
            string expectedText, StreamReader reader, InputFormatterContext context,
            ILogger logger)
        {
            var line = await reader.ReadLineAsync();

            if (!line.StartsWith(expectedText))
            {
                var errorMessage = $"Looked for '{expectedText}' and got '{line}'";

                context.ModelState.TryAddModelError(context.ModelName, errorMessage);
                logger.LogError(errorMessage);

                throw new Exception(errorMessage);
            }

            return line;
        }

        private string FirstCharUppercase(string value) => $"{value[0].ToString().ToUpper()}{value.Substring(1)}";
    }
}
