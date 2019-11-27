using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieTicketBookingProject.Models
{
    public class Cart
    {
        public int id { get; set; }
        public string SeatNo { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public int MovieId { get; set; }


    }
}
