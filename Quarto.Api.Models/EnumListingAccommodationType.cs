using Newtonsoft.Json;

namespace Quarto.Api.Models
{
    public enum AccommodationType : byte
    {
        Room = 1,
        House = 2,
        Venue = 3,
        Resort = 4,
        OfficeSpace = 5
    }
    public class EnumListingAccommodationType
    {
        public AccommodationType ID { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual Listing Listing { get; set; }
    }
}
