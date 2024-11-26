using CapitalGains.Core.Entities;
using CapitalGains.Core.Interfaces;
using CapitalGains.UI.DTOs;
using Newtonsoft.Json;

namespace CapitalGains.Application.Services.Consoles
{
    public class OperationConsole : IOperationConsole
    {
        public void ReadInput(ref List<List<Operation>> operations)
        {
            string? line;

            try
            {
                // Recebe linhas de input até que seja enviada linha vazia
                while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
                {
                    var operationLine = JsonConvert.DeserializeObject<List<OperationInput>>(line);

                    if (operationLine?.Count > 0)
                        operations.Add(operationLine.Select(x => new Operation(x.operation, x.unitCost, x.quantity)).ToList());
                }
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new JsonException($"Error to Deserialize Object: {e.Message}");
            }
        }

        public void WriteOutput(ref List<List<Operation>> operations)
        {
            try
            {
                // Select utilizado para transformar todos os objeto Operation das listas em OperationOutput
                var serializedOperations = operations.Select(x => JsonConvert.SerializeObject(x.Select(y => new OperationOutput(y.Tax))));
                
                if(serializedOperations.Any())
                    Console.WriteLine(string.Join(Environment.NewLine, serializedOperations));
            }
            catch (Exception e)
            {
                throw new JsonException($"Error to Serialize Object: {e.Message}");
            }
        }
    }
}
