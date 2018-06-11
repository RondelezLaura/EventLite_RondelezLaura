using System;
using System.Collections.Generic;

namespace EventLite_RondelezLauraMVC.Entities
{
    public partial class Visitor
    {
        public Visitor()
        {
            Subscription = new HashSet<Subscription>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public ICollection<Subscription> Subscription { get; set; }
    }
}
