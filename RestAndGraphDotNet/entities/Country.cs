using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAndGraphNet.entities
{
    public class Country
    {
        public Country(string name, string language)
        {
            Name = name;
            Language = language;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Language)}: {Language}";
        }
    }
}
