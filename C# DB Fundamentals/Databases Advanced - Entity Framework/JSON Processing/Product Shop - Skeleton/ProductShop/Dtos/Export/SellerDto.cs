using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProductShop.Dtos.Export
{
    public class SellerDto
    {
        [JsonProperty(PropertyName = "firstName")]
        public string SellerFirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string SellerLastName { get; set; }

        [JsonProperty(PropertyName = "soldProducts")]
        public List<SoldProductsDto> SoldProducts { get; set; }

        [JsonProperty(PropertyName = "age")]
        public int? Age { get; set; }
    }
}
