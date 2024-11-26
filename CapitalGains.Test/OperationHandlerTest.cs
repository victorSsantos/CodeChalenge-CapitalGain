using CapitalGains.Application.Services.Handlers;
using CapitalGains.Core.Entities;
using CapitalGains.Core.Entities.Enums;
using CapitalGains.Core.Interfaces;

namespace CapitalGains.Test
{
    public class OperationHandlerTest
    {
        private readonly IOperationHandler _handler = new OperationHandler();

        [Fact]
        public void HandleBuyOperation_ShouldHandleWithSuccess_WhenValidData()
        {
            // Arrange
            double averageCost = 0.0;
            int currentQuantity = 0;
            Operation operation =  new(OperationType.buy, 10.0, 100);

            double averageCostExpected = 10.0;
            int currentQuantityExpected = 100;
            Operation operationExpected = new(OperationType.buy, 10.0, 100, 0.0);           

            // Act
            _handler.HandleBuyOperation(ref operation, ref averageCost, ref currentQuantity);

            // Assert
            Assert.Equal(operationExpected.OperationType, operation.OperationType);
            Assert.Equal(operationExpected.Quantity, operation.Quantity);
            Assert.Equal(operationExpected.UnitCost, operation.UnitCost);
            Assert.Equal(operationExpected.Tax, operation.Tax);
            Assert.Equal(averageCostExpected, averageCost); 
            Assert.Equal(currentQuantityExpected, currentQuantity);
        }

        [Fact]
        public void HandleSellOperation_ShouldHandleWithSuccess_WhenLoss()
        {
            // Arrange
            double loss = 0.0;
            double averageCost = 10.0;
            int currentQuantity = 100;
            Operation operation = new(OperationType.sell, 5.0, 50);

            double lossExpected = -250.0;
            double averageCostExpected = 10.0;
            int currentQuantityExpected = 50;
            Operation operationExpected = new(OperationType.sell, 5.0, 50, 0.0);

            // Act
            _handler.HandleSellOperation(ref operation, ref averageCost, ref currentQuantity, ref loss);

            // Assert
            Assert.Equal(operationExpected.OperationType, operation.OperationType);
            Assert.Equal(operationExpected.Quantity, operation.Quantity);
            Assert.Equal(operationExpected.UnitCost, operation.UnitCost);
            Assert.Equal(operationExpected.Tax, operation.Tax);
            Assert.Equal(lossExpected, loss);
            Assert.Equal(averageCostExpected, averageCost);
            Assert.Equal(currentQuantityExpected, currentQuantity);
        }

        [Fact]
        public void HandleSellOperation_ShouldHandleWithSuccess_WhenGain()
        {
            // Arrange
            double loss = 0.0;
            double averageCost = 10.0;
            int currentQuantity = 2000;
            Operation operation = new(OperationType.sell, 25.0, 1000);

            double lossExpected = 0.0;
            double averageCostExpected = 10.0;
            int currentQuantityExpected = 1000;
            Operation operationExpected = new(OperationType.sell, 25.0, 1000, 3000);

            // Act
            _handler.HandleSellOperation(ref operation, ref averageCost, ref currentQuantity, ref loss);

            // Assert
            Assert.Equal(operationExpected.OperationType, operation.OperationType);
            Assert.Equal(operationExpected.Quantity, operation.Quantity);
            Assert.Equal(operationExpected.UnitCost, operation.UnitCost);
            Assert.Equal(operationExpected.Tax, operation.Tax);
            Assert.Equal(lossExpected, loss);
            Assert.Equal(averageCostExpected, averageCost);
            Assert.Equal(currentQuantityExpected, currentQuantity);
        }

        [Fact]
        public void HandleSellOperation_ShouldHandleWithSuccess_WhenGainWithLossBefore()
        {
            // Arrange
            double loss = -20000.0;
            double averageCost = 10.0;
            int currentQuantity = 2000;
            Operation operation = new(OperationType.sell, 25.0, 1000);

            double lossExpected = -5000.0;
            double averageCostExpected = 10.0;
            int currentQuantityExpected = 1000;
            Operation operationExpected = new(OperationType.sell, 25.0, 1000, 0.0);

            // Act
            _handler.HandleSellOperation(ref operation, ref averageCost, ref currentQuantity, ref loss);

            // Assert
            Assert.Equal(operationExpected.OperationType, operation.OperationType);
            Assert.Equal(operationExpected.Quantity, operation.Quantity);
            Assert.Equal(operationExpected.UnitCost, operation.UnitCost);
            Assert.Equal(operationExpected.Tax, operation.Tax);
            Assert.Equal(lossExpected, loss);
            Assert.Equal(averageCostExpected, averageCost);
            Assert.Equal(currentQuantityExpected, currentQuantity);
        }

        [Fact]
        public void HandleSellOperation_ShouldThrowJsonException_WhenInvalidData()
        {
            // Arrange
            double loss = 0.0;
            double averageCost = 10.0;
            int currentQuantity = 1000;
            Operation operation = new(OperationType.sell, 15.0, 2000);

            // Act
            var exception = Assert
                .Throws<InvalidOperationException>(() => _handler
                .HandleSellOperation(ref operation, ref averageCost, ref currentQuantity, ref loss));

            // Assert
            Assert.Contains("Invalid operation: The quantity of shares being " +
                "sold cannot exceed the current quantity of shares owned.", exception.Message);
        }
    }
}

