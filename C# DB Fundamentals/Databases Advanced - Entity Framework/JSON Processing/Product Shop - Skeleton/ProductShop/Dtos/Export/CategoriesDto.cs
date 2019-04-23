using Newtonsoft.Json;

namespace ProductShop.Dtos.Export
{
    public class CategoriesDto
    {
        [JsonProperty(PropertyName = "category")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "productsCount")]
        public int ProcuctsCount { get; set; }

        [JsonProperty(PropertyName = "averagePrice")]
        public string AveragePrice { get; set; }

        [JsonProperty(PropertyName = "totalRevenue")]
        public string Revenue { get; set; }
    }
}
