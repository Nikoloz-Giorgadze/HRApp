﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDatabaseModels.Models
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
    }
}
