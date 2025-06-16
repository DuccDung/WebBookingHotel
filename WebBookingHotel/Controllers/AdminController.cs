using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBookingHotel.Models;

namespace WebBookingHotel.Controllers
{
    public class AdminController : Controller
    {
        private readonly BookingHotelDbContext _context;
        public AdminController(BookingHotelDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Login(string email, string password)
        {
            var isValidUser =await _context.Users.AnyAsync(u => u.Email == email && u.PasswordHash == password && u.Role == "Admin");
            if(!isValidUser)
            {
                RedirectToAction("Index");
            }
            HttpContext.Session.SetString("Email", email);
            HttpContext.Session.SetString("Password", password);

            return RedirectToAction("DashBoard");
        }
        public IActionResult DashBoard()
        {
            return View();
        }
    }
}
