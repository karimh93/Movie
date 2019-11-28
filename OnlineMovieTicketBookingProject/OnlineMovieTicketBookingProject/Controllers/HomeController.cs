using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineMovieTicketBookingProject.Data;
using OnlineMovieTicketBookingProject.Models;
using OnlineMovieTicketBookingProject.Models.ViewModels;

namespace OnlineMovieTicketBookingProject.Controllers
{
    public class HomeController : Controller
    {
        int count = 1;
        bool flag = true;
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var getMovieList = _context.MovieDetails.ToList();

            return View(getMovieList);
        }
        [HttpGet]
        public IActionResult BookNow(int id)
        {
            BookNowViewModel model = new BookNowViewModel();
            var item = _context.MovieDetails.Where(a => a.id == id).FirstOrDefault();
            model.Movie_Name = item.Movie_Name;
            model.Movie_Date = item.DateAndTime;
            model.MovieId = item.id;

            return View(model);


        }

        [HttpPost]
        public IActionResult BookNow(BookNowViewModel model)
        {
            List<BookingTicket> bookings = new List<BookingTicket>();
            List<Cart> cart = new List<Cart>();
            string seatNo = model.SeatNo.ToString();
            int movieId = model.MovieId;

            string[] seatNoArray = seatNo.Split(',');
            count = seatNo.Length;
            if (checkSeat(seatNo, movieId) == false)
            {
                foreach (var item in seatNoArray)
                {
                    cart.Add(new Cart { Amount = 150, MovieId = model.MovieId, UserId = _userManager.GetUserId(HttpContext.User), Date = model.Movie_Date, SeatNo = item });
                }
                foreach (var item in cart)
                {
                    _context.Cart.Add(item);
                    _context.SaveChanges();
                }
                TempData["Sucess"] = "Seat no booked,check your Cart";

                }
                else
                {
                TempData["seatNoMsg"] = "Please check your seat number";
            }
            return RedirectToAction("BookNow");
        }

        private bool checkSeat(string seatNo, int movieId)
        {
            string seats = seatNo;
            string[] seatReserve = seats.Split(',');
            var seatNoList = _context.BookingTicket.Where(a => a.MovieDetailsId == movieId).ToList();
            foreach(var item in seatNoList)
            {
                string alreadyBooked = item.SeatNo;
                foreach(var item1 in seatReserve)
                {
                    if (item1 == alreadyBooked)
                    {
                        flag = false;
                        break;
                    }
                }
            }
            if (flag == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        public IActionResult CheckSeat(DateTime Movie_Date,BookNowViewModel model)
        {
            string seatNo = string.Empty;
            var movieList = _context.BookingTicket.Where(a => a.DateToPresent == Movie_Date).ToList();
            if (movieList == null)
            {
                var getSeatNo = movieList.Where(b => b.MovieDetailsId == model.MovieId).ToList();
                if (getSeatNo != null)
                {
                    foreach(var item in getSeatNo)
                    {
                        seatNo = seatNo + " " + item.SeatNo.ToString();
                    }
                    TempData["SNO"] = "Already Booked"+ seatNo;
                }
            }
            
            return View();
        }



        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page";
            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page";
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

