using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinlongHan.HotelManagementSystem.ApplicationCore.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int RTCode { get; set; }
        public bool? Status { get; set; }
        public RoomType Roomtype { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Roomservice> Roomservices { get; set; }
    }
}
