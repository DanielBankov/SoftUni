using Newtonsoft.Json;

namespace ProductShop.Dtos.Export
{
    public class SoldProductsDto
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "buyerFirstName")]
        public string BuyerFirstName { get; set; }

        [JsonProperty(PropertyName = "buyerLastName")]
        public string BuyerLastName { get; set; }
    }
}
