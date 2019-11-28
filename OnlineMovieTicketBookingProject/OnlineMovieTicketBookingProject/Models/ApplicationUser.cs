using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieTicketBookingProject.Models
{
    
    public class ApplicationUser
    {
    public int Id { get; set; }
    public string UserName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public int MyProperty { get; set; }
    [Phone]
    public int PhoneNumber { get; set; }

    }
}
