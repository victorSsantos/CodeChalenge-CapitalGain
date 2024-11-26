using CapitalGains.Core.Entities.Enums;
using CapitalGains.Core.Interfaces;
using CapitalGains.Core.Entities;

namespace CapitalGains.Processor.Processors 
{
    public class OperationProcessor(IOperationHandler handler, IOperationConsole console) : IOperationProcessor
    {
        private readonly IOperationHandler _handler = handler;
        private readonly IOperationConsole _console = console;

        public void Execute()
        {
            List<List<Operation>> operations = [];

            try
            {
                _console.ReadInput(ref operations);

                // Itera sobre linhas do input de forma paralela.
                Parallel.ForEach(operations, (line) =>
                {
                    int shareBoughtQuantity = 0;
                    double averageBuyingCost = 0.0;
                    double loss = 0.0;

                    // Itera sobre operações da linha
                    for (var currentOperation = 0; currentOperation < line.Count; currentOperation++)
                    {
                        var operation = line[currentOperation];

                        if (operation.OperationType == OperationType.buy)
                            _handler.HandleBuyOperation(ref operation, ref averageBuyingCost, ref shareBoughtQuantity);

                        if (operation.OperationType == OperationType.sell)
                            _handler.HandleSellOperation(ref operation, ref averageBuyingCost, ref shareBoughtQuantity, ref loss);

                        line[currentOperation] = operation;
                    }
                });

                _console.WriteOutput(ref operations);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}