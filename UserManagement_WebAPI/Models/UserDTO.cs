using System;
using System.Collections.Generic;

#nullable disable

namespace UserManagement_WebAPI.Models
{
    public partial class UserDto
    {
        
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
