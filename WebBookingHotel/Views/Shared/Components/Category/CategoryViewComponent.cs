using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBookingHotel.Models;

namespace WebBookingHotel.Views.Shared.Components.CategoryViewComponent
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly BookingHotelDbContext _context;
        public CategoryViewComponent(BookingHotelDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int cateId)
        {
            var categories = await _context.Categories.ToListAsync();
            return View("CategoryHotel" , categories);
        }
    }
}
