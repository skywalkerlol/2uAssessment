using Newtonsoft.Json;
using System;

namespace InvoiceApp.Model
{
    public class Invoice
    {
        [JsonProperty(PropertyName = "invoice_number")]
        public string InvoiceNumber { get; set; }
        [JsonProperty(PropertyName = "total")]
        public decimal Total { get; set; }
        [JsonProperty(PropertyName = "currrency")]
        public string Currrency { get; set; }
        [JsonProperty(PropertyName = "invoice_date")]
        public DateTime InvoiceDate { get; set; }
        [JsonProperty(PropertyName = "due_date")]
        public DateTime DueDate { get; set; }
        [JsonProperty(PropertyName = "vendor_name")]
        public string VendorName { get; set; }
        [JsonProperty(PropertyName = "remittance_address")]
        public string RemitToAddress { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "status")]
        public int InvoiceStatus { get; set; }
    }
}
