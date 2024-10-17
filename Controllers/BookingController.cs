using Microsoft.AspNetCore.Mvc;
using BookingSystem.Models;
using BookingSystem.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookingSystem.Data;
using Microsoft.EntityFrameworkCore;


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
            var bookings = await _bookingService.GetAllBookingsAsync();  
            return View(bookings);
        }

        // GET: /Booking/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // Populate dropdowns for Room and User

            var roomList = await GetRooms();
            var usersList = await GetUsers();            

            ViewBag.Rooms = roomList;
            ViewBag.Users = usersList;
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
            var roomList = await GetRooms();
            var usersList = await GetUsers();

            ViewBag.Rooms = roomList;
            ViewBag.Users = usersList;
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
            var roomList = await GetRooms();
            var usersList = await GetUsers();

            ViewBag.Rooms = roomList;
            ViewBag.Users = usersList;
            return View(booking);  
        }

        //// POST: /Booking/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(int id, BookingModel model)
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

            
            var roomList = await GetRooms();
            var usersList = await GetUsers();

            ViewBag.Rooms = roomList;
            ViewBag.Users = usersList;
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


        // View all bookings for a specific room
        [HttpGet]
        public async Task<IActionResult> ViewBookingsByRoom(int roomId)
        {
            var bookings = await _bookingService.GetBookingsByRoomAsync(roomId);
            return View(bookings);  
        }

        // View all bookings for a specific user
        [HttpGet]
        public async Task<IActionResult> ViewBookingsByUser(int userId)
        {
            var bookings = await _bookingService.GetBookingsByUserAsync(userId);
            return View(bookings);  
        }

        private async Task<List<SelectListItem>> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();

            List<SelectListItem> roomList = (from room in rooms
                                             select new SelectListItem
                                             {
                                                 Value = room.Id.ToString(),
                                                 Text = room.RoomName
                                             }).ToList();

            return roomList;
        }

        private async Task<List<SelectListItem>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            List<SelectListItem> userList = (from user in users
                                             select new SelectListItem
                                             {
                                                 Value = user.Id.ToString(),
                                                 Text = user.UserName
                                             }).ToList();

            return userList;
        }
    }
}
