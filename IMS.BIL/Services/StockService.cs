using IMS.BLL.DTOs;
using IMS.BLL.Interfaces;
using IMS.DAL.Interfaces;
using IMS.Models;
using IMS.Models.Enums;
using Microsoft.Extensions.Logging;

namespace IMS.BLL.Services
{
    public class StockService : IStockService
    {
        private readonly IProductRepository _productRepository;
        private readonly IStockRepository _stockRepository;
        private readonly ILogger<StockService> _logger;

        public StockService(
            IProductRepository productRepository,
            IStockRepository stockRepository, 
            ILogger<StockService> logger)
        {
            _productRepository = productRepository;
            _stockRepository = stockRepository;
            _logger = logger;
        }

        public async Task StockInAsync(StockInDto dto, string username)
        {
            var product = await _productRepository.GetByIdAsync(dto.ProductId);

            if (product == null)
                throw new Exception("Product not found");

            int previousQuantity = product.Quantity;

            product.Quantity += dto.Quantity;

            var transaction = new StockTransaction
            {
                ProductId = product.Id,
                TransactionType = TransactionType.IN,
                Quantity = dto.Quantity,
                PreviousQuantity = previousQuantity,
                NewQuantity = product.Quantity,
                Remarks = dto.Remarks,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = username
            };

            await _stockRepository.AddTransactionAsync(transaction);

            await _productRepository.UpdateAsync(product);

            await _stockRepository.SaveChangesAsync();

            _logger.LogInformation(
                        "StockIn operation done for ProductId {ProductId} by {User}. Previous quantity {PreviousQuantity} new quantity {NewQuantity}",
                        product.Id,
                        username,
                        previousQuantity,
                        product.Quantity);
        }

        public async Task<bool> StockOutAsync(StockOutDto dto, string username)
        {
            var product = await _productRepository.GetByIdAsync(dto.ProductId);

            if (product == null)
                throw new Exception("Product not found");

            if (product.Quantity < dto.Quantity)
                return false;

            int previousQuantity = product.Quantity;

            product.Quantity -= dto.Quantity;

            var transaction = new StockTransaction
            {
                ProductId = product.Id,
                TransactionType = TransactionType.OUT,
                Quantity = dto.Quantity,
                PreviousQuantity = previousQuantity,
                NewQuantity = product.Quantity,
                Remarks = dto.Remarks,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = username
            };

            await _stockRepository.AddTransactionAsync(transaction);

            await _productRepository.UpdateAsync(product);

            await _stockRepository.SaveChangesAsync();

            _logger.LogInformation(
                        "StockOut operation done for ProductId {ProductId} by {User}. Previous quantity {PreviousQuantity} new quantity {NewQuantity}",
                        product.Id,
                        username,
                        previousQuantity,
                        product.Quantity);

            return true;
        }

        public async Task AdjustStockAsync(StockAdjustmentDto dto, string username)
        {
            var product = await _productRepository.GetByIdAsync(dto.ProductId);

            if (product == null)
                throw new Exception("Product not found");

            int previousQuantity = product.Quantity;

            product.Quantity = dto.NewQuantity;

            var transaction = new StockTransaction
            {
                ProductId = product.Id,
                TransactionType = TransactionType.ADJUSTMENT,
                Quantity = dto.NewQuantity - previousQuantity,
                PreviousQuantity = previousQuantity,
                NewQuantity = dto.NewQuantity,
                Remarks = dto.Remarks,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = username
            };

            await _stockRepository.AddTransactionAsync(transaction);

            await _productRepository.UpdateAsync(product);

            await _stockRepository.SaveChangesAsync();

            _logger.LogInformation(
                        "Adjust operation done for ProductId {ProductId} by {User}. Previous quantity {PreviousQuantity} new quantity {NewQuantity}",
                        product.Id,
                        username,
                        previousQuantity,
                        product.Quantity);
        }

        public async Task<(List<StockTransaction> Items, int TotalCount)> GetPagedTransactionsAsync(int page, int pageSize, string search = "", string transactionType = "", string createdBy = "")
        {
            return await _stockRepository.GetPagedTransactionsAsync(page, pageSize, search, transactionType, createdBy);
        }

        public async Task<List<string>> GetDistinctCreatedByAsync()
        {
            return await _stockRepository.GetDistinctCreatedByAsync();
        }
    }
}