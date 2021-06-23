using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinlongHan.HotelManagementSystem.ApplicationCore.Exceptions
{
    public class ConflicException : Exception
    {
        public ConflicException(string massage) : base(massage)
        {

        }
    }
}
