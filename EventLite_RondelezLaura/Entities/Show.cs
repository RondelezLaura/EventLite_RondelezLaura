using System;
using System.Collections.Generic;

namespace EventLite_RondelezLauraMVC.Entities
{
    public partial class Show
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int? TypeId { get; set; }
        public int? EventId { get; set; }
        public string Performer { get; set; }

        public Event Event { get; set; }
        public ShowType Type { get; set; }
    }
}
