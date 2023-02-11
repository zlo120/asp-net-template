using Newtonsoft.Json;

namespace Core.Models
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product>? Products { get; set; }
        [JsonIgnore]
        public virtual ICollection<Store>? Stores { get; set; }
    }
}