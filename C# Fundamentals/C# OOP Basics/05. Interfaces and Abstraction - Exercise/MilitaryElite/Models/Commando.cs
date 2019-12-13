using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using System.Collections.Generic;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<IMission> missions;

        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<IMission>();
        }

        public ICollection<IMission> Missions
        {
            get => this.missions;
            set => this.missions = value;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nCorps: {this.Corps}\nMissions:{(this.Missions.Count == 0 ? "" : "\n")}{string.Join("\n", this.Missions)}";
        }
    }
}