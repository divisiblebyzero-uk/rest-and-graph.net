using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAndGraphNet.entities
{
    public class City
    {
        public City(string name, string size, Country country)
        {
            Name = name;
            Size = size;
            Country = country;
        }

        public City()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public Country Country { get; set; }
    }
}
