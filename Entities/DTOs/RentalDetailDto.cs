using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public  class RentalDetailDto : IDto
    {
        public int RentalId { get; set; }
        public string CarName { get; set; }
        public  string UserName  { get; set; }
        public string  CustomerName { get; set; }
        public DateTime RentDate { get; set; } //kiralama tarih 
        public DateTime ReturnDate { get; set; }//teslim tarih 

    }
}
