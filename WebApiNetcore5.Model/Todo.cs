﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiNetcore5.Model
{
    public class Todo
    {
        [Key]
        public int TodoId { get; set; }
    }
}
