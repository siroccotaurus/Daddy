using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndDragonsWeb.Models.Database
{
    public class Aptitude
    {
        string name;
        string description;
        int value;

        public Aptitude(string name, string description, int value)
        {
            this.name = name;
            this.value = value;
            this.description = description;
        }

        public string Name { get => name; set => name = value; }
        public int Value { get => value; set => this.value = value; }
    }
}
