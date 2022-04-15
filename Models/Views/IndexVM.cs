using DungeonsAndDragonsWeb.Models.Database;
using DungeonsAndDragonsWeb.Models.Resources;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonsAndDragonsWeb.Models.Views
{
    public class IndexVM
    {
        readonly bool autoUpdate;
        bool started;

        int chars;
        int games;
        int unis;
        List<Character> characters;

        public IndexVM() { started = false; characters = new List<Character>(); }
        public IndexVM(bool autoUpdate = true) : this() { this.autoUpdate = autoUpdate; Update(); }

        public int CharacterCount { get => chars; set => chars = value; }
        public int GameCount { get => games; set => games = value; }
        public int UniverseCount { get => unis; set => unis = value; }
        public List<Character> Characters { get => characters; set => characters = value; }

        public bool IsAutoUpdating { get => autoUpdate; }

        public bool Update()
        {
            if (DatabaseDelegator.HasRoute)
            {
                if (autoUpdate && !started)
                {
                    started = true;
                    Task t = new Task(() =>
                    {
                        while (true)
                        {
                            Update();
                            Thread.Sleep(new TimeSpan(24, 0, 0));
                        }
                    });
                    t.Start();
                    return true;
                }
                else
                {
                    chars = DatabaseDelegator.GetCharacterCount();
                    games = DatabaseDelegator.GetGameCount();
                    unis = DatabaseDelegator.GetUniverseCount();
                    return true;
                }
            }
            else return false;
        }
    }
}
