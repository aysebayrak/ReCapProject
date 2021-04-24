using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public  class Rental: IEntity
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int CustomerID { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ReturnDate1 { get; set; }
    }
}
