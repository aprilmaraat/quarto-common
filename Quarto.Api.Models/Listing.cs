using Newtonsoft.Json;

namespace Quarto.Api.Models
{
    public class Listing
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ParentListing { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public AccommodationType AccomodationTypeID { get; set; }
        public AvailabilityType AvailabilityTypeID { get; set; }

        [JsonIgnore]
        public virtual EnumListingAccommodationType EnumListingAccommodationType  { get; set;}
        [JsonIgnore]
        public virtual EnumListingAvailabilityType EnumListingAvailabilityType { get; set; }
    }
}
