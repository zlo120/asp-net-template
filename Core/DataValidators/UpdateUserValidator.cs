﻿using System.ComponentModel.DataAnnotations;

namespace Core.DataValidators
{
    public class UpdateUserValidator
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}