using IMS.BLL.DTOs;
using IMS.BLL.Interfaces;
using IMS.DAL.Interfaces;
using IMS.Models;
using IMS.Models.Enums;

namespace IMS.BLL.Services
{
    public class StockService : IStockService
    {
        private readonly IProductRepository _productRepository;
        private readonly IStockRepository _stockRepository;

        public StockService(
            IProductRepository productRepository,
            IStockRepository stockRepository)
        {
            _productRepository = productRepository;
            _stockRepository = stockRepository;
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
                Quantity = dto.NewQuantity,
                PreviousQuantity = previousQuantity,
                NewQuantity = dto.NewQuantity,
                Remarks = dto.Remarks,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = username
            };

            await _stockRepository.AddTransactionAsync(transaction);

            await _productRepository.UpdateAsync(product);

            await _stockRepository.SaveChangesAsync();
        }

        //public async Task<List<StockTransaction>> GetTransactionHistoryAsync(int productId)
        //{
        //    return await _stockRepository.GetTransactionsByProductIdAsync(productId);
        //}

        public async Task<List<StockTransaction>> GetAllTransactionsAsync()
        {
            return await _stockRepository.GetAllTransactionsAsync();
        }
    }
}