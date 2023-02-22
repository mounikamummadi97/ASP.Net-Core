﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class AuthenticatedResponse
    {
        [Key]
        public string? Token { get; set; }
    }
}
