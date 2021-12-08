using CoreBusiness;
using System.Collections.Generic;

namespace UseCases
{
    public interface IGetTodayTransactionUseCase
    {
        public IEnumerable<Transaction> Execute(string cashierName);
    }
}