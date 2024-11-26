using CapitalGains.Core.Entities;
using CapitalGains.Core.Interfaces;

namespace CapitalGains.Application.Services.Handlers
{
    public class OperationHandler : IOperationHandler
    {
        private const double _percentualTax = 0.2;
        private const int _minValueToTax = 20000;

        public void HandleBuyOperation(ref Operation operation, ref double averageCost, ref int currentQuantity)
        {
            averageCost = CalculateWeightedAverage(currentQuantity, averageCost, operation.Quantity, operation.UnitCost);
            currentQuantity += operation.Quantity;
        }

        public void HandleSellOperation(ref Operation operation, ref double averageCost, ref int currentQuantity, ref double loss)
        {
            if (operation.Quantity > currentQuantity)
                throw new InvalidOperationException("Invalid operation: The quantity of shares being sold cannot exceed the current quantity of shares owned.");

            currentQuantity -= operation.Quantity;
            var balance = CalculateBalance(operation.Quantity, operation.UnitCost, averageCost);

            if (operation.UnitCost > averageCost)
            {
                // Deduz valor de lucro do Prejuizo acumuluado das vendas até deduzir valor do prejuizo a 0.0
                balance += loss;

                // Taxa é calculada apenas para operações que deram lucro e que valor total da operação é maior que valor minimo para taxar.
                if (balance > 0 && operation.UnitCost * operation.Quantity > _minValueToTax)
                    operation.Tax = CalculateTax(balance);
                else
                    loss = balance;
            }
            else if (operation.UnitCost < averageCost)
            {
                loss += balance;
            }
        }

        #region Private Methods
        private static double CalculateWeightedAverage(int currentQuantity, double averageCost, int quantity, double unitCost)
        {
            return (currentQuantity * averageCost + quantity * unitCost) / (currentQuantity + quantity);
        }

        public static double CalculateBalance(int quantity, double unitCost, double averageCost)
        {
            return quantity * (unitCost - averageCost);
        }

        public static double CalculateTax(double gain)
        {
            return gain * _percentualTax;
        }
        #endregion
    }
}
