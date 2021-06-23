using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinlongHan.HotelManagementSystem.ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace XinlongHan.HotelManagementSystem.ApplicationCore.Models
{
    public class RoomtypeCreateRequestModel
    {
        public string RTDesc { get; set; }
        public decimal Rent { get; set; }
    }

    public class RoomserviceCreateRequestModel
    {
        public int RoomNo { get; set; }
        public string SDesc { get; set; }
        public decimal Amount { get; set; }
        public DateTime ServiceDate { get; set; }
        public Room Room { get; set; }
    }

    public class CustomerRegisterRequestModel
    {
        [Required(ErrorMessage = "Room Number cannot be empty")]
        public int RoomNo { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        public string CName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone cannot be empty")]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Checkin { get; set; }

        [Required]
        public int TotalPersons { get; set; }

        [Required]
        public int BookingDays { get; set; }

        [Required]
        public decimal? Advance { get; set; }
    }

    public class RoomCreateRequestModel
    {
        [Required]
        public int RTCode { get; set; }

        [Required]
        public byte Status { get; set; }
    }
    public class UserRegisterRequestModel
    {
        [Required(ErrorMessage = "make sure you entered firstname")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "make sure you entered lastname")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(128)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be atleast {2} characters long", MinimumLength = 8)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage =
            "Password Should have minimum 8 with at least one upper, lower, number and special character")]
        public string Password { get; set; }
       
    }
    public class LoginRequestModel
    {
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class CustomerRequest
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public string CName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? CheckIn { get; set; }
        public int? TotalPersons { get; set; }
        public int? BookingDays { get; set; }
        public decimal? Advance { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
    public class RoomRequestModel
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public bool? Status { get; set; }
    }

    public class ServiceRequest
    {
        public int Id { get; set; }
        public int? RoomNo { get; set; }
        public decimal? Amount { get; set; }
        public string SDESC { get; set; }
        public DateTime? ServiceDate { get; set; }
    }

    public class RoomTypeRequest
    {
        public int Id { get; set; }
        public string RTDESC { get; set; }
        public decimal? Rent { get; set; }
    }
}
