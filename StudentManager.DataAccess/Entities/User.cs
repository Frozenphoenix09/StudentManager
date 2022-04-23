﻿using System.ComponentModel.DataAnnotations;

namespace StudentManager.DataAccess.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
    }
}
