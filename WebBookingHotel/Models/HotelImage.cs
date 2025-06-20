﻿namespace WebBookingHotel.Models
{
    public class HotelImage
    {
        public int ImageId { get; set; }

        public int HotelId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Caption { get; set; }
        public bool IsThumbnail { get; set; }

        public virtual Hotel Hotel { get; set; } = null!;
    }

}
