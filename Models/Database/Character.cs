using DungeonsAndDragonsWeb.Models.Resources;
using System.Collections.Generic;

namespace DungeonsAndDragonsWeb.Models.Database
{
    public class Character
    {
        int id;
        string name;
        string description;
        List<Ability> abilities;
        List<Aptitude> aptitudes;
        Dictionary<int, Item> objects;
        Race race;
        bool npc;

        public Character()
        {
            id = -1;
            abilities = new List<Ability>();
            aptitudes = new List<Aptitude>();
        }
        public Character(int id, string name) : this() { this.id = id; this.name = name; }
        public Character(int id, string name, string description) : this(id, name) { this.description = description; }
        public Character(int id, string name, string description, bool npc) : this(id, name, description) { this.npc = npc; }

        public int Id { get => id; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string ImagePath { get => ImageHandler.Get(typeof(Character), id); }
        internal List<Ability> Abilities { get => abilities; set => abilities = value; }
        internal List<Aptitude> Aptitudes { get => aptitudes; set => aptitudes = value; }
    }
}
