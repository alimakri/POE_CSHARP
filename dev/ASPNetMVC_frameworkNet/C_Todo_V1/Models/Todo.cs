﻿using C_Todo_V1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace C_Todo_V1.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public bool Fait { get; set; }
    }
}