using System;
using System.Collections.Generic;

namespace WebBookingHotel.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public int HotelId { get; set; }

    public string RoomType { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }
    public string? Img { get; set; }
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Hotel Hotel { get; set; } = null!;
}
