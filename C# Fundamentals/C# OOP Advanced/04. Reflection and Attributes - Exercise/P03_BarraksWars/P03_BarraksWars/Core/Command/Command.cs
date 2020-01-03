namespace P03_BarraksWars.Core.Command
{
    using _03BarracksFactory.Contracts;

    public abstract class Command : IExecutable
    {
        private string[] data;
        private IRepository repository;
        private IUnitFactory unitFactory;

        protected Command(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            this.Data = data;
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        protected string[] Data
        {
            get { return data; }
            set { data = value; }
        }

        protected IRepository Repository
        {
            get { return repository; }
            set { repository = value; }
        }

        protected IUnitFactory UnitFactory
        {
            get { return unitFactory; }
            set { unitFactory = value; }
        }

        public abstract string Execute();
    }
}
