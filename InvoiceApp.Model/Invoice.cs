using Newtonsoft.Json;
using System;

namespace InvoiceApp.Model
{
    public class Invoice
    {
        //public string invoice_number { get; set; }
        //public decimal total { get; set; }
        //public string currrency { get; set; }
        //public DateTime invoice_date { get; set; }
        //public DateTime due_date { get; set; }
        //public string vendor_name { get; set; }
        //public string remittance_address { get; set; }
        //[JsonProperty(PropertyName = "id")]
        //public string InvoiceId { get; set; }
        //public int invoice_status { get; set; }

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
        [JsonProperty(PropertyName = "invoice_status")]
        public int InvoiceStatus { get; set; }
    }
}
