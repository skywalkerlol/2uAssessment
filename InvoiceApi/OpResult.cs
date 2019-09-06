using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApi
{
    public class OpResult
    {
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}
