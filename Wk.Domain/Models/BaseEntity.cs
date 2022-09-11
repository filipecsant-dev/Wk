﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk.Domain.Models
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public bool ATIVO { get; set; }
    }
}
