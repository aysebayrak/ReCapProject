﻿using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
  public   class CustomerDetailDto :IDto
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? FindexScore { get; set; }
        public string CompanyName { get; set; }
    }
}
