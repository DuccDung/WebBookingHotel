using System;
using System.Collections.Generic;

namespace WebBookingHotel.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int UserId { get; set; }

    public int HotelId { get; set; }

    public int Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
