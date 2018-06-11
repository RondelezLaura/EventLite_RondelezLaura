using System;
using System.Collections.Generic;

namespace EventLite_RondelezLauraMVC.Entities
{
    public partial class Subscription
    {
        public int Id { get; set; }
        public int? VisitorId { get; set; }
        public int? EventId { get; set; }

        public Event Event { get; set; }
        public Visitor Visitor { get; set; }
    }
}
