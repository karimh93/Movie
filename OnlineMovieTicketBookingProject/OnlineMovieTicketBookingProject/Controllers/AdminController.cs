using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileUploadControl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineMovieTicketBookingProject.Data;
using OnlineMovieTicketBookingProject.Models;
using OnlineMovieTicketBookingProject.Models.ViewModels;

namespace OnlineMovieTicketBookingProject.Controllers
{
  

    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private IUpload _upload;

        public AdminController(ApplicationDbContext context,IUpload upload)
        {
            _context = context;
            _upload = upload;
        }
      

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IList<IFormFile> files, MovieDataViewModel model,MovieDetails movieDetails)
        {
            movieDetails.Movie_Name = model.Name;
            movieDetails.Movie_Description = model.Description;
            movieDetails.DateAndTime = model.DateOfMovie;

            foreach(var item in files)
            {
                movieDetails.MoviePicture = "~/uploads/" + item.FileName.Trim();
            }
            _upload.uploadMultipleFiles(files);
            _context.MovieDetails.Add(movieDetails);
            _context.SaveChanges();

            TempData["Sucess"] = "Save Your Movie";

            return RedirectToAction("Create","Admin");


            
            
        }

    }
}