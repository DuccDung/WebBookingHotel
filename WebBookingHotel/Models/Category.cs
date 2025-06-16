namespace WebBookingHotel.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Img { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
    }

}
