using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class UserForUpdateDto :IDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
