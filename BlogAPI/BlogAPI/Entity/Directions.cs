using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Entity
{
    public class Directions
    {
        public int Id { get; set; }

        public double StartLatitude { get; set; }

        public double StartLongitude { get; set; }

        public double DestLatitude { get; set; }

        public double DestLongitude { get; set; }
    }
}
