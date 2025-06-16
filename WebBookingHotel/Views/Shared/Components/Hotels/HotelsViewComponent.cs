using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBookingHotel.Models;

namespace WebBookingHotel.Views.Shared.Components.Hotels
{
    public class HotelsViewComponent : ViewComponent
    {
        private readonly BookingHotelDbContext _context;
        public HotelsViewComponent(BookingHotelDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int cateId)
        {
            var hotels = await _context.Hotels.Where(x => x.CategoryId == cateId).ToListAsync();
            return View("Hotel", hotels);
        }
    }
}
