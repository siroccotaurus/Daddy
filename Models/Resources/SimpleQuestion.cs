using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonsAndDragonsWeb.Models.Resources
{
    public class SimpleQuestion
    {
        public string text { get; set; }

        public SimpleQuestion() { }
        public SimpleQuestion(string text) : this() { this.text = text; }
    }
}
