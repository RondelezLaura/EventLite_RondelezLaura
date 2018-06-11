using System;
using System.Collections.Generic;

namespace EventLite_RondelezLauraMVC.Entities
{
    public partial class ShowType
    {
        public ShowType()
        {
            Show = new HashSet<Show>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short Seats { get; set; }

        public ICollection<Show> Show { get; set; }
    }
}
