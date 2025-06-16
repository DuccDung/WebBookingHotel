using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBookingHotel.Models;

namespace WebBookingHotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookingHotelDbContext _context;

        public HomeController(ILogger<HomeController> logger , BookingHotelDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult HandleLogin(string email , string password)
        {
            var isValidUser = _context.Users.Any(u => u.Email == email && u.PasswordHash == password && u.Role == "user");
            if (!isValidUser)
            {
                ViewBag.ErrorMessage = "Invalid email or password.";
                return View("Login");
            }
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.PasswordHash == password);
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetString("FullName", user.FullName);
            }
            return RedirectToAction("Index" , "Home");
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> HotelSource(int categoryId)
        {
            var cate =await _context.Categories.FindAsync(categoryId);
            return View(cate);
        }
        public IActionResult HotelDetail(int hotelIđ)  
        {
            return View();
        }
        public IActionResult Booking(int hotelId)
        {
            return View(hotelId);
        }
        public IActionResult HandleBooking(string lastName , string firstName , string email ,string phone, int roomOption , int hotelId , int price)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            _context.Bookings.Add(new Booking
            {
                UserId = userId.Value,
                RoomId = roomOption,
                CheckIn = DateOnly.FromDateTime(DateTime.Now),
                CheckOut = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                TotalPrice = price,
                Status = "pending",
                CreatedAt = DateTime.Now
            });
            _context.SaveChanges();
            return RedirectToAction("Index" , "Home");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
