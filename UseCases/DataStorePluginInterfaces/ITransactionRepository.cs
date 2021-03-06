using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITransactionRepository
    {
        public IEnumerable<Transaction> Get(string cashierName);

        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime day);

        public void Save(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty);

        IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate);
    }
}