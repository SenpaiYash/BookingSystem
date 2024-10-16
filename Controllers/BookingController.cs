using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookingSystem.Models;
using BookingSystem.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookingSystem.Data;
using BookingSystem.Models.Entities;

namespace BookingSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly BookingContext _context;

        public BookingController(IBookingService bookingService, BookingContext context)
        {
            _bookingService = bookingService;
            _context = context;
        }

        // GET: /Booking/
        public async Task<IActionResult> Index()
        {
            var bookings = await _bookingService.GetBookingsByRoomAsync(1); // Example Room ID
            return View(bookings);
        }

        // GET: /Booking/Create
        [HttpGet]
        public IActionResult Create()
        {
            // Populate dropdowns for Room and User
            ViewBag.Rooms = new SelectList(_context.Rooms, "RoomID", "RoomName");
            ViewBag.Users = new SelectList(_context.Users, "UserID", "UserName");
            return View();
        }

        // POST: /Booking/Create
        [HttpPost]
        public async Task<IActionResult> Create(BookingModel model)
        {
            if (ModelState.IsValid)
            {
                await _bookingService.CreateBookingAsync(model);
                return RedirectToAction("Index");
            }

            // Repopulate dropdowns if validation fails
            ViewBag.Rooms = new SelectList(_context.Rooms, "RoomID", "RoomName");
            ViewBag.Users = new SelectList(_context.Users, "UserID", "UserName");
            return View(model);
        }


        // GET: /Booking/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            // Populate dropdowns for Room and User
            ViewBag.Rooms = new SelectList(_context.Rooms, "RoomID", "RoomName");
            ViewBag.Users = new SelectList(_context.Users, "UserID", "UserName");
            return View(booking);  // booking will be of type BookingModel
        }

        //// POST: /Booking/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Booking model)
        {
            if (ModelState.IsValid)
            {
                var booking = await _bookingService.GetBookingByIdAsync(id);
                if (booking == null)
                {
                    return NotFound();
                }

                booking.RoomID = model.RoomID;
                booking.UserID = model.UserID;
                booking.BookingDate = model.BookingDate;
                booking.StartTime = model.StartTime;
                booking.EndTime = model.EndTime;

                await _bookingService.UpdateBookingAsync(booking);
                return RedirectToAction("Index");
            }

            // Repopulate dropdowns if validation fails
            ViewBag.Rooms = new SelectList(_context.Rooms, "RoomID", "RoomName");
            ViewBag.Users = new SelectList(_context.Users, "UserID", "UserName");
            return View(model);
        }

        // GET: /Booking/Delete/{id}
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: /Booking/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookingService.DeleteBookingAsync(id);
            return RedirectToAction("Index");
        }

        
    }
}
