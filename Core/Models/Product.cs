using System.Text.Json.Serialization;

namespace Core.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int StoreId { get; set; }
        [JsonIgnore]
        public virtual Store Store { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
