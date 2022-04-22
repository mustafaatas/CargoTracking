﻿using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class AdressDto
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public int? UserId { get; set; }
        public int ZIPCode { get; set; }
    }
}
