using System;
using System.Collections.Generic;

namespace EventLite_RondelezLauraMVC.Entities
{
    public partial class Event
    {
        public Event()
        {
            Show = new HashSet<Show>();
            Subscription = new HashSet<Subscription>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? VenueId { get; set; }
        public int? CategoryId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public decimal Price { get; set; }

        public Category Category { get; set; }
        public Venue Venue { get; set; }
        public ICollection<Show> Show { get; set; }
        public ICollection<Subscription> Subscription { get; set; }
    }
}
