using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndDragonsWeb.Models.Database
{
    public class Race
    {
        string name;
        string description;

        public Race() { }
        public Race(string name) : this() { this.name = name; }
        public Race(string name, string description) : this(name) { this.description = description; }

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
    }
}
