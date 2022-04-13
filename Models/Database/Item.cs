using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndDragonsWeb.Models.Database
{
    public class Item
    {
        string name;
        string description;
        int value;
        List<Ability> abilities;

        public Item()
        {
            name = "";
            description = "";
            value = -1;
            abilities = new List<Ability>();
        }
        public Item(string name, string description, int value) : this()
        {
            this.name = name;
            this.description = description;
            this.value = value;
        }
        public Item(string name, string description, int value, List<Ability> abilities) : this(name, description, value)
        {
            this.abilities = abilities;
        }

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int Value { get => value; set => this.value = value; }
        internal List<Ability> Abilities { get => abilities; set => abilities = value; }
    }
}
