using Newtonsoft.Json;

namespace Quarto.Api.Models
{
    public enum AvailabilityType : byte
    {
        Vacant = 1,
        Occupied = 2,
        NotAvailable = 3
    }
    public class EnumListingAvailabilityType
    {
        public AvailabilityType ID { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual Listing Listing { get; set; }
    }
}
