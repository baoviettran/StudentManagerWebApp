﻿using System;
using System.Collections.Generic;

#nullable disable

namespace UserManagement_WebAPI.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastLoginDate { get; set; }


    }
}
