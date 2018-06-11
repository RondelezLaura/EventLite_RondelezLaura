﻿using System;
using System.Collections.Generic;

namespace EventLite_RondelezLauraMVC.Entities
{
    public partial class Category
    {
        public Category()
        {
            Event = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Event> Event { get; set; }
    }
}
