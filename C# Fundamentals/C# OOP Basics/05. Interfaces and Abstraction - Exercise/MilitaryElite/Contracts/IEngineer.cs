using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface IEngineer : ISpecialisedSoldier, ISoldier
    {
        ICollection<IRepair> Repairs { get; set; }
    }
}