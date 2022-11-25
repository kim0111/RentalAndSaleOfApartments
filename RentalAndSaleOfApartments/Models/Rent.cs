using Microsoft.EntityFrameworkCore;

namespace RentalAndSaleOfApartments.Models
{
    public class Rent
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public int Rooms { get; set; }
        public string? SizeInM { get; set; }
        public string? Price { get; set; }
        public int RentalPeriodInMounth { get; set; }
        public string? OwnersPhone { get; set; }
        public bool isRenovation { get; set; }
        public DateTime PostedOnSite { get; set; }


    }

}
