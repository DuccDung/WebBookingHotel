using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBookingHotel.Models;

namespace WebBookingHotel.Views.Shared.Components.TypeRoom
{

    public class TypeRoomViewComponent : ViewComponent
    {
        private readonly BookingHotelDbContext _context;
        public TypeRoomViewComponent(BookingHotelDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int hotelId)
        {
            var rooms = await _context.Rooms.Where(x => x.HotelId == hotelId).ToListAsync();
            return View("TypeRoom", rooms);
        }
    }
}
