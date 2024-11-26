using CapitalGains.Core.Entities;

namespace CapitalGains.Core.Interfaces
{
    public interface IOperationHandler 
    {
        void HandleBuyOperation(ref Operation operation, ref double averageCost, ref int currentQuantity);
        void HandleSellOperation(ref Operation operation, ref double averageCost, ref int currentQuantity, ref double loss);
    }
}
