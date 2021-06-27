using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get => roster.Count; }

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            if (Capacity > roster.Count)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            foreach (var player in roster)
            {
                if (player.Name == name)
                {
                    roster.Remove(player);
                    return true;
                }
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            foreach (var player in roster)
            {
                if (player.Name == name)
                {
                    player.Rank = "Member";
                    break;
                }
            }
        }

        public void DemotePlayer(string name)
        {
            foreach (var player in roster)
            {
                if (player.Name == name)
                {
                    player.Rank = "Trial";
                    break;
                }
            }
        }

        public Player[] KickPlayersByClass(string clas)
        {
            Player[] players;
            List<Player> all = new List<Player>();

            for (int i = 0; i < roster.Count - 1; i++)
            {
                if (roster[i].Class == clas)
                {
                    all.Add(roster[i]);
                    roster.Remove(roster[i]);
                    i--;
                }
            }

            players = all.ToArray();
            return players;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {Name}");
            sb.AppendLine($"{string.Join('\n', roster)}");

            return sb.ToString().TrimEnd();
        }
    }
}
