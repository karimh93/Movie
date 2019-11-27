using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieTicketBookingProject.Models
{
    public class BookingTicket
    {
        public int Id { get; set; }
        public string SeatNo { get; set; }

        public string UserId { get; set; }
        public DateTime DateToPresent { get; set; }
        public int MovieDetailsId { get; set; }
        public int Amount { get; set; }
        [ForeignKey("MovieDetailsId")]
        public virtual MovieDetails MovieDetails { get; set; }


    }
}
