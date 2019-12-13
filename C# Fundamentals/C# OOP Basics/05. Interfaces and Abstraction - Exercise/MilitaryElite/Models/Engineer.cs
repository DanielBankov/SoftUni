using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using System.Collections.Generic;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private ICollection<IRepair> repairs;

        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<IRepair>();
        }

        public ICollection<IRepair> Repairs
        {
            get => this.repairs;
            set => this.repairs = value;
        }

        public override string ToString()
        {
            if (this.Repairs.Count == 0)
            {
                return "Repairs:";
            }

            return base.ToString() + $"\nCorps: {this.Corps}\nRepairs:{(this.Repairs.Count == 0 ? "" : "\n")}{string.Join("\n", this.Repairs)}";
        }
    }
}