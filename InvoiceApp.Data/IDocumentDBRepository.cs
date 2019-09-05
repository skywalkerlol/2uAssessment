using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;

namespace InvoiceApp.Data
{
    public interface IDocumentDBRepository<T> where T : class
    {
        Task<Document> CreateItemAsync(T item);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(Expression<Func<T, bool>> predicate);
        void Initialize();
        Task<Document> UpdateItemAsync(string id, T item);
    }
}