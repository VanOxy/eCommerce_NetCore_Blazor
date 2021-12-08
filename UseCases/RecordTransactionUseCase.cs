using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class RecordTransactionUseCase : IRecordTransactionUseCase
    {
        private readonly ITransactionRepository transactionInMemoryRepository;
        private readonly IGetProductByIdUseCase getProductByIdUseCase;

        public RecordTransactionUseCase(
            ITransactionRepository TransactionInMemoryRepository,
            IGetProductByIdUseCase GetProductByIdUseCase)
        {
            transactionInMemoryRepository = TransactionInMemoryRepository;
            getProductByIdUseCase = GetProductByIdUseCase;
        }

        public void Execute(string cashierName, int productId, int qty)
        {
            var product = getProductByIdUseCase.Execute(productId);
            transactionInMemoryRepository.Save(cashierName, productId, product.Name, product.Price.Value, product.Quantity.Value, qty);
        }
    }
}