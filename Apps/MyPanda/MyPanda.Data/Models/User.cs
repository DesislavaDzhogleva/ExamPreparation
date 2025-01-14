﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPanda.Data.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Receipts = new HashSet<Receipt>();
            this.Packages = new HashSet<Package>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        //[MinLength(5)] buisness logic
        [MaxLength(20)]
        public string Username { get; set; }
    
        [Required]
        [MaxLength(20)]
        public string Email { get; set; }
    
        [Required]
        public string Password { get; set; }
    
        public virtual ICollection<Package> Packages { get; set; }
    
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
