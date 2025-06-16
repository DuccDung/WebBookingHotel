using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBookingHotel.Models;

namespace WebBookingHotel.Views.Shared.Components.Account
{
    public class AccountViewComponent : ViewComponent
    {
        private readonly BookingHotelDbContext _context;
        public AccountViewComponent(BookingHotelDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var isCheck = HttpContext.Session.GetString("Email");
            var pass = HttpContext.Session.GetString("Password");
            if (isCheck != null)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == isCheck && u.PasswordHash == pass);

                return View("Account", user);
            }
            return View("Ac_null");
        }
    }
}
