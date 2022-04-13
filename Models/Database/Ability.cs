using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndDragonsWeb.Models.Database
{
    public class Ability
    {
        string name;
        string description;
        int value;

        public Ability(string name, string description, int value)
        {
            this.name = name;
            this.description = description;
            this.value = value;
        }

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int Value { get => value; set => this.value = value; }
    }
}
