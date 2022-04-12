using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Model.Payment
{
    public class Item

    {

        [JsonProperty("id")]
        public string Id { get; set; }

    }

    public class PaymentIntentCreateRequest

    {

        [JsonProperty("accId")]
        public string accId { get; set; } 
        [JsonProperty("amount")]
        public long amount { get; set; }



        [JsonProperty("items")]
        public Item[] Items { get; set; }

    }
}
