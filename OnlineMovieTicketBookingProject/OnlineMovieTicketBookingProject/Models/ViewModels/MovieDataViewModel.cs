using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieTicketBookingProject.Models.ViewModels
{
    public class MovieDataViewModel
    {
   public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfMovie { get; set; }
        public string MoviePicture { get; set; }
    }
}
