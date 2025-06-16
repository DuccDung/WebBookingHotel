using Microsoft.AspNetCore.Mvc;
using WebBookingHotel.Models;

namespace WebBookingHotel.Views.Shared.Components.AcountUser
{
    public class AcountUserViewComponent : ViewComponent
    {
        private readonly BookingHotelDbContext _context;
        public AcountUserViewComponent(BookingHotelDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                var user = await _context.Users.FindAsync(userId.Value);
                return View("AcountUser", user);
            }
            return View("Null"); 
        }
    }
}
