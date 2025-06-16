using System;
using System.Collections.Generic;

namespace WebBookingHotel.Models;

public partial class Hotel
{
    public int HotelId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public decimal? PriceFrom { get; set; }

    public double? Rating { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }
    public string? Img { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
    public virtual ICollection<HotelImage> HotelImages { get; set; } = new List<HotelImage>();

    public int? CategoryId { get; set; }
    public virtual Category? Category { get; set; }

}
