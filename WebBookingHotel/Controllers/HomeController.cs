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
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
