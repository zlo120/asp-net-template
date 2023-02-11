using System.Text.Json.Serialization;

namespace Core.Models
{
    public class Store : BaseModel
    {
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<User>? Users { get; set; }
        [JsonIgnore]
        public virtual ICollection<Product>? Products { get;set; }
    }
}
