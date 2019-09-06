using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvoiceApp.Data;
using InvoiceApp.Model;

namespace InvoiceApp.Core
{
    public class InvoiceManager
    {
        IDocumentDBRepository<Invoice> Repository;
        public InvoiceManager(IDocumentDBRepository<Invoice> repo)
        {
            Repository = repo;
            Repository.Initialize();
        }
        public async Task<string> AddAsync(Invoice invoice)
        {
            //add validation here
            var doc = await Repository.CreateItemAsync(invoice);
            return doc.Id;
        }

        public async Task<bool> UpdateAsync(string id, Invoice invoice)
        {
            //add validation here
            var doc = await Repository.UpdateItemAsync(id, invoice);
            return true;//TODO improve the return type here
        }

        public async Task<Invoice> GetByIdAsync(string id)
        {
            Invoice invoice = await Repository.GetItemAsync(id);
            return invoice;
        }

        public async Task<IEnumerable<Invoice>> GetList(int status)
        {
            IEnumerable<Invoice> invoices = await Repository.GetItemsAsync(d => d.InvoiceStatus == status);
            return invoices;
        }
    }
}
